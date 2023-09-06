using System;
namespace RemoveElement
{
    class RemoveElement
    {
        public static void Main(string[] args)
        {
            string[] nums1;
            int val;
            Console.WriteLine("输入数组以空格分隔");
            nums1 = Console.ReadLine().Split(' ');
            Console.WriteLine("输入要移除的元素值");
            val = Convert.ToInt32(Console.ReadLine());
            int[] nums11 = new int[nums1.Length];
            int num , p = 0;
            Boolean flag;
            foreach(string s in nums1)
            {
                flag = int.TryParse(s, out num);
                if (flag)
                {
                    nums11[p++] = num;
                }
                else
                {
                    Console.WriteLine("数组中有非数值元素");
                }
            }
            RemoveElement removeElement = new RemoveElement();
            int len = removeElement.Remove(nums11, val);
            for(int i = 0; i < len; i++)
            {
                Console.WriteLine(nums11[i]);
            }
        }

        public int Remove(int[] nums, int val)
        {
            //1、暴力解法：时间复杂度：O(n^2) 空间复杂度：O(1)
            /*
            int size = nums.Length;
            for(int i = 0; i < size; i++)
            {
                if (nums[i] == val)
                {
                    for(int j = i + 1; j < nums.Length; j++)
                    {
                        nums[j - 1] = nums[j];
                    }
                    i--;
                    size--;
                }
            }
            return size;
            */

            //2、双指针法（快慢指针法）：通过一个快指针和慢指针在一个for循环下完成两个for循环的工作。
            // 时间复杂度：O(n)
            // 空间复杂度：O(1)
            //快指针：寻找新数组元素，新数组即是不含删除元素的数组。
            //慢指针：指向更新 新数组下标的位置
            int slowIndex = 0;
            for(int fastIndex = 0; fastIndex < nums.Length; fastIndex++)
            {
                if(val != nums[fastIndex])
                {
                    nums[slowIndex++] = nums[fastIndex];
                }
            }
            return slowIndex;
        }
    }
}