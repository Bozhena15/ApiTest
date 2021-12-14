using System;
using System.Linq;

namespace ApiTest.Utils
{
    public static class UtilsString
    {
        public static string GetRandomString(int length)
        {
            var r = new Random();
            return new String(Enumerable.Range(0, length).Select(n => (Char)(r.Next(32, 127))).ToArray());
        }
    }
}