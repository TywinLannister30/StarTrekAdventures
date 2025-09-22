namespace StarTrekAdventures.Helpers;

public class RandomGenerator : IRandomGenerator
{
    private readonly Random _rnd = new();

    public int GetRandom()
    {
        return _rnd.Next();
    }

    public int GetRandom(int max)
    {
        return _rnd.Next(0, max);
    }
}
