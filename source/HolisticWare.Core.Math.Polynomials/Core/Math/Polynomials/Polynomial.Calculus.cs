using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Math.Polynomials
{
    public partial class Polynomial<T>
    {
        public Polynomial<double> Integrate(int initial_value)
        {
            int n = this.Coefficients.Count();
            double[] coefficients_integrated = new double[n+1];

            coefficients_integrated[0] = initial_value;
            for (int i = 0; i < n; i++)
            {
                coefficients_integrated[i + 1] = (double)(object)this.Coefficients[i] / (i + 1);
            }

            Polynomial<double> integration = new Polynomial<double>(coefficients_integrated);

            return integration;
        }

        public Polynomial<T> Derive()
        {
            Polynomial<T> derivation = new Polynomial<T>();

            return derivation;
        }
    }
}
