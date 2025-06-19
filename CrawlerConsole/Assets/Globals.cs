using System.ComponentModel;

namespace ConsoleApp1.Assets;

public class Globals
{
    public static int ParseStrToInt(string str)
    {
        try{
            int result = Int32.Parse(str);
            return result;
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{str}'");
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

    public static ClassType GetAndCheckPlayerClass()
    {
        ClassType baseClassType = ClassType.Warrior;
        var invalidClass = true;

        while (invalidClass)
        {
            Console.Write("Enter your class\n");
            var inputClass = Console.ReadLine();
            var playerClass = CheckPlayerStrAgainstClassStr(inputClass);
            if(playerClass.Length > 0)
            {
                baseClassType = GetClassFromStr(playerClass);
                invalidClass = false;
            }
        }
        return baseClassType;
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

    private static ClassType GetClassFromStr(string playerClass)
    {
        switch (playerClass.ToLower())
        {
            case "monk":
                return ClassType.Monk;
            case "priest":
                return ClassType.Priest;
            case "wizard":
                return ClassType.Wizard;
            case "hunter":
                return ClassType.Hunter;
            case "rogue":
                return ClassType.Rogue;
            case "berserker":
                return ClassType.Berserker;
            default: case "warrior":
                return ClassType.Warrior;
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
        foreach (var pClass in Enum.GetNames(typeof(ClassType)))
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

    public static int CalculateLuckStat(Race race, ClassType classType, int baseLuck)
    {
        return baseLuck + GetRaceLuckBuff(race) + GetClassLuckBuff(classType);
    }

    public static int CalculateCharismaStat(Race race, ClassType classType, int baseCharisma)
    {
        return baseCharisma + GetClassCharismaBuff(classType);
    }

    public static int CalculateStealthStat(Race race, ClassType classType, int baseStealth)
    {
        return baseStealth + GetClassStealthBuff(classType);
    }

    public static int CalculateHp(Race race, ClassType classType, int baseHp)
    {
        return baseHp + GetRaceHpBuff(race);
    }

    public static int CalculateCp(Race race, ClassType classType, int baseCp)
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
    private static int GetClassLuckBuff(ClassType pClassType)
    {
        return (pClassType == ClassType.Wizard || pClassType == ClassType.Hunter) ? 3 : 0;
    }
    
    private static int GetClassStealthBuff(ClassType pClassType)
    {
        return (pClassType == ClassType.Rogue || pClassType == ClassType.Hunter) ? 3 : 0;
    }
    
    private static int GetClassCharismaBuff(ClassType pClassType)
    {
        return (pClassType == ClassType.Wizard || pClassType == ClassType.Warrior || pClassType == ClassType.Priest) ? 3 : 0;
    }
    
    #endregion
}