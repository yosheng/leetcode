using System;

namespace Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            // 输出: 321
            Console.WriteLine(Reverse(123));
            
            // 输出: -321
            Console.WriteLine(Reverse(-123));
            
            // 输出: 21
            Console.WriteLine(Reverse(120));
        }

        private static int Reverse(int num)
        {
            var numStr = num < 0 ? (num*-1).ToString() : num.ToString();

            var reverseStr = string.Empty;

            for (int i = numStr.Length - 1; i >= 0; i--)
            {
                reverseStr += numStr[i];
            }

            if (num < 0)
            {
                reverseStr = $"-{reverseStr}";
            }

            try
            {
                return int.Parse(reverseStr);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}