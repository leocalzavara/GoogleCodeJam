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
                    var path = inputFile.ReadLine();

                    mkdir(currentNode, path);
                }

                long numberOfFoldersCreated = 0;

                for (int i = 0; i < numberOfDesiredFolders; ++i)
                {
                    var currentNode = rootFolder;
                    var path = inputFile.ReadLine();

                    numberOfFoldersCreated += mkdir(currentNode, path);
                }

                output.WriteLine("Case #{0}: {1}", caseNumber, numberOfFoldersCreated);
                output.Flush();
            }

            output.Dispose();
        }

        static int mkdir(TreeNode currentNode, string path)
        {
            var treeDepth = 0;
            int numberOfFoldersCreated = 0;

            var pathParts = path.Split('/');

            for (var j = 0; j < pathParts.Length; ++j)
            {
                if (treeDepth == j) continue;

                var node = currentNode.FindChild(pathParts[j]);

                if (node == null)
                {
                    node = currentNode.AddChild(pathParts[j]);
                    numberOfFoldersCreated++;
                }

                currentNode = node;
                treeDepth++;
            }

            return numberOfFoldersCreated;
        }
    }

    class TreeNode
    {
        public String Value;
        private List<TreeNode> Children;

        public TreeNode(string value)
        {
            this.Value = value;
            this.Children = new List<TreeNode>();
        }

        public TreeNode FindChild(string value)
        {
            return this.Children.Find(node => node.Value == value);
        }

        public TreeNode AddChild(string value)
        {
            var childNode = new TreeNode(value);
            this.Children.Add(childNode);

            return childNode;
        }
    }
}
