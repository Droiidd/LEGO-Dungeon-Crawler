using ConsoleApp1.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities;

public class Beast : Monster
{
    public MonsterType type { get; set; }
    public int level { get; set; }
    public int hp { get; set; }
    public int cp { get; set; }
    public bool isAlive { get; set; }
    public int lootRolls { get; set; }
    public Beast(MonsterType type, int level)
    {
        this.type = type;
        this.level = level;
        this.isAlive = true;
        SetLootRollsFromLevel(level);
        SetMaxCpFromLevel(level);
        SetMaxHpFromLevel(level);
    }

    public void SetMaxHpFromLevel(int level)
    {
        if (level == 1)
        {
            hp = 50;
        }
        if (level == 2)
        {
            hp = 105;
        }
        if (level == 3)
        {
            hp = 155;
        }
    }

    public void SetMaxCpFromLevel(int level)
    {
        if (level == 1)
        {
            cp = 32;
        }
        if (level == 2)
        {
            cp = 40;
        }
        if (level == 3)
        {
            cp = 60;
        }
    }

    public void SetLootRollsFromLevel(int level)
    {
        if (level == 1)
        {
            lootRolls = 2;
        }
        if (level == 2)
        {
            lootRolls = 3;
        }
        if (level == 3)
        {
            lootRolls = 4;
        }
    }

    public int GetCurrentHp()
    {
        return hp;
    }
    public void UpdateLiving(bool isAlive)
    {
        this.isAlive = isAlive;
    }
    public bool IsAlive()
    {
        return isAlive;
    }
}