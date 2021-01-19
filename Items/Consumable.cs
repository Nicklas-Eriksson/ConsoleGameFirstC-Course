using Labb3.Character;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    public class Consumable : IItem
    {
       public static Consumable pot = new Consumable();

        public string name { get => name; set => name = value; }
        public int goldCost { get => goldCost; set => goldCost = value; }
        public int itemLevel { get => itemLevel; set => itemLevel = value; }
        public int bonus { get => bonus; set => bonus = value; }
        public List<IItem> itemList { get => itemList; set => itemList = value; }




        public List<IItem> Type(string type)
        {
            Consumable lesserHealing = new Consumable()
            {
                name = "Lesser Healing Potion",
                goldCost = 50,
                itemLevel = 1,
                bonus = 50
            };
            Consumable minorHealing = new Consumable()
            {
                name = "Lesser Healing Potion",
                goldCost = 150,
                itemLevel = 2,
                bonus = 150
            };
            Consumable majorHealing = new Consumable()
            {
                name = "Lesser Healing Potion",
                goldCost = 400,
                itemLevel = 3,
                bonus = 400
            };

            itemList = new List<IItem>() {lesserHealing, minorHealing, minorHealing};

            return itemList;
        }
    }
}
