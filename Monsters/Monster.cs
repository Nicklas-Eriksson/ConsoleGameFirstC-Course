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
