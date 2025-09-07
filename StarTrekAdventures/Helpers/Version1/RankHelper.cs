using StarTrekAdventures.Constants;
using StarTrekAdventures.Models.Version1;

namespace StarTrekAdventures.Helpers.Version1
{
    public static class RankHelper
    {
        public static bool IsFlagOfficer(Character character)
        {
            return (character.Rank == Rank.RearAdmiral || character.Rank == Rank.ViceAdmiral || character.Rank == Rank.Admiral || character.Rank == Rank.FleetAdmiral);
        }
    }
}
