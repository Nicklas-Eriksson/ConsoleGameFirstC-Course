using System;
using Labb3.Menues;
using Labb3.UtilityTools;
using static System.Threading.Thread;

namespace Labb3.Story
{
    static public class InfoAndStory
    {
        static public void GameInfo()
        {
            Console.Clear();
            Logo.DoS();
            Tools.YellowLine("Welcome to Dungeons of Solitude!");
            Tools.YellowLine("This is a text only, choose your own adventure game.");
            Tools.YellowLine("Creator: Nicklas Eriksson, 2021.");
            Tools.YellowLine("Inspiration:\n" +
                " DnD module \"Dungeons of Daggorath\" by Douglas J. Morgan, 1982,\n" +
                " Ready Player One by Ernest Cline, 2018 &\n" +
                " The wicked mind of H.P Lovecraft 1890-1937");
            Tools.YellowLine("______________________________________________________");
            Tools.YellowLine(
                "You will be faced with options as you progress deeper down\n" +
                " the dungeon. What adventure you take, thats up to you.\n" +
                " Read the instructions as they present themselves,\n" +
                " and make your decision in the console window.\n" +
                " As you grow stronger, so will also the monsters,\n" +
                " and keep a close look on your health.\n" +
                " You don't want to be caught out without any..");

            Tools.PressEnterToContinue();

            Console.Clear();
        }
        static public void Intro()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            const string intro = " As you wander closer to your destination, you feel light on\n" +
                " your feet. With a broad smile you fantasize about all the treasure that\n" +
                " you will come across down in that forsaken dungeon.\n" +
                " Rumors has it become a smuggler's den after it was shut down for business 55 years ago..\n" +
                " The smugglers are long gone by now, since the plague had its way  all those years ago.\n" +
                " So you stride onward, confident and armored with bravery and your wooden practice sword\n" +
                " that your dad made for you at your 18th birthday last year.\n";
            intro.ToCharArray();

            foreach (var letter in intro)
            {
                Console.Write(letter);
                Sleep(30);
            }
            Console.ResetColor();

            Sleep(1600);
        }

        static public void Outro()
        {
            Console.Clear();
            Logo.YouWon();

            Tools.YellowLine("You has beaten the game! Congratulations, now the world is free from horror and you can finally rest..\n");
            Sleep(1600);

            Tools.PurpleLine("-Press any key to exit the game-");
            Console.ReadKey();

            Tools.ExitGame(true);
        }
    }
}
