using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Labb3.Items;

namespace Labb3.Monsters
{
    [Serializable]

    public class Monster : IMonster
    {        
        public string Name { get; set; } 
        public int Lvl { get; set;} //level
        public int Hp { get; set;} //health (hit points)
        public int Dmg { get; set;} //damage
        public int ExpDrop { get; set;} //experience point drop. Obtained by player by killing monster
        public int GoldDrop { get; set; }//Obtained by player by killing monster
        public bool Alive { get; set; }

        public bool CheckIfAlive()
        {
            if(Hp <= 0)
            {
                Alive = false;
            }
            return Alive;
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
