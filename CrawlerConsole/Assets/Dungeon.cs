namespace ConsoleApp1.Assets;

public class Dungeon
{
    public static List<Room> rooms = new List<Room>();
    public int totalRooms;

    public Dungeon(int rooms)
    {
        Console.WriteLine("Creating dungeon...");
        this.totalRooms = rooms;
        InitDungeon();
    }

    public void InitDungeon()
    {
        for (int i = 0; i < totalRooms; i++)
        {
            var room = new Room(i + 1);
            rooms.Add(room);
            Invader mon = new Invader(MonsterType.Invader, 11, room);
            Console.WriteLine($"Monster stats: HP {mon.hp} | CP {mon.cp} ");
            rooms[i].AddMonster(mon);
        }
    }

}