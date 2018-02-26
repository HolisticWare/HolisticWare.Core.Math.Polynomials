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
using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using Core.Math.Polynomials;

namespace UnitTests.Core.Math.Statistics.Descriptive.Sequential.Sync
{
    public partial class Tests02Compression
    {
        Stopwatch sw = null;
        
        [Test()]
        public void ConstructorDefault()
        {
            //====================================================================================================
            // Arrange
            Polynomial<int> p01 = new Polynomial<int>();

            sw = Stopwatch.StartNew();
            //----------------------------------------------------------------------------------------------------
            // Act
            Dictionary<int, int> coefficients_compressed = p01.Compress();
            sw.Stop();
            Console.WriteLine($"Polynomial<int>()");
            Console.WriteLine($"          size               = {p01.Coefficients.Count()}");
            Console.WriteLine($"          p01.Coefficients   = {p01.Coefficients}");
            Console.WriteLine($"          elapsed[ticks]     = {sw.ElapsedTicks}");
            Console.WriteLine($"          elapsed[ms]        = {sw.Elapsed.TotalMilliseconds}");
            sw.Reset();

            //----------------------------------------------------------------------------------------------------
            // Assert
            Assert.AreEqual(1, p01.Coefficients.Count());
            CollectionAssert.AreEquivalent
                               (
                                    p01.Coefficients,
                                    new int[1]
                                    {
                                        0,
                                    }
                               );
            //====================================================================================================

            return;
        }

        [Test()]
        public void ConstructorConstant()
        {
            //====================================================================================================
            // Arrange
            Polynomial<int> p01 = new Polynomial<int>(3);

            sw = Stopwatch.StartNew();
            //----------------------------------------------------------------------------------------------------
            // Act
            sw.Stop();
            Console.WriteLine($"Polynomial<int>(T)");
            Console.WriteLine($"          size               = {p01.Coefficients.Count()}");
            Console.WriteLine($"          elapsed[ticks]     = {sw.ElapsedTicks}");
            Console.WriteLine($"          elapsed[ms]        = {sw.Elapsed.TotalMilliseconds}");
            sw.Reset();

            //----------------------------------------------------------------------------------------------------
            // Assert
            Assert.AreEqual(1, p01.Coefficients.Count());
            CollectionAssert.AreEquivalent
                               (
                                    p01.Coefficients,
                                    new int[1]
                                    {
                                        3,
                                    }
                               );
            //====================================================================================================

            return;
        }

        [Test()]
        public void ConstructorCopyPolynomial()
        {
            //====================================================================================================
            // Arrange
            Polynomial<double> p00 = new Polynomial<double>();
            p00.Coefficients = new double[] { 1.0, 0.0, 1.0, 3.1, 0.0, 5.2, -2.2, 2.4, 1.9 };
            Polynomial<double> p01 = new Polynomial<double>(p00);

            sw = Stopwatch.StartNew();
            //----------------------------------------------------------------------------------------------------
            // Act
            sw.Stop();
            Console.WriteLine($"Polynomial<double>(new Dictionary<int, double>)");
            Console.WriteLine($"          size               = {p01.Coefficients.Count()}");
            Console.WriteLine($"          elapsed[ticks]     = {sw.ElapsedTicks}");
            Console.WriteLine($"          elapsed[ms]        = {sw.Elapsed.TotalMilliseconds}");
            sw.Reset();

            //----------------------------------------------------------------------------------------------------
            // Assert
            Assert.AreEqual(9, p01.Coefficients.Count());
            //====================================================================================================

            return;
        }
    }
}
