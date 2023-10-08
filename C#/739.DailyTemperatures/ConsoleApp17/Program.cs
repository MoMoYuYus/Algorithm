using System;
namespace Temperatures
{
    class Temperature
    {
        static void Main(string[] args)
        {
            string[] temperatures1;
            Console.WriteLine("输入每天的温度以空格分隔");
            temperatures1 = Console.ReadLine().Split(' ');
            int[] temperatures = Array.ConvertAll(temperatures1, int.Parse);
            Temperature t = new Temperature();
            int[] anwser = t.DailyTempertures(temperatures);
            foreach (int i in anwser)
            {
                Console.WriteLine(i);
            }
        }

        private int[] DailyTempertures(int[] T)
        {
            int size = T.Length;
            int[] answer = new int[size];
            Array.Fill(answer, 0);
            // 栈里存的元素为数组下标
            Stack<int> s = new Stack<int>();
            s.Push(0);
            for(int i = 0; i < size; i++)
            {
                while (s.Count != 0 && T[i] > T[s.Peek()])
                {
                    answer[s.Peek()] = i - s.Peek();
                    s.Pop();
                }
                s.Push(i);
            }

            //for (int i = 0; i < size; i++)
            //{
            //    if (T[i] < T[s.Peek()])  // 遍历元素T[i]小于栈顶元素s.Peek()
            //    {
            //        s.Push(i);
            //    }
            //    else if (T[i] == T[s.Peek()])  // 遍历元素T[i]等于栈顶元素s.Peek()
            //    {
            //        s.Push(i);
            //    }
            //    else    
            //    {
            //        // 循环弹出栈中小的值，这样才能保持栈头到栈底是递增顺序
            //        while (s.Count != 0 && T[i] > T[s.Peek()]) // 遍历元素T[i]大于栈顶元素s.Peek()
            //        {
            //            answer[s.Peek()] = i - s.Peek();
            //            s.Pop();
            //        }
            //        s.Push(i);
            //    }
            //}

            return answer;
        }
    }
}