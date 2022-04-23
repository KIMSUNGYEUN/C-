using System;
using System.Text;

namespace ConsoleApp3
{
    class Program
    {

        static StringBuilder sb = new StringBuilder();
        static int cnt = 0;

        public static void Hanoi(int h, int PS, int PM, int PD)
        {
            if (h == 1)
            {
                sb.Append($"{h} : {PS} ==> {PD}\n");
                cnt++;
            }
            else
            {
                Hanoi(h - 1, PS, PD, PM);

                sb.Append($"{h} : {PS} ==> {PD}\n");
                cnt++;

                Hanoi(h - 1, PM, PS, PD);
            }
        }

        public static void Main(string[] args)
        {
            string temp = Console.ReadLine();
            int height = int.Parse(temp);
            int Pole1 = 1;
            int Pole2 = 2;
            int Pole3 = 3;

            Hanoi(height, Pole1, Pole2, Pole3);
            sb.Insert(0, $"{cnt}\n");
            Console.WriteLine("총 옮긴 횟수 : {0}",sb);
        }
    }
}
