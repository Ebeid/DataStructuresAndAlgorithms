using System;

namespace Assignment1_AplusB
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result=0;
            int temp;
            foreach (string num in input.Split(" ".ToCharArray()))  
            {
                if (int.TryParse(num, out temp))
                {
                    result += temp;
                }                        
            }
            Console.WriteLine(result.ToString());
        }
    }
}
