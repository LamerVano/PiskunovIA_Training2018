using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input num: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int[] facktorial = CalcFactorial(n);
            timer.Stop();
            Console.Write("Factorial: ");
            foreach (int i in facktorial)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("Running time in milliseconds : " + timer.ElapsedMilliseconds);
            Console.Read();
        }
        static int[] CalcFactorial(int n)
        {
            int[] facktorial = new int[1] { 1 };
            for (int i = 1; i <= n; i++)
            {
                facktorial = CalcMultiply(facktorial, ConvertToArray(i));
            }
            return Clear(facktorial);
        }

        private static int[] Clear(int[] facktorial)
        {
            List<int> now = new List<int>();
            int len = facktorial.Length;
            for (int i = 0; i < len; i++)
            {
                if (now.Count == 0 & facktorial[i] == 0)
                {
                    continue;
                }
                else
                {
                    now.Add(facktorial[i]);
                }
            }
            return now.ToArray();
        }

        static int[] ConvertToArray(int num)
        {
            List<int> ret = new List<int>();
            string str = "" + num;
            for (int i = 0; i < str.Length; i++)
            {
                ret.Add(str[i] - 48);
            }
            return ret.ToArray();
        }
        static int[] CalcMultiply(int[] num1, int[] num2)
        {
            int lenght1 = num1.Length, lenght2 = num2.Length;
            int[][] sums = new int[lenght2][];
            for (int i = 0; i < lenght2; i++)
            {
                sums[i] = new int[lenght1];
                for (int j = 0; j < lenght1; j++)
                {
                    sums[i][j] = num2[i] * num1[j];
                }
            }
            int[] resultNum = new int[lenght1 + lenght2];
            resultNum[0] = 0;
            for (int i = 0; i < lenght2; i++)
            {
                for (int j = 0; j < lenght1; j++)
                {
                    resultNum[i + j + 1] += sums[i][j];
                }
            }
            while (!IsCorrect(resultNum))
            {
                for (int i = 0; i < resultNum.Length - 1; i++)
                {
                    resultNum[i] += resultNum[i + 1] / 10;
                    resultNum[i + 1] -= (resultNum[i + 1] / 10) * 10;
                }
            }
            return resultNum;
        }

        private static bool IsCorrect(int[] ret)
        {
            foreach (int i in ret)
            {
                if (i / 10 != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
