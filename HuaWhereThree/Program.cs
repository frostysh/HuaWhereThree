using HuaWhereThree.Static;

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

            foreach(int number in setNumbers)
            {
                
                if ((counter != 0) && (counter % 15 == 0))
                {
                    Console.WriteLine("{0, 4}|", number);
                }
                else
                {
                    Console.Write("{0, 4}|", number);
                }

                counter = counter + 1;
            }

            IEnumerable<int> positiveQuerry = setNumbers.HuaWhere(IsPositive);

            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");

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
                    Console.WriteLine("{0, 4}|", number);
                }
                else
                {
                    Console.Write("{0, 4}|", number);
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
