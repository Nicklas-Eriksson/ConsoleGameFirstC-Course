using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Labb3.UtilityTools;

namespace Labb3.Menues
{
    static public class Logo
    {
        //Ascii Doom 
        static public void DoD()
        {
            Console.Clear();

            string[] daggorath = {
                "______                                          _____  __  ______                                  _   _",
                "|  _  \\                                        |  _  |/ _| |  _  \\                                | | | |",
                "| | | |_   _ _ __   __ _  ___  ___  _ __  ___  | | | | |_  | | | |__ _  __ _  __ _  ___  _ __ __ _| |_| |__",
                "| | | | | | | '_ \\ / _` |/ _ \\/ _ \\| '_ \\/ __| | | | |  _| | | | / _` |/ _` |/ _` |/ _ \\| '__/ _` | __| '_ \\ ",
                "| |/ /| |_| | | | | (_| |  __/ (_) | | | \\__ \\ \\ \\_/ / |   | |/ / (_| | (_| | (_| | (_) | | | (_| | |_| | | |",
                "|___/  \\__,_|_| |_|\\__, |\\___|\\___/|_| |_|___/  \\___/|_|   |___/ \\__,_|\\__, |\\__, |\\___/|_|  \\__,_|\\__|_| |_|",
                "                    __/ |                                               __/ | __/ |",
                "                   |___/                                               |___/ |___/\n"
            };

            foreach (var row in daggorath)
            {
                Console.WriteLine(row);
            }
        }//Welcome Screen

        static public void RdyP1()//Ready Player One
        {
            Console.Clear();

            string[] rdy = {
                "______               _        ______ _                         _____            ",
                "| ___ \\             | |       | ___ \\ |                       |  _  |",
                "| |_/ /___  __ _  __| |_   _  | |_/ / | __ _ _   _  ___ _ __  | | | |_ __   ___",
                "|    // _ \\/ _` |/ _` | | | | |  __/| |/ _` | | | |/ _ \\ '__| | | | | '_ \\ / _ \\",
                "| |\\ \\  __/ (_| | (_| | |_| | | |   | | (_| | |_| |  __/ |    \\ \\_/ / | | |  __/",
                "\\_| \\_\\___|\\__,_|\\__,_|\\__, | \\_|   |_|\\__,_|\\__, |\\___|_|     \\___/|_| |_|\\___|",
                "                        __/ |                 __/ |",
                "                       |___/                 |___/                              \n"
            };

            foreach (var row in rdy)
            {
                Console.WriteLine(row);
            }
        }

        static public void Shop()//The Iron Skillet
        {
            Console.Clear();

            string[] shop = {
                "                 _____ _            _____                  _____ _    _ _ _      _",
                "|_   _| |          |_   _|                /  ___| |  (_) | |    | |",
                "  | | | |__   ___    | | _ __ ___  _ __   \\ `--.| | ___| | | ___| |_",
                "  | | | '_ \\ / _ \\   | || '__/ _ \\| '_ \\   `--. \\ |/ / | | |/ _ \\ __|",
                "  | | | | | |  __/  _| || | | (_) | | | | /\\__/ /   <| | | |  __/ |_ ",
                "  \\_/ |_| |_|\\___|  \\___/_|  \\___/|_| |_| \\____/|_|\\_\\_|_|_|\\___|\\__|\n"
            };

            foreach (var row in shop)
            {
                Console.WriteLine(row);
            }
        }
    }
}
