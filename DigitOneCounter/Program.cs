using System;
using System.Text.RegularExpressions;

namespace DigitOneCounter
{
    class Program
    {

        public static void Main(string[] args)
        {
            int value1, value2;
            bool menu = true;
            do
            {
                Print("Bienvenido al programa contador de dígito 1", 'l');
                Print("Ingrese el valor inicial: ");
                value1 = ReadValue();
                Print("Ingrese el valor final: ");
                value2 = ReadValue();

                int digitCount = CountOne(value1, value2);
              
                Print("El dígito 1 ha aparecido: ");
                switch (digitCount)
                {
                    case 1:
                        Print("1 vez", 'l');
                        break;

                    default:
                        Print($"{digitCount} veces", 'l');
                        break;
                }

                Print("Quieres repetir las opciones? ( y / n)", 'l');

                if (Console.ReadLine().ToString() != "y")
                {
                    menu = false;
                }
                Console.Clear();

            } while (menu);
        }

        static void Print(string arg, char line = 'n')
        {
            if (line == 'l')
                Console.WriteLine(arg);
            else
                Console.Write(arg);
        }

        private static int ReadValue()
        {
            string input;
            int val;
            while (true)
            {
                input = Console.ReadLine();

                if (Regex.IsMatch(input, @"^-?\d*\.{0,1}\d+$"))
                {
                    int.TryParse(input, out val);
                    break;
                }
                Print($"{input}, no es un valor entero, favor digitar un valor entero", 'l');
            }

            return val;
        }
        static int CountOne(int value1, int value2)
        {
            int digitCount = 0, NumbersDigitLength;
            string NumbersDigit = string.Empty;

            if (value1 < value2 || value1 == value2)
            {
                for (; value1 <= value2; value1++)
                {
                    NumbersDigit += value1.ToString();
                }

                NumbersDigitLength = NumbersDigit.Length;
                digitCount = NumbersDigitLength - NumbersDigit.Replace("1", string.Empty).Length;
            }
            else
            {
                Print("el valor inicial debe ser menor al valor final");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return digitCount;
        }
    }
}
