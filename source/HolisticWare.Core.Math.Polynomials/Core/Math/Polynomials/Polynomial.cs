using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Math.Polynomials
{
    /// <summary>
    /// Polynomial implementation
    /// </summary>
    /// <see cref="https://en.wikipedia.org/wiki/Polynomial"/>
    public partial class Polynomial<T>
        where T :
                struct,
                IComparable,
                IComparable<T>,
                #if NETSTANDARD1_3
                IConvertible,       // System.Runtime.dll
                #endif
                IEquatable<T>,
                IFormattable
    {
        /// <summary>
        /// Coefficients of the Polynomial
        /// </summary>
        /// <value>The coefficients.</value>
        public Dictionary<int, T> Coefficients
        {
            get;
            set;
        }

        /// <summary>
        /// Indeterminate or Variable (Argument if Polynomial is considered as function)
        /// 
        /// Used mostly for output.
        /// </summary>
        /// <value>Indeterminate / Variable / Argument</value>
        public string IndeterminateVariable
        {
            get;
            set;
        } = "x";

        public Polynomial()
        {
            this.Coefficients = new Dictionary<int, T>()
            {
                {0, default(T)}
            };

            return;
        }

        public Polynomial(T n)
            : this()
        {
            this.Coefficients[0] = n;

            return;
        }

        public Polynomial(Dictionary<int, T> coefficients)
            : this()
        {
            this.Coefficients = new Dictionary<int, T>(coefficients);

            return;
        }

        public Polynomial(Polynomial<T> polynimial)
            :this()
        {
            this.Coefficients = new Dictionary<int, T>(polynimial.Coefficients);

            return;
        }

        public Polynomial(IEnumerable<T> p)
        {
            this.Coefficients = new Dictionary<int, T>();

            for (int i = 0; i < p.Count(); i++)
            {
                this.Coefficients.Add(i, p.ElementAt(i));
            }

            return;
        }
    }
}
