using Support.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam2010.Round1A.A
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("SampleInput.txt");
            var output = new Output("Output.txt", true);

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int caseNumber = 1; caseNumber <= numberOfCases; ++caseNumber)
            {
                var input_N_K = inputFile.ReadLine().Split(' ');

                var N = Byte.Parse(input_N_K[0]);
                var K = Byte.Parse(input_N_K[1]);

                char[][] matrix = new char[N][];

                for (int n1 = 0; n1 < N; ++n1)
                {
                    var line = inputFile.ReadLine().ToCharArray();

                    GravitySort(line);

                    matrix[n1] = line;
                }

                var rotatedMatrix = RotateMatrix(matrix);

                PrintMatrix(rotatedMatrix);

                // TODO: check for K pieces in a row

                output.WriteLine("Case #{0}: {1}", caseNumber, "");
                output.Flush();
            }

            output.Dispose();
        }
        
        // Rotate matrix 90 degrees clockwise.
        static char[][] RotateMatrix(char[][] matrix)
        {
            var rotatedMatrix = new char[matrix.Length][];

            for (int n1 = 0; n1 < matrix.Length; ++n1)
            {
                rotatedMatrix[n1] = new char[matrix[n1].Length];

                for (int n2 = 0; n2 < matrix[n1].Length; ++n2)
                {
                    rotatedMatrix[n1][n2] = matrix[matrix[n1].Length -1 - n2][n1];
                }
            }

            return rotatedMatrix;
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int n1 = 0; n1 < matrix.Length; ++n1)
            {
                for(int n2 = 0; n2 < matrix[n1].Length; ++n2)
                {
                    Console.Write(matrix[n1][n2].ToString());
                }

                Console.WriteLine("");
            }
        }

        // This is like a Bubble Sort, just with custom comparer.
        static void GravitySort(char[] arr)
        {
            char temp = '\0';

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    //if (arr[sort] > arr[sort + 1])
                    if (arr[sort] != '.' && arr[sort + 1] == '.')
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }
        }
    }
}
