namespace StarTrekAdventures.Helpers;

// Phase this out
public static class Util
{
    private static readonly Random rnd = new();

    public static int GetRandom()
    {
        return rnd.Next();
    }

    public static int GetRandom(int max)
    {
        return rnd.Next(0, max);
    }
}
