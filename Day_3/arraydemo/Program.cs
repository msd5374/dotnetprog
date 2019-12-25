using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arraydemo
{
    class Program
    {
        static void Main1()
        {
            int[] arr = new int[3];


            for(int i=0;i<arr.Length;i++)
            {
                Console.WriteLine("enter value for subscript {0}", i);
                //arr[i] = int.Parse(Console.ReadLine());
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine();

            foreach(int x in arr)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();

        }

        static void Main2()
        {
            int[,] arr = new int[3, 2];
            //arr[0,0] arr[0,1] arr[0,2]
            //arr[1,0].....arr[1,2]

            //    arr[4,2]
            //arr.Rank
            //arr.GetLowerBound(0)
            //arr.GetUpperBound(0)

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("enter value for subscript {0},{1} : ", i, j);
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();
            //foreach (int x in arr)
            //{

            //}

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is : {2}", i, j, arr[i, j]);
                }
            }
            Console.ReadLine();
        }

        static void Main3()
        {
            //jagged array:array inside array i.e. array of array
            int[][] arr = new int[5][];

            arr[0] = new int[3];
            arr[1] = new int[5];
            arr[2] = new int[2];
            arr[3] = new int[8];
            arr[4] = new int[10];

            arr[0] = new int[] { 3, 5, 7 };
            arr[1] = new int[] { 1, 0, 2, 4, 6 };
            arr[2] = new int[] { 1, 6 };
            arr[3] = new int[] { 1, 0, 2, 4, 6, 45, 67, 78 };
            arr[4] = new int[] { 1, 0, 2, 4, 6, 34, 54, 67, 87, 78 };

            int[][] arr2 = new int[][]
            {
                new int[] { 3, 5, 7 },
                new int[] { 1, 0, 2, 4, 6 },
                new int[] { 1, 6 },
                new int[] { 1, 0, 2, 4, 6, 45, 67, 78 }
            };

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.Write("enter value for subscript {0},{1} : ", i, j);
                    arr2[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is {2}  ", i, j, arr2[i][j]);
                }
            }
            Console.ReadLine();
        }
    }
}
