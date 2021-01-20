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
        public static List<PowerUp> itemList = new List<PowerUp>();

        public string name { get => name; set => name = value; }
        public int goldCost { get => goldCost; set => goldCost = value; }
        public int itemLevel { get => itemLevel; set => itemLevel = value; }
        public int bonus { get => bonus; set => bonus = value; }
        
        public void Instantiate()
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

            

            itemList.Add(lesserStamina);//0
            itemList.Add(lesserStrength);//1
            itemList.Add(minorStamina);//2
            itemList.Add(minorStrength);//3
            itemList.Add(majorStamina);//4
            itemList.Add(majorStrength);//5

            Sleep(1300);
        }
    }
}
