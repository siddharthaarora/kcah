using System;

namespace Challenge
{    
    public class OldTreeNode
    {
        public int Value;
        public OldTreeNode Left;
        public OldTreeNode Right;

        public OldTreeNode()
        {
            Value = 0;
        }
        public OldTreeNode(int value)
        {
            Value = value;
        }
        public void Insert(int v)
        {
            if (Value == 0)
            {
                Value = v;
            }
            else if (v < Value)
            {
                if (Left == null)
                {
                    Left = new OldTreeNode();
                }
                Left.Insert(v);
            }
            else
            {
                if (Right == null)
                {
                    Right = new OldTreeNode();
                }
                Right.Insert(v);
            }
        }

        public void PrintTree()
        {
            PrintTree(false, "");
        }

        private void PrintNodeValue()
        {
            if (Value == 0)
            {
                Console.WriteLine("<null>");
            }
            else
            {
                Console.WriteLine(Value.ToString());
            }
        }

        private void PrintTree(bool isRightNode, string indent)
        {
            if (Right != null)
            {
                Right.PrintTree(true, indent + (isRightNode ? "        " : " |    "));
            }
            Console.Write(indent);

            if (isRightNode)
            {
                Console.Write("/");
            }
            else
            {
                Console.Write("\\");
            }
            
            Console.Write("---- ");
            PrintNodeValue();

            if (Left != null)
            {
                Left.PrintTree(false, indent + (isRightNode ? " |    " : "        "));
            }
        }
    }
}