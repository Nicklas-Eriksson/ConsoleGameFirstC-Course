using Labb3.UtilityTools;
using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Monsters;
using Labb3.Items;
using Labb3.Character;
using Labb3.Store;

namespace Labb3.Encounters
{
    public class MonsterEncounters
    {
        static private Random rnd = new Random();
        

        public static void Encounter()
        {         
            Console.Clear();

            List<string> monsterNames = new List<string>() { "Goblin", "Thief", "Banshee", "Cultist", "Mutant", "Hell Hound", "Elder Thing", "Deep One", " Silent One", "Necromancer", "Deci", "Ogre", "Gargoyle", "Troll", "Nymph", "Kobold", "Satyr", "Decided Rat", "Giant Spider", "Rabid Goblin", "Giant Spider" };
            List<string> lvl10Monsters = new List<string>() { "Azathoth", "B'gnu-Thun", "Bokrug", "Cthulhu", "Dagon", "Dimensional Shambler", "Dunwich Horror", "Formless Spawn", "Ghatanothoa", "Gloon", "Gnoph-Keh", "Great Old One", "Yog-Sothoth", "Yuggoth", "Innsmouth", "Shoggoth", "Outer God", "Nightgaut", "Nyarlathotep" };

            int[] expDropArray = new int[9] { 20, 55, 66, 100, 160, 266, 458, 800, 1422 }; //will use player lvl as index to face off against same lvl monster
            //exp to lvl 
            
            int monsterIndex = rnd.Next(0, monsterNames.Count);

            if (Player.player.Lvl < 9)
            {
                Monster monster = new Monster()//Balance this 
                {
                    name = monsterNames[monsterIndex],
                    lvl = Player.player.Lvl,
                    hp = Player.player.Hp * 2,
                    dmg = Player.player.Hp / 2,
                    //expDrop = expDropArray[Player.player.Lvl],
                    expDrop = expDropArray[Player.player.Lvl],
                    goldDrop = 100 * Player.player.Lvl
                };

                Tools.YellowLine("You decide to keep exploring the god forsaken dungeon..\n" +
                   "You grab the doorknob to the next room and slowly turn it..\n" +
                   "When you hear the door klick, you push open the door, ready to face whatever stands before you.\n" +
                   "There before you stands a hideous creature..\n");
                                
                StatsDuringFight(monster);

                Tools.BlueLine("Press to return");//Test
                Console.ReadKey();

                //Player dmg = {Player.Player.player.Dmg + Player.Player.player.WeaponDmg}
            }
            else if (Player.player.Lvl >= 9)
            {
                Monster monster = new Monster()//Balance this
                {
                    name = monsterNames[monsterIndex],
                    lvl = Player.player.Lvl,
                    hp = 10000,
                    dmg = 500,
                    expDrop = 10000,
                    goldDrop = 10000
                };

                Console.WriteLine("You decide to keep exploring the god forsaken dungeon..\n" +
                    "You grab the doorknob to the next room and slowly turn it..\n" +
                    "When you hear the door klick, you push open the door, ready to face whatever stands before you.\n" +
                    "There before you stands a hideous creature..\n");
                                
                StatsDuringFight(monster);

                Tools.BlueLine("Press to return");//Test
                Console.ReadKey();

                Fight(monster, monsterIndex);

            }
            static void StatsDuringFight(Monster monster)
            {
                Tools.YellowLine("-----------------------------");
                Tools.Yellow("|| ");
                Console.WriteLine($"{monster.name}");
                Tools.Yellow("||");
                Tools.RedLine($"Level: {monster.lvl}");
                Tools.Yellow("||");
                Tools.RedLine($"Health: {monster.hp}");
                Tools.YellowLine("-----------------------------");
                Tools.Yellow("|| ");
                Console.WriteLine($"{Player.player.Name}");
                Tools.Yellow("||");
                Tools.GreenLine($"Level: {Player.player.Lvl}");
                Tools.Yellow("||");
                Tools.GreenLine($"Health: {Player.player.Hp}");
                Tools.Yellow("||");
                Tools.GreenLine($"Healing Potions: {Player.player.HealingPotions} flasks");
                Tools.YellowLine("-----------------------------\n");
            }

            static void FightingMenueText()
            {                
                Console.WriteLine("-----------------------");
                Console.WriteLine("|| [A]ttack......... ||");
                Console.WriteLine("|| [B]lock Attack... ||");
                Console.WriteLine("|| [H]ealing Potion..||");
                Console.WriteLine("|| [R]un Away........||");
                Console.WriteLine("|| [E]xit Game.......||");
                Console.WriteLine("-----------------------");
            } 
            static void Fight(Monster monster, int monsterIndex)
            {

                FightingMenueText();
                StatsDuringFight(monster);

                char input = Console.ReadKey().KeyChar;

                switch(input)
                {
                    case ('a')://Attack

                        //Remove monster index?

                        while(Player.player.Alive == true)
                        {
                            Console.WriteLine($"You raise your {Weapon.weapon.WeaponList[Player.player.WeaponIndex]} and attack the {monster.name}!");

                            int dodge = rnd.Next(1, 5); //1 in 5 that the attack is dodged
                            

                            if (dodge == 1)
                            {
                                Console.WriteLine("As you strike you miss your attack..");
                                Console.WriteLine($"The {monster.name} strikes you while you gather your wits");
                                Player.player.Hp -= monster.dmg / 2; //Player takes half monster dmg
                               
                            }
                            else
                            {
                                Console.WriteLine($"As you strike the {monster.name} it screams in pain.");
                                monster.dmg -= Player.player.Hp;
                                                              
                            }
                            if (Player.player.Hp <= 0)
                            {
                                Player.player.Alive = false;
                            }
                            if(monster.hp <= 0)
                            {
                                Console.WriteLine($"As you prepare for one more attack on the {monster.name}\n" +
                                    $"you suddenly come to a halt, as you see the lifeless corpse of your foe.\n" +
                                    $"It has fallen dead onto the floor and blood are seeping out from its open wounds..");
                                Console.WriteLine($"+ {monster.expDrop} experience poionts!");
                                Player.player.Exp += monster.expDrop;
                                Player.ExpToLvl(Player.player.Exp);

                            }

                            Fight(monster, monsterIndex);
                            monster.hp -= Player.player.Dmg + Player.player.WeaponDmg;
                            Console.WriteLine($"The {monster.name} ");
                        }

                        
                        break;

                    case ('b')://Block
                            
                        break;

                    case ('h')://Heal
                            //heal.
                        break;

                    case ('r')://Run away
                            //take dmg and run away. back to menu
                        break;

                    case ('e')://Exit Game
                        Tools.ExitGame();
                        break;
                }
                
            }


        }
    }
}
