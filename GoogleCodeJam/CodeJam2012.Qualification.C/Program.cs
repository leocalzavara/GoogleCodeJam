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
            var inputFile = new StreamReader("C-large.in");
            var outputFile = new StreamWriter("Output.txt");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int i = 0; i < numberOfCases; i++)
            {
                Console.Write("Case #{0}: ", i + 1);
                outputFile.Write("Case #{0}: ", i + 1);

                string[] inputLine = inputFile.ReadLine().Split(' ');

                lowerLimit = Int32.Parse(inputLine[0]);
                higherLimit = Int32.Parse(inputLine[1]);

                List<int[]> recycledPairs = new List<int[]>();
                //int numberOfValidRecycledPairs = 0;

                for (int j = lowerLimit; j <= higherLimit; j++)
                {
                    string currentNumber = j.ToString();
                    //Console.Write(currentNumber + " -> ");

                    for (int k = currentNumber.Length - 1; k > 0; k--)
                    {
                        int n = j; // j is the currentNumber...
                        int m = Int32.Parse(currentNumber.Substring(k) + currentNumber.Substring(0, k));
                        //Console.Write(number + " ");

                        int[] recycledPair = { n, m };

                        if (IsRecycledPair(recycledPair) && !recycledPairs.Contains(recycledPair))
                        {
                            recycledPairs.Add(recycledPair);
                            //numberOfValidRecycledPairs++;
                            //outputFile.WriteLine(recycledPair[0] + ", " + recycledPair[1]);
                        }
                    }

                    //Console.Write(Environment.NewLine);
                }

                Console.Write(recycledPairs.Count + Environment.NewLine);
                outputFile.Write(recycledPairs.Count + Environment.NewLine);
                outputFile.Flush();
            }

            inputFile.Dispose();
            outputFile.Dispose();
        }

        static bool IsRecycledPair(int[] recycledPair)
        {
            int n = recycledPair[0];
            int m = recycledPair[1];

            if (lowerLimit <= n && n < m && m <= higherLimit)
            {
                return true;
            }

            return false;
        }
    }
}
