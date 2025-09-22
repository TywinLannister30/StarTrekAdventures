namespace StarTrekAdventures.Helpers;

public class MockRandomGenerator : IRandomGenerator
{
    private readonly Queue<int> _sequence;

    public MockRandomGenerator(IEnumerable<int> sequence)
    {
        _sequence = new Queue<int>(sequence);
    }

    public int GetRandom()
    {
        if (_sequence.Count == 0)
            throw new InvalidOperationException("No more values in sequence.");

        return _sequence.Dequeue();
    }

    public int GetRandom(int max)
    {
        if(_sequence.Count == 0)
            throw new InvalidOperationException("No more values in sequence.");

        return _sequence.Dequeue();
    }
}
