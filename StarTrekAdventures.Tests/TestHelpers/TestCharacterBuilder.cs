using StarTrekAdventures.Models;

namespace StarTrekAdventures.Tests.TestHelpers;

public class CharacterBuilder
{
    private Character _character = new();

    public CharacterBuilder AddValidDetails()
    {
        _character = new Character
        {
            Attributes = new CharacterAttributes
            {
                Control = 10,
                Daring = 10,
                Fitness = 9,
                Insight = 9,
                Presence = 9,
                Reason = 9
            },
            Departments = new Departments
            {
                Command = 3,
                Conn = 3,
                Engineering = 3,
                Security = 3,
                Science = 2,
                Medicine = 2
            },
            SpeciesAbility = new SpeciesAbility { Name = "Human Resilience", Description = "Humans are adaptable and resilient." },
            Traits = [],
            Values = ["Duty", "Honor", "Courage", "Exploration"],
            Focuses = ["Starship Operations", "Diplomacy", "Science", "Leadership", "Focus1", "Focus2"],
            Talents =
            [
                new Talent { Name = "Adaptable" },
                new Talent { Name = "Brilliant Strategist" },
                new Talent { Name = "Calm Under Pressure" },
                new Talent { Name = "Veteran" }
            ],
            CareerEvents = ["First Contact", "Battle of the Binary Stars"],
            Rank = "Lieutenant"
        };

        return this;
    }

    public CharacterBuilder AddBasicDetails()
    {
        _character = new Character
        {
            Attributes = new CharacterAttributes
            {
                Control = 7,
                Daring = 7,
                Fitness = 7,
                Insight = 7,
                Presence = 7,
                Reason = 7
            },
            Departments = new Departments
            {
                Command = 1,
                Conn = 1,
                Engineering = 1,
                Security = 1,
                Science = 1,
                Medicine = 1
            },
            SpeciesAbility = new SpeciesAbility(),
            Traits = [],
            Values = [],
            Focuses = [],
            Talents = [],
            CareerEvents = []
        };

        return this;
    }

    public CharacterBuilder SetAttributes(CharacterAttributes attributes)
    {
        _character.Attributes = attributes;
        return this;
    }

    public CharacterBuilder SetDepartments(Departments departments)
    {
        _character.Departments = departments;
        return this;
    }

    public CharacterBuilder ClearValues()
    {
        _character.Values = [];
        return this;
    }

    public CharacterBuilder ClearTalents()
    {
        _character.Talents = [];
        return this;
    }

    public CharacterBuilder ClearFocuses()
    {
        _character.Focuses = [];
        return this;
    }

    public CharacterBuilder SetRoles(List<Role> roles)
    {
        _character.Roles = roles;
        return this;
    }

    public CharacterBuilder SetSpeciesAbility(SpeciesAbility speciesAbility)
    {
        _character.SpeciesAbility = speciesAbility;
        return this;
    }

    public CharacterBuilder SetTalents(List<Talent> talents)
    {
        _character.Talents = talents;
        return this;
    }

    public CharacterBuilder SetRank(string rank)
    {
        _character.Rank = rank;
        return this;
    }

    public CharacterBuilder AddTrait(string trait)
    {
        _character.Traits.Add(trait);
        return this;
    }

    public CharacterBuilder AddEnvironment(string environment)
    {
        _character.Environment = environment;
        return this;
    }

    public CharacterBuilder SetCareerPath(string careerPath)
    {
        _character.CareerPath = careerPath;
        return this;
    }

    public Character Build()
    {
        return _character;
    }
}