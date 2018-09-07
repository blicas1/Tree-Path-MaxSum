namespace BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Node
    {
        public Node(int value)
        {
            Number = value;
        }

        public int Number { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public bool Checked { get; set; }
    }

    class Program
    {
        static void Main()
        {
            string dataPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())) + "\\data.txt";
            List<List<int>> listOfTree = GenerateListOfTree(dataPath);

            Node binaryTree = CreateBinaryTree(listOfTree);
            GenerateResults(binaryTree);
            Console.ReadKey();
        }

        private static List<List<int>> GenerateListOfTree(string path)
        {
            string[] data = File.ReadAllText(path).Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            List<List<int>> list = new List<List<int>> { };

            foreach (string singleData in data)
            {
                List<int> numbers = singleData.Split(' ').Select(x => Convert.ToInt32(x)).ToList();
                list.Add(numbers);
            }

            return list;
        }

        private static Node CreateBinaryTree(List<List<int>> treeList)
        {
            Node binaryTree = new Node(treeList[0].First()); // setting a peak of a tree
            List<Node> nodes = new List<Node> { binaryTree };

            for (int row = 1; row < treeList.Count; row++)
            {
                List<int> allRowNumbers = treeList[row].ToList();
                List<Node> tempNodes = new List<Node> { };

                for (int i = 0; i < nodes.Count; i++)
                {
                    int index = Array.FindIndex(treeList[row - 1].ToArray(), nr => nr == nodes[i].Number);
                    nodes[i].Left = new Node(allRowNumbers[index]);
                    nodes[i].Right = new Node(allRowNumbers[index + 1]);

                    tempNodes.Add(nodes[i].Left);
                    tempNodes.Add(nodes[i].Right);
                }

                nodes = new List<Node>(tempNodes);
            }

            return binaryTree;
        }

        private static void GenerateResults(Node binaryTree)
        {
            List<int> correctPath = new List<int>();
            int max = 0;

            Stack<Node> stack = new Stack<Node>();
            stack.Push(binaryTree);

            while (stack.Count != 0)
            {
                if (!stack.Peek().Checked)
                {
                    if (stack.Peek().Left != null && !stack.Peek().Left.Checked)
                    {
                        stack.Push(stack.Peek().Left);
                        continue;
                    }

                    if (stack.Peek().Right != null && !stack.Peek().Right.Checked)
                    {
                        stack.Push(stack.Peek().Right);
                        continue;
                    }

                    stack.Peek().Checked = true;
                }
                else
                {
                    if (stack.Peek().Left == null && stack.Peek().Right == null && IsOddEven(stack))
                    {
                        int singleStackMax = stack.Select(x => x.Number).ToArray().Sum();

                        if (singleStackMax > max)
                        {
                            max = singleStackMax;
                            correctPath = stack.Select(x => x.Number).ToList();
                        }
                    }

                    stack.Pop();
                }
            }

            Console.WriteLine("Max sum " + max);
            Console.WriteLine("Path: " + GeneratePath(correctPath));
        }

        private static bool IsOddEven(Stack<Node> stack)
        {
            Stack<Node> stackTmp = new Stack<Node>(stack);
            while (stackTmp.Count != 1)
            {
                if (stackTmp.Pop().Number % 2 == stackTmp.Peek().Number % 2)
                {
                    return false;
                }
            }

            return true;
        }

        private static string GeneratePath(List<int> values)
        {
            string path = string.Empty;

            for (int i = values.Count; i >= 1; i--)
            {
                path += values[i - 1] + (i != 1 ? ", " : string.Empty);
            }

            return path;
        }
    }
}