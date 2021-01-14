using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Monsters
{
    public interface IMonster
    {
        string name { get; set; }
        int lvl { get; set; }
        int hp { get; set; }
        int dmg { get; set; }
        int expDrop { get; set; }
        int goldDrop { get; set; }
    }
}
