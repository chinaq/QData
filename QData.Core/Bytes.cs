using System;
using System.Linq;

namespace QData.Core
{
    public class Bytes
    {
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
    }
}