namespace ConsoleApp1.Assets;

public class Dungeon
{
    public static List<Room> rooms = new List<Room>();
    public int totalRooms;

    public Dungeon(int playerCount)
    {
        Console.WriteLine("Creating dungeon...");
        SetRoomCount(playerCount);
        InitDungeon();
    }

    public void InitDungeon()
    {
        for (int i = 0; i < totalRooms; i++)
        {
            var room = new Room(i + 1);
            rooms.Add(room);
            rooms[i].AddMonster(new Invader(MonsterType.Invader, 11, room));
        }
    }

    private void SetRoomCount(int playerCount)
    {
        totalRooms = 5;
        if (playerCount > 2 && playerCount < 5)
        {
            totalRooms = 16;
        }else if (playerCount > 5 && playerCount < 10)
        {
            totalRooms = 20;
        }
    }

}