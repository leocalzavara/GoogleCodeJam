using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2015.Round1A.B
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("B-small-practice.in");

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int caseNumber = 1; caseNumber <= numberOfCases; ++caseNumber)
            {
                var b_n = inputFile.ReadLine().Split(' ').Select(x => Int32.Parse(x)).ToArray();
                var numberOfBarbers = b_n[0];
                var queuePosition = b_n[1];

                var m = inputFile.ReadLine().Split(' ').Select(i => Int32.Parse(i)).ToArray();

                int[] m_aux = new int[numberOfBarbers];
                m.CopyTo(m_aux, 0);

                int currentBarber = 0;
                
                var lcm = LCM(m);

                int totalPerRound = 0;

                for (int b = 0; b < numberOfBarbers; b++)
                {
                    totalPerRound += (lcm / m[b]);
                    m[b] = 0;
                }

                var remainingPeople = queuePosition % totalPerRound;
                
                if (remainingPeople == 0)
                    remainingPeople = totalPerRound;
                
                while (remainingPeople > 0)
                {
                    m[currentBarber] -= 1;

                    if (m[currentBarber] <= 0)
                    {
                        m[currentBarber] = m_aux[currentBarber];
                        remainingPeople--;
                    }

                    if (remainingPeople == 0) break;

                    if (currentBarber < numberOfBarbers - 1)
                        currentBarber++;
                    else
                        currentBarber = 0;
                }
                
                Console.WriteLine("Case #{0}: {1}", caseNumber, currentBarber + 1);
            }
        }

        static int LCM(int[] numbers)
        {
            return numbers.Aggregate(LCM);
        }

        static int LCM(int a, int b)
        {
            int num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }
    }
}
