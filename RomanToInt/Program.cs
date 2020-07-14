using System;
using System.Diagnostics;

namespace RomanToInt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanToInt("III")); // 3
            Console.WriteLine(RomanToInt("IV")); // 4
            Console.WriteLine(RomanToInt("IX")); // 9
            Console.WriteLine(RomanToInt("LVIII")); // 58
            Console.WriteLine(RomanToInt("MCMXCIV")); // 1994
        }
        
        private static int RomanToInt(string s)
        {
            int num = 0;
            int lastNum = 0;
            for (int i = s.Length -1 ; i >= 0; i--)
            {
                int operateNum = 0; 
                switch (s[i])
                {
                    case 'I':
                        operateNum = 1;
                        break;
                    case 'V':
                        operateNum = 5;
                        break;
                    case 'X':
                        operateNum = 10;
                        break;
                    case 'L':
                        operateNum = 50;
                        break;
                    case 'C':
                        operateNum = 100;
                        break;
                    case 'D':
                        operateNum = 500;
                        break;
                    case 'M':
                        operateNum = 1000;
                        break;
                }

                // 如果本次操作的数字小于上次操作的数字则相减
                if (operateNum < lastNum)
                {
                    num -= operateNum;
                }
                else
                {
                    num += operateNum;
                }

                lastNum = operateNum;
            }

            return num;
        }
    }
}