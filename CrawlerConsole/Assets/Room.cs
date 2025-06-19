namespace ConsoleApp1.Assets;

public class Room
{
    private static int roomNumber;
    private static bool unlocked;
    private static bool vanquished;
    private static Monster monster;

    public Room(int roomNumber)
    {
        unlocked = false;
        vanquished = false;
        Room.roomNumber = roomNumber;
    }

    public void AddMonster(Monster monster)
    {
        Room.monster = monster;
    }
    
    
}