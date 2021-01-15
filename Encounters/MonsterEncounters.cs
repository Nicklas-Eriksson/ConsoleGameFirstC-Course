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
    public class MonsterEncounters
    {
        static private Random rnd = new Random();

        private static void TextEncounter()
        {
            Tools.YellowLine("You decide to keep exploring the god-forsaken dungeon..");
            Sleep(3000);
            Tools.YellowLine("You grab the doorknob to the next room and slowly turn it..");
            Sleep(3000);
            Tools.YellowLine("When you hear the door click, you push open the door, ready to face whatever stand before you.");
            Sleep(3000);
            Tools.YellowLine("Before you stands a hideous creature..\n");
            Sleep(3000);
        }
        public static void EncounterGenerator()
        {
            Console.Clear();

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
                    hp = Player.player.Hp * 2,
                    dmg = Player.player.Dmg / 2,
                    expDrop = expDropArray[Player.player.Lvl],
                    goldDrop = 100 * Player.player.Lvl
                };

                TextEncounter();

                Fight(monster, monsterIndex);
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

                TextEncounter();

                Fight(monster, monsterIndex);
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
            Tools.GreenLine($"Healing Potions: {Player.player.HealingPotions} flasks");
            Tools.YellowLine("-----------------------------\n");
        }

        static void FightingMenueText()
        {
            Console.WriteLine("-----------------------");
            Console.WriteLine("|| [A]ttack......... ||");//The fighting is turn based. First you strike, than the monster will attack you
            Console.WriteLine("|| [B]lock Attack... ||");//Block attack, take reduced/no dmg, and deal some back
            Console.WriteLine("|| [H]ealing Potion..||");//Take a swig from a potion, heals up health. Takes reduced damage while healing
            Console.WriteLine("|| [R]un Away........||");//Tries to escape. Chanse to be hit on the way out
            Console.WriteLine("|| [E]xit Game.......||");
            Console.WriteLine("-----------------------");
        }
        static public void Fight(Monster monster, int monsterIndex)
        {
            Console.Clear();
            FightingMenueText();
            StatsDuringFight(monster);
            Weapon.weapon.instantiateList();

            int monsterChanseOnHit = rnd.Next(1, 3); //33% chance to hit on escape
            int dodge = rnd.Next(1, 5); //20% that the attack is dodged
            int pDmg = Player.player.Dmg;
            int pDmg2 = Player.player.WeaponDmg;
            int pDmg3 = pDmg + pDmg2;
            char input;

            Tools.Yellow("Option: ");
            input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case ('a')://Attack

                    //Remove monster index?

                    while (Player.player.Alive == true)
                    {
                        Console.WriteLine($"\nYou raise your {Weapon.weapon.WeaponList[Player.player.WeaponIndex].Name} and attack the {monster.name}!");
                        Sleep(3000);

                        if (dodge == 1)
                        {
                            Console.WriteLine("As you try to strike you miss your attack..");
                            Console.WriteLine($"The {monster.name} strikes you while you gather your wits");
                            Player.player.Hp -= monster.dmg / 2; //Player takes half monster dmg  
                            Sleep(3000);

                            CheckIfAlive();
                        }
                        else
                        {
                            Console.WriteLine($"As you strike the {monster.name} it screams in pain.");
                            Console.WriteLine($"The {monster.name} was delt {pDmg}.");
                            monster.hp -= pDmg;
                            Sleep(3000);

                            CheckIfAlive();
                        }

                        if (monster.hp <= 0)
                        {

                            Tools.YellowLine($"As you prepare for one more attack on the { monster.name}");
                            Sleep(3000);
                            Tools.YellowLine($"you suddenly come to a halt when you see the lifeless corpse of your foe.");
                            Sleep(3000);
                            Tools.YellowLine($"It has fallen dead onto the floor and blood is seeping from its open wounds..");
                            Sleep(3000);
                            Console.WriteLine($"+ {monster.expDrop} experience points!");
                            Console.WriteLine($"+ {monster.goldDrop} gold added to pouch!");

                            Player.player.Exp += monster.expDrop;
                            Player.player.Gold += monster.goldDrop;
                            Sleep(3000);

                            Player.ExpToLvl(Player.player.Exp); //Cheks if you can level up
                        }

                        //Now the monster will attack back!
                        Console.WriteLine($"The {monster.name} strikes you for {monster.dmg}!");
                        Player.player.Hp -= monster.dmg;

                        Player.ExpToLvl(Player.player.Exp); //Cheks if you can level up

                        Fight(monster, monsterIndex);
                    }
                    break;

                ////////////////
                //   Block   //
                case ('b')://Block

                    Console.WriteLine($"You raise your {Weapon.weapon.WeaponList[Player.player.WeaponIndex].Name} in a defensive stance.");
                    if (monsterChanseOnHit == 1)//If monster hits
                    {
                        Console.WriteLine($"The {monster.name} strikes you with all their power and hits you for {monster.dmg / 2} damage.");
                        Player.player.Hp -= monster.dmg / 2;

                    }
                    else if (monsterChanseOnHit > 1) //Miss
                    {
                        Console.WriteLine($"The {monster.name} misses you with their attack and you frantically strike back");
                        Console.WriteLine($"You hit the {monster.name} for {pDmg / 2} damage.");
                        monster.hp -= pDmg / 2;
                    }
                    Sleep(2000);
                    break;

                /////////////////
                //    Heal    //
                case ('h'):

                    //Drink a healing potion.
                    Sleep(2000);
                    break;

                ///////////////////
                //   Run away   //
                case ('r'):

                    Console.WriteLine("With darting eyes you look for the door you just came in from.");
                    Console.WriteLine("You turn around and head for the exit.");
                    Console.WriteLine($"But as you do the {monster.name} takes a swing at you!");

                    if (monsterChanseOnHit == 1) //Hit
                    {
                        Console.WriteLine($"The sweeping strike from the {monster.name} hits you for {monster.dmg / 2}.");
                        Player.player.Hp -= monster.dmg / 2;
                    }
                    else if (monsterChanseOnHit > 1)//Miss
                    {
                        Console.WriteLine("The {monster.name} barely misses you, as you slam the door shut.");
                        Sleep(2000);
                        MenuOptions.Options(); //Back to menu
                    }
                    Sleep(2000);
                    break;

                ////////////////
                //    Exit   //
                case ('e')://Exit Game

                    Tools.ExitGame();
                    break;
            }

        }
        static private void CheckIfAlive()
        {
            if(Player.player.Hp <= 0)
            {
                Player.player.Alive = false;
                Console.WriteLine("You died! Game over!");
                Sleep(4000);
                Tools.ExitGame();
            }            
        }



    }
}
