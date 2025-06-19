namespace ConsoleApp1.Assets;

public class Player
{
    public int cp;
    public int hp;
    public int stealth;
    public int luck;
    public int charisma;
    public int level;
    public Race race;
    public ClassType _classType;
    public string name;
    private Room currentRoom;
    private static List<Player> players = new List<Player>();

    public Player(string name, int cp, int hp, int stealth, int luck, int charisma, Race race, ClassType classType)
    {
        this.cp = cp;
        this.hp = hp;
        this.stealth = stealth;
        this.luck = luck;
        this.charisma = charisma;
        this.race = race;
        this._classType = classType;
        this.name = name;
        this.currentRoom = null;
        this.level = 1;
        players.Add(this);
    }

    public static List<Player> GetPlayers()
    {
        return players;
    }
    public static Player GetPlayer(string name)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].name.Equals(name))
            {
                return players[i];
            }
        }

        return null;
    }

    public void UpdateRoom(Room room)
    {
        this.currentRoom = room;
    }
}