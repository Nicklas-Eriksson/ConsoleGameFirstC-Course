using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Menues;
using Labb3.UtilityTools;
using Labb3.Items;
using static System.Threading.Thread;

namespace Labb3.Store
{
    public static class Dealers
    {
        public static void StoreMenueIronSkillet()
        {
            Logo.Shop();
            Tools.YellowLine("Welcome to The Iron Skillet!"); Sleep(1400);
            Tools.YellowLine("It's not often we get customers these days.."); Sleep(2000);
            Tools.YellowLine("Anyways!.."); Sleep(1300);
            Tools.YellowLine("Here are my goods!\n"); Sleep(1400);
        }

        public static void WeaponIcons()
        {
            //Broadsword
            Console.WriteLine("Write the number of the weapon you would like to purchase:\n");
            Console.WriteLine("[1]: Sword");
            Tools.BlueLine(
                           "       |______________\n" +
                           "[======|______________ >\n" +
                           "       |");
            Tools.BlueLine("Blunt broadsword: +2 Damage");
            Tools.BlueLine("Cost to purchase: 100 Gold");
            Console.WriteLine("------------------------------");

            //Dagger 
            Console.WriteLine("[2]: Dagger");
            Tools.BlueLine(
               "    #\n" +
               "O===#========-\n" +
               "    #");
            Tools.BlueLine("Rusty dagger: +1 Damage + 0-2");
            Tools.BlueLine("Cost to purchase: 100 Gold");
            Console.WriteLine("------------------------------");

            //Heavy Axe
            Console.WriteLine("[3]: Axe");
            Tools.BlueLine(
                           "#############\n" +
                           "        |   |\n" +
                           "        ¨¨¨¨");
            Tools.BlueLine("Unbalanced axe: 0 Damage + 0-6 Damage");
            Tools.BlueLine("Cost to purchase: 100 Gold");
            Console.WriteLine("------------------------------");
        }

        static public void BuyingWeaponSwitch()
        {
            
            string input;
            int number;
            do
            {
                input = Console.ReadLine();
                number = Tools.ConvToInt32(input);
                if(number > 3)
                { Tools.RedLine("You need to keep within the range of 1-3"); }
            } while (number <= 3);



            Console.WriteLine($"You opted for option {number}");
            if (number == 1)
            { Console.WriteLine("Blunt broadsword has been equipped as your weapon"); }
            else if (number == 2)
            { Console.WriteLine("Rusty dagger has been equipped as your weapon"); }
            else if (number == 3)
            { Console.WriteLine("Unbalanced axe has been equipped as your weapon"); }

            switch (number)
            {
                case 1:
                    //gold - and add weapon
                    break;
                case 2:
                    break;
                case 3:

                    break;
            }
        }
    }
}
