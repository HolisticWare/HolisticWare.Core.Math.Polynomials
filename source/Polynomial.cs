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
        public Dictionary<int, T> CoefficientsCompressed
        {
            get
            {
                return this.Compress();
            }


        }

        public T[] Coefficients
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
            this.Coefficients = new T[1]
            {
                default(T)              // 0 = Polynomial() { 0 };
                                        // 0 * x ^ 0;
            };

            return;
        }

        public Polynomial(T n)
            : this()
        {
            this.Coefficients[0] = n;   // constant => Polynomial() { n };
                                        // n * x ^ 0;

            return;
        }

        public Polynomial(T[] coefficients)
            : this()
        {
            coefficients.CopyTo(this.Coefficients, 0);

            return;
        }

        public Polynomial(Dictionary<int, T> coefficients)
            : this()
        {
            this.Coefficients = this.Decompress(coefficients); 

            return;
        }

        public Polynomial(Polynomial<T> polynimial)
            :this()
        {
            this.Coefficients = new T[polynimial.Coefficients.Count()];
            polynimial.Coefficients.CopyTo(this.Coefficients, 0);

            return;
        }

        public Polynomial(IEnumerable<T> p)
        {
            int n = p.Count();
            this.Coefficients = new T[n];

            for (int i = 0; i < n; i++)
            {
                this.Coefficients[i] = p.ElementAt(i);
            }

            return;
        }

        public Dictionary<int, T> Compress()
        {
            Dictionary<int, T> coefficients_compressed = new Dictionary<int, T>();

            for (int i = 0; i < this.Coefficients.Count(); i++)
            {
                if (this.Coefficients[i].CompareTo(default(T)) == 0) // == 0
                {
                    continue;
                }
                else
                {
                    coefficients_compressed.Add(i, this.Coefficients[i]);
                }
            }

            return coefficients_compressed;
        }

        public T[] Decompress(Dictionary<int, T> coefficeints_compressed)
        {
            int n_compressed = coefficeints_compressed.Count();
            int n = coefficeints_compressed.Last().Key;

            T[] coefficeints_uncompressed = new T[n + 1];
            foreach (KeyValuePair<int, T> kvp in coefficeints_compressed)
            {
                coefficeints_uncompressed[kvp.Key] = kvp.Value;
            }

            return coefficeints_uncompressed;
        }
    }
}
