using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Support.Tools;
using System.IO;
using Oyster.Math;

namespace CodeJam2008.Round1A.A
{
    public class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("A-large-practice.in");
            var output = new Output("Output.txt", true);
            
            int numberOfCases = Int32.Parse(inputFile.ReadLine());
            int vectorSize = 0;

            for (int i = 0; i < numberOfCases; i++)
            {
                output.Write(String.Format("Case #{0}: ", i + 1));

                vectorSize = Int32.Parse(inputFile.ReadLine());

                int[] x = inputFile.ReadLine().Split(' ')
                    .Select<string, int>(p => Int32.Parse(p)).ToArray<int>();

                int[] y = inputFile.ReadLine().Split(' ')
                    .Select<string, int>(p => Int32.Parse(p)).ToArray<int>();

                Array.Sort(x);

                Array.Sort(y);
                Array.Reverse(y);

                output.Write(ScalarProduct(x, y) + "\r\n");
                output.Flush();
            }
        }

        public static IntX ScalarProduct(int[] x, int[] y)
        {
            IntX scalarProduct = 0;

            for (int i = 0; i < x.Length; i++)
            {
                scalarProduct += x[i] * y[i];
            }

            return scalarProduct;
        }
    }
}
