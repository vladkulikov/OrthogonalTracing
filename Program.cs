using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core;
using algorithm;


namespace OrthogonalTracing
{
    class Program
    {

        public static Net getData(string fname)
        {
            string[] text = File.ReadAllLines(fname);
            int nN = Int32.Parse(text[0]); //num nodes
            int nP = Int32.Parse(text[nN + 1]); //num pins

            int[][] graph = new int[nN][];
            for (int i = 0; i < nN; i++)
            {
                string[] f = text[i + 1].Split(' ');
                int size = f.Length;//num of adjacent nodes 
                graph[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    graph[i][j] = Int32.Parse(f[j]);
                }
            }

            int[][] pins = new int[nP][];
            for (int i = 0; i < nP; i++)
            {
                string[] f = text[i + nN + 2].Split(' ');
                int size = f.Length;
                if (size != 2) //this limitation may be removed later
                {
                    Console.WriteLine("Pins array should contain pairs only");
                    Console.ReadLine();
                    return null;
                }
                pins[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    pins[i][j] = Int32.Parse(f[j]);
                }
            }

            return new Net(graph, pins);
        }

        public static Solution trace(Net net)
        {
            int[][] tracks = new int[net.Pins.Length][];
            int[][] pins = net.Pins;
            int[][] graph = net.Graph;
            int a = graph.Length;
            int[] vers = new int[a];
            int front = 0;
            int node1 = pins[0][0];
            int node2 = pins[0][1];

            for (int i = 0; i < a; i++)
            {

                vers[i] = -1;
            }

            vers[node1] = front;

            for (; vers[pins[0][1]] < 0;)
            {
                for (int i = 0; i < graph.Length; i++)
                {
                    if (vers[i] == front)
                    {
                        for (int j = 0; j < graph[i].Length; j++)
                        {
                            vers[j] = front + 1;
                        }
                    }
                }
                front++;
            }

            int way = front--;

            List<int> optway = new List<int>(way);

            int v = node2;
            front = vers[node2];

            for (; front != 0;)
            {
                for (int i = 0; i < graph[v].Length; i++)
                {
                    if (vers[graph[v][i]] == front - 1)
                    {

                        optway.Add(graph[v][i]);
                        v = graph[v][i];
                        break;
                    }
                }
                front--;
            }
            optway.Reverse();
            for (int i = 0; i < optway.Count; i++)
            {
                tracks[0][i] = optway[i];
            }



            return new Solution(net.Pins, tracks);
        }

        static void Main(string[] args)
        {
			int[][] testgraph = new int[100][];
			int[][] testpins = new int[1][];
            string s = "testproject.txt";



            Net  test = getData(s);

            Solution decision = trace(test);

            Console.WriteLine(decision.Tracks[0][0]);

           Console.ReadKey();
        }
    }
}
