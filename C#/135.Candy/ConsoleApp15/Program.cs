using System;
namespace Candys
{
    class HandOutCandy
    {
        public static void Main(string[] args)
        {
            string[] ratings1;
            Console.WriteLine("输入孩子评分数组以空格分隔：");
            ratings1 = Console.ReadLine().Split(' ');
            int[] ratings = Array.ConvertAll(ratings1, int.Parse);
            var handOutCandy = new HandOutCandy();
            int candyNum = handOutCandy.Candy(ratings);
            Console.WriteLine("需要准备的最少糖果数为：{0}", candyNum);
        }

        private int Candy(int[] ratings)
        {
            int[] candyVec = new int[ratings.Length];
            candyVec[0] = 1;
            for(int i = 1; i < candyVec.Length; i++)
            {
                candyVec[i] = (ratings[i] > ratings[i - 1]) ? candyVec[i - 1] + 1 : 1 ;
            }
            for(int i = candyVec.Length - 2; i >= 0; i--)
            {
                if (ratings[i] > ratings[i + 1])
                {
                    candyVec[i] = Math.Max(candyVec[i], candyVec[i + 1] + 1);
                }
            }
            int total = candyVec.Sum();
            return total;
        }
    }
}