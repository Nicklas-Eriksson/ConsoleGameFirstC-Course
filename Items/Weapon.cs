using System;
using System.Collections.Generic;

namespace Labb3.Items
{
    [Serializable]

    public class Weapon : AbstractItem
    {
        public static Weapon weapon = new Weapon();

        private int power;
        private List<Weapon> weaponList = new List<Weapon>();
        private List<Weapon> fullWeaponList = new List<Weapon>();
        private List<Weapon> currentWeapon = new List<Weapon>();

        //add a string trivia?
        public int Power { get => power; set => power = ItemLevel * 50; }
        public List<Weapon> WeaponList { get => weaponList; set => weaponList = value; }
        public List<Weapon> FullWeaponList { get => fullWeaponList; set => fullWeaponList = value; }
        public List<Weapon> CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }

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

        void WeaponForge()
        {
            //Weapons will be obtained in shop and/or through loot

            Weapon blundtSword = new Weapon()//0
            {
                Name = "Blundt Sword",
                ItemLevel = 1,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon rustyDagger = new Weapon()//1
            {
                Name = "Rusty Dagger",
                ItemLevel = 1,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon unbalancedAxe = new Weapon()//2
            {
                Name = "Unbalanced Axe",
                ItemLevel = 1,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon vorpalBlade = new Weapon()//3
            {
                Name = "Vorpal Blade",
                ItemLevel = 2,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon railGuns = new Weapon()//4
            {
                Name = "Rail Guns",
                ItemLevel = 2,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon lightsaber = new Weapon()//5
            {
                Name = "Lightsaber",
                ItemLevel = 3,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon harbringer = new Weapon()//6
            {
                Name = "Harbringer",
                ItemLevel = 3,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon needle = new Weapon()//7
            {
                Name = "Arya's Needle",
                ItemLevel = 4,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon keyblade = new Weapon()//8
            {
                Name = "Sora's Keyblade",
                ItemLevel = 5,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon oblivion = new Weapon()//9
            {
                Name = "Oblivion Keyblade",
                ItemLevel = 5,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon oathkeeper = new Weapon()//10
            {
                Name = "Oathkeeper Keyblade",
                ItemLevel = 6,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon thorsHammer = new Weapon()//11
            {
                Name = "Thors Hammer",
                ItemLevel = 6,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon theElderWand = new Weapon()//12
            {
                Name = "The Elder Wand",
                ItemLevel = 7,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon infinityGuantlet = new Weapon()//13
            {
                Name = "Infinity Guantlet",
                ItemLevel = 7,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon gatlinGun = new Weapon()//14
            {
                Name = "Gatlin Gun",
                ItemLevel = 8,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon muramasBlade = new Weapon()//15
            {
                Name = "Muramas Blade",
                ItemLevel = 8,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon dreamRod = new Weapon()//16
            {
                Name = "Dream Rod",
                ItemLevel = 9,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon olympiaSword = new Weapon()//17
            {
                Name = "Olympia Sword",
                ItemLevel = 9,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon kakashisShuriken = new Weapon()//18
            {
                Name = "Kakashi's Shuriken",
                ItemLevel = 10,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon håkansLongsword = new Weapon()//19
            {
                Name = "Håkan's Longsword",
                ItemLevel = 10,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon tinasLongbow = new Weapon()//20
            {
                Name = "Tina's Ivory Longbow",
                ItemLevel = 10,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon bennysWhip = new Weapon()//21
            {
                Name = "Benny's Leather Whip",
                ItemLevel = 10,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon josefinesRevolver = new Weapon()//22
            {
                Name = "Josefine's Golden Revolver",
                ItemLevel = 10,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            Weapon davidsSpear = new Weapon()//23
            {
                Name = "David's Glowing Spear",
                ItemLevel = 10,
                Power = this.power,
                GoldCost = this.GoldCost,
                GoldIfSold = this.GoldIfSold
            };
            
            //Weapon List
            weaponList.Add(blundtSword);
            weaponList.Add(rustyDagger);
            weaponList.Add(unbalancedAxe);
            weaponList.Add(vorpalBlade);
            weaponList.Add(railGuns);
            weaponList.Add(lightsaber);
            weaponList.Add(harbringer);
            weaponList.Add(needle);
            weaponList.Add(keyblade);
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
            weaponList.Add(davidsSpear);

            //Full Weapon List
            fullWeaponList.Add(blundtSword);
            fullWeaponList.Add(rustyDagger);
            fullWeaponList.Add(unbalancedAxe);
            fullWeaponList.Add(vorpalBlade);
            fullWeaponList.Add(railGuns);
            fullWeaponList.Add(lightsaber);
            fullWeaponList.Add(harbringer);
            fullWeaponList.Add(needle);
            fullWeaponList.Add(keyblade);
            fullWeaponList.Add(oblivion);
            fullWeaponList.Add(oathkeeper);
            fullWeaponList.Add(thorsHammer);
            fullWeaponList.Add(theElderWand);
            fullWeaponList.Add(infinityGuantlet);
            fullWeaponList.Add(gatlinGun);
            fullWeaponList.Add(muramasBlade);
            fullWeaponList.Add(dreamRod);
            fullWeaponList.Add(olympiaSword);
            fullWeaponList.Add(kakashisShuriken);
            fullWeaponList.Add(håkansLongsword);
            fullWeaponList.Add(tinasLongbow);
            fullWeaponList.Add(bennysWhip);
            fullWeaponList.Add(josefinesRevolver);
            fullWeaponList.Add(davidsSpear);
        }

        public List<Weapon> GetFullWeaponList()
        {
            WeaponForge();

            return weaponList;
        }
    } //Weapon class End        
}
