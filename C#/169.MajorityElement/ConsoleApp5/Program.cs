using System;
using System.Collections;
using System.Collections.Generic;
namespace MajorityElement
{
    class MajorityElement
    {
        public static void Main(string[] args)
        {
            string[] nums1;
            int n;
            Console.WriteLine("输入数组以空格分隔");
            nums1 = Console.ReadLine().Split(' ');
            Console.WriteLine("输入数组的大小n：");
            n = Convert.ToInt32(Console.ReadLine());
            int[] nums = Array.ConvertAll(nums1, int.Parse);
            MajorityElement majorityElement = new MajorityElement();
            int k = majorityElement.Majority(nums);
            Console.WriteLine("输入数组中的多数元素为：{0}", k);
        }

        private int Majority(int[] nums)
        {
            //解法一：利用哈希表解决，涉及数值加减所以使用哈希表泛型字典Dictionary<int,int>解决
            /*
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach(int num in nums)
            {
                counts.TryAdd(num, 0);
                counts[num]++;
            }
            int majority = 0;
            int n = nums.Length;
            foreach(KeyValuePair<int, int> pair in counts)
            {
                if(pair.Value > n / 2)
                {
                    majority = pair.Key;
                    break;
                }
            }
            return majority;
            */

            /*解法二：将数组排序后得到多数元素。排序后的数组满足相等的元素一定出现在数组中的相邻位置，
             * 由于多数元素在数组中的出现次数大于[n/2]（向下取整），因此排序后的数组中存在至少[n/2]+1个连续的元素都是多数元素，
             * 下标[n/2]（向下取整）的元素一定是多数元素。
             * 理由如下：
             * 如果多数元素是数组中的最小元素，则排序后的数组从下标0到下标[n/2]（向下取整）的元素都是多数元素；
             * 如果多数元素是数组中的最大元素，则排序后的数组从下标[n/2]（向下取整）到下标n-1的元素都是多数元素；
             * 如果多数元素不是数组中的最小元素和最大元素，则排序后的数组的下标0和下标n−1的元素都不是多数元素，
             * 多数元素的开始下标一定小于[n/2]（向下取整）结束下标一定大于[n/2]（向下取整），下标[n/2]（向下取整）的元素一定是多数元素。
             * 将数组排序之后返回下标[n/2]（向下取整）的元素即可。
            */
            Array.Sort(nums);
            int n = nums.Length;
            return nums[n / 2];
        }
    }
}