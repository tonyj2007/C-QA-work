using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = Convert.ToInt32(Console.ReadLine());
            int modulas;
            String binary = "";
            while (input >= 1)
            {
                modulas = input % 2;
                binary = modulas + binary;
                input /= 2;
            }
            Console.Write(binary);
            Console.ReadLine();
        }
    }
}
