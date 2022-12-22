using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    internal class CountingSort
    {
        public long[] Sort(long[] mass, long maxValue)
        {
            long[] idxMass = new long[maxValue + 1];

            for (long i = 0; i < mass.Length; i++)
                idxMass[mass[i]]++;

            for (long i = 1; i < idxMass.Length; i++)
                idxMass[i] += idxMass[i - 1];

            long[] sortMass = new long[mass.Length];
            for (long i = mass.Length - 1; i >= 0; i--)
                sortMass[--idxMass[mass[i]]] = mass[i];

            return sortMass;
        }

        public UInt16[] Sort(UInt16[] mass, UInt16 maxValue)
        {
            int[] idxMass = new int[maxValue + 1];

            for (int i = 0; i < mass.Length; i++)
                idxMass[mass[i]]++;

            for (int i = 1; i < idxMass.Length; i++)
                idxMass[i] += idxMass[i - 1];

            UInt16[] sortMass = new UInt16[mass.Length];
            for (int i = mass.Length - 1; i >= 0; i--)
                sortMass[--idxMass[mass[i]]] = mass[i];

            return sortMass;
        }

    }
}
