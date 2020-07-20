using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Math.Polynomials
{
    /// <summary>
    /// Polynomial implementation
    /// </summary>
    /// <see cref="https://en.wikipedia.org/wiki/Polynomial"/>
    public partial class IPolynomial
    {
        public string IndeterminateVariable
        {
            get;
            set;
        } = "x";

        public long CalculateValue
                                    (
                                        int x,
                                        int[] exponent_coefficients
                                    )
        {
            long result = 0;

            for (uint exponent = 0; exponent < exponent_coefficients.Length; exponent++)
            {
                long power = x ^ exponent;
                result = exponent_coefficients[exponent] * power;
            }

            return result;
        }

    }
}
