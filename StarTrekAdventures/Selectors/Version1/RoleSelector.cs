using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Helpers.Version1;
using StarTrekAdventures.Models.Version1;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class RoleSelector
    {
        public static string ChooseRole(Character character)
        {
            var weightedRoleList = new WeightedList<string>();

            if (RankHelper.IsFlagOfficer(character))
                return RoleName.Admiral;

            if (character.Rank == Rank.Captain)
                return RoleName.CommandingOfficer;

            if (character.Track == DisciplineName.Command)
            {
                if (character.Rank == Rank.Commander)
                    weightedRoleList.AddEntry(RoleName.CommandingOfficer, 10);

                weightedRoleList.AddEntry(RoleName.Adjudant, 1);
                weightedRoleList.AddEntry(RoleName.ExecutiveOfficer, 10);
                weightedRoleList.AddEntry(RoleName.StrategicOperationsOfficer, 5);
            }

            if (character.Track == DisciplineName.Engineering)
            {
                weightedRoleList.AddEntry(RoleName.OperationsManager, 5);
                weightedRoleList.AddEntry(RoleName.ChiefEngineer, 5);
            }

            if (character.Track == DisciplineName.Security)
            {
                weightedRoleList.AddEntry(RoleName.ChiefOfSecurity, 5);
                weightedRoleList.AddEntry(RoleName.ChiefTacticalOfficer, 5);
            }

            if (character.Track == DisciplineName.Medicine)
            {
                foreach (var focus in character.Focuses)
                {
                    if (FocusHelper.IsPsychologyFocus(focus))
                        weightedRoleList.AddEntry(RoleName.ShipsCounselor, 5);
                }

                weightedRoleList.AddEntry(RoleName.ChiefMedicalOfficer, 5);

                weightedRoleList.AddEntry(RoleName.ChiefSurgeon, 3);
                weightedRoleList.AddEntry(RoleName.HeadNurse, 2);
                weightedRoleList.AddEntry(RoleName.Anesthesiologist, 1);
                weightedRoleList.AddEntry(RoleName.PhysiciansAssistant, 1);
            }

            if (character.Track == DisciplineName.Science)
            {
                weightedRoleList.AddEntry(RoleName.ChiefScienceOfficer, 5);
            }

            if (character.Track == DisciplineName.Conn)
            {
                weightedRoleList.AddEntry(RoleName.FlightController, 5);
            }

            weightedRoleList.AddEntry(RoleName.DiplomaticAttache, 1);
            weightedRoleList.AddEntry(RoleName.FleetLiaisonOfficer, 1);
            weightedRoleList.AddEntry(RoleName.IntelligenceOfficer, 1);

            return weightedRoleList.GetRandom();
        }
    }
}
