﻿// This file is automatically generated by KvsStructConverter.exe.

using System;
using System.Runtime.InteropServices;

namespace KvStruct {
    class KvStruct {
        const int stMemArr_WSIZE = 100;
        const int stNode_WSIZE = 100;
        const int stParent_WSIZE = 100;


        public static int[] NewIndices(Array target) {
            int rank = target.Rank;
            int[] indices = new int[rank];
            Array.Clear(indices, 0, rank);
            indices[rank - 1]--;
            return indices;
        }

        public static void NextIndices(Array target, int[] indices) {
            int rank = target.Rank;
            indices[rank - 1]++;
            for (int dim = rank - 1; dim >= 0; dim--) {
                if (indices[dim] > target.GetUpperBound(dim)) {
                    if (dim == 0) break;
                    for (int j = dim; j < rank; j++) indices[j] = target.GetLowerBound(j);
                    indices[dim - 1]++;
                }
            }
        }

        public static Array CreateClassInstanceArray<T>(int[] sizes) {
            Array entity = Array.CreateInstance(typeof(T), sizes);
            int[] indices = NewIndices(entity);
            for (int i = 0; i < entity.Length; i++) {
                NextIndices(entity, indices);
                entity.SetValue(Activator.CreateInstance(typeof(T)), indices);
            }
            return entity;
        }

        private static void SwapBytes(byte[] tgt, int byteSize, int byteOffset = 0) {
            byte tmpByte;
            for (int i = 0; i < byteSize / 2; i++) {
                tmpByte = tgt[i * 2 + byteOffset];
                tgt[i * 2 + byteOffset] = tgt[i * 2 + 1 + byteOffset];
                tgt[i * 2 + 1 + byteOffset] = tmpByte;
            }
        }

        public static void ByteToBoolBase(Array dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            int byteOffset = (wordOffset * 2) + (bitOffset / 8);
            int byteBitOffset = bitOffset % 8;
            int[] indices = NewIndices(src);
            for (int i = 0; i < len; i++) {
                NextIndices(src, indices);
                dst.SetValue((src[((i + byteBitOffset) / 8) + byteOffset] & (1 << (i + byteBitOffset) % 8)) != 0, indices);
            }
        }

        public static void ByteToBool(ref bool dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            int byteOffset = (wordOffset * 2) + (bitOffset / 8);
            int byteBitOffset = bitOffset % 8;
            dst = (src[byteOffset] & 1 << byteBitOffset) != 0;
        }

        public static void ByteToBool(ref bool[] dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            ByteToBoolBase(dst, src, len, wordOffset, bitOffset);
        }
        public static void ByteToBool(ref bool[,] dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            ByteToBoolBase(dst, src, len, wordOffset, bitOffset);
        }
        public static void ByteToBool(ref bool[,,] dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            ByteToBoolBase(dst, src, len, wordOffset, bitOffset);
        }
        public static void ByteToBool(ref bool[,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            ByteToBoolBase(dst, src, len, wordOffset, bitOffset);
        }
        public static void ByteToBool(ref bool[,,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            ByteToBoolBase(dst, src, len, wordOffset, bitOffset);
        }
        public static void ByteToBool(ref bool[,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            ByteToBoolBase(dst, src, len, wordOffset, bitOffset);
        }
        public static void ByteToBool(ref bool[,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            ByteToBoolBase(dst, src, len, wordOffset, bitOffset);
        }
        public static void ByteToBool(ref bool[,,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            ByteToBoolBase(dst, src, len, wordOffset, bitOffset);
        }

        public static void ByteToShort(ref short dst, byte[] src, int len = 1, int wordOffset = 0) {
            dst = BitConverter.ToInt16(src, wordOffset * 2);
        }

        public static void ByteToShort(ref short[] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(short));
        }
        public static void ByteToShort(ref short[,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(short));
        }
        public static void ByteToShort(ref short[,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(short));
        }
        public static void ByteToShort(ref short[,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(short));
        }
        public static void ByteToShort(ref short[,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(short));
        }
        public static void ByteToShort(ref short[,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(short));
        }
        public static void ByteToShort(ref short[,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(short));
        }
        public static void ByteToShort(ref short[,,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(short));
        }

        public static void ByteToUshort(ref ushort dst, byte[] src, int len = 1, int wordOffset = 0) {
            dst = BitConverter.ToUInt16(src, wordOffset * 2);
        }

        public static void ByteToUshort(ref ushort[] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(ushort));
        }
        public static void ByteToUshort(ref ushort[,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(ushort));
        }
        public static void ByteToUshort(ref ushort[,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(ushort));
        }
        public static void ByteToUshort(ref ushort[,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(ushort));
        }
        public static void ByteToUshort(ref ushort[,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(ushort));
        }
        public static void ByteToUshort(ref ushort[,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(ushort));
        }
        public static void ByteToUshort(ref ushort[,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(ushort));
        }
        public static void ByteToUshort(ref ushort[,,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(ushort));
        }

        public static void ByteToInt(ref int dst, byte[] src, int len = 1, int wordOffset = 0) {
            dst = BitConverter.ToInt32(src, wordOffset * 2);
        }

        public static void ByteToInt(ref int[] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(int));
        }
        public static void ByteToInt(ref int[,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(int));
        }
        public static void ByteToInt(ref int[,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(int));
        }
        public static void ByteToInt(ref int[,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(int));
        }
        public static void ByteToInt(ref int[,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(int));
        }
        public static void ByteToInt(ref int[,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(int));
        }
        public static void ByteToInt(ref int[,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(int));
        }
        public static void ByteToInt(ref int[,,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(int));
        }

        public static void ByteToUint(ref uint dst, byte[] src, int len = 1, int wordOffset = 0) {
            dst = BitConverter.ToUInt32(src, wordOffset * 2);
        }

        public static void ByteToUint(ref uint[] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(uint));
        }
        public static void ByteToUint(ref uint[,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(uint));
        }
        public static void ByteToUint(ref uint[,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(uint));
        }
        public static void ByteToUint(ref uint[,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(uint));
        }
        public static void ByteToUint(ref uint[,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(uint));
        }
        public static void ByteToUint(ref uint[,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(uint));
        }
        public static void ByteToUint(ref uint[,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(uint));
        }
        public static void ByteToUint(ref uint[,,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(uint));
        }

        public static void ByteToFloat(ref float dst, byte[] src, int len = 1, int wordOffset = 0) {
            dst = BitConverter.ToSingle(src, wordOffset * 2);
        }

        public static void ByteToFloat(ref float[] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(float));
        }
        public static void ByteToFloat(ref float[,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(float));
        }
        public static void ByteToFloat(ref float[,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(float));
        }
        public static void ByteToFloat(ref float[,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(float));
        }
        public static void ByteToFloat(ref float[,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(float));
        }
        public static void ByteToFloat(ref float[,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(float));
        }
        public static void ByteToFloat(ref float[,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(float));
        }
        public static void ByteToFloat(ref float[,,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(float));
        }

        public static void ByteToDouble(ref double dst, byte[] src, int len = 1, int wordOffset = 0) {
            dst = BitConverter.ToDouble(src, wordOffset * 2);
        }

        public static void ByteToDouble(ref double[] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(double));
        }
        public static void ByteToDouble(ref double[,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(double));
        }
        public static void ByteToDouble(ref double[,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(double));
        }
        public static void ByteToDouble(ref double[,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(double));
        }
        public static void ByteToDouble(ref double[,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(double));
        }
        public static void ByteToDouble(ref double[,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(double));
        }
        public static void ByteToDouble(ref double[,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(double));
        }
        public static void ByteToDouble(ref double[,,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, wordOffset * 2, dst, 0, len * sizeof(double));
        }

        public static void ByteToString(ref byte[] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            byte[] strTmp = new byte[len * stringSize];
            Array.Copy(src, wordOffset * 2, strTmp, 0, len * stringSize);
            SwapBytes(strTmp, len * stringSize);
            Buffer.BlockCopy(strTmp, 0, dst, 0, len * stringSize);
        }
        public static void ByteToString(ref byte[,] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            byte[] strTmp = new byte[len * stringSize];
            Array.Copy(src, wordOffset * 2, strTmp, 0, len * stringSize);
            SwapBytes(strTmp, len * stringSize);
            Buffer.BlockCopy(strTmp, 0, dst, 0, len * stringSize);
        }
        public static void ByteToString(ref byte[,,] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            byte[] strTmp = new byte[len * stringSize];
            Array.Copy(src, wordOffset * 2, strTmp, 0, len * stringSize);
            SwapBytes(strTmp, len * stringSize);
            Buffer.BlockCopy(strTmp, 0, dst, 0, len * stringSize);
        }
        public static void ByteToString(ref byte[,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            byte[] strTmp = new byte[len * stringSize];
            Array.Copy(src, wordOffset * 2, strTmp, 0, len * stringSize);
            SwapBytes(strTmp, len * stringSize);
            Buffer.BlockCopy(strTmp, 0, dst, 0, len * stringSize);
        }
        public static void ByteToString(ref byte[,,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            byte[] strTmp = new byte[len * stringSize];
            Array.Copy(src, wordOffset * 2, strTmp, 0, len * stringSize);
            SwapBytes(strTmp, len * stringSize);
            Buffer.BlockCopy(strTmp, 0, dst, 0, len * stringSize);
        }
        public static void ByteToString(ref byte[,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            byte[] strTmp = new byte[len * stringSize];
            Array.Copy(src, wordOffset * 2, strTmp, 0, len * stringSize);
            SwapBytes(strTmp, len * stringSize);
            Buffer.BlockCopy(strTmp, 0, dst, 0, len * stringSize);
        }
        public static void ByteToString(ref byte[,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            byte[] strTmp = new byte[len * stringSize];
            Array.Copy(src, wordOffset * 2, strTmp, 0, len * stringSize);
            SwapBytes(strTmp, len * stringSize);
            Buffer.BlockCopy(strTmp, 0, dst, 0, len * stringSize);
        }
        public static void ByteToString(ref byte[,,,,,,,] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            byte[] strTmp = new byte[len * stringSize];
            Array.Copy(src, wordOffset * 2, strTmp, 0, len * stringSize);
            SwapBytes(strTmp, len * stringSize);
            Buffer.BlockCopy(strTmp, 0, dst, 0, len * stringSize);
        }

        public static void BoolToByteBase(ref byte[] dst, Array src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            int[] indices = NewIndices(dst);
            for (int i = 0; i < len; i++) {
                NextIndices(dst, indices);
                BoolToByte(ref dst, (bool)src.GetValue(indices), 1, wordOffset, bitOffset);
                bitOffset++;
                if (bitOffset >= 16) {
                    bitOffset = 0;
                    wordOffset++;
                }
            }
        }

        public static void BoolToByte(ref byte[] dst, bool src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            int byteOffset = (wordOffset * 2) + (bitOffset / 8);
            int byteBitOffset = bitOffset % 8;
            if (src) {
                dst[byteOffset] |= (byte)(1 << byteBitOffset);
            }
            else {
                dst[byteOffset] &= (byte)~(1 << byteBitOffset);
            }
        }

        public static void BoolToByte(ref byte[] dst, bool[] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            BoolToByteBase(ref dst, src, len, wordOffset, bitOffset);
        }
        public static void BoolToByte(ref byte[] dst, bool[,] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            BoolToByteBase(ref dst, src, len, wordOffset, bitOffset);
        }
        public static void BoolToByte(ref byte[] dst, bool[,,] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            BoolToByteBase(ref dst, src, len, wordOffset, bitOffset);
        }
        public static void BoolToByte(ref byte[] dst, bool[,,,] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            BoolToByteBase(ref dst, src, len, wordOffset, bitOffset);
        }
        public static void BoolToByte(ref byte[] dst, bool[,,,,] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            BoolToByteBase(ref dst, src, len, wordOffset, bitOffset);
        }
        public static void BoolToByte(ref byte[] dst, bool[,,,,,] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            BoolToByteBase(ref dst, src, len, wordOffset, bitOffset);
        }
        public static void BoolToByte(ref byte[] dst, bool[,,,,,,] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            BoolToByteBase(ref dst, src, len, wordOffset, bitOffset);
        }
        public static void BoolToByte(ref byte[] dst, bool[,,,,,,,] src, int len = 1, int wordOffset = 0, int bitOffset = 0) {
            BoolToByteBase(ref dst, src, len, wordOffset, bitOffset);
        }

        public static void ShortToByte(ref byte[] dst, short src, int len = 1, int wordOffset = 0) {
            Array.Copy(BitConverter.GetBytes(src), 0, dst, wordOffset * 2, len * sizeof(short));
        }

        public static void ShortToByte(ref byte[] dst, short[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(short));
        }
        public static void ShortToByte(ref byte[] dst, short[,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(short));
        }
        public static void ShortToByte(ref byte[] dst, short[,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(short));
        }
        public static void ShortToByte(ref byte[] dst, short[,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(short));
        }
        public static void ShortToByte(ref byte[] dst, short[,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(short));
        }
        public static void ShortToByte(ref byte[] dst, short[,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(short));
        }
        public static void ShortToByte(ref byte[] dst, short[,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(short));
        }
        public static void ShortToByte(ref byte[] dst, short[,,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(short));
        }

        public static void UshortToByte(ref byte[] dst, ushort src, int len = 1, int wordOffset = 0) {
            Array.Copy(BitConverter.GetBytes(src), 0, dst, wordOffset * 2, len * sizeof(ushort));
        }

        public static void UshortToByte(ref byte[] dst, ushort[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(ushort));
        }
        public static void UshortToByte(ref byte[] dst, ushort[,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(ushort));
        }
        public static void UshortToByte(ref byte[] dst, ushort[,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(ushort));
        }
        public static void UshortToByte(ref byte[] dst, ushort[,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(ushort));
        }
        public static void UshortToByte(ref byte[] dst, ushort[,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(ushort));
        }
        public static void UshortToByte(ref byte[] dst, ushort[,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(ushort));
        }
        public static void UshortToByte(ref byte[] dst, ushort[,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(ushort));
        }
        public static void UshortToByte(ref byte[] dst, ushort[,,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(ushort));
        }

        public static void IntToByte(ref byte[] dst, int src, int len = 1, int wordOffset = 0) {
            Array.Copy(BitConverter.GetBytes(src), 0, dst, wordOffset * 2, len * sizeof(int));
        }

        public static void IntToByte(ref byte[] dst, int[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(int));
        }
        public static void IntToByte(ref byte[] dst, int[,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(int));
        }
        public static void IntToByte(ref byte[] dst, int[,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(int));
        }
        public static void IntToByte(ref byte[] dst, int[,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(int));
        }
        public static void IntToByte(ref byte[] dst, int[,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(int));
        }
        public static void IntToByte(ref byte[] dst, int[,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(int));
        }
        public static void IntToByte(ref byte[] dst, int[,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(int));
        }
        public static void IntToByte(ref byte[] dst, int[,,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(int));
        }

        public static void UintToByte(ref byte[] dst, uint src, int len = 1, int wordOffset = 0) {
            Array.Copy(BitConverter.GetBytes(src), 0, dst, wordOffset * 2, len * sizeof(uint));
        }

        public static void UintToByte(ref byte[] dst, uint[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(uint));
        }
        public static void UintToByte(ref byte[] dst, uint[,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(uint));
        }
        public static void UintToByte(ref byte[] dst, uint[,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(uint));
        }
        public static void UintToByte(ref byte[] dst, uint[,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(uint));
        }
        public static void UintToByte(ref byte[] dst, uint[,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(uint));
        }
        public static void UintToByte(ref byte[] dst, uint[,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(uint));
        }
        public static void UintToByte(ref byte[] dst, uint[,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(uint));
        }
        public static void UintToByte(ref byte[] dst, uint[,,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(uint));
        }

        public static void FloatToByte(ref byte[] dst, float src, int len = 1, int wordOffset = 0) {
            Array.Copy(BitConverter.GetBytes(src), 0, dst, wordOffset * 2, len * sizeof(float));
        }

        public static void FloatToByte(ref byte[] dst, float[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(float));
        }
        public static void FloatToByte(ref byte[] dst, float[,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(float));
        }
        public static void FloatToByte(ref byte[] dst, float[,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(float));
        }
        public static void FloatToByte(ref byte[] dst, float[,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(float));
        }
        public static void FloatToByte(ref byte[] dst, float[,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(float));
        }
        public static void FloatToByte(ref byte[] dst, float[,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(float));
        }
        public static void FloatToByte(ref byte[] dst, float[,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(float));
        }
        public static void FloatToByte(ref byte[] dst, float[,,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(float));
        }

        public static void DoubleToByte(ref byte[] dst, double src, int len = 1, int wordOffset = 0) {
            Array.Copy(BitConverter.GetBytes(src), 0, dst, wordOffset * 2, len * sizeof(double));
        }

        public static void DoubleToByte(ref byte[] dst, double[] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(double));
        }
        public static void DoubleToByte(ref byte[] dst, double[,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(double));
        }
        public static void DoubleToByte(ref byte[] dst, double[,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(double));
        }
        public static void DoubleToByte(ref byte[] dst, double[,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(double));
        }
        public static void DoubleToByte(ref byte[] dst, double[,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(double));
        }
        public static void DoubleToByte(ref byte[] dst, double[,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(double));
        }
        public static void DoubleToByte(ref byte[] dst, double[,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(double));
        }
        public static void DoubleToByte(ref byte[] dst, double[,,,,,,,] src, int len = 1, int wordOffset = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * sizeof(double));
        }

        public static void StringToByte(ref byte[] dst, byte[] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * stringSize);
            SwapBytes(dst, len * stringSize, wordOffset * 2);
        }
        public static void StringToByte(ref byte[] dst, byte[,] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * stringSize);
            SwapBytes(dst, len * stringSize, wordOffset * 2);
        }
        public static void StringToByte(ref byte[] dst, byte[,,] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * stringSize);
            SwapBytes(dst, len * stringSize, wordOffset * 2);
        }
        public static void StringToByte(ref byte[] dst, byte[,,,] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * stringSize);
            SwapBytes(dst, len * stringSize, wordOffset * 2);
        }
        public static void StringToByte(ref byte[] dst, byte[,,,,] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * stringSize);
            SwapBytes(dst, len * stringSize, wordOffset * 2);
        }
        public static void StringToByte(ref byte[] dst, byte[,,,,,] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * stringSize);
            SwapBytes(dst, len * stringSize, wordOffset * 2);
        }
        public static void StringToByte(ref byte[] dst, byte[,,,,,,] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * stringSize);
            SwapBytes(dst, len * stringSize, wordOffset * 2);
        }
        public static void StringToByte(ref byte[] dst, byte[,,,,,,,] src, int len = 1, int wordOffset = 0, int stringSize = 0) {
            Buffer.BlockCopy(src, 0, dst, wordOffset * 2, len * stringSize);
            SwapBytes(dst, len * stringSize, wordOffset * 2);
        }
    }
}
