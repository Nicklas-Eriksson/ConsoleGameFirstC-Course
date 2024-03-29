﻿using Labb3.Character;
using Labb3.Items;
using Labb3.Menues;
using Labb3.UtilityTools;
using System;
using System.Collections.Generic;
using static System.Threading.Thread;

namespace Labb3.Store
{
    [Serializable]
    public static class Dealers
    {
        private static int input;
        private static bool purchaseOk;
        static private int readOnce;
        static private int readOnce2;

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
            Console.Clear();
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
                    Tools.ExitGame(false);
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
            while (readOnce == 0)
            {
                PowerUp.powerUp.Instantiate();
                Potions.Instantiate();
                readOnce++;
            }
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
                    Tools.ExitGame(false);
                    break;
            }
        }
        //Buy Options END

        //Buy Weapons START
        public static void DisplayWeapons()
        {
            Console.Clear();
            Logo.Shop();

            Console.WriteLine("\n Write the number of the weapon\n you would like to purchase:\n");

            //Display Weapons for shop, loops through the whole weapon list
            for (int i = 0; i < Weapon.weapon.WeaponList.Count; i++)
            {
                if (i == 1)
                {
                    Tools.DrawCharacterStatus();
                }
                BuyWeaponText(i);
            }
            Tools.DrawCharacterStatus();

            Console.WriteLine("------------------------------");
        }

        private static void BuyWeaponText(int i)//will be looped through in BuyInstruct()
        {
            Console.WriteLine("------------------------------");
            Tools.YellowLine($"[{i + 1}]: {Weapon.weapon.WeaponList[i].Name}");
            Tools.Yellow($"Weapon damage: +{Weapon.weapon.WeaponList[i].Power} damage");

            //This if statement displays how much + or - dmg the weapons in the store gives vs current weapon
            if (Player.player.WeaponIndex >= 0) //Check if higher since default weapon index for wooden sword is -1
            {
                if (Weapon.weapon.WeaponList[i].Power > Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power && Weapon.weapon.WeaponList[i].Name != Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Name)
                {
                    Tools.GreenLine($" +{Weapon.weapon.WeaponList[i].Power - Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power} on current weapon");
                }
                else if (Weapon.weapon.WeaponList[i].Power == Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power)
                {
                    Tools.BlueLine($" +{Weapon.weapon.WeaponList[i].Power - Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power} on current weapon");
                }
                else if (Weapon.weapon.WeaponList[i].Power < Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power)
                {
                    Tools.RedLine($" {Weapon.weapon.WeaponList[i].Power - Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power} on current weapon");
                }
            }
            else
            {
                Tools.GreenLine($" +{Weapon.weapon.WeaponList[i].Power} on equipped weapon");
            }
            Tools.YellowLine($"Cost to purchase: {Weapon.weapon.WeaponList[i].GoldCost} Gold");
        }

        static public void BuyWeapon()
        {
            List<IItem> IItemList = new List<IItem>(); //Interface list <----

            Logo.Shop();
            DisplayWeapons();

            input = Tools.ConvToInt32(Weapon.weapon.WeaponList.Count);

            bool sucessfulPurchase = GoldWithdraw(input, "weapon");

            if (sucessfulPurchase)
            {
                Tools.GreenLine($"\n {Weapon.weapon.WeaponList[input - 1].Name} has been equipped as your weapon");
                Player.player.WeaponDmg = Weapon.weapon.WeaponList[input - 1].Power;

                int wepIndex = 0;
                for (int i = 0; i < Weapon.weapon.FullWeaponList.Count; i++)
                {
                    if (Weapon.weapon.FullWeaponList[i].Name == Weapon.weapon.WeaponList[input - 1].Name)
                    {
                        wepIndex = i;
                        break;
                    }
                }

                Player.player.WeaponIndex = wepIndex;
                /* WeaponIndex is a way for me to access the weapon at the correct index when calling on the full weapon list. One of many ways to do it */

                IItemList.Add(Weapon.weapon.WeaponList[input - 1]);
                Item.SetList(IItemList); //adds this list to the main Interface list for holding inventory items
                Weapon.weapon.WeaponList.RemoveAt(input - 1); //test

                Sleep(2500);
            }
            else
            {
                Sleep(1400);
                MenuOptions.MainMenuSwitch();
            }

            BuyOrSellSwitch();
        }

        //Buy Weapons END

        //Buy Power-Ups START
        private static void BuyPowerUpText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine(@"
 ===========================
 || ------Power-Ups------ ||
 || [1] Buy Stamina...... ||
 || [2] Buy Strength..... ||
 || [3] Back............. ||");
            Tools.YellowLine("===========================");
            Tools.DrawCharacterStatus();

            Tools.YellowLine("\n Okey, listen up!");
            Tools.YellowLine("There are two different types of power-ups..\n");
            Tools.Green("Stamina:"); Tools.YellowLine("Increases your max health.");
            Tools.Red("Strength:"); Tools.YellowLine("Increases your attack damage.\n");
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
            Sleep(2000);
        }

        private static void StaminaText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine(@"
 ===========================
 || ---------Buy--------  ||
 || [1] Minor Stamina.... ||
 || [2] Greater Stamina.. ||
 || [3] Major Stamina.... ||
 || [4] Back............. ||");
            Tools.DrawCharacterStatus();
            Tools.YellowLine("==========================\n");

            for (int i = 0; i < PowerUp.staminaList.Count; i++)
            {
                Tools.Yellow($"-{PowerUp.staminaList[i].Name}:"); Tools.Green($"+{PowerUp.staminaList[i].Bonus} hp"); Tools.YellowLine($"for {PowerUp.staminaList[i].GoldCost} gold");
            }
            Console.WriteLine();
        }

        private static void StrengthText()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("============================");
            Tools.YellowLine("|| ----------Buy--------  ||");
            Tools.YellowLine("|| [1] Minor Strength.... ||");
            Tools.YellowLine("|| [2] Greater Strength.. ||");
            Tools.YellowLine("|| [3] Major Strength.... ||");
            Tools.YellowLine("|| [4] Back.............. ||");
            Tools.YellowLine("============================\n");

            Tools.DrawCharacterStatus();

            for (int i = 0; i < PowerUp.strengthList.Count; i++)
            {
                Tools.Yellow($"-{PowerUp.strengthList[i].Name}:"); Tools.Green($"+{PowerUp.strengthList[i].Bonus} damage"); Tools.YellowLine($"for {PowerUp.strengthList[i].GoldCost} gold");
            }
            Console.WriteLine();
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
                    purchaseOk = GoldWithdraw(nr - 1, "power-up");
                    if (purchaseOk)
                    {
                        Player.player.MaxHp += PowerUp.staminaList[nr - 1].Bonus;
                        Player.player.Hp += PowerUp.staminaList[nr - 1].Bonus;
                        Tools.YellowLine("\n Max health increased!");
                        Tools.GreenLine($"+{PowerUp.staminaList[nr - 1].Bonus} max health.");
                        Tools.YellowLine($"-{PowerUp.staminaList[nr - 1].GoldCost} gold.");
                        Sleep(1500);
                    }
                    BuyStaminaSwitch();
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
                    purchaseOk = GoldWithdraw(nr - 1, "power-up");
                    if (purchaseOk)
                    {
                        Player.player.BaseDamage += PowerUp.strengthList[nr - 1].Bonus;
                        Tools.YellowLine("\n The power flows through you!");
                        Tools.GreenLine($"+{PowerUp.strengthList[nr - 1].Bonus} base damage.");
                        Tools.YellowLine($"-{PowerUp.strengthList[nr - 1].GoldCost} gold");
                        Sleep(1500);
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
            Tools.YellowLine("==================================");
            Tools.YellowLine("|| -------Healing Potions------ ||");
            Tools.YellowLine("|| [1] Minor Healing Potion.... ||");
            Tools.YellowLine("|| [2] Greater Healing potion.. ||");
            Tools.YellowLine("|| [3] Major Healing potion.... ||");
            Tools.YellowLine("|| [4] Back.................... ||");
            Tools.DrawCharacterStatus();
            Tools.YellowLine("==================================\n");

            Tools.YellowLine("This red little bottle will maybe one day be your life saver.. ");
            Tools.YellowLine("I mean it.. Literally, you wont die if you drink it..");
            Tools.YellowLine("Pinkie swear...\n");


            for (int i = 0; i < Potions.potionList.Count; i++)
            {
                Tools.Yellow($"{Potions.potionList[i].Name}: {Potions.potionList[i].GoldCost} gold");
                Tools.GreenLine($"+{Potions.potionList[i].Bonus} healing");
            }
            Console.WriteLine();
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
                    purchaseOk = GoldWithdraw(input - 1, "potion");
                    if (purchaseOk)
                    {
                        if (input == 1)
                        {
                            Player.player.MinorPotion++;
                        }
                        else if (input == 2)
                        {
                            Player.player.GreaterPotion++;
                        }
                        else if (input == 3)
                        {
                            Player.player.MajorPotion++;
                        }
                        Tools.GreenLine($"\n 1 {Potions.potionList[input - 1].Name} has been added to your inventory!");
                        Tools.YellowLine($"\n -{Potions.potionList[input - 1].GoldCost} has been withdrawn from your pouch!");
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
        private static void SellTextMenu()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("====================================");
            Tools.YellowLine("|| -------------Sell------------- ||");
            Tools.YellowLine("|| Enter the number of the item   ||");
            Tools.YellowLine("||    you would like to sell.     ||");
            Tools.Yellow("||   To go back write"); Tools.Red("\"back\""); Tools.YellowLine("     ||");
            Tools.YellowLine("==================================== \n");
            Tools.DrawCharacterStatus();
        }

        private static void SellSwitch()
        {
            bool success;
            List<IItem> items = Item.GetList();

            do
            {
                SellTextMenu();
                Player.DisplayInventory();

                Tools.Yellow("\n Option: ");

                string _input = Console.ReadLine().Trim().ToLower();

                if (_input == "back" || _input == "b")
                {
                    BuyOrSellSwitch();
                }

                success = Int32.TryParse(_input, out int nr);
                if (nr <= items.Count)
                {
                    if (Player.player.WeaponIndex >= 0) //If weapon is equipped
                    {
                        if (Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Name == items[nr - 1].Name) //If you sell your equipped weapon
                        {
                            Player.player.Gold += Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].GoldIfSold;
                            items.RemoveAt(nr - 1);
                            Player.ItemList.RemoveAt(nr - 1);
                            Tools.GreenLine("Back to your wooden sword I guess!");
                            Player.player.WeaponIndex = -1;
                        }
                        else
                        {
                            Tools.GreenLine($"\n {items[nr - 1].Name} sold, +{items[nr - 1].GoldIfSold} gold coins.");
                            Player.player.Gold += items[nr - 1].GoldIfSold;
                            items.RemoveAt(nr - 1);
                        }
                    }
                    else //If no weapon is equipped
                    {
                        Tools.GreenLine($"\n {items[nr - 1].Name} sold, +{items[nr - 1].GoldIfSold} gold coins.");
                        Player.player.Gold += items[nr - 1].GoldIfSold;
                        items.RemoveAt(nr - 1);
                    }
                }
                else
                {
                    Tools.GreenLine($"\n {items[nr - 1].Name} sold, +{items[nr - 1].GoldIfSold} gold coins.");
                    Player.player.Gold += items[nr - 1].GoldIfSold;
                    items.RemoveAt(nr - 1);
                }

            } while (!success);
            Tools.PressEnterToContinue();

            BuyOrSellSwitch();
        }

        //Sell END

        public static void MainMenuStore()
        {
            while (readOnce2 == 0)
            {
                Console.Clear();
                Logo.Shop();
                Tools.YellowLine("Welcome to The Iron Skillet!");
                Tools.YellowLine("It's not often we get customers these days..");
                Tools.YellowLine("Anyways!..");
                Tools.PressEnterToContinue();
                readOnce2++;
            }
            BuyOrSellSwitch();
        }

        //GoldWithdraw START
        private static bool GoldWithdraw(int index, string product)
        {
            if (product == "weapon")
            {
                if (Player.player.Gold >= Weapon.weapon.WeaponList[index - 1].GoldCost)
                {
                    Tools.YellowLine($"\n -{Weapon.weapon.WeaponList[index - 1].GoldCost} Gold has been withdrawn from your pouch");
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
                if (Player.player.Gold >= Potions.potionList[index].GoldCost)
                {
                    Player.player.Gold -= Potions.potionList[index].GoldCost;
                    purchaseOk = true;
                }
                else if (Player.player.Gold < Potions.potionList[index].GoldCost)
                {
                    purchaseOk = false;
                }
            }
            else if (product == "power-up")
            {
                //Does not matter which list I take gold cost from since they are the same
                if (Player.player.Gold >= PowerUp.staminaList[index].GoldCost)
                {
                    Player.player.Gold -= PowerUp.staminaList[index].GoldCost;
                    purchaseOk = true;
                }
                else if (Player.player.Gold < PowerUp.staminaList[index].GoldCost)
                {
                    purchaseOk = false;
                }
            }
            if (!purchaseOk)
            {
                Tools.RedLine("Not enough gold! Get back here when you can afford it!");
                Tools.RedLine("Filthy creature..");
                Tools.PressEnterToContinue();
            }
            return purchaseOk;
        }//GoldWithdraw() End
    }//Dealers.cs End
}