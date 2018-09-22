using System;
using System.Linq;

namespace QData.Core
{
    public class Strs
    {
        public static string ComparedMsg(string expected, string actual) {
            // var the_end = "{THE END}";
            var the_diff = @"███ DiFF ███▶";

            var index = expected.Zip(actual, (c1, c2) => c1 == c2)
                                .TakeWhile(b => b)
                                .Count();
            var lineNum = expected.Substring(0, index)
                                .Count(c => c == '\n');
            var linePos = lineNum < 1? 0: expected
                                .Select((c, i) => new { c, i })
                                .Where(x => x.c == '\n')
                                .Skip(lineNum - 1)
                                .FirstOrDefault().i;
            var colNum = index - linePos;

            // var expected_diff_char = expected.Length > index ? expected[index].ToString() : "{THE END}";
            // var actual_diff_char = actual.Length > index ? actual[index].ToString() : "{THE END}";
            
            var expected_diff = expected.Insert(index, the_diff);
            var actual_diff = actual.Insert(index, the_diff);

            var start = index - 10;
            var len = the_diff.Length + 20;
            var msg = $@"
##################
# EXPECTED: 
""{expected_diff}""
##################
# ACTUAL: 
""{actual_diff}"" 
##################
# expected len: {expected.Length}
# actual len:   {actual.Length}
# diff index:   {index} (line {lineNum}, col {colNum})
""{expected_diff.Substring(Math.Max(start,0), len)}""
""{actual_diff.Substring(Math.Max(start,0), len)}""
##################";

            return msg;
        }
    }
}