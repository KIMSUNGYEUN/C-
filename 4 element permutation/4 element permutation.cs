using System;

namespace ConsoleApp5
{
    class Program
    {
        //// 4요소 permutation
        
        const int LL = 6;
        static string org_str = " ABCDEFGHIJ";
        static char[] org = new char[11];
        static int cnt = 0;
        static int p;
        static void permutation()
        {
            Console.Write("[{0:d3}] ", ++cnt);

            for (int a = 1; a <= LL; a++)
            {
                Console.Write("{0} ", org[a]);
            }
            Console.WriteLine();

            p = 0;
            for (int k = 1; k < LL; k++)
            {
                if (org[k] < org[k + 1])
                    p = k;
            }
            
            if (p == 0) return;
            
            int q;
            char temp;
            for (q = LL; q > 0; q--)
            {
                if (org[q] > org[p])
                    break;
            }

            temp = org[p];
            org[p] = org[q];
            org[q] = temp;

            for (int a = p + 1; a <= (p + 1 + LL) / 2; a++)
            {
                q = p + 1 + LL - a;
                temp = org[a];
                org[a] = org[q];
                org[q] = temp;
            }
        }

        static void Main(string[] args)
        {
            p = 1;
            for (int a = 1; a <= LL; a++)
            {
                org[a] = org_str[a];
            }

            while (p != 0) 
            {
                permutation();
            }
        }
    }
}
