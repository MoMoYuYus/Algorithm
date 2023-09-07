using System;
namespace RemoveDuplicates
{
    class RemoveDuplicates
    {
        public static void Main(string[] args)
        {
            string[] nums1;
            Console.WriteLine("请输入待删除重复元素的数组以空格分隔");
            nums1 = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(nums1, int.Parse);
            RemoveDuplicates removeDuplicates = new RemoveDuplicates();
            int k = removeDuplicates.Remove(nums);
            for(int i = 0; i < k; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }

        private int Remove(int[] nums)
        {
            int slowIndex = 0;
            for(int fastIndex = 1; fastIndex < nums.Length; fastIndex++)
            {
                if (nums[slowIndex] != nums[fastIndex])
                {
                    nums[++slowIndex] = nums[fastIndex];
                }
            }
            return slowIndex + 1;
        }
    }
}