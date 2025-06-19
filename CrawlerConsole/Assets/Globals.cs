using System.ComponentModel;

namespace ConsoleApp1.Assets;

public class Globals
{
    public static int CheckPlayerCountNumber(string playerNumber)
    {
        try{
            int result = Int32.Parse(playerNumber);
            return result;
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{playerNumber}'");
        }

        return -1;
    }

    public static Race GetAndCheckPlayerRace()
    {
        Race baseRace = new Race();
        var invalidRace = true;

        while (invalidRace)
        {
            Console.Write("Enter your race\n");
            var inputRace = Console.ReadLine();
            var playerRace = CheckPlayerStrAgainstRaceStr(inputRace);
            if(playerRace.Length > 0)
            {
                baseRace = Globals.GetRaceFromStr(playerRace);
                invalidRace = false;
            }
        }
        return baseRace;
    }

    public static PlayerClass GetAndCheckPlayerClass()
    {
        PlayerClass baseClass = PlayerClass.Warrior;
        var invalidClass = true;

        while (invalidClass)
        {
            Console.Write("Enter your class\n");
            var inputClass = Console.ReadLine();
            var playerClass = CheckPlayerStrAgainstClassStr(inputClass);
            if(playerClass.Length > 0)
            {
                baseClass = GetClassFromStr(playerClass);
                invalidClass = false;
            }
        }
        return baseClass;
    }

    private static string CheckPlayerStrAgainstRaceStr(string playerRace)
    {
        string baseRace = "";
        foreach (var race in Enum.GetNames(typeof(Race)))
        {
            if (EqualsIgnoreCase(race, playerRace))
            {
                baseRace = race;
            }
        }
        return baseRace;
    }

    private static PlayerClass GetClassFromStr(string playerClass)
    {
        switch (playerClass.ToLower())
        {
            case "monk":
                return PlayerClass.Monk;
            case "priest":
                return PlayerClass.Priest;
            case "wizard":
                return PlayerClass.Wizard;
            case "hunter":
                return PlayerClass.Hunter;
            case "rogue":
                return PlayerClass.Rogue;
            case "berserker":
                return PlayerClass.Berserker;
            default: case "warrior":
                return PlayerClass.Warrior;
        }
    }

    private static Race GetRaceFromStr(string race)
    {
        switch (race.ToLower())
        {
            case "beastman": case "beast man":
                return Race.Beastman;
            case "sinnick":
                return Race.Sinnick;
            case "dwarf":
                return Race.Dwarf;
            case "undead":
                return Race.Undead;
            case "afflicted":
                return Race.Afflicted;
            default: case "human":
                return Race.Human;
        }
    }
    
    private static string CheckPlayerStrAgainstClassStr(string playerClass)
    {
        string baseStr = "";
        foreach (var pClass in Enum.GetNames(typeof(PlayerClass)))
        {
            if (EqualsIgnoreCase(pClass, playerClass))
            {
                baseStr = pClass;
            }
        }
        return baseStr;
    }

    private static bool EqualsIgnoreCase(string str1, string str2)
    {
        return (str1.ToLower().Equals(str2.ToLower())) ? true :false;
    }

    public static int CalculateLuckStat(Race race, PlayerClass playerClass, int baseLuck)
    {
        return baseLuck + GetRaceLuckBuff(race) + GetClassLuckBuff(playerClass);
    }

    public static int CalculateCharismaStat(Race race, PlayerClass playerClass, int baseCharisma)
    {
        return baseCharisma + GetClassCharismaBuff(playerClass);
    }

    public static int CalculateStealthStat(Race race, PlayerClass playerClass, int baseStealth)
    {
        return baseStealth + GetClassStealthBuff(playerClass);
    }

    public static int CalculateHp(Race race, PlayerClass playerClass, int baseHp)
    {
        return baseHp + GetRaceHpBuff(race);
    }

    public static int CalculateCp(Race race, PlayerClass playerClass, int baseCp)
    {
        return baseCp + GetRaceCpBuff(race);
    }
    #region Race Buff Calculators
    private static int GetRaceLuckBuff(Race race)
    {
        //default is 7
        return race == Race.Dwarf ? 3 : 0;
    }

    public static int GetRaceHpBuff(Race race)
    {
        if (race == Race.Dwarf)
        {
            return -15;
        }
        else if (race == Race.Beastman)
        {
            return 20;
        }

        return 0;
    }

    public static int GetRaceCpBuff(Race race)
    {
        return race == Race.Afflicted ? 6 : 0;
    }

    #endregion
    #region Class Buff Calculators
    private static int GetClassLuckBuff(PlayerClass pClass)
    {
        return (pClass == PlayerClass.Wizard || pClass == PlayerClass.Hunter) ? 3 : 0;
    }
    
    private static int GetClassStealthBuff(PlayerClass pClass)
    {
        return (pClass == PlayerClass.Rogue || pClass == PlayerClass.Hunter) ? 3 : 0;
    }
    
    private static int GetClassCharismaBuff(PlayerClass pClass)
    {
        return (pClass == PlayerClass.Wizard || pClass == PlayerClass.Warrior || pClass == PlayerClass.Priest) ? 3 : 0;
    }
    
    #endregion
}