using System;

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
        private string rareLoot = "Golden egg";
        private int rareLootGold = 1000;
        
        public string RareLoot { get => rareLoot; set => rareLoot = value; }
        public int RareLootGold { get => rareLootGold; set => rareLootGold = value; }


        public MiniBoss()
        {}
    }
    public class LastBoss : MiniBoss
    {
        private string specialAttackName;
        private int specialAttackPower;

        public string SpecialAttackName { get => specialAttackName; set => specialAttackName = value; }
        public int SpecialAttackPower { get => specialAttackPower; set => specialAttackPower = value; }

        public LastBoss()
        {}
    }
}
