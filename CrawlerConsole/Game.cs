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
        Util util = new Util();
        Init();


        Menus.DisplayIntro(players);
        //Player creation done
        StartPlayersTurnPhase();
    }

    private void Init()
    {
        //TEMPORRARY!!@!
        //InitializePlayers();
        new Player("Jon",20,50,10,10,10,Race.Sinnick,ClassType.Monk);
        playerCount = 1;



        players = Player.GetPlayers();
        InitializeDungeon();
    }

    public void InitializeDungeon()
    {
        dungeon = new Dungeon(players);
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
            Menus.DisplayMainActionsMenu(players[i], dungeon);
        }
    }

    
    
}