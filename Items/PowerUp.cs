using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Character;
using Labb3.UtilityTools;
using static System.Threading.Thread;

namespace Labb3.Items
{
    public class PowerUp : IItem
    {
        public static PowerUp powerUp = new PowerUp();

        public string name { get => name; set => name = value; }
        public int goldCost { get => goldCost; set => goldCost = value; }
        public int itemLevel { get => itemLevel; set => itemLevel = value; }
        public int bonus { get => bonus; set => bonus = value; }
        public List<IItem> itemList { get => ((IItem)powerUp).itemList; set => ((IItem)powerUp).itemList = value; }//Fixa

        public List<IItem> Type(string type)
        {
            //Stamina buff
            PowerUp lesserStamina = new PowerUp()
            {
                name = "Lesser Stamina",
                goldCost = 100,
                itemLevel = 1,
                bonus = 50,

            };
            PowerUp minorStamina = new PowerUp()
            {
                name = "Minor Stamina",
                goldCost = 200,
                itemLevel = 2,
                bonus = 100,

            };
            PowerUp majorStamina = new PowerUp()
            {
                name = "Major Stamina",
                goldCost = 300,
                itemLevel = 3,
                bonus = 150,

            };

            //Strength buff
            PowerUp lesserStrength = new PowerUp()
            {
                name = "Lesser Strength",
                goldCost = 100,
                itemLevel = 1,
                bonus = 50,

            };
            PowerUp minorStrength = new PowerUp()
            {
                name = "Minor Strength",
                goldCost = 200,
                itemLevel = 2,
                bonus = 100,

            };
            PowerUp majorStrength = new PowerUp()
            {
                name = "Major Strength",
                goldCost = 300,
                itemLevel = 3,
                bonus = 150,

            };

            if (type == "hp")
            {
                
                Player.player.MaxHp += 20 * Player.player.Lvl;
                Player.player.Hp += 20 * Player.player.Lvl;
                Tools.GreenLine($"Max health is now {Player.player.MaxHp}");
            }
            else if (type == "dmg")
            {
                Player.player.Dmg += 20 * Player.player.Lvl;
                Tools.GreenLine($"The power flows through you! is now {Player.player.MaxHp}");
                Tools.GreenLine($"{Player.player.Name} power: {Player.player.Dmg}");
            }

            itemList.Add(lesserStamina);
            itemList.Add(lesserStrength);
            itemList.Add(minorStamina);
            itemList.Add(minorStrength);
            itemList.Add(majorStamina);
            itemList.Add(majorStrength);

            Sleep(1300);
            return itemList;
        }
    }
}
