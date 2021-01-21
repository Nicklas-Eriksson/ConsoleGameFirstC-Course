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
using System.Threading;

namespace Labb3.StartGame
{
    [Serializable]
    public static class Start
    {

        static public void Game()
        {
            Console.Title = "Dungeons of Solitude";
            Console.WindowHeight = 55;
            Console.WindowWidth = 100;

            //Music
            SoundPlayer music = new SoundPlayer("music/NinjaMusicWAV.wav");
            //SoundPlayer music2 = new SoundPlayer("music/BlueLanternWAV.wav");
            music.PlayLooping();

            //Logo.SaveGame();
            //Console.ReadKey();

            

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

            music.Stop();

        }

        private static void NewGameOrLoadGame()
        {
            Console.Clear();
            Logo.DoS();

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
