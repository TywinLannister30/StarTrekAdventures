using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public static class RankSelector
{
    public static string ChooseRank(Character character)
    {
        var weightedRankList = new WeightedList<string>();

        if (character.IsEnlisted())
        {
            if (character.Experience == ExperienceName.Novice || character.Experience == ExperienceName.Experienced)
            {
                weightedRankList.AddEntry(Rank.Crewman1stClass, 1);
                weightedRankList.AddEntry(Rank.Crewman2ndClass, 1);
                weightedRankList.AddEntry(Rank.Crewman3rdClass, 1);
                weightedRankList.AddEntry(Rank.PettyOfficer1stClass, 1);
                weightedRankList.AddEntry(Rank.PettyOfficer2ndClass, 1);
                weightedRankList.AddEntry(Rank.PettyOfficer3rdClass, 1);
            }

            if (character.Experience == ExperienceName.Experienced || character.Experience == ExperienceName.Veteran)
            {
                weightedRankList.AddEntry(Rank.ChiefPettyOfficer, 2);
                weightedRankList.AddEntry(Rank.SeniorChiefPettyOfficer, 2);
                weightedRankList.AddEntry(Rank.MasterChiefPettyOfficer, 2);
            }
        }
        else if (character.IsStarfleet())
        {
            if (character.Experience == ExperienceName.Novice)
            {
                weightedRankList.AddEntry(Rank.Cadet, 1);
                weightedRankList.AddEntry(Rank.Ensign, 1);
            }

            if (character.Experience == ExperienceName.Novice || character.Experience == ExperienceName.Experienced)
                weightedRankList.AddEntry(Rank.LieutenantJuniorGrade, 2);

            if (character.Experience == ExperienceName.Experienced)
                weightedRankList.AddEntry(Rank.Lieutenant, 3);

            if (character.Experience == ExperienceName.Experienced || character.Experience == ExperienceName.Veteran)
            {
                weightedRankList.AddEntry(Rank.LieutenantCommander, 3);
                weightedRankList.AddEntry(Rank.Commander, 2);
                weightedRankList.AddEntry(Rank.Captain, 1);
            }

            if (character.CareerPath == TrackName.StarfleetOfficerCommand && character.Experience == ExperienceName.Veteran)
            {
                weightedRankList.AddEntry(Rank.FleetCaptain, 1);
                weightedRankList.AddEntry(Rank.Commodore, 1);
                weightedRankList.AddEntry(Rank.RearAdmiral, 1);
                weightedRankList.AddEntry(Rank.ViceAdmiral, 1);
                weightedRankList.AddEntry(Rank.Admiral, 1);
                weightedRankList.AddEntry(Rank.FleetAdmiral, 1);
            }
        }
        else
        {
            weightedRankList.AddEntry("Civilian", 1);
        }

        return weightedRankList.GetRandom();
    }
}
