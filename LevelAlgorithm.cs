using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using core;

namespace algorithm
{
    public class LevelAlgorithm : ITraceAlgorithm
    {
        public Solution trace(Net net)
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
			//распространение волны
			for (; vers[node2] < 0; )
			{
				for (int i = 0; i < graph.Length; i++)
				{
					if (vers[i] == front)
					{
						for (int j = 0; j < graph[i].Length; j++)
						{
							if (vers[graph[i][j]] == -1)
							{
								vers[graph[i][j]] = front + 1;
							}
						}
					}
				}
				front++;
			}

			int way = front--;

			List<int> optway = new List<int>(way);
			
			int v = node2;
			
			front = vers[node2];
			//обратнй ход поиск пути
			for (; front >  0;)
			{
				for (int i = 0; i < graph[v].Length; i++)
				{
					if (vers[graph[v][i]] == front - 1) {
						
						optway.Add(graph[v][i]);
						v = graph[v][i];
						break;
					}

				}
				front--;
			}
			optway.Reverse();
			tracks[0] = new int[way];
			for (int i = 0; i < optway.Count; i++)
			{
				tracks[0][i] = optway[i];
			}
			


			return new Solution(net.Pins, tracks);
        }

        public bool checkSolution(Net net, Solution solution)
        {
            int[][] tracks = solution.Tracks;
            int[][] pins = solution.Pins;
            int[][] graph = net.Graph;
            bool result = true;

            if (tracks.Length != pins.Length)
            {
                Console.WriteLine("tracks.Length != pins.Length");
                return false;
            }


            //TODO: add num of not traced pins
            for (int i = 0; i < tracks.Length; i++)
            {
                if (tracks[i] != null)
                {
                    List<int> cur = new List<int>(graph[ pins[i][0] ]);
                    if (cur.IndexOf(tracks[i][0]) < 0)
                    {
                        Console.WriteLine("Error in track {0}, on benween pos 0 and 1. Edge doesn't exist", i);
                        result = false;
                    }

                    int len = tracks[i].Length;
                    for (int j = 0; j < len - 1; j++)
                    {
                        cur = new List<int>(graph[tracks[i][j]]);
                        if (cur.IndexOf(tracks[i][j + 1]) < 0)
                        {
                            Console.WriteLine("Error in track {0}, on pos {1}, benween {2} and {3}. Edge doesn't exist", i, j, tracks[i][j], tracks[i][j + 1]);
                            result = false;
                        }
                    }
                    cur = new List<int>(graph[ tracks[i][len - 1] ]);
                    if (cur.IndexOf(pins[i][1]) < 0)
                    {
                        Console.WriteLine("Error in track {0}, on pos {1}, benween {2} and {3}. Edge doesn't exist", i, len, tracks[i][len - 1], pins[i][1]);
                        result = false;
                    }
                }
                else
                {
                    Console.WriteLine("Track {0} is not traced", i);
                    //result = ?
                }
            }
            return result;
		}

		public static Solution searchSolution(Net net) {
			int[][] pins = net.Pins;
			int[][] tracks = new int[net.Pins.Length][];
			int[][] graph = net.Graph;
			int a = graph.Length;
			int[,] vers = new int[2,a];
			int[] optway = new int[a];
			for (int i = 0; i < a; i++)
			{
				vers[0, i] = i;
				vers[1, i] = -1;
				optway[i] = 0; 
			}
			
			int pin1 = pins[0][0];//пины которые нуно соединить
			int pin2 = pins[0][1];//пины которые нуно соединить
			int d;
			//vers[1, 0] = 0;
			for (int i = 0; i < a; i++)                        
			{
				if (graph[i].Length != 0)
				{
					d = vers[1, i] + 1;
					for (int j = 0; j < graph[i].Length; j++)
					{
						if (vers[1, graph[i][j]] == -1)
						{
							vers[1, graph[i][j]] = d;
						}

					}
				}
			}
			int v = vers[1, pin1];
			int k = 0;
			for (int j = pin1; j != pin2; )						
			{
				for (int i = 0; i < graph[j].Length; i++)	
				{
					if (vers[1, graph[j][i]] == v - 1) { optway[k] = graph[j][i]; break; }								
				}
				j = optway[k];
				v = vers[1, optway[k]];
				k++;
			}													
			

			return new Solution(pins, tracks);
		}

		

	}
}
