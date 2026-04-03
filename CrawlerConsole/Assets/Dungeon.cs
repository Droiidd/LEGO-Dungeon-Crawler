using ConsoleApp1.Entities;
using ConsoleApp1.Helpers;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp1.Assets;

public class Dungeon
{
    public static List<Room> rooms = new List<Room>();
    public int totalRooms;
    //These are the inner most rooms. We only want players to spawn on edge rooms 
    public static int[] spawnRoomWhitelist = new int[] { 6, 7 };

    public Dungeon(List<Player> players)
    {
        Console.WriteLine("Creating dungeon...");
        totalRooms = 12;
        
        InitDungeon(players);
    }

    public void InitDungeon(List<Player> players)
    {
        CreateRooms();
        SpawnPlayers(players);
        Console.WriteLine("Dungeon created! AHHH");
    }

    public int GetSpawnRoom()
    {
        int spawnRoom = Util.GetRandomNum(0, 12);
        while (!spawnRoomWhitelist.Contains(spawnRoom))
        {
            spawnRoom = Util.GetRandomNum(0, 12);
        }
        return spawnRoom;
    }

    public void CreateRooms()
    {
        //Creates a 4x3 matrix for 12 rooms
        for (int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                var room = new Room(i + 1, new Tuple<int, int>(i, j));
                rooms.Add(room);
            }
        }
    }

    public List<Room> GetNearestRooms(Tuple<int,int> currentPos)
    {
        List<Room> nearestRooms = new List<Room>();

        //Get positions
        if(currentPos.Item1 + 1 < 4)
        {
            Room aboveRoom = GetRoomFromPosition(new Tuple<int, int>(currentPos.Item1 + 1, currentPos.Item2));
            if(aboveRoom != null)
            {
                nearestRooms.Add(aboveRoom);
            }
        }
        if (currentPos.Item1 - 1 < 4 && currentPos.Item1 - 1 > 0)
        {
            Room belowRoom = GetRoomFromPosition(new Tuple<int, int>(currentPos.Item1 - 1, currentPos.Item2));
            if (belowRoom != null)
            {
                nearestRooms.Add(belowRoom);
            }
        }
        if (currentPos.Item2 + 1 < 3)
        {
            Room rightRoom = GetRoomFromPosition(new Tuple<int, int>(currentPos.Item1, currentPos.Item2 + 1));
            if (rightRoom != null)
            {
                nearestRooms.Add(rightRoom);
            }
        }
        if (currentPos.Item2 - 1 < 3 && currentPos.Item2 - 1 > 0)
        {
            Room leftRoom = GetRoomFromPosition(new Tuple<int, int>(currentPos.Item1, currentPos.Item2 - 1));
            if (leftRoom != null)
            {
                nearestRooms.Add(leftRoom);
            }
        }
        //Validate positions

        //Add to list

        return nearestRooms;
    }

    public Room GetRoomFromPosition(Tuple<int,int> pos)
    {
        foreach(Room room in rooms ){
            if(room.position == pos)
            {
                return room;
            }
        }
        return null;
    }

    public void SpawnPlayers(List<Player> players)
    {
        Console.WriteLine("Spawning players...");
        foreach (Player p in players)
        {
            int spawnRoom = GetSpawnRoom();
            p.UpdateRoom(rooms[spawnRoom]);
            Console.WriteLine(p.name+"...");
        }
    }
}