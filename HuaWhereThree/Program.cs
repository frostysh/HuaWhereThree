﻿using HuaWhereThree.Static;

namespace HuaWhereThree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random pseudoRnd = new Random();

            Console.WriteLine("Ad");

            int[] setNumbers = new int[150];

            // TO FILL THE ARRAY.
            for (int index = 0; index < setNumbers.Length; index = index +1)
            {
                setNumbers[index] = pseudoRnd.Next(-1000, 1001);
            }

            // TO FORMAT CONSOLE OUTPUT.
            int counter = 1;

            Console.WriteLine("\nINITIAL COLLECTION: int[150] -- VIA foreach\n");

            foreach(int number in setNumbers)
            {
                
                if ((counter != 0) && (counter % 15 == 0))
                {
                    Console.WriteLine("{0, 5}|", number);
                }
                else
                {
                    Console.Write("{0, 5}|", number);
                }

                counter = counter + 1;
            }

            IEnumerable<int> positiveQuerry = setNumbers.HuaWhere(IsPositive);

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\nCREATING VARIABLE IEnumerable<int> positiveQuerry = setNumbers.HuaWhere(IsPositive),\n AND THEN CHANGE COLLECTION VIA foreach, TO MAKE ALL NUMBERS POSITIVE, AFTER THIS CREATE NEW LIST:\n List<int> numberList = positiveQuerry.ToList(), THEN MAKE DISPLAY THE LIST ON THE CONSOLE.\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

            // ACTUALLY CHANGE THE COLLECTION TO CONFIRM EXECUTION OF THE METHOD ONLY ON foreach-MECHANISM EXECUTION.
            for (int index = 0; index < setNumbers.Length; index = index + 1)
            {
                // MAKES ALL NUMBERS POSITIVE.
                setNumbers[index] = Math.Abs(setNumbers[index]);
            }

            // TO ACTUALLY PERFORM ITERATION.
            List<int> numberList = positiveQuerry.ToList();

            counter = 1;

            foreach (int number in numberList)
            {
                if ((counter != 0) && (counter % 15 == 0))
                {
                    Console.WriteLine("{0, 5}|", number);
                }
                else
                {
                    Console.Write("{0, 5}|", number);
                }

                counter = counter + 1;
            }
        }

        public static bool IsPositive(int number)
        {
            if (number < 0)
            {
                return false;
            }
            else if (number == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
