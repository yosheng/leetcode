using System;

namespace IsPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPalindromeByString(121));
            Console.WriteLine(IsPalindromeByString(-121));
            Console.WriteLine(IsPalindromeByString(10));
            
            Console.WriteLine(IsPalindromeByNum(121));
            Console.WriteLine(IsPalindromeByNum(-121));
            Console.WriteLine(IsPalindromeByNum(10));
        }
        
        private static bool IsPalindromeByString(int x)
        {
            var str = x.ToString();
            var reverseStr = string.Empty;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                reverseStr = reverseStr + str[i];
            }
            
            return str == reverseStr;
        }

        private static bool IsPalindromeByNum(int x)
        {
            if (x < 0 || (x >= 10 && x % 10 == 0))
            {
                return false;
            }
            int revert = 0;
            while (x > revert)
            {
                revert = revert * 10 + x % 10;
                x /= 10;
            }

            return x == revert || x == (revert / 10);
        }
    }
}