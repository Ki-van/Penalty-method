using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB_3_Coordinate_Descent
{
    class Optimize
    {
        static double e = 0.01;

        public delegate double dfunction(double[] vars);
        static dfunction func;
        public static double[] minimize(dfunction function, params double[] vars)
        {
            func = function;
            double A;
            double B = function(vars);
            int i = -1;
            do
            {
                A = B;
                i = (i + 1) % vars.Length;

                dichotomy(vars, i);

                B = func(vars);
            } while (Math.Abs(A - B) > e);

            return vars;
        }


        static double dichotomy(double[] vars, int i)
        { 
            double[] aVars = new double[vars.Length];
            Array.Copy(vars, aVars, vars.Length);

            double[] bVars = new double[vars.Length];
            Array.Copy(vars, bVars, vars.Length);

            double a = vars[i] - 100;
            double b = vars[i] + 100;
            
            while(Math.Abs(b - a) > e)
            {
                aVars[i] = vars[i] - e;
                bVars[i] = vars[i] + e;
                if(func(aVars) < func(bVars))
                {
                    b = vars[i];
                    
                } else
                {
                    a = vars[i];
                }
                vars[i] = (a + b) / 2;
            }

            return vars[i];
        }
    }
}
