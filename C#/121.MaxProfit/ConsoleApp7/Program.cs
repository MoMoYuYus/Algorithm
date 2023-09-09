using System;
using System.Runtime.Intrinsics.Arm;

namespace MaxProfit
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] prices1;
            Console.WriteLine("输入股票价格数组以空格分隔");
            prices1 = Console.ReadLine().Split(' ');
            int[] prices = Array.ConvertAll(prices1, int.Parse);
            Program p = new Program();
            int profitMax = p.maxProfit(prices);
            Console.WriteLine("获取最大利润为：{0}", profitMax);
        }

        private int maxProfit(int[] prices)
        {
            //动态规划通用方法：
            /*
            int n = prices.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[2]; 
            }
            
            dp[0][0] = -prices[0];
            dp[0][1] = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                dp[i][0] = Math.Max(dp[i - 1][0], -prices[i]);
                dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] + prices[i]);
            }
            int l = prices.Length - 1;
            return dp[l][1];
            */

            //优化内存和时间后的动态规划解法
            int[] dp = new int[2];
            dp[0] = -prices[0];
            dp[1] = 0;
            //在121.买卖股票的最佳时机中，因为股票全程只能买卖一次，所以如果买入股票，那么第i天持有股票即dp[i][0]一定就是 - prices[i]。
            for (int i = 1; i < prices.Length; i++)
            {
                dp[0] = Math.Max(dp[0], -prices[i]);
                dp[1] = Math.Max(dp[1], dp[0] + prices[i]);
            }
            return dp[1];
        }
    }
}