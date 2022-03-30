using System;
using System.Text;

namespace ConsoleApp2
{
    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static int cnt = 0;

        public static void hanoi(int h, int start, int assist, int goal)
        {
            if(h == 1)
            {
                sb.Append($"{start}{goal}\n");
                cnt++;
            }
            else
            {
                hanoi(h - 1, start, goal, assist);

                sb.Append($"{start}{goal}\n");
                cnt++;

                hanoi(h - 1, assist, start, goal);
            }
        }

        public static void Main(string[] args)
        {
            string temp = Console.ReadLine();
            int height = int.Parse(temp);

            hanoi(height, 1, 2, 3);
            sb.Insert(0, $"{cnt}\n");
            Console.WriteLine(sb);
        }
    }
}
