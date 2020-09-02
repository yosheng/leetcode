using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace IsValid
{
    class Program
    {
        static void Main(string[] args)
        {
            // True
            Console.WriteLine(IsValid("()"));
            // True
            Console.WriteLine(IsValid("()[]{}"));
            // False
            Console.WriteLine(IsValid("(]"));
            // False
            Console.WriteLine(IsValid("([)]"));
            // True
            Console.WriteLine(IsValid("{[]}"));
            // False
            Console.WriteLine(IsValid("(("));
            // False
            Console.WriteLine(IsValid("))"));
        }

        /*
         * 	执行耗时:92 ms,击败了44.99% 的C#用户
			内存消耗:22 MB,击败了46.63% 的C#用户
         */
        private static bool IsValid(string s)
        {
            if (s.Length <= 1 || s.Length % 2 != 0)
            {
                return false;
            }

            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                // 左括号先入栈
                if (s[i] == '(' || s[i] == '[' || s[i] == '{')
                {
                    stack.Push(s[i]);
                }
                // 右括号判断是否跟左括号成对
                else
                {
                    // 假设第一个为右括号
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var leftSign = stack.Pop();
                    if (s[i] == ')' && leftSign != '(')
                    {
                        return false;
                    }

                    if (s[i] == ']' && leftSign != '[')
                    {
                        return false;
                    }

                    if (s[i] == '}' && leftSign != '{')
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}