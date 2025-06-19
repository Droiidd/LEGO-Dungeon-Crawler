namespace ConsoleApp1.Assets;

public class Invader: Monster
{
    public Invader(MonsterType type, int level, int hp, int cp, int statScalerRoll, Room currentRoom): base(type,level,hp,cp,statScalerRoll,currentRoom)
    {
        Invader.type = type;
        Invader.level = level;
        Invader.hp = hp;
        Invader.cp = cp;
        Invader.statScalerRoll = statScalerRoll;
        Invader.currentRoom = currentRoom;
        Invader.isAlive = true;
    }
    
    public virtual void CalculateHpFromLevel()
    {
        //Invaders hp = 30 + 4 * stat scaler
        hp = 30 + (4 * statScalerRoll);
    }
    
    public virtual void CalculateCpFromLevel()
    {
        switch (level)
        {
            default: case 1:
                cp = 25;
                break;
            case 2:
                cp = 35;
                break;
            case 3:
                cp = 60;
                break;
        }
    }
    
}