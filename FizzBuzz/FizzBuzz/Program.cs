using System;

namespace FizzBuzz
{
    /**
    prints all numbers from 1 to 100 and then prints Fizz instead of multiples of 3, Buzz instead of multiples of 5 and FizzBuzz instead of multiples of 15 
        worked out using modules
        */
    class Program
    {
        static void Main(string[] args)
        {
            Program fizz = new Program();
            fizz.fizzBuzz();
        }
        protected void fizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Console.WriteLine("Buzz");
                else
                    Console.WriteLine(i);
            }
            Console.Read();
        }
    }
}
