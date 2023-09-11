using System;
namespace CanJumpII
{
    class Solution
    {
        public static void Main(string[] args)
        {
            string[] nums1;
            Console.WriteLine("输入整数数组以空格分隔：");
            nums1 = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(nums1, int.Parse);
            Solution s = new Solution();
            int times = s.CanJump(nums);
            Console.WriteLine("到达数组最后一个位置的最小跳跃次数：{0}", times);
        }

        private int CanJump(int[] nums)
        {
            //贪心算法
            int t = 0;
            int end = 0;
            int maxPosition = 0;
            /*在遍历数组时，我们不访问最后一个元素，这是因为在访问最后一个元素之前，
             * 我们的边界一定大于等于最后一个位置，否则就无法跳到最后一个位置了。
             * 如果访问最后一个元素，在边界正好为最后一个位置的情况下，
             * 我们会增加一次「不必要的跳跃次数」，因此我们不必访问最后一个元素。             
             */
            for (int i = 0; i < nums.Length - 1; i++)
            {
                maxPosition = Math.Max(maxPosition, i + nums[i]);
                /*维护当前能够到达的最大下标位置，记为边界。
                 * 我们从左到右遍历数组，到达边界时，更新边界并将跳跃次数增加 1。
                 */
                if (i == end)
                {
                    end = maxPosition;
                    t++;
                }
            }
            return t;
        }
    }
}