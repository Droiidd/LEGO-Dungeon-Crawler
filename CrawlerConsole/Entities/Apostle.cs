using ConsoleApp1.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities;

public class Apostle : Monster
{
    public MonsterType type { get; set; }
    public int level { get; set; }
    public int hp { get; set; }
    public int cp { get; set; }
    public bool isAlive { get; set; }
    public int lootRolls { get; set; }
    public Apostle(MonsterType type, int level)
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
            hp = 100;
        }
        if (level == 2)
        {
            hp = 170;
        }
        if (level == 3)
        {
            hp = 200;
        }
    }

    public void SetMaxCpFromLevel(int level)
    {
        if (level == 1)
        {
            cp = 60;
        }
        if (level == 2)
        {
            cp = 80;
        }
        if (level == 3)
        {
            cp = 100;
        }
    }

    public void SetLootRollsFromLevel(int level)
    {
        if (level == 1)
        {
            lootRolls = 4;
        }
        if (level == 2)
        {
            lootRolls = 5;
        }
        if (level == 3)
        {
            lootRolls = 6;
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