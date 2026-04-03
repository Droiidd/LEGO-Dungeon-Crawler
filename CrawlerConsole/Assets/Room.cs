using System.Runtime.InteropServices.Marshalling;

namespace ConsoleApp1.Assets;

public class Room
{
    public int roomNumber;
    public bool isUnlocked;
    public bool isVanquished;
    public Monster monster;
    private static List<Room> rooms = new List<Room>();
    public Tuple<int,int> position;

    public Room(int roomNumber, Tuple<int,int> position)
    {
        this.isUnlocked = false;
        this.isVanquished = false;
        this.roomNumber = roomNumber;
        this.position = position;
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