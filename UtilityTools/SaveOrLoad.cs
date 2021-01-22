using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.Text;
using Labb3.Character;
using Labb3.Menues;
using static System.Threading.Thread;

namespace Labb3.UtilityTools
{  

    public static class SaveOrLoad
    {
        public static int idCounter = 0;

        
        public static void Save()
        {
            Console.Clear();
            Logo.SaveGame();
            Logo.GameSaved();
            Sleep(1500);

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = "saves/" + Player.player.Id.ToString();
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            binaryFormatter.Serialize(file, Player.player);
            file.Close();
        }

        public static Player Load()
        {
            Console.Clear();
            Logo.LoadGame();

            Tools.YellowLine("-Load a saved game-\n");

            string[] arrayOfSavedGames = Directory.GetFiles("saves");
            List<Player> savedPlayers = new List<Player>();
            

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            foreach (var save in arrayOfSavedGames)
            {
                FileStream file = File.Open(save, FileMode.Open);
                Player _player = (Player)binaryFormatter.Deserialize(file); // castin it to a player
                file.Close();
                savedPlayers.Add(_player);
            }
            idCounter = savedPlayers.Count;

            int saveIndex = 1;
            foreach (Player player in savedPlayers)
            {
                Tools.Yellow($"Save {saveIndex}: ");
                Console.WriteLine($"Player ID = #{player.Id}. Player name = {player.Name}. Player Level = {player.Lvl}");
                saveIndex++;
            }

            Tools.YellowLine("\n Enter the number of the save you want to load.\n");
            
            int nr = Tools.ConvToInt32(savedPlayers.Count);
                       
            
            return savedPlayers[nr-1];
        }
    }
}
