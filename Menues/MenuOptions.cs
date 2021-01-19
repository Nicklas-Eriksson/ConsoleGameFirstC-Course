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
    public static class MenuOptions
    {
        private static int input;

        private static void OptionAlternatives()
        {
            Console.Clear();
            Logo.DoD();

            Tools.YellowLine("===========================");
            Tools.YellowLine("|| [1] Explore.......... ||");
            Tools.YellowLine("|| [2] Shop............. ||");
            Tools.YellowLine("|| [3] Exit Game........ ||");
            Tools.YellowLine("===========================\n");



            Tools.PurpleLine("-Player Stats-");
            Console.Write(" Name: ");
            Tools.YellowLine($"{Player.player.Name}");
            Console.Write(" Health:");
            Tools.GreenLine($"{Player.player.MaxHp}"); ;
            Console.Write(" Power:");
            Tools.RedLine($"{Player.player.Dmg}");
            Console.Write($" Level:");
            Tools.YellowLine($"{Player.player.Lvl}");
            Console.Write($" Experience:");
            Tools.GreenLine($"{Player.player.Exp} / {Player.player.MaxExp}");

            Tools.PurpleLine("\n -Inventory-");
            List<Weapon> weaponList = Weapon.weapon.GetFullWeaponList();

            int wepIndex = Player.player.WeaponIndex;
            if (wepIndex >= 0)
            {
                Console.Write(" Weapon:");
                Tools.PurpleLine($"{weaponList[wepIndex].Name} + {weaponList[wepIndex].Power} damage");
            }
            else if (wepIndex == -1)
            {
                Console.Write(" Weapon:");
                Tools.PurpleLine("Fists");
            }
            Console.Write(" Gold:");
            Tools.YellowLine($"{Player.player.Gold}\n");
            Console.WriteLine(" Healing Potions:");
            Tools.GreenLine($"  Lesser: {Player.player.LesserPotion}");
            Tools.GreenLine($"  Minor: {Player.player.MinorPotion}");
            Tools.GreenLine($"  Major: {Player.player.MajorPotion}");


        }

        public static void Options()
        {
            Console.Clear();
            OptionAlternatives();

            input = Tools.ConvToInt32(3);

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

                        Options();
                    }
                    else //90% You encounter a monster
                    {
                        MonsterEncounters.EncounterGenerator();
                    }
                    break;

                case 2://Shop

                    Dealers.StoreMenueIronSkillet();
                    break;

                case 3://Exit Game

                    Tools.ExitGame();
                    break;
            }
        }


    }
}
