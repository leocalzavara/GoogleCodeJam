using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Africa2010.QualificationRound.C
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("C-large-practice.in");
            var outputFile = new StreamWriter("Output.txt");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            IDictionary<string, char> dictionary = InitDictionary();

            for (int i = 0; i < numberOfCases; i++)
            {
                var caseMsg = String.Format("Case #{0}: ", i + 1);

                Console.Write(caseMsg);
                outputFile.Write(caseMsg);

                string word = inputFile.ReadLine();
                char lastPrintedChar = '\0';

                foreach (char c in word)
                {
                    KeyValuePair<string, char> item = dictionary.Where(d => d.Key.Contains(c)).Single();

                    if (item.Value == lastPrintedChar)
                    {
                        Console.Write(' ');
                        outputFile.Write(' ');
                    }

                    for (int j = 0; j < item.Key.IndexOf(c) + 1; j++)
                    {
                        Console.Write(item.Value);
                        outputFile.Write(item.Value);
                    }

                    lastPrintedChar = item.Value;
                }

                Console.Write("\n");
                outputFile.Write("\n");
            }

            inputFile.Dispose();
            outputFile.Dispose();
        }

        static IDictionary<string, char> InitDictionary()
        {
            Dictionary<string, char> dictionary = new Dictionary<string, char>();

            dictionary.Add("abc", '2');
            dictionary.Add("def", '3');
            dictionary.Add("ghi", '4');
            dictionary.Add("jkl", '5');
            dictionary.Add("mno", '6');
            dictionary.Add("pqrs", '7');
            dictionary.Add("tuv", '8');
            dictionary.Add("wxyz", '9');
            dictionary.Add(" ", '0');

            return dictionary;
        }
    }
}
