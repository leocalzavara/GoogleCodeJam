using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeJam2012.Qualification.B
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("B-large.in");
            var outputFile = new StreamWriter("Output.txt");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int i = 0; i < numberOfCases; i++)
            {
                Console.Write("Case #{0}: ", i + 1);
                outputFile.Write("Case #{0}: ", i + 1);

                int[] inputLine = inputFile.ReadLine().Split(' ')
                    .Select<string, int>(p => Int32.Parse(p)).ToArray<int>();

                int numberOfGooglers = inputLine[0];
                int numberOfSurprises = inputLine[1];
                int minimumScore = inputLine[2];

                int sumOfScoresToAchieveTarget = (minimumScore * 3) - 2;
                int sumOfScoresToAchieveTargetWithSurprise = (minimumScore * 3) - 4;
                
                if (minimumScore > 0 && sumOfScoresToAchieveTargetWithSurprise <= 0)
                {
                    sumOfScoresToAchieveTargetWithSurprise = 1;
                }
                
                Console.WriteLine("sumOfScoresToAchieveTarget is {0}", sumOfScoresToAchieveTarget);
                Console.WriteLine("sumOfScoresToAchieveTargetWithSurprise is {0}", sumOfScoresToAchieveTargetWithSurprise);

                int count = 0;

                // Googlers start on index 3 of inputLine array.
                for (int j = 3; j < numberOfGooglers + 3; j++)
                {
                    if (inputLine[j] >= sumOfScoresToAchieveTarget)
                    {
                        Console.WriteLine("googler[{0}] did it!", j-3);
                        count++;
                    }
                    else if (inputLine[j] >= sumOfScoresToAchieveTargetWithSurprise
                        && inputLine[j] < sumOfScoresToAchieveTarget
                        && numberOfSurprises > 0/* && inputLine[j] >= minimumScore*/)
                    {
                        Console.WriteLine("googler[{0}] did it with surprise!", j-3);
                        count++;
                        numberOfSurprises--;
                    }
                }

                Console.Write(count + Environment.NewLine);
                outputFile.Write(count + Environment.NewLine);
                outputFile.Flush();
            }

            inputFile.Dispose();
            outputFile.Dispose();
        }
    }
}
