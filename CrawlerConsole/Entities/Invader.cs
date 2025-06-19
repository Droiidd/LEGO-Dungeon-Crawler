namespace ConsoleApp1.Assets;

public class Invader: Monster
{
    public Invader(MonsterType type,int statScalerRoll, Room currentRoom): base(type,statScalerRoll,currentRoom)
    {
        this.type = type;
        this.statScalerRoll = statScalerRoll;
        this.currentRoom = currentRoom;
        this.isAlive = true;

        InitStats();
    }
    
    public override void CalculateHpFromLevel()
    {
        //Invaders hp = 30 + 4 * stat scaler
        hp = 30 + (4 * statScalerRoll);
    }
    
    public override void CalculateCpFromLevel()
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