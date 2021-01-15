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

        static private void instanceateList()//Ta listan från weapons istället
        {
            if (fullWepList.Count == 0)
            {
                fullWepList = Weapon.weapon.GetFullWeaponList();
            }
        }

        private static void StoreMenueIronSkillet()
        {
            Console.Clear();
            Logo.Shop();
            Tools.YellowLine("Welcome to The Iron Skillet!"); //Sleep(1400);
            Sleep(2000);
            Tools.YellowLine("It's not often we get customers these days..");  //Sleep(2000);
            Sleep(2000);
            Tools.YellowLine("Anyways!..");  //Sleep(1300);
            Sleep(2000);
            Tools.YellowLine("Here are my goods!\n"); // Sleep(2400);
            Sleep(2000);
        }
        public static void BuyInstruct()
        {
            Console.Clear();
            Logo.Shop();

            Console.WriteLine("Write the number of the weapon you would like to purchase:\n");

            //Display Weapons for shop, loops through the whole weapon list 
            for (int i = 0; i < fullWepList.Count; i++)
            {
                BuyWeaponText(i);
            }
        }
        public static void BuyWeaponText(int nr)//will be looped through in BuyInstruct()
        {
            Tools.YellowLine($"[{nr + 1}]: {fullWepList[nr].Name}");
            Tools.YellowLine($"Weapon power: +{fullWepList[nr].Power} damage");
            Tools.YellowLine($"Cost to purchase: {fullWepList[nr].GoldCost} Gold");
            Console.WriteLine("------------------------------");
        }

        static public void BuyWeapon()
        {
            instanceateList();
            StoreMenueIronSkillet();
            BuyInstruct();

            //Add remove bought iteam??

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
                    Tools.RedLine($"You entered a too low number: {number - 1}.");
                    Tools.RedLine($"Keep it within the range of 1-{fullWepList.Count}!");
                }

            } while (number > fullWepList.Count || number - 1 <= 1);


            Tools.GreenLine($"{fullWepList[number - 1].Name} has been equipped as your weapon");
            Player.player.WeaponDmg = fullWepList[number - 1].Power;
            Player.player.WeaponIndex = number - 1;//A way for me to access the weapon at the correct index when calling on the full weapon list. One of many ways to do it
            Sleep(1500);


            //GoldWithdraw(number-1);


            fullWepList.Clear();//test if this works, last time on visiting the shop more than once, wrote out double wep list.
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
                BuyWeapon();
            }
        }
    }
}
