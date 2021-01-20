using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Character;
using Labb3.UtilityTools;
using static System.Threading.Thread;

namespace Labb3.Items
{
    [Serializable]

    public class PowerUp : IItem
    {
        public static PowerUp powerUp = new PowerUp();
        public static List<PowerUp> staminaList = new List<PowerUp>();
        public static List<PowerUp> strengthList = new List<PowerUp>();

        private string name;
        private int goldCost;
        private int itemLevel;
        private int bonus;

        public string Name { get => name; set => name = value; }
        public int GoldCost { get => goldCost; set => goldCost = value; }
        public int ItemLevel { get => itemLevel; set => itemLevel = value; }
        public int Bonus { get => bonus; set => bonus = value; }
        
        public void Instantiate()
        {
            //Stamina buff
            PowerUp lesserStamina = new PowerUp()
            {
                Name = "Lesser Stamina",
                GoldCost = 100,
                ItemLevel = 1,
                Bonus = 50,

            };
            PowerUp minorStamina = new PowerUp()
            {
                Name = "Minor Stamina",
                GoldCost = 200,
                ItemLevel = 2,
                Bonus = 100,

            };
            PowerUp majorStamina = new PowerUp()
            {
                Name = "Major Stamina",
                GoldCost = 300,
                ItemLevel = 3,
                Bonus = 150,

            };

            //Strength buff
            PowerUp lesserStrength = new PowerUp()
            {
                Name = "Lesser Strength",
                GoldCost = 100,
                ItemLevel = 1,
                Bonus = 50,

            };
            PowerUp minorStrength = new PowerUp()
            {
                Name = "Minor Strength",
                GoldCost = 200,
                ItemLevel = 2,
                Bonus = 100,

            };
            PowerUp majorStrength = new PowerUp()
            {
                Name = "Major Strength",
                GoldCost = 300,
                ItemLevel = 3,
                Bonus = 150,

            };

            
            //Stamina
            staminaList.Add(lesserStamina);//0
            staminaList.Add(minorStamina);//1
            staminaList.Add(majorStamina);//2

            //Strength
            strengthList.Add(lesserStamina);//0
            strengthList.Add(minorStamina);//1
            strengthList.Add(majorStamina);//2

            Sleep(1300);
        }
    }
}
