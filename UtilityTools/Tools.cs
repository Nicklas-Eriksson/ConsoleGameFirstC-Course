using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.UtilityTools
{
    static public class Tools
    {
        //Text color
        static public void Red(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input);
            Console.ResetColor();
        }
        static public void RedLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        static public void Yellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(input);
            Console.ResetColor();
        }
        static public void YellowLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        static public void Green(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(input);
            Console.ResetColor();
        }
        static public void GreenLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        static public void Blue(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(input);
            Console.ResetColor();
        }
        static public void BlueLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(input);
            Console.ResetColor();
        }
        //Text color end

        //Convertions
        static public int ConvToInt32(string input)
        {
            bool success;
            int nr;
            do
            {
                success = Int32.TryParse(input.Trim(), out nr);
                if (success)
                {
                    break;
                }
                Error();
                Option();
                input = Console.ReadLine();
            } while (!success);
            return nr;
        }
        
        
        //Often used
        static public void Error()
        {
            Tools.RedLine("Wrong input, try again");
        }
        static public void Option()
        {
            Tools.Yellow("Option: ");
        }
    }
}

