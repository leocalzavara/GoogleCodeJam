using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Africa2010.QualificationRound.B
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("B-large-practice.in");
            var outputFile = new StreamWriter("Output.txt");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int i = 0; i < numberOfCases; i++)
            {
                var caseMsg = String.Format("Case #{0}: ", i + 1);

                Console.Write(caseMsg);
                outputFile.Write(caseMsg);

                string[] words = inputFile.ReadLine().Split(' ').ToArray();

                IEnumerable<string> reversedWords = words.Reverse();

                foreach (string word in reversedWords)
                {
                    Console.Write(word + " ");
                    outputFile.Write(word + " ");
                }

                Console.Write("\n");
                outputFile.Write("\n");
            }

            inputFile.Dispose();
            outputFile.Dispose();
        }
    }
}
