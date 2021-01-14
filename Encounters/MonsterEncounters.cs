using Labb3.UtilityTools;
using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Monsters;
using Labb3.Items;
using Labb3.Player;
using Labb3.Store;

namespace Labb3.Encounters
{
    public class MonsterEncounters
    {


        public static void Encounter(string name, int hp, int ad)
        {
            Monster monster = new Monster();
            Weapon weapon = new Weapon();
            List<IMonster> monsterL = monster.MonsterGenerator();
            //List<Weapon> weaponL = weapon.WeaponForge();
            Player.Player player = new Player.Player();

            // name = Player.CurrentPlayer
            //Console.WriteLine($"{name} HP: {}");


            Random rnd = new Random();
            int rndNr = rnd.Next(monsterL.Count);

            //Make different list of monters depending on lvl.
            //Or make monsters with generated stats based on player lvl.
            Console.WriteLine($"A {monsterL[rndNr].name} appears! BUUU!");
            Console.WriteLine("1 = attack\n 2 = block \n 3 = heal\n 4 = run away");
            Console.Write("Option: ");
            int nr = Tools.ConvToInt32(Console.ReadLine());
            switch (nr)
            {
                
                case 1:
                    Console.Write("Monster:");
                    Console.Write("Player:");
                    Console.Write($"{ monsterL[rndNr].name}");
                    Console.Write($"{ player.Name}");
                    Console.Write($"{ monsterL[rndNr].lvl}");
                    Console.Write($"{ player.Lvl}");
                    Console.Write($"{ monsterL[rndNr].hp}");
                    Console.Write($"{ player.Hp}");
                    Console.Write($"{ monsterL[rndNr].dmg}");      
                    Console.Write($"{ player.Dmg}");      
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"You attack the {monsterL[rndNr].name}!");
                    monsterL[rndNr].hp -= player.Dmg; //+ player.CurrentWeapon.power

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;

            }

        }
    }
}
