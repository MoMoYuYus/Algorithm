using System;
namespace CanCompleteCircuit
{
    class Solution
    {
        public static void Main(string[] args)
        {
            string[] gas1, cost2;
            Console.WriteLine("输入加油站存油数组以空格分隔：");
            gas1 = Console.ReadLine().Split(' ');
            Console.WriteLine("输入开往下一个加油站消耗汽油数组以空格分隔：");
            cost2 = Console.ReadLine().Split(' ');
            int[] gas = Array.ConvertAll(gas1, int.Parse);
            int[] cost = Array.ConvertAll(cost2, int.Parse);
            Solution s = new Solution();
            int num = s.CompleteCircuit(gas, cost);
            Console.WriteLine("出发加油站编号为：{0}", num);
        }

        private int CompleteCircuit(int[] gas, int[] cost)
        {
            int curSum = 0;         // 实时剩余油量，当小于零时重置出发点
            int totalSum = 0;       // 总剩余油量，如果小于零那一定走不完一圈
            int start = 0;
            for(int i = 0; i < gas.Length; i++)
            {
                curSum += gas[i] - cost[i];
                totalSum += gas[i] - cost[i];
                // 实时剩余油量小于零时重置出发点，重置剩余油量
                if (curSum < 0)
                {
                    start = i + 1;
                    curSum = 0;
                }               
            }
            // 总剩余油量小于零那一定走不完一圈
            if (totalSum < 0)
            {
                return -1;
            }
            return start;
        }
    }
}