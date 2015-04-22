using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2015.Round1A.A
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("A-large-practice.in");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int caseNumber = 1; caseNumber <= numberOfCases; ++caseNumber)
            {
                var n = Int32.Parse(inputFile.ReadLine());
                var m = inputFile.ReadLine().Split(' ').Select(i => Int32.Parse(i)).ToArray();

                int method1 = 0, method2 = 0;
                int method2_mushroomsPerRound = 0;

                for (int i = 0; i < n - 1; ++i)
                {
                    if (m[i] > m[i + 1])
                    {
                        method1 += (m[i] - m[i + 1]);

                        if ((m[i] - m[i + 1]) > method2_mushroomsPerRound)
                            method2_mushroomsPerRound = (m[i] - m[i + 1]);
                    }
                }

                for (int i = 0; i < n - 1; ++i)
                {
                    if (m[i] > method2_mushroomsPerRound)
                        method2 += method2_mushroomsPerRound;
                    else
                        method2 += m[i];
                }

                Console.WriteLine("Case #{0}: {1} {2}", caseNumber, method1, method2);
            }
        }
    }
}
