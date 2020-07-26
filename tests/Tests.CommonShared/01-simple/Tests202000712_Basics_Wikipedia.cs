// /*
//    Copyright (c) 2017-12
//
//    moljac
//    Test.cs
//
//    Permission is hereby granted, free of charge, to any person
//    obtaining a copy of this software and associated documentation
//    files (the "Software"), to deal in the Software without
//    restriction, including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the
//    Software is furnished to do so, subject to the following
//    conditions:
//
//    The above copyright notice and this permission notice shall be
//    included in all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//    EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//    OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//    NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//    WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//    FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//    OTHER DEALINGS IN THE SOFTWARE.
// */

#if XUNIT
using Xunit;
// NUnit aliases
using Test = Xunit.FactAttribute;
using OneTimeSetUp = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
// XUnit aliases
using TestClass = HolisticWare.Core.Testing.UnitTests.UnitTestsCompatibilityAliasAttribute;
#elif NUNIT
using NUnit.Framework;
// MSTest aliases
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestProperty = NUnit.Framework.PropertyAttribute;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
// XUnit aliases
using Fact = NUnit.Framework.TestAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
// NUnit aliases
using Test = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
using OneTimeSetUp = Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute;
// XUnit aliases
using Fact = Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute;
#endif

#if BENCHMARKDOTNET
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Attributes.Jobs;
#else
using Benchmark = HolisticWare.Core.Testing.BenchmarkTests.Benchmark;using ShortRunJob = HolisticWare.Core.Testing.BenchmarkTests.ShortRunJob;
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Collections.ObjectModel;

using Core.Math.Polynomials;

namespace UnitTests.Core.Math.Polynomials {
    /// <summary>
    /// Test01
    /// </summary>
    /// <see href="https://en.wikipedia.org/wiki/Polynomial"/>
    [TestClass]
    public partial class Tests202000712_Basics_Wikipedia
    {
        [Test]
        public void Polynomial_of_int_Constructor_01_default()
        {
            Polynomial<int> polynomial = new Polynomial<int>();

            #if NUNIT
            Assert.AreEqual(polynomial.Coefficients.Length, 0);
            #elif XUNIT
            Assert.Equals(polynomial.Coefficients.Lenght,   0);
            #elif MSTEST
            Assert.AreEqual(polynomial.Coefficients.Length, 0);
            #endif

            return;
        }

        [Test]
        public void Polynomial_of_int_Constructor_02_default()
        {
            Polynomial<int> polynomial = new Polynomial<int>(5);

            return;
        }

        [Test]
        public void Polynomial_of_int_Constructor_02_int_Array_coefficients()
        {
            int[] coefficeints = new[] { 1, 3, 4 };

            Polynomial<int> polynomial = new Polynomial<int>(coefficeints);

            return;
        }

        [Test]
        public void Polynomial_of_int_Constructor_02_Dictionary_coefficients()
        {
            Dictionary<uint, int> coefficeints =
                                                new Dictionary<uint, int>
                                                {
                                                    { 1, 2 },
                                                    { 3, 3 },
                                                    { 6, 4 },
                                                };

            Polynomial<int> polynomial = new Polynomial<int>(coefficeints);

            return;
        }

        [Test]
        public void Polynomial_of_int_Constructor_02_IEnumerable_of_Tuples_coefficients()
        {
            int x = 0;
            int y = 4 * x ^ 2 + (-3) * x ^ 1 + 2 * x ^ 0;

            IEnumerable<(uint exponent, int coefficient)> coefficeints =
                                                                    new (uint, int)[]
                                                                    {
                                                                        ( 0,  2 ),
                                                                        ( 1, -3 ),
                                                                        ( 2,  4 ),
                                                                    };

            Polynomial<int> polynomial = new Polynomial<int>(coefficeints);

            x = 0;

            #if NUNIT
            Assert.AreEqual(y, polynomial.CalculateValue(x, polynomial.Coefficients));
            #elif MSTEST
            #elif XUNIT
            #endif

            return;
        }


        [Test]
        public void Polynomial_of_int_CalculateValue()
        {

            IEnumerable<(uint exponent, int coefficient)> coefficeints =
                                                                    new (uint, int)[]
                                                                    {
                                                                        ( 1, 2 ),
                                                                        ( 1, 3 ),
                                                                        ( 2, 4 ),
                                                                    };

            Polynomial<int> polynomial = new Polynomial<int>(coefficeints);

            return;
        }
    }
}