using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Math.Polynomials
{
    public partial class Polynomial<T>
        : System.Collections.Generic.IEqualityComparer<Polynomial<T>>
    {
        public static bool operator ==(Polynomial<T> i1, Polynomial<T> i2)
        {
            bool retval = false;

            return retval;
        }

        public static bool operator !=(Polynomial<T> i1, Polynomial<T> i2)
        {
            bool retval = false;

            return retval;
        }

        public static bool operator <(Polynomial<T> i1, Polynomial<T> i2)
        {
            bool retval = false;

            return retval;
        }

        public static bool operator >(Polynomial<T> i1, Polynomial<T> i2)
        {
            bool retval = false;

            return retval;
        }

        public static bool operator <=(Polynomial<T> i1, Polynomial<T> i2)
        {
            bool retval = false;

            return retval;
        }

        public static bool operator >=(Polynomial<T> i1, Polynomial<T> i2)
        {
            bool retval = false;

            return retval;
        }

        public bool Equals(Polynomial<T> x, Polynomial<T> y)
        {
            return x.Equals(y);
        }

        public bool Equals(Polynomial<T> i)
        {
            if (i == null)
            {
                return false;
            }

            return true;
        }

        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (ReferenceEquals(null, obj) || obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals(obj as Polynomial<T>);
        }

        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            unchecked
            {
                //IEnumerable<T> values = (IEnumerable<T>) this.Coefficients.Values.ToList();
                //values.Average();
                int hashCode = 13;
                //hashCode = (hashCode * 397) ^ values.Sum().GetHashCode();
                return hashCode;
            }
        }

        public int GetHashCode(Polynomial<T> obj)
        {
            return obj.GetHashCode();
        }
    }
}
