using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemsolutionDfsBfs
{
    class minimum_cost_for_tickets
    {
        //https://leetcode.com/problems/minimum-cost-for-tickets/
        public static void Main(string[] args)
        {

            Result1 res = new Result1();
            var days = new int[] { 1, 4, 6, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23, 27, 28 };
            //1,4,6,9,10,11,12,13,14,15,16,17,18,20,21,22,23,27,28
            var costs = new int[] { 3, 13, 45 };//3,13,45
                                                // res.MincostTickets(days,costs);
            Console.WriteLine(res.MincostTickets(days, costs));

        }
    }
    class Result1
    {
        public int[] dP = new int[365];

        public int MincostTickets(int[] days, int[] costs)
        {
            //int[] defaultValues = Enumerable.Repeat(-1, ((dP.GetLength(0)) * (dP.GetLength(1)))).ToArray();
            //var length = dP.Length;
            //Array.Copy(defaultValues, dP, defaultValues.Length);
            for (int i = 0; i < dP.Length; i++)
            {
                dP[i] = -1;

            }



            //    MinCost(0, days[0]-1,days,costs);

            return MinCost(days[0], days, costs);

        }

        public int MinCost(int permit, int[] days, int[] cost)
        {

            if (permit == 365)
            {

                return 0;

            }

            if (dP[permit] != -1)
            {
                return dP[permit];

            }
            var finalResult = 0;
            if (days.Contains(permit))
            {
                int result1 = MinCost(permit + 1, days, cost) + cost[0];
                int result7 = MinCost(permit + 7, days, cost) + cost[1];//7 days
                int result15 = MinCost(permit + 30, days, cost) + cost[2];// 15 days
                finalResult = Math.Min(result1, Math.Min(result7, result15));
            }
            else
            {

                finalResult = MinCost(permit + 1, days, cost);

            }

            return dP[permit] = finalResult;

        }

    }
}
