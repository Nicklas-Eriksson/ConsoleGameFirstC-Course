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
        private static void OptionAlternatives()
        {
            Console.Clear();
            Tools.YellowLine("===========================");
            Tools.YellowLine("|| [1] Explore.......... ||");
            Tools.YellowLine("|| [2] Shop............. ||");
            Tools.YellowLine("|| [3] Player Stats..... ||");
            Tools.YellowLine("|| [4] Exit Game........ ||");
            Tools.YellowLine("===========================\n");
        }

        public static void Options()
        {
            Console.Clear();
            OptionAlternatives();

            int input = Tools.ConvToInt32(Console.ReadLine());

            switch (input)
            {
                case 1://Explore
                    Random rnd = new Random();
                    int rndNr = rnd.Next(1, 11);

                    if (rndNr == 1)//10% nothing happens
                    {
                        Console.Clear();

                        Tools.YellowLine("You explore deeper into the dungeon.");
                        Sleep(3000);
                        Tools.YellowLine("You see a wooden door with a rusty knob and lock.");
                        Sleep(3000);
                        Tools.YellowLine("Slowly you turn the creeking door open..");
                        Sleep(3000);
                        Tools.YellowLine("To your surprise, the corridor is completly desolate...");
                        Sleep(3000);
                        
                        Options();
                    }
                    else //90% You encounter a monster
                    {
                        MonsterEncounters.EncounterGenerator();
                    }
                    break;

                case 2://Shop

                    Dealers.BuyWeapon();
                    break;

                case 3://Player Stats

                    PlayerStats();                   
                    break;

                case 4://Exit Game

                    Tools.ExitGame();
                    break;
            }
        }

        private static void PlayerStats()
        {
            Console.Clear();
            OptionAlternatives();
            Console.WriteLine(" -Player Stats-");
            Console.WriteLine($" Name: {Player.player.Name}");
            Console.WriteLine($" Health: {Player.player.Hp}");
            Console.WriteLine($" Power: {Player.player.Dmg}");
            Console.WriteLine($" Level: {Player.player.Lvl}");
            Console.WriteLine($" Experience: {Player.player.Exp}");

            Console.WriteLine("\n -Inventory-");
            List<Weapon> weaponList = Weapon.weapon.GetFullWeaponList();

            int wepIndex = Player.player.WeaponIndex;
            Console.WriteLine($" Weapon: {weaponList[wepIndex].Name} + {weaponList[wepIndex].Power} ");
            Console.WriteLine($" Potions: {Player.player.HealingPotions}");
            Console.WriteLine($" Gold: {Player.player.Gold}\n");

            Tools.BlueLine("Press any key when you want to return to previous menu..");
            Console.ReadKey();
            MenuOptions.Options();
        }
    }
}
