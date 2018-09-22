using Microsoft.VisualStudio.TestTools.UnitTesting;
using QData.Core;

namespace QData.UnitTest
{
    [TestClass]
    public class BytesTest
    {
        [TestMethod]
        public void Combine() {
            var byte0 = new byte[] {12, 34};
            var byte1 = new byte[] {56, 78};
            var byte2 = new byte[] {90};
            // action
            var combined = Bytes.Combine(byte0, byte1, byte2);
            // assert
            var expected = new byte[] {12, 34, 56, 78, 90};
            CollectionAssert.AreEqual(expected, combined);
        }
        
    }
}