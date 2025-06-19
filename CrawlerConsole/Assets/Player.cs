namespace ConsoleApp1.Assets;

public class Player
{
    private int cp;
    private int hp;
    private int stealth;
    private int luck;
    private int charisma;
    private Race race;
    private PlayerClass playerClass;
    private string name;

    public Player(string name, int cp, int hp, int stealth, int luck, int charisma, Race race, PlayerClass playerClass)
    {
        this.cp = cp;
        this.hp = hp;
        this.stealth = stealth;
        this.luck = luck;
        this.charisma = charisma;
        this.race = race;
        this.playerClass = playerClass;
        this.name = name;
    }
    
}