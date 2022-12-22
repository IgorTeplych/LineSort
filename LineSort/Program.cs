using LineSort;
using SimpleSort;
using System.Diagnostics;

public static class Program
{
    public static void Main()
    {
        string report = "";
        List<string> reports = new List<string>();
        int size = (int)Math.Pow(10, 8);

        Stopwatch sw = new Stopwatch();
        GenerateFiles.GenerateBinFile(size, 65535);
        UInt16[] mass = GenerateFiles.ReadFile(size);
        CountingSort countingSort = new CountingSort();
        sw.Start();
        var countingSortMass = countingSort.Sort(mass, 65535);
        sw.Stop();
        report += FormatTimer(sw.Elapsed.TotalMilliseconds, 32) + $"||";

        sw = new Stopwatch();
        GenerateFiles.GenerateBinFile(size, 65535);
        mass = GenerateFiles.ReadFile(size);
        BucketSort bucketSort = new BucketSort();
        sw.Start();
        var bucketSortMass = bucketSort.Sort(mass, 65535, 50000);
        sw.Stop();
        report += FormatTimer(sw.Elapsed.TotalMilliseconds, 32) + $"||";

        sw = new Stopwatch();
        GenerateFiles.GenerateBinFile(size, 65535);
        mass = GenerateFiles.ReadFile(size);
        sw.Start();
        bucketSortMass = bucketSort.Sort(mass, 65535, 100000);
        sw.Stop();
        report += FormatTimer(sw.Elapsed.TotalMilliseconds, 32) + $"||";

        sw = new Stopwatch();
        GenerateFiles.GenerateBinFile(size, 65535);
        mass = GenerateFiles.ReadFile(size);
        RadixSort radixSort = new RadixSort();
        sw.Start();
        var radixSortMass = radixSort.Sort(mass, 65535);
        sw.Stop();
        report += FormatTimer(sw.Elapsed.TotalMilliseconds, 32) + $"||";
        reports.Add(report);

        int temp = 32;
        string hat =
            "Size".PadRight(12) +
            "||" + "Counting sort, ms".PadLeft(temp) +
            "||" + "Bucket sort (50000 buckets), ms".PadLeft(temp) +
            "||" + "Bucket sort (100000 buckets), ms".PadLeft(temp) +
            "||" + "Radix sort, ms".PadLeft(temp) +
            "||";
        Console.WriteLine(hat);

        Console.WriteLine("-".PadRight(hat.Length, '-'));

        Console.WriteLine(Format(size) + "||" + reports[0]);
        Console.WriteLine();
    }

    static void CommonTests()
    {
        CreateMassForTests();
        List<string> reports = new List<string>();

        int count = 0;
        string report = "";
        while (count < massForTests.Length)
        {
            report = "";

            Stopwatch sw = new Stopwatch();
            CountingSort countingSort = new CountingSort();
            sw.Start();
            countingSort.Sort(GetCopyMass(count), 999);
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"||";

            sw = new Stopwatch();
            BucketSort bucketSort = new BucketSort();
            sw.Start();
            bucketSort.Sort(GetCopyMass(count), 999, 100);
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"||";

            sw = new Stopwatch();
            bucketSort = new BucketSort();
            sw.Start();
            bucketSort.Sort(GetCopyMass(count), 999, 200);
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"||";

            sw = new Stopwatch();
            bucketSort = new BucketSort();
            sw.Start();
            bucketSort.Sort(GetCopyMass(count), 999, 400);
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"||";

            sw = new Stopwatch();
            RadixSort radixSort = new RadixSort();
            sw.Start();
            radixSort.Sort(GetCopyMass(count), 999);
            sw.Stop();
            report += FormatTimer(sw.Elapsed.TotalMilliseconds) + $"||";

            reports.Add(report);
            count++;
        }

        int temp = 30;
        string hat =
            "Size".PadRight(12) +
            "||" + "Counting sort, ms".PadLeft(temp) +
            "||" + "Bucket sort (100 buckets), ms".PadLeft(temp) +
            "||" + "Bucket sort (200 buckets), ms".PadLeft(temp) +
            "||" + "Bucket sort (400 buckets), ms".PadLeft(temp) +
            "||" + "Radix sort, ms".PadLeft(temp) +
            "||";
        Console.WriteLine(hat);

        Console.WriteLine("-".PadRight(hat.Length, '-'));
        for (int i = 0; i < reports.Count; i++)
        {
            Console.WriteLine(Format(sizes[i]) + "||" + reports[i]);
        }
        Console.WriteLine();
    }


    static long[][] massForTests;
    static long[] sizes;
    static long[] GetCopyMass(int index)
    {
        var mass = massForTests[index];
        long[] copyMass = new long[mass.Length];
        mass.CopyTo(copyMass, 0);
        return copyMass;
    }
    static void CreateMassForTests()
    {
        sizes = new long[] { (long)Math.Pow(10, 2), (long)Math.Pow(10, 3), (long)Math.Pow(10, 4), (long)Math.Pow(10, 5), (long)Math.Pow(10, 6) };
        massForTests = new long[sizes.Length][];

        for (int i = 0; i < sizes.Length; i++)
        {
            massForTests[i] = GetMass(sizes[i], 999);
        }
    }
    static Random random = new Random();
    static long[] GetMass(long size, int maxValue)
    {
        long[] mass = new long[size];
        long count = 0;

        while (count++ < size - 1)
        {
            mass[count] = random.Next(0, maxValue + 1);
        }
        return mass;
    }

    static string Format(long l)
    {
        return l.ToString().PadLeft(12);
    }
    static string Format(string s)
    {
        return s.PadLeft(12);
    }
    static string FormatTimer(double d, int insert = 30)
    {
        if (d > 100)
        {
            return Math.Round(d, 0).ToString().PadLeft(insert);
        }
        else
        {
            return Math.Round(d, 2).ToString().PadLeft(insert);
        }
    }
}
