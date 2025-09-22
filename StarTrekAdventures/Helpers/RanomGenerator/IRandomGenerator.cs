namespace StarTrekAdventures.Helpers;

public interface IRandomGenerator
{
    public int GetRandom();

    public int GetRandom(int max);
}
