using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Math.Polynomials
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types"/>
    /// <see cref="https://docs.microsoft.com/en-us/dotnet/api/system.iformatprovider"/>
    /// <see cref=""/>
    /// <see cref=""/>
    /// <see cref=""/>
    /// <see cref=""/>
    public partial class PolynomFormatProvider
                :
                System.IFormatProvider, //System.Globalization.CultureInfo
                System.ICustomFormatter
    {
        private System.Globalization.CultureInfo culture_info = null;

        public System.Globalization.CultureInfo CurrentCulture
        {
            get
            {
                return culture_info;
            }
            set
            {
                culture_info = value;
            }
        }

        public PolynomFormatProvider()
        {
            FormatMethod = FormatDefault;

            return;
        }

        public Func<string, object, string> FormatMethod;

        public string FormatDefault(string format, object o)
        {
            if (string.IsNullOrEmpty(format))
            {
                return FormatMethod(format, o);
            }

            StringBuilder sb = new StringBuilder();

            switch (format.ToUpperInvariant())
            {
                case "CSHARP":
                case "CS":
                    TypeInfo ti = o.GetType().GetTypeInfo();
                    string type_fq = ti.FullName;
                    string type = ti.Name;
                    string variable_name = type.ToLowerInvariant();
                    if
                        (
                            typeof(System.Collections.IEnumerable).GetTypeInfo().IsAssignableFrom(ti)
                            ||
                            ti.ImplementedInterfaces.Contains(typeof(System.Collections.IEnumerable))
                        )
                    {
                    }
                    else
                    {
                        sb.AppendLine($"{type_fq} {variable_name}= new {type_fq} ();");
                    }
                    break;
                default:
                    HandleOtherFormats(format, o);
                    break;
            }

            return sb.ToString();
        }

        public string Format(string fmt, object polynom, IFormatProvider formatProvider)
        {

            return this.FormatDefault(fmt, polynom);
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                System.Diagnostics.Debug.WriteLine("HandleOtherFormats Object implements IFormattable");
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                System.Diagnostics.Debug.WriteLine("HandleOtherFormats Object does NOT implement IFormattable");
                return arg.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            else
            {
                return null;
            }
        }

        string ICustomFormatter.Format(string format, object arg, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }
}
