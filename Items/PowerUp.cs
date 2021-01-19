﻿using System;
using System.Collections.Generic;
using System.Text;
using Labb3.Character;
using Labb3.UtilityTools;
using static System.Threading.Thread;

namespace Labb3.Items
{
    public class PowerUp : IPowerUp
    {
        public static PowerUp powerUp = new PowerUp();

        public string name { get => name; set => name = value; }
        public int goldCost { get => goldCost; set => Player.player.Gold -= 50 * Player.player.Lvl; }

        public void Bonus(string type)
        {
            if(type == "hp")
            {
                Tools.YellowLine("How many do you want to buy?");
                Tools.YellowLine("");
                Player.player.MaxHp += 20 * Player.player.Lvl;
                Player.player.Hp += 20 * Player.player.Lvl;
                Tools.GreenLine($"Max health is not {Player.player.MaxHp}");
            }
            else if (type == "dmg")
            {
                Player.player.Dmg += 20 * Player.player.Lvl;
                Tools.GreenLine($"The power flows through you! is now {Player.player.MaxHp}");
                Tools.GreenLine($"{Player.player.Name} power: {Player.player.Dmg}");
            }
            Sleep(1300);
        }
    }
}