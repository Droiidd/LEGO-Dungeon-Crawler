using ConsoleApp1.Assets;

public class Monster
{
    public static MonsterType type;
    public static int level;
    public static int hp;
    public static int cp;
    public static int statScalerRoll;
    public static Room currentRoom;
    public static bool isAlive;

    public Monster(MonsterType type, int level, int hp, int cp, int statScalerRoll, Room currentRoom)
    {
        Monster.type = type;
        Monster.level = level;
        Monster.hp = hp;
        Monster.cp = cp;
        Monster.statScalerRoll = statScalerRoll;
        Monster.currentRoom = currentRoom;
        isAlive = true;
    }
    public virtual void CalculateCpFromLevel() { }

    public virtual void CalculateHpFromLevel() { }
    
    public virtual void CalculateCritHit() {}

    public int GetHp()
    {
        return hp;
    }

    public int GetCp()
    {
        return cp;
    }

    public Room GetRoom()
    {
        return currentRoom;
    }

    public void SetRoom(Room room)
    {
        currentRoom = room;
    }

    public void UpdateLiving(bool isAlive)
    {
        isAlive = isAlive;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void UpdateStatScalerRoll(int newRoll)
    {
        statScalerRoll = newRoll;
    }
}