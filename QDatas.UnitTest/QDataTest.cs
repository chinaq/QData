using Microsoft.VisualStudio.TestTools.UnitTesting;
using QDatas.Core;
using System;

namespace QDatas.UnitTest
{
    [TestClass]
    public class QDataTest
    {
        // HexStrToInt
        [TestMethod]
        public void HexStrToInt_Positive()
        {
            string hexStr = "00 00 01 0C ";
            int result = QData.StrHexToInt(hexStr);
            Assert.AreEqual(268, result);
        }

        [TestMethod]
        public void HexStrToInt_Negitive()
        {
            string hexStr = "F0 00 01 0C ";
            int result = QData.StrHexToInt(hexStr);
            Assert.AreEqual(-268435188, result);
        }



        // Bytes4ToInt
        [TestMethod]
        public void Bytes4ToInt()
        {
            byte[] bytes = new byte[] { 0xF0, 0x00, 0x01, 0x0C };
            int result = QData.Bytes4ToInt(bytes, 0);
            Assert.AreEqual(-268435188, result);
        }

        [TestMethod]
        public void Bytes4ToInt_Len_Gt_4()
        {
            byte[] bytes = new byte[] { 0x00, 0xF0, 0x00, 0x01, 0x0C };
            int result = QData.Bytes4ToInt(bytes, 1);
            Assert.AreEqual(-268435188, result);
        }



        // Bytes2ToInt
        [TestMethod]
        public void Bytes2ToInt()
        {
            byte[] bytes = new byte[] { 0x11, 0xaa, 0x22, 0xbb };
            int result = QData.Bytes2ToInt(bytes, 1);
            Assert.AreEqual(43554, result);
        }

        // Bytes4ToLong
        [TestMethod]
        public void Bytes4ToLong()
        {
            byte[] bytes = new byte[] { 0x00, 0x11, 0xFD, 0x41 };
            long result = QData.Bytes4ToLong(bytes, 0);
            Assert.AreEqual(1178945, result);
        }

        [TestMethod]
        public void Bytes4ToLong_Len_Gt_4()
        {
            byte[] bytes = new byte[] { 0x00, 0x00, 0x11, 0xFD, 0x41 };
            long result = QData.Bytes4ToLong(bytes, 1);
            Assert.AreEqual(1178945, result);
        }



        //Bytes4ToFloat
        [TestMethod]
        public void Bytes4ToFloat()
        {
            byte[] bytes = new Byte[] { 0x41, 0x8E, 0x58, 0xCA };
            float result = QData.Bytes4ToFloat(bytes, 0);
            Assert.AreEqual(17.79, result, 0.1);
        }




        // BytesToStrChars
        [TestMethod]
        public void BytesToStrChars()
        {
            byte[] bytes = new byte[] { 0x32, 0x38, 0x4A, 0x41, 0x31, 0x34, 0x31, 0x30, 0x30, 0x30, 0x30, 0x32 };
            string result = QData.BytesToStrChars(bytes);
            Assert.AreEqual("28JA14100002", result);
        }

        [TestMethod]
        public void BytesToStrChars_non_ascii()
        {
            byte[] bytes = new byte[] { 0xff, 0x38, 0x4A, 0x41, 0x31, 0x34, 0x31, 0x30, 0x30, 0x30, 0x30, 0x32 };
            string result = QData.BytesToStrChars(bytes);
            Assert.AreEqual("?8JA14100002", result);
        }



        // CheckSum
        [TestMethod]
        public void CheckSum()
        {
            byte[] bytes = new byte[] { 0x00, 0x11, 0x22, 0x55 };
            byte result = QData.CheckSum(bytes, 1, 2);
            Assert.AreEqual(0x33, result);
        }


        // str hex to long
        [TestMethod]
        public void StrToLong()
        {
            string strHex = "34 19 29";
            long result = QData.StrToLong(strHex);
            Assert.AreEqual(341929, result);
        }


        // bytes bcd to long
        [TestMethod]
        public void BytesBcdToLong()
        {
            byte[] bytes = new byte[] { 0x12, 0x23 };
            long result = QData.BytesBcdToLong(bytes, 0, 2);
            Assert.AreEqual(1223, result);
        }
    }
}
