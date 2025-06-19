namespace ConsoleApp1.Assets;

public class Invader: Monster
{

    public Invader()
    {
        
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