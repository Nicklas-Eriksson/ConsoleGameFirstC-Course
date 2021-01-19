using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    interface IPowerUp
    {
        string name { get; set; }
        int goldCost { get; set; }

        void Bonus(string type);
        
    }
}
