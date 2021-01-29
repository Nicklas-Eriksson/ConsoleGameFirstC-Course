using System;
using Labb3.Character;
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
                "You will be faced with options as you progress deeper down the dungeon.\n" +
                " Read the instructions and make your decisions in the console window.\n" +
                " As you grow stronger, so will the monsters.\n" +
                " And keep a close eye on your health!\n" +
                " You don't want to be caught without any..");

            Tools.PressEnterToContinue();

            Console.Clear();
        }
        public static void CharacterInfo()
        {
            Logo.DoS();
            Tools.PurpleLine("====================================================");
            Tools.YellowLine($"My name is {Player.player.Name}, and I come from\n a village called the Merchant's Gut.");
            Tools.YellowLine("The \"Gut\" is located in a mountain outcrop just\n beside the village's mining shafts.");
            Tools.YellowLine("Our town is a rugged one.. We get little to no");
            Tools.DrawCharacterStatus();
            Tools.YellowLine("sunshine during the day.");
            Tools.YellowLine("If you want to see the sun you have to sneak out\n and explore on your own.");
            Tools.YellowLine("The salesmen from the village are specialized in\n the gem trade.");
            Tools.YellowLine("If you don't find a big one you're in it deep..");
            Tools.YellowLine("The cost of living is immense.. Contribute or you\n get fed to the wolves, or worse..");
            Tools.YellowLine("You can get left in an old mining pit without any light\n or means to escape.");
            Tools.YellowLine("I myself just turned 18 this spring, so I'm\n not expected to work until next summer.");
            Tools.YellowLine("Naturally I'm a bit bored, and seeking\n adventure..");
            Tools.YellowLine("That's why I find myself in this dungeon I guess..");
            Tools.YellowLine("And no, my parents does not know I'm here,\n and they probably wouldn't care..");
            Tools.PurpleLine("====================================================");

            Tools.PressEnterToContinue();
        }
        public static void EmptyRoom()
        {
            Console.Clear();
            Logo.NoEncounter();
            Tools.YellowLine("You explore deeper into the dungeon.");
            Tools.YellowLine("You see a wooden door with a rusty knob and lock.");
            Tools.YellowLine("Slowly you turn the creaking door open..");
            Tools.YellowLine("To your surprise, the corridor is completely desolate...");

            Tools.PressEnterToContinue();
        }
        static public void Intro()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            const string intro = " As you wander closer to your destination, you feel light on\n" +
                " your feet. With a wide smile you fantasize about all the treasure that\n" +
                " you will come across down in that forsaken dungeon.\n" +
                " Rumors has it that it became a smuggler's den after it was shut down for business 55 years ago..\n" +
                " The smugglers are long gone by now, since the plague had its way all those years ago.\n" +
                " So you stride onward, confident and armored with bravery and your wooden practice sword\n" +
                " that your dad made for you for your 18th birthday last year.\n";
            intro.ToCharArray();

            foreach (var letter in intro)
            {
                Console.Write(letter);
                Sleep(30);
            }
            Console.ResetColor();
        }

        static public void Outro()
        {
            Console.Clear();
            Logo.YouWon();

            Tools.YellowLine("You have beaten the game! Congratulations, now the world is free from horror and you can finally rest..\n");

            Tools.PurpleLine("-Press any key to exit the game-");
            Console.ReadKey();

            Tools.ExitGame(true);
        }
    }
}
