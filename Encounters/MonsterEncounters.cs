using Labb3.UtilityTools;
using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Monsters;
using Labb3.Items;
using Labb3.Character;
using Labb3.Store;
using static System.Threading.Thread;
using Labb3.Menues;

namespace Labb3.Encounters
{
    [Serializable]

    public class MonsterEncounters
    {
        private static Random rnd = new Random();
        private static int input;

        private static void TextEncounter()
        {
            Console.Clear();
            Logo.Fight();

            Tools.YellowLine("You decide to keep exploring the god-forsaken dungeon..");
            // Sleep(3000);
            Tools.YellowLine("You grab the doorknob to the next room and slowly turn it..");
            //Sleep(3000);
            Tools.YellowLine("When you hear the door click, you push open the door,");
            // Sleep(3000);
            Tools.YellowLine("ready to face whatever stand before you.");
            // Sleep(3000);
            Tools.YellowLine("Before you stands a hideous creature..\n");
            // Sleep(3000);
        }
        public static void EncounterGenerator()
        {
            Console.Clear();

            TextEncounter();
            

            List<string> monsterNames = new List<string>() { "Goblin", "Thief", "Banshee", "Cultist", "Mutant", "Hell Hound", "Elder Thing", "Deep One", " Silent One", "Necromancer", "Deci", "Ogre", "Gargoyle", "Troll", "Nymph", "Kobold", "Satyr", "Decided Rat", "Giant Spider", "Rabid Goblin", "Giant Spider" };
            List<string> lvl10Monsters = new List<string>() { "Azathoth", "B'gnu-Thun", "Bokrug", "Cthulhu", "Dagon", "Dimensional Shambler", "Dunwich Horror", "Formless Spawn", "Ghatanothoa", "Gloon", "Gnoph-Keh", "Great Old One", "Yog-Sothoth", "Yuggoth", "Innsmouth", "Shoggoth", "Outer God", "Nightgaut", "Nyarlathotep" };

            int[] expDropArray = new int[9] { 20, 55, 66, 100, 160, 266, 458, 800, 1422 }; //will use player lvl as index to face off against same lvl monster

            int monsterIndex = rnd.Next(0, monsterNames.Count);


            if (Player.player.Lvl < 9)
            {
                Monster monster = new Monster()//Balance this 
                {
                    name = monsterNames[monsterIndex],
                    lvl = Player.player.Lvl,
                    hp = 100 * Player.player.Lvl,
                    dmg = 50 * Player.player.Lvl,
                    expDrop = expDropArray[Player.player.Lvl],
                    goldDrop = 100 * Player.player.Lvl,
                    alive = true
                };

                Fight(monster);
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
                    goldDrop = 10000,
                    alive = true
                };

                Fight(monster);
            }
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
            Tools.GreenLine($"Healing Potions:");
            Tools.Yellow("||");
            Tools.GreenLine($"  -Lesser: {Player.player.LesserPotion} flasks");
            Tools.Yellow("||");
            Tools.GreenLine($"  -Minor: {Player.player.MinorPotion} flasks");
            Tools.Yellow("||");
            Tools.GreenLine($"  -Major: {Player.player.MajorPotion} flasks");
            Tools.YellowLine("-----------------------------\n");
        }

        static void FightingMenueText()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("|| [1] Attack......... ||");//The fighting is turn based. First you strike, than the monster will attack you
            Console.WriteLine("|| [2] Block Attack... ||");//Block attack, take reduced/no dmg, and deal some back
            Console.WriteLine("|| [3] Healing.........||");//Take a swig from a potion, heals up health. Takes reduced damage while healing
            Console.WriteLine("|| [4] Run Away........||");//Tries to escape. Chanse to be hit on the way out
            Console.WriteLine("|| [5] Exit Game.......||");
            Console.WriteLine("=========================");
        }
        static public void Fight(Monster monster)
        {
            //Montster
            int monsterChanseOnHit = rnd.Next(1, 3); //33% chance to hit on escape
            int dodge = rnd.Next(1, 5); //20% that the attack is dodged

            //Player
            int pDmg = Player.player.Dmg + Player.player.WeaponDmg;
            int pIndex = Player.player.WeaponIndex;
            string wepName;

            if (pIndex > 0)
            {
                wepName = Weapon.weapon.WeaponList[Player.player.WeaponIndex].Name;
            }
            else
            {
                wepName = "Fists";
            }

            
            while (Player.player.Alive == true && monster.alive == true)
            {
                Console.Clear();

                //UI
                FightingMenueText();
                StatsDuringFight(monster);

                
                input = Tools.ConvToInt32(5);

                switch (input)
                {
                    ////////////////
                    //   Attack  //
                    case 1:

                        //Remove monster index?

                        Console.WriteLine($"\n You raise your {wepName} and attack the {monster.name}!");
                        //Sleep(3000);

                        if (dodge == 1)
                        {
                            Console.WriteLine(" As you try to strike your attack miss..");
                            Console.WriteLine($" The {monster.name} strikes you while you gather your wits");
                            Tools.RedLine($"-{monster.dmg / 2} health.");
                            Player.player.Hp -= monster.dmg / 2; //Player takes half monster dmg  
                            Player.CheckIfAlive();
                            Sleep(3000);
                        }
                        else //Hit
                        {
                            Console.WriteLine($" As you strike the {monster.name} it screams in pain.");
                            Console.Write($" The {monster.name} was delt ");
                            Tools.GreenLine($"{pDmg} damage");
                            monster.hp -= pDmg;
                            Player.CheckIfAlive();
                            Sleep(3000);
                        }


                        //Monsters turn to attack
                        Console.WriteLine($" As you prepare for one more attack on the {monster.name},");
                        //Sleep(3000);
                        Console.WriteLine($" you suddenly come to a halt when you see its lifeless corpse.");
                        //Sleep(3000);
                        Console.WriteLine($" It has fallen dead onto the floor and blood is seeping from its open wounds..");
                        //Sleep(3000);
                        Tools.GreenLine($"+ {monster.expDrop} experience points!");
                        Tools.YellowLine($"+ {monster.goldDrop} gold added to pouch!");

                        Player.player.Exp += monster.expDrop;
                        Player.player.Gold += monster.goldDrop;

                        Sleep(3000);
                        monster.CheckIfAlive();
                        Player.CheckIfLvlUp(); //Cheks if you can level up



                        Console.WriteLine($" After your hits has landed the {monster.name} hits you with a sweeping strike!");
                        Tools.RedLine($"-{monster.dmg} damage");
                        Player.player.Hp -= monster.dmg;
                        Player.CheckIfAlive();

                        break;

                    ////////////////
                    //   Block   //
                    case 2:


                        Console.WriteLine($" You raise your {wepName} in a defensive stance.");
                        if (monsterChanseOnHit >= 1)// 66% chance on hit
                        {
                            Console.WriteLine($" The {monster.name} strikes you with all their power and hits you for {monster.dmg} damage.");
                            Player.player.Hp -= monster.dmg;
                            Player.CheckIfAlive();

                        }
                        else if (monsterChanseOnHit == 3)// 33% chance to miss
                        {
                            Console.WriteLine($" The {monster.name} misses you with their attack and you frantically strike back");
                            Console.WriteLine($" You hit the {monster.name} for {pDmg / 2} damage.");
                            monster.hp -= pDmg / 2;
                            monster.CheckIfAlive();
                        }
                        Sleep(2000);

                        break;

                    /////////////////
                    //    Heal    //
                    case 3:
                        while (Player.player.Hp < Player.player.MaxHp)
                        {
                            Console.WriteLine(" -Chose your potion-");
                            int index = Tools.ConvToInt32(3);

                            Console.WriteLine($" You open your bag and scramble for your {Consumable.itemList[index].Name}healing potion..");
                            Console.WriteLine(" With a big chug you down the whole content.");
                            Tools.GreenLine($"Health + {Consumable.itemList[index].Bonus}");

                            Player.player.Hp += Consumable.itemList[index].Bonus;

                            if (Player.player.Hp >= Player.player.MaxHp) //Corrects so that player cant heal for more than max hp
                            {
                                Player.player.Hp = Player.player.MaxHp;
                            }

                            if (index == 1)
                            {
                                Player.player.LesserPotion--;
                            }
                            else if (index == 2)
                            {
                                Player.player.MinorPotion--;
                            }
                            else if (index == 3)
                            {
                                Player.player.MajorPotion--;
                            }

                            Sleep(2000);
                        }
                        break;

                    ///////////////////
                    //   Run away   //
                    case 4:

                        Console.WriteLine("With darting eyes you look for the door you just came in from.");
                        Console.WriteLine("You turn around and head for the exit.");
                        Console.WriteLine($"But as you do the {monster.name} takes a swing at you!");

                        if (monsterChanseOnHit >= 1) // 33% chace the monster hits you on your way out
                        {
                            Console.WriteLine($"The sweeping strike from the {monster.name} hits you for as you try to run away.");
                            Tools.RedLine($"-{monster.dmg / 2}");
                            Player.player.Hp -= monster.dmg / 2;
                            Player.CheckIfAlive();
                        }
                        else if (monsterChanseOnHit > 1)// 66% miss
                        {
                            Console.WriteLine($"The {monster.name} barely misses you, as you slam the door shut.");
                            Sleep(2000);
                            MenuOptions.MainMenuSwitch(); //Back to menu
                        }
                        Sleep(2000);
                        break;

                    ////////////////
                    //    Exit   //
                    case 5://Exit Game

                        Tools.ExitGame();
                        break;
                }//Switch end

            }//While (player and monster alive == true) end
            MenuOptions.MainMenuSwitch();
        }
    }
}
