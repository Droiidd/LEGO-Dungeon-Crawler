using ConsoleApp1.Assets;
using ConsoleApp1.Ui;

namespace ConsoleApp1.Helpers;

public class Actions
{
    public static void MovePlayerToRoom(Player player, Dungeon dungeon)
    {
        Console.WriteLine("Please enter the number of the door you wish to knock down: ");
        var roomNumStr = Console.ReadLine();
        //verify roomNumber is an int
        int roomNum = Globals.ParseStrToInt(roomNumStr);
        //Verify roomNumber is an existing room and is locked
        if (!(roomNum <= dungeon.totalRooms))
        {
            //try again!
        }

        Room room = Room.GetRoom(roomNum);
        if (room == null)
        {
            // try again!
        }
            
        if (room.isUnlocked)
        {
            //This door is unlocked, proceed anyway?
        }
        else
        {
            KickDownDoor(player,room);
        }
    }

    public static void KickDownDoor(Player player, Room room)
    {
        player.UpdateRoom(room);
        Console.Clear();
        
        string dialogue = $"-------------\nYou have kicked down the door to room {room.roomNumber}!\nRoll a d20 for your mob type";
        Console.WriteLine(dialogue);
        
        //check bad rolls: \/\/\/\/
        Console.WriteLine("\nRolled number:");
        var rollStr = Console.ReadLine();
        Console.WriteLine("\n\nRoll a second d20 for your stat scaler roll\nRolled number: ");
        var statStr = Console.ReadLine();
        Console.Clear();
        
        int roll = Globals.ParseStrToInt(rollStr);
        int statScaler = Globals.ParseStrToInt(statStr);
        
        MonsterType type = Globals.GetMonsterTypeFromRoll(roll);
        Monster summonedMonster = AssetLoader.CreateNewMonster(type, statScaler, room);
        
        room.monster = summonedMonster;
        Monster monster = room.monster;
            
        string monsterIntro = $"\nFrom the darkness...\nA level {monster.level} "+monster.type.ToString()+" emerges!\n\n\n";
        Console.WriteLine(dialogue+monsterIntro);
        Console.WriteLine(PhaseUi.GetCombatPhaseUi(player,monster));
    }
}