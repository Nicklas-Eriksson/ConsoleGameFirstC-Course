using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    public class Weapon
    {
        //public static Weapon weapon = new Weapon();

        private string name;
        private int itemLevel;
        private int power;
        private int goldCost;
        private List<Weapon> weaponList = new List<Weapon>();
        private List<Weapon> currentWeapon = new List<Weapon>();

        public int ItemLevel { get => itemLevel; set => itemLevel = value; }
        public int Power { get => power; set => power = value; }
        public int GoldCost { get => goldCost; set => goldCost = value; }
        public string Name { get => name; set => name = value; }
        public List<Weapon> WeaponList { get => weaponList; set => weaponList = value; }
        public List<Weapon> CurrentWeapon { get => currentWeapon; set => currentWeapon = value; }


        //Constructors
        public Weapon()
        {
        }
        public Weapon(string name, int powerLevel, int power, int goldCost)
        {
            this.name = name;
            this.itemLevel = powerLevel;
            this.power = power;
            this.goldCost = goldCost;
        }

        void WeaponForge()
        {
            //Weapons will be obtained in shop and/or through loot
            Weapon blundtSword = new Weapon()//0
            {
                Name = "Blundt Sword",
                ItemLevel = 1,
                Power = 100,
                goldCost = 100
            };
            Weapon rustyDagger = new Weapon()//1
            {
                Name = "Rusty Dagger",
                ItemLevel = 1,
                Power = 100,
                goldCost = 100
            };
            Weapon unbalancedAxe = new Weapon()//2
            {
                Name = "Unbalanced Axe",
                ItemLevel = 1,
                Power = 100,
                goldCost = 100
            };
            Weapon vorpalBlade = new Weapon()//3
            {
                Name = "Vorpal Blade",
                ItemLevel = 2,
                Power = 200,
                goldCost = 200
            };
            Weapon railGuns = new Weapon()//4
            {
                Name = "Rail Guns",
                ItemLevel = 2,
                Power = 200,
                goldCost = 200
            };
            Weapon lightsaber = new Weapon()//5
            {
                Name = "Lightsaber",
                ItemLevel = 3,
                Power = 300,
                goldCost = 300
            };
            Weapon harbringer = new Weapon()//6
            {
                Name = "Harbringer",
                ItemLevel = 3,
                Power = 300,
                goldCost = 300
            };
            Weapon needle = new Weapon()//7
            {
                Name = "Arya's Needle",
                ItemLevel = 4,
                Power = 400,
                goldCost = 400
            };
            Weapon keyblade = new Weapon()//8
            {
                Name = "Sora's Keyblade",
                ItemLevel = 5,
                Power = 500,
                goldCost = 500
            };
            Weapon oblivion = new Weapon()//9
            {
                Name = "Oblivion Keyblade",
                ItemLevel = 5,
                Power = 500,
                goldCost = 500
            };
            Weapon oathkeeper = new Weapon()//10
            {
                Name = "Oathkeeper Keyblade",
                ItemLevel = 6,
                Power = 600,
                goldCost = 600
            };
            Weapon thorsHammer = new Weapon()//11
            {
                Name = "Thors Hammer",
                ItemLevel = 6,
                Power = 600,
                goldCost = 600
            };
            Weapon theElderWand = new Weapon()//12
            {
                Name = "The Elder Wand",
                ItemLevel = 7,
                Power = 700,
                goldCost = 700
            };
            Weapon infinityGuantlet = new Weapon()//13
            {
                Name = "Infinity Guantlet",
                ItemLevel = 7,
                Power = 700,
                goldCost = 700
            };
            Weapon gatlinGun = new Weapon()//14
            {
                Name = "Gatlin Gun",
                ItemLevel = 8,
                Power = 800,
                goldCost = 800
            };
            Weapon muramasBlade = new Weapon()//15
            {
                Name = "Muramas Blade",
                ItemLevel = 8,
                Power = 800,
                goldCost = 800
            };
            Weapon dreamRod = new Weapon()//16
            {
                Name = "Dream Rod",
                ItemLevel = 9,
                Power = 900,
                goldCost = 900
            };
            Weapon olympiaSword = new Weapon()//17
            {
                Name = "Olympia Sword",
                ItemLevel = 9,
                Power = 900,
                goldCost = 900
            };
            Weapon kakashisShuriken = new Weapon()//18
            {
                Name = "Kakashi's Shuriken",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000
            };
            Weapon håkansLongsword = new Weapon()//19
            {
                Name = "Håkan's Longsword -\"It seems to glowing while orcs are near..\" ",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000
            };
            Weapon tinasLongbow = new Weapon()//20
            {
                Name = "Tina's Ivory Longbow",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000
            };
            Weapon bennysWhip = new Weapon()//21
            {
                Name = "Benny's Leather Whip",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 1000
            };
            Weapon josefinesRevolver = new Weapon()//22
            {
                Name = "Josefine's Golden Revolver",
                ItemLevel = 10,
                Power = 1000,
                goldCost = 100
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
    } //Weapon class End

    public class CurrentWeapon : Weapon
    {
        public static CurrentWeapon weapon = new CurrentWeapon();
    }
}
