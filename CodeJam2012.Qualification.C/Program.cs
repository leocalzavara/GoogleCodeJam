using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam2012.Qualification.C
{
    class Program
    {
        static int lowerLimit, higherLimit;

        static void Main(string[] args)
        {
            var initialTime = DateTime.Now;

            var inputFile = new StreamReader("C-small-practice.in");
            var outputFile = new StreamWriter("Output.txt");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int i = 0; i < numberOfCases; i++)
            {
                Console.Write("Case #{0}: ", i + 1);
                outputFile.Write("Case #{0}: ", i + 1);

                string[] inputLine = inputFile.ReadLine().Split(' ');

                lowerLimit = Int32.Parse(inputLine[0]);
                higherLimit = Int32.Parse(inputLine[1]);

                int numberOfValidRecycledPairs = 0;

                for (int n = lowerLimit; n <= higherLimit; n++)
                {
                    //Console.Write(n + " -> ");

                    int numberOfDigits = n.ToString().Length;
                    int m = n;

                    for (int j = 0; j < numberOfDigits - 1; j++)
                    {
                        // shift
                        m = (int)((m / 10) + ((m % 10) * Math.Pow(10, numberOfDigits - 1)));

                        //Console.Write(m + " ");

                        if (IsRecycledPair(n, m))
                        {
                            numberOfValidRecycledPairs++;
                        }
                    }

                    //Console.Write(Environment.NewLine);
                }

                Console.Write(numberOfValidRecycledPairs + Environment.NewLine);
                outputFile.Write(numberOfValidRecycledPairs + Environment.NewLine);
                outputFile.Flush();
            }

            inputFile.Dispose();
            outputFile.Dispose();

            Console.WriteLine("Execution time: {0}", (DateTime.Now - initialTime));
        }

        static bool IsRecycledPair(int n, int m)
        {
            if (lowerLimit <= n && n < m && m <= higherLimit)
            {
                return true;
            }

            return false;
        }
    }
}
