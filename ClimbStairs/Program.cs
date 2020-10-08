using System;

namespace ClimbStairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        
        /// <summary>
        /// 超时
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int ClimbStairsByRec(int n)
        {
            if (n == 1) return 1;
            if (n == 2) return 2;
            return ClimbStairsByRec(n - 1) + ClimbStairsByRec(n - 2);
        }
        
        /**  
         * 执行耗时:40 ms,击败了96.00% 的C#用户
		   内存消耗:14.2 MB,击败了78.03% 的C#用户
         */
        static int ClimbStairsByDP(int n) {
            if(n==1) return 1;
            if(n==2) return 2;

            var result = 0;
            var prev = 1;
            var cur = 2;

            for(int i=2; i < n; i++){
                result = prev + cur;
                prev = cur;
                cur = result;
            }

            return result;
        }
    }
}