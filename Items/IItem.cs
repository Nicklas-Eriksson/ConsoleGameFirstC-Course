using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    public interface IItem
    {
        string name { get; set; }
        int goldCost { get; set; }
        int itemLevel { get; set; }
        int bonus { get; set; }
       

        void Instantiate();

    }
}
