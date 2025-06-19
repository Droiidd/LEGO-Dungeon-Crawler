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
        
    }

    private static void Init()
    {
        InitializePlayers();
        InitializeDungeon();

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
        Console.WriteLine("How many players are entering the dungeon?");
        var playerCountStr = Console.ReadLine();

        playerCount = Globals.ParseStrToInt(playerCountStr);
        if (playerCount == -1)
        {
            //crash out
        }
        Console.Clear();
        for (int i = 0; i < playerCount; i++)
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
    
    
            Player player = new Player(name,cp,hp,stealth,luck,charisma,race,playerClass);
            Console.WriteLine("\nPlayer created... Loading stats:");
            string breakStr = "\n-----------\n";
            string stats = breakStr+"Name: "+name+"\nRace: "+race+"\nClass: "+playerClass+breakStr+"HP: "+hp+"\nCP: "+cp+breakStr+"Luck: "+luck+"\nCharisma: "+charisma+"\nStealth: "+stealth+"\n";
            Console.WriteLine(stats);;
        }
    }

    public void StartMainActionPhase(Player player)
    {
        Console.Clear();
        Console.WriteLine(player.name+"'s turn!\n ------------ \n Actions:");
        
        string actionMenu = "1.) Move\n2.) Rest and heal\n\nPlease choose (1 or 2)";
        var choice = Console.ReadLine();
        //if choice is good then
    }

    public void StartMovementAction(Player player)
    {
        Console.Clear();
        Console.WriteLine("Movement Options:\n1.) Kick a new door down\n2.) Enter an unlocked room\n3.) Return to previous menu");
        Console.WriteLine("\n\nPlease choose (1,2, or 3 to exit)");
        var choice = Console.ReadLine();
        //if choice is good
        if (choice == "3")
        {
            StartMainActionPhase(player);
        }

        if (choice == "1")
        {
            Console.WriteLine("Please enter the number of the door you wish to knock down: ");
            var roomNum = Console.ReadLine();
            //verify roomNumber is an int
            //Verify roomNumber is an existing room and is locked
            
            
        }
        
    }

    public void KickDownDoor(Player player)
    {
        Console.Clear();
    }
}