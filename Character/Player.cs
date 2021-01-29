using Labb3.Items;
using Labb3.Menues;
using Labb3.UtilityTools;
using System;
using System.Collections.Generic;
using static System.Threading.Thread;

namespace Labb3.Character
{
    [Serializable]
    public class Player
    {
        public static Player player = new Player();

        private string name;
        private int id;
        private bool alive = true;
        private int lvl = 1; //level
        private int exp; //experience points
        private int maxExp = 20; //Max exp before lvl up
        private int maxHp = 175; //Max health
        private int hp = 175; //current health
        private int baseDamage = 20; //damage
        private int woodenSword = 30; //damage
        private int weaponDmg; //weapon damage. dmg and weaponDmg will be added together during combat
        private int weaponIndex = -1; //set to -1 so wooden sword can be set as a kind of starter weapon
        private int gold; //Obtains by killing monsters and selling stuff
        private int minorPotion = 1; //can be obtained from shop
        private int greaterPotion; //can be obtained from shop
        private int majorPotion; //can be obtained from shop
        private static List<Weapon> myWeapons = new List<Weapon>();
        private static List<Item> myItems = new List<Item>();
        private static List<IItem> itemList = new List<IItem>();

        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public bool Alive { get => alive; set => alive = value; }
        public int Lvl { get => lvl; set => lvl = value; }
        public int Exp { get => exp; set => exp = value; }
        public int MaxExp { get => maxExp; set => maxExp = value; }
        public int Hp { get => hp; set => hp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int BaseDamage { get => baseDamage; set => baseDamage = value; }
        public int WoodenSword { get => woodenSword; set => woodenSword = value; }
        public int WeaponDmg { get => weaponDmg; set => weaponDmg = value; }
        public int WeaponIndex { get => weaponIndex; set => weaponIndex = value; }
        public int Gold { get => gold; set => gold = value; }
        public int MinorPotion { get => minorPotion; set => minorPotion = value; }
        public int GreaterPotion { get => greaterPotion; set => greaterPotion = value; }
        public int MajorPotion { get => majorPotion; set => majorPotion = value; }
        public static List<Weapon> MyWeapons { get => myWeapons; set => myWeapons = value; }
        public static List<Item> MyItems { get => myItems; set => myItems = value; }
        public static List<IItem> ItemList { get => itemList; set => itemList = value; }

        //Method for leveling the character
        public static void CheckIfLvlUp()
        {
            if (player.lvl < 10)
            {
                if (player.Exp >= player.MaxExp)
                {
                    player.Exp -= player.MaxExp; //if say player has 220 / 200 exp, he will lvl up and have 20 / 250 exp
                    player.MaxExp *= 2;
                    player.lvl++;

                    player.MaxHp += 20 * player.Lvl;
                    player.Hp = player.MaxHp;

                    player.BaseDamage += 5 * player.lvl;

                    Tools.Yellow("\n Level up!"); Tools.GreenLine($"New level = {player.Lvl}");
                    Tools.GreenLine($"  +{20 * player.Lvl} max health");
                    Tools.GreenLine($"  +{5 * player.Lvl} base damage");
                }
            }
            else
            {
                Player.player.Exp = Player.player.MaxExp;
            }
        }

        //Method for checking if character is dead or alive after a fight
        public static void CheckIfAlive()
        {
            if (Player.player.Hp <= 0)
            {
                Player.player.Alive = false;
                Tools.ExitGame(false);
            }
        }

        private static int wIndex = 0;
        //Displays items obtained by player, and shows the gold amount it sells for
        public static void DisplayInventory()
        {
            ItemList.Clear();
            ItemList.AddRange(Item.GetList());

            Console.WriteLine("\n\n");

            if (ItemList.Count == 0)
            {
                Tools.YellowLine("-Inventory is empty-\n");

                //MenuOptions.MainMenuSwitch();
            }
            else
            {
                for (int i = 0; i < ItemList.Count; i++)
                {
                    if (Player.player.WeaponIndex >= 0)
                    {
                        if (Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Name == ItemList[i].Name)
                        {
                            Tools.Yellow($"{1 + i}: {ItemList[i].Name}");
                            Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold. ");
                            Tools.PurpleLine("- Equipped weapon - ");
                        }
                        else if (ItemList[i] is Weapon)
                        {
                            Tools.Yellow($"{1 + i}: {ItemList[i].Name}");

                            for (int j = 0; i < Weapon.weapon.FullWeaponList.Count; j++)
                            {
                                if (Weapon.weapon.FullWeaponList[j].Name == ItemList[i].Name)
                                {
                                    wIndex = j;
                                    break;
                                }
                            }

                            //if player weapon is stronger than other weapons in inventory, display power difference
                            if (Weapon.weapon.FullWeaponList[wIndex].Power < Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power)
                            {
                                Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold. ");
                                Tools.RedLine($" {Weapon.weapon.FullWeaponList[wIndex].Power - Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power} attack damage.");
                            }
                            //if player weapon got same power as another weapon in inventory, display power difference
                            else if (Weapon.weapon.FullWeaponList[wIndex].Power == Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power)
                            {
                                Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold. ");
                                Tools.BlueLine("Same attack damage as equipped weapon.");
                            }
                            //if player weapon is weaker than other weapons in inventory, display power difference
                            else
                            {
                                Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold. ");
                                Tools.GreenLine($"{Weapon.weapon.FullWeaponList[wIndex].Power - Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power} attack damage.");
                            }
                        }
                        else
                        {
                            Tools.Yellow($"{i + 1}: {ItemList[i].Name}"); Tools.GreenLine($"+{ItemList[i].GoldIfSold} gold if sold.");
                        }
                    }
                    else //if player don't have weapon (index will be -1)
                    {
                        if (ItemList[i] is Weapon)
                        {
                            Tools.Yellow($"{1 + i}: {ItemList[i].Name}");
                            Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold. ");
                            Tools.GreenLine($"+{Weapon.weapon.FullWeaponList[wIndex].Power} attack damage.");
                        }
                        else
                        {
                            Tools.Yellow($"{i + 1}: {ItemList[i].Name}"); Tools.GreenLine($"+{ItemList[i].GoldIfSold} gold if sold.");
                        }
                    }
                }
            }
        }

        //Cheat codes for when character name is given
        public static void GodMode()
        {
            if (player.Name == "Hakk" || player.Name == "hakk" || player.Name == "Robin" || player.Name == "Robin Kamo" || player.Name == "robin" || player.Name == "robin kamo")
            {
                player.MaxHp = 1000000;
                player.BaseDamage = 1000000;
                player.Gold = 1000000;
                player.MajorPotion = 5;

                Tools.YellowLine("-God mode activated-");
                Console.Write("Health:");
                Tools.GreenLine($"{player.MaxHp}");
                Console.Write("Power:");
                Tools.RedLine($"{player.BaseDamage}");
                Console.Write("Gold:");
                Tools.YellowLine($"{player.Gold}");
                Console.Write("Potions:");
                Tools.GreenLine($"  -Minor Healing Potions: {player.MinorPotion}");
                Tools.GreenLine($"  -Greater Healing Potions: {player.GreaterPotion}");
                Tools.GreenLine($"  -Major Healing Potions: {player.MajorPotion}");
            }
        }
        public static void ResetPlayer()
        {
            player.Name = "";
            player.Id = Player.player.id++;
            player.Alive = true;
            player.Lvl = 1;
            player.Exp = 0;
            player.MaxExp = 20;
            player.MaxHp = 175;
            player.Hp = 175;
            player.BaseDamage = 20;
            player.WoodenSword = 30;
            player.WeaponDmg = 0;
            player.WeaponIndex = -1;
            player.Gold = 0;
            player.MinorPotion = 1;
            player.GreaterPotion = 0;
            player.MajorPotion = 0;
            player.MajorPotion = 0;
            player.MajorPotion = 0;
            Player.MyWeapons.Clear();
            Player.MyItems.Clear();
            Player.ItemList.Clear();
        }
    }
}