using System;
namespace RemoveDuplicates
{
    class RemoveDuplicates
    {
        public static void Main(string[] args)
        {
            string[] nums1;
            Console.WriteLine("输入待删除元素数组以空格分隔");
            nums1 = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(nums1, int.Parse);
            RemoveDuplicates removeDuplicates = new RemoveDuplicates();
            int k = removeDuplicates.Remove(nums);
            for(int i = 0; i < k; i++)
            {
                Console.WriteLine(nums[i]);
            }
        }
        // 快慢指针加可留存次数标识符（t<几，就是留存几次，通用于留存一个数组中可保留最多重复元素个数为任意）
        private int Remove(int[] nums)
        {
            int slowIndex = 0;
            int t = 1;
            for(int fastIndex = 1; fastIndex < nums.Length; fastIndex++)
            {
                if (nums[slowIndex] != nums[fastIndex])
                {
                    nums[++slowIndex] = nums[fastIndex];
                    t = 1;
                }
                else if (nums[slowIndex] == nums[fastIndex] && t < 2)
                {
                    nums[++slowIndex] = nums[fastIndex];
                    t++;
                }
            }
            return slowIndex + 1;
        }
    }
}