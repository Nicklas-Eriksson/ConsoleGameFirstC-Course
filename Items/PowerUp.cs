﻿using System;
using System.Collections.Generic;

namespace Labb3.Items
{
    [Serializable]
    public class PowerUp : AbstractItem
    {
        private int goldCost;

        public int GoldCost { get => goldCost; set => goldCost = value; }

        public static PowerUp powerUp = new PowerUp();
        public static List<PowerUp> staminaList = new List<PowerUp>();
        public static List<PowerUp> strengthList = new List<PowerUp>();

        public int Bonus { get; set; }

        public void Instantiate()
        {
            //Stamina buff
            var minorStamina = new PowerUp()
            {
                Name = "Minor Stamina",
                GoldCost = 100,
                ItemLevel = 1,
                Bonus = 100,
            };
            var greaterStamina = new PowerUp()
            {
                Name = "Greater Stamina",
                GoldCost = 200,
                ItemLevel = 2,
                Bonus = 175,
            };
            var majorStamina = new PowerUp()
            {
                Name = "Major Stamina",
                GoldCost = 300,
                ItemLevel = 3,
                Bonus = 250,
            };

            //Strength buff
            var minorStrength = new PowerUp()
            {
                Name = "Minor Strength",
                GoldCost = 100,
                ItemLevel = 1,
                Bonus = 10,
            };
            var greaterStrength = new PowerUp()
            {
                Name = "Greater Strength",
                GoldCost = 200,
                ItemLevel = 2,
                Bonus = 25,
            };
            var majorStrength = new PowerUp()
            {
                Name = "Major Strength",
                GoldCost = 300,
                ItemLevel = 3,
                Bonus = 50,
            };

            //Stamina
            staminaList.Add(minorStamina);//0
            staminaList.Add(greaterStamina);//1
            staminaList.Add(majorStamina);//2

            //Strength
            strengthList.Add(minorStrength);//0
            strengthList.Add(greaterStrength);//1
            strengthList.Add(majorStrength);//2                       
        }
    }
}