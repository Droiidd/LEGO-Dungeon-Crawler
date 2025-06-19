using ConsoleApp1.Assets;

namespace ConsoleApp1;

public class Game
{
    private static int playerCount;
    private static Dungeon dungeon;

    public Game()
    {
        playerCount = 0;
    }
    public void Run()
    {
        Init();
        
        Console.WriteLine("\"Ahh... A new batch of rangers looking for their share of loot...");
        string dialogue = "\nWelcome";
        List<Player> players = Player.GetPlayers();
        for (int i = 0; i < players.Count; i++)
        {
                dialogue += ", "+players[i].name ;
        }
        Console.WriteLine(dialogue);
        for (int i = 0; i < players.Count; i++)
        {
            StartMainActionPhase(players[i]);
        }
    }

    private static void Init()
    {
        InitializeDungeon();
        InitializePlayers();
    }

    public static void InitializeDungeon()
    {
        
        var roomCount = 5;
        if (playerCount > 2 && playerCount < 5)
        {
            roomCount = 16;
        }else if (playerCount > 5 && playerCount < 10)
        {
            roomCount = 20;
        }
        dungeon = new Dungeon(roomCount);
    }

    private static void InitializePlayers()
    {
        while (playerCount <= 0)
        {
            Console.WriteLine("How many players are entering the dungeon?");
            var playerCountStr = Console.ReadLine();

            playerCount = Globals.ParseStrToInt(playerCountStr);
            if (playerCount > 0)
            {
                break;
            }
            
            Console.Clear();
            Console.WriteLine("Incorrect input, try again");
        }
        Console.Clear();
        for (int i = 0; i < playerCount; i++)
        {
            CreateNewPlayer(i);
            Console.WriteLine("\nCreating new player...");
        }
    }

    private static void CreateNewPlayer(int i)
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

    private Monster CreateNewMonster(MonsterType type, int statScaler, Room room)
    {
        switch (type)
        {
            default: case MonsterType.Invader:
                return new Invader(type,statScaler,room);
        }
    }

    public void StartMainActionPhase(Player player)
    {
        Console.Clear();
        Console.WriteLine(player.name+"'s turn!\n ------------ \n Actions:");
        
        string actionMenu = "1.) Move\n2.) Rest and heal\n\nPlease choose (1 or 2)";
        Console.WriteLine(actionMenu);
        var choice = Console.ReadLine();
        //if choice is good then
        if (choice == "1")
        {
            StartMovementAction(player);
        }

        if (choice == "2")
        {
            //RestAndHeal
        }
    }

    public void StartMovementAction(Player player)
    {
        Console.Clear();
        string movementMenu =
            "Movement Options:\n1.) Kick a new door down\n2.) Enter an unlocked room\n3.) Return to previous menu" +
            "\n\nPlease choose (1,2, or 3 to exit)";
        Console.WriteLine(movementMenu);
        var choice = Console.ReadLine();
        //if choice is good
        if (choice == "1")
        {
            MovePlayerToRoom(player);
        }

        if (choice == "2")
        {
            
        }
        if (choice == "3")
        {
            StartMainActionPhase(player);
        }

        if (choice != "1" && choice != "2" && choice != "3")
        {
            // you failed!
        }
        
    }

    public void MovePlayerToRoom(Player player)
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

    public void KickDownDoor(Player player, Room room)
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
        
        int roll = Globals.ParseStrToInt(rollStr);
        int statScaler = Globals.ParseStrToInt(statStr);
        
        MonsterType type = Globals.GetMonsterTypeFromRoll(roll);
        Monster summonedMonster = CreateNewMonster(type, statScaler, room);
        
        room.monster = summonedMonster;
        Monster monster = room.monster;
            
        string monsterIntro = $"\nFrom the darkness...\nA level {monster.level} "+monster.type.ToString()+" emerges!\n\n\n";
        Console.WriteLine(dialogue+monsterIntro);
        Console.WriteLine(CombatPhaseUi(player,monster));
    }

    public string CombatPhaseUi(Player player, Monster monster)
    {
        string d = "-----------------------------------------" +
                   $"\n{player.name}: \t\t\t\t\t{monster.type}:" +
                   $"\nLvl: {player.level} \t\t\t\t\tLvl: {monster.level}" +
                   $"\n| HP: {player.hp} | CP: {player.cp} |\t\t\t| HP: {monster.hp} | CP: {monster.cp} |";
        return d;
    }
}