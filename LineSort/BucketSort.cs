using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSort
{
    internal class BucketSort
    {
        public long[] Sort(long[] mass, long maxVal, int bucketNumber)
        {
            long[][] buckets = new long[bucketNumber][];

            long count = 0;
            while (count < mass.Length)
            {
                int currentBucket = (int)(((long)mass[count] * (long)bucketNumber) / (long)(maxVal + 1));
                InsertInBucket(ref buckets[currentBucket], mass[count]);
                count++;
            }
            return MergeMass(ref buckets, mass.Length);
        }

        public UInt16[] Sort(UInt16[] mass, long maxVal, int bucketNumber)
        {
            UInt16[][] buckets = new UInt16[bucketNumber][];

            long count = 0;
            while (count < mass.Length)
            {
                int currentBucket = (int)(((long)mass[count] * (long)bucketNumber) / (long)(maxVal + 1));
                InsertInBucket(ref buckets[currentBucket], mass[count]);
                count++;
            }
            return MergeMass(ref buckets, mass.Length);
        }

        void InsertInBucket(ref long[] bucket, long number)
        {
            if (bucket == null)
            {
                bucket = new long[] { number };
                return;
            }

            long[] newBucket = new long[bucket.Length + 1];
            long count = 0;
            while (count < bucket.Length && bucket[count] < number)
            {
                newBucket[count] = bucket[count];
                count++;
            }
            newBucket[count++] = number;
            while (count < newBucket.Length)
            {
                newBucket[count] = bucket[count - 1];
                count++;
            }
            bucket = newBucket;
        }
        void InsertInBucket(ref UInt16[] bucket, UInt16 number)
        {
            if (bucket == null)
            {
                bucket = new UInt16[] { number };
                return;
            }

            UInt16[] newBucket = new UInt16[bucket.Length + 1];
            long count = 0;
            while (count < bucket.Length && bucket[count] < number)
            {
                newBucket[count] = bucket[count];
                count++;
            }
            newBucket[count++] = number;
            while (count < newBucket.Length)
            {
                newBucket[count] = bucket[count - 1];
                count++;
            }
            bucket = newBucket;
        }
        long[] MergeMass(ref long[][] buckets, long size)
        {
            long[] sortMass = new long[size];

            long countBig = 0;
            long count = 0;
            int countElements = 0;
            while (countBig < buckets.Length)
            {
                if (buckets[countBig] != null)
                {
                    countElements = 0;
                    while (countElements < buckets[countBig].Length)
                    {
                        sortMass[count++] = buckets[countBig][countElements++];
                    }
                }
                countBig++;
            }
            return sortMass;
        }

        UInt16[] MergeMass(ref UInt16[][] buckets, long size)
        {
            var sortMass = new UInt16[size];

            long countBig = 0;
            long count = 0;
            int countElements = 0;
            while (countBig < buckets.Length)
            {
                if (buckets[countBig] != null)
                {
                    countElements = 0;
                    while (countElements < buckets[countBig].Length)
                    {
                        sortMass[count++] = buckets[countBig][countElements++];
                    }
                }
                countBig++;
            }
            return sortMass;
        }
    }
}
