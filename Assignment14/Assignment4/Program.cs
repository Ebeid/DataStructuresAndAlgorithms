using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Problem3());
            Console.WriteLine(Problem2());
            Console.ReadLine();
        }

        public static int Problem2()
        {
            string[] line1Parts = Console.ReadLine().Split(' ');
            int W = Convert.ToInt32(line1Parts[0]);
            int n = Convert.ToInt32(line1Parts[1]);

            int[] wt = new int[n];
            int[] val = new int[n];
            int i = 0;
            foreach (string linePart in Console.ReadLine().Split(' '))
            {
                wt[i] = int.Parse(linePart);
                val[i] = int.Parse(linePart);
                i++;
            }
            return knapSack(W, wt, val, n);
        }
        public static int Problem3()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }

        public static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        public static int knapSack(int W, int[] wt, int[] val, int n)
        {
            int i, w;
            int[,] K = new int[(n + 1), (W + 1)];

            // Build table K[][] in bottom up manner
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = max(val[i - 1] + K[(i - 1), (w - wt[i - 1])], K[(i - 1), w]);
                    else
                        K[i, w] = K[(i - 1), w];
                }
            }

            return K[n, W];
        }
    }
}

