using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    [Serializable]

    public class Weapon : IItem
    {       
        public static Weapon weapon = new Weapon();

        private string name;
        private int itemLevel;
        private int power;
        private int goldCost;
        private int goldIfSold;
        private List<Weapon> weaponList = new List<Weapon>();
        private List<Weapon> currentWeapon = new List<Weapon>();

        //add a string trivia?

        public string Name { get => name; set => name = value; }
        public int ItemLevel { get => itemLevel; set => itemLevel = value; }
        public int Power { get => power; set => power = value; }
        public int GoldCost { get => goldCost; set => goldCost = value; }
        public int GoldIfSold { get => goldIfSold; set => goldIfSold = goldCost / 2; }
        public List<Weapon> WeaponList { get => weaponList; set => weaponList = value; }
        public List<Weapon> CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }
        



        //Constructors
        public Weapon()
        {
        }
        public Weapon(string name, int powerLevel, int power, int goldCost, int goldIfSold)
        {
            this.name = name;
            this.itemLevel = powerLevel;
            this.power = power;
            this.goldCost = goldCost;
            this.goldIfSold = goldIfSold;
        }
        
        //public List<IItem> Inventory()
        //{
        //    inventoryList = new List<IItem>();


        //    return inventoryList;
        //}

        void WeaponForge()
        {
            //Weapons will be obtained in shop and/or through loot
            
            Weapon blundtSword = new Weapon()//0
            {
                Name = "Blundt Sword",
                ItemLevel = 1,
                Power = 100,
                goldCost = 100,
                goldIfSold = this.GoldIfSold
            };
            Weapon rustyDagger = new Weapon()//1
            {
                Name = "Rusty Dagger",
                ItemLevel = 1,
                Power = 100,
                goldCost = 100,
                goldIfSold = this.GoldIfSold
            };
            Weapon unbalancedAxe = new Weapon()//2
            {
                Name = "Unbalanced Axe",
                ItemLevel = 1,
                Power = 100,
                goldCost = 100,
                goldIfSold = this.GoldIfSold
            };
            Weapon vorpalBlade = new Weapon()//3
            {
                Name = "Vorpal Blade",
                ItemLevel = 2,
                Power = 200,
                goldCost = 200,
                goldIfSold = this.GoldIfSold
            };
            Weapon railGuns = new Weapon()//4
            {
                Name = "Rail Guns",
                ItemLevel = 2,
                Power = 200,
                goldCost = 200,
                goldIfSold = this.GoldIfSold
            };
            Weapon lightsaber = new Weapon()//5
            {
                Name = "Lightsaber",
                ItemLevel = 3,
                Power = 300,
                goldCost = 300,
                goldIfSold = this.GoldIfSold
            };
            Weapon harbringer = new Weapon()//6
            {
                Name = "Harbringer",
                ItemLevel = 3,
                Power = 300,
                goldCost = 300,
                goldIfSold = this.GoldIfSold
            };
            Weapon needle = new Weapon()//7
            {
                Name = "Arya's Needle",
                ItemLevel = 4,
                Power = 400,
                goldCost = 400,
                goldIfSold = this.GoldIfSold
            };
            Weapon keyblade = new Weapon()//8
            {
                Name = "Sora's Keyblade",
                ItemLevel = 5,
                Power = 500,
                goldCost = 500,
                goldIfSold = this.GoldIfSold
            };
            Weapon oblivion = new Weapon()//9
            {
                Name = "Oblivion Keyblade",
                ItemLevel = 5,
                Power = 500,
                goldCost = 500,
                goldIfSold = this.GoldIfSold
            };
            Weapon oathkeeper = new Weapon()//10
            {
                Name = "Oathkeeper Keyblade",
                ItemLevel = 6,
                Power = 600,
                goldCost = 600,
                goldIfSold = this.GoldIfSold
            };
            Weapon thorsHammer = new Weapon()//11
            {
                Name = "Thors Hammer",
                ItemLevel = 6,
                Power = 600,
                goldCost = 600,
                goldIfSold = this.GoldIfSold
            };
            Weapon theElderWand = new Weapon()//12
            {
                Name = "The Elder Wand",
                ItemLevel = 7,
                Power = 700,
                goldCost = 700,
                goldIfSold = this.GoldIfSold
            };
            Weapon infinityGuantlet = new Weapon()//13
            {
                Name = "Infinity Guantlet",
                ItemLevel = 7,
                Power = 700,
                goldCost = 700,
                goldIfSold = this.GoldIfSold
            };
            Weapon gatlinGun = new Weapon()//14
            {
                Name = "Gatlin Gun",
                ItemLevel = 8,
                Power = 800,
                goldCost = 800,
                goldIfSold = this.GoldIfSold
            };
            Weapon muramasBlade = new Weapon()//15
            {
                Name = "Muramas Blade",
                ItemLevel = 8,
                Power = 800,
                goldCost = 800,
                goldIfSold = this.GoldIfSold
            };
            Weapon dreamRod = new Weapon()//16
            {
                Name = "Dream Rod",
                ItemLevel = 9,
                Power = 900,
                goldCost = 900,
                goldIfSold = this.GoldIfSold
            };
            Weapon olympiaSword = new Weapon()//17
            {
                Name = "Olympia Sword",
                ItemLevel = 9,
                Power = 900,
                goldCost = 900,
                goldIfSold = this.GoldIfSold
            };
            Weapon kakashisShuriken = new Weapon()//18
            {
                Name = "Kakashi's Shuriken",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000,
                goldIfSold = this.GoldIfSold
            };
            Weapon håkansLongsword = new Weapon()//19
            {
                Name = "Håkan's Longsword",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000,
                goldIfSold = this.GoldIfSold
            };
            Weapon tinasLongbow = new Weapon()//20
            {
                Name = "Tina's Ivory Longbow",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000,
                goldIfSold = this.GoldIfSold
            };
            Weapon bennysWhip = new Weapon()//21
            {
                Name = "Benny's Leather Whip",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000,
                goldIfSold = this.GoldIfSold
            };
            Weapon josefinesRevolver = new Weapon()//22
            {
                Name = "Josefine's Golden Revolver",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000,
                goldIfSold = this.GoldIfSold
            };
            Weapon davidsSpear = new Weapon()//23
            {
                Name = "David's Glowing Spear",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000,
                goldIfSold = this.GoldIfSold
            };
                        
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

        }
        public List<Weapon> GetFullWeaponList()
        {
            WeaponForge();
            return weaponList;
        }
        public void SetCurrentWeapon(Weapon wep)
        {
            WeaponForge();
            currentWeapon.Add(wep);
        }
        public List<Weapon> GetCurrentWeapon()
        {
            WeaponForge();
            return currentWeapon;
        }

        public void instantiateList()
        {           
            if (weapon.WeaponList.Count == 0)
            {
                weapon.WeaponList = Weapon.weapon.GetFullWeaponList();
            }
        }

        

    } //Weapon class End

    
}
