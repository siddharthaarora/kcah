using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public class BinarySearchTree
    {
        private TreeNode root;

        public BinarySearchTree()
        { }

        public TreeNode Root
        {
            get
            {
                return root;
            }
        }

        public void Add(int value)
        {
            if (root == null)
            {
                root = new TreeNode(value);
            }
            else
            {
                root.Add(new TreeNode(value));
            }
        }

        public List<List<int>> Traverse(TraversalOrder order = TraversalOrder.LevelOrder)
        {
            List<List<int>> nodes = new List<List<int>>();

            if (order == TraversalOrder.InOrder)
            {
                TraverseInOrder(root, nodes);
            }
            else if (order == TraversalOrder.LevelOrder)
            {
                TraverseLevelOrder(root, nodes);
            }
            else if (order == TraversalOrder.LevelOrderZigZag)
            {
                TraverseLevelOrderZigZag(root, nodes);
            }
            return nodes;
        }

        public enum TraversalOrder
        {
            InOrder,
            LevelOrder,
            LevelOrderZigZag
        }

        private void TraverseLevelOrder(TreeNode node, List<List<int>> nodes)
        {
            List<TreeNode> parents = new List<TreeNode> { node };
            TraverseLevelOrder(parents, nodes);
        }

        private void TraverseLevelOrder(List<TreeNode> parents, List<List<int>> nodes)
        {
            List<TreeNode> newParents = new List<TreeNode>();
            List<int> values = new List<int>();

            foreach(TreeNode p in parents)
            {
                values.Add(p.Value);

                if (p.Left != null)
                {
                    newParents.Add(p.Left);
                }

                if (p.Right != null)
                {
                    newParents.Add(p.Right);
                }
            }

            nodes.Add(values);

            if (newParents.Count != 0)
            {
                TraverseLevelOrder(newParents, nodes);
            }
        }

        private void TraverseLevelOrderZigZag(TreeNode node, List<List<int>> nodes)
        { 
            List<TreeNode> parents = new List<TreeNode> { node };
            TraverseLevelOrderZigZag(parents, nodes, false);
        }

        private void TraverseLevelOrderZigZag(List<TreeNode> parents, List<List<int>> nodes, bool zigZag)
        {
            List<TreeNode> newParents = new List<TreeNode>();
            List<int> values = new List<int>();

            foreach (TreeNode p in parents)
            {
                values.Add(p.Value);

                if (p.Left != null) { newParents.Add(p.Left); }
                if (p.Right != null) { newParents.Add(p.Right); }
            }

            if (zigZag)
            {
                values.Reverse();
            }
            nodes.Add(values);

            if (newParents.Count != 0)
            {
                TraverseLevelOrderZigZag(newParents, nodes, !zigZag);
            }
        }


        private void TraverseInOrder(TreeNode node, List<List<int>> nodes)
        {
            if (node.Left != null)
            {
                TraverseInOrder(node.Left, nodes);
            }

            nodes.Add(new List<int> { node.Value });

            if (node.Right != null)
            {
                TraverseInOrder(node.Right, nodes);
            }
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            this.Value = value;
        }

        public void Add (TreeNode node)
        {
            if (node.Value < this.Value && this.Left != null)
            {
                this.Left.Add(node);
            }
            else if (node.Value > this.Value && this.Right != null)
            {
                this.Right.Add(node);
            }
            else if (node.Value < this.Value)
            {
                this.Left = node;
            }
            else if (node.Value > this.Value)
            {
                this.Right = node;
            }

        }
    }
}
