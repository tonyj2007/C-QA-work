using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToBinary
{
    class Program
    {
        /**
        takes user input and changes the number into the binary representation using modules to figure out if the bit is 1 or 0 
            based on the results of the modules equation 
            */
        static void Main(string[] args)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            int modules;
            String binary = "";
            while (input >= 1)
            {
                modules = input % 2;
                binary = modules + binary;
                input /= 2;
            }
            Console.Write(binary);
            Console.ReadLine();
        }
    }
}
