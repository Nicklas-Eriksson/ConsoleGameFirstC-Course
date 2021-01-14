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
        static private List<Weapon> fullWepList = Weapon.weapon.GetFullWeaponList();

        private static void StoreMenueIronSkillet()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("Welcome to The Iron Skillet!"); //Sleep(1400);
            Tools.YellowLine("It's not often we get customers these days..");  //Sleep(2000);
            Tools.YellowLine("Anyways!..");  //Sleep(1300);
            Tools.YellowLine("Here are my goods!\n"); // Sleep(2400);
        }
        public static void BuyWeapon(int nr)
        {
            Tools.YellowLine($"[{nr+1}]: {fullWepList[nr].Name}");
            Tools.YellowLine($"Weapon power: +{fullWepList[nr].Power} damage");
            Tools.YellowLine($"Cost to purchase: {fullWepList[nr].GoldCost} Gold");
            Console.WriteLine("------------------------------");
        }
        public static void WeaponIcons()
        {
            Console.Clear();
            Logo.Shop();

            Console.WriteLine("Write the number of the weapon you would like to purchase:\n");

            //Display Weapons for shop
            for (int i = 0; i < fullWepList.Count; i++)
            {
                BuyWeapon(i);
            }
        }

        static public void BuyingWeaponSwitch()
        {
            StoreMenueIronSkillet();
            WeaponIcons();

            int number;

            do
            {
                Tools.Yellow("Option: ");
                number = Tools.ConvToInt32(Console.ReadLine());


                if (number - 1 > fullWepList.Count)
                {
                    Tools.RedLine($"You entered a too high number: {number - 1}.");
                    Tools.RedLine($"Keep it within the range of 1-{fullWepList.Count}!");
                }
                else if (number - 1 <= 1)
                {
                    Tools.RedLine($"You entered a too low number: {number-1}.");
                    Tools.RedLine($"Keep it within the range of 1-{fullWepList.Count}!");
                }
            } while (number > fullWepList.Count || number-1 <= 1);


            Tools.GreenLine($"{fullWepList[number-1].Name} has been equipped as your weapon");
            Player.player.WeaponDmg = fullWepList[number-1].Power;
            Player.player.WeaponIndex = number-1;
            //GoldWithdraw(number-1);

            //test 
            fullWepList.Clear();
            Sleep(1500);
            MenuOptions.Options();
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
                BuyingWeaponSwitch();
            }
        }
    }
}
