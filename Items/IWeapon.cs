using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    //KOmmer tillbaka hit när jag förstår interfaces bättre
    public interface IWeapon
    {
        string name { get; set; }
        int itemlevel { get; set; }
        int power { get; set; }
        int crit { get; set; }
    }
}
