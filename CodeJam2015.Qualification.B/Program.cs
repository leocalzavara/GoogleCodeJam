using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2015.Qualification.B
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("B-small-attempt1.in");
            //var inputFile = new StreamReader("SampleInput.txt");
            var output = new Output("Output.txt", true);

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int caseNumber = 1; caseNumber <= numberOfCases; ++caseNumber)
            {
                var numberOfNonEmptyPlates = Int32.Parse(inputFile.ReadLine());
                var nonEmptyPlates = inputFile.ReadLine().Split(' ').Select(i => Int32.Parse(i)).ToArray();

                Array.Sort(nonEmptyPlates);

                var specialMinute = 0;
                var totalMinutes = nonEmptyPlates[nonEmptyPlates.Length - 1];

                while (nonEmptyPlates[nonEmptyPlates.Length - 1] > 3)
                {
                    ++specialMinute;
                    var currentMax = nonEmptyPlates[nonEmptyPlates.Length - 1];
                    var halfMax = currentMax / 2;

                    for (int x = 1; x <= halfMax; ++x)
                    {
                        nonEmptyPlates[nonEmptyPlates.Length - 1] = halfMax;

                        var tempList = nonEmptyPlates.ToList();
                        tempList.Add(currentMax - halfMax);

                        nonEmptyPlates = tempList.ToArray();
                        Array.Sort(nonEmptyPlates);

                        if (nonEmptyPlates[nonEmptyPlates.Length - 1] + specialMinute < totalMinutes)
                            totalMinutes = nonEmptyPlates[nonEmptyPlates.Length - 1] + specialMinute;
                    }
                }

                output.WriteLine("Case #{0}: {1}", caseNumber, totalMinutes);
                output.Flush();
            }

            output.Dispose();
        }
    }
}
