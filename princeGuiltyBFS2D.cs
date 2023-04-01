using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsolutionDfsBfs
{
    //https://lightoj.com/problem/guilty-prince
    class princeGuiltyBFS2D
    {
        public static void MainGGGG(string[] args)
        {
            //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int q = Convert.ToInt32(Console.ReadLine().Trim());


            for (int qItr = 0; qItr < q; qItr++)
            {

                List<string> graph = new List<string>();
                //int numberOfNode = int.Parse(Console.ReadLine().TrimEnd());
                string[] multipleInput = Console.ReadLine().TrimEnd().Split(' ');
                int WRow = Convert.ToInt32(multipleInput[1]);
                int HCol = Convert.ToInt32(multipleInput[0]);
                bool[,] visited = new bool[WRow, HCol];
                int positionR = 0;
                int positionC = 0;
                for (int row = 0; row < WRow; row++)
                {

                    string line = Console.ReadLine();
                    graph.Add(line);

                    for (int col = 0; col < graph[row].Length; col++)
                    {

                        if (graph[row][col] == '@')
                        {
                            positionR = row;
                            positionC = col;
                        }

                    }

                }

                for (int v = 0; v < WRow; v++)
                {
                    for (int u = 0; u < HCol; u++)
                        visited[v, u] = false;
                }



                int result = Result.bfs2D(positionR, positionC, WRow, HCol, graph, ref visited);

                Console.WriteLine("Case " + (qItr + 1) + ": " + result);



            }

        }
    }

    class Result
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

        public static int bfs2D(int srcX, int srcY, int maxRow, int maxCol, List<string> graph, ref bool[,] visited)
        {
            int numberOfDest = 1;

            visited[srcX, srcY] = true;
            Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(Tuple.Create(srcX, srcY));

            while (queue.Count != 0)
            {
                Tuple<int, int> src = queue.Dequeue();
                srcX = src.Item1;
                srcY = src.Item2;
                //U,R,L,D
                int[] dx = { -1, 0, 0, 1 };
                int[] dy = { 0, 1, -1, 0 };
                for (int d = 0; d < 4; d++)
                {
                    int destinationX = srcX + dx[d];
                    int destinationY = srcY + dy[d];

                    if (destinationX < 0 || destinationY < 0 || destinationX >= maxRow || destinationY >= maxCol)
                        continue;

                    if (visited[destinationX, destinationY] == false && graph[destinationX][destinationY] == '.')
                    {
                        visited[destinationX, destinationY] = true;
                        queue.Enqueue(Tuple.Create(destinationX, destinationY));
                        numberOfDest += 1;

                    }


                }


            }


            return numberOfDest;
        }





    }
}
