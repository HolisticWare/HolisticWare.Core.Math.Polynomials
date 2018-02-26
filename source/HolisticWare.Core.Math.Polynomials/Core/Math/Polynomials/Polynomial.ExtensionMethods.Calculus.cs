using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Math.Polynomials
{
    public static partial class PolynomialExtensionMethods
    {
        public static Polynomial<double> Integrate(this Polynomial<int> polynomial, int initial_value)
        {
            int n = polynomial.Coefficients.Count();
            double[] coefficients_integrated = new double[n+1];

            coefficients_integrated[0] = initial_value;
            for (int i = 0; i < n; i++)
            {
                coefficients_integrated[i + 1] = (double) polynomial.Coefficients.ElementAt<int>(i) / (i + 1);
            }

            Polynomial<double> integration = new Polynomial<double>(coefficients_integrated);

            return integration;
        }

        public static Polynomial<int> Derive(this Polynomial<int> polynomial)
        {
            int n = polynomial.Coefficients.Count();
            int[] coefficients_derived = new int[n - 1];

            for (int i = 1; i < n - 1; i++)
            {
                coefficients_derived[i - 1] = polynomial.Coefficients.ElementAt<int>(i) * i;
            }

            Polynomial<int> derivation = new Polynomial<int>();

            return derivation;
        }
    }
}
