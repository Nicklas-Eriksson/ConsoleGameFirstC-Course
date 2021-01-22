using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Character;
using Labb3.UtilityTools;
using static System.Threading.Thread;

namespace Labb3.Items
{
    [Serializable]

    public class PowerUp : AbstractItem
    {
        public static PowerUp powerUp = new PowerUp();
        public static List<PowerUp> staminaList = new List<PowerUp>();
        public static List<PowerUp> strengthList = new List<PowerUp>();

     
        private int bonus;

    
        public int Bonus { get => bonus; set => bonus = value; }
        
        public void Instantiate()
        {
            //Stamina buff
            PowerUp minorStamina = new PowerUp()
            {
                Name = "Minor Stamina",
                GoldCost = 100,
                ItemLevel = 1,
                Bonus = 50,

            };
            PowerUp greaterStamina = new PowerUp()
            {
                Name = "Greater Stamina",
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
            PowerUp minorStrength = new PowerUp()
            {
                Name = "Minor Strength",
                GoldCost = 100,
                ItemLevel = 1,
                Bonus = 50,

            };
            PowerUp greaterStrength = new PowerUp()
            {
                Name = "Greater Strength",
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
            staminaList.Add(minorStamina);//0
            staminaList.Add(greaterStamina);//1
            staminaList.Add(majorStamina);//2

            //Strength
            strengthList.Add(minorStamina);//0
            strengthList.Add(greaterStamina);//1
            strengthList.Add(majorStamina);//2

            Sleep(1300);
        }
    }
}
