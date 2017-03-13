using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sum_of_digits_in_number
{
    /**
    program uses testNumber variable as the input (not user input) and sums the value of each of the digits within the number
        E.G 923 would be (9+2+3 = 14)
        */
    class Program
    {
        static void Main(string[] args)
        {
            int testNumber = 917;
            int sumOfInput = 0;
            int lengthOfTestNumber = testNumber.ToString().Length;
            string testNum = testNumber.ToString();
            char[] arrayOfNumbersToAdd = testNum.ToCharArray();
            for (int i = 0; i < lengthOfTestNumber; i++)
            {
                int temp = Convert.ToInt32(arrayOfNumbersToAdd[i].ToString());
                sumOfInput = sumOfInput + temp;
            }
            Console.Write(sumOfInput);
            Console.Read();
        }
    }
}
