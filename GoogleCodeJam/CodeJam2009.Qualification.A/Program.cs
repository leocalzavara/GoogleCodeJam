using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeJam2009.Qualification.A
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("A-large-practice.in");
            var outputFile = new StreamWriter("Output.txt");

            string[] line = inputFile.ReadLine().Split(' ');

            int wordLength = Int32.Parse(line[0]);
            int numberOfWords = Int32.Parse(line[1]);
            int numberOfCases = Int32.Parse(line[2]);

            List<string> language = new List<string>();

            for (int j = 0; j < numberOfWords; j++)
            {
                language.Add(inputFile.ReadLine());
            }

            for (int i = 0; i < numberOfCases; i++)
            {
                var caseMsg = String.Format("Case #{0}: ", i + 1);

                Console.Write(caseMsg);
                outputFile.Write(caseMsg);

                int matches = 0;

                string originalRegexString = inputFile.ReadLine();
                string fixedRegexString = originalRegexString.Replace('(', '[').Replace(')', ']');

                Regex regex = new Regex(fixedRegexString);

                //Console.Write(regex.ToString());
                
                foreach (string word in language)
                {
                    if (regex.IsMatch(word))
                        matches++;
                }
                
                Console.Write(matches);
                outputFile.Write(matches);

                Console.Write("\n");
                outputFile.Write("\n");
            }

            inputFile.Dispose();
            outputFile.Dispose();
        }
    }
}
