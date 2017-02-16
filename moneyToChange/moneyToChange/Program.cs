using System;
using System.Collections.Generic;

namespace moneyToChange
{
    class Driver
    {
        static void Main(string[] args)
        {
            money mon = new money();
            mon.createDictionary();
            mon.changeDue();
            mon.printDictonary();
            Console.ReadLine();
        }
    }
    class money
    {
        double moneyAmount = 23.74;
        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        string[,] moneyNames = new string[,] { { "Twenty pound", "20"}, { "Ten pound","10" }, { "Five pound","5" }, { "Two pound","2" }, { "One pound","1" },
            { "Fifty pence","0.50" }, { "Twenty pence","0.20" }, { "Ten pence","0.10" }, { "Five pence","0.05" }, { "Two pence" ,"0.02" }, { "One pence","0.01" } };

        public void createDictionary()
        {
            for (int x = 0; x < moneyNames.Length / 2; x++)
            {
                dictionary.Add(moneyNames[x, 0], 0);
            }
        }

        public void printDictonary()
        {
            foreach (KeyValuePair<string, int> item in dictionary)
            {
                if (item.Value != 0)
                    Console.WriteLine(item.Key + ": " + item.Value);
            }
        }

        public void changeDue()
        {
            for (int i = 0; i < moneyNames.Length / 2; i++)
            {
                if (moneyAmount - Convert.ToDouble(moneyNames[i, 1]) >= 0.00)
                {
                    dictionary[moneyNames[i, 0]]++;
                    moneyAmount -= Convert.ToDouble(moneyNames[i, 1]);
                    changeDue();
                }
            }
        }
    }
}