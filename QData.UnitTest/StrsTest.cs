using Microsoft.VisualStudio.TestTools.UnitTesting;
using QData.Core;

namespace QData.UnitTest
{
    [TestClass]
    public class StrsTest
    {
        [TestMethod]
        public void ComparedMsg() {
            var cmp1 = "sadfasfgfdgljl;hkhgasdfip[pgsjlxjam./xzcvjg";
            var cmp2 = "sadfasfgfdgljl;hkhgasdgip[pgsjlxjam./xzcvjgvv";

            var result = Strs.ComparedMsg(cmp1, cmp2);
            var expected = @"
##################
# EXPECTED: 
""sadfasfgfdgljl;hkhgasd███ DiFF ███▶fip[pgsjlxjam./xzcvjg""
##################
# ACTUAL: 
""sadfasfgfdgljl;hkhgasd███ DiFF ███▶gip[pgsjlxjam./xzcvjgvv"" 
##################
# expected len: 43
# actual len:   45
# diff index:   22 (line 0, col 22)
""jl;hkhgasd███ DiFF ███▶fip[pgsjlx""
""jl;hkhgasd███ DiFF ███▶gip[pgsjlx""
##################";

            Assert.AreEqual(expected, result);
        }
        
    }
}