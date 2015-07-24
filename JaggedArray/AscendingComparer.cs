using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray.Task1.Library
{
    internal class AscendingComparer: IRowComparer 
    {
        public int Compare(int[] first, int[] second, IKeyCalculator keyCalc)
        {
            if ((first == second) || ((first.Length == 0) && (second.Length == 0)))
                return 0;
            if ((first == null) || (first.Length == 0))
                return -1;
            if ((second == null) || (second.Length == 0))
                return 1;

            int firstKey = keyCalc.GetKey(first);
            int secondKey = keyCalc.GetKey(second);

            if (firstKey > secondKey)
            {
                return 1;
            }
            else if (firstKey < secondKey)
            {
                return -1;
            }
            else return 0;
        }
    }
}
