using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Menues;
using Labb3.UtilityTools;
using Labb3.Items;
using static System.Threading.Thread;
using Labb3.Character;

namespace Labb3.Store
{
    public static class Dealers
    {
        static private List<Weapon> fullWepList = new List<Weapon>();

        
        //Buy/Sell START
        private static void BuyOrSellText()
        {
            Console.Clear();
            Logo.Shop();

            Tools.YellowLine("===========================");
            Tools.YellowLine("|| [1] Buy.............. ||");
            Tools.YellowLine("|| [2] Sell............. ||");
            Tools.YellowLine("|| [3] Main Menu........ ||");
            Tools.YellowLine("|| [4] Exit Game........ ||");
            Tools.YellowLine("===========================\n");
        }
        private static void BuyOrSellSwitch()
        {
            BuyOrSellText();

            Tools.Yellow("Option: ");
            int input = Tools.Option(Console.ReadLine(), 4);

            switch (input)
            {
                case 1:
                    BuySwitch();
                    break;

                case 2:
                    SellSwitch();
                    break;
                case 3:
                    MenuOptions.Options();
                    break;
                case 4:
                    Tools.ExitGame();
                    break;
            }
        }
        //Buy/Sell END

        //Buy Options START
        private static void BuyText()
        {
            Console.Clear();
            Logo.Shop();

            Tools.YellowLine("===========================");
            Tools.YellowLine("|| ---------Buy--------- ||");
            Tools.YellowLine("|| [1] Weapons.......... ||");
            Tools.YellowLine("|| [2] Power-Ups........ ||");
            Tools.YellowLine("|| [3] Healing Potions.. ||");
            Tools.YellowLine("|| [4] Back............. ||");
            Tools.YellowLine("|| [5] Exit Game........ ||");
            Tools.YellowLine("===========================\n");
        }
        private static void BuySwitch()
        {
            BuyText();

            Tools.Yellow("Option: ");
            int input = Tools.Option(Console.ReadLine(), 5);

            switch (input)
            {
                case 1://Weapons
                    BuyWeapon();
                    break;
                case 2://Power-Ups
                    BuyPowerUpSwitch();
                    break;
                case 3://Potions
                    BuyPotionSwitch();
                    break;
                case 4://Back
                    BuyOrSellSwitch();
                    break;
                case 5://Exit
                    Tools.ExitGame();
                    break;
            }
        }
        //Buy Options END

        //Buy Weapons START
        static private void instantiateListWeapons()
        {
            if (fullWepList.Count == 0)
            {
                fullWepList = Weapon.weapon.GetFullWeaponList();
            }
        }
        public static void DisplayWeapon()
        {
            //instantiateListWeapons();
            Weapon.weapon.instantiateList();
            Console.Clear();
            Logo.Shop();

            Console.WriteLine("Write the number of the weapon you would like to purchase:\n");

            //Display Weapons for shop, loops through the whole weapon list 
            
            
            for (int i = 0; i < Weapon.weapon.WeaponList.Count; i++)
            {
                BuyWeaponText(i);
            }
        }
        private static void BuyWeaponText(int nr)//will be looped through in BuyInstruct()
        {
            Tools.YellowLine($"[{nr + 1}]: {Weapon.weapon.WeaponList[nr].Name}");
            Tools.YellowLine($"Weapon power: +{Weapon.weapon.WeaponList[nr].Power} damage");
            Tools.YellowLine($"Cost to purchase: {Weapon.weapon.WeaponList[nr].GoldCost} Gold");
            Console.WriteLine("------------------------------");
        }

        static public void BuyWeapon()
        {
            Logo.Shop();

            
            DisplayWeapon();

            //Add remove bought iteam??

            int number;

            //do
            //{
                Tools.Yellow("Option: ");
                number = Tools.ConvToInt32(Console.ReadLine(), Weapon.weapon.WeaponList.Count);

                //Onödigt om errorhandeling funkar som jag tänkt

                //if (number - 1 > fullWepList.Count)
                //{
                //    Tools.RedLine($"You entered a too high number: {number - 1}.");
                //    Tools.RedLine($"Keep it within the range of 1-{fullWepList.Count}!");
                //}
                //else if (number - 1 <= 1)
                //{
                //    Tools.RedLine($"You entered a too low number: {number - 1}.");
                //    Tools.RedLine($"Keep it within the range of 1-{fullWepList.Count}!");
                //}

            //} while (number > fullWepList.Count || number - 1 <= 1);


            Tools.GreenLine($"{Weapon.weapon.WeaponList[number - 1].Name} has been equipped as your weapon");
            Player.player.WeaponDmg = Weapon.weapon.WeaponList[number - 1].Power;
            Player.player.WeaponIndex = number - 1;//A way for me to access the weapon at the correct index when calling on the full weapon list. One of many ways to do it
            Sleep(1500);


            //GoldWithdraw(number-1);


            BuyOrSellSwitch();
        }
        //Buy Weapons END


        //Buy Power-Ups START
        private static void BuyPowerUpText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine( "===========================        ===================== ");
            Tools.YellowLine( "|| ------Power-Ups------ ||       || --Player Stats-- ");
            Tools.YellowLine($"|| [1] Stamina.......... ||       || Max Health: {Player.player.MaxHp} ");
            Tools.YellowLine($"|| [2] Strength......... ||       || Attack Damage: {Player.player.Dmg} ");
            Tools.YellowLine($"|| [3] Main store menu.. ||       || Gold : {Player.player.Gold} gold ");
            Tools.YellowLine("===========================        =====================\n");

            Tools.YellowLine("Okey, listen up!");
            Tools.YellowLine("There are two different types of power-ups..");
            Tools.YellowLine("Stamina: This power-up increases your maximum healt..");
            Tools.YellowLine("Strength: This power-up increases your damage capability..\n");
            Tools.RedLine("   :~:           :~:   ");
            Tools.RedLine("   | |           | |   ");
            Tools.RedLine("  .' '.         .' '.  ");
            Tools.RedLine(".'     '.     .'     '.");
            Tools.RedLine("|  Sta  |     |  Str  |");
            Tools.RedLine("'.......'     '.......'\n");
        }
        private static void BuyPowerUpSwitch()
        {
            BuyPowerUpText();

            Tools.Yellow("Option: ");
            int input = Tools.Option(Console.ReadLine(), 3);

            switch(input)
            {
                case 1://+ stamina
                    PowerUp.powerUp.Bonus("hp");
                    BuyPowerUpSwitch();
                    break;

                case 2://+ strength
                    PowerUp.powerUp.Bonus("dmg");
                    BuyPowerUpSwitch();
                    break;

                case 3:
                    BuyOrSellSwitch();
                    break;
            }

            //loop som displayar alla power ups



            Sleep(2000);
        }
        //Buy Power-Ups END


        //Buy Potions START
        private static void BuyPotionText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("===========================");
            Tools.YellowLine("|| ---Healing Potions--- ||");
            Tools.YellowLine("|| [1] Healing potion... ||");
            Tools.YellowLine("|| [2] Main store menu.. ||");
            Tools.YellowLine("=========================== \n");


            Tools.YellowLine("This red little bottle will maby one day be your life saver.. ");
            Tools.YellowLine("I mean it.. Literally, you wont die if you drink it..\n");
            Tools.RedLine("   :~:       ");
            Tools.RedLine(" .'   '.     ");
            Tools.RedLine("|  HP+  |    ");
            Tools.RedLine("'.......'  \n");
        }
        private static void BuyPotionSwitch() 
        {
            BuyPotionText();

            Tools.Yellow("Option: ");
            int input = Tools.Option(Console.ReadLine(), 2);
            switch(input)
            {
                case 1:
                    //-gold
                    Player.player.HealingPotions++;
                    Tools.GreenLine("1 Healing Potion has been added to your inventory!");
                    Sleep(2000);

                    BuyPotionSwitch();
                    break;
                case 2:
                    BuyOrSellSwitch();
                    break;
            }
        }
        //Buy Potions END


        //Sell START
        private static void SellText()
        {            
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("===================================");
            Tools.YellowLine("|| -------------Sell------------- ||");
            Tools.YellowLine("|| Enter the number of the iteam  ||");
            Tools.YellowLine("||    you would like to sell      ||");
            Tools.YellowLine("=================================== \n");
        }
        private static void SellSwitch()
        {
            SellText();
            Player.DisplayInventory();

            Tools.Yellow("Option: ");
            int input = Tools.Option(Console.ReadLine(), Player.player.InventoryList.Count);

            Console.WriteLine($"There you go, {Weapon.weapon.WeaponList[input - 1].GoldIfSold} gold coins.");
            Player.player.Gold += Weapon.weapon.WeaponList[input - 1].GoldIfSold; //You get half the cost back from selling

            Sleep(2000);
            BuyOrSellSwitch();
        }
        //Sell END


        public static void StoreMenueIronSkillet()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("Welcome to The Iron Skillet!");
           // Sleep(2000);
            Tools.YellowLine("It's not often we get customers these days..");
           // Sleep(2000);
            Tools.YellowLine("Anyways!..");
           // Sleep(2000);
            Console.Clear();

            BuyOrSellSwitch();

        }
       
        
       

        private static void GoldWithdraw(int number)
        {
            //The number that comes in is already altered to be -1

            if (Player.player.Gold >= fullWepList[number - 1].GoldCost)
            {
                Console.WriteLine($"{fullWepList[number].GoldCost} Gold has been withdrawn from your pouch");
                Player.player.Gold -= fullWepList[number].GoldCost;
            }
            else if (Player.player.Gold < fullWepList[number].GoldCost)
            {
                Console.WriteLine("Not enough gold! Get back here when you can afford it!");
                Console.WriteLine("Filthy creature..");
                Sleep(1500);
                BuyWeapon();
            }
        }//GoldWithdraw() End
    }//Dealers.cs End
}
