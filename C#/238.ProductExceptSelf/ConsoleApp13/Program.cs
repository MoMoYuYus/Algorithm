using System;

namespace ProductExceptSelf
{
    class Solution
    {
        public static void Main(string[] args)
        {
            string[] nums1;
            Console.WriteLine("输入数组以空格分隔");
            nums1 = Console.ReadLine().Split(' ');
            int[] nums = Array.ConvertAll(nums1, int.Parse);
            Solution p = new Solution();
            int[] answer = p.Product(nums);
            foreach(int i in answer)
            {
                Console.Write(i + " ");
            }
        }

        private int[] Product(int[] nums)
        {
            //int[] answer = new int[nums.Length];
            //int[] L = new int[nums.Length];
            //int[] R = new int[nums.Length];
            //L[0] = 1;
            //for(int i = 1; i< nums.Length; i++)
            //{
            //    L[i] = nums[i - 1] * L[i - 1];
            //}
            //R[nums.Length - 1] = 1;
            //for(int i = nums.Length - 2; i >= 0; i--)
            //{
            //    R[i] = nums[i + 1] * R[i + 1];
            //}
            //for(int i = 0; i < nums.Length; i++)
            //{
            //    answer[i] = L[i] * R[i]; 
            //}

            // 节约空间，简化版
            int[] answer = new int[nums.Length];
            answer[0] = 1;
            // 存储左边乘积的结果
            for(int i = 1; i < nums.Length; i++)
            {
                answer[i] = nums[i - 1] * answer[i - 1];
            }
            int R = 1;
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                //乘积结果等于左边乘积乘右边乘积R
                answer[i] = answer[i] * R;
                // 右边乘积R累乘
                R *= nums[i];
            }
            return answer;
        }
    }
}