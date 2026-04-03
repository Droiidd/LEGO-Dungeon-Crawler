using ConsoleApp1.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers
{
    internal class RaceHelper
    {

        public static int GetHpBonusFromRace(Race race)
        {
            switch (race)
            {
                case Race.Dwarf:
                    return -5;
                case Race.Beastman:
                    return 10;
                case Race.Undead:
                    return -10;
                default:
                    return 0;
            }
        }
    }
}
