using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Labb3.Monsters
{
    public class Monster
    {
        private string name;
        private int level;
        private int health;
        private int power;
        private int experienceDrop;
        private int goldDrop;

        public string Name { get => name; set => name = value; }
        public int Level { get => level; set => level = value; }
        public int Health { get => health; set => health = value; }
        public int Power {get => power; set => power = value; }
        public int ExperienceDrop { get => experienceDrop; set => experienceDrop = value; }
        public int GoldDrop { get => goldDrop; set => goldDrop = value; }

        public Monster (string name, int level, int health, int power, int experienceDrop, int goldDrop)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.power = power;
            this.experienceDrop = experienceDrop;
            this.goldDrop = goldDrop;
        }      
        public Monster(){ }//Empty Constructor
    }
    public class MiniBoss : Monster
    {
        private string specialAttackName;
        private int specialAttackPower;
        private string loot;

        public string SpecialAttackName { get => specialAttackName; set => specialAttackName = value; }
        public int SpecialAttackPower { get => specialAttackPower; set => specialAttackPower = value; }
        public string Loot { get => loot; set => loot = value; }

        public MiniBoss(string specialAttackName, int specialAttackPower, string loot)
        {
            this.specialAttackName = specialAttackName;
            this.specialAttackPower = specialAttackPower;
            this.loot = loot;
        }
        public MiniBoss(){ }//Empty Constructor
    }
    public class LastBoss : MiniBoss
    {
        private string rareLoot;

        public string RareLoot { get => rareLoot; set => rareLoot = value; }

        public LastBoss (string rareLoot)
        {
            this.rareLoot = rareLoot;
        }
        public LastBoss(){ }//Empty Constructor
    }
}
