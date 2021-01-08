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
            Random rnd = new Random();
           
            Weapon blundSword = new Weapon();
            {
                name = "Blunt Sword";
                powerLevel = 1;
                power = 7 + rnd.Next(0,5);
            }
            Weapon rustyDagger = new Weapon();
            {
                name = "Rusty Dagger";
                powerLevel = 1;
                power = 4 + rnd.Next(0, 8);
            }
            Weapon unbalancedAxe = new Weapon();
            {
                name = "Unbalanced Axe";
                powerLevel = 1;
                power = 0 + rnd.Next(0, 20);
            }
            Weapon vorpalBlade = new Weapon();
            {
                name = "Vorpal Blade";
                powerLevel = 2;
                power = 15 + rnd.Next(0, 10); ;
            }
            Weapon railGuns = new Weapon();
            {
                name = "Rail Guns";
                powerLevel = 2;
                power = 15 + rnd.Next(0,15);
            }
            Weapon lightsaber = new Weapon();
            {
                name = "Lightsaber";
                powerLevel = 3;
                power = 40 + rnd.Next(0, 18);
            }
            Weapon harbringer = new Weapon();
            {
                name = "Harbringer";
                powerLevel = 3;
                power = 47 + rnd.Next(0, 5);
            }
            Weapon stinger = new Weapon();
            {
                name = "Stinger";
                powerLevel = 4;
                power = 40 + rnd.Next(0, 20);
            }
            Weapon keayblade = new Weapon();
            {
                name = "Keayblade";
                powerLevel = 5;
                power = 100 + rnd.Next(1, 50);
            }
            Weapon oblivion = new Weapon();
            {
                name = "Oblivion";
                powerLevel = 5;
                power = 120 + rnd.Next(1, 10);
            }
            Weapon oathkeeper = new Weapon();
            {
                name = "Oathkeeper";
                powerLevel = 6;
                power = 145 + rnd.Next(1, 25);
            }
            Weapon thorsHammer = new Weapon();
            {
                name = "Thors Hammer";
                powerLevel = 6;
                power = 80 + rnd.Next(1, 200);
            }
            Weapon theElderWand = new Weapon();
            {
                name = "The Elder Wand";
                powerLevel = 7;
                power = 155 + rnd.Next(1, 66);
            }
            Weapon infinityGuantlet = new Weapon();
            {
                name = "Infinity Guantlet";
                powerLevel = 7;
                power = 180 + rnd.Next(1, 22);
            }
            Weapon gatlinGun = new Weapon();
            {
                name = "Gatlin Gun";
                powerLevel = 8;
                power = 90 + rnd.Next(1, 200);
            }
            Weapon muramasBlade = new Weapon();
            {
                name = "Muramas Blade";
                powerLevel = 8;
                power = 100 + rnd.Next(1, 100);
            }
            Weapon dreamRod = new Weapon();
            {
                name = "Dream Rod";
                powerLevel = 9;
                power = 139 + rnd.Next(1, 15);
            }
            Weapon olympiaSword = new Weapon();
            {
                name = "Olympia Sword";
                powerLevel = 9;
                power = 100 + rnd.Next(1, 50);
            }
            Weapon kakashisShuriken = new Weapon();
            {
                name = "Kakashi's Shuriken";
                powerLevel = 10;
                power = 0 + rnd.Next(0, 900);
            }
            Weapon håkansLongsword = new Weapon();
            {
                name = "Håkan's Longsword";
                powerLevel = 10;
                power = 0 + rnd.Next(0, 900);
            }
            Weapon tinasLongbow = new Weapon();
            {
                name = "Tina's Longbow";
                powerLevel = 10;
                power = 0 + rnd.Next(0, 900);
            }
            Weapon bennysWhip = new Weapon();
            {
                name = "Benny's Leather Whip";
                powerLevel = 10;
                power = 0 + rnd.Next(0, 900);
            }
            Weapon josefinesRevolver = new Weapon();
            {
                name = "Josefine's Revolver";
                powerLevel = 10;
                power = 0 + rnd.Next(0, 900);
            }

            weaponList.Add(blundSword);
            weaponList.Add(rustyDagger);
            weaponList.Add(unbalancedAxe);
            weaponList.Add(vorpalBlade);
            weaponList.Add(railGuns);
            weaponList.Add(lightsaber);
            weaponList.Add(harbringer);
            weaponList.Add(stinger);
            weaponList.Add(keayblade);
            weaponList.Add(oblivion);
            weaponList.Add(oathkeeper);
            weaponList.Add(thorsHammer);
            weaponList.Add(theElderWand);
            weaponList.Add(infinityGuantlet);
            weaponList.Add(gatlinGun);
            weaponList.Add(muramasBlade);
            weaponList.Add(dreamRod);
            weaponList.Add(olympiaSword);
            weaponList.Add(kakashisShuriken);
            weaponList.Add(håkansLongsword);
            weaponList.Add(tinasLongbow);
            weaponList.Add(bennysWhip);
            weaponList.Add(josefinesRevolver);

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
