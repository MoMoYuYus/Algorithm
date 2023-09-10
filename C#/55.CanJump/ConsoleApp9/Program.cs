using System;
namespace CanJump
{
    class Solution
    {
        public static void Main(string[] args)
        {
            string[] nums1;
            Console.WriteLine("输入非负整数数组以空格分隔：");
            nums1 = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(nums1, int.Parse);
            Solution s = new Solution();
            Boolean b = s.CanJump(nums);
            Console.WriteLine("能否到达最后一个下标：{0}" , b);
        }

        private bool CanJump(int[] nums)
        {
            /*贪心算法：
             *跳几步无所谓，关键在于可跳的覆盖范围！
             *这个问题就转化为跳跃覆盖范围究竟可不可以覆盖到终点！
             *贪心算法局部最优解：每次取最大跳跃步数（取最大覆盖范围），
             *整体最优解：最后得到整体最大覆盖范围，看是否能到终点。
            */
            int cover = 0;
            if (nums.Length == 0) return true; // 只有一个元素一定可以到达
            //i 小于等于覆盖范围时继续循环
            for(int i = 0; i <= cover; i++)
            {
                cover = Math.Max(i + nums[i], cover);
                if(cover >= nums.Length - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}