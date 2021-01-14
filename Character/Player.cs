﻿using System;
using System.Collections.Generic;
using System.Text;
using Labb3.UtilityTools;
using Labb3.Items;

namespace Labb3.Player
{
    public class Player
    {
        public static Player player = new Player();
        
        private string name;
        private int gold = 0;
        private int hp = 100; //health
        private int dmg = 10; //damage
        private int healingPotions = 1; //can be obtained from shop
        private int lvl = 1; //level
        private int exp = 0; //experience points

        public Player(string name, int gold, int hp, int dmg, int healingPotions, int lvl, int exp)
        {
            this.name = name;
            this.gold = gold;
            this.hp = hp;
            this.dmg = dmg;
            this.healingPotions = healingPotions;
            this.lvl = lvl;
            this.exp = exp;
        }
        public Player() { }//Empty constructor

        public string Name { get => name; set => name = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Hp { get => hp; set => hp = value; }
        public int Dmg { get => dmg; set => dmg = value; }
        public int HealingPotions { get => healingPotions; set => healingPotions = value; }
        public int Lvl { get => lvl; set => lvl = value; }
        public int Exp { get => exp; set => exp = value; }

    }
}