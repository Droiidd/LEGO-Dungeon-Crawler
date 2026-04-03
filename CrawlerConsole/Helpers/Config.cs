using ConsoleApp1.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Helpers;

public class Config
{
    // === HP ===

    static int apostleLvl1Hp = 100;
    static int apostleLvl2Hp = 170;
    static int apostleLvl3Hp = 200;

    static int invaderLvl1Hp = 45;
    static int invaderLvl2Hp = 90;
    static int invaderLvl3Hp = 140;

    static int beastLvl1Hp = 60;
    static int beastLvl2Hp = 105;
    static int beastLvl3Hp = 155;

    static int hordeLvl1Hp = 20;

    static int mountLvl1Hp = 50;
    static int mountLvl2Hp = 55;
    static int mountLvl3Hp = 60;

    // === CP ===

    static int apostleLvl1Cp = 150;
    static int apostleLvl2Cp = 200;
    static int apostleLvl3Cp = 100;

    static int invaderLvl1Cp = 150;
    static int invaderLvl2Cp = 200;
    static int invaderLvl3Cp = 100;

    static int beastLvl1Cp = 150;
    static int beastLvl2Cp = 200;
    static int beastLvl3Cp = 100;

    static int mountLvl1Cp = 150;
    static int mountLvl2Cp = 200;
    static int mountLvl3Cp = 100;
    public static Dictionary<string, int> levelSpecificMonsterHPs = new Dictionary<string, int>()
    {
        { "invaderLvl1", invaderLvl1Hp },
        { "beastLvl1", beastLvl1Hp },
        { "hordeLvl1", hordeLvl1Hp },
        { "apostleLvl1", apostleLvl1Hp },
        {  "mountLvl1", mountLvl1Hp + invaderLvl1Hp },
        { "invaderLvl2", invaderLvl2Hp },
        { "beastLvl2", beastLvl2Hp },
        { "apostleLvl2", apostleLvl2Hp },
        { "mountLvl2", mountLvl2Hp + invaderLvl2Hp },
        { "invaderLvl3", invaderLvl3Hp },
        { "beastLvl3", beastLvl3Hp },
        { "apostleLvl3", apostleLvl3Hp },
        { "mountLvl3", mountLvl3Hp + invaderLvl3Hp }
    };

    public static int SetHpFromLevelAndType(int level, MonsterType type) {

        return levelSpecificMonsterHPs.ElementAt(levelSpecificMonsterHPs.Keys.ToList().FindIndex(x => x.Equals($"{type.ToString().ToLower()}Lvl{level}"))).Value == 1 ? 1 : -1;
    }
    public static int SetCpFromLevelAndType(){
        return -1;
    }



}

