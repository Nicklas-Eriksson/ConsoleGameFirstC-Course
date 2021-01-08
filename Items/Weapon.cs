using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    public class Weapon
    {
        private List<Weapon> weaponList = new List<Weapon>();
        private string name;
        private int powerLevel;
        private int power;
        private int crit;

        public List<Weapon> WeaponList { get => weaponList; set => weaponList = value; }
        public string Name { get => name; set => name = value; }
        public int PowerLevel { get => powerLevel; set => powerLevel = value; }
        public int Power { get => power; set => Power = value; }
        public int Crit { get => crit; set => crit = value; }

        public Weapon(string name, int powerLevel, int power, int crit)
        {
            this.name = name;
            this.powerLevel = powerLevel;
            this.power = power;
            this.crit = crit;
        }
        public Weapon() { }

        public List<Weapon> WeaponForge()
        {
            

            Weapon blundSword = new Weapon();
            {
                name = "asd";
                powerLevel = 1;
                power = 2;
                crit = crit;
            }


            return weaponList;
        }        
    }

    




    public class EquippedWeapon : Weapon
    {
        private List<EquippedWeapon> equippedWeaponList = new List<EquippedWeapon>();

        public List<EquippedWeapon> EquippedWeaponList { get => equippedWeaponList; set => equippedWeaponList = value; }

        ///////////////////////////////////////////////////////////////////////////





    }
}
