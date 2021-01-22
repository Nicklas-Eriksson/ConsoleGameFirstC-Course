﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Labb3.UtilityTools;
using static System.Threading.Thread;

namespace Labb3.Menues
{
    static public class Logo
    {
        //Ascii Doom 
        static public void DoS()
        {
            Console.Clear();
            Tools.PurpleLine(@"
______                                      _____  __   _____       _ _ _             _      
|  _  \                                    |  _  |/ _| /  ___|     | (_) |           | |     
| | | |_   _ _ __   __ _  ___  ___  _ __   | | | | |_  \ `--.  ___ | |_| |_ _   _  __| | ___ 
| | | | | | | '_ \ / _` |/ _ \/ _ \| '_ \  | | | |  _|  `--. \/ _ \| | | __| | | |/ _` |/ _ \
| |/ /| |_| | | | | (_| |  __/ (_) | | | | \ \_/ / |   /\__/ / (_) | | | |_| |_| | (_| |  __/
|___/  \__,_|_| |_|\__, |\___|\___/|_| |_|  \___/|_|   \____/ \___/|_|_|\__|\__,_|\__,_|\___|
                    __/ |                                                                    
                   |___/                                                                     ");
        }//Welcome Screen

        static public void RdyP1()//Ready Player One
        {
            Console.Clear();
            Tools.PurpleLine(@"
______               _        ______ _                         _____            
| ___ \             | |       | ___ \ |                       |  _  |           
| |_/ /___  __ _  __| |_   _  | |_/ / | __ _ _   _  ___ _ __  | | | |_ __   ___ 
|    // _ \/ _` |/ _` | | | | |  __/| |/ _` | | | |/ _ \ '__| | | | | '_ \ / _ \
| |\ \  __/ (_| | (_| | |_| | | |   | | (_| | |_| |  __/ |    \ \_/ / | | |  __/
\_| \_\___|\__,_|\__,_|\__, | \_|   |_|\__,_|\__, |\___|_|     \___/|_| |_|\___|
                        __/ |                 __/ |                             
                       |___/                 |___/                             
                                                                     ");


        }

        static public void Shop()//The Iron Skillet
        {
            Console.Clear();
            Tools.PurpleLine(@"
 _____ _            _____                  _____ _    _ _ _      _   
|_   _| |          |_   _|                /  ___| |  (_) | |    | |  
  | | | |__   ___    | | _ __ ___  _ __   \ `--.| | ___| | | ___| |_ 
  | | | '_ \ / _ \   | || '__/ _ \| '_ \   `--. \ |/ / | | |/ _ \ __|
  | | | | | |  __/  _| || | | (_) | | | | /\__/ /   <| | | |  __/ |_ 
  \_/ |_| |_|\___|  \___/_|  \___/|_| |_| \____/|_|\_\_|_|_|\___|\__|
                                                                     ");

        }

        static public void Fight()
        {
            Console.Clear();
            Console.Clear();
            Tools.PurpleLine(@"
______ _       _     _   
|  ___(_)     | |   | |  
| |_   _  __ _| |__ | |_ 
|  _| | |/ _` | '_ \| __|
| |   | | (_| | | | | |_ 
\_|   |_|\__, |_| |_|\__|
          __/ |          
         |___/           ");

        }

        static public void Exit()
        {
            Console.Clear();
            Console.Clear();
            Tools.PurpleLine(@"
 _____     _ _     _____                      
|  ___|   (_) |   |  __ \                     
| |____  ___| |_  | |  \/ __ _ _ __ ___   ___ 
|  __\ \/ / | __| | | __ / _` | '_ ` _ \ / _ \
| |___>  <| | |_  | |_\ \ (_| | | | | | |  __/
\____/_/\_\_|\__|  \____/\__,_|_| |_| |_|\___|
                                              ");

        }

        static public void LoadGame()
        {
            Console.Clear();
            Tools.PurpleLine(@"
 _                     _   _____                      
| |                   | | |  __ \                     
| |     ___   __ _  __| | | |  \/ __ _ _ __ ___   ___ 
| |    / _ \ / _` |/ _` | | | __ / _` | '_ ` _ \ / _ \
| |___| (_) | (_| | (_| | | |_\ \ (_| | | | | | |  __/
\_____/\___/ \__,_|\__,_|  \____/\__,_|_| |_| |_|\___|
                                                      ");

        }

        static public void SaveGame()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            string sg = @"
 _____             _               _____                            
/  ___|           (_)             |  __ \                           
\ `--.  __ ___   ___ _ __   __ _  | |  \/ __ _ _ __ ___   ___       
 `--. \/ _` \ \ / / | '_ \ / _` | | | __ / _` | '_ ` _ \ / _ \      
/\__/ / (_| |\ V /| | | | | (_| | | |_\ \ (_| | | | | | |  __/
\____/ \__,_| \_/ |_|_| |_|\__, |  \____/\__,_|_| |_| |_|\___/
                            __/ |                                   
                           |___/                                    ";

            sg.ToCharArray();

            //So it looks cool when you are saving.. Even tho the saving process does not take this long...
            for (int i = 0; i < 3; i++)
            {
                foreach (var item in sg)
                {
                    Console.Write(item);
                    Sleep(3);
                }
                Console.Clear();
            }

            Console.ResetColor();
        }
        static public void GameSaved()
        {
            Console.Clear();
            Tools.PurpleLine(@"
 _____                        _____                     _ 
|  __ \                      /  ___|                   | |
| |  \/ __ _ _ __ ___   ___  \ `--.  __ ___   _____  __| |
| | __ / _` | '_ ` _ \ / _ \  `--. \/ _` \ \ / / _ \/ _` |
| |_\ \ (_| | | | | | |  __/ /\__/ / (_| |\ V /  __/ (_| |
 \____/\__,_|_| |_| |_|\___| \____/ \__,_| \_/ \___|\__,_|
                                                          
                                                          ");

        }
    }
}
