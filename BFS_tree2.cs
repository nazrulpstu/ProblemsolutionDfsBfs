using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class BFS_tree2
    {
        //https://lightoj.com/problem/farthest-nodes-in-a-tree-ii

        public static void Main1(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());

            for (int qItr = 0; qItr < q; qItr++)
            {
                int numberOfNode = int.Parse(Console.ReadLine().TrimEnd());
                List<Tuple<int, int>>[] graph = new List<Tuple<int, int>>[numberOfNode];

                for (int p = 0; p < numberOfNode; p++)
                {
                    graph[p] = new List<Tuple<int, int>>();

                }

                for (int j = 0; j < numberOfNode - 1; j++)
                {

                    int n, m, w;
                    string[] multipleInput = Console.ReadLine().TrimEnd().Split(' ');

                    n = Convert.ToInt32(multipleInput[0]);
                    m = Convert.ToInt32(multipleInput[1]);
                    w = Convert.ToInt32(multipleInput[2]);
                    // int newNumber = Convert.ToInt32(string.Format("{0}{1}", n, m));
                    Tuple<int, int> u = new Tuple<int, int>(n, w);
                    Tuple<int, int> v = new Tuple<int, int>(m, w);
                    graph[n].Add(v);
                    graph[m].Add(u);


                }
                List<int> dist = Enumerable.Repeat(0, numberOfNode).ToList();
                List<bool> visited = Enumerable.Repeat(false, numberOfNode).ToList();


                List<int> result = Result2.bfs(0, graph, ref visited, ref dist);
                int MAX = -1;
                int farthestNode = 0;
                for (int i = 0; i < result.Count; i++)
                {

                    if (result[i] > MAX)
                    {
                        farthestNode = i;
                        MAX = result[i];

                    }



                }


                for (int p = 0; p < visited.Count; p++)
                {

                    visited[p] = false;
                    dist[p] = 0;

                }
                List<int> result1 = Result2.bfs(farthestNode, graph, ref visited, ref dist);
                int FMAX = 0;
                int farthestNode2 = 0;

                for (int r = 0; r < result1.Count(); r++)
                {

                    if (FMAX < result1[r])
                    {
                        FMAX = result1[r];
                        farthestNode2 = r;

                    }

                }

                //  result1[farthestNode] = FMAX;
                for (int p = 0; p < visited.Count; p++)
                {

                    visited[p] = false;


                }


                List<int> distF2 = Enumerable.Repeat(0, numberOfNode).ToList();
                List<int> distFromF2Result = Result2.bfs(farthestNode2, graph, ref visited, ref distF2);


                Console.WriteLine("Case " + (qItr + 1) + ":");

                for (int s = 0; s < result1.Count; s++)
                {
                    Console.WriteLine(Math.Max(result1[s], distFromF2Result[s]));
                }







            }

        }

    }

    class Result2
        {

            /*
             * Complete the 'bfs' function below.
             *
             * The function is expected to return an INTEGER_ARRAY.
             * The function accepts following parameters:
             *  1. INTEGER n
             *  2. INTEGER m
             *  3. 2D_INTEGER_ARRAY edges
             *  4. INTEGER s
             */

            public static List<int> bfs(int src, List<Tuple<int, int>>[] graph, ref List<bool> visited, ref List<int> dist)
            {

                Queue<int> queue = new Queue<int>();
                queue.Enqueue(src);
                visited[src] = true;

                while (queue.Count != 0)
                {
                    src = queue.Dequeue();
                    for (int i = 0; i < graph[src].Count(); i++)
                    {

                        int dest = graph[src][i].Item1;
                        int w = graph[src][i].Item2;
                        if (visited[dest] == false)
                        {
                            visited[dest] = true;
                            dist[dest] = dist[src] + w;
                            queue.Enqueue(dest);

                        }
                    }
                }

                return dist;

            }



        }
    }

