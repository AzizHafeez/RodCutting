using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RodCutting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] profit = new int[] { 1, 5, 8, 9, 10, 17, 17, 20, 24, 30 };
            int result = CutRod(profit, profit.Length);
            //int result = MemoizedCutRod(profit, profit.Length);
            //int result = BottomUpCutRod(profit, profit.Length);
            Console.WriteLine("Optimal Solution is:{0}", result);
            Console.ReadLine();
        }

        static int CutRod(int[] profit, int n)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            if (n == 0) // first element is 0
                return 0;

            int q = int.MinValue;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Calculating for {0},{1}", i, n);
                q = Math.Max(q, profit[i - 1] + CutRod(profit, n - i));
            }
            time.Stop();
            //Console.WriteLine("N={0}, Q={1}", n, q);
            Console.WriteLine("Running time of cutRode in milliseconds: {0}", time.ElapsedMilliseconds);
            Console.WriteLine();

            return q;
        }

        static int MemoizedCutRod(int[] profit, int n)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            int[] r = new int[n];
            for (int i = 0; i < n; i++)
                r[i] = int.MinValue;
            time.Stop();
            Console.WriteLine("Running time of MemoizedCutRod in milliseconds: {0}", time.ElapsedMilliseconds);
            return MemoizedCutRodAux(profit, r, n);
        }

        static int MemoizedCutRodAux(int[] profit, int[] r, int n)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            if (n > 0 && r[n - 1] >= 0)
                return r[n - 1];

            int q = int.MinValue;

            if (n == 0)
            {
                q = 0;
                return 0;
            }
            else
            {
                for (int i = 1; i <= n; i++)
                    q = Math.Max(q, profit[i - 1] + MemoizedCutRodAux(profit, r, n - i));
            }

            r[n - 1] = q;
            time.Stop();
            Console.WriteLine("Running time of Memoized CutRodAux in milliseconds: {0}", time.ElapsedMilliseconds);
            return q;
        }

        static int BottomUpCutRod(int[] profit, int n)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            int[] r = new int[n + 1];
            r[0] = 0;

            for (int j = 1; j <= n; j++)
            {
                int q = int.MinValue;
                for (int i = 1; i <= j; i++)
                {
                    q = Math.Max(q, profit[i - 1] + r[j - i]);
                }
                r[j] = q;
            }
            time.Stop();
            Console.WriteLine("Running timme of BottomUpCutRod: {0}", time.ElapsedMilliseconds);
            return r[n];
        }
    }
}
