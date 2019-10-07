using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class Parser
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

        public static Solution getSolution(string fname)
        {
            string[] text = File.ReadAllLines(fname);
            int nN = Int32.Parse(text[0]); //num nodes
            int nP = Int32.Parse(text[nN + 1]); //num pins

            int[][] tracks = new int[nN][];
            for (int i = 0; i < nN; i++)
            {
                string[] f = text[i + 1].Split(' ');
                int size = f.Length;//num of adjacent nodes 
                tracks[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    tracks[i][j] = Int32.Parse(f[j]);
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

            return new Solution(pins, tracks);
        }
    }
}
