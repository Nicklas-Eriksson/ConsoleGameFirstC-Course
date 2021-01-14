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
            //List<IMonster> monsterList = Monster.monster.MonsterGenerator();


            List<string> monsterNames = new List<string>() { "Goblin", "Thief", "Banshee", "Cultist", "Mutant", "Hell Hound", "Elder Thing", "Deep One", " Silent One", "Necromancer", "Deci", "Ogre", "Gargoyle", "Troll", "Nymph", "Kobold", "Satyr", "Decided Rat", "Giant Spider", "Rabid Goblin", "Giant Spider" };
            List<string> lvl10Monsters = new List<string>() { "Azathoth", "B'gnu-Thun", "Bokrug", "Cthulhu", "Dagon", "Dimensional Shambler", "Dunwich Horror", "Formless Spawn", "Ghatanothoa", "Gloon", "Gnoph-Keh", "Great Old One", "Yog-Sothoth", "Yuggoth", "Innsmouth", "Shoggoth", "Outer God", "Nightgaut", "Nyarlathotep" };

            int[] expDropArray = new int[9] { 20, 55, 66, 100, 160, 266, 458, 800, 1422 }; //will use player lvl as index to face off against same lvl monster

            Random rnd = new Random();
            if (Player.Player.player.Lvl < 9)
            {
                Monster monster = new Monster()//Balance this 
                {
                    name = monsterNames[rnd.Next(0, monsterNames.Count)],
                    lvl = Player.Player.player.Lvl,
                    hp = Player.Player.player.Hp * 2,
                    dmg = Player.Player.player.Hp / 2,
                    expDrop = expDropArray[Player.Player.player.Lvl],
                    goldDrop = 10000

                };
            }
            else if (Player.Player.player.Lvl >= 9)
            {
                Monster monster = new Monster()//Balance this
                {
                    name = monsterNames[rnd.Next(0, monsterNames.Count)],
                    lvl = Player.Player.player.Lvl,
                    hp = 10000,
                    dmg = 500,
                    expDrop = 10000,
                    goldDrop = 10000

                };



                Console.WriteLine("You decide to keep exploring the god forsaken dungeon..\nYou grab the doorknob to the next room and slowly turn it..\n" +
                    "When you hear the door klick, you push open the door, ready to face whatever stands before you.\n" +
                    "There before you stands a hideous creature..");

                Console.WriteLine($"{ monster.name}");
                Console.WriteLine($"{ monster.lvl}");
                Console.WriteLine($"{ monster.hp}");
                Console.WriteLine($"{ monster.dmg}");
                Console.WriteLine("----------------------------\n");
                Console.WriteLine($"Player:");
                Console.WriteLine($"{ Player.Player.player.Name}");
                Console.WriteLine($"{ Player.Player.player.Lvl}");
                Console.WriteLine($"{ Player.Player.player.Hp}");
                Console.WriteLine($"{ Player.Player.player.Dmg + Player.Player.player.WeaponDmg}");
                Console.WriteLine($"{ Player.Player.player.HealingPotions}");
                Console.WriteLine("----------------------------\n");




            }


        }
    }
}
