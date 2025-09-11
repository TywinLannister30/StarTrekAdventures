using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public static class RoleSelector
{
    public static Role ChooseRole(Character character)
    {
        var weightedRoleList = new WeightedList<Role>();

        if (character.IsCommandingOfficer())
            return GetRole(RoleName.CommandingOfficer);

        if (character.Rank == Rank.Commander)
            weightedRoleList.AddEntry(GetRole(RoleName.CommandingOfficer), 1);

        if (character.Rank == Rank.Commander)
            weightedRoleList.AddEntry(GetRole(RoleName.ExecutiveOfficer), 5);

        if (character.CareerPath.StartsWith(TrackName.StarfleetOfficerCommand))
        {
            if (character.Rank == Rank.Commander || character.Rank == Rank.LieutenantCommander)
                weightedRoleList.AddEntry(GetRole(RoleName.ExecutiveOfficer), 5);

            if (character.Departments.Conn >= 4) weightedRoleList.AddEntry(GetRole(RoleName.FlightController), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.StarfleetOfficerOperations))
        {
            if (character.Experience == ExperienceName.Experienced || character.Experience == ExperienceName.Veteran)
            {
                if (character.Departments.Engineering >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefEngineer), 10);
                if (character.Departments.Engineering >= 4) weightedRoleList.AddEntry(GetRole(RoleName.OperationsManager), 10);
                if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefOfSecurity), 10);
                if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefTacticalOfficer), 10);
            }
        }

        if (character.CareerPath.StartsWith(TrackName.StarfleetOfficerSciences))
        {
            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Navigator), 5);
            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ScienceOfficer), 10);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ShipsDoctor), 10);

            if (character.Experience == ExperienceName.Experienced || character.Experience == ExperienceName.Veteran)
            {
                if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefMedicalOfficer), 10);
            }

            if (character.HasPsychologyFocus())
            {
                weightedRoleList.AddEntry(GetRole(RoleName.ShipsCounselor), 10);
            }
        }

        if (character.CareerPath.StartsWith(TrackName.StarfleetEnlisted))
        {
            if (character.Departments.Conn >= 4) weightedRoleList.AddEntry(GetRole(RoleName.FlightController), 10);

            if (character.Experience == ExperienceName.Experienced || character.Experience == ExperienceName.Veteran)
            {
                if (character.Departments.Engineering >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefEngineer), 10);
                if (character.Departments.Engineering >= 4) weightedRoleList.AddEntry(GetRole(RoleName.OperationsManager), 10);
                if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefOfSecurity), 10);
                if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefTacticalOfficer), 10);
            }

            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Navigator), 5);
            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ScienceOfficer), 10);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ShipsDoctor), 10);

            if (character.HasPsychologyFocus())
            {
                weightedRoleList.AddEntry(GetRole(RoleName.ShipsCounselor), 10);
            }
        }

        if (character.CareerPath.StartsWith(TrackName.StarfleetIntelligence))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.IntelligenceAgent), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.DiplomaticCorps))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.PoliticalLiason), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.CivilianPhysician))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.Expert), 10);

            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ShipsDoctor), 10);

            if (character.HasPsychologyFocus())
            {
                weightedRoleList.AddEntry(GetRole(RoleName.ShipsCounselor), 10);
            }
        }

        if (character.CareerPath.StartsWith(TrackName.CivilianScientist))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.Expert), 10);

            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Navigator), 5);
            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ScienceOfficer), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.CivilianOfficial))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.Expert), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.CivilianTrader))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.Merchant), 10);

            if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Bodyguard), 10);

        }

        weightedRoleList.AddEntry(GetRole(RoleName.CommunicationsOfficer), 1);

        if (character.Roles.Count != 0)
            weightedRoleList.RemoveAll(character.Roles.First());

        return weightedRoleList.GetRandom();
    }

    public static Role GetRole(string name)
    {
        return Roles.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    internal static List<Role> GetAllRoles()
    {
        return Roles;
    }

    private static readonly List<Role> Roles = new()
    {
        new Role
        {
            Name = RoleName.CommandingOfficer,
            Benefit = "You may spend Determination to grant any other character you can communicate with 1 Determination; this does not have to be linked to using or challenging a value."
        },
        new Role
        {
            Name = RoleName.ExecutiveOfficer,
            Benefit = "When an allied character in communication with you spends Determination, you may spend 3 Momentum (Immediate) to enable that character to regain the spent point of Determination."
        },
        new Role
        {
            Name = RoleName.OperationsManager,
            Benefit = "Whenever you create a trait representing a piece of equipment, or an alteration made to existing equipment, any character who benefits from that trait while you are present in the scene may re-roll a d20."
        },
        new Role
        {
            Name = RoleName.ChiefEngineer,
            Benefit = "You reduce the opportunity cost of engineering teams by 1, to a minimum of 0. Further, when you attempt a task to perform repairs to a starship or attempt to push the ship’s capabilities beyond its normal limits, you may spend 1 Momentum (Immediate) to re-roll a d20."
        },
        new Role
        {
            Name = RoleName.ChiefOfSecurity,
            Benefit = "You reduce the opportunity cost of weapons and security teams by 1, to a minimum of 0. Further, when you succeed at an Attack against an enemy during personal combat, you may spend 1 Momentum to increase the Difficulty of that enemy’s next Attack by 1."
        },
        new Role
        {
            Name = RoleName.ChiefTacticalOfficer,
            Benefit = "When you succeed at an Attack with the ship’s weapons, you may increase the damage rating of that weapon system by spending 1 Momentum rather than 2."
        },
        new Role
        {
            Name = RoleName.FlightController,
            Benefit = "When you attempt an engineering task related to flight or propulsion, you may use your Conn rating instead of Engineering. When you succeed at a Conn task to pilot a starship, you generate 1 bonus Momentum to be used on that task (bonus Momentum may not be saved)."
        },
        new Role
        {
            Name = RoleName.Navigator,
            Benefit = "When you attempt a science task related to astrophysics or stellar navigation, you may use your Conn rating instead of Science. When you attempt or Assist a task to maneuver a starship through difficult or dangerous terrain, you may spend 1 Momentum to ignore a complication suffered (Repeatable)."
        },
        new Role
        {
            Name = RoleName.ScienceOfficer,
            Benefit = "When you succeed at a task assisted by the ship’s Sensors or Computers, or a task using a tricorder or other sensing device, you may ask one additional question as if you had spent Momentum on Obtain Information."
        },
        new Role
        {
            Name = RoleName.ChiefMedicalOfficer,
            Benefit = "You reduce the opportunity cost of medical equipment and medical teams by 1, to a minimum of 0. Further, when you attempt a task using your Medicine rating, and you have assistance, you generate 1 bonus Momentum (bonus Momentum may not be saved)."
        },
        new Role
        {
            Name = RoleName.ShipsDoctor,
            Benefit = "You have two additional focuses, which must relate to medicine fields of study. However, your ship cannot use Crew Support to introduce supporting characters who are medical personnel.",
            AdditionalFocuses = 2,
            AdditionalFocusesChoices = new List<string>() { Focus.Cybernetics, Focus.EmergencyMedicine,  Focus.Genetics, Focus.InfectiousDiseases, Focus.Psychiatry, Focus.Surgery, Focus.TraumaSurgery, Focus.Virology, Focus.Xenobiology }
        },
        new Role
        {
            Name = RoleName.ShipsCounselor,
            Benefit = "When you Assist a character suffering from a trait representing a negative emotional state, you may re-roll your assist die. Additionally, once per mission, you may spend a scene counseling a character who has challenged one of their values during the current mission. At the end of the scene, the character may rewrite their crossed-out value immediately, rather than waiting until the end of the mission. If they do this, they immediately gain 1 Determination as well."
        },
        new Role
        {
            Name = RoleName.CommunicationsOfficer,
            Benefit = "When you attempt a task assisted by the ship’s Computers or Communications systems, do not roll the ship’s assist die: instead, count the ship’s die as if it had rolled a 1."
        },
        new Role
        {
            Name = RoleName.Bodyguard,
            Benefit = "Choose a single character—another player character or an NPC—who you are assigned to protect. When you are in the same zone as that character, you may spend 1 Momentum (Immediate) when that character is attacked to have the Attack target you instead. If you do this, the attack’s Difficulty is increased by 1."
        },
        new Role
        {
            Name = RoleName.Expert,
            Benefit = "You gain one additional value, which must reflect the importance of your work to you. In addition, select one of your focuses—this is the field you are an expert in. When you use this focus on a task and succeed, you generate 1 bonus Momentum (bonus Momentum may not be saved).",
            AdditionalValues = 1
        },
        new Role
        {
            Name = RoleName.IntelligenceAgent,
            Benefit = "Once per adventure, you may create a trait without requiring a task or spending any Momentum, Threat, or Determination. This trait must reflect information, physical resources, or access to a location (such as access codes or identification data) provided to you by a contact or by your agency."
        },
        new Role
        {
            Name = RoleName.Merchant,
            Benefit = "Once per adventure, you can ignore the opportunity costs on up to three items of equipment being acquired by other player characters. You may even allow other player characters to obtain items not normally available to them (such as disruptors to a Starfleet crew, or items which are restricted or illegal), though you add 1 Threat for each such item provided."
        },
        new Role
        {
            Name = RoleName.PoliticalLiason,
            Benefit = "You represent the official government your organization belongs to—i.e., if you are a member of the Bajoran Militia, you represent the current Bajoran government. You gain an additional Directive, which only applies to you, which reflects the political stance of the government you represent. Your gamemaster will work with you to determine the wording of this Directive. It serves to provide you with a source of complications and potential restrictions when acting against the interests of your government, and benefits when you are acting with the full support of your superiors."
        },
        new Role
        {
            Name = RoleName.Translator,
            Benefit = "When attempting to read, understand, or speak a language unfamiliar to you, you may spend 2 Momentum (Immediate) to piece together a basic understanding of that language immediately, enough to convey simple ideas. This allows social tasks to be attempted in this language, but the complication range of these tasks is increased to 18–20. Deeper study, at the gamemaster’s discretion, allows you to remove this penalty and discuss more complex ideas."
        },
    };
}
