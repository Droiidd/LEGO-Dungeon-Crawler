// See https://aka.ms/new-console-template for more information

using ConsoleApp1.Assets;

Console.WriteLine("How many players are entering the dungeon?");
var playerCountStr = Console.ReadLine();

int playerCount = Globals.CheckPlayerCountNumber(playerCountStr);
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





Console.WriteLine("Press any key to exit");
var exit = Console.ReadLine();
