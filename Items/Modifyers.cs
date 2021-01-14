using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3.Items
{
    class Modifyers //för lvl up
    {
        Random rnd = new Random();

        static int HPModifyer(double HP)
        {            
            double hp = HP * 1.7;           
            return Convert.ToInt32(hp);
        }
        static int ADModifyer(double AD)
        {
            double ad = AD * 1.5;
            return Convert.ToInt32(ad);
        }
        public int CritModifyer(int DMG)
        {
            double crit = rnd.Next(DMG/2, DMG);
            return Convert.ToInt32(crit);
        }
    }
}
