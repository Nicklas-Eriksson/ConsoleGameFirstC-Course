using System;
using System.Collections.Generic;
using System.Text;
using Labb3.UtilityTools;
using Labb3.Items;

namespace Labb3.Player
    {
    public class CurrentPlayer
    {
        private string name;
        private int gold = 0;
        private int health = 100;
        private int damage = 10;
        private int healingPotions = 1;
        private int level = 1;
        private int experience = 0;

        public CurrentPlayer(string name, int gold, int health, int damage, int healingPotions, int level, int experience)
        {
            this.name = name;
            this.gold = gold;
            this.health = health;
            this.damage = damage;
            this.healingPotions = healingPotions;
            this.level = level;
            this.experience = experience;
        }
        public CurrentPlayer() { }//Empty constructor

        public string Name { get => name; set => name = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Health { get => health; set => health = value; }
        public int Damage { get => damage; set => damage = value; }
        public int HealingPotions { get => healingPotions; set => healingPotions = value; }
        public int Level { get => level; set => level = value; }
    }
    

    //maby this fits in nice here
    public class Inventory
    {
       //hmm
    }
}
