using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankPrcatice
{
    class Program
    {
        static void Main(string[] args)
        {
            //            List<int> a = new List<int>() { 17 ,28, 30 };
            //          List<int> b = new List<int>() { 99, 16 ,8 };
            //        List<int> c =compareTriplets(a, b);

            string s = Console.ReadLine();

            string result = timeConversion(s);
            Console.WriteLine(result);

            Console.Read();
        }

        static string timeConversion(string s)
        {
            /*
             * Write your code here.
             */

            if (s.Contains("AM"))
            {
                s = s.TrimEnd('M');
                s = s.TrimEnd('A');
            }
            else//For PM
            {//07:05:45PM
                string[] time = s.Split(':');
                int newtime = int.Parse(time[0]) + 12;
                if (newtime == 24)
                    newtime = 0;
                time[0] = newtime.ToString("00");
                s = s.TrimEnd('M');
                s = s.TrimEnd('P');
                s=s.Remove(0, 2);
                s = time[0] + s;

            }
            return s;

        }
        static List<int> compareTriplets(List<int> a, List<int> b)
        {
            int aCount = 0, bCount = 0;
            List<int> finalCount = new List<int>();
            for (int i = 0; i < a.Count(); i++)
            {
                if (a[i] > b[i])
                {
                    aCount++;
                }
                else if (a[i] < b[i])
                {
                    bCount++;
                }
            }
            finalCount.Add(aCount);
            finalCount.Add(bCount);

            return finalCount;
        }
    }
}
