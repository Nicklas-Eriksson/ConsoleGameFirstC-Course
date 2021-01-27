using System;
using Labb3.Menues;
using Labb3.Character;
using Labb3.UtilityTools;
using Labb3.Items;
using System.Media;
using System.IO;

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
            music.PlayLooping();                        

            if (!Directory.Exists("saves"))//Fixa så den inte crachar om inte mappen finns
            {
                Directory.CreateDirectory("saves");
            }

            NewGameOrLoadGame();

            Tools.PurpleLine("\n -Press any key to continue-");
            Console.ReadKey();

            //Sleep(1400);

            MenuOptions.MainMenuSwitch();

            music.Stop();
        }

        private static void NewGameOrLoadGame()
        {
            Console.Clear();
            Logo.DoS();
            Weapon.weapon.GetFullWeaponList();


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
                    Tools.ExitGame(false);
                    break;
            }
        }

        public static void NewGame()
        {
            Tools.Yellow("\n Enter character name: ");
            Player.player.Name = Console.ReadLine().Trim();//Stor bokstav på första??
            Tools.YellowLine($"\n Greetings {Player.player.Name}..\n");
            Player.GodMode(); //Checks if user is admin or Robin
            /* Names to activate GodMode: Hakk, hakk, Robin, robin, Robin Kamo, robin kamo */

            Player.player.Id = SaveOrLoad.idCounter + 1;//Kanske inte behövs..

            //Messange.Intro();

        }
    }
}
