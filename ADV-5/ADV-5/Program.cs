using System;
using System.IO;

namespace ADV_5
{
    internal class Program
    {
        static readonly string textFile = @"C:\Users\Nikita.Ulianov\Downloads\archive\test.txt";
        static readonly string resultFile = @"C:\Users\Nikita.Ulianov\Downloads\archive\Tesult.txt";
        static void Main(string[] args)
        {
            int[] counts = new int[100];

            if (File.Exists(textFile))
            {
                using (StreamReader file = new StreamReader(textFile))
                {
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        //string[] values = ln.Split(',');
                        int value = int.Parse(ln);//values[1]);

                        counts[value]++;
                    }

                    file.Close();
                }

                int[] starts = new int[counts.Length];
                int[] used = new int[counts.Length];
                for (int number = 0, position = 0; number < counts.Length; number++)
                {
                    starts[number] = position;
                    position += counts[number];
                }

                using (StreamReader file = new StreamReader(textFile))
                {
                    using (FileStream fs = File.Create(resultFile))
                    {
                        string ln;
                        while ((ln = file.ReadLine()) != null)
                        {
                            //string[] values = ln.Split(',');
                            int value = int.Parse(ln);//values[1]);

                            byte[] thing = new byte[] { (byte)value };

                            fs.SetLength(counts.Length);

                            fs.Position = starts[value] + used[value];
                            fs.Write(thing, 0, 1);
                            used[value]++;
                        }

                        file.Close();
                    }
                }
            }
        }
    }
}