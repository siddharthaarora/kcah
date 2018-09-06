//Given a boolean 2D matrix, find the number of islands.
//A group of connected 1s forms an island.For example, the below matrix contains 5 islands
//Example:
//Input : mat[][] = {
//                   { 1, 1, 0, 0, 0},
//                   { 0, 1, 0, 0, 1},
//                   { 1, 0, 0, 1, 1},
//                   { 0, 0, 0, 0, 0},
//                   { 1, 0, 1, 0, 1}
//                  }
//    Output: 5

// For reference, this is Adjajency metrix representation of a graph
// https://stackoverflow.com/questions/15306040/generate-an-adjacency-matrix-for-a-weighted-graph
// https://www.geeksforgeeks.org/find-number-of-islands/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge
{
    public class Graph
    {
        public class Node
        {
            public string Value {get; set;}
            public List<Edge> Edges = new List<Edge>();

            public Node(string value)
            {
                this.Value = value;
            }

            public Node AddEdge(Node child, int weight)
            {
                Edge edge = new Edge();
                edge.Parent = this;
                edge.Child = child;
                edge.Weight = weight; 
                Edges.Add(edge);

                if (!child.Edges.Exists(a => a.Parent == child && a.Child == this))
                {
                    child.AddEdge(this, weight);
                }

                return this;
            }
        }
        public class Edge
        {
            public int Weight {get; set;}
            public Node Parent {get; set;}
            public Node Child {get; set;}
        }

        public Node Root {get; set;}

        public List<Node> Nodes = new List<Node>();

        public Node AddNode(string value)
        {
            var n = new Node(value);
            this.Nodes.Add(n);

            if (this.Nodes.Count == 1)
            {
                this.Root = n;
            }

            return n;
        }

        public int?[,] CreateAdjacencyMatrix()
        {
            int?[,] adjMatrix = new int?[Nodes.Count, Nodes.Count];

            for(int i=0; i<Nodes.Count; i++)
            {
                Node n1 = Nodes[i];

                for(int j=0; j<Nodes.Count; j++)
                {
                    Node n2 = Nodes[j];

                    var edge = n1.Edges.FirstOrDefault(a => a.Child == n2);
                    
                    if (edge != null)
                    {
                        adjMatrix[i,j] = 1;
                    }
                }
            }

            return adjMatrix;
        }

        public void PrintAdjacencyMatrix(int?[,] adjMatrix)
        {
            Console.Write("      ");
            for(int i=0; i<adjMatrix.GetLength(0);i++)
            {
                Console.Write("{0} ", (char)('A' + i));
            }
            Console.WriteLine();
            for(int i=0; i<adjMatrix.GetLength(0); i++)
            {
                Console.Write("{0} | [ ", (char)('A' + i));
                for(int j=0; j<adjMatrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.Write("- ");
                    }
                    else if (adjMatrix[i,j] == null)
                    {
                        Console.Write("0 ");
                    }
                    else
                    {
                        Console.Write("{0} ", adjMatrix[i,j]);
                    }
                }
                Console.Write(" ]\r\n");
            }
            Console.Write("\r\n");
        }

        public static Graph CreateSampleGraph()
        {
            var graph = new Graph();

            var a = graph.AddNode("A");
            var b = graph.AddNode("B");
            var c = graph.AddNode("C");
            var d = graph.AddNode("D");
            var e = graph.AddNode("E");
            var f = graph.AddNode("F");
            var g = graph.AddNode("G");
            var h = graph.AddNode("H");
            var i = graph.AddNode("I");
            var j = graph.AddNode("J");
            var k = graph.AddNode("K");
            var l = graph.AddNode("L");
            var m = graph.AddNode("M");
            var n = graph.AddNode("N");
            var o = graph.AddNode("O");
            var p = graph.AddNode("P");

            a.AddEdge(b, 1)
             .AddEdge(c, 1)
             .AddEdge(d, 1);

            g.AddEdge(h, 1)
             .AddEdge(i, 1);

            g.AddEdge(k, 1);

            n.AddEdge(o, 1)
             .AddEdge(p, 1);

            return graph;
        }
        public static void Test_GraphAdjacencyMatrix()
        {
            var graph = Graph.CreateSampleGraph();

            int?[,] adjMatrix = graph.CreateAdjacencyMatrix();

            graph.PrintAdjacencyMatrix(adjMatrix);
        }

    }
}
