using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JaggedArray.Task1.Library;


namespace ConsoleApplication1
{
    class Program
    {
        static void PrintToConsole(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------");
        }

        static int[][] CreateRandomJaggedArray(int minRowsCount, int maxRowsCount, int minColsCount, int maxColsCount, int minValue, int maxValue)
        {
            Random random = new Random();
            int rowsCount = random.Next(minRowsCount, maxRowsCount);

            int[][] jaggedArray = new int[rowsCount][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                int colsCount = random.Next(minColsCount, maxColsCount);
                jaggedArray[i] = new int[colsCount];

                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    int value = random.Next(minValue, maxValue);
                    jaggedArray[i][j] = value;
                    System.Threading.Thread.Sleep(1);
                }
            }
            return jaggedArray;
        }

        static void Main(string[] args)
        {
            int[][] jaggedArray = CreateRandomJaggedArray(5, 6, 0, 6, -10, 10);
            PrintToConsole(jaggedArray);
           
            Sorter.SortAscending(jaggedArray, new ValuesSumKey());
            PrintToConsole(jaggedArray);

            Sorter.SortDescending(jaggedArray, new ValuesSumKey());
            PrintToConsole(jaggedArray);

            Sorter.SortAscending(jaggedArray, new MaxAbsValueKey());
            PrintToConsole(jaggedArray);

            Sorter.SortDescending(jaggedArray, new MaxAbsValueKey());
            PrintToConsole(jaggedArray);

            Console.ReadLine();
        }
    }

    class ValuesSumKey : IKeyCalculator
    {
        public int GetKey(int[] array)
        {
            int ValuesSum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                ValuesSum += array[i];
            }
            return ValuesSum;
        }
    }

    class MaxAbsValueKey : IKeyCalculator
    {
        public int GetKey(int[] array)
        {
            int maxAbsValue = Math.Abs(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                if ( maxAbsValue < Math.Abs(array[i]) )
                {
                    maxAbsValue = Math.Abs(array[i]);
                }
            }
            return maxAbsValue;
        }
    }

    class MaxValueKey : IKeyCalculator
    {
        public int GetKey(int[] array)
        {
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }
            return maxValue;
        }
    }

    class MinValueKey : IKeyCalculator
    {
        public int GetKey(int[] array)
        {
            int minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }
            return minValue;
        }
    }



}
