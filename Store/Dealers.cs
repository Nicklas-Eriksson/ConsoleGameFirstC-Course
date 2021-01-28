using Labb3.Character;
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

            //DisplayPlayerGoldAndSuch();

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

        private static void BuyWeaponText(int nr)//will be looped through in BuyInstruct()
        {
            Console.WriteLine("------------------------------");
            Tools.YellowLine($"[{nr + 1}]: {Weapon.weapon.WeaponList[nr].Name}");
            Tools.Yellow($"Weapon damage: +{Weapon.weapon.WeaponList[nr].Power} damage");

            //This if statement displays how much + or - dmg the weapons in the store gives vs current weapon
            if (Player.player.WeaponIndex >= 0) //Check if higher since default weapon index for fist is -1
            {
                if (Weapon.weapon.WeaponList[nr].Power >= Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power && Weapon.weapon.WeaponList[nr].Name != Weapon.weapon.WeaponList[Player.player.WeaponIndex].Name)
                {
                    Tools.GreenLine($" +{Weapon.weapon.WeaponList[nr].Power - Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power} on current weapon");
                }
                else if (Weapon.weapon.WeaponList[nr].Power == Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Power)
                {
                    Tools.BlueLine($" +{Weapon.weapon.WeaponList[nr].Power - Weapon.weapon.WeaponList[Player.player.WeaponIndex].Power} on current weapon");
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

                //test
                // Player.MyWeapons.Add(Weapon.weapon.WeaponList[input - 1]);//Should be able to save a list with an implemented interface, but it did not work for me somehow.

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
            Tools.YellowLine("==========================");

            Tools.Yellow("\n -Minor:"); Tools.Green("+50 hp"); Tools.YellowLine("for 100 gold");
            Tools.Yellow("-Greater:"); Tools.Green("+100 hp"); Tools.YellowLine("for 200 gold");
            Tools.Yellow("-Major:"); Tools.Green("+150 hp"); Tools.YellowLine("for 300 gold\n");
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

            Tools.Yellow("-Minor:"); Tools.Red("+50 damage"); Tools.YellowLine("for 100 gold");
            Tools.Yellow("-Greater:"); Tools.Red("+100 damage"); Tools.YellowLine("for 200 gold");
            Tools.Yellow("-Major:"); Tools.Red("+150 damage"); Tools.YellowLine("for 300 gold\n");

            Tools.RedLine(@"
              $$$$$$$$$$
             $$__$_____$$$$$
             $$_$$__$$____$$$$$$$$
            $$_$$__$$$$$________$$$
           $$_$$__$$__$$_$$$__$$__$$
           $$_$$__$__$$__$$$$$$$$__$$
            $$$$$_$$_$$$_$$$$$$$$_$$$
             $$$$$$$$$$$$$_$$___$_$$$$
                $$_$$$      $$$$$_$$$$
                 $$$$       $$$$$___$$$
                           $$_$$____$$$$
                           $$_$$____$$$$$
                          $$$$$_____$$$$$$
                         $__$$_______$$$$$
                        $$$_$$________$$$$$
                        $$$___________$$$$$
                 $$$$   $$____________$$$$$$
  $$$$$$$$    $$$$$$$$$$ $____________$$$_$$
 $$$$$$$$$$$$$$$______$$$$$$$___$$____$$_$$$
$$________$$$$__________$_$$$___$$$_____$$$$
$$______$$$_____________$$$$$$$$$$$$$$$$$_$$
$$______$$_______________$$_$$$$$$$$$$$$$$$
$$_____$_$$$$$__________$$$_$$$$$$$$$$$$$$$
$$___$$$__$$$$$$$$$$$$$$$$$__$$$$$$$$$$$$$
$$_$$$$_____$$$$$$$$$$$$________$$$$$$__$
$$$$$$$$$$$$$$_________$$$$$______$$$$$$$
$$$$_$$$$$______________$$$$$$$$$$$$$$$$
$$__$$$$_____$$___________$$$$$$$$$$$$$
$$_$$$$$$$$$$$$____________$$$$$$$$$$
$$_$$$$$$$$$$$$____$$$$$$$$__$$$
$$$$  $$$$$$$$$$$$$$$$$$$$$$$$
$$         $$$$$$$$$$$$$$$     ");
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

            Tools.YellowLine("This red little bottle will maby one day be your life saver.. ");
            Tools.YellowLine("I mean it.. Literally, you wont die if you drink it..");
            Tools.YellowLine("Pinky swear...\n");
            Tools.RedLine("   :~:       ");
            Tools.RedLine(" .'   '.     ");
            Tools.RedLine("|  HP+  |    ");
            Tools.RedLine("'.......'  \n");
        }

        private static void BuyPotionSwitch()
        {
            BuyPotionText();

            List<IItem> IItemList = new List<IItem>();

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
                        Tools.GreenLine($"\n 1 {Potions.itemList[input - 1].Name} has been added to your inventory!");
                        IItemList.Add(Potions.itemList[input - 1]);
                        Item.SetList(IItemList); //adds this list to the main Interface list for holding inventory items
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
                if (!success)
                {
                    Tools.Error();
                    Sleep(1300);
                }
                else if (Weapon.weapon.FullWeaponList[Player.player.WeaponIndex].Name == items[nr - 1].Name)
                {
                    Tools.RedLine("You can't sell an equipped weapon!");
                    success = false;
                    Sleep(2000);
                }
                else
                {
                    Tools.GreenLine($"\n {items[nr - 1].Name} sold, +{items[nr - 1].GoldIfSold} gold coins.");
                    Player.player.Gold += items[nr - 1].GoldIfSold;
                    items.RemoveAt(nr - 1);
                    Sleep(2000);
                }
            } while (!success);

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
                Potions.Instantiate();
                if (Player.player.Gold >= Potions.itemList[index].GoldCost)
                {
                    Player.player.Gold -= Potions.itemList[index].GoldCost;
                    purchaseOk = true;
                }
                else if (Player.player.Gold < Potions.itemList[index].GoldCost)
                {
                    purchaseOk = false;
                }
            }
            else if (product == "power-up")
            {
                //Does not matter which list I take gold cost from since they are the same
                PowerUp.powerUp.Instantiate();
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
                Sleep(1400);
                Tools.RedLine("Filthy creature..");
                Sleep(1400);
            }
            return purchaseOk;
        }//GoldWithdraw() End
    }//Dealers.cs End
}