using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Math.Polynomials
{
    public partial class Polynomial<T>
    {
        /*
        Package System.Text.Json 4.7.2 is not compatible with netstandard1.0
        Package System.Text.Json 4.7.2 supports:
          - net461 (.NETFramework,Version=v4.6.1)
          - netcoreapp3.0 (.NETCoreApp,Version=v3.0)
          - netstandard2.0 (.NETStandard,Version=v2.0)
        */
        public string ToString
                                (
                                    string format
                                )
        {
            Polynomial<T> o = this;

            if (string.IsNullOrEmpty(format))
            {
                return o.ToString();
            }

            return o.ToString
                    (
                        format,
                        // System.Globalization.CultureInfo.CurrentCulture
                        new PolynomFormatProvider()
                    );
        }

        public string ToString
                                (
                                    string format,
                                    PolynomFormatProvider provider
                                )
        {
            Polynomial<T> o = this;
            string formatted = null;

            if (String.IsNullOrEmpty(format))
            {
                formatted = o.ToString();

                return formatted;
            }

            IFormatProvider ifp = null;

            if (provider == null)
            {
                ifp = provider.CurrentCulture;
            }
            else
            {
                formatted = provider.FormatMethod
                                            (
                                                format,
                                                o as Polynomial<T>
                                            );
            }

            return formatted;
        }

        public string ToStringCSharp
                                (
                                )
        {
            Type t = this.GetType();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Polynom<{t}> polynom = new Polynom<{t}>");
            sb.AppendLine("{");
            foreach (var kvp in this.CoefficientsCompressed)
            {
                sb.AppendLine($"    {kvp.Key}, {kvp.Value}");
            }
            sb.AppendLine("};");

            return sb.ToString();
        }

        public string ToStringJSON
                                (
                                )
        {
            string json = "Polynom<T>.ToStringJSON";

            // https://docs.microsoft.com/en-us/dotnet/standard/frameworks
            #if NETSTANDARD1_0
            json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            #elif NETSTANDARD2_0
            json = JsonSerializer.Serialize(this);
            #endif

            return json;
        }

        public string ToStringXML
                                (
                                )
        {
            string xml = "Polynom<T>.ToStringJSON";

            // https://docs.microsoft.com/en-us/dotnet/standard/frameworks
            System.Xml.Serialization.XmlSerializer s;

            s = new System.Xml.Serialization.XmlSerializer(this.GetType());

            using(System.IO.StringWriter tw = new System.IO.StringWriter())
            {
                s.Serialize(tw, this);
                xml = tw.ToString();
            }

            return xml;
        }
    }
}
