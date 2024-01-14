using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{
    internal class RangeOfArray
    {
        private readonly int min;
        private readonly int max;

        private int[] arr;

        public RangeOfArray(int min, int max)
        {
            if (min > max)
            {
                int tmp = min;
                min = max;
                max = tmp;
            }

            this.min = min;
            this.max = max;

            arr = new int[max - min + 1];
        }

        public int getMin()
        {
            return min;
        }
        public int getMax()
        {
            return max;
        }

        bool IsIndexOK(int index)
        {
            return index >= min && index <= max;
        }

        public int this[int index]
        {
            get
            {
                if (IsIndexOK(index))
                    return arr[max - index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (IsIndexOK(index))
                    arr[max - index] = value;
                else throw new IndexOutOfRangeException();
            }
        }
    }
}
