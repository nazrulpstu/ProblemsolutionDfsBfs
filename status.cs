using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsolutionDfsBfs
{
    class status
    {

        class CustomLinklist //--Program
        {
            //https://codeforces.com/contest/129/problem/C?fbclid=IwAR2KPMTOnr-KYJKrtVopP8YZUcrYbfP_y1JjQtVi_m_tvFnaFahS4iHI7Hc
            public static void MainStatue(string[] args)
            {
                //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

                List<string> graph = new List<string>();
                int WRow = 8;
                int HCol = 8;
                bool[,] visited = new bool[WRow, HCol];

                for (int row = 0; row < WRow; row++)
                {

                    string line = Console.ReadLine();
                    graph.Add(line);


                }

                bool result = Result.Bfs(graph);

                Console.WriteLine((result == true) ? "WIN" : "LOSE");


            }


        }

        class Result
        {

            public static bool Bfs(List<string> graph)
            {

                bool isValid(int destinationX, int destinationY)
                {
                    if (destinationY > 7 || destinationX > 7 || destinationY < 0 || destinationX < 0)
                    {
                        return false;

                    }
                    return true;
                }

                bool isAllowedMove(int destinationX, int destinationY, List<string> graph, int numberOfMove)
                {


                    if (isValid(destinationX, destinationY))
                    {
                        if (numberOfMove > 7)
                        {
                            return true;
                        }
                        destinationX = destinationX - numberOfMove;
                        if (isValid(destinationX, destinationY))
                        {

                            if (graph[destinationX][destinationY] == 'S')
                            {

                                return false;
                            }

                            destinationX -= 1;
                            if (isValid(destinationX, destinationY))
                            {

                                if (graph[destinationX][destinationY] == 'S')
                                {

                                    return false;
                                }


                                return true;

                            }
                            return true;

                        }



                        return true;
                    }


                    return false;
                }

                int positionX = 7;
                int positionY = 0;

                int targetX = 0;
                int targetY = 7;

                int[,] distance = new int[8, 8];
                distance[positionX, positionY] = 0;
                int numberOfMove = 0;
                Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();
                queue.Enqueue(Tuple.Create(positionX, positionY, 0));
                while (queue.Count != 0)
                {

                    Tuple<int, int, int> dque = queue.Dequeue();
                    positionX = dque.Item1;
                    positionY = dque.Item2;
                    numberOfMove = dque.Item3;

                    //L,R,UR,UL,U,D,DL,DR
                    int[] directX = { 0, 0, -1, -1, 0, -1, 1, 1, 1 };
                    int[] directY = { -1, 1, 1, -1, 0, 0, 0, -1, 1 };

                    int[] dx = { 0, -1 };
                    int[] dy = { 1, 0 };
                    for (int i = 0; i < directX.Count(); i++)
                    {

                        int destinationX = positionX + directX[i];
                        int destinationY = positionY + directY[i];
                        // string direction = "lrRLN";

                        if (isAllowedMove(destinationX, destinationY, graph, numberOfMove))
                        {
                            // Console.WriteLine("from:"+positionX +"  "+ positionY +"  To :"+ destinationX +"  "+ destinationY);
                            // Console.ReadLine();

                            // Console.WriteLine("posX:" + positionX + "  posY : " + positionY + " direction : " + direction[i]);
                            // Console.WriteLine("DesX:" + destinationX + "  destY : " + destinationY + " distance : " + distance[positionX, positionY]);
                            if ((targetX == destinationX) && (targetY == destinationY))
                            {

                                return true;
                            }
                            queue.Enqueue(Tuple.Create(destinationX, destinationY, numberOfMove + 1));


                        }



                    }




                }


                return false;
            }





        }
    }
}
