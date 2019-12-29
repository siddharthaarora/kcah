// Simple Graph implementation

using System;
using System.Collections;

namespace Kcah
{
    public class Graph
    {
        private Hashtable map;
        public int Count { get; set; }

        public GraphNode[] Nodes{ get; }

        public Graph(int capacity)
        {
            this.Nodes = new GraphNode[capacity];
            this.map = new Hashtable(capacity);
            this.Count = 0;
        }

        public void AddNode(GraphNode node)
        {
            this.Nodes[this.Count] = node;
            this.map.Add(node.Value, this.Count - 1);
            this.Count++;
        }

        public int[,] GetAdjacencyMatrix()
        {
            int[,] matrix = new int[this.Count,this.Count];
            for (int i=0; i<this.Count; i++)
            {
                GraphNode n = this.Nodes[i];
                for (int j=0; j<n.Count; j++)
                {
                    GraphNode c = n.Children[j];
                    matrix[i,Convert.ToInt32(this.map[c.Value])] = 1;
                }
            }
            return matrix;
        }

        public void PrintAdjacencyMatrix(int[,] matrix)
        {
            for(int i=0; i < this.Count; i++)
            {
                Console.WriteLine(i.ToString());
                Console.WriteLine("|");
                for(int j=0; j < this.Count; j++)
                {
                    if (i == 0)
                    {
                    Console.WriteLine(j.ToString());
                    Console.Write("__");
                    }
                    Console.Write(matrix[i,j].ToString());
                }
            }
        }
    }

    public class GraphNode
    {
        public int Count { get; set; }
        public string Value {get; set; }
        public GraphNode[] Children { get; }

        public GraphNode(string value, int childrenCount)
        {
            this.Value = value;
            this.Children = new GraphNode[childrenCount];
            this.Count = 0;
        }

        public void AddChild(GraphNode child)
        {
            this.Children[this.Count] = child;
            this.Count++;
        }
    }

    public static class TestGraph
    {
        internal static Graph g;

        internal static void CreateGraph()
        {
            g = new Graph(10);
            GraphNode nA = new GraphNode("A", 3);
            GraphNode nB = new GraphNode("B", 1);
            GraphNode nC = new GraphNode("C", 0);
            GraphNode nD = new GraphNode("D", 3);
            GraphNode nE = new GraphNode("E", 1);
            GraphNode nF = new GraphNode("F", 0);
            GraphNode nG = new GraphNode("G", 0);

            nA.AddChild(nB);
            nA.AddChild(nD);
            nA.AddChild(nE);

            nB.AddChild(nD);

            nD.AddChild(nC);
            nD.AddChild(nG);
            nD.AddChild(nF);

            nE.AddChild(nD);

            g.AddNode(nA);
            g.AddNode(nB);
            g.AddNode(nC);
            g.AddNode(nD);
            g.AddNode(nE);
            g.AddNode(nF);
            g.AddNode(nG);
        }
        public static void Test_GetAdjacencyMatrix()
        {
            CreateGraph();
            int[,] matrix = g.GetAdjacencyMatrix();
            g.PrintAdjacencyMatrix(matrix);
        }
    }
}
