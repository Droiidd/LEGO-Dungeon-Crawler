namespace ConsoleApp1.Assets;

public class Room
{
    public int roomNumber;
    public bool isUnlocked;
    public bool isVanquished;
    public Monster monster;
    private static List<Room> rooms = new List<Room>();

    public Room(int roomNumber)
    {
        this.isUnlocked = false;
        this.isVanquished = false;
        this.roomNumber = roomNumber;
        rooms.Add(this);
    }

    public void AddMonster(Monster monster)
    {
        this.monster = monster;
    }

    public static Room GetRoom(int roomNumber)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].roomNumber == roomNumber)
            {
                return rooms[i];
            }
        }

        return null;
    }
}