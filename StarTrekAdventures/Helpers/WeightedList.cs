namespace StarTrekAdventures.Helpers;

public class WeightedList<T>
{
    private struct Entry
    {
        public double accumulatedWeight;
        public T item;
    }

    private readonly List<Entry> entries = new();
    private double accumulatedWeight;
    private readonly Random rand = new();

    public void AddEntry(T item, double weight)
    {
        accumulatedWeight += weight;
        entries.Add(new Entry { item = item, accumulatedWeight = accumulatedWeight });
    }

    public T GetRandom()
    {
        double r = rand.NextDouble() * accumulatedWeight;

        foreach (Entry entry in entries)
        {
            if (entry.accumulatedWeight >= r)
            {
                return entry.item;
            }
        }
        return default;
    }

    public void RemoveAll(T value)
    {
        var filtered = new List<Entry>();
        double newAccumulatedWeight = 0;

        foreach (var entry in entries)
        {
            if (!EqualityComparer<T>.Default.Equals(entry.item, value))
            {
                // Get the weight of this entry relative to the previous entry
                double previousAccumulated = filtered.Count > 0 ? filtered[^1].accumulatedWeight : 0;
                double weight = entry.accumulatedWeight - previousAccumulated;

                newAccumulatedWeight += weight;
                filtered.Add(new Entry { item = entry.item, accumulatedWeight = newAccumulatedWeight });
            }
        }

        entries.Clear();
        entries.AddRange(filtered);
        accumulatedWeight = newAccumulatedWeight;
    }

    public void RemoveWhere(Func<T, bool> predicate)
    {
        var filtered = new List<Entry>();
        double newAccumulatedWeight = 0;

        foreach (var entry in entries)
        {
            if (!predicate(entry.item))
            {
                double previousAccumulated = filtered.Count > 0 ? filtered[^1].accumulatedWeight : 0;
                double weight = entry.accumulatedWeight - previousAccumulated;

                newAccumulatedWeight += weight;
                filtered.Add(new Entry { item = entry.item, accumulatedWeight = newAccumulatedWeight });
            }
        }

        entries.Clear();
        entries.AddRange(filtered);
        accumulatedWeight = newAccumulatedWeight;
    }

    public void RemoveWhereNotIn<TValue>(Func<T, TValue> selector, params TValue[] allowedValues)
    {
        var allowed = new HashSet<TValue>(allowedValues);
        RemoveWhere(x => !allowed.Contains(selector(x)));
    }
}
