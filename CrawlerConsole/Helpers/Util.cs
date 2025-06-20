namespace ConsoleApp1.Helpers;

public class Util
{
    public static Random random;

    public Util()
    {
        random = new Random();
    }

    public static int GetRandomNum(int min, int max)
    {
        return random.Next(min, max);
    }
}