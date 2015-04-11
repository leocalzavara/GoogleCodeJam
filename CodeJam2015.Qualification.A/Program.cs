using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2015.Qualification.A
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("A-small-attempt0.in");
            var output = new Output("Output.txt", true);

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int caseNumber = 1; caseNumber <= numberOfCases; ++caseNumber)
            {
                var inputLine = inputFile.ReadLine().Split(' ');
                var Smax = Int32.Parse(inputLine[0]);
                var S = inputLine[1].ToCharArray().Select(i => Int32.Parse(i.ToString())).ToArray();

                long numberOfStandUpPeople = 0;
                long numberOfFriendsToCall = 0;

                for (int i = 0; i <= Smax; ++i)
                {
                    if (S[i] == 0) continue;

                    if (numberOfStandUpPeople < i)
                    {
                        numberOfFriendsToCall += (i - numberOfStandUpPeople);
                        numberOfStandUpPeople += (i - numberOfStandUpPeople);
                    }
                    
                    numberOfStandUpPeople += S[i];
                }

                output.WriteLine("Case #{0}: {1}", caseNumber, numberOfFriendsToCall);
                output.Flush();
            }

            output.Dispose();
        }
    }
}
