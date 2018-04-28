using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Math.Polynomials
{
    /// <summary>
    /// Polynomial implementation
    /// </summary>
    /// <see cref="https://en.wikipedia.org/wiki/Polynomial"/>
    public partial class PolynomialBase
    {
        public string IndeterminateVariable
        {
            get;
            set;
        } = "x";

        public PolynomialBase()
        {
            return;
        }
    }
}
