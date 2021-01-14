﻿using System;
using System.Collections.Generic;
using System.Text;
using Labb3.UtilityTools;

namespace Labb3.Story
{
    static public class Messange
    {
        static public void GameInfo()
        {
            Console.Clear();
            Tools.YellowLine("Welcome to Dungeons of Daggorath!");
            Tools.YellowLine("This is a text only, choose your own adventure game.");
            Tools.YellowLine("Creator: Nicklas Eriksson, 2021.");
            Tools.YellowLine("Inspiration:\n" +
                "DnD module \"Dungeons of Daggorath\" by Douglas J. Morgan, 1982,\n" +
                "Ready Player One by Ernest Cline, 2018 &\n" +
                "The wicked mind of H.P Lovecraft 1890-1937");
            Tools.YellowLine("______________________________________________________");
            Tools.YellowLine(
                "You will be faced with options as you progress deeper down\n" +
                "the dungeon. What adventure you take, thats up to you.\n" +
                "Read the instructions as they present themself,\n" +
                "and make your decision in the console window.\n" +
                "As you grow stronger, so will also the monsters, and keep a close look on your\n" +
                "healt. You don't want to be caught out without any..\n");

            Console.WriteLine("Press any key when you are done reading...");
            Console.ReadKey();
            Console.Clear();
        }
        static public void Intro()
        {
            Tools.YellowLine("As you wander closer to your destination, you feel light on\n" +
                "your feet. With a brad smile you fantisize about all the treasure that\n" +
                "you will come across down in that forsaken dungeon.\n" +
                "Roumors has it became a smugglers den after it was shut down for bussines 55 years ago..\n" +
                "The smugglers are long gone by now, since the plague had its way  all those years ago.\n" +
                "So you stride onward, confident and armored with bravery and your wooden practise sword\n" +
                "that your dad made for you at your 18th birthday last year.\n");
            Console.WriteLine("Press any key when you are done reading...");
            Console.ReadKey();
        }
    }
}