using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primeNumbers
{
    /**
    console application that is used to work out all the prime number between(2 and a number the user inputs)
        */
    class Program
    {
        static void Main(string[] args)
        {
            int userNum = Convert.ToInt32(Console.ReadLine());
            Prime prime = new Prime();
            prime.workOutPrime(userNum);
            Console.ReadLine();
        }
    }
    class Prime
    {
        public void workOutPrime(int a)
        {
            /**
            anything that modules with 2,3,5,7 or 11 is not a prime number
            */
            Console.Clear();
            int[] notPrime = new int[] { 2, 3, 5, 7, 11 };
            for (int i = 2; i <= a; i++)
            {
                {
                    if (notPrime.Contains(i))
                    {
                        Console.WriteLine(i);
                    }
                    else if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0 && i % 7 != 0 && i % 11 != 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}