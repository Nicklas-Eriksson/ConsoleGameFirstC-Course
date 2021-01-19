using System;
using System.Collections.Generic;
using System.Text;
using Labb3.UtilityTools;
using Labb3.Items;
using static System.Threading.Thread;

namespace Labb3.Character
{
    public class Player
    {
        public static Player player = new Player();

        private string name;
        private bool alive = true;
        private int gold = 100; //Will be sufficient for 1 of the 3 starter weapons in the store
        private int hp = 100; //health
        private int maxHp = 100; //health
        private int dmg = 10; //damage
        private int weaponDmg = 0; //damage
        private int healingPotions = 1; //can be obtained from shop
        private int lvl = 1; //level
        private int exp = 0; //experience points
        private int maxExp = 0; //Max exp before lvl up
        private int killsToLevel = 1; //Kills needed for each lvl        
        private int weaponIndex = -1;
        private bool lvlUp = false;
        private List<Weapon> inventoryList = new List<Weapon>();

        public string Name { get => name; set => name = value; }
        public bool Alive { get => alive; set => alive = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Hp { get => hp; set => hp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int Dmg { get => dmg; set => dmg = value; }
        public int WeaponDmg { get => weaponDmg; set => weaponDmg = value; }
        public int HealingPotions { get => healingPotions; set => healingPotions = value; }
        public int Lvl { get => lvl; set => lvl = value; }
        public int Exp { get => exp; set => exp = MaxExp / KillsToLevel; }
        public int MaxExp { get => maxExp; set => maxExp = maxExp * 2; }
        public int KillsToLevel { get => killsToLevel; set => killsToLevel = Exp * Lvl; }
        public int WeaponIndex { get => weaponIndex; set => weaponIndex = value; }
        public bool LvlUp { get => lvlUp; set => lvlUp = value; }
        public List<Weapon> InventoryList { get => inventoryList; set => inventoryList = value; }

        public static void ExpToLvl()
        {

            if (player.lvl < 10)
            {
                if (player.Exp >= player.MaxExp)
                {
                    player.Exp -= player.MaxExp;
                    player.lvl++;
                }
                Sleep(2000);
            }
        }

        static public void CheckIfAlive()
        {
            if (Player.player.Hp <= 0)
            {
                Player.player.Alive = false;
                Console.WriteLine("You died! Game over!");
                Sleep(5000);
                Tools.ExitGame();
            }
        }

        public static void DisplayInventory()
        {
            for (int i = 0; i < player.InventoryList.Count; i++)
            {
                Tools.YellowLine($"{i+1}: {player.InventoryList[i].Name} - sell for {player.InventoryList[i].GoldIfSold} gold\n");
            }

        }

        public static void GodMode()
        {
            if(player.Name == "Hakk" || player.Name == "hakk" || player.Name == "Robin" || player.Name == "Robin Kamo" || player.Name == "robin" || player.Name == "robin kamo")
            {
                player.MaxHp = 1000000;
                player.Dmg = 1000000;
                player.Gold = 1000000;
                player.HealingPotions = 100;

                Tools.YellowLine("-God mode activated-");
                Console.Write("Health:");
                Tools.GreenLine($"{player.MaxHp}");
                Console.Write("Power:");
                Tools.RedLine($"{player.Dmg}");
                Console.Write("Gold:");
                Tools.YellowLine($"{player.Gold}");
                Console.Write("Potions:");
                Tools.GreenLine($"{player.HealingPotions}");
            }
        }
    }
}
