using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class BFS1
    {
        public static int BFS(int src, List<List<int>> graph, ref List<int> visited, ref List<int> color)
        {

            int one = 1;
            int zero = 0;
            visited[src] = 1;
            color[src] = 1;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(src);
            while (queue.Count != 0)
            {
                src = queue.Dequeue();
                for (int i = 0; i < graph[src].Count(); i++)
                {
                    int dest = graph[src][i];
                    if (visited[dest] == 0)
                    {
                        visited[dest] = 1;
                        if (color[src] == 1)
                        {
                            color[dest] = 0;
                            zero++;

                        }
                        else
                        {

                            color[dest] = 1;
                            one++;

                        }


                        queue.Enqueue(dest);
                    }
                }

            }
            return Math.Max(one, zero);
        }


        static void Main1(string[] args)
        {

            const int NODE = 20005;
            int T = int.Parse(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                List<int> nodes = new List<int>();
                int N = int.Parse(Console.ReadLine());
                List<List<int>> graph = new List<List<int>>();

                for (int j = 0; j < NODE; j++)
                {

                    graph.Add(new List<int>());

                }

                for (int j = 0; j < N; j++)
                {

                    string[] edgeInput = Console.ReadLine().Split();
                    int U = int.Parse(edgeInput[0]);
                    int V = int.Parse(edgeInput[1]);
                    graph[U].Add(V);
                    graph[V].Add(U);
                    nodes.Add(U);
                    nodes.Add(V);


                }

                List<int> visited = new List<int>();
                List<int> color = new List<int>();

                for (int j = 0; j < NODE; j++)
                {
                    visited.Add(0);
                    color.Add(-1);
                }
                int maxFight = 0;
                foreach (int src in nodes)
                {
                    if (visited[src] == 0)
                        maxFight += BFS(src, graph, ref visited, ref color);

                }


                Console.WriteLine("Case " + (i + 1) + ": " + maxFight);

            }



        }
    }
}
