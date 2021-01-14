using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Encounters;
using Labb3.Items;
using Labb3.Player;
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
            OptionAlternatives();

            int input = Tools.ConvToInt32(Console.ReadLine());

            switch (input)
            {
                case 1://Explore
                    Random rnd = new Random();
                    int rndNr = rnd.Next(1, 11);
                    if (rndNr == 1)//10% nothing happens
                    {
                        Console.WriteLine("You explore deeper into the dungeon.\n" +
                          "You see a wooden door with a rusted knob and lock.\n" +
                          "Slowly you turn the creeking door open..\n" +
                          "To your surprise, the corridor is completly decollet.");
                    }
                    else
                    {
                        //MonsterEncounters.Encounter();
                    }
                    break;
                case 2://Shop
                    Store.Dealers.BuyingWeaponSwitch();
                    break;
                case 3://Player Stats
                   
                    Weapon weapon = new Weapon();
                    

                    Console.WriteLine("-Player Stats-");
                    Console.WriteLine("Name: " + Player.Player.player.Name);
                    Console.WriteLine("Health: " + Player.Player.player.Hp);
                    Console.WriteLine("Power: " + Player.Player.player.Dmg);
                    Console.WriteLine("Level: " + Player.Player.player.Lvl);
                    Console.WriteLine("Experience: " + Player.Player.player.Exp);
                    Console.WriteLine("Potions: " + Player.Player.player.HealingPotions);
                    

                    Console.ReadKey();
                    
                  
                    
                    //Console.WriteLine("Weapon name: " + currentWeapon.Name);
                    //Console.WriteLine("Weapon power level: " + currentWeapon.Name);
                    //Console.WriteLine("Weapon power: " + currentWeapon.Power);
                    //Console.WriteLine("--------------------------------");

                    break;

                case 4://Exit Game
                    Tools.ExitGame();
                    break;

            }
        }

    }
}
