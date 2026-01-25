using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class UpbringingSelector : IUpbringingSelector
{
    public Upbringing ChooseUpbringing(Character character)
    {

        var weightedUpbringingList = new WeightedList<Upbringing>();

        foreach (var upbringing in Upbringings)
        {
            if (upbringing.Name.StartsWith("Hardship and Subjugation") && character.PrimarySpecies == SpeciesName.Reman)
                weightedUpbringingList.AddEntry(upbringing, 20);
            else if (upbringing.Name.StartsWith("Hardship and Subjugation") && character.PrimarySpecies != SpeciesName.Reman)
                weightedUpbringingList.AddEntry(upbringing, 1);
            else
                weightedUpbringingList.AddEntry(upbringing, 2);
        }

        var choice = weightedUpbringingList.GetRandom();
        
        if (choice == null)
            return null;
        
        return choice;
    }

    public Upbringing GetUpbringing(string name)
    {
        return Upbringings.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<Upbringing> GetAllUpbringings()
    {
        return Upbringings;
    }

    private static readonly List<Upbringing> Upbringings = new()
    {
        new Upbringing {
            Name = "Agriculture or Rural (Accepted)",
            Attributes = new CharacterAttributes { Fitness = 2, Control = 1 },
            DepartmentChoices = new Departments { Conn = 1, Security = 1, Medicine = 1 },
            Focuses = new List<string> { Focus.AnimalHandling, Focus.Athletics, Focus.EmergencyMedicine, Focus.Endurance, Focus.GroundVehicles, Focus.InfectiousDiseases, Focus.Navigation, Focus.Toxicology, Focus.SurvivalTraining } },

        new Upbringing {
            Name = "Agriculture or Rural (Rebelled)",
            Attributes = new CharacterAttributes { Reason = 2, Presence = 1 },
            DepartmentChoices = new Departments { Conn = 1, Security = 1, Medicine = 1 },
            Focuses = new List<string> { Focus.AnimalHandling, Focus.Athletics, Focus.EmergencyMedicine, Focus.Endurance, Focus.GroundVehicles, Focus.InfectiousDiseases, Focus.Navigation, Focus.Toxicology, Focus.SurvivalTraining } },

        new Upbringing {
            Name = "Artistic and Creative (Accepted)",
            Attributes = new CharacterAttributes { Presence = 2, Insight = 1 },
            DepartmentChoices = new Departments { Command = 1, Engineering = 1, Science = 1 },
            Focuses = new List<string> { Focus.Botany, Focus.CulturalStudies, Focus.Holoprogramming, Focus.Linguistics, Focus.Music, Focus.Observation, Focus.Persuasion, Focus.Psychology } },

        new Upbringing {
            Name = "Artistic and Creative (Rebelled)",
            Attributes = new CharacterAttributes { Fitness = 2, Daring = 1 },
            DepartmentChoices = new Departments { Command = 1, Engineering = 1, Science = 1 },
            Focuses = new List<string> { Focus.Botany, Focus.CulturalStudies, Focus.Holoprogramming, Focus.Linguistics, Focus.Music, Focus.Observation, Focus.Persuasion, Focus.Psychology } },

        new Upbringing {
            Name = "Business or Trade (Accepted)",
            Attributes = new CharacterAttributes { Presence = 2, Daring = 1 },
            DepartmentChoices = new Departments { Command = 1, Engineering = 1, Science = 1 },
            Focuses = new List<string> { Focus.Finances, Focus.Geology, Focus.Linguistics, Focus.Manufacturing, Focus.Metallurgy, Focus.Negotiation, Focus.Survey } },

        new Upbringing {
            Name = "Business or Trade (Rebelled)",
            Attributes = new CharacterAttributes { Insight = 2, Reason = 1 },
            DepartmentChoices = new Departments { Command = 1, Engineering = 1, Science = 1 },
            Focuses = new List<string> { Focus.Finances, Focus.Geology, Focus.Linguistics, Focus.Manufacturing, Focus.Metallurgy, Focus.Negotiation, Focus.Survey } },

        new Upbringing {
            Name = "Diplomacy and Politics (Accepted)",
            Attributes = new CharacterAttributes { Presence = 2, Control = 1 },
            DepartmentChoices = new Departments { Command = 1, Conn = 1, Security = 1 },
            Focuses = new List<string> { Focus.Composure, Focus.Debate, Focus.Diplomacy, Focus.Espionage, Focus.Interrogation, Focus.Law, Focus.Philosophy, Focus.StarfleetProtocol } },

        new Upbringing {
            Name = "Diplomacy and Politics (Rebelled)",
            Attributes = new CharacterAttributes { Reason = 2, Fitness = 1 },
            DepartmentChoices = new Departments { Command = 1, Conn = 1, Security = 1 },
            Focuses = new List<string> { Focus.Composure, Focus.Debate, Focus.Diplomacy, Focus.Espionage, Focus.Interrogation, Focus.Law, Focus.Philosophy, Focus.StarfleetProtocol } },

        new Upbringing {
            Name = "Science and Technology (Accepted)",
            Attributes = new CharacterAttributes { Control = 2, Reason = 1 },
            DepartmentChoices = new Departments { Conn = 1, Engineering = 1, Science = 1, Medicine = 1 },
            Focuses = new List<string> { Focus.Astrophysics, Focus.Astronavigation, Focus.Computers, Focus.Cybernetics, Focus.Genetics, Focus.Physics, Focus.PowerSystems, Focus.QuantumMechanics, Focus.SubspaceCommunications, Focus.Surgery, Focus.WarpFieldDynamics, Focus.Xenobiology } },

        new Upbringing {
            Name = "Science and Technology (Rebelled)",
            Attributes = new CharacterAttributes { Insight = 2, Daring = 1 },
            DepartmentChoices = new Departments { Conn = 1, Engineering = 1, Science = 1, Medicine = 1 },
            Focuses = new List<string> { Focus.Astrophysics, Focus.Astronavigation, Focus.Computers, Focus.Cybernetics, Focus.Genetics, Focus.Physics, Focus.PowerSystems, Focus.QuantumMechanics, Focus.SubspaceCommunications, Focus.Surgery, Focus.WarpFieldDynamics, Focus.Xenobiology } },

        new Upbringing {
            Name = "Starfleet (Accepted)",
            Attributes = new CharacterAttributes { Control = 2, Fitness = 1 },
            AnyDepartment = true,
            Focuses = new List<string> { Focus.Astronavigation, Focus.Composure, Focus.ExtraVehicularActivity, Focus.HandPhasers, Focus.HandToHandCombat, Focus.History, Focus.SmallCraft, Focus.StarfleetProtocol, Focus.StarshipRecognition } },

        new Upbringing {
            Name = "Starfleet (Rebelled)",
            Attributes = new CharacterAttributes { Daring = 2, Insight = 1 },
            AnyDepartment = true,
            Focuses = new List<string> { Focus.Astronavigation, Focus.Composure, Focus.ExtraVehicularActivity, Focus.HandPhasers, Focus.HandToHandCombat, Focus.History, Focus.SmallCraft, Focus.StarfleetProtocol, Focus.StarshipRecognition } },

        new Upbringing {
            Name = "Hardship and Subjugation (Accepted)",
            Attributes = new CharacterAttributes { Control = 2, Presence = 1 },
            DepartmentChoices = new Departments { Command = 1, Security = 1, Medicine = 1 },
            Focuses = new List<string> { Focus.EmergencyMedicine, Focus.Endurance, Focus.GuerrillaTactics, Focus.Stealth, Focus.Survival } },

        new Upbringing {
            Name = "Hardship and Subjugation (Rebelled)",
            Attributes = new CharacterAttributes { Daring = 2, Fitness = 1 },
            DepartmentChoices = new Departments { Command = 1, Security = 1, Medicine = 1 },
            Focuses = new List<string> { Focus.EmergencyMedicine, Focus.Endurance, Focus.GuerrillaTactics, Focus.Stealth, Focus.Survival } },
    };
}
