using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Menues;
using Labb3.Player;
using Labb3.UtilityTools;
using Labb3.Story;
using static System.Threading.Thread;

namespace Labb3.StartGame
{
    public static class Start
    {
        public static CurrentPlayer player = new CurrentPlayer();

        static public  void Game()
        {
            Console.Title = "Dungeons of Daggorath";

            Logo.DoD();
            Sleep(3500);
            Logo.RdyP1();
            Sleep(2500);
            Messange.GameInfo();
            Tools.Yellow("Enter your name: ");
            player.Name = Console.ReadLine().Trim();
            Tools.YellowLine($"\nGreetings {player.Name}..");
            Sleep(1400);
            Messange.Intro();



        }
    }
}
