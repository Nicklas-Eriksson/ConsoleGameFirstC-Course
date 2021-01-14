using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Menues;
using Labb3.UtilityTools;
using Labb3.Items;
using static System.Threading.Thread;
using Labb3.Player;

namespace Labb3.Store
{
    public static class Dealers
    {
        static private List<Weapon> fullWepList = CurrentWeapon.weapon.GetFullWeaponList();

        private static void StoreMenueIronSkillet()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("Welcome to The Iron Skillet!"); //Sleep(1400);
            Tools.YellowLine("It's not often we get customers these days..");  //Sleep(2000);
            Tools.YellowLine("Anyways!..");  //Sleep(1300);
            Tools.YellowLine("Here are my goods!\n"); // Sleep(2400);
        }

        public static void WeaponIcons()
        {
            Console.Clear();
            Logo.Shop();
            //Broadsword
            Console.WriteLine("Write the number of the weapon you would like to purchase:\n");
            Tools.YellowLine("[1]: Sword");
            Tools.BlueLine(
                           "       |______________\n" +
                           "[======|______________ >\n" +
                           "       |");
            Tools.YellowLine("Blunt broadsword: +2 Damage");
            Tools.YellowLine("Cost to purchase: 100 Gold");
            Console.WriteLine("------------------------------");

            //Dagger 
            Tools.YellowLine("[2]: Dagger");
            Tools.BlueLine(
               "    #\n" +
               "O===#========-\n" +
               "    #");
            Tools.YellowLine("Rusty dagger: +1 Damage + 0-2");
            Tools.YellowLine("Cost to purchase: 100 Gold");
            Console.WriteLine("------------------------------");

            //Heavy Axe
            Tools.YellowLine("[3]: Axe");
            Tools.BlueLine(
                           "###################\n" +
                           "          |       |\n" +
                           "           \\     /\n" +
                           "            ¨¨¨¨¨¨");
            Tools.YellowLine("Unbalanced axe: 0 Damage + 0-6 Damage");
            Tools.YellowLine("Cost to purchase: 100 Gold");
            Console.WriteLine("------------------------------");
        } //fel info

        static public void BuyingWeaponSwitch()
        {
            
            //Weapon weapon = new Weapon();
            //List<Weapon> fullWepList = weapon.GetFullWeaponList();


            StoreMenueIronSkillet();
            WeaponIcons();

            int number;

            //Error handling for switch. Swap out?
            do
            {
                Tools.Yellow("Option: ");
                number = Tools.ConvToInt32(Console.ReadLine());
                if (number > 3)
                {
                    Tools.RedLine($"You entered a too high number: {number}.");
                    Tools.RedLine($"Keep it within the range of 1-3!");
                }
                else if (number < 1)
                {
                    Tools.RedLine($"You entered a too low number: {number}.");
                    Tools.RedLine($"Keep it within the range of 1-3!");
                }
            } while (number > 3 || number < 1);


            switch (number)
            {
                case 1:

                    Tools.GreenLine($"{fullWepList[number - 1].Name} has been equipped as your weapon");
                    Player.Player.player.Dmg += fullWepList[number - 1].Power;

                    //GoldWithdraw(number);


                    Sleep(1500);
                    MenuOptions.Options();
                    break;

                case 2:
                    Tools.GreenLine($"{CurrentWeapon.weapon.WeaponList[number - 1]} has been equipped as your weapon");
                    CurrentWeapon.weapon.SetCurrentWeapon(CurrentWeapon.weapon.WeaponList[number - 1]);
                    Sleep(1500);
                    MenuOptions.Options();
                    break;

                case 3:
                    Tools.GreenLine($"{CurrentWeapon.weapon.WeaponList[number - 1]} has been equipped as your weapon");
                    CurrentWeapon.weapon.SetCurrentWeapon(CurrentWeapon.weapon.WeaponList[number - 1]);
                    Sleep(1500);
                    MenuOptions.Options();
                    break;
            }
            Sleep(3000);
            MenuOptions.Options(); //Back to main menu
        }

        private static void GoldWithdraw(int number)
        {            
            //-gold  Break out to its own method
            if (Player.Player.player.Gold >= fullWepList[number - 1].GoldCost)
            {
                Console.WriteLine("fullWepList[number-1].GoldCost Gold has been withdrawn from your pouch");
                Player.Player.player.Gold -= fullWepList[number - 1].GoldCost;
            }
            else if (Player.Player.player.Gold < fullWepList[number - 1].GoldCost)
            {
                Console.WriteLine("Not enough gold! Get back here when you can afford it!");
                Console.WriteLine("Filthy creature..");
                Sleep(1500);
                BuyingWeaponSwitch();
            }
        }
    }
}
