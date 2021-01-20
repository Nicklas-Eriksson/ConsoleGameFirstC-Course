﻿using System;
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
        private static int input;
        private static bool purchaseOk;


        //Buy or Sell START
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

            input = Tools.ConvToInt32(4);

            switch (input)
            {
                case 1:
                    BuySwitch();
                    break;

                case 2:
                    SellSwitch();
                    break;
                case 3:
                    MenuOptions.MainMenuSwitch();
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

            input = Tools.ConvToInt32(5);

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

        public static void DisplayWeapon()
        {
            Weapon.weapon.instantiateList();
            Console.Clear();
            Logo.Shop();

            Console.WriteLine(" Write the number of the weapon you would like to purchase:\n");

            DisplayPlayerGoldAndSuch();


            //Display Weapons for shop, loops through the whole weapon list 
            for (int i = 0; i < Weapon.weapon.WeaponList.Count; i++)
            {
                BuyWeaponText(i);
            }
            Console.WriteLine("------------------------------");
        }

        private static void DisplayPlayerGoldAndSuch()
        {
            Tools.YellowLine("==============================================================");
            Console.Write(" Health:");
            Tools.GreenLine($"{Player.player.MaxHp}");
            Console.Write(" Power:");
            Tools.RedLine($"{Player.player.Dmg}");
            Console.Write(" Gold:");
            Tools.YellowLine($"{Player.player.Gold}");

            if (Player.player.WeaponIndex >= 0)
            {
                Console.Write(" Equipped Weapon:");
                Tools.YellowLine($"{Weapon.weapon.WeaponList[Player.player.WeaponIndex].Name} +{Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power} damage");
            }
            else if (Player.player.WeaponIndex < 0)
            {
                Console.WriteLine(" Weapon: Fists +0 dmg\n");
            }
        }

        private static void BuyWeaponText(int nr)//will be looped through in BuyInstruct()
        {
            Console.WriteLine("------------------------------");
            Tools.YellowLine($"[{nr + 1}]: {Weapon.weapon.WeaponList[nr].Name}");
            Tools.Yellow($"Weapon power: +{Weapon.weapon.WeaponList[nr].Power} damage");

            //This if statement displays how much + or - dmg the weapons in the store gives vs current weapon
            if (Player.player.WeaponIndex >= 0) //Check if higher since default weapon index for fist is -1
            {
                if (Weapon.weapon.WeaponList[nr].Power >= Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power && Weapon.weapon.WeaponList[nr].Name == Weapon.weapon.WeaponList[Player.player.WeaponIndex].Name == false)
                {
                    Tools.GreenLine($" +{Weapon.weapon.WeaponList[nr].Power - Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power} on current weapon");
                }
                else if (Weapon.weapon.WeaponList[nr].Name == Weapon.weapon.WeaponList[Player.player.WeaponIndex].Name)
                {
                    Tools.BlueLine($"  -Current Weapon-");
                }
                else if (Weapon.weapon.WeaponList[nr].Power < Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power)
                {
                    Tools.RedLine($" {Weapon.weapon.WeaponList[nr].Power - Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power} on current weapon");
                }
            }
            else
            {
                Tools.GreenLine($" +{Weapon.weapon.WeaponList[nr].Power} on equipped weapon");
            }
            Tools.YellowLine($"Cost to purchase: {Weapon.weapon.WeaponList[nr].GoldCost} Gold");
        }

        static public void BuyWeapon()
        {
            Logo.Shop();

            DisplayWeapon();

            input = Tools.ConvToInt32(Weapon.weapon.WeaponList.Count);

            bool sucessfulPurchase = GoldWithdraw(input, "weapon");

            if (sucessfulPurchase == true)
            {
                Tools.GreenLine($"\n{Weapon.weapon.WeaponList[input - 1].Name} has been equipped as your weapon");
                Player.player.WeaponDmg = Weapon.weapon.WeaponList[input - 1].Power;
                Player.player.WeaponIndex = input - 1;
                /* WeaponIndex is a way for me to access the weapon at the correct index when calling on the full weapon list. One of many ways to do it */
                Sleep(2500);
            }

            BuyOrSellSwitch();
        }
        //Buy Weapons END


        //Buy Power-Ups START
        private static void BuyPowerUpText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("===========================        ==================== ");
            Tools.YellowLine("|| ------Power-Ups------ ||          --Player Stats-- ");
            Tools.YellowLine($"|| [1] Buy Stamina...... ||          Max Health: {Player.player.MaxHp} ");
            Tools.YellowLine($"|| [2] Buy Strength..... ||          Attack Damage: {Player.player.Dmg} ");
            Tools.YellowLine($"|| [3] Back............. ||          Gold : {Player.player.Gold} gold ");
            Tools.YellowLine("===========================        =====================\n");

            Tools.YellowLine("Okey, listen up!");
            Tools.YellowLine("There are two different types of power-ups..");
            Tools.Green("Stamina:"); Tools.YellowLine("This power-up increases your maximum healt..");
            Tools.Red("Strength:"); Tools.YellowLine("This power-up increases your damage capability..");
            Tools.YellowLine("There are 3 different degrees of effectiveness");
            Tools.YellowLine("-Lesser: +50 bonus for 100 gold");
            Tools.YellowLine("-Minor: +100 bonus for 200 gold");
            Tools.YellowLine("-Major: +150 bonus for 300 gold\n");            
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

            input = Tools.ConvToInt32(3);

            switch (input)
            {
                case 1://+ stamina
                    BuyStaminaSwitch();
                    break;

                case 2://+ strength
                    BuyStrengthSwitch();
                    break;

                case 3:
                    BuySwitch();
                    break;
            }

            //loop som displayar alla power ups



            Sleep(2000);
        }
        private static void StaminaText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("===========================");
            Tools.YellowLine("|| --------Buy--------  ||");
            Tools.YellowLine("|| [1] Lesser Stamina.. ||");
            Tools.YellowLine("|| [2] Minor Stamina... ||");
            Tools.YellowLine("|| [3] Major Stamina... ||");
            Tools.YellowLine("|| [4] Back............ ||");
            Tools.YellowLine("===========================\n");
            Tools.Yellow("-Lesser:"); Tools.Green("+50 hp"); Tools.YellowLine("for 100 gold");
            Tools.Yellow("-Minor:"); Tools.Green("+100 hp"); Tools.YellowLine("for 200 gold");
            Tools.Yellow("-Major:"); Tools.Green("+150 hp"); Tools.YellowLine("for 300 gold\n");
            Tools.RedLine("   :~:     ");
            Tools.RedLine("   | |     ");
            Tools.RedLine("  .' '.    ");
            Tools.RedLine(".'     '.  ");
            Tools.RedLine("|  Sta  |  ");
            Tools.RedLine("'.......'\n");
        }
        private static void StrengthText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("===========================");
            Tools.YellowLine("|| ---------Buy--------  ||");
            Tools.YellowLine("|| [1] Lesser Strength.. ||");
            Tools.YellowLine("|| [2] Minor Strength... ||");
            Tools.YellowLine("|| [3] Major Strength... ||");
            Tools.YellowLine("|| [4] Back............. ||");
            Tools.YellowLine("===========================\n");
            Tools.Yellow("-Lesser:"); Tools.Red("+50 damage"); Tools.YellowLine("for 100 gold");
            Tools.Yellow("-Minor:"); Tools.Red("+100 damage"); Tools.YellowLine("for 200 gold");
            Tools.Yellow("-Major:"); Tools.Red("+150 damage"); Tools.YellowLine("for 300 gold\n");
            Tools.RedLine("   :~:     ");
            Tools.RedLine("   | |     ");
            Tools.RedLine("  .' '.    ");
            Tools.RedLine(".'     '.  ");
            Tools.RedLine("|  Str  |  ");
            Tools.RedLine("'.......'\n");
        }
        private static void BuyStaminaSwitch()
        {           
            StaminaText();

            int nr = Tools.ConvToInt32(4);

            switch (nr)
            {
                case 1:
                case 2:
                case 3:
                    purchaseOk = GoldWithdraw(nr-1, "power-up");
                    if (purchaseOk)
                    {
                        Player.player.MaxHp += PowerUp.itemList[nr - 1].bonus;
                        Player.player.Hp += PowerUp.itemList[nr - 1].bonus;
                        Tools.YellowLine("Max health increased!");
                        Tools.GreenLine($"+{PowerUp.itemList[nr - 1].bonus}.");
                    }
                    BuyStrengthSwitch();
                    break;

                case 4://Back
                    BuyPowerUpSwitch();
                    break;
            }

        }
        private static void BuyStrengthSwitch()
        {
            StrengthText();
            int nr = Tools.ConvToInt32(4);

            switch (nr)
            {
                case 1:
                case 2:
                case 3:
                    purchaseOk = GoldWithdraw(nr-1, "power-up");
                    if (purchaseOk)
                    {
                        Player.player.Dmg += PowerUp.itemList[nr - 1].bonus;
                        Tools.YellowLine("The power flows through you!");
                        Tools.GreenLine($"+{PowerUp.itemList[nr - 1].bonus} damage.");
                    }
                        BuyStrengthSwitch();
                    break;

                case 4://Back
                    BuyPowerUpSwitch();
                    break;
            }

        }
        //Buy Power-Ups END


        //Buy Potions START
        private static void BuyPotionText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("==============================");
            Tools.YellowLine("|| ------Healing Potions------ ||");
            Tools.YellowLine("|| [1] Lesser Healing Potion.. ||");
            Tools.YellowLine("|| [2] Minor Healing potion... ||");
            Tools.YellowLine("|| [3] Major Healing potion... ||");
            Tools.YellowLine("|| [4] Back................... ||");
            Tools.YellowLine("============================== \n");


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

            input = Tools.ConvToInt32(4);
           

            switch (input)
            {

                case 1:
                case 2:
                case 3:
                    purchaseOk = GoldWithdraw(input-1, "potion");
                    if (purchaseOk)
                    {
                        Player.player.LesserPotion++;
                        Tools.GreenLine($"1 {Consumable.itemList[input - 1].name} has been added to your inventory!");
                    }
                    Sleep(2000);

                    BuyPotionSwitch();
                    break;                                  

                case 4:
                    BuySwitch();
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

            input = Tools.ConvToInt32(Player.player.InventoryList.Count);

            Console.WriteLine($"There you go, {Weapon.weapon.WeaponList[input - 1].GoldIfSold} gold coins.");
            Player.player.Gold += Weapon.weapon.WeaponList[input - 1].GoldIfSold; //You get half the cost back from selling

            Sleep(2000);
            BuyOrSellSwitch();
        }
        //Sell END


        public static void MainMenuStore()
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


        //GoldWithdraw START
        private static bool GoldWithdraw(int index, string product)
        {         


            if (product == "weapon")
            {
                if (Player.player.Gold >= Weapon.weapon.WeaponList[index - 1].GoldCost)
                {
                    Tools.YellowLine($"\n-{Weapon.weapon.WeaponList[index - 1].GoldCost} Gold has been withdrawn from your pouch");
                    Player.player.Gold -= Weapon.weapon.WeaponList[index - 1].GoldCost;
                    purchaseOk = true;
                }
                else if (Player.player.Gold < Weapon.weapon.WeaponList[index - 1].GoldCost)
                {
                    purchaseOk = false;
                }
            }
            else if (product == "potion")
            {
                Consumable.pot.Instantiate();
                if (Player.player.Gold >= Consumable.itemList[index].goldCost)
                {
                    Player.player.Gold -= Consumable.itemList[index].goldCost;
                    purchaseOk = true;
                }
                else if (Player.player.Gold < Consumable.itemList[index].goldCost)
                {
                    purchaseOk = false;
                }
            }
            else if (product == "power-up")
            {
                PowerUp.powerUp.Instantiate();
                if (Player.player.Gold >= PowerUp.itemList[index].goldCost)
                {
                    Player.player.Gold -= PowerUp.itemList[index].goldCost;
                    purchaseOk = true;
                }
                else if (Player.player.Gold < PowerUp.itemList[index].goldCost)
                {
                    purchaseOk = false;
                }
            }
            if (purchaseOk == false)
            {
                Console.WriteLine("Not enough gold! Get back here when you can afford it!");
                // Sleep(1500);
                Console.WriteLine("Filthy creature..");
                // Sleep(1500);
            }
            return purchaseOk;

        }//GoldWithdraw() End
    }//Dealers.cs End
}
