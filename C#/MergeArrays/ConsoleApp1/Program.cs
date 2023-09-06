using System;
namespace MergeArrays
{
    class MergeArrays
    {
        public static void Main(string[] args)
        {
            string[] nums11, nums22;
            int m, n;
            Console.WriteLine("输入数组1元素以空格分隔");
            nums11 = Console.ReadLine().Split(' ');
            Console.WriteLine("输入数组1元素个数m：");
            m = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("输入数组2元素以空格分隔");
            nums22 = Console.ReadLine().Split(' ');
            Console.WriteLine("输入数组2元素个数n：");
            n = Convert.ToInt32(Console.ReadLine());
            int[] nums1 = new int[m+n];
            int[] nums2 = new int[n];
            int num1, num2;
            int p = 0, q = 0;
            Boolean flag;
            foreach(string s in nums11)
            {
                flag = int.TryParse(s, out num1);
                if(flag == true)
                {
                    nums1[p++] = num1;
                }
                else
                {
                    Console.WriteLine("输入数组1中有元素不是数值");
                }
            }
            foreach(string s in nums22)
            {
                flag = int.TryParse(s, out num2);
                if(flag == true)
                {
                    nums2[q++] = num2;
                }
                else
                {
                    Console.WriteLine("输入数组2中有元素不是数值");
                }
            }
            MergeArrays mergeArrays = new MergeArrays();
            mergeArrays.Merge(nums1, m, nums2, n);
            for(int i = 0; i < nums1.Length; i++)
            {
                if(i == 0)
                {
                    Console.Write("[" + nums1[i] + ",");
                }
                else if(i > 0 && i < nums1.Length - 1)
                {
                    Console.Write(nums1[i] + ",");
                }
                else if(i == nums1.Length - 1)
                {
                    Console.Write(nums1[i] + "]");
                } 
            }
        }
        // 俩个非递增数组合并,两个有序数组合并到一个数组里均可变换使用，算法复杂度O(m+n)，空间复杂度O(1)。
        private void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int index = m + n - 1;
            int i = m - 1;
            int j = n - 1;
            while(i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    nums1[index--] = nums2[j--];
                }
                else
                {
                    nums1[index--] = nums1[i--];
                }
            }
            while(i >= 0)
            {
                nums1[index--] = nums1[i--];
            }
            while(j >= 0)
            {
                nums1[index--] = nums2[j--];
            }
        }
    }
}