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
            var inputFile = new StreamReader("C-large-practice.in");
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

                for (int j = lowerLimit; j <= higherLimit; j++)
                {
                    string currentNumber = j.ToString();
                    //Console.Write(currentNumber + " -> ");

                    for (int k = currentNumber.Length - 1; k > 0; k--)
                    {
                        int n = j; // j is the currentNumber...
                        int m = Int32.Parse(currentNumber.Substring(k) + currentNumber.Substring(0, k));
                        //Console.Write(number + " ");

                        if (IsRecycledPair(n, m))
                        {
                            numberOfValidRecycledPairs++;
                            //outputFile.WriteLine(n + ", " + m);
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
