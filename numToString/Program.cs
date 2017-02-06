using System;

namespace numToString
{
    class driver
    {
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