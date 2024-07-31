using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BienTheTimBalo
{
    class BienTheTimBaLo
    {
        class Knapsack01
        {
            static void Main()
            {
                int[] values = { 60, 100, 120 };
                int[] weights = { 10, 20, 30 };
                int capacity = 50;

                int n = values.Length;
                Console.WriteLine("Maximum value in Knapsack = " + Knapsack(capacity, weights, values, n));
                Console.ReadLine();
            }

            static int Knapsack(int capacity, int[] weights, int[] values, int n)
            {         
                int[,] dp = new int[n + 1, capacity + 1];
                for (int i = 0; i <= n; i++)
                {
                    for (int w = 0; w <= capacity; w++)
                    {
                        if (i == 0 || w == 0)
                            dp[i, w] = 0;
                        else if (weights[i - 1] <= w)
                            dp[i, w] = Math.Max(values[i - 1] + dp[i - 1, w - weights[i - 1]], dp[i - 1, w]);
                        else
                            dp[i, w] = dp[i - 1, w];
                    }
                }
                return dp[n, capacity];
            }
        }
    }
}
