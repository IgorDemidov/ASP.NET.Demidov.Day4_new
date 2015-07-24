using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray.Task1.Library
{
    internal interface IRowComparer
    {
        int Compare(int[] first, int[] second, IKeyCalculator keyCalc);
    }
}
