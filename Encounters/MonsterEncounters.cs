using Labb3.UtilityTools;
using System;
using System.Collections.Generic;
using Labb3.Monsters;
using Labb3.Items;
using Labb3.Character;
using static System.Threading.Thread;
using Labb3.Menues;
using Labb3.Story;

namespace Labb3.Encounters
{
    [Serializable]

    public class MonsterEncounters
    {
        private static LastBoss demiLich = new LastBoss();
        private static MiniBoss miniboss = new MiniBoss();
        private static Random rnd = new Random();
        private static int input;
        private static int readOnce = 0;
        private static int specialAttack = 0;

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
            List<string> miniBossNames = new List<string>() { "Azathoth", "B'gnu-Thun", "Bokrug", "Cthulhu", "Dagon", "Dimensional Shambler", "Dunwich Horror", "Formless Spawn", "Ghatanothoa", "Gloon", "Gnoph-Keh", "Great Old One", "Yog-Sothoth", "Yuggoth", "Innsmouth", "Shoggoth", "Outer God", "Nightgaut", "Nyarlathotep" };

            int[] expDropArray = new int[9] { 20, 23, 27, 41, 54, 92, 161, 285, 513 };
            int monsterIndex = rnd.Next(0, monsterNames.Count);
            int monsterIndex2 = rnd.Next(0, miniBossNames.Count);
            int bonusDmg = rnd.Next(1, 15);
            int bonusGold = rnd.Next(5, 20);
            //int upOrDown = rnd.Next(0, 2);
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
                    Hp = 500 * (Player.player.Lvl + 1),
                    Dmg = 450 + (bonusDmg * 5),
                    ExpDrop = expDropArray[Player.player.Lvl - 1],
                    GoldDrop = 500,
                    Alive = true
                };

                Fight(miniBoss);
            }
            else
            {
                demiLich.Name = "Demi-Lich";
                demiLich.Lvl = 11;
                demiLich.Hp = 10000;
                demiLich.Dmg = 700 + (bonusDmg * 5);
                demiLich.SpecialAttackName = "Ice lance";
                demiLich.SpecialAttackPower = 1000;
                demiLich.Alive = true;

                Fight(demiLich);
            }            
        }

        static void StatsDuringFight(Monster monster)
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
            Tools.GreenLine($"Health: {Player.player.Hp}");
            Tools.Yellow("||");
            Tools.GreenLine($"Healing Potions:");
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
            var randomItem = Item.StuffGenerator();

            //20% chanse a weapon drops
            int rndChanse = rnd.Next(0, 6);
            int rndChanse2 = rnd.Next(0, 5);

            //So weapons with index of 0 ti 14 can drop from mobs
            int rndNr = rnd.Next(0, 3);
            int rndNr2 = rnd.Next(3, 7);
            int rndNr3 = rnd.Next(7, 11);
            int rndNr4 = rnd.Next(11, 15);

            List<IItem> itemList = new List<IItem>();

            if (rndChanse == 0 && Player.player.Lvl < 9) //1 in 5 a weapon will drop
            {
                Tools.YellowLine("\n Loot spontaniously appears from thin air!");
                Sleep(1400);
                Tools.YellowLine("Remarkable!\n");
                Sleep(1400);

                if (rndChanse2 <= 1)
                {
                    Tools.GreenLine($"{Weapon.weapon.FullWeaponList[rndNr].Name} has been added to your inventory!");
                    itemList.Add(Weapon.weapon.FullWeaponList[rndNr]);
                    Item.SetList(itemList);

                }
                else if (rndChanse2 == 2)
                {
                    Tools.GreenLine($"{Weapon.weapon.FullWeaponList[rndNr2].Name} has been added to your inventory!");
                    itemList.Add(Weapon.weapon.FullWeaponList[rndNr2]);
                    Item.SetList(itemList);
                    if (rndNr == 1)
                    {
                        Tools.GreenLine($"\n {randomItem.Name} has been added to your inventory!");
                        itemList.Add(randomItem);
                        Item.SetList(itemList);
                    }
                }
                else if (rndChanse2 == 3)
                {
                    Tools.GreenLine($"{Weapon.weapon.FullWeaponList[rndNr3].Name} has been added to your inventory!");
                    itemList.Add(Weapon.weapon.FullWeaponList[rndNr3]);
                    Item.SetList(itemList);
                }
                else if (rndChanse2 == 4)
                {
                    Tools.GreenLine($"{Weapon.weapon.FullWeaponList[rndNr4].Name} has been added to your inventory!");
                    itemList.Add(Weapon.weapon.FullWeaponList[rndNr4]);
                    Item.SetList(itemList);
                }

                Sleep(2000);
            }
            else if (Player.player.Lvl == 9)
            {
                Tools.GreenLine($"\n {miniboss.RareLoot} has been added to your inventory!");
                var goldenEgg = new Item() { Name = "Golden egg", GoldCost = 1000, GoldIfSold = 10000, ItemLevel = 10 };
                itemList.Add(goldenEgg);
            }

            if (rndNr == 1) // 33% to drop extra trash
            {
                Sleep(1400);
                Tools.GreenLine($"{randomItem.Name} has been added to your inventory!");
                itemList.Add(randomItem);
                Item.SetList(itemList);
            }

            Sleep(2000);

            Tools.PressEnterToContinue();

        }//ItemDrop END

        static void FightingMenueText()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("|| [1] Attack......... ||");//The fighting is turn based. First you strike, than the monster will attack you
            Console.WriteLine("|| [2] Block Attack... ||");//Block attack, take reduced  or no dmg, and deal some back
            Console.WriteLine("|| [3] Healing.........||");//Take a swig from a potion, heals up health. Takes reduced damage while healing
            Console.WriteLine("|| [4] Run Away........||");//Tries to escape. Chanse to be hit on the way out
            Console.WriteLine("|| [5] Exit Game.......||");
            Console.WriteLine("=========================");
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
            else //fists
            {
                wepName = "Fists";
                pDmg = Player.player.BaseDamage + Player.player.FistDamage; //fist dmg
            }

            while (Player.player.Alive == true && monster.Alive == true)
            {
                int monsterChanseOnHit = rnd.Next(1, 3); //33% chance to hit on escape
                int dodge = rnd.Next(1, 5); //20% that the attack is dodged
                Console.Clear();

                //UI
                Logo.Fight();
                FightingMenueText();
                StatsDuringFight(monster);

                while (readOnce == 0)//hmm
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
                        Console.Write($"\n You raise your"); Tools.Purple($"{wepName}"); Console.WriteLine($" and attack the {monster.Name}!");
                        Sleep(1500);

                        if (dodge == 1)
                        {
                            Console.Write(" As you try to strike you stumble and"); Tools.Yellow("miss"); Console.WriteLine(" your attack...");
                            Sleep(1500);

                            if (monster is LastBoss)
                            {
                                Tools.YellowLine($"\n -{demiLich.Name} Turn-");
                                Console.WriteLine($" As you clumsily stumbles forward {monster.Name} slices you with a his dagger seemingly made from ice.\n ");
                                Tools.GreenLine($"{pName} health: -{demiLich.Dmg / 2}");
                                Sleep(1500);
                                Player.player.Hp -= demiLich.Dmg / 2; //Player takes half monster dmg  
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
                                Console.WriteLine($" With gathered curage you strike against the {demiLich.Name}, he does not even flintch.\n ");
                                Sleep(1500);
                                Tools.RedLine($"{demiLich.Name} health: -{pDmg}");
                                Sleep(1500);
                                demiLich.Hp -= pDmg;
                            }
                            else
                            {
                                Console.WriteLine($" As you strike the {monster.Name}, it screams in pain.\n ");
                                Sleep(1500);
                                Tools.RedLine($"{monster.Name} health: -{pDmg}");
                                Sleep(1500);
                                monster.Hp -= pDmg;
                            }

                            Player.CheckIfAlive();
                        }

                        bool monsterAlive = monster.CheckIfAlive();

                        if (!monsterAlive)
                        {
                            if (monster is LastBoss)
                            {
                                Console.WriteLine($" As your last strike has landed the {demiLich.Name} bones start to rattle as they fall down to the floor.");
                                Sleep(1600);
                                Console.WriteLine(" Just as soon as the bones hit the floorboards they instantaniously turn to dust.");
                                Sleep(1600);
                                Console.WriteLine($" As the dust settles left is only the eyes of the {demiLich.Name}. ");
                                Sleep(1400);
                                Console.WriteLine(" 2 blood red rubys are all that is left.");
                                Sleep(1400);

                                Tools.PressEnterToContinue();

                                Messange.Outro();
                            }
                            else
                            {
                                Console.WriteLine($"\n As you prepare for one more attack on the {monster.Name},");
                                Sleep(1400);
                                Console.WriteLine($" you suddenly come to a halt when you see it laying lifeless right before you.");
                                Sleep(1400);
                                Console.WriteLine($" It has fallen dead onto the floor boards and blood is seeping from its wounds..\n");
                                Sleep(1400);
                                Tools.GreenLine($"+ {monster.ExpDrop} experience points!");
                                Tools.YellowLine($"+ {monster.GoldDrop} gold added to pouch!");

                                Player.player.Exp += monster.ExpDrop;
                                Player.player.Gold += monster.GoldDrop;
                                Player.CheckIfLvlUp(); //Cheks if you can level up

                                ItemDrop();
                            }

                            Sleep(3000);
                        }
                        else if (monsterAlive)
                        {
                            //Monsters turn to attack
                            Tools.YellowLine($"\n-{mName} Turn-");

                            specialAttack++;

                            if (specialAttack % 2 == 0 && monster is MiniBoss)
                            {
                                Console.WriteLine($" With dark eys the {monster.Name} fixates its gaze in your eyes..");
                                Sleep(1400);
                                Console.WriteLine($" Without hesitation the {monster.Name} strikes you with a deafening blow.\n ");
                                Sleep(1400);
                                Tools.GreenLine($"{pName} health: -{monster.Dmg}.");
                            }
                            else if (specialAttack % 2 == 1 && monster is LastBoss)
                            {
                                Console.WriteLine($" As you stare into the glowing ruby eyes of the {monster.Name}, you can feel your blood start to freeze..");
                                Sleep(3000);
                                Console.WriteLine($" You can not seem to look away, his glare is paralyzing you momentarily in place..\n ");
                                Sleep(1400);
                                Tools.GreenLine($"{pName} health: -{demiLich.Dmg}");
                                Player.player.Hp -= demiLich.Dmg;
                            }
                            else if (specialAttack % 2 == 0 && monster is LastBoss)
                            {
                                Console.WriteLine($" Suddenly the {monster.Name} starts mubeling something..");
                                Sleep(1400);
                                Console.WriteLine($" You can not quite heare what he's saying.. Thus, you are sertain its words are ancient and powerfull.");
                                Sleep(1400);
                                Console.WriteLine($" A second later the {monster.Name} bony hands starts to glow white.");
                                Sleep(1400);
                                Console.WriteLine($" Ice is emerging in his hands from nothing, and before you realize feel a sharp sting in your chest.");
                                Sleep(1400);
                                Console.WriteLine(" As you look down at your chest an ice lance has shattered on you and its fragments are protruding out from your skin..\n ");
                                Sleep(1400);
                                Tools.GreenLine($"{pName} health: -{demiLich.SpecialAttackPower}.");
                                Player.player.Hp -= demiLich.SpecialAttackPower;
                            }
                            else
                            {
                                Console.WriteLine($" The {monster.Name} takes a step back, and lunges towards you and hits you with a sweeping strike!\n");
                                Sleep(1400);
                                Tools.GreenLine($"{pName} health: -{monster.Dmg}");
                                Player.player.Hp -= monster.Dmg;
                            }

                            Tools.PressEnterToContinue();

                            Player.CheckIfAlive();
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
                            Console.WriteLine($" Their attack was not that effective..");
                            Sleep(2000);
                            Tools.GreenLine($"{pName} health: -{monster.Dmg / 2}");
                            Sleep(1400);

                            Tools.PressEnterToContinue();

                            Player.player.Hp -= monster.Dmg / 2;
                            Player.CheckIfAlive();
                        }
                        else if (monsterChanseOnHit == 3)// 33% chance to miss
                        {
                            Tools.YellowLine($"\n -{mName} Turn-");
                            Console.WriteLine($" The {monster.Name} misses you with their attack and you quickly counter attack!");
                            Sleep(1400);
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
                                Tools.GreenLine($"{Player.player.MajorPotion} left");

                                int index = Tools.ConvToInt32(3);
                                Tools.YellowLine($" You open your bag and scramble for your {Potions.itemList[index - 1].Name}..");
                                Sleep(1500);

                                if (Potions.itemList[index - 1].Name == "Minor healing potion")
                                {
                                    if (Player.player.MinorPotion > 0)
                                    {
                                        Player.player.MinorPotion--;
                                        Console.WriteLine(" With a big chug you down its content.");
                                        Tools.GreenLine($"Health + {Potions.itemList[index - 1].Bonus}");

                                        success = true;
                                    }
                                    else
                                    {
                                        Tools.RedLine("You don't have any left!");
                                    }
                                }
                                else if (Potions.itemList[index - 1].Name == "Greater healing potion")
                                {
                                    if (Player.player.GreaterPotion > 0)
                                    {
                                        Player.player.GreaterPotion--;
                                        Console.WriteLine(" With a big chug you down the whole content.");
                                        Tools.GreenLine($"Health + {Potions.itemList[index - 1].Bonus}");

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
                                        Tools.GreenLine($"Health + {Potions.itemList[index - 1].Bonus}");

                                        success = true;
                                    }
                                    else
                                    {
                                        Tools.RedLine("You don't have any left!");
                                    }
                                }

                                Player.player.Hp += Potions.itemList[index - 1].Bonus;

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
                            Sleep(2000);
                        }
                        break;

                    ///////////////////
                    //   Run away   //
                    case 4:
                        Console.WriteLine("With darting eyes you look for the door you just came in from.");
                        Sleep(1400);
                        Console.WriteLine("You turn around and head for the exit.");
                        Sleep(1400);
                        Console.WriteLine($"But as you do the {monster.Name} takes a swing at you!");
                        Sleep(1400);

                        if (monsterChanseOnHit >= 1) // 33% chace the monster hits you on your way out
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
