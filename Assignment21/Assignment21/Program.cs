using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
                //Console.WriteLine(Problem1(Console.ReadLine()));
                Console.WriteLine(Problem2(Console.ReadLine(), Console.ReadLine()));
            //Console.ReadLine();
            //}
    }

        private static string Problem2(string strLength, string strTree)
        {
            int nodesCount = int.Parse(strLength);
            int treeDepth = 0;
            //int[,] rawTree = new int[2, nodesCount];
            //Dictionary<int, int> rawTree = new Dictionary<int, int>();
            List<RawNode> rawNodes = new List<RawNode>();
            RawNode rawNode;
            RawNode root = new RawNode();
            int i = 0;
            foreach (string item in strTree.Split(" ".ToCharArray()))
            {
                //rawTree.Add(i, int.Parse(item));
                rawNode = new RawNode();
                rawNode.Value = i;
                rawNode.ParentValue = double.Parse(item);

                // We encountered the root node
                if (double.Parse(item) == -1)
                {
                    rawNode.placed = true;
                    rawNode.depth = 1;
                    root = rawNode;
                }
                rawNodes.Add(rawNode);
                i++;
            }
            int depth = root.depth;
            foreach (RawNode currentNode in rawNodes)
            {
                if(!currentNode.placed)
                {
                    foreach (RawNode node in rawNodes)
                    {
                        if(node.Value == currentNode.ParentValue)
                        {
                            if (null == node.Children) node.Children = new List<RawNode>();
                            node.Children.Add(currentNode);
                            currentNode.placed = true;
                            currentNode.depth = node.depth + 1;
                            if (currentNode.depth > depth) depth = currentNode.depth;
                            break;
                        }
                    }
                }
            }
            //return maxDepth.ToString();
            return maxDepth(root).ToString();
        }

        static int maxDepth(RawNode node)
        {
            if (node == null) return 0;
            int max = 0;
            int temp = 0;
            if (null != node.Children)
            {
                foreach (RawNode child in node.Children)
                {
                    temp = maxDepth(child);
                    if (temp > max)
                        max = temp;
                }
            }
            return max + 1;
            /*
            //compute the depth of each subtree 
            int lDepth = maxDepth(node.left);
            int rDepth = maxDepth(node.right);

            // use the larger one 
            if (lDepth > rDepth)
                return (lDepth + 1);
            else
                return (rDepth + 1);
            */
        }

        private static string Problem21(string strLength, string strTree)
        {
            int nodesCount = int.Parse(strLength);
            int treeDepth = 0;

            return "";
        }

        #region Problem 1
        public static string Problem1(string strCode)
        {
            int i = 0;
            Stack<KeyValuePair<int, char>> brackets = new Stack<KeyValuePair<int, char>>();
            foreach (char currentChar in strCode.ToCharArray())   
            {
                i++;
                if(isOpeningBracket(currentChar))
                {
                    brackets.Push(new KeyValuePair<int, char>(i, currentChar));
                    continue;
                }
                if(isClosingBracket(currentChar))
                {
                    if (brackets.Count == 0)
                        //return (strCode.IndexOf(currentChar) + 1).ToString();
                        return i.ToString();
                    KeyValuePair<int, char> stackTop = brackets.Pop();
                    if(isMatchingBrackets( stackTop.Value, currentChar))
                    {
                        continue;
                    }
                    else
                    {
                        return i.ToString();
                    }
                }
            }
            if (brackets.Count > 0)
            {
                if (isClosingBracket(brackets.Peek().Value))
                    return i.ToString();
                else
                    return brackets.Peek().Key.ToString();
            }
            return "Success";
        }
        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        private static bool isMatchingBrackets(char stackTop, char currentChar)
        {
            if (
                (stackTop.Equals('{') && currentChar.Equals('}')) ||
                (stackTop.Equals('[') && currentChar.Equals(']')) ||
                (stackTop.Equals('(') && currentChar.Equals(')'))
              )
                return true;

            return false;
        }

        private static bool isClosingBracket(char currentChar)
        {
            if (currentChar.Equals('}') || currentChar.Equals(']') || currentChar.Equals(')')) return true;
            return false;
        }

        private static bool isOpeningBracket(char currentChar)
        {
            if (currentChar.Equals('{') || currentChar.Equals('[') || currentChar.Equals('(')) return true;
            return false;
        }
        #endregion
    }

    class Node
    {
        public double value;
        public List<Node> Children = new List<Node>();
    }

    class RawNode
    {
        /// <summary>
        /// Node Value
        /// </summary>
        public double Value;

        /// <summary>
        /// Parent Node Value
        /// </summary>
        public double ParentValue;

        /// <summary>
        /// Pointer to parent
        /// </summary>
        public RawNode Parent;

        /// <summary>
        /// List of children
        /// </summary>
        public List<RawNode> Children;
        public bool placed = false;
        public int depth;
    }
}
