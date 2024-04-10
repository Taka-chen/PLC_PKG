//taka add
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using AK_C_;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static IniFileHelper;
//---

namespace AK_C_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // 訂閱事件
            IniFileHelper.ReadCompleted += IniFileHelper_ReadCompleted;
            IniFileHelper.WriteCompleted += IniFileHelper_WriteCompleted;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 调用plc_process方法
            IniFileHelper.plc_process(null); // 假设这个方法现在不需要参数
        }

        private void IniFileHelper_ReadCompleted(string readResult)
        {
            // 由於這可能是從另一個線程調用，所以需要確保它在UI線程上執行
            if (InvokeRequired)
            {
                Invoke(new IniFileHelper.ReadCompletedEventHandler(IniFileHelper_ReadCompleted), readResult);
            }
            else
            {
                plc_info2.Text = readResult;
            }
        }
        private void IniFileHelper_WriteCompleted(string WriteResult)
        {
            // 由於這可能是從另一個線程調用，所以需要確保它在UI線程上執行
            if (InvokeRequired)
            {
                Invoke(new IniFileHelper.WriteCompletedEventHandler(IniFileHelper_WriteCompleted), WriteResult);
            }
            else
            {
                plc_info.Text = WriteResult;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

//taka add---
class IniFileHelper
{
    // 定義委託
    public delegate void ReadCompletedEventHandler(string readResult);
    // 定義事件
    public static event ReadCompletedEventHandler ReadCompleted;
    // 定義委託
    public delegate void WriteCompletedEventHandler(string writeResult);
    // 定義事件
    public static event WriteCompletedEventHandler WriteCompleted;

    public static void plc_process(string[] args)
    {
        // 创建PLC_PKG类的实例
        PLC_PKG plcPkg = new PLC_PKG("192.168.0.10", 8500, false);
        //PLC_PKG plcPkg = new PLC_PKG("192.160.0.10", 8500, false);

        // 调用Read方法
        string readResult;
        try
        {
            readResult = plcPkg.Read("DM6400");
            ReadCompleted?.Invoke(readResult);
        }
        catch (Exception ex)
        {
            // 處理異常，例如顯示錯誤信息
            readResult = "connect error when read";
            ReadCompleted?.Invoke(readResult);
        }
        // 调用Write方法
        string writeResult;
        try
        {
            writeResult = plcPkg.Write("DM6401", "1234");
            WriteCompleted?.Invoke(writeResult);
        }
        catch (Exception ex)
        {
            // 處理異常，例如顯示錯誤信息
            writeResult = "connect error when write";
            WriteCompleted?.Invoke(writeResult);
        }
        //if (writeResult)
        //{
        //    // 寫入成功
        //}
        //else
        //{
        //    // 寫入失敗
        //}
    }

    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

    public static void WriteValue(string section, string key, string value, string iniPath)
    {
        WritePrivateProfileString(section, key, value, iniPath);
    }
}
//---

