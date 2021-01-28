using Labb3.Character;
using Labb3.Items;
using Labb3.Menues;
using Labb3.StartGame;
using System;
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

        //Conversions
        /// <summary>
        /// Maximum length the option is allowed to be
        /// </summary>
        /// <param name="maxLength"></param>
        /// <returns></returns>
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
                    if (!success && input == "greedisgood" || !success && input == "ihavethepower" || !success && input == "whosyourdaddy")
                    {
                    }
                    else
                    {
                        Error();
                    }
                }

                //Cheat codes START
                if (!success && input == "greedisgood")//gold cheat
                {
                    Player.player.Gold += 1000000;
                    Tools.GreenLine("\n Congratulations, you are now filthy rich!\n" +
                        " +1 Million gold added to pouch");

                    Tools.PressEnterToContinue();

                    MenuOptions.MainMenuSwitch();
                }
                else if (!success && input == "ihavethepower")//lvl up cheat
                {
                    Tools.YellowLine("\n Enter the level you want to become:");
                    int lvlRequest = ConvToInt32(10);
                    Tools.YellowLine($"Okey a level {lvlRequest} warrior coming up!");
                    Sleep(1400);

                    for (int i = 0; i < lvlRequest; i++)
                    {
                        Player.player.Exp = Player.player.MaxExp;
                        Player.CheckIfLvlUp();
                    }

                    Tools.GreenLine("\n Whooow! You grow up fast don't you!?");
                    Tools.GreenLine($"Character level: {Player.player.Lvl}");

                    Tools.PressEnterToContinue();

                    MenuOptions.MainMenuSwitch();
                }
                else if (!success && input == "whosyourdaddy")//lvl up cheat
                {
                    Player.player.MaxHp += 10000;
                    Player.player.Hp = Player.player.MaxHp;

                    Tools.GreenLine("\n Is that hair on your chest??");
                    Tools.GreenLine($"New max health: {Player.player.MaxHp}");

                    Tools.PressEnterToContinue();

                    MenuOptions.MainMenuSwitch();
                }
                //Cheat codes END
            } while (!success || nr > maxLength);

            return nr;
        }

        //Often used START
        static public void Error()
        {
            Tools.RedLine("Wrong input, try again\n");
        }

        static public void PressEnterToContinue()
        {
            bool success;

            Tools.Purple("\n -Press"); Tools.Yellow("[Enter]"); Tools.PurpleLine("to continue-");

            do
            {
                success = Console.ReadKey().Key == ConsoleKey.Enter;
            } while (!success);
        }

        //Set Cursor START
        private static int orginalRow;

        private static int orginalCol;

        static private void CursorWriteYellow(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(orginalCol + x, orginalRow + y);
                Tools.Yellow(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static private void CursorWriteGreen(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(orginalCol + x, orginalRow + y);
                Tools.Green(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static private void CursorWritePurple(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(orginalCol + x, orginalRow + y);
                Tools.Purple(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static private void CursorWriteWhite(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(orginalCol + x, orginalRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static private void CursorWriteRed(string s, int x, int y)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            try
            {
                Console.SetCursorPosition(orginalCol + x, orginalRow + y);
                Tools.Red(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static public void DrawCharacterStatus()
        {
            //Console.Clear();
            orginalRow = Console.CursorTop;
            orginalCol = Console.CursorLeft;

            //Draw frame left
            Tools.CursorWriteYellow("||", 53, -5);
            Tools.CursorWriteYellow("||", 53, -4);
            Tools.CursorWriteYellow("||", 53, -3);
            Tools.CursorWriteYellow("||", 53, -2);
            Tools.CursorWriteYellow("||", 53, -1);

            //Draw frame middle
            Tools.CursorWriteYellow("||", 77, -5);
            Tools.CursorWriteYellow("||", 77, -4);
            Tools.CursorWriteYellow("||", 77, -3);
            Tools.CursorWriteYellow("||", 77, -2);
            Tools.CursorWriteYellow("||", 77, -1);

            //Draw frame Right
            Tools.CursorWriteYellow("||", 113, -5);
            Tools.CursorWriteYellow("||", 113, -4);
            Tools.CursorWriteYellow("||", 113, -3);
            Tools.CursorWriteYellow("||", 113, -2);
            Tools.CursorWriteYellow("||", 113, -1);

            //Draw frame top
            Tools.CursorWriteYellow("========Player Stats==================Inventory===============", 53, -6);

            //Draw frame Bottom
            Tools.CursorWriteYellow("==============================================================", 53, 0);

            Tools.CursorWriteWhite(" -Name: ", 56, -5);
            Tools.CursorWriteGreen($"{Player.player.Name}", 63, -5);
            Tools.CursorWriteWhite(" -Health:", 56, -4);
            Tools.CursorWriteGreen($"{Player.player.MaxHp}", 64, -4);
            Tools.CursorWriteWhite(" -Base damage:", 56, -3);
            Tools.CursorWriteRed($"{Player.player.BaseDamage}", 70, -3);
            Tools.CursorWriteWhite(" -Level:", 56, -2);
            Tools.CursorWriteYellow($"{Player.player.Lvl}", 63, -2);
            if (Player.player.Lvl == 10)
            {
                Tools.CursorWriteWhite(" -Experience:", 56, -1);
                Tools.CursorWriteGreen("MAX", 68, -1);
            }
            else
            {
                Tools.CursorWriteWhite(" -Experience:", 56, -1);
                Tools.CursorWriteGreen($"{Player.player.Exp}/{Player.player.MaxExp}", 68, -1);
            }

            int wepIndex = Player.player.WeaponIndex;

            if (wepIndex == -1)
            {
                Tools.CursorWritePurple($"-Fists +{Player.player.FistDamage} attack dmg", 80, -3);
            }

            //Tools.CursorWritePurple("-Leather Pouch-", 80, -3);

            if (wepIndex >= 0)
            {
                Tools.CursorWriteWhite(" -Weapon", 80, -4);
                Tools.CursorWritePurple($"{Weapon.weapon.FullWeaponList[wepIndex].Name} +{Weapon.weapon.FullWeaponList[wepIndex].Power} attack dmg", 80, -3);
            }
            else if (wepIndex == -1)
            {
                Tools.CursorWriteWhite(" -Weapon:", 80, -4);
                Tools.CursorWritePurple("None", 89, -4);
            }
            Tools.CursorWriteWhite(" -Gold:", 80, -5);
            Tools.CursorWriteYellow($"{Player.player.Gold}", 87, -5);
            Tools.CursorWriteWhite(" -Healing Potions", 80, -2);
            Tools.CursorWriteGreen($"Minor: {Player.player.MinorPotion}.", 80, -1);
            Tools.CursorWriteGreen($"Greater: {Player.player.GreaterPotion}.", 91, -1);
            Tools.CursorWriteGreen($"Major: {Player.player.MajorPotion}.", 103, -1);

            Console.WriteLine();
        }

        //Set Cursor END

        //Often used END

        //Exit Game START
        /// <summary>
        /// Enter false if game is not won yet
        /// </summary>
        /// <param name="wonGame"></param>
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
            else if (Player.player.Alive && !wonGame)
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
            else if (!Player.player.Alive)
            {
                Tools.RedLine("You died! Better luck next time!");
                Sleep(1400);
                Tools.YellowLine("One more time?!");
                Tools.YellowLine("===================");
                Tools.YellowLine("|| [1] Yes.......||");
                Tools.YellowLine("|| [2] Hell no!..||");
                Tools.YellowLine("===================");

                int nr = Tools.ConvToInt32(2);
                if (nr == 1)
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