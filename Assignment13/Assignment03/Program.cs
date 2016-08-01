using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem 1 - Binary Search
            //Problem1();
            Problem2();
            Console.ReadLine();
        }

        private static void Problem1()
        {
            int searchSpaceCapacity;
            int keywordsCapacity;

            string line1 = Console.ReadLine();
            string[] line1Parts = line1.Split(' ');
            searchSpaceCapacity = Convert.ToInt32(line1Parts[0]);
            double[] values = new double[searchSpaceCapacity];
            List<double> v = new List<double>();
            for (int i = 1; i <= searchSpaceCapacity; i++)
            {
                values[i - 1] = Convert.ToDouble(line1Parts[i]);
                v.Add(Convert.ToDouble(line1Parts[i]));
            }

            string line2 = Console.ReadLine();
            string[] line2Parts = line2.Split(' ');
            keywordsCapacity = Convert.ToInt32(line2Parts[0]);
            double[] keys = new double[keywordsCapacity];
            for (int i = 1; i <= keywordsCapacity; i++)
                keys[i - 1] = Convert.ToDouble(line2Parts[i]);
            int result;
            foreach (double key in keys)
            {
                //binarySearch(key, values);
                result = v.BinarySearch(key);
                if (result >= 0)
                    Console.Write(result);
                else
                    Console.Write("-1");
                Console.Write(" ");
            }
        }

        private static void Problem2()
        {

            int n = Convert.ToInt32(Console.ReadLine());

            string line2 = Console.ReadLine();
            string[] line2Parts = line2.Split(' ');
            Dictionary<int, int> values = new Dictionary<int, int>();

            for (int i = 0; i < line2Parts.Length; i++)
            {
                if (values.ContainsKey(int.Parse(line2Parts[i])))
                {
                    values[int.Parse(line2Parts[i])]++;
                    if (values[int.Parse(line2Parts[i])] > (line2Parts.Length / 2))
                    {
                        Console.WriteLine(1);
                        return;
                    }
                }
                else
                    values.Add(int.Parse(line2Parts[i]), 1);
            }
            Console.WriteLine(0);
        }
    }
}
