using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Encounters;
using Labb3.Items;
using Labb3.Store;
using Labb3.Character;
using Labb3.UtilityTools;
using static System.Threading.Thread;

namespace Labb3.Menues
{
    [Serializable]

    public static class MenuOptions
    {
        private static int input;

        private static void MainMenuText()
        {
            Console.Clear();
            Logo.DoS();

            Tools.YellowLine("===========================");
            Tools.YellowLine("|| [1] Explore.......... ||");
            Tools.YellowLine("|| [2] Shop............. ||");
            Tools.YellowLine("|| [3] View Inventory... ||");
            Tools.YellowLine("|| [4] Save Game........ ||");
            Tools.YellowLine("|| [5] Exit Game........ ||");
            Tools.YellowLine("===========================\n");

            //Displays the stats for current charracter
            PlayerStats();
        }

        private static void PlayerStats()
        {
            Tools.PurpleLine("-Player Stats-");
            Console.Write(" Name: ");
            Tools.YellowLine($"{Player.player.Name}");
            Console.Write(" Health:");
            Tools.GreenLine($"{Player.player.MaxHp}"); ;
            Console.Write(" Base damage:");
            Tools.RedLine($"{Player.player.BaseDamage}");
            Console.Write($" Level:");
            Tools.YellowLine($"{Player.player.Lvl}");
            Console.Write($" Experience:");
            Tools.GreenLine($"{Player.player.Exp} / {Player.player.MaxExp}");
            int wepIndex = Player.player.WeaponIndex;

            if (wepIndex == -1)
            {
                Tools.PurpleLine($"\n Fists + {Player.player.FistDamage} attack damage");
                

            }

            Tools.PurpleLine("\n -Leather Pouch-");
            //List<Weapon> weaponList = Weapon.weapon.GetFullWeaponList();

            if (wepIndex >= 0)
            {
                Console.Write(" Weapon:");
                Tools.PurpleLine($"{Weapon.weapon.WeaponList[wepIndex].Name} + {Weapon.weapon.WeaponList[wepIndex].Power} attack damage");
            }
            else if (wepIndex == -1)
            {
                Console.Write(" Weapon:");
                Tools.PurpleLine("None");
            }
            Console.Write(" Gold:");
            Tools.YellowLine($"{Player.player.Gold}\n");
            Console.WriteLine(" Healing Potions:");
            Tools.GreenLine($"  Minor: {Player.player.MinorPotion}");
            Tools.GreenLine($"  Greater: {Player.player.GreaterPotion}");
            Tools.GreenLine($"  Major: {Player.player.MajorPotion}\n");
        }

        public static void MainMenuSwitch()
        {
            Console.Clear();
            MainMenuText();

            input = Tools.ConvToInt32(5);

            switch (input)
            {
                case 1://Explore
                    Random rnd = new Random();
                    int rndNr = rnd.Next(1, 11);

                    if (rndNr == 1)//10% nothing happens
                    {
                        Console.Clear();

                        Tools.YellowLine("You explore deeper into the dungeon.");
                        //Sleep(3000);
                        Tools.YellowLine("You see a wooden door with a rusty knob and lock.");
                        // Sleep(3000);
                        Tools.YellowLine("Slowly you turn the creeking door open..");
                        // Sleep(3000);
                        Tools.YellowLine("To your surprise, the corridor is completly desolate...");
                        // Sleep(3000);

                        MainMenuSwitch();
                    }
                    else //90% You encounter a monster
                    {
                        MonsterEncounters.EncounterGenerator();
                    }
                    break;

                case 2://Shop

                    Dealers.MainMenuStore();
                    break;

                case 3://View Inventor

                    ViewInventory();
                    break;

                case 4://Save Game

                    SaveOrLoad.Save();
                    MainMenuSwitch();
                    break;

                case 5://Exit Game

                    Tools.ExitGame(false);
                    break;
            }
        }

        private static void ViewInventory()
        {
            Console.Clear();
            Logo.Inventory();
            InventoryMenu();
            Player.DisplayInventory();

            Console.WriteLine();
            InventorySwitch();

            List<IItem> inventory = Item.GetList();//Bort??




        }

        private static void InventorySwitch()
        {
            List<IItem> _inventory = Item.GetList();

            input = Tools.ConvToInt32(3);
            switch (input)
            {
                case 1://Change Weapon
                    Tools.YellowLine("\n Enter the number of the weapon you would like to equip.\n");
                    input = Tools.ConvToInt32(_inventory.Count);
                    if (_inventory[input - 1] is Weapon)
                    {
                        int foundIndex = 0;
                        bool contains = Weapon.weapon.WeaponList.Contains(_inventory[input - 1] as Weapon);
                        if (contains)
                        {
                            foundIndex = Weapon.weapon.WeaponList.IndexOf(_inventory[input - 1] as Weapon);
                        }

                        Player.player.WeaponIndex = foundIndex;
                        Tools.YellowLine($"{Weapon.weapon.WeaponList[foundIndex].Name} is nor your current weapon.");
                        Sleep(1800);
                        MainMenuSwitch();
                    }
                    else
                    {
                        Tools.Error();
                        Sleep(1300);
                        Tools.RedLine("That item is not a weapon!");
                        InventorySwitch();
                    }

                    break;

                case 2://Inspect Item
                    //
                    break;

                case 3://Back to main menu
                    MainMenuSwitch();
                    break;

            }
        }

        private static void InventoryMenu()
        {
            Tools.YellowLine("=========================");
            Tools.YellowLine("|| -----Inventory----- ||");
            Tools.YellowLine("|| [1] Change Weapon.. ||");
            Tools.YellowLine("|| [2] Inspect Item... ||");
            Tools.YellowLine("|| [3] Back........... ||");
            Tools.YellowLine("=========================\n");
        }
    }
}
