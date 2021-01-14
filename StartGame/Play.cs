using System;
using Labb3.Menues;
using Labb3.Player;
using Labb3.UtilityTools;
using Labb3.Story;
using static System.Threading.Thread;
using Labb3.Items;
using System.Collections.Generic;

namespace Labb3.StartGame
{
    public static class Start
    {
        static public void Game()
        {            
            //List<Weapon> wepList = weapon.ReturnList();
                    

            
            //Console.Title = "Dungeons of Daggorath";
            //Logo.DoD();
            //Sleep(3500);
            //Logo.RdyP1();
            //Sleep(2500);
            //Messange.GameInfo();
            Tools.Yellow("Enter your name: ");
            Player.Player.player.Name = Console.ReadLine().Trim();
            Tools.YellowLine($"\nGreetings {Player.Player.player.Name}..\n");
            Console.WriteLine("Player Name:" + Player.Player.player.Name);
            Console.WriteLine("Player HP:" + Player.Player.player.Hp);
            //Console.WriteLine("Player DMG:" + player.Power);
            Console.ReadKey();
            
            //Sleep(1400);
            //Messange.Intro();
            MenuOptions.Options();




        }
    }
}
