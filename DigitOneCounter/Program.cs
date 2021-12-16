using System;

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
                int.TryParse(Console.ReadLine(), out value1);

                Print("Ingrese el valor final: ");
                int.TryParse(Console.ReadLine(), out value2);

                int digitCount = CountOne(value1, value2, 0);
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
        static int CountOne(int value1, int value2, int digitCount)
        {
            string NumbersDigit = string.Empty;
            int NumbersDigitLength;

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
                Console.Error.WriteLine("el valor inicial debe ser menor al valor final");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return digitCount;
        }
    }
}
