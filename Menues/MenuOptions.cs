using Labb3.Character;
using Labb3.Encounters;
using Labb3.Items;
using Labb3.Store;
using Labb3.UtilityTools;
using System;
using System.Collections.Generic;
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

            Tools.DrawCharacterStatus();

            Tools.YellowLine("===========================\n");
        }

        public static void MainMenuSwitch()
        {
            MainMenuText();

            input = Tools.ConvToInt32(5);

            switch (input)
            {
                case 1://Explore
                    Explore();
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

        private static void Explore()
        {
            Random rnd = new Random();
            int rndNr = rnd.Next(1, 11);

            if (rndNr == 1)//10% nothing happens
            {
                Console.Clear();

                Tools.YellowLine("You explore deeper into the dungeon.");
                //Sleep(3000);
                Tools.YellowLine("You see a wooden door with a rusty knob and lock.");
                // Sleep(3000);
                Tools.YellowLine("Slowly you turn the creaking door open..");
                // Sleep(3000);
                Tools.YellowLine("To your surprise, the corridor is completely desolate...");
                // Sleep(3000);

                MainMenuSwitch();
            }
            else //90% You encounter a monster
            {
                MonsterEncounters.EncounterGenerator();
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
        }

        private static void InventorySwitch()
        {
            List<IItem> _inventory = Item.GetList();

            input = Tools.ConvToInt32(2);
            switch (input)
            {
                case 1://Change Weapon
                    Tools.YellowLine("\n Enter the number of the weapon you would like to equip.\n");
                    input = Tools.ConvToInt32(_inventory.Count);
                    if (_inventory[input - 1] is Weapon)
                    {
                        int foundIndex = 0;
                        bool contains = Weapon.weapon.FullWeaponList.Contains(_inventory[input - 1] as Weapon);
                        if (contains)
                        {
                            foundIndex = Weapon.weapon.FullWeaponList.IndexOf(_inventory[input - 1] as Weapon);
                        }

                        Player.player.WeaponIndex = foundIndex;
                        Tools.YellowLine($"{Weapon.weapon.FullWeaponList[foundIndex].Name} is now your current weapon.");
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

                case 2://Back to main menu
                    MainMenuSwitch();
                    break;
            }
        }

        private static void InventoryMenu()
        {
            Tools.YellowLine("=========================");
            Tools.YellowLine("|| -----Inventory----- ||");
            Tools.YellowLine("|| [1] Change Weapon.. ||");
            Tools.YellowLine("|| [2] Back........... ||");
            Tools.YellowLine("=========================\n");
        }
    }
}