using System;

namespace LongestCommonPrefix
{
    class Program
    {
        static void Main(string[] args)
        {
            // "fl"
            Console.WriteLine(LongestCommonPrefix(new string[] {"flower","flow","flight"}));
            
            // ""
            Console.WriteLine(LongestCommonPrefix(new string[] {"dog","racecar","car"}));
            
            // ""
            Console.WriteLine(LongestCommonPrefix(new string[] {""}));
            
            // "c"
            Console.WriteLine(LongestCommonPrefix(new string[] {"c", "c"}));
        }
        
        private static string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            
            // 假设第一个字符串是完整共同的字符串
            var longestCommonPrefix = strs[0];
            
            // 如果第一个字符串不为空才比较
            if (longestCommonPrefix != string.Empty)
            {
                // 找出下个字符串
                for (int i = 1; i < strs.Length; i++)
                {
                    var nextStr = strs[i];
                
                    // 比对假定的字符串与其他的字符串中相同字元
                    for (int j = 0; j < longestCommonPrefix.Length; j++)
                    {
                        // 如果比较目标字符串长度短 或 找不到一样 跳出
                        if (nextStr.Length -1 < j || longestCommonPrefix[j] != nextStr[j])
                        {
                            // 移除多余的假设
                            longestCommonPrefix = longestCommonPrefix.Remove(j);
                            break;
                        }
                    }

                    // 如果已经没有共同字符串则跳出回圈
                    if (longestCommonPrefix == string.Empty)
                    {
                        break;
                    }
                }
            }

            return longestCommonPrefix;
        }
    }
}