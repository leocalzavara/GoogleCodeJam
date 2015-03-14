using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Africa2010.QualificationRound.A
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("A-large-practice.in");
            var outputFile = new StreamWriter("Output.txt");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int i = 0; i < numberOfCases; i++)
            {
                var caseMsg = String.Format("Case #{0}: ", i + 1);

                Console.Write(caseMsg);
                outputFile.Write(caseMsg);

                int availableCash = 0;
                int numberOfItems = 0;
                int[] pricesOfItems;

                availableCash = Int32.Parse(inputFile.ReadLine());
                numberOfItems = Int32.Parse(inputFile.ReadLine());

                pricesOfItems = inputFile.ReadLine().Split(' ')
                    .Select<string, int>(p => Int32.Parse(p)).ToArray<int>();

                int sum = 0;
                int auxIdx = 1;

                for(int j=0; j < numberOfItems; j++)
                {
                    for (auxIdx = j + 1; auxIdx < numberOfItems; auxIdx++)
                    {
                        sum = pricesOfItems[j] + pricesOfItems[auxIdx];

                        if (sum == availableCash)
                        {
                            var result = String.Format("{0} {1}\n", j + 1, auxIdx + 1);

                            Console.Write(result);
                            outputFile.WriteLine(result);
                        }
                    }
                }
            }

            inputFile.Dispose();
            outputFile.Dispose();
        }
    }
}
