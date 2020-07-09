using System;

namespace TwnSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = TwoSum(new int[] {2, 7, 11, 15}, 9);
            Console.WriteLine("[{0}]", string.Join(", ", result));
        }

        private static int[] TwoSum(int[] nums, int target) {
            int[] twoSum = new int[2];
            for (int i= 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        twoSum[0] = i;
                        twoSum[1] = j;
                    }
                }
            }
            return twoSum;
        }
    }
}