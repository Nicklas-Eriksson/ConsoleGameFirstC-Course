using System;
using Labb3.Menues;
using Labb3.Character;
using Labb3.UtilityTools;
using Labb3.Story;
using static System.Threading.Thread;
using Labb3.Items;
using System.Collections.Generic;
using System.Media;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Labb3.StartGame
{
    [Serializable]
    public static class Start
    {
        static public void Game()
        {
            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + @"C:\Users\salk1\Music\NinjaMusic.mp3";
            //player.Play();


            Console.Title = "Dungeons of Daggorath";
            //Logo.DoD();
            //Sleep(3500);
            //Logo.RdyP1();
            //Sleep(2500);
            //Messange.GameInfo();

            if (!Directory.Exists("saves"))//Fixa så den inte crachar om inte mappen finns
            {
                Directory.CreateDirectory("saves");
            }

            NewGameOrLoadGame();

            Console.WriteLine("Press a key to keep going /debug");
            Console.ReadKey(); //Ta bort sen

            //Sleep(1400);
            //Messange.Intro();
            MenuOptions.MainMenuSwitch();


        }

        private static void NewGameOrLoadGame()
        {
            Console.Clear();
            Logo.DoD();

            Tools.YellowLine("=====================");
            Tools.YellowLine("|| [1] New Game... ||");
            Tools.YellowLine("|| [2] Load Game.. ||");
            Tools.YellowLine("|| [3] Exit Game.. ||");
            Tools.YellowLine("=====================\n");
                       
            int nr = Tools.ConvToInt32(3);
            switch (nr)
            {
                case 1:
                    NewGame();
                    break;
                case 2:
                    Player.player = SaveOrLoad.Load();
                    break;
                case 3:
                    Tools.ExitGame();
                    break;
            }
        }

        private static void NewGame()
        {
            Tools.Yellow("\n Enter character name: ");
            Player.player.Name = Console.ReadLine().Trim();//Stor bokstav på första??
            Tools.YellowLine($"\nGreetings {Player.player.Name}..\n");
            Player.player.Id = SaveOrLoad.idCounter + 1;//Kanske inte behövs..

            Player.GodMode(); //Checks if user is admin or Robin
            /* Names to avtivate god mode: Hakk, hakk, Robin, robin, Robin Kamo, robin kamo */
        }
    }
}
