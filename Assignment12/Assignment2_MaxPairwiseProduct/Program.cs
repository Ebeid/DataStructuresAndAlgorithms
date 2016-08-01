using System;

namespace Assignment2_MaxPairwiseProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg1 = Console.ReadLine();
            int n = 0;
            if (int.TryParse(arg1, out n))
                n = int.Parse(arg1);

            string arg2 = Console.ReadLine();
            Double[] nums = null;
            if ((!string.IsNullOrEmpty(arg2)) && (null != arg2.Split(" ".ToCharArray())))
            {
                int temp = arg2.Split(" ".ToCharArray()).Length;
                nums = new Double[temp];
                int i = 0;
                foreach (string str in arg2.Split(" ".ToCharArray()))
                {
                    nums[i] = Double.Parse(str);
                    i++;
                }
            }
            if ((n == 2) && (nums[0] != 0) && (nums[1] != 0))
            {
                Console.WriteLine(nums[0] * nums[1]);
                return;
            }
            Double Maximum = 0;
            int iM = 0;
            Double secondMaximum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (Maximum < nums[i])
                {
                    Maximum = nums[i];
                    iM = i;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if ((i != iM)&& (secondMaximum < nums[i]))
                {
                    secondMaximum = nums[i];
                }
            }
            //Console.WriteLine(Maximum);
            //Console.WriteLine(secondMaximum);
            Console.WriteLine(Maximum * secondMaximum);
            //Console.ReadLine();
        }
    }
}
