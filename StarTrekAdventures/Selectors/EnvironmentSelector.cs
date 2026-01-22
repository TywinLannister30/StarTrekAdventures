using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class EnvironmentSelector : IEnvironmentSelector
{
    private const int HomeworldWeight = 10;

    public CharacterEnvironment ChooseEnvironment(string species)
    {
        var weightedEnvironmentList = new WeightedList<CharacterEnvironment>();

        foreach (var environment in GetAllEnvironments())
        {
            if (environment.SpeciesHomeworld.Contains(species))
                weightedEnvironmentList.AddEntry(environment, HomeworldWeight);
            else
                weightedEnvironmentList.AddEntry(environment, environment.Weight);
        }

        return weightedEnvironmentList.GetRandom();
    }

    public CharacterEnvironment GetEnvironment(string name)
    {
        return Environments.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<CharacterEnvironment> GetAllEnvironments()
    {
        return Environments;
    }

    private static readonly List<CharacterEnvironment> Environments = new()
    {
        new() { Name = "Homeworld", DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 }, SpeciesAttributes = true, Weight = HomeworldWeight },
        new() { Name = "Busy Colony", AttributeChoices = new CharacterAttributes { Daring = 1, Presence = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 }, Weight = 5 },
        new() { Name = "Isolated Colony", AttributeChoices = new CharacterAttributes { Reason = 1, Insight = 1 }, DepartmentChoices = new Departments { Engineering = 1, Science = 1, Medicine = 1 }, Weight = 5 },
        new() { Name = "Frontier Colony", AttributeChoices = new CharacterAttributes { Control = 1, Fitness = 1 }, DepartmentChoices = new Departments { Conn = 1, Security = 1, Medicine = 1 }, Weight = 5 },
        new() { Name = "Starship or Stabase", AttributeChoices = new CharacterAttributes { Control = 1, Insight = 1 }, DepartmentChoices = new Departments { Command = 1, Conn = 1, Engineering = 1 }, Weight = 5 },
        new() { Name = "Another Species' World", AnotherSpeciesAttributes = true, AnyDepartment = true, Weight = 1 },

        new() { Name = "Andoria", AttributeChoices = new CharacterAttributes { Control = 1, Presence = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 }, SpeciesHomeworld = { SpeciesName.Aenar, SpeciesName.Andorian }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Betazed", AttributeChoices = new CharacterAttributes { Insight = 1, Presence = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Medicine = 1 }, SpeciesHomeworld = { SpeciesName.Betazoid }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Denobula", AttributeChoices = new CharacterAttributes { Insight = 1, Reason = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 }, SpeciesHomeworld = { SpeciesName.Denobulan }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Earth", AttributeChoices = new CharacterAttributes { Daring = 1, Control = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 }, SpeciesHomeworld = { SpeciesName.Human, SpeciesName.Lanthanite }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Qo’noS", AttributeChoices = new CharacterAttributes { Daring = 1, Presence = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Engineering = 1 }, SpeciesHomeworld = { SpeciesName.Klingon }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Risa", AttributeChoices = new CharacterAttributes { Control = 1, Reason = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 }, SpeciesHomeworld = { SpeciesName.Risian }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Romulus", AttributeChoices = new CharacterAttributes { Control = 1, Reason = 1 }, DepartmentChoices = new Departments { Command = 1, Security = 1, Science = 1 }, SpeciesHomeworld = { SpeciesName.Romulan }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Tellar Prime", AttributeChoices = new CharacterAttributes { Insight = 1, Reason = 1 }, DepartmentChoices = new Departments { Command = 1, Engineering = 1, Science = 1 }, SpeciesHomeworld = { SpeciesName.Tellarite }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Trill", AttributeChoices = new CharacterAttributes { Insight = 1, Presence = 1 }, DepartmentChoices = new Departments { Command = 1, Science = 1, Medicine = 1 }, SpeciesHomeworld = { SpeciesName.Trill }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury },
        new() { Name = "Vulcan", AttributeChoices = new CharacterAttributes { Control = 1, Reason = 1 }, DepartmentChoices = new Departments { Command = 1, Conn = 1, Science = 1, Medicine = 1 }, SpeciesHomeworld = { SpeciesName.Vulcan }, Weight = 1, Source = BookSource.CampiagnGuide23rdCentury }
    };
}
