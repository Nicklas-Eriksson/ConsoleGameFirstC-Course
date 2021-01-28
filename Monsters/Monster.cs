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
        public string RareLoot { get; set; } = "Golden egg";
        public int RareLootGold { get; set; } = 1000;

        public MiniBoss()
        {}
    }
    public class LastBoss : MiniBoss
    {
        public string SpecialAttackName { get; set; }
        public int SpecialAttackPower { get; set; }

        public LastBoss()
        {}
    }
}
