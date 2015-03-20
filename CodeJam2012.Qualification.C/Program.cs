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

            var inputFile = new StreamReader("C-large-practice.in");
            var outputFile = new StreamWriter("Output.txt");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int i = 0; i < numberOfCases; i++)
            {
                string[] inputLine = inputFile.ReadLine().Split(' ');

                lowerLimit = Int32.Parse(inputLine[0]);
                higherLimit = Int32.Parse(inputLine[1]);

                int numberOfValidRecycledPairs = 0;

                for (int n = lowerLimit; n <= higherLimit; n++)
                {
                    int numberOfDigits = n.ToString().Length;
                    int m = n;

                    for (int j = 0; j < numberOfDigits - 1; j++)
                    {
                        // shift
                        m = (int)((m / 10) + ((m % 10) * Math.Pow(10, numberOfDigits - 1)));

                        // Info: https://code.google.com/codejam/contest/1460488/dashboard#s=a&a=2
                        if (m == n) break;

                        if (n < m && m <= higherLimit)
                        {
                            numberOfValidRecycledPairs++;
                        }
                    }
                }

                Console.WriteLine("Case #{0}: {1}", i + 1, numberOfValidRecycledPairs);
                outputFile.WriteLine("Case #{0}: {1}", i + 1, numberOfValidRecycledPairs);
                outputFile.Flush();
            }

            inputFile.Dispose();
            outputFile.Dispose();

            Console.WriteLine("Execution time: {0}", (DateTime.Now - initialTime));
        }
    }
}
