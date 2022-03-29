namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] datas = new char[] { 'a', 'b', 'c', 'd' };

            Perm(datas, 0);

            Console.ReadKey();
        }

        private static void Perm(char[] a, int k)
        {
            if (k == a.Length - 1)//순열을 출력
            {
                for (int i = 0; i < a.Length; i++)
                {
                    Console.Write("{0} ", a[i]);
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = k; i < a.Length; i++)
                {
                    //a[k]와 a[i]를 교환
                    char temp = a[k];
                    a[k] = a[i];
                    a[i] = temp;

                    Perm(a, k + 1); //a[k+1],…,a[n-1]에 대한 모든 순열
                    //원래 상태로 되돌리기 위해 a[k]와 a[i]를 다시 교환
                    temp = a[k];
                    a[k] = a[i];
                    a[i] = temp;
                }
            }
        }
    }
}
