using Labb3.Character;
using Labb3.Menues;
using Labb3.StartGame;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Threading.Thread;

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
                    Sleep(3000);
                    MenuOptions.MainMenuSwitch();
                }
                else if (!success && input == "ihavethepower")//lvl 10 cheat
                {
                    Player.player.Lvl = 10;//lvl 10 cheat
                    Tools.GreenLine("Whooow! You grow up fast dont you!?");
                    Tools.GreenLine("Character level: 10");
                    Sleep(3000);
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
        static public void ExitGame(bool wonGame)
        {
            Console.Clear();
            Logo.Exit();

            string input;
            if (wonGame)
            {
                Tools.YellowLine("\n Thank you for playing my game");
                Sleep(1500);
                Tools.RedLine("Exiting Game..");
                Sleep(1400);
                Environment.Exit(0);
            }
            else if (Player.player.Alive == true && !wonGame)
            {
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
                        Console.Clear();
                        Logo.Exit();

                        Tools.YellowLine("===========================");
                        Tools.YellowLine("|| Save before you exit? ||");
                        Tools.YellowLine("|| [1] Yes...............||");
                        Tools.YellowLine("|| [2] Hell no...........||");
                        Tools.YellowLine("===========================\n");

                        int nr = Tools.ConvToInt32(2);

                        switch (nr)
                        {
                            case 1:
                                SaveOrLoad.Save();
                                Tools.YellowLine("\n Thank you for playing my game");
                                Sleep(1500);
                                Tools.RedLine("Exiting Game..");
                                Sleep(1400);
                                Environment.Exit(0);
                                break;
                            case 2:
                                Tools.YellowLine("\n Not all progress is good progress I guess!");
                                Tools.YellowLine("Thank you for playing my game");
                                Sleep(1500);
                                Tools.RedLine("Exiting Game..");
                                Sleep(1400);
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

            }//if (alive == true) END

            else if(Player.player.Alive == false)
            {
                Tools.RedLine("You died! Better luck next time!");
                Sleep(1400);
                Tools.YellowLine("One more time?!");
                Tools.YellowLine("===================");
                Tools.YellowLine("|| [1] Yes.......||");
                Tools.YellowLine("|| [2] Hell no!..||");
                Tools.YellowLine("===================");

                int nr = Tools.ConvToInt32(2);
                if(nr == 1)
                {
                    Start.NewGame();
                }
                else
                {
                    Tools.YellowLine("Well.. Not every one can die a hero!");
                    Sleep(1400);
                    Tools.YellowLine("Thank you for playing my game");
                    Sleep(1400);
                    Tools.RedLine("Exiting Game..");
                    Sleep(1400);
                    Environment.Exit(0);
                }
            }

        }//Exit Game END
    }//Class Tools END
}

