using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Oyster.Math;

namespace CodeJam2008.Round1A.A
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Scalar_product_of_two_vectors_of_three_1s_should_be_3()
        {
            int[] x = { 1, 1, 1 };
            int[] y = { 1, 1, 1 };

            IntX scalarProduct = Program.ScalarProduct(x, y);

            Assert.AreEqual(3, scalarProduct);
        }

        [Test]
        public void Scalar_product_of_two_vectors_of_zeroes_should_be_0()
        {
            int[] x = { 0, 0, 0, 0, 0, 0 };
            int[] y = { 0, 0, 0, 0, 0, 0 };

            IntX scalarProduct = Program.ScalarProduct(x, y);

            Assert.AreEqual(0, scalarProduct);
        }
    }
}
