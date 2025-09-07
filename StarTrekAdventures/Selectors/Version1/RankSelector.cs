using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class RankSelector
    {
        public static string ChooseRank(Character character)
        {
            var weightedRankList = new WeightedList<string>();

            var isEnlisted = (Util.GetRandom(100) < 10) && character.Track != DisciplineName.Command;

            if (isEnlisted)
            {
                if (character.Career == CareerName.Young || character.Career == CareerName.Experienced)
                {
                    weightedRankList.AddEntry(Rank.Crewman1stClass, 1);
                    weightedRankList.AddEntry(Rank.Crewman2ndClass, 1);
                    weightedRankList.AddEntry(Rank.Crewman3rdClass, 1);
                    weightedRankList.AddEntry(Rank.PettyOfficer1stClass, 1);
                    weightedRankList.AddEntry(Rank.PettyOfficer2ndClass, 1);
                    weightedRankList.AddEntry(Rank.PettyOfficer3rdClass, 1);
                    weightedRankList.AddEntry(Rank.Specialist1stClass, 1);
                    weightedRankList.AddEntry(Rank.Specialist2ndClass, 1);
                    weightedRankList.AddEntry(Rank.Specialist3rdClass, 1);
                    weightedRankList.AddEntry(Rank.Yeoman1stClass, 1);
                    weightedRankList.AddEntry(Rank.Yeoman2ndClass, 1);
                    weightedRankList.AddEntry(Rank.Yeoman3rdClass, 1);
                }

                if (character.Career == CareerName.Experienced || character.Career == CareerName.Veteran)
                {
                    weightedRankList.AddEntry(Rank.ChiefPettyOfficer, 2);
                    weightedRankList.AddEntry(Rank.ChiefSpecialist, 2);
                    weightedRankList.AddEntry(Rank.SeniorChiefPettyOfficer, 2);
                    weightedRankList.AddEntry(Rank.SeniorChiefSpecialist, 2);
                    weightedRankList.AddEntry(Rank.MasterChiefPettyOfficer, 2);
                    weightedRankList.AddEntry(Rank.MasterChiefSpecialist, 2);
                }
            }
            else
            {
                if (character.Career == CareerName.Young)
                    weightedRankList.AddEntry(Rank.Ensign, 1);

                if (character.Career == CareerName.Young || character.Career == CareerName.Experienced)
                    weightedRankList.AddEntry(Rank.LieutenantJuniorGrade, 2);

                if (character.Career == CareerName.Experienced)
                    weightedRankList.AddEntry(Rank.Lieutenant, 3);

                if (character.Career == CareerName.Experienced || character.Career == CareerName.Veteran)
                {
                    weightedRankList.AddEntry(Rank.LieutenantCommander, 3);
                    weightedRankList.AddEntry(Rank.Commander, 2);
                    weightedRankList.AddEntry(Rank.Captain, 1);
                }

                if (character.Track == DisciplineName.Command && character.Career == CareerName.Veteran)
                {
                    weightedRankList.AddEntry(Rank.RearAdmiral, 1);
                    weightedRankList.AddEntry(Rank.ViceAdmiral, 1);
                    weightedRankList.AddEntry(Rank.Admiral, 1);
                    weightedRankList.AddEntry(Rank.FleetAdmiral, 1);
                }
            }

            return weightedRankList.GetRandom();
        }
    }
}
