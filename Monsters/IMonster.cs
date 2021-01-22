using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Monsters
{
    public interface IMonster
    {
        string Name { get; set; }
        int Lvl { get; set; }
        int Hp { get; set; }
        int Dmg { get; set; }
        int ExpDrop { get; set; }
        int GoldDrop { get; set; }
        bool Alive { get; set; }

        bool CheckIfAlive();
    }
}
