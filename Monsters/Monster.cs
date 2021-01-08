using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Labb3.Items;

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

        public void MonsterGenerator()
        {
            Random rnd = new Random();
            Modifyers mod = new Modifyers();
            Monster goblin = new Monster();
            {
                name = "Goblin";
                level = 1;
                health = 40;
                power = 15;
                experienceDrop = 20;
                goldDrop = 50;                                
            }
            Monster thief = new Monster();
            {
                name = "Thief";
                level = 2;
                health = 80;
                power = 10 + mod.CritModifyer(5);
                experienceDrop = 55;
                goldDrop = 100;                                
            }
            Monster banshee = new Monster();
            {
                name = "Banshee";
                level = 3;
                health = 100;
                power = 5 + mod.CritModifyer(10);
                experienceDrop = 66;
                goldDrop = 75;                                
            }
            Monster necromancer = new Monster();
            {
                name = "Necromancer";
                level = 4;
                health = 70;
                power = 20 + mod.CritModifyer(50);
                experienceDrop = 100;
                goldDrop = rnd.Next(150, 250); ;                                
            }
            Monster cultist = new Monster();
            {
                name = "Cultist";
                level = 4;
                health = 70;
                power = 10 + mod.CritModifyer(20);
                experienceDrop = 100;
                goldDrop = rnd.Next(100, 200);
            }
            Monster mutant = new Monster();
            {
                name = "Mutant";
                level = 5;
                health = 250;
                power = 100 + mod.CritModifyer(20);
                experienceDrop = 160;
                goldDrop = rnd.Next(20, 200);
            }
            Monster hound = new Monster();
            {
                name = "Hound";
                level = 6;
                health = 300;
                power = 50 + mod.CritModifyer(70);
                experienceDrop = 266;
                goldDrop = rnd.Next(20,200);                                
            }
}
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
