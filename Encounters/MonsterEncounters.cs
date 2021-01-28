using Labb3.Character;
using Labb3.Items;
using Labb3.Menues;
using Labb3.Monsters;
using Labb3.Story;
using Labb3.UtilityTools;
using System;
using System.Collections.Generic;
using static System.Threading.Thread;

namespace Labb3.Encounters
{
    [Serializable]
    public static class MonsterEncounters
    {
        private static readonly MiniBoss miniboss = new MiniBoss();
        private static readonly Random rnd = new Random();
        private static int input;
        private static int readOnce;
        private static int specialAttack;

        public static LastBoss DemiLich { get; } = new LastBoss();

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

            List<string> monsterNames = new List<string>() { "Goblin", "Thief", "Banshee", "Cultist", "Mutant", "Hell Hound", "Elder Thing", "Deep One", "Silent One", "Necromancer", "Deci", "Ogre", "Gargoyle", "Troll", "Nymph", "Kobold", "Satyr", "Decided Rat", "Giant Spider", "Rabid Goblin", "Giant Spider" };
            List<string> miniBossNames = new List<string>() { "Azathoth", "B'gnu-Thun", "Bokrug", "Cthulhu", "Dagon", "Dimensional Shambler", "Dunwich Horror", "Formless Spawn", "Ghatanothoa", "Gloon", "Gnoph-Keh", "Great Old One", "Yog-Sothoth", "Yuggoth", "Innsmouth", "Shoggoth", "Outer God", "Nightgaut", "Nyarlathotep" };

            int[] expDropArray = new int[9] { 20, 23, 27, 41, 54, 92, 161, 285, 20000 };
            int monsterIndex = rnd.Next(0, monsterNames.Count);
            int monsterIndex2 = rnd.Next(0, miniBossNames.Count);
            int bonusDmg = rnd.Next(1, 15);
            int bonusGold = rnd.Next(5, 20); 
            int belowEvenAbove = rnd.Next(-1, 2);

            if (Player.player.Lvl < 9)
            {
                int lvlVariation = Player.player.Lvl;

                if (Player.player.Lvl >= 2)
                {
                    lvlVariation = Player.player.Lvl + belowEvenAbove;
                }

                Monster monster2 = new Monster()
                {
                    Name = monsterNames[monsterIndex],
                    Lvl = lvlVariation,
                    Hp = 100 * lvlVariation,
                    Dmg = (20 * lvlVariation) + bonusDmg,
                    ExpDrop = expDropArray[lvlVariation],
                    GoldDrop = (100 + bonusGold) * lvlVariation,
                    Alive = true
                };
                Fight(monster2);
            }
            else if (Player.player.Lvl == 9)
            {
                Monster miniBoss = new Monster()
                {
                    Name = miniBossNames[monsterIndex2],
                    Lvl = Player.player.Lvl + 1,
                    Hp = 4500,
                    Dmg = 450 + (bonusDmg * 5),
                    ExpDrop = expDropArray[Player.player.Lvl - 1],
                    GoldDrop = 500,
                    Alive = true
                };

                Fight(miniBoss);
            }
            else
            {
                DemiLich.Name = "Demi-Lich";
                DemiLich.Lvl = 11;
                DemiLich.Hp = 7000;
                DemiLich.Dmg = 400 + (bonusDmg * 5);
                DemiLich.SpecialAttackName = "Ice lance";
                DemiLich.SpecialAttackPower = 1000;
                DemiLich.Alive = true;

                Fight(DemiLich);
            }
        }

        private static void StatsDuringFight(Monster monster)
        {
            Tools.YellowLine("-----------------------------");
            Tools.Yellow("|| ");
            Console.WriteLine($"{monster.Name}");
            Tools.Yellow("||");
            Tools.RedLine($"Level: {monster.Lvl}");
            Tools.Yellow("||");
            Tools.RedLine($"Health: {monster.Hp}");
            Tools.YellowLine("-----------------------------");
            Tools.Yellow("|| ");
            Console.WriteLine($"{Player.player.Name}");
            Tools.Yellow("||");
            Tools.GreenLine($"Level: {Player.player.Lvl}");
            Tools.Yellow("||");
            Tools.GreenLine($"Health: {Player.player.Hp} / {Player.player.MaxHp}");
            Tools.Yellow("||");
            Tools.GreenLine("Healing Potions:");
            Tools.Yellow("||");
            Tools.GreenLine($"  -Minor: {Player.player.MinorPotion}");
            Tools.Yellow("||");
            Tools.GreenLine($"  -Greater: {Player.player.GreaterPotion}");
            Tools.Yellow("||");
            Tools.GreenLine($"  -Major: {Player.player.MajorPotion}");
            Tools.YellowLine("-----------------------------\n");
        }

        //ItemDrop START
        static private void ItemDrop()
        {
            var randomItem = Item.RandomItem();

            //chance on weapon drops
            int chanseOnLoot = rnd.Next(0, 2); //50% chance on drop
            int chanseOnWeaponLoot = rnd.Next(0, 4);//25% to drop weapon too

            //So weapons with index of 0 ti 6 can drop from mobs
            int rndNr = rnd.Next(0, 3);
            int rndNr2 = rnd.Next(0, 7);

            if (Player.player.Lvl < 9 && chanseOnLoot == 0)
            {
                Tools.YellowLine("\n Loot spontaneously appears from thin air!");
                Sleep(1400);
                Tools.YellowLine("Remarkable!\n");
                Sleep(1400);

                Tools.GreenLine($"-{randomItem.Name} has been added to your inventory!");
                Item.InventoryList.Add(randomItem);

                if (chanseOnWeaponLoot <= 1) //if 0 or 1 is rolled this drops (bad weapons)
                {
                    Tools.GreenLine($"-{Weapon.weapon.FullWeaponList[rndNr].Name} has been added to your inventory!");
                    Item.InventoryList.Add(Weapon.weapon.FullWeaponList[rndNr]);
                }
                else if (chanseOnWeaponLoot > 1) //if 2 or 3 is rolled this drops (better weapons)
                {
                    Tools.GreenLine($"-{Weapon.weapon.FullWeaponList[rndNr2].Name} has been added to your inventory!");
                    Item.InventoryList.Add(Weapon.weapon.FullWeaponList[rndNr2]);
                }

                Sleep(1400);
            }
            else if (Player.player.Lvl == 9)
            {
                Tools.GreenLine($"\n -{miniboss.RareLoot} has been added to your inventory!");
                var goldenEgg = new Item() { Name = miniboss.RareLoot, GoldIfSold = miniboss.RareLootGold, ItemLevel = 10 };
                Item.InventoryList.Add(goldenEgg);
            }
            Tools.PressEnterToContinue();

        }//ItemDrop END

        private static void FightingMenueText()
        {
            Console.WriteLine(" =========================");
            Console.WriteLine(" || [1] Attack......... ||");//The fighting is turn based. First you strike, than the monster will attack you
            Console.WriteLine(" || [2] Block Attack... ||");//Block attack, take reduced  or no dmg, and deal some back
            Console.WriteLine(" || [3] Healing.........||");//Take a swig from a potion, heals up health. Takes reduced damage while healing
            Console.WriteLine(" || [4] Run Away........||");//Tries to escape. Chance to be hit on the way out
            Console.WriteLine(" || [5] Exit Game.......||");
            Console.WriteLine(" =========================");
        }

        static public void Fight(Monster monster)
        {
            //Player
            int crit = rnd.Next(0, 20);
            int pDmg;
            int pIndex = Player.player.WeaponIndex;
            string wepName;
            string pName = Player.player.Name;

            //Monster
            string mName = monster.Name;

            if (pIndex >= 0) //if weapon is equipped
            {
                wepName = Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Name;
                pDmg = Player.player.BaseDamage + Player.player.WeaponDmg + crit;
            }
            else //wooden sword
            {
                wepName = "Wooden sword";
                pDmg = Player.player.BaseDamage + Player.player.WoodenSword; //wooden sword dmg dmg
            }

            while (Player.player.Alive && monster.Alive)
            {
                int monsterChanseOnHit = rnd.Next(1, 3); //33% chance to hit on escape
                int dodge = rnd.Next(1, 7); //% that the attack is dodged
                Console.Clear();

                //UI
                Logo.Fight();
                FightingMenueText();
                StatsDuringFight(monster); //Displays stats of the player and the monster

                while (readOnce == 0)
                {
                    Potions.Instantiate();
                    readOnce = 1;
                }

                input = Tools.ConvToInt32(5);

                switch (input)
                {
                    ////////////////
                    //   Attack  //
                    case 1:

                        Tools.YellowLine($"\n -{pName} Turn-");
                        Console.Write(" You raise your"); Tools.Purple($"{wepName}"); Console.WriteLine($" and attack the {monster.Name}!");
                        Sleep(1500);

                        if (dodge == 1)
                        {
                            Console.Write(" As you try to strike you stumble and"); Tools.Yellow("miss"); Console.WriteLine(" your attack...");
                            Sleep(1500);

                            if (monster is LastBoss)
                            {
                                Tools.YellowLine($"\n -{DemiLich.Name} Turn-");
                                Console.WriteLine($" You clumsily stumbles forward {monster.Name} slices you with a his icy dagger.\n ");
                                Tools.GreenLine($"{pName} health: -{DemiLich.Dmg / 2}");
                                Sleep(1500);
                                Player.player.Hp -= DemiLich.Dmg / 2; //Player takes half monster dmg
                            }
                            else
                            {
                                Tools.YellowLine($"\n -{mName} Turn-");
                                Console.WriteLine($" The {monster.Name} strikes you while you gather your wits.\n ");
                                Tools.GreenLine($"{pName} health: -{monster.Dmg / 2}");
                                Sleep(1500);
                                Player.player.Hp -= monster.Dmg / 2; //Player takes half monster dmg
                            }

                            Tools.PressEnterToContinue();

                            Player.CheckIfAlive();
                        }
                        else //Hit
                        {
                            if (monster is LastBoss)
                            {
                                Console.WriteLine($" With gathered courage you strike against the {DemiLich.Name}, he does not even flinch.\n ");  
                                Tools.RedLine($"{DemiLich.Name} health: -{pDmg}");
                                Sleep(1500);
                                DemiLich.Hp -= pDmg;
                            }
                            else
                            {
                                Console.WriteLine($" As you strike the {monster.Name}, it screams in pain.\n ");
                                Tools.RedLine($"{monster.Name} health: -{pDmg}");
                                Sleep(1500);
                                monster.Hp -= pDmg;
                            }
                        }

                        bool monsterAlive = monster.CheckIfAlive();

                        if (monsterAlive)
                        {
                            //Monsters turn to attack
                            Tools.YellowLine($"\n -{mName} Turn-");

                            specialAttack++;

                            if (monster is LastBoss && specialAttack % 2 == 1)
                            {
                                Console.WriteLine($" As you stare into the glowing ruby eyes of the {monster.Name}, you can feel your blood start to freeze..");
                                Console.WriteLine(" You can not seem to look away, his glare is paralyzing you momentarily in place..\n ");
                                Tools.GreenLine($"{pName} health: -{DemiLich.Dmg}");
                                Player.player.Hp -= DemiLich.Dmg;
                            }
                            else if (monster is LastBoss && specialAttack % 2 == 0)
                            {
                                Console.WriteLine($" Suddenly the {monster.Name} starts mumbling something..");
                                Console.WriteLine(" You can not quite hear what he's saying.. Thus, you are certain its words are ancient and power full.");
                                Console.WriteLine($" A second later the {monster.Name} bony hands starts to glow white.");
                                Console.WriteLine(" Ice is emerging in his hands from nothing, and before you realize feel a sharp sting in your chest.");
                                Console.WriteLine(" As you look down at your chest an ice lance has shattered on you and its fragments are protruding out from your skin..\n ");
                                Tools.GreenLine($"{pName} health: -{DemiLich.SpecialAttackPower}.");
                                Player.player.Hp -= DemiLich.SpecialAttackPower;
                            }
                            else if (monster is MiniBoss && specialAttack % 2 == 0)
                            {
                                Console.WriteLine($" With dark eyes the {monster.Name} fixates its gaze in your eyes..");
                                Console.WriteLine($" Without hesitation the {monster.Name} strikes you with a deafening blow.\n ");
                                Tools.GreenLine($"{pName} health: -{monster.Dmg}.");
                            }
                            else
                            {
                                Console.WriteLine($" The {monster.Name} takes a step back, and lunges towards you and hits you with a sweeping strike!\n");
                                Tools.GreenLine($"{pName} health: -{monster.Dmg}");
                                Player.player.Hp -= monster.Dmg;
                            }

                            Tools.PressEnterToContinue();

                            Player.CheckIfAlive();
                        }
                        else if (!monsterAlive)
                        {
                            if (monster is LastBoss)
                            {
                                Console.WriteLine($" As your last strike has landed the {DemiLich.Name} bones start to rattle as they fall down to the floor.");
                                Sleep(1600);
                                Console.WriteLine(" Just as soon as the bones hit the floorboards they instantaneously turn to dust.");
                                Sleep(1600);
                                Console.WriteLine($" As the dust settles left is only the eyes of the {DemiLich.Name}. ");
                                Sleep(1400);
                                Console.WriteLine(" 2 blood red rubies are all that is left.");
                                Sleep(1400);

                                Tools.PressEnterToContinue();

                                InfoAndStory.Outro();
                            }
                            else
                            {
                                Console.WriteLine($"\n As you prepare for one more attack on the {monster.Name},");
                                Sleep(1400);
                                Console.WriteLine(" you suddenly come to a halt when you see it laying lifeless right before you.");
                                Sleep(1400);
                                Console.WriteLine(" It has fallen dead onto the floor boards and blood is seeping from its wounds..\n");
                                Sleep(1400);
                                Tools.GreenLine($"+ {monster.ExpDrop} experience points!");
                                Tools.YellowLine($"+ {monster.GoldDrop} gold added to pouch!");

                                Player.player.Exp += monster.ExpDrop;
                                Player.player.Gold += monster.GoldDrop;
                                Player.CheckIfLvlUp(); //Checks if you can level up

                                ItemDrop();
                            }

                        }

                        break;

                    ////////////////
                    //   Block   //
                    case 2:

                        Tools.YellowLine($"\n -{pName} Turn-");
                        Console.WriteLine($" You raise your {wepName} in a defensive stance.");
                        Sleep(1400);

                        if (monsterChanseOnHit >= 1)// 66% chance on hit
                        {
                            Tools.YellowLine($"\n -{mName} Turn-");
                            Console.WriteLine($" The {monster.Name} strikes you with all their power and hits you for half the damage!");
                            Console.WriteLine(" Their attack was not that effective..");
                            Tools.GreenLine($"{pName} health: -{monster.Dmg / 2}");

                            Tools.PressEnterToContinue();

                            Player.player.Hp -= monster.Dmg / 2;
                            Player.CheckIfAlive();
                        }
                        else if (monsterChanseOnHit == 3)// 33% chance to miss
                        {
                            Tools.YellowLine($"\n -{mName} Turn-");
                            Console.WriteLine($" The {monster.Name} misses you with their attack and you quickly counter attack!");
                            Console.WriteLine($" You hit the {monster.Name} for half your damage.");
                            Tools.RedLine($"{mName} health: -{pDmg / 2}");

                            Tools.PressEnterToContinue();

                            monster.Hp -= pDmg / 2;
                            monster.CheckIfAlive();
                        }
                        Sleep(2000);

                        break;

                    /////////////////
                    //    Heal    //
                    case 3:
                        if (Player.player.Hp < Player.player.MaxHp)
                        {
                            bool success = false;
                            do
                            {
                                Tools.YellowLine("\n -Chose your potion-");
                                Tools.Yellow("1: Minor Healing Potion: ");
                                Tools.GreenLine($"{Player.player.MinorPotion} left");
                                Tools.Yellow("2: Greater Healing Potion: ");
                                Tools.GreenLine($"{Player.player.GreaterPotion} left");
                                Tools.Yellow("3: Major Healing Potion: ");
                                Tools.GreenLine($"{Player.player.MajorPotion} left\n");

                                int index = Tools.ConvToInt32(3);
                                Tools.YellowLine($"\n You open your bag and scramble for your {Potions.potionList[index - 1].Name}..");
                                Sleep(1500);

                                if (Potions.potionList[index - 1].Name == "Minor healing potion")
                                {
                                    if (Player.player.MinorPotion > 0)
                                    {
                                        Player.player.MinorPotion--;
                                        Console.WriteLine(" With a big chug you down its content.\n");
                                        Tools.GreenLine($"Health + {Potions.potionList[index - 1].Bonus}");

                                        success = true;
                                    }
                                    else
                                    {
                                        Tools.RedLine("You don't have any left!");
                                    }
                                }
                                else if (Potions.potionList[index - 1].Name == "Greater healing potion")
                                {
                                    if (Player.player.GreaterPotion > 0)
                                    {
                                        Player.player.GreaterPotion--;
                                        Console.WriteLine(" With a big chug you down the whole content.");
                                        Tools.GreenLine($"Health + {Potions.potionList[index - 1].Bonus}");

                                        success = true;
                                    }
                                    else
                                    {
                                        Tools.RedLine("You don't have any left!");
                                    }
                                }
                                else
                                {
                                    if (Player.player.MajorPotion > 0)
                                    {
                                        Player.player.MajorPotion--;
                                        Console.WriteLine(" With a big chug you down the whole content.");
                                        Tools.GreenLine($"Health + {Potions.potionList[index - 1].Bonus}");

                                        success = true;
                                    }
                                    else
                                    {
                                        Tools.RedLine("You don't have any left!");
                                    }
                                }

                                Player.player.Hp += Potions.potionList[index - 1].Bonus;

                                if (Player.player.Hp >= Player.player.MaxHp) //Corrects so that player cant heal for more than max hp
                                {
                                    Player.player.Hp = Player.player.MaxHp;
                                }

                                Tools.PressEnterToContinue();
                            } while (!success);
                        }
                        else
                        {
                            Tools.RedLine("Your health is already at max!");
                            Tools.PressEnterToContinue();
                        }
                        break;

                    ///////////////////
                    //   Run away   //
                    case 4:
                        Console.WriteLine("With darting eyes you look for the door you just came in from.");
                        Console.WriteLine("You turn around and head for the exit.");
                        Console.WriteLine($"But as you do the {monster.Name} takes a swing at you!");

                        if (monsterChanseOnHit >= 1) // 33% chance the monster hits you on your way out
                        {
                            Console.WriteLine($"The sweeping strike from the {monster.Name} hits you for as you try to run away.");
                            Tools.RedLine($"-{monster.Dmg / 2}");

                            Tools.PressEnterToContinue();

                            Player.player.Hp -= monster.Dmg / 2;
                            Player.CheckIfAlive();
                        }
                        else if (monsterChanseOnHit > 1)// 66% miss
                        {
                            Console.WriteLine($"The {monster.Name} barely misses you, as you slam the door shut.");

                            Tools.PressEnterToContinue();

                            MenuOptions.MainMenuSwitch(); //Back to menu
                        }
                        break;

                    ////////////////
                    //    Exit   //
                    case 5://Exit Game

                        Tools.ExitGame(false);
                        break;
                }//Switch end
            }//While (player and monster alive == true) end

            MenuOptions.MainMenuSwitch();
        }
    }
}