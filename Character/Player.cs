using System;
using System.Collections.Generic;
using Labb3.UtilityTools;
using Labb3.Items;
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
        private int exp = 0; //experience points
        private int maxExp = 20; //Max exp before lvl up         
        private int maxHp = 175; //Max health
        private int hp = 175; //current health
        private int baseDamage = 20; //damage
        private int fistDamage = 30; //damage
        private int weaponDmg = 0; //weapon damage. dmg and weaponDmg will be added together during combat
        private int weaponIndex = -1; //set to -1 so fists can be set as a kind of starter weapon
        private string weaponName = ""; 
        private int gold = 0; //Obtains by killing monsters and selling stuff
        private int minorPotion = 1; //can be obtained from shop 
        private int greaterPotion = 0; //can be obtained from shop 
        private int majorPotion = 0; //can be obtained from  
        private static List<Weapon> myWeapons = new List<Weapon>();
        private static List<Item> myItems = new List<Item>();
        private static List<IItem> itemList = new List<IItem>();



        public string Name { get => name; set => name = value; }
        public int Id { get => id; set => id = value; }
        public bool Alive { get => alive; set => alive = value; }
        public int Lvl { get => lvl; set => lvl = value; }
        public int Exp { get => exp; set => exp = value; }
        public int MaxExp { get => maxExp; set => maxExp = maxExp * maxExp; } // doubles the exp needed to lvl up
        public int Hp { get => hp; set => hp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int BaseDamage { get => baseDamage; set => baseDamage = value; }
        public int FistDamage { get => fistDamage; set => fistDamage = value; }
        public int WeaponDmg { get => weaponDmg; set => weaponDmg = value; }
        public int WeaponIndex { get => weaponIndex; set => weaponIndex = value; }
        public string WeaponName { get => weaponName; set => weaponName = value; }
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
                    player.lvl++;

                    player.MaxHp += 25 * player.Lvl;
                    player.Hp = player.MaxHp;

                    player.BaseDamage += 5 * player.lvl;

                    Tools.Yellow("\n Level up!"); Tools.GreenLine($"New level = {player.Lvl}");
                    Tools.GreenLine($"  +{25 * player.Lvl} max health");
                    Tools.GreenLine($"  +{5 * player.Lvl} base damage");

                    
                }
                Sleep(4000);
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
                Console.WriteLine("You died! Game over!");
                Sleep(5000);
                Tools.ExitGame(false);
            }
        }

        //Displays iteams obtained by player, and shows the gold amount it sells for
        public static void DisplayInventory()
        {

            ItemList = Item.GetList();

            if (ItemList.Count == 0)
            {
                Tools.YellowLine("-Inventory is empty-\n");
                Sleep(1400);
                Tools.RedLine("Come back when you got something to sell!");
                Sleep(1400);
                Tools.RedLine("You filthy rat!");
                Sleep(1400);
            }
            else
            {
                for (int i = 0; i < ItemList.Count; i++)
                {
                    if (Player.player.WeaponName == ItemList[i].Name)
                    {
                        Tools.Yellow($"{1 + i}: {ItemList[i].Name}");
                        Tools.PurpleLine("- Equipped weapon - ");

                    }
                    else if (ItemList[i] is Weapon)
                    {
                        Tools.Yellow($"{1 + i}: {ItemList[i].Name}");

                        if (Weapon.weapon.WeaponList[i].Power < Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power)
                        {
                            Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold. ");
                            Tools.Red($" {Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power - Weapon.weapon.WeaponList[i].Power}");
                        }
                        else if(Weapon.weapon.WeaponList[i].Power == Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power)
                        {
                            Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold. ");
                            Tools.Red($" {Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power - Weapon.weapon.WeaponList[i].Power}");
                        }
                        else
                        {
                            Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold. ");
                            Tools.Green($" + {Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power - Weapon.weapon.WeaponList[i].Power}");
                        }
                    }
                    else
                    {
                        Tools.Yellow($"{i + 1}: {ItemList[i].Name}"); Tools.Green($"+{ItemList[i].GoldIfSold} gold if sold.\n");
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
                player.MajorPotion = 100;

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
    }
}
