using System;

namespace numToString
{
    class driver
    {
        /**
        program uses the variable testNumber (changed with the program not user input) and turns the number into the 
            string representation e.g.(510 will be turned into five hundred ten)
            */
        static void Main(String[] args)
        {
            converter c = new converter();
            c.convert();
            Console.ReadLine();
        }
    }

    class converter
    {
        static int testNumber = 4520;
        static string number = testNumber.ToString();
        private static string[] ones = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
        "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
        private static string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        public void convert()
        {
            /**
            convert function used to change the numbers and figure out if the numbers are singles, tens, hundreds or thousand
            to avoid all zeros from being read a zero when it might be part of a bigger number e.g. 10 after the number 10 has been converted
            the number 1 from 10 is removed from the original testNumber and the following zero's up until another number/end of number are trimmed.
            */
            try
            {
                int temp = Convert.ToInt32(Convert.ToString(number));

                if (temp >= 0 && temp < 20)
                    Console.Write(ones[Convert.ToInt32(Convert.ToString(number))]);

                else if (temp >= 20 && temp < 100)
                {
                    Console.WriteLine(tens[Convert.ToInt32(Convert.ToString(number[0]))] + " ");
                    number = number.Remove(0, 1);
                    number = number.TrimStart('0');
                    convert();
                }
                else if (temp > 99 && temp < 1000)
                {
                    Console.Write(ones[Convert.ToInt32(Convert.ToString(number[0]))] + " hundred ");
                    number = number.Remove(0, 1);
                    number = number.TrimStart('0');
                    convert();
                }
                else
                {
                    Console.Write(ones[Convert.ToInt32(Convert.ToString(number[0]))] + " thousand ");
                    number = number.Remove(0, 1);
                    number = number.TrimStart('0');
                    convert();
                }
                Console.ReadLine();
            }
            catch (Exception) { }
        }
    }
}