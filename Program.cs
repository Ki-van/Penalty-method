using System;

namespace LB_4_MMK
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] min = PenaltyMethod.minimize(objective, fine, 100, 100, 100);
            for (int i = 0; i < min.Length; i++)
            {
                Console.WriteLine("x{0} = {1:F3}", i + 1, min[i]);
            }
            Console.WriteLine("F min = {0:F3}", objective(min));
        }

        static public double objective(double[] x)
        {
            return Math.Pow(x[0],2) + Math.Pow(x[1], 2) + Math.Pow(x[2], 2);
        }

        static public double fine(double[] x, double r, double wi)
        {
            /*return r * (
                (wi / (x[0] + x[1] + x[2] - 3))
                + (wi / (x[0] * x[1] * x[2] - 3))
                + (wi / x[0])
                + (wi / x[1])
                + (wi / x[2])
                );*/
            return r * (
                   Math.Pow(Math.Min(x[0] + x[1] + x[2] - 3, 0), 2)
                 + Math.Pow(Math.Min(x[0] * x[1] * x[2] - 3, 0), 2)
                 + Math.Pow(Math.Min(x[0], 0), 2)
                 + Math.Pow(Math.Min(x[1], 0), 2)
                 + Math.Pow(Math.Min(x[2], 0), 2)
                );
        }
    }
}
