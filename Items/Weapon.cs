using System;
using System.Collections.Generic;

namespace Labb3.Items
{
    [Serializable]
    public class Weapon : AbstractItem
    {
        public static Weapon weapon = new Weapon();

        private int power;
        private int goldCost;

        //add a string trivia?
        public int Power { get => power; set => power = ItemLevel * 20; }
        public int GoldCost { get => goldCost; set => goldCost = 100*ItemLevel; }

        public List<Weapon> WeaponList { get; set; } = new List<Weapon>();
        public List<Weapon> FullWeaponList { get; set; } = new List<Weapon>();
        public List<Weapon> CurrentWeapon { get; set; } = new List<Weapon>();

        //Constructors
        public Weapon()
        {
        }

        public Weapon(string name, int powerLevel, int power, int goldCost, int goldIfSold)
        {
            this.Name = name;
            this.ItemLevel = powerLevel;
            this.power = power;
            this.GoldCost = goldCost;
            this.GoldIfSold = goldIfSold;
        }

        private void WeaponForge()
        {
            //Weapons will be obtained in shop and/or through loot

            Weapon rustyDagger = new Weapon()//1
            {
                Name = "Rusty Dagger",
                ItemLevel = 2,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon vorpalBlade = new Weapon()//3
            {
                Name = "Vorpal Blade",
                ItemLevel = 5,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon lightsaber = new Weapon()//5
            {
                Name = "Lightsaber",
                ItemLevel = 8,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon needle = new Weapon()//7
            {
                Name = "Arya's Needle",
                ItemLevel = 13,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon keyblade = new Weapon()//8
            {
                Name = "Sora's Keyblade",
                ItemLevel = 16,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon thorsHammer = new Weapon()//11
            {
                Name = "Thors Hammer",
                ItemLevel = 19,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon infinityGuantlet = new Weapon()//13
            {
                Name = "Infinity Gauntlet",
                ItemLevel = 20,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon gatlingGun = new Weapon()//14
            {
                Name = "Gatling Gun",
                ItemLevel = 23,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon olympiaSword = new Weapon()//17
            {
                Name = "Olympia Sword",
                ItemLevel = 26,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon kakashisShuriken = new Weapon()//18
            {
                Name = "Kakashi's Shuriken",
                ItemLevel = 30,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon håkansLongsword = new Weapon()//19
            {
                Name = "Håkan's Longsword",
                ItemLevel = 30,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon tinasLongbow = new Weapon()//20
            {
                Name = "Tina's Longbow",
                ItemLevel = 30,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon bennysWhip = new Weapon()//21
            {
                Name = "Benny's Whip",
                ItemLevel = 30,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon josefinesRevolver = new Weapon()//22
            {
                Name = "Josefine's Revolver",
                ItemLevel = 30,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon davidsSpear = new Weapon()//23
            {
                Name = "David's Spear",
                ItemLevel = 30,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };

            //Weapon List
            WeaponList.Add(rustyDagger);
            WeaponList.Add(vorpalBlade);
            WeaponList.Add(lightsaber);
            WeaponList.Add(needle);
            WeaponList.Add(keyblade);
            WeaponList.Add(thorsHammer);
            WeaponList.Add(infinityGuantlet);
            WeaponList.Add(gatlingGun);
            WeaponList.Add(olympiaSword);
            WeaponList.Add(kakashisShuriken);
            WeaponList.Add(håkansLongsword);
            WeaponList.Add(tinasLongbow);
            WeaponList.Add(bennysWhip);
            WeaponList.Add(josefinesRevolver);
            WeaponList.Add(davidsSpear);

            //Full Weapon List
            FullWeaponList.Add(rustyDagger);
            FullWeaponList.Add(vorpalBlade);
            FullWeaponList.Add(lightsaber);
            FullWeaponList.Add(needle);
            FullWeaponList.Add(keyblade);
            FullWeaponList.Add(thorsHammer);
            FullWeaponList.Add(infinityGuantlet);
            FullWeaponList.Add(gatlingGun);
            FullWeaponList.Add(olympiaSword);
            FullWeaponList.Add(kakashisShuriken);
            FullWeaponList.Add(håkansLongsword);
            FullWeaponList.Add(tinasLongbow);
            FullWeaponList.Add(bennysWhip);
            FullWeaponList.Add(josefinesRevolver);
            FullWeaponList.Add(davidsSpear);
        }

        public List<Weapon> GetFullWeaponList()
        {
            WeaponForge();

            return WeaponList;
        }
    } //Weapon class End
}