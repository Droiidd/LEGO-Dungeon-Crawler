using ConsoleApp1.Assets;
using ConsoleApp1.Helpers;
using ConsoleApp1.Ui;

namespace ConsoleApp1;

public class Game
{
    private static int playerCount;
    private static Dungeon dungeon;
    private List<Player> players  = new List<Player>();

    public Game()
    {
        playerCount = 0;
    }
    public void Run()
    {
        Init();
        Util util = new Util();
        
        StartPlayerIntroPhase();
        //Player creation done
        StartPlayersTurnPhase();
    }

    private void Init()
    {
        //InitializePlayers();
        new Player("Jon",20,50,10,10,10,Race.Sinnick,ClassType.Monk);
        playerCount = 1;
        players = Player.GetPlayers();
        InitializeDungeon();
    }

    public void InitializeDungeon()
    {
        dungeon = new Dungeon(playerCount);
    }

    private void InitializePlayers()
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
            AssetLoader.CreateNewPlayer(i);
            Console.WriteLine("\nCreating new player...");
        }
        players = Player.GetPlayers();
    }
    
    private void StartPlayersTurnPhase()
    {
        for(int i = 0; i < players.Count; i++)
        {
            StartMainActionPhase(players[i]);
        }
    }

    private void StartPlayerIntroPhase()
    {
        string dialogue = "\"Ahh... A new batch of rangers looking for their share of loot...\nWelcome";
        for (int i = 0; i < players.Count; i++)
        {
            string tmp = ", "+players[i].name ;
            dialogue += tmp;

        }
        dialogue += "\"\n\nPress any key to continue";
        Console.WriteLine(dialogue);
        Console.ReadKey();
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
            MovementMenuHandler(player);
        }

        if (choice == "2")
        {
            //RestAndHeal
        }
    }

    public void MovementMenuHandler(Player player)
    {
        var invalidChoice = true;

        Console.Clear();
        while(invalidChoice)
        {
            // you failed!
            
            string movementMenu =
                "Movement Options:\n1.) Kick a new door down\n2.) Enter an unlocked room\n3.) Back" +
                "\n\nPlease choose (1,2, or 3 to exit)";
            Console.WriteLine(movementMenu);
            var choice = Console.ReadLine();
            //if choice is good
            if (choice == "1" || choice == "2")
            {
                Actions.MovePlayerToRoom(player,dungeon);
            }
            if (choice == "3")
            {
                StartMainActionPhase(player);
            }

            if (choice == "1" && choice == "2" && choice == "3")
            {
                invalidChoice = false;
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid choice. Please try again");
            }
        }
        
    }
}