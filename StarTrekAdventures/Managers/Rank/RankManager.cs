using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class RankManager : IRankManager
{
    public List<string> GetAll()
    {
        return RankSelector.GetAllRanks();
    }
}
