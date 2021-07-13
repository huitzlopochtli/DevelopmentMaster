using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Immutables
{
    class Program
    {
        static int matrixElementsSum(int[][] matrix)
        {
            int total = 0;

            int[] banned = new int[6];

            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                        banned[j] = 1;
                    else if (banned[j] != 1)
                        total += matrix[i][j];
                }

            return total;
        }

        static string reverseInParentheses(string inputString)
        {
            var arr = inputString.ToArray();
            Stack<int> stack = new Stack<int>();


            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '(')
                    stack.Push(i);

                else if (arr[i] == ')')
                {
                    reverse(arr, stack.Pop(), i);
                }
            }


            inputString = "";

            Console.WriteLine(inputString);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].ToString() != "(" && arr[i].ToString() != ")")
                    inputString += arr[i].ToString();
            }
            Console.WriteLine(inputString);

            return inputString;
        }

        static void reverse(char[] str, int startIndex, int endIndex)
        {
            int n = (startIndex + endIndex) / 2;
            for (; startIndex <= n; startIndex++, endIndex--)
            {
                char temp = str[startIndex];
                str[startIndex] = str[endIndex];
                str[endIndex] = temp;
            }
        }



        static bool isLucky()
        {
            string str = "1230";
            int len = str.Length - 1;

            int left = 0, right = 0;

            for (int i = 0; i <= len / 2; i++)
            {
                left += str[i] - '0';
                right += str[len - i] - '0';
            }

            return left == right;

        }





        static void Main()
        {
            int[][] m = new int[3][];
            m[0] = new int[4];
            m[1] = new int[4];
            m[2] = new int[4];


            reverseInParentheses("(bar)");
        }

    }
}
