using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray.Task1.Library
{
    public static class Sorter
    {
        public static void SortAscending(int[][] jaggedArray, IKeyCalculator keyCalc)
        {
            Sort(jaggedArray, new AscendingComparer(), keyCalc);
        }

        public static void SortDescending(int[][] jaggedArray, IKeyCalculator keyCalc)
        {
            Sort(jaggedArray, new DescendingComparer(), keyCalc);
        }

        private static void Sort(int[][] jaggedArray, IRowComparer comparer, IKeyCalculator keyCalc)
        {
            if (jaggedArray == null)
            {
                throw new ArgumentNullException("jaggedArray");
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                for (int j = 0; j < jaggedArray.Length - 1 - i; j++)
                {
                    if (comparer.Compare(jaggedArray[j], jaggedArray[j + 1], keyCalc) == 1)
                    {
                        Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                    }
                }
            }  
                 
        }

        private static void Swap(ref int[] first, ref int[] second)
        {
            int[] temp = first;
            first = second;
            second = temp;
        }
    }
}
