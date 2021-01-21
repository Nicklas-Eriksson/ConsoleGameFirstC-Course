﻿using Labb3.Character;
using Labb3.Menues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Labb3.UtilityTools
{
    static public class Tools
    {
        //Text color
        static public void Red(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" " + input);
            Console.ResetColor();
        }
        static public void RedLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" " + input);
            Console.ResetColor();
        }
        static public void Yellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" " + input);
            Console.ResetColor();
        }
        static public void YellowLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" " + input);
            Console.ResetColor();
        }
        static public void Green(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" " + input);
            Console.ResetColor();
        }
        static public void GreenLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + input);
            Console.ResetColor();
        }
        static public void Blue(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(" " + input);
            Console.ResetColor();
        }
        static public void BlueLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" " + input);
            Console.ResetColor();
        }
        static public void Purple(string input)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" " + input);
            Console.ResetColor();
        }
        static public void PurpleLine(string input)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" " + input);
            Console.ResetColor();
        }
        //Text color end

        //Convertions
        static public int ConvToInt32(int maxLength)
        {
            bool success;
            string input;
            int nr;

            do
            {
                Tools.Yellow("Option: ");
                input = Console.ReadLine();
                success = Int32.TryParse(input.Trim(), out nr);
                if (success && nr <= maxLength)
                {
                    return nr;
                }
                else
                {
                    Error();
                }

                //Cheat codes START
                if (!success && input == "greedisgood")//gold cheat 
                {
                    Player.player.Gold += 1000000;
                    Tools.GreenLine("Congratulations, you are now filthy rich!\n" +
                        "+1 Million gold added to pouch");
                    Thread.Sleep(3000);
                    MenuOptions.MainMenuSwitch();
                }
                else if (!success && input == "ihavethepower")//lvl 10 cheat
                {
                    Player.player.Lvl = 10;//lvl 10 cheat
                    Tools.GreenLine("Whooow! You grow up fast dont you!?");
                    Tools.GreenLine("Character level: 10");
                    Thread.Sleep(3000);
                    MenuOptions.MainMenuSwitch();
                }
                //Cheat codes END

            } while (!success || nr > maxLength);

            return nr;
        }

        //Often used
        static public void Error()
        {
            Tools.RedLine("Wrong input, try again\n");
        }

        //Exit Game START
        static public void ExitGame()
        {
            Console.Clear();
            Logo.Exit();

            string input;

            Tools.YellowLine("Are you sure you want to exit?");
            Tools.Yellow("To confirm type");
            Tools.RedLine("\"exit\".");
            Tools.Yellow("To go back type");
            Tools.RedLine("\"back\".");

            do
            {
                Tools.Yellow("Option: ");
                input = Console.ReadLine().Trim().ToLower();

                if (input == "exit")
                {
                    Tools.YellowLine("=========================");
                    Tools.YellowLine("|| Save you exit game? ||");
                    Tools.YellowLine("|| [1] Yes.............||");
                    Tools.YellowLine("|| [2] Hell no.........||");
                    Tools.YellowLine("=========================");

                    int nr = Tools.ConvToInt32(2);

                    switch (nr)
                    {
                        case 1:
                            SaveOrLoad.Save();
                            Tools.YellowLine("Thank you for playing my game");
                            Thread.Sleep(1500);
                            Tools.RedLine("Exiting Game..");
                            Thread.Sleep(1400);
                            Environment.Exit(0);
                            break;
                        case 2:
                            Tools.YellowLine("Not all progress is good progress I guess!");
                            Tools.YellowLine("Thank you for playing my game");
                            Thread.Sleep(1500);
                            Tools.RedLine("Exiting Game..");
                            Thread.Sleep(1400);
                            Environment.Exit(0);
                            break;
                    }                    
                }
                else if (input == "back")
                {
                    MenuOptions.MainMenuSwitch();
                }
                else
                {
                    Error();
                }

            } while (input != "exit" || input != "back");

        }//Exit Game END
    }//Class Tools END
}

