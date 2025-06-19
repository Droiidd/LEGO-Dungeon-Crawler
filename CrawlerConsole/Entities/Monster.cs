using ConsoleApp1.Assets;

public class Monster
{
    public MonsterType type;
    public int level;
    public int hp;
    public int cp;
    public int statScalerRoll;
    public Room currentRoom;
    public bool isAlive;

    public Monster(MonsterType type, int statScalerRoll, Room currentRoom)
    {
        this.type = type;
        this.statScalerRoll = statScalerRoll;
        this.currentRoom = currentRoom;
        isAlive = true;
    }

    public void InitStats()
    {
        CalculateHpFromLevel();
        CalculateLevelFromStatScaler();
        CalculateCpFromLevel();
    }

    public void CalculateLevelFromStatScaler()
    {
        if (statScalerRoll >= 1 && statScalerRoll <= 10)
        {
            level = 1;
        }
        else if (statScalerRoll > 10 && statScalerRoll <= 17)
        {
            level = 2;
        }
        else
        {
            level = 3;
        }
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