using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace QData.Core
{
    /// <summary>
    /// Q's Data Helper
    /// get from https://github.com/chinaq/QData.git
    /// </summary>

    public class Conv
    {
        // 16 进制 string 转 int
        public static int StrHexToInt(string strHex)
        {
            return Convert.ToInt32(strHex.Replace(" ", ""), 16);
        }

        // 16 进制 string 转 long
        public static long StrToLong(string strHex)
        {
            return long.Parse(strHex.Replace(" ", ""));
        }

        // 16 进制 bcd 转 long
        public static long BytesBcdToLong(byte[] bytes, int start, int len)
        {
            return Conv.StrToLong(Conv.BytesToStrHex(bytes, start, len));
        }

        public static long BytesBcdToLong(byte[] bytes)
        {
            return Conv.StrToLong(Conv.BytesToStrHex(bytes));
        }





        // 4 Bytes 转 int，大端在前
        public static int Bytes4ToInt(byte[] bytes, int start)
        {
            byte[] newBytes = ResetBytes(bytes, start, 4);
            return BitConverter.ToInt32(newBytes, 0);
        }

        // 4 bytes 转 long，大端在前
        public static long Bytes4ToLong(byte[] bytes, int start)
        {
            byte[] newBytes = ResetBytes(bytes, start, 4);
            return BitConverter.ToUInt32(newBytes, 0);
        }

        // 4 bytes 转 float, 大端在前
        public static float Bytes4ToFloat(byte[] bytes, int start)
        {
            byte[] newBytes = ResetBytes(bytes, start, 4);
            return BitConverter.ToSingle(newBytes, 0);
        }

        // 2 bytes 转 int， 大端在前
        public static int Bytes2ToInt(byte[] bytes, int start)
        {
            byte[] newBytes = ResetBytes(bytes, start, 2);
            return BitConverter.ToUInt16(newBytes, 0);
        }


        private static byte[] ResetBytes(byte[] bytes, int start, int len)
        {
            var newBytes = CopyBytes(bytes, start, len);
            IfLittleEndianThenRevers(ref newBytes);
            return newBytes;
        }

        private static byte[] CopyBytes(byte[] bytes, int start, int len)
        {
            byte[] newBytes = bytes.Skip(start).Take(len).ToArray();
            return newBytes;
        }

        private static void IfLittleEndianThenRevers(ref byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
        }




        // bytes 转 char 字符串
        public static string BytesToStrChars(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }



        // bytes 转 char 字符串
        public static string BytesToStrChars(byte[] bytes, int start, int len)
        {
            return Encoding.ASCII.GetString(bytes, start, len);
        }



        // 16 进制 字符串 转 byte 数组
        public static byte[] StrHexToBytes(string hexStr, string separator = " ")
        {
            byte[] bytes = hexStr.Trim().Split(separator.ToCharArray())
                .Select(x => byte.Parse(x, NumberStyles.HexNumber))
                .ToArray();
            return bytes;
        }


        // 校验和
        public static byte CheckSum(byte[] bytes, int start, int len)
        {
            byte checkByte = 0;
            for (int i = start; i < start + len; i++)
            {
                checkByte += bytes[i];
            }
            return checkByte;
        }



        // 组合数组
        public static byte[] Combine(params byte[][] listOfByteArrays)
        {
            int len = listOfByteArrays.Sum(c => c.Length);
            byte[] result = new byte[len];

            int lastLen = 0;
            for (int i = 0; i < listOfByteArrays.Length; i++)
            {
                byte[] bytes = listOfByteArrays[i];
                Buffer.BlockCopy(bytes, 0, result, lastLen, bytes.Length);
                lastLen += bytes.Length;
            }
            return result;
        }


        // 子数组
        public static byte[] SubArray(byte[] bytes, int start, int len)
        {
            return bytes.Skip(start).Take(len).ToArray();
        }


        // 数组转字符串
        public static string BytesToStrHex(byte[] bytes, int start, int len, string separator = " ")
        {
            string hexStr = BitConverter.ToString(bytes, start, len);
            if (separator != "-")
                hexStr = hexStr.Replace("-", separator);
            return hexStr;
        }

        public static string BytesToStrHex(byte[] bytes, string separator = " ")
        {
            string hexStr = BitConverter.ToString(bytes);
            hexStr = ReplaceSeparator(hexStr, separator);
            return hexStr;
        }

        private static string ReplaceSeparator(string hexStr, string separator)
        {
            if (separator != "-")
                hexStr = hexStr.Replace("-", separator);
            return hexStr;
        }
    }
}
