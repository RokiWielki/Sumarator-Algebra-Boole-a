using System;
using System.Collections.Generic;
using static System.Console;



namespace Sumarator
{
    public class Program
    {


        static void Main(string[] args)
        {
            ManualTest();
            Console.WriteLine();
            Console.WriteLine("Dowolny przycisk aby kontynuować...");
            Console.ReadKey();
            AllPossibilities();

        }
        
        private static void ManualTest()
        {
            DisplayFirst(1);
            string firstInput;
            while (true)
            {
                firstInput = ReadLine().Trim();
                if (firstInput.Length == 4)
                {
                    if (int.TryParse(firstInput, out _))
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(firstInput, Constants.BinaryStringValidate()))
                        {
                            break;
                        }
                    }
                }

                WriteLine("Wprowadzono błędne dane!");
                Write("Podaj pierwszą cyfrę (");
                Write("binarną, czterobitową");
                Write("): ");
            }

            DisplayFirst(2, firstInput);
            string secondInput;
            while (true)
            {
                secondInput = ReadLine().Trim();
                if (secondInput.Length == 4)
                {
                    if (int.TryParse(secondInput, out _))
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(secondInput, Constants.BinaryStringValidate()))
                        {
                            break;
                        }
                    }
                }
                WriteLine(firstInput + " + ");

                WriteLine("Wprowadzono błędne dane!");
                Write("Podaj drugą cyfrę (");
                Write("binarną, czterobitową");
                Write("): ");
            }
            

            int sum1 = Convert.ToInt32(firstInput, 2);
            int sum2 = Convert.ToInt32(secondInput, 2);
            string result = Convert.ToString(sum1 + sum2, 2).PadLeft(4, '0');

            if (result.Length == 4)
            {
                WriteLine(firstInput + " + " + secondInput + " = " + result);
            }
            else
            {
                Write(firstInput + " + " + secondInput + " = " + result.Remove(0, result.Length - 4));
                WriteLine(" [Overflow] => " + result);

            }

            WriteLine("Wynik w systemie decymalnym: " + (sum1 + sum2));
            
        }
        private static void DisplayFirst(int x, string firstBinary = null)
        {
            

            if (x == 1)
            {
                Write("Podaj pierwszą cyfrę: ");
            }
            else if (x == 2)
            {
                WriteLine(firstBinary + " + ");

                Write("Podaj drugą cyfrę: ");
            }
        }
        private static void AllPossibilities()
        {
            int parity = 0;
            int trials = 0;
            List<string> binary = Constants.BinaryInput();

            foreach (string variable in binary)
            {
                int baseOfSum = Convert.ToInt32(variable, 2);
                for (int i = 0; i < binary.Count; i++)
                {
                    
                    Write(variable);
                    
                    Write(" + " + binary[i] + " = ");
                    int targetOfSum = Convert.ToInt32(binary[i], 2);
                    string result = Convert.ToString(baseOfSum + targetOfSum, 2).PadLeft(4, '0');
                    if (result.Length > 4)
                    {
                        result = result.Remove(0, result.Length - 4);
                        Write(result);
                        WriteLine(" [Overflow]");
                    }
                    else
                    {
                        WriteLine(result);
                    }

                    trials++;
                }
                parity++;
            }

            if (trials == 1)
                WriteLine($"Wykonano: {trials} raz!");
            else
                WriteLine($"Wykonano: {trials} razy!");
        }

    }
   
    public static class Constants
    {
        public static List<string> BinaryInput()
        {
            return new List<string>()
            {
                "0000",
                "0001",
                "0010",
                "0011",
                "0100",
                "0101",
                "0110",
                "0111",
                "1000",
                "1001",
                "1010",
                "1011",
                "1100",
                "1101",
                "1110",
                "1111"
            };
        }
        public static string BinaryStringValidate()
        {
            return "[2-9]+";
        }
    }
}



