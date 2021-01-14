using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Labb3.Items;

namespace Labb3.Monsters
{
    public class Monster : IMonster
    {
        public static Monster monster = new Monster();
        public string name { get; set; } 
        public int lvl { get; set;} //level
        public int hp { get; set;} //health (hit points)
        public int dmg { get; set;} //damage
        public int expDrop { get; set;} //experience point drop. Obtained by player by killing monster
        public int goldDrop { get; set; }//Obtained by player by killing monster


        //private string name;
        //private int level;
        //private int health;
        //private int power;
        //private int experienceDrop;
        //private int goldDrop;

        //public string Name { get => name; set => name = value; }
        //public int Level { get => level; set => level = value; }
        //public int Health { get => health; set => health = value; }
        //public int Power { get => power; set => power = value; }
        //public int ExperienceDrop { get => experienceDrop; set => experienceDrop = value; }
        //public int GoldDrop { get => goldDrop; set => goldDrop = value; }

        //public Monster(string name, int level, int health, int power, int experienceDrop, int goldDrop)
        //{
        //    this.name = name;
        //    this.level = level;
        //    this.health = health;
        //    this.power = power;
        //    this.experienceDrop = experienceDrop;
        //    this.goldDrop = goldDrop;
        //}
        //public Monster() { }//Empty Constructor

        public List<IMonster> MonsterGenerator()
        {
            Random rnd = new Random();
            Modifyers mod = new Modifyers();

            Monster goblin = new Monster();
            {
                name = "Goblin";
                lvl = Player.Player.player.Lvl;
                hp = 500;
                dmg = 15;
                expDrop = 20;
                goldDrop = 100;
            }
            Monster thief = new Monster();
            {
                name = "Thief";
                lvl = Player.Player.player.Lvl;
                hp = 700;
                dmg = 10 + mod.CritModifyer(5);
                expDrop = 55;
                goldDrop = 100;
            }
            Monster banshee = new Monster();
            {
                name = "Banshee";
                lvl = Player.Player.player.Lvl;
                hp = 1000;
                dmg = 5 + mod.CritModifyer(10);
                expDrop = 66;
                goldDrop = 75;
            }
            Monster necromancer = new Monster();
            {
                name = "Necromancer";
                lvl = Player.Player.player.Lvl;
                hp = 1500;
                dmg = 20 + mod.CritModifyer(50);
                expDrop = 100;
                goldDrop = rnd.Next(150, 250); ;
            }
            Monster cultist = new Monster();
            {
                name = "Cultist";
                lvl = Player.Player.player.Lvl;
                hp = 1800;
                dmg = 10 + mod.CritModifyer(20);
                expDrop = 100;
                goldDrop = rnd.Next(100, 200);
            }
            Monster mutant = new Monster();
            {
                name = "Mutant";
                lvl = Player.Player.player.Lvl;
                hp = 2000;
                dmg = 100 + mod.CritModifyer(20);
                expDrop = 160;
                goldDrop = rnd.Next(20, 200);
            }
            Monster hound = new Monster();
            {
                name = "Hound";
                lvl = Player.Player.player.Lvl;
                hp = 2500;
                dmg = 50 + mod.CritModifyer(70);
                expDrop = 266;
                goldDrop = rnd.Next(20, 200);
            }
            Monster elderThing = new Monster();
            {
                name = "Elder Thing";
                lvl = Player.Player.player.Lvl;
                hp = 3000;
                dmg = 70 + mod.CritModifyer(70);
                expDrop = 458;
                goldDrop = rnd.Next(50, 200);
            }
            Monster silentOne = new Monster();
            {
                name = "Silent One";
                lvl = Player.Player.player.Lvl;
                hp = 4000;
                dmg = 80 + mod.CritModifyer(80);
                expDrop = 800;
                goldDrop = rnd.Next(50, 200);
            }
            Monster deepOne = new Monster();
            {
                name = "Deep One";
                lvl = Player.Player.player.Lvl;
                hp = 5000;
                dmg = 100 + mod.CritModifyer(100);
                expDrop = 1422;
                goldDrop = rnd.Next(50, 200);
            }
            Monster demiLich = new Monster();
            {
                name = "Demi-Lich";
                lvl = Player.Player.player.Lvl;
                hp = 10000;
                dmg = 155 + mod.CritModifyer(155);
                expDrop = 10000;
                goldDrop = 10000;
            }

            List<IMonster> monsterList = new List<IMonster>();
            monsterList.Add(goblin);
            monsterList.Add(thief);
            monsterList.Add(banshee);
            monsterList.Add(necromancer);
            monsterList.Add(mutant);
            monsterList.Add(hound);
            monsterList.Add(elderThing);
            monsterList.Add(silentOne);
            monsterList.Add(deepOne);
            monsterList.Add(demiLich);

            return monsterList;
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
        public MiniBoss() { }//Empty Constructor
    }
    public class LastBoss : MiniBoss
    {
        private string rareLoot;

        public string RareLoot { get => rareLoot; set => rareLoot = value; }

        public LastBoss(string rareLoot)
        {
            this.rareLoot = rareLoot;
        }
        public LastBoss() { }//Empty Constructor
    }
}
