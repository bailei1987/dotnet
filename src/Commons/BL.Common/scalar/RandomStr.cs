using System;

namespace BL.Common.Scalar
{
    class RandomStr
    {
        public static string Create(int n)
        {
            var chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            var res = "";
            var random = new Random();
            for (var i = 0; i < n; i++)
            {
                res += chars[random.Next(0, 35)];
            }
            return res;
        }
    }
}
