# QData

[![NuGet version](https://badge.fury.io/nu/QData.svg)](https://badge.fury.io/nu/QData)
[![Build status](https://ci.appveyor.com/api/projects/status/w1ce121c2uvde2l3?svg=true)](https://ci.appveyor.com/project/chinaq/qdata)
[![codecov](https://codecov.io/gh/chinaq/QData/branch/master/graph/badge.svg)](https://codecov.io/gh/chinaq/QData)

- Q's Data Helper to convert data types among string, bytes, int and etc.

- Example
``` cs
[TestMethod]
public void HexStrToInt_Positive()
{
    string hexStr = "00 00 01 0C ";
    int result = Conv.StrHexToInt(hexStr);
    Assert.AreEqual(268, result);
}
```