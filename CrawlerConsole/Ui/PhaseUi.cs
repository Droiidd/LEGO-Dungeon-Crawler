using ConsoleApp1.Assets;

namespace ConsoleApp1.Ui;

public class PhaseUi
{
    public static string GetCombatPhaseUi(Player player, Monster monster)
    {
        string d = "-----------------------------------------" +
                   $"\n{player.name}: \t\t\t\t\t{monster.type}:" +
                   $"\nLvl: {player.level} \t\t\t\t\tLvl: {monster.level}" +
                   $"\n| HP: {player.hp} | CP: {player.cp} |\t\t\t| HP: {monster.hp} | CP: {monster.cp} |";
        return d;
    }
}