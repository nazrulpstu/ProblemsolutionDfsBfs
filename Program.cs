using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    class CustomLinklist //--Program
    {
        
        public static void Main(string[] args)
        {

            Result1  res = new Result1();
            var days = new int[] { 1, 4, 6, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 20, 21, 22, 23, 27, 28 };
            //1,4,6,9,10,11,12,13,14,15,16,17,18,20,21,22,23,27,28
            var costs = new int[]{ 3, 13, 45 };//3,13,45
                                            // res.MincostTickets(days,costs);
            Console.WriteLine(res.MincostTickets(days, costs));

        }


    }

   




}


