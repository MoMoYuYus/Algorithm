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
            int n = prices.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[2]; 
            }
            
            dp[0][0] = -prices[0];
            dp[0][1] = 0;
            /* 
             * 在121. 买卖股票的最佳时机中，因为股票全程只能买卖一次，所以如果买入股票，那么第i天持有股票即dp[i][0]一定就是 -prices[i]。
            *而本题，因为一只股票可以买卖多次，所以当第i天买入股票的时候，所持有的现金可能有之前买卖过的利润。
            *那么第i天持有股票即dp[i][0]，如果是第i天买入股票，所得现金就是昨天不持有股票的所得现金 减去 今天的股票价格 即：dp[i - 1][1] - prices[i]。
            *再来看看如果第i天不持有股票即dp[i][1]的情况， 依然可以由两个状态推出来
            *第i - 1天就不持有股票，那么就保持现状，所得现金就是昨天不持有股票的所得现金 即：dp[i - 1][1]
            *第i天卖出股票，所得现金就是按照今天股票价格卖出后所得现金即：prices[i] + dp[i - 1][0]          
             */
            for (int i = 1; i < prices.Length; i++)
            {
                dp[i][0] = Math.Max(dp[i - 1][0], dp[i - 1][1] -prices[i]);
                dp[i][1] = Math.Max(dp[i - 1][1], dp[i - 1][0] + prices[i]);
            }
            int l = prices.Length - 1;
            return dp[l][1];
        }
    }
}