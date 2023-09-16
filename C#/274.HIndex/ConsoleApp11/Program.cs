using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace HIndex
{
    class Solution
    {
        public static void Main(string[] args)
        {
            string[] citations1;
            Console.WriteLine("输入论文引用次数数组以空格分隔：");
            citations1 = Console.ReadLine().Split();
            int[] citations = Array.ConvertAll(citations1, int.Parse);
            Solution s = new Solution();
            int h = s.Hindex(citations);
            foreach (int i in citations)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("高引用次数h指数的值为：{0}", h);
        }

        private int Hindex(int[] citations)
        {
            //int temp;
            //int j;
            //int h = 0, m = 0;
            ////先排序，再判断
            //for(int i = 1; i < citations.Length; i++)
            //{
            //    temp = citations[i];
            //    j = i - 1;
            //    while (j >= 0 &&temp < citations[j])
            //    {
            //        citations[j + 1] = citations[j];
            //        j--;
            //    }
            //    citations[j + 1] = temp;
            //}
            //for(int i = 0; i < citations.Length; i++)
            //{
            //    if(citations.Length - i <= citations[i])
            //    {
            //        m = citations.Length - i;
            //        if (m > h) h = m;
            //    }
            //}
            //return h;

            //二分搜索：>> 1右移1位等同于/2 但是运算更快
            int left = 0, right = citations.Length;
            int mid = 0, cnt = 0;
            while(left < right)
            {
                mid = (left + right + 1) >> 1;
                cnt = 0;
                for(int i = 0; i < citations.Length; i++)
                {
                    if (citations[i] >= mid)
                    {
                        cnt++;
                    }
                }
                if(cnt >= mid)
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }
    }
}