using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            string s = "asad";
            string sa = "asad";
           

            Console.WriteLine(s.GetHashCode());
            Console.WriteLine(sa.GetHashCode());
            Console.Read();
        }

        // Complete the jumpingOnClouds function below.
        //0 0 0 0 1 0
        static int jumpingOnClouds(int[] c)
        {
            //int count = 0;
            //int temp=2, temp2=2;
            //for (int i = 0; i < c.Length; i++)
            //{
            //    if (c[i] == 0 && temp != 0 && temp2 != 0)
            //    {
            //        temp = c[i];
            //    }
            //    else if (c[i] == 0 && temp == 0)
            //    {
            //        count++;
            //        temp = 2;
            //        temp2 = 0;
            //    }
            //    else if (c[i] == 0 && temp2 == 0)
            //    {
            //        temp2 = 2;
            //        temp = 0;
            //    }
            //    else if (c[i] == 1)
            //    {
            //        temp2 = 2;
            //        temp = 2;
            //    }
            //}

            /*
             
             [0] [0] [0] [1] [0] [0]

             */

            int count = 0;
            for (int i = 0; i < c.Length - 1; i++)
            {
                if (c[i] == 0 && c[i + 1] == 0 )
                {
                    count++;
                    if(i<c.Length-2)
                    if (c[i + 2] == 0 && c[i + 1] == 0)
                        i++;
                }
                else if (c[i] == 0 && c[i + 2] == 0)
                {
                    count++;
                    i++;
                }
            }

            Console.WriteLine($"count={count} ");

            return count;
        }

        /*
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */
        static int birthdayCakeCandles(int[] ar)
        {
            Array.Sort(ar);
            int max = ar.Max();
            int count = 0;
            foreach (int a in ar)
            {
                if (a == max)
                    count++;
            }
            return count;

        }
        // Complete the divisibleSumPairs function below.
        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int result = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        result++;
                }

            }

            return result;
        }
        //a
        //5
        //aaaaa
        static long repeatedString(string s, long n)
        {
            long check = 0;
            int i = 0, j = 0, k = 0;
            long count = 0;

            for (i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                    count++;
            }

            long div = n / s.Length;
            long reminder = n % s.Length;

            count = div * count;

            for (i = 0; i < reminder; i++)
            {
                if (s[i] == 'a')
                    count++;
            }

            return count;
        }
        // Complete the birthday function below.
        static int birthday(List<int> s, int d, int m)
        {
            //d no of choclate
            //m segment
            int count = 0; int result = 0;
            for (int i = 0; i < s.Count + 1 - m; i++)
            {
                for (int j = i; j < i + m; j++)
                {
                    count = count + s[j];

                }
                if (count == d)
                    result++;
                count = 0;
            }
            return result;
        }

        // Complete the kangaroo function below.
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            string result = "NO";
            int k1 = x1 + v1;
            int k2 = x2 + v2;

            for (int i = 0; i < 10000; i++)
            {
                if ((k1) == (k2))
                { result = "YES"; break; }
                k1 = k1 + v1;
                k2 = k2 + v2;
            }

            return result;
        }

        // Complete the viralAdvertising function below.
        static int viralAdvertising(int n)
        {
            int ressult = 0;
            int temp = 5 / 2;
            int likes = temp;
            for (int i = 0; i < n - 1; i++)//For Five days
            {
                likes = (likes * 3) / 2;
                temp = temp + likes;

            }
            return temp;
        }
        public static int diagonalDifference(List<List<int>> arr)
        {
            int difference = 0;
            int j = arr.Count - 1;
            int d1 = 0, d2 = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                d1 = d1 + arr[i][i];
                d2 = d2 + arr[i][j];
                j--;

            }
            return Math.Abs(d1 - d2);
        }

        public static int maxHeight(List<int> stickPositions, List<int> stickHeights)
        {
            int n = stickPositions.Count;
            int m = stickHeights.Count;
            int max = 0;
            // 1 3 7
            // 4 3 3
            // 2 4 5 6
            // 4 4 5 4
            for (int i = 0; i < n - 1; i++)
            {
                if (stickPositions[i] < stickPositions[i + 1] - 1)
                {
                    // We have a gap
                    int heightDiff = Math.Abs(stickHeights[i + 1] - stickHeights[i]);
                    int gapLen = stickPositions[i + 1] - stickPositions[i] - 1;
                    int localMax = 0;
                    if (gapLen > heightDiff)
                    {
                        int low = Math.Max(stickHeights[i + 1], stickHeights[i]) + 1;
                        int remainingGap = gapLen - heightDiff - 1;
                        localMax = low + remainingGap / 2;
                    }
                    else
                    {
                        localMax = Math.Min(stickHeights[i + 1], stickHeights[i]) + gapLen;
                    }

                    max = Math.Max(max, localMax);
                }
            }

            return max;
        }

        // 4 3 2 1
        public static int countStudents(List<int> height)
        {
            int result = 0;
            List<int> second = new List<int>();

            foreach (int a in height)
            {
                second.Add(a);
            }
            second.Sort();

            for (int j = 0; j < height.Count; j++)
            {
                if (height[j] != second[j])
                    result++;
            }


            return result;
        }
        // Complete the designerPdfViewer function below.
        static int designerPdfViewer(int[] h, string word)
        {
            int result = 0;
            int maxheight = 0;


            for (int i = 0; i < word.Length; i++)
            {
                int pos = ((int)word[i]);
                if (h[pos - 97] > maxheight)
                {
                    maxheight = h[pos - 97];
                }
            }
            result = maxheight * word.Length;

            return result;

        }

        static int factorial(int n)
        {

            int result = n;
            for (int i = n - 1; i >= 0; i--)
            {
                result = result * i;

            }
            return result;
        }
        static void factorial(int n,string s)
        {
        }
        static void factorial(string n, int s)
        {
        }
        static void staircase(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.Write(new String(' ', n - i));
                Console.WriteLine(new String('#', i));
            }

        }
        static void miniMaxSum(int[] arr)
        {
            long summax = 0, summin = 0;
            long totalsum = 0;
            for (int j = 0; j < arr.Length; j++)
            {
                totalsum = totalsum + arr[j];
            }
            summin = totalsum;
            for (int i = 0; i < arr.Length; i++)
            {
                if ((totalsum - arr[i]) < summin)
                {
                    summin = totalsum - arr[i];
                }
                if ((totalsum - arr[i]) > summax)
                {
                    summax = totalsum - arr[i];
                }
            }
            Console.WriteLine(summin + " " + summax);
        }
        static void plusMinus(int[] arr)
        {
            decimal positive = 0, negative = 0, zero = 0;
            decimal countp = 0, countn = 0, countz = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                { countn++; }
                else if (arr[i] > 0)
                { countp++; }
                else if (arr[i] == 0)
                { countz++; }

            }
            //positive = Decimal.Divide(Convert.ToDecimal(countp), Convert.ToDecimal(arr.Length));
            positive = countp / arr.Length;
            negative = countn / arr.Length;
            zero = countz / arr.Length;
            // Decimal.Round((decimal)positive, 5);
            Console.WriteLine(string.Format("{0:N6}", positive));
            Console.WriteLine(string.Format("{0:N6}", negative));
            Console.WriteLine(string.Format("{0:N6}", zero));
        }
    }
}
