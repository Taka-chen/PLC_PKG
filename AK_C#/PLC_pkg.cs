using System;
using EasyModbus; // 确保添加了此using指令
using System.Net.Sockets;
using System.Threading;
using KHL = KvHostLink.KvHostLink;
using KHST = KvStruct.KvStruct;
using Microsoft.VisualBasic.Devices;

namespace AK_C_
{
    public class PLC_PKG // 确保类是public
    {
        public enum DataType // 确保枚举是public
        {
            Unsigned_16bit_OCT = 1,
            Signed_16bit_OCT,
            Unsigned_32bit_OCT,
            Signed_32bit_OCT,
            None_16bit_HEX,
            Signed_32bit_Float,
            Signed_64bit_Double
        }

        private ModbusClient modbusClient;
        private bool _logStatus = false;
        private bool _isBypass = false;
        private readonly object _threadLock = new object();

        public PLC_PKG(string IP, int Port = 8500, bool isBypass = false)
        {
            modbusClient = new ModbusClient(IP, Port);
            _isBypass = isBypass;
            int sock = 0;
            ushort ushortport = (ushort)Port;
            if (!_isBypass)
            {
                int err = KHL.KHLInit();
                try
                {
                    var result = KHL.KHLConnect(IP, ushortport, 3000, KvHostLink.KHLSockType.SOCK_TCP, ref sock);
                    Console.WriteLine("Init PLC Connection - Success !");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Init PLC Connection - Fail ! {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Bypass PLC Init Connection!!");
            }
        }

        public void SetLogStatus(bool status)
        {
            _logStatus = status;
        }

        public string Read(string plcMem)
        {
            if (_isBypass)
            {
                return "Bypass mode - Read operation skipped.";
            }

            lock (_threadLock)
            {
                int address = Convert.ToInt16(plcMem.Substring(2)); // 先把DM省略
                uint address_uint = (uint)address;
                int sock = 0;
                int err = 0;
                int reasponse = 0;
                byte[] readBuf = new byte[2];
                // 讀取
                var result = KHL.KHLConnect("192.168.0.10", 8500, 3000, KvHostLink.KHLSockType.SOCK_TCP, ref sock);
                err = KHL.KHLReadDevicesAsWords(sock, KvHostLink.KHLDevType.DEV_DM, address_uint, 1, readBuf);
                if (err == 0) {
                    reasponse = readBuf[0] + readBuf[1] * 256;
                }
                else
                {
                    reasponse = -1;
                }
                return string.Join(", ", reasponse);
            }
        }

        public string Write(string plcMem, string message)
        {
            if (_isBypass)
            {
                return "Bypass mode - Read operation skipped.";
            }

            lock (_threadLock)
            {
                int address = Convert.ToInt16(plcMem.Substring(2)); // 先把DM省略
                uint address_uint = (uint)address;
                int sock = 0;
                int err = 0;
                int err2 = 0;
                int reasponse = 0;
                byte[] writeBuf = new byte[2];
                byte[] readBuf = new byte[2];
                //把要寫入的值轉為二進制
                int writeValue = Convert.ToInt16(message);
                writeBuf[0] = (byte)(writeValue & 0xFF);
                writeBuf[1] = (byte)((writeValue >> 8) & 0xFF);

                // 读取操作
                var result = KHL.KHLConnect("192.168.0.10", 8500, 3000, KvHostLink.KHLSockType.SOCK_TCP, ref sock);
                err = KHL.KHLWriteDevicesAsWords(sock, KvHostLink.KHLDevType.DEV_DM, address_uint, 1, writeBuf);
                err2 = KHL.KHLReadDevicesAsWords(sock, KvHostLink.KHLDevType.DEV_DM, address_uint, 1, readBuf);
                if (err == 0 && err2==0)
                {
                    reasponse = readBuf[0] + readBuf[1] * 256;
                }
                else
                {
                    reasponse = -1;
                }
                return string.Join(", ", reasponse); // 将结果转换为逗号分隔的字符串
            }
        }

        private string GetDataTypeSuffix(DataType dataType)
        {
            switch (dataType)
            {
                case DataType.Unsigned_16bit_OCT: return ".U";
                case DataType.Signed_16bit_OCT: return ".S";
                // 完善其他數據類型對應的後綴
                default: return string.Empty;
            }
        }

        // 實現msTime和isTimeout功能
        private static long MsTime() => DateTimeOffset.Now.ToUnixTimeMilliseconds();

        private static bool IsTimeout(long startTime, int timeoutMs)
        {
            return MsTime() - startTime > timeoutMs;
        }
    }
}
