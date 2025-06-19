namespace ConsoleApp1.Assets;

public class Dungeon
{
    public static List<Room> rooms = new List<Room>();
    public int totalRooms;

    public Dungeon(int rooms)
    {
        this.totalRooms = rooms;
        InitDungeon();
    }

    public void InitDungeon()
    {
        for (int i = 0; i < totalRooms; i++)
        {
            rooms.Add(new Room(i+1));
            rooms[i].AddMonster(new Invader());
        }
    }

}