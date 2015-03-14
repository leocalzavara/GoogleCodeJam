using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeJam2012.Qualification.A
{
    class Program
    {
        static void Main(string[] args)
        {
            string googlerese = "ejp mysljylc kd kxveddknmc re jsicpdrysi rbcpc ypc rtcsra dkh wyfrepkym veddknkmkrkcd de kr kd eoya kw aej tysr re ujdr lkgc jv";
            string translated = "our language is impossible to understand there are twenty six factorial possibilities so it is okay if you want to just give up";

            var dictionary = new Dictionary<string, string>();

            for (int i = 0; i < googlerese.Length; i++)
            {
                var letter = googlerese[i];
                if(!dictionary.ContainsKey(letter.ToString()))
                {
                    dictionary.Add(letter.ToString(), translated[i].ToString());
                }
            }
            dictionary.Add("z", "q");
            dictionary.Add("q", "z");

            Console.Write("dictionary.count is {0}", dictionary.Count);

            Console.WriteLine("");

            var listKeys = dictionary.Keys.ToList();
            listKeys.Sort();
            foreach (var l in listKeys)
            {
                Console.Write(l);
            }
            Console.WriteLine("");

            var listValues = dictionary.Values.ToList();
            listValues.Sort();
            foreach (var l in listValues)
            {
                Console.Write(l);
            }
            Console.WriteLine("");








            var inputFile = new StreamReader("A-small-attempt0.in");
            var outputFile = new StreamWriter("Output.txt");

            var numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int i = 0; i < numberOfCases; i++)
            {
                var caseMsg = String.Format("Case #{0}: ", i + 1);

                Console.Write(caseMsg);
                outputFile.Write(caseMsg);

                var line = inputFile.ReadLine();
                foreach (var ch in line)
                {
                    Console.Write(dictionary[ch.ToString()]);
                    outputFile.Write(dictionary[ch.ToString()]);
                }

                Console.Write(Environment.NewLine);
                outputFile.Write(Environment.NewLine);

                outputFile.Flush();
            }

            inputFile.Dispose();
            outputFile.Dispose();
        }
    }
}
