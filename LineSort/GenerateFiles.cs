using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineSort
{
    public static class GenerateFiles
    {
        static string path = @"Numbers.bin";
        static string mainPath = Environment.CurrentDirectory + @"\Files\";
        static Random random = new Random();
        public static void GenerateBinFile(int size, int maxValue)
        {
            if (Directory.Exists(mainPath))
                Directory.Delete(mainPath, true);

            Directory.CreateDirectory(mainPath);

            using (BinaryWriter writer = new BinaryWriter(File.Open(mainPath + path, FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < size; i++)
                {
                    writer.Write(random.Next(0, maxValue + 1).ToString());
                }
            }
        }

        public static UInt16[] ReadFile(int size)
        {
            var mass = new UInt16[size];
            using (BinaryReader reader = new BinaryReader(File.Open(mainPath + path, FileMode.Open)))
            {
                for (int i = 0; i < size; i++)
                {
                    mass[i] = UInt16.Parse(reader.ReadString());
                }
            }
            return mass;
        }
    }
}
