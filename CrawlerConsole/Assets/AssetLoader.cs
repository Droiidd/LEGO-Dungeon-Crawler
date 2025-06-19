namespace ConsoleApp1.Assets;

public class AssetLoader
{
    public static void CreateNewPlayer(int i)
    {
        Console.WriteLine($"Welcome player {(i+1)}, please enter your name");
        var name =  Console.ReadLine();
        var race = Globals.GetAndCheckPlayerRace();
        var playerClass =  Globals.GetAndCheckPlayerClass();
        //All input done
        Console.Clear();
    
        var luck = Globals.CalculateLuckStat(race, playerClass,7);
        var charisma = Globals.CalculateCharismaStat(race, playerClass,10);
        var stealth = Globals.CalculateStealthStat(race, playerClass,10);
        var hp = Globals.CalculateHp(race, playerClass, 50);
        var cp = Globals.CalculateCp(race, playerClass, 10);

        new Player(name,cp,hp,stealth,luck,charisma,race,playerClass);
    }

    public static Monster CreateNewMonster(MonsterType type, int statScaler, Room room)
    {
        switch (type)
        {
            default: case MonsterType.Invader:
                return new Invader(type,statScaler,room);
        }
    }
}