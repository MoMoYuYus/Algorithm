using System;
namespace Trap
{
    class Solution
    {
        public static void Main(string[] args)
        {
            string[] height1;
            Console.WriteLine("输入柱子高度数组以空格分隔：");
            height1 = Console.ReadLine().Split(' ');
            int[] height = Array.ConvertAll(height1, int.Parse);
            Solution s = new Solution();
            int sum = s.TrappingRain(height);
            Console.WriteLine("接到雨水总量为：{0}", sum);
        }

        private int TrappingRain(int[] height)
        {
            // 单调栈，代码优化
            int sum = 0;
            Stack<int> st = new Stack<int>();
            st.Push(0);
            for(int i = 1; i < height.Length; i++)
            {
                while(st.Count != 0 && height[i] > height[st.Peek()])
                {
                    int mid = st.Pop();
                    if(st.Count != 0)
                    {
                        int h = Math.Min(height[st.Peek()], height[i]) - height[mid];
                        int w = i - st.Peek() - 1;
                        sum += h * w;
                    }
                }
                st.Push(i);
            }

            //// 单调栈
            //int sum = 0;
            //Stack<int> st = new Stack<int>();
            //st.Push(0);
            //for (int i = 1; i < height.Length; i++)
            //{
            //    if (height[i] < height[st.Peek()])
            //    {
            //        st.Push(i);
            //    }
            //    else if (height[i] == height[st.Peek()])
            //    {
            //        st.Pop();       // 这种情况时，这一步可以省略，因为在计算雨量的时候高度差为0了，后续可以继续精简
            //        st.Push(i);
            //    }
            //    else
            //    {
            //        while (st.Count != 0 && height[i] > height[st.Peek()])
            //        {
            //            int mid = st.Pop();
            //            if (st.Count != 0)
            //            {
            //                int h = Math.Min(height[st.Peek()], height[i]) - height[mid];
            //                int w = i - st.Peek() - 1;  // 注意减1，只求中间宽度
            //                sum += h * w;
            //            }
            //        }
            //        st.Push(i);
            //    }
            //}

            //// 双指针优化版
            //// 使用两个数组分别记录当前柱子的左侧最高柱子和右侧最高柱子
            //int[] maxLeft = new int[height.Length];
            //int[] maxRight = new int[height.Length];
            //int size = height.Length;
            //// 计算左侧最高柱子，为前一个位置的左边最高高度或者本高度的最大值
            //maxLeft[0] = height[0];
            //for(int l = 1; l < height.Length; l++)
            //{
            //    maxLeft[l] = Math.Max(maxLeft[l - 1], height[l]);
            //}
            //// 计算右侧最高柱子，为后一个位置的右边最高高度或者本高度的最大值
            //maxRight[size - 1] = height[size - 1];
            //for(int r = size - 2; r >= 0; r--)
            //{
            //    maxRight[r] = Math.Max(maxRight[r + 1], height[r]);
            //}
            //// 计算积雨量
            //int sum = 0;
            //for(int i = 0; i < height.Length; i++)
            //{
            //    int count = Math.Min(maxLeft[i], maxRight[i]) - height[i];
            //    if (count > 0) sum += count;
            //}

            return sum;
        }
    }
}