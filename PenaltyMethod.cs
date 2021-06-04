using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LB_3_Coordinate_Descent;

namespace LB_4_MMK
{
    class PenaltyMethod
    {
        static double e = 0.1;
        static double r = 1;
        static double wi = 1;
        static double dr = 0.5;

        public delegate double dfunction(double[] x);
        static dfunction Objective;
        public delegate double dFine(double[] x, double r, double wi);
        static dFine Fine;

        public static double[] minimize(dfunction objective, dFine fine, params double[] x)
        {

            int pointNum = 0;
            Objective = objective;
            Fine = fine;
            double F,Fext;
            do
            {
                
                Optimize.minimize(penaltyFunction, x);
                r += dr;
                F = Objective(x);
                Fext = penaltyFunction(x);
                Console.WriteLine(String.Format("M{0} = ({1:F2}; {2:F2}; {3:F2}), F = {4:F2}, Штраф = {5:F2}, F^ = {6:F2}",
                    pointNum, x[0], x[1], x[2], F, Fine(x, r, wi), Fext));
                pointNum++;

            } while (Math.Abs(Fext - F) > e);
            
            return x;
        }
        public static double penaltyFunction(double[] x)
        {
            return Objective(x) + Fine(x, r, wi);
        }

    }
}
