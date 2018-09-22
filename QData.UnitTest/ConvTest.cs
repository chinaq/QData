using Microsoft.VisualStudio.TestTools.UnitTesting;
using QData.Core;
using System;

namespace QData.UnitTest
{
    [TestClass]
    public class ConvTest
    {
        ///////////////////////////
        // HexStrToInt
        ///////////////////////////
        [TestMethod]
        public void HexStrToInt_Positive()
        {
            string hexStr = "00 00 01 0C ";
            int result = Conv.StrHexToInt(hexStr);
            Assert.AreEqual(268, result);
        }

        [TestMethod]
        public void HexStrToInt_Negitive()
        {
            string hexStr = "F0 00 01 0C ";
            int result = Conv.StrHexToInt(hexStr);
            Assert.AreEqual(-268435188, result);
        }



        ///////////////////////////
        // BytesToInt
        ///////////////////////////
        // Bytes4ToInt
        [TestMethod]
        public void Bytes4ToInt()
        {
            byte[] bytes = new byte[] { 0xF0, 0x00, 0x01, 0x0C };
            int result = Conv.Bytes4ToInt(bytes, 0);
            Assert.AreEqual(-268435188, result);
        }

        [TestMethod]
        public void Bytes4ToInt_Len_Gt_4()
        {
            byte[] bytes = new byte[] { 0x00, 0xF0, 0x00, 0x01, 0x0C };
            int result = Conv.Bytes4ToInt(bytes, 1);
            Assert.AreEqual(-268435188, result);
        }



        // Bytes2ToInt
        [TestMethod]
        public void Bytes2ToInt()
        {
            byte[] bytes = new byte[] { 0x11, 0xaa, 0x22, 0xbb };
            int result = Conv.Bytes2ToInt(bytes, 1);
            Assert.AreEqual(43554, result);
        }


        ///////////////////////////
        // Bytes4ToLong
        ///////////////////////////
        [TestMethod]
        public void Bytes4ToLong()
        {
            byte[] bytes = new byte[] { 0x00, 0x11, 0xFD, 0x41 };
            long result = Conv.Bytes4ToLong(bytes, 0);
            Assert.AreEqual(1178945, result);
        }

        [TestMethod]
        public void Bytes4ToLong_Len_Gt_4()
        {
            byte[] bytes = new byte[] { 0x00, 0x00, 0x11, 0xFD, 0x41 };
            long result = Conv.Bytes4ToLong(bytes, 1);
            Assert.AreEqual(1178945, result);
        }



        ///////////////////////////
        //Bytes4ToFloat
        ///////////////////////////
        [TestMethod]
        public void Bytes4ToFloat()
        {
            byte[] bytes = new Byte[] { 0x41, 0x8E, 0x58, 0xCA };
            float result = Conv.Bytes4ToFloat(bytes, 0);
            Assert.AreEqual(17.79, result, 0.1);
        }




        ///////////////////////////
        // BytesToStrChars
        ///////////////////////////
        [TestMethod]
        public void BytesToStrChars()
        {
            byte[] bytes = new byte[] { 0x32, 0x38, 0x4A, 0x41, 0x31, 0x34, 0x31, 0x30, 0x30, 0x30, 0x30, 0x32 };
            string result = Conv.BytesToStrChars(bytes);
            Assert.AreEqual("28JA14100002", result);
        }

        [TestMethod]
        public void BytesToStrChars_non_ascii()
        {
            byte[] bytes = new byte[] { 0xff, 0x38, 0x4A, 0x41, 0x31, 0x34, 0x31, 0x30, 0x30, 0x30, 0x30, 0x32 };
            string result = Conv.BytesToStrChars(bytes);
            Assert.AreEqual("?8JA14100002", result);
        }

        [TestMethod]
        public void BytesToStrChars_with_len_paras()
        {
            byte[] bytes = new byte[] { 0xff, 0x38, 0x4A, 0x41, 0x31, 0x34, 0x31, 0x30, 0x30, 0x30, 0x30, 0x32 };
            string result = Conv.BytesToStrChars(bytes, 1, 2);
            Assert.AreEqual("8J", result);
        }

        ///////////////////////////
        // CheckSum
        ///////////////////////////
        [TestMethod]
        public void CheckSum()
        {
            byte[] bytes = new byte[] { 0x00, 0x11, 0x22, 0x55 };
            byte result = Conv.CheckSum(bytes, 1, 2);
            Assert.AreEqual(0x33, result);
        }


        ///////////////////////////
        // str hex to long
        ///////////////////////////
        [TestMethod]
        public void StrToLong()
        {
            string strHex = "34 19 29";
            long result = Conv.StrToLong(strHex);
            Assert.AreEqual(341929, result);
        }


        ///////////////////////////
        // bytes bcd to long
        ///////////////////////////
        [TestMethod]
        public void BytesBcdToLong_with_len_paras()
        {
            byte[] bytes = new byte[] { 0x12, 0x23 };
            long result = Conv.BytesBcdToLong(bytes, 0, 2);
            Assert.AreEqual(1223, result);
        }

        [TestMethod]
        public void BytesBcdToLong() {
            byte[] bytes = new byte[] { 0x12, 0x23 };
            long result = Conv.BytesBcdToLong(bytes);
            Assert.AreEqual(1223, result);
        }





        ///////////////////////////
        // str hex to bytes
        ///////////////////////////
        [TestMethod]
        public void StrHexToBytes() {
            var bytes = Conv.StrHexToBytes("12 34 ab cd");
            CollectionAssert.AreEqual(new byte[] {0x12,0x34,0xab,0xcd}, bytes);
        }
    }
}
