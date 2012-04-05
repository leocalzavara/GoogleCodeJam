using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam2009.Qualification.A
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("SampleInput.txt");
            var outputFile = new StreamWriter("Output.txt");

            string[] line = inputFile.ReadLine().Split(' ');

            int wordLength = Int32.Parse(line[0]);
            int numberOfWords = Int32.Parse(line[1]);
            int numberOfCases = Int32.Parse(line[2]);

            for (int i = 0; i < numberOfCases; i++)
            {
                var caseMsg = String.Format("Case #{0}: ", i + 1);

                Console.Write(caseMsg);
                outputFile.Write(caseMsg);

                // TODO: logic

                Console.Write("\n");
                outputFile.Write("\n");
            }

            inputFile.Dispose();
            outputFile.Dispose();
        }
    }
}
