using System;
using System.IO;
using Support.Tools;

namespace CodeJam2010.Round1C.A
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("A-large-practice.in");
            var output = new Output("Output.txt", true);

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int caseNumber = 1; caseNumber <= numberOfCases; ++caseNumber)
            {
                int numberOfIntersections = 0;
                int numberOfWires = Int32.Parse(inputFile.ReadLine());

                int[] A = new int[numberOfWires];
                int[] B = new int[numberOfWires];

                for (int wireNumber = 0; wireNumber < numberOfWires; ++wireNumber)
                {
                    string[] inputLine = inputFile.ReadLine().Split(' ');

                    A[wireNumber] = Int32.Parse(inputLine[0]);
                    B[wireNumber] = Int32.Parse(inputLine[1]);
                }

                for (int i = 0; i < numberOfWires; ++i)
                {
                    for (int j = 0; j < numberOfWires; ++j)
                    {
                        if (i == j)
                            continue;

                        if (A[j] > A[i] && B[j] < B[i])
                            numberOfIntersections++;
                    }
                }

                output.WriteLine("Case #{0}: {1}", caseNumber, numberOfIntersections);
                output.Flush();
            }

            output.Dispose();
        }
    }
}
