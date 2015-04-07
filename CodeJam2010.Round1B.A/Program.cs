using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support.Tools;
using System.IO;

namespace CodeJam2010.Round1B.A
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new StreamReader("A-large-practice.in");
            var output = new Output("Output.txt", true);

            int numberOfCases = Int32.Parse(inputFile.ReadLine());

            for (int caseNumber = 1; caseNumber <= numberOfCases; ++caseNumber)
            {
                var N_M = inputFile.ReadLine().Split(' ');
                var numberOfExistingFolders = Int32.Parse(N_M[0]);
                var numberOfDesiredFolders = Int32.Parse(N_M[1]);

                var rootFolder = new TreeNode("");

                for (int i = 0; i < numberOfExistingFolders; ++i)
                {
                    var currentNode = rootFolder;
                    var pathParts = inputFile.ReadLine().Split('/');

                    var treeDepth = 0;

                    for (var j = 0; j < pathParts.Length; ++j)
                    {
                        if (treeDepth == j)
                        {
                            continue;
                        }

                        var node = currentNode.Children.SingleOrDefault(n => n.Value == pathParts[j]);

                        if (node == null)
                        {
                            node = new TreeNode(pathParts[j]);
                            currentNode.Children.Add(node);
                        }

                        currentNode = node;
                        treeDepth++;
                    }
                }

                long numberOfFoldersCreated = 0;

                for (int i = 0; i < numberOfDesiredFolders; ++i)
                {
                    var currentNode = rootFolder;
                    var pathParts = inputFile.ReadLine().Split('/');

                    var treeDepth = 0;

                    for (var j = 0; j < pathParts.Length; ++j)
                    {
                        if (treeDepth == j)
                        {
                            continue;
                        }

                        var node = currentNode.Children.SingleOrDefault(n => n.Value == pathParts[j]);

                        if (node == null)
                        {
                            node = new TreeNode(pathParts[j]);
                            currentNode.Children.Add(node);
                            numberOfFoldersCreated++;
                        }

                        currentNode = node;
                        treeDepth++;
                    }
                }

                output.WriteLine("Case #{0}: {1}", caseNumber, numberOfFoldersCreated);
                output.Flush();
            }

            output.Dispose();
        }
    }

    class TreeNode
    {
        public String Value;
        public List<TreeNode> Children;

        public TreeNode(string value)
        {
            this.Value = value;
            this.Children = new List<TreeNode>();
        }
    }
}
