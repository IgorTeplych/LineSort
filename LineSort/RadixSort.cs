using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSort
{
    internal class RadixSort
    {
        public long[] Sort(long[] mass, long maxValue)
        {
            long div = 1;
            while (div <= maxValue)
            {
                long[] idxMass = new long[10];

                for (long i = 0; i < mass.Length; i++)
                {
                    idxMass[(mass[i] / div) % 10]++;
                }

                for (long i = 1; i < idxMass.Length; i++)
                {
                    idxMass[i] += idxMass[i - 1];
                }

                long[] sortMass = new long[mass.Length];
                for (long i = mass.Length - 1; i >= 0; i--)
                {
                    sortMass[--idxMass[(mass[i] / div) % 10]] = mass[i];
                }

                div *= 10;
                mass = sortMass;
            }
            return mass;
        }
        public UInt16[] Sort(UInt16[] mass, UInt16 maxValue)
        {
            long div = 1;
            while (div <= maxValue)
            {
                long[] idxMass = new long[10];

                for (long i = 0; i < mass.Length; i++)
                {
                    idxMass[(mass[i] / div) % 10]++;
                }

                for (long i = 1; i < idxMass.Length; i++)
                {
                    idxMass[i] += idxMass[i - 1];
                }

                UInt16[] sortMass = new UInt16[mass.Length];
                for (long i = mass.Length - 1; i >= 0; i--)
                {
                    sortMass[--idxMass[(mass[i] / div) % 10]] = mass[i];
                }

                div *= 10;
                mass = sortMass;
            }
            return mass;
        }
    }
}
