using System;
using System.Collections.Generic;

namespace moneyToChange
{
    /**
    console application that takes a given double to two digits in the form of the moneyAmount variable (represents a money value such as £23.74P)
        the moneyAmount variable is then transformed into the amount of change you will get from that number e.g.(£21.50 would give 1:£20 note, 1:£1 coin and 1:50p coin)
        Driver class creates a dictionary with the values of money and what they are worth in a (key,value pair),
        then uses the dictionary to work out what change is needed with the changeDue method and finally prints the change
        that would be given by using the printDictonary method.
        */
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