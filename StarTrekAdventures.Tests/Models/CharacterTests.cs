using Moq;
using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;
using StarTrekAdventures.Tests.TestHelpers;
using System.Data;

namespace StarTrekAdventures.Tests.Models;

public class CharacterTests
{
    private readonly Mock<IRoleSelector> _mockRoleSelector;
    private readonly Mock<ISpeciesSelector> _mockSpeciesSelector;
    private readonly Mock<ITalentSelector> _mockTalentSelector;
    private readonly Mock<IValueSelector> _mockValueSelector;

    public CharacterTests()
    {
        _mockRoleSelector = new Mock<IRoleSelector>();
        _mockSpeciesSelector = new Mock<ISpeciesSelector>();
        _mockTalentSelector = new Mock<ITalentSelector>();
        _mockValueSelector = new Mock<IValueSelector>();
    }

    [Fact]
    public void IsValid_True_WhenValidCharacter()
    {
        var character = new CharacterBuilder().AddValidDetails().Build();

        Assert.True(character.IsValid);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(-1)]
    public void IsValid_False_WhenSumOfAttributesIsNot56(int modifier)
    {
        var total = 56 + modifier;

        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetAttributes(new CharacterAttributes
            {
                Control = 10 + modifier,
                Daring = 10,
                Fitness = 9,
                Insight = 9,
                Presence = 9,
                Reason = 9
            })
            .Build();

        Assert.False(character.IsValid);
        Assert.Contains($"Sum of attributes is {total}. It should be 56.", character.ValidationIssue);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(-1)]
    public void IsValid_False_WhenSumOfDepartmentsIsNot16(int modifier)
    {
        var total = 16 + modifier;

        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetDepartments(new Departments
            {
                Command = 3 + modifier,
                Conn = 3,
                Engineering = 3,
                Security = 3,
                Science = 2,
                Medicine = 2
            })
            .Build();

        Assert.False(character.IsValid);
        Assert.Contains($"Sum of departments is {total}. It should be 16.", character.ValidationIssue);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void IsValid_False_WhenNumberOfValuesIsNotFour(int numValues)
    {
        var character = new CharacterBuilder().AddValidDetails().ClearValues().Build();
        
        for (var i = 0; i < numValues; i++)
        {
            character.Values.Add($"Value{i+1}");
        }

        Assert.False(character.IsValid);
        Assert.Contains($"The character has {numValues} values. It should be 4.", character.ValidationIssue);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void IsValid_False_WhenNumberOfValuesIsNotFiveIfRoleAddsValue(int numValues)
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetRoles([new Role { Name = "Role1", AdditionalValues = 1 }])
            .ClearValues()
            .Build();

        for (var i = 0; i < numValues; i++)
        {
            character.Values.Add($"Value{i + 1}");
        }

        Assert.False(character.IsValid);
        Assert.Contains($"The character has {numValues} values. It should be 5.", character.ValidationIssue);
    }

    [Fact]
    public void IsValid_True_WhenNumberOfValuesIsFiveIfRoleAddsValue()
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetRoles([new Role { Name = "Role1", AdditionalValues = 1 }])
            .Build();

        character.Values.Add($"Value 5");

        Assert.True(character.IsValid);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void IsValid_False_WhenNumberOfTalentsIsNotFour(int numTalents)
    {
        var character = new CharacterBuilder().AddValidDetails().ClearTalents().Build();

        for (var i = 0; i < numTalents; i++)
        {
            character.Talents.Add(new Talent { Name = $"Talent{i + 1}" });
        }

        Assert.False(character.IsValid);
        Assert.Contains($"The character has {numTalents} talents. It should be 4.", character.ValidationIssue);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void IsValid_False_WhenNumberOfTalentsIsNotFiveIfSpeciesAddsTalent(int numTalents)
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetSpeciesAbility(new SpeciesAbility { Name = "Ability1", Description = "Desc1", AddTalent = "Talent" })
            .ClearTalents()
            .Build();

        for (var i = 0; i < numTalents; i++)
        {
            character.Talents.Add(new Talent { Name = $"Talent{i + 1}" });
        }

        Assert.False(character.IsValid);
        Assert.Contains($"The character has {numTalents} talents. It should be 5.", character.ValidationIssue);
    }

    [Fact]
    public void IsValid_True_WhenNumberOfTalentsIsFiveIfSpeciesAddsTalent()
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetSpeciesAbility(new SpeciesAbility { Name = "Ability1", Description = "Desc1", AddTalent = "Talent" })
            .Build();
        
        character.Talents.Add(new Talent { Name = "Talent 5" });

        Assert.True(character.IsValid);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void IsValid_False_WhenNumberOfFocusesIsNotSix(int numFocuses)
    {
        var character = new CharacterBuilder().AddValidDetails().ClearFocuses().Build();

        for (var i = 0; i < numFocuses; i++)
        {
            character.Focuses.Add($"Focus{i + 1}");
        }

        Assert.False(character.IsValid);
        Assert.Contains($"The character has {numFocuses} focuses. It should be 6.", character.ValidationIssue);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void IsValid_False_WhenNumberOfFocusesIsNotSevenAndSpeciesAddsFocus(int numFocuses)
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetSpeciesAbility(new SpeciesAbility { Name = "Ability1", Description = "Desc1", AdditionalFocuses = 1 })
            .ClearFocuses()
            .Build();

        for (var i = 0; i < numFocuses; i++)
        {
            character.Focuses.Add($"Focus{i + 1}");
        }

        Assert.False(character.IsValid);
        Assert.Contains($"The character has {numFocuses} focuses. It should be 7.", character.ValidationIssue);
    }

    [Fact]
    public void IsValid_True_WhenNumberOfFocusesIsSevenAndSpeciesAddsFocus()
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetSpeciesAbility(new SpeciesAbility { Name = "Ability1", Description = "Desc1", AdditionalFocuses = 1 })
            .Build();

        character.Focuses.Add("Focus 7");

        Assert.True(character.IsValid);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void IsValid_False_WhenNumberOfFocusesIsNotSevenAndRoleAddsFocus(int numFocuses)
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetRoles([new Role { Name = "Role1", AdditionalFocuses = 1 }])
            .ClearFocuses()
            .Build();

        for (var i = 0; i < numFocuses; i++)
        {
            character.Focuses.Add($"Focus{i + 1}");
        }

        Assert.False(character.IsValid);
        Assert.Contains($"The character has {numFocuses} focuses. It should be 7.", character.ValidationIssue);
    }

    [Fact]
    public void IsValid_True_WhenNumberOfFocusesIsSevenAndRoleAddsFocus()
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetRoles([new Role { Name = "Role1", AdditionalFocuses = 1 }])
            .Build();

        character.Focuses.Add("Focus 7");

        Assert.True(character.IsValid);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void IsValid_False_WhenNumberOfFocusesIsNotSevenAndTalentAddsFocus(int numFocuses)
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetTalents(
            [
                new() { Name = "Talent1" },
                new() { Name = "Talent2" },
                new() { Name = "Talent3" },
                new() { Name = "Talent4", GainRandomFocus = new List<string> { "Focus 7" } }
            ])
            .ClearFocuses()
            .Build();

        for (var i = 0; i < numFocuses; i++)
        {
            character.Focuses.Add($"Focus{i + 1}");
        }

        Assert.False(character.IsValid);
        Assert.Contains($"The character has {numFocuses} focuses. It should be 7.", character.ValidationIssue);
    }

    [Fact]
    public void IsValid_True_WhenNumberOfFocusesIsSevenAndTalentAddsFocus()
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetTalents(
            [
                new() { Name = "Talent1" },
                new() { Name = "Talent2" },
                new() { Name = "Talent3" },
                new() { Name = "Talent4", GainRandomFocus = new List<string> { "Focus 7" } }
            ])
            .Build();

        character.Focuses.Add("Focus 7");

        Assert.True(character.IsValid);
    }

    [Fact]
    public void AllAttributesLessThanOrEqualTo_ReturnsTrue_WhenAllAreBelowOrEqual()
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetAttributes(new CharacterAttributes
            {
                Control = 7,
                Daring = 7,
                Fitness = 7,
                Insight = 7,
                Presence = 7,
                Reason = 7
            })
            .Build();

        Assert.True(character.AllAttributesLessThanOrEqualTo(7));
    }

    [Fact]
    public void AllAttributesLessThanOrEqualTo_ReturnsFalse_WhenAnyAbove()
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetAttributes(new CharacterAttributes
            {
                Control = 8,
                Daring = 7,
                Fitness = 7,
                Insight = 7,
                Presence = 7,
                Reason = 7
            })
            .Build();

        Assert.False(character.AllAttributesLessThanOrEqualTo(7));
    }

    [Fact]
    public void AllDepartmentsLessThanOrEqualTo_ReturnsTrue_WhenAllAreBelowOrEqual()
    {
        var character = new CharacterBuilder()
            .AddValidDetails()
            .SetDepartments(new Departments
            {
                Command = 1,
                Conn = 1,
                Engineering = 1,
                Security = 1,
                Science = 1,
                Medicine = 1
            })
            .Build();

        Assert.True(character.AllDepartmentsLessThanOrEqualTo(1));
    }

    [Fact]
    public void AllDepartmentsLessThanOrEqualTo_ReturnsFalse_WhenAnyAbove()
    {
        var character = new CharacterBuilder()
           .AddValidDetails()
           .SetDepartments(new Departments
           {
               Command = 2,
               Conn = 1,
               Engineering = 1,
               Security = 1,
               Science = 1,
               Medicine = 1
           })
           .Build();

        Assert.False(character.AllDepartmentsLessThanOrEqualTo(1));
    }

    [Fact]
    public void AdjustAttributesForSpecies_ThreeSpecificAttributes_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var species = new Species { AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Fitness = 1 } };

        character.AdjustAttributesForSpecies(species, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(8, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(8, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForSpecies_ThreeRandomAttributesAndFirstThreeChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var species = new Species { AttributeModifiers = new CharacterAttributes(), ThreeRandomAttributes = true };

        character.AdjustAttributesForSpecies(species, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(8, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(8, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForSpecies_ThreeRandomAttributesAndLastThreeChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var species = new Species { AttributeModifiers = new CharacterAttributes(), ThreeRandomAttributes = true };

        character.AdjustAttributesForSpecies(species, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(8, character.Attributes.Insight);
        Assert.Equal(8, character.Attributes.Presence);
        Assert.Equal(8, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForSpecies_OneOfTheseModifiersAndFirstThreeChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var species = new Species { AttributeModifiers = new CharacterAttributes(), OneOfTheseModifiers = new CharacterAttributes { Fitness = 1, Insight = 1 } };

        character.AdjustAttributesForSpecies(species, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(8, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForSpecies_OneOfTheseModifiersAndLastThreeChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var species = new Species { AttributeModifiers = new CharacterAttributes(), OneOfTheseModifiers = new CharacterAttributes { Fitness = 1, Insight = 1 } };

        character.AdjustAttributesForSpecies(species, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(8, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AddSpeciesAbility_NoIssues_AddsSpeciesAbility()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var speciesAbility = new SpeciesAbility { Name = "Species Ability" };

        character.AddSpeciesAbility(speciesAbility, _mockTalentSelector.Object);

        Assert.Equal(speciesAbility, character.SpeciesAbility);
        Assert.Empty(character.Talents);
    }

    [Fact]
    public void AddSpeciesAbility_SpeciesAbilityAddsTalent_AddsSpeciesAbilityWithTalent()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var speciesAbility = new SpeciesAbility { Name = "Species Ability", AddTalent = "talent" };

        _mockTalentSelector
            .Setup(t => t.GetTalent("talent"))
            .Returns(new Talent { Name = "talent" });

        character.AddSpeciesAbility(speciesAbility, _mockTalentSelector.Object);

        Assert.Equal(speciesAbility, character.SpeciesAbility);
        Assert.Single(character.Talents);
        Assert.Equal("talent", character.Talents.First().Name);
    }

    [Fact]
    public void AddSpeciesAbility_SpeciesAbilityAddsOneOfTheseTalentsAndPicksFirst_AddsSpeciesAbilityWithTalent()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var speciesAbility = new SpeciesAbility { Name = "Species Ability", AddOneOfTheseTalents = ["talent1", "talent2"] };

        _mockTalentSelector
            .Setup(t => t.GetTalent("talent1"))
            .Returns(new Talent { Name = "talent1" });

        _mockTalentSelector
            .Setup(t => t.GetTalent("talent2"))
            .Returns(new Talent { Name = "talent2" });

        character.AddSpeciesAbility(speciesAbility, _mockTalentSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(speciesAbility, character.SpeciesAbility);
        Assert.Single(character.Talents);
        Assert.Equal("talent1", character.Talents.First().Name);
    }

    [Fact]
    public void AddSpeciesAbility_SpeciesAbilityAddsOneOfTheseTalentsAndPicksLast_AddsSpeciesAbilityWithTalent()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var speciesAbility = new SpeciesAbility { Name = "Species Ability", AddOneOfTheseTalents = ["talent1", "talent2"] };

        _mockTalentSelector
            .Setup(t => t.GetTalent("talent1"))
            .Returns(new Talent { Name = "talent1" });

        _mockTalentSelector
            .Setup(t => t.GetTalent("talent2"))
            .Returns(new Talent { Name = "talent2" });

        character.AddSpeciesAbility(speciesAbility, _mockTalentSelector.Object, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(speciesAbility, character.SpeciesAbility);
        Assert.Single(character.Talents);
        Assert.Equal("talent2", character.Talents.First().Name);
    }

    [Fact]
    public void AddValue_NoIssues_AddsValue()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockValueSelector.Setup(x => x.ChooseValue(It.IsAny<Character>())).Returns("New Value");

        character.AddValue(_mockValueSelector.Object);

        Assert.Single(character.Values);
        Assert.Equal("New Value", character.Values.First());
    }

    [Fact]
    public void AdjustAttributesForEnvironment_TwoChoicesAndFirstChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var environment = new CharacterEnvironment { AttributeChoices = new CharacterAttributes { Control = 1, Daring = 1 } };

        character.AdjustAttributesForEnvironment(environment, _mockSpeciesSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(8, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForEnvironment_TwoChoicesAndLastChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var environment = new CharacterEnvironment { AttributeChoices = new CharacterAttributes { Control = 1, Daring = 1 } };

        character.AdjustAttributesForEnvironment(environment, _mockSpeciesSelector.Object, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForEnvironment_AdjustForSpeciesAttributesAndFirstChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().AddTrait("Race").Build();
        var environment = new CharacterEnvironment { SpeciesAttributes = true };

        _mockSpeciesSelector
            .Setup(s => s.GetSpecies(It.IsAny<string>()))
            .Returns(new Species { AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Fitness = 1 } });

        character.AdjustAttributesForEnvironment(environment, _mockSpeciesSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(8, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForEnvironment_AdjustForSpeciesAttributesAndLastChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().AddTrait("Race").Build();
        var environment = new CharacterEnvironment { SpeciesAttributes = true };

        _mockSpeciesSelector
            .Setup(s => s.GetSpecies(It.IsAny<string>()))
            .Returns(new Species { AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Fitness = 1 } });

        character.AdjustAttributesForEnvironment(environment, _mockSpeciesSelector.Object, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(8, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForEnvironment_AdjustForAnotherSpeciesAttributesAndFirstChosen_AddsExpectedAttributesAndAdjustsEnvironmentName()
    {
        var character = new CharacterBuilder().AddBasicDetails().AddEnvironment("Another Species World").AddTrait("Race").Build();
        var environment = new CharacterEnvironment { AnotherSpeciesAttributes = true };

        _mockSpeciesSelector
            .Setup(s => s.GetAnotherRandomSpecies(It.IsAny<string>()))
            .Returns(new Species { Name = "Other Race", AttributeModifiers = new CharacterAttributes { Insight = 1, Presence = 1, Reason = 1 } });

        character.AdjustAttributesForEnvironment(environment, _mockSpeciesSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(8, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
        Assert.Equal("Another Species World (Other Race)", character.Environment);
    }

    [Fact]
    public void AdjustAttributesForEnvironment_AdjustForAnotherSpeciesAttributesAndLastChosen_AddsExpectedAttributesAndAdjustsEnvironmentName()
    {
        var character = new CharacterBuilder().AddBasicDetails().AddEnvironment("Another Species World").AddTrait("Race").Build();
        var environment = new CharacterEnvironment { AnotherSpeciesAttributes = true };

        _mockSpeciesSelector
            .Setup(s => s.GetAnotherRandomSpecies(It.IsAny<string>()))
            .Returns(new Species { Name = "Other Race", AttributeModifiers = new CharacterAttributes { Insight = 1, Presence = 1, Reason = 1 } });

        character.AdjustAttributesForEnvironment(environment, _mockSpeciesSelector.Object, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(8, character.Attributes.Reason);
        Assert.Equal("Another Species World (Other Race)", character.Environment);
    }

    [Fact]
    public void AdjustAttributesForEnvironment_AdjustForSpeciesAttributesWithThreeRandomAttributesAndFirstChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder()
            .AddBasicDetails()
            .SetAttributes(new CharacterAttributes
            {
                Control = 8,
                Daring = 8,
                Fitness = 8,
                Insight = 8,
                Presence = 8,
                Reason = 8
            })
            .AddTrait("Race").Build();
        var environment = new CharacterEnvironment { SpeciesAttributes = true };

        _mockSpeciesSelector
            .Setup(s => s.GetSpecies(It.IsAny<string>()))
            .Returns(new Species { ThreeRandomAttributes = true });

        character.AdjustAttributesForEnvironment(environment, _mockSpeciesSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(9, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(8, character.Attributes.Fitness);
        Assert.Equal(8, character.Attributes.Insight);
        Assert.Equal(8, character.Attributes.Presence);
        Assert.Equal(8, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForEnvironment_AdjustForSpeciesAttributesWithThreeRandomAttributesAndLastChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder()
            .AddBasicDetails()
            .SetAttributes(new CharacterAttributes
            {
                Control = 8,
                Daring = 8,
                Fitness = 8,
                Insight = 8,
                Presence = 8,
                Reason = 8
            })
            .AddTrait("Race").Build();
        var environment = new CharacterEnvironment { SpeciesAttributes = true };

        _mockSpeciesSelector
            .Setup(s => s.GetSpecies(It.IsAny<string>()))
            .Returns(new Species { ThreeRandomAttributes = true });

        character.AdjustAttributesForEnvironment(environment, _mockSpeciesSelector.Object, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(8, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(8, character.Attributes.Fitness);
        Assert.Equal(8, character.Attributes.Insight);
        Assert.Equal(8, character.Attributes.Presence);
        Assert.Equal(9, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustDepartmentsForEnvironment_TwoChoicesAndFirstChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var environment = new CharacterEnvironment { DepartmentChoices = new Departments { Command = 1, Conn = 1 } };

        character.AdjustDepartmentsForEnvironment(environment, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(2, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForEnvironment_TwoChoicesAndLastChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var environment = new CharacterEnvironment { DepartmentChoices = new Departments { Command = 1, Conn = 1 } };

        character.AdjustDepartmentsForEnvironment(environment, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(2, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForEnvironment_AnyDepartmentAndFirstChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var environment = new CharacterEnvironment { AnyDepartment = true };

        character.AdjustDepartmentsForEnvironment(environment, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(2, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForEnvironment_AnyDepartmentAndLastChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var environment = new CharacterEnvironment { AnyDepartment = true };

        character.AdjustDepartmentsForEnvironment(environment, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(2, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustAttributesForUpbringing_TwoSpecificAttributes_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var upbringing = new Upbringing { Attributes = new CharacterAttributes { Fitness = 2, Reason = 1 } };

        character.AdjustAttributesForUpbringing(upbringing);

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(9, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(8, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustDepartmentsForUpbringing_ThreeChoicesAndFirstChosen_AddsExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var upbringing = new Upbringing { DepartmentChoices = new Departments { Command = 1, Conn = 1, Engineering = 1 } };

        character.AdjustDepartmentsForUpbringing(upbringing, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(2, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForUpbringing_ThreeChoicesAndLastChosen_AddsExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var upbringing = new Upbringing { DepartmentChoices = new Departments { Command = 1, Conn = 1, Engineering = 1 } };

        character.AdjustDepartmentsForUpbringing(upbringing, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(2, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForUpbringing_AnyDepartmentAndFirstChosen_AddsExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var upbringing = new Upbringing { AnyDepartment = true };

        character.AdjustDepartmentsForUpbringing(upbringing, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(2, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForUpbringing_AnyDepartmentAndLastChosen_AddsExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var upbringing = new Upbringing { AnyDepartment = true };

        character.AdjustDepartmentsForUpbringing(upbringing, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(2, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AddFocuses_OneRandomFocusAndFirstChosen_AddsExpectedFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AddFocuses(["First", "Last"], 1, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Single(character.Focuses);
        Assert.Equal("First", character.Focuses.First());
    }

    [Fact]
    public void AddFocuses_OneRandomFocusAndLastChosen_AddsExpectedFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AddFocuses(["First", "Last"], 1, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Single(character.Focuses);
        Assert.Equal("Last", character.Focuses.First());
    }

    [Fact]
    public void AddFocuses_TwoRandomFocusAndFirstTwoChosen_AddsExpectedFocuses()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AddFocuses(["First", "Second", "Third"], 2, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(2, character.Focuses.Count);
        Assert.Contains("First", character.Focuses);
        Assert.Contains("Second", character.Focuses);
    }

    [Fact]
    public void AddFocuses_TwoRandomFocusAndLastTwoChosen_AddsExpectedFocuses()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AddFocuses(["First", "Second", "Third"], 2, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(2, character.Focuses.Count);
        Assert.Contains("Second", character.Focuses);
        Assert.Contains("Third", character.Focuses);
    }

    [Fact]
    public void AddTalent_ChooseTalent_AddsExpectedTalent()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockTalentSelector.Setup(x => x.ChooseTalent(It.IsAny<Character>())).Returns(new Talent { Name = "Talent" });

        character.AddTalent(_mockTalentSelector.Object);

        Assert.Single(character.Talents);
        Assert.Equal("Talent", character.Talents.First().Name);
        _mockTalentSelector.Verify(x => x.GetTalent(It.IsAny<string>()), Times.Never);
    }

    [Fact]
    public void AddTalent_GetTalent_AddsExpectedTalent()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockTalentSelector.Setup(x => x.GetTalent(It.IsAny<string>())).Returns(new Talent { Name = "Talent" });

        character.AddTalent(_mockTalentSelector.Object, "Talent");

        Assert.Single(character.Talents);
        Assert.Equal("Talent", character.Talents.First().Name);
        _mockTalentSelector.Verify(x => x.ChooseTalent(It.IsAny<Character>()), Times.Never);
    }

    [Fact]
    public void AddTalent_ChooseTalentIsSymbiote_AddsExpectedTalentAndAddsTrait()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockTalentSelector.Setup(x => x.ChooseTalent(It.IsAny<Character>())).Returns(new Talent { Name = "Talent", Symbiote = true });

        character.AddTalent(_mockTalentSelector.Object);

        Assert.Single(character.Talents);
        Assert.Equal("Talent", character.Talents.First().Name);
        Assert.Single(character.Traits);
        Assert.Contains("Symbiote", character.Traits.First());
    }

    [Fact]
    public void AddTalent_ChooseTalentAddsFocus_AddsExpectedTalentAndAddsFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockTalentSelector.Setup(x => x.ChooseTalent(It.IsAny<Character>())).Returns(new Talent { Name = "Talent", GainRandomFocus = ["Focus"] });

        character.AddTalent(_mockTalentSelector.Object);

        Assert.Single(character.Talents);
        Assert.Equal("Talent", character.Talents.First().Name);
        Assert.Single(character.Focuses);
        Assert.Equal("Focus", character.Focuses.First());
    }

    [Fact]
    public void AddTalent_ChooseTalentChooseFocus_AddsExpectedTalentWithModifiedName()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Focuses.Add("Focus");

        _mockTalentSelector.Setup(x => x.ChooseTalent(It.IsAny<Character>())).Returns(new Talent { Name = "Talent", ChooseFocus = true });

        character.AddTalent(_mockTalentSelector.Object);

        Assert.Single(character.Talents);
        Assert.Equal("Talent (Focus)", character.Talents.First().Name);
    }

    [Fact]
    public void AddTraitsForCareerPath_CareerPathHasTrait_AddsExpectedTrait()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerPath = new CareerPath { Name = "Career", Trait = "Career Trait" };

        character.AddTraitsForCareerPath(careerPath);

        Assert.Single(character.Traits);
        Assert.Equal("Career Trait", character.Traits.First());
    }

    [Fact]
    public void AddTraitsForCareerPath_CareerPathHasRandomTraitAndChoosesFirst_AddsExpectedTrait()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerPath = new CareerPath { Name = "Career", RandomTrait = ["First", "Last"] };

        character.AddTraitsForCareerPath(careerPath, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Single(character.Traits);
        Assert.Equal("First", character.Traits.First());
    }

    [Fact]
    public void AddTraitsForCareerPath_CareerPathHasRandomTraitAndChoosesLast_AddsExpectedTrait()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerPath = new CareerPath { Name = "Career", RandomTrait = ["First", "Last"] };

        character.AddTraitsForCareerPath(careerPath, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Single(character.Traits);
        Assert.Equal("Last", character.Traits.First());
    }

    [Fact]
    public void AdjustAttributesForCareerPath_RaiseThreeRandomAttributesByOneAndFirstThreeChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustAttributesForCareerPath(mustSelectAttribute: null, new MockRandomGenerator([1, 2, 3, 4, 5, 6, 7]));

        Assert.Equal(8, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(8, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForCareerPath_RaiseThreeRandomAttributesByOneAndLastThreeChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustAttributesForCareerPath(mustSelectAttribute: null, new MockRandomGenerator([1, 6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(8, character.Attributes.Insight);
        Assert.Equal(8, character.Attributes.Presence);
        Assert.Equal(8, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForCareerPath_RaiseOneByTwoAndOneByOneAndFirstTwoChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustAttributesForCareerPath(mustSelectAttribute: null, new MockRandomGenerator([0, 2, 3, 4, 5, 6, 7]));

        Assert.Equal(9, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForCareerPath_RaiseOneByTwoAndOneByOneAndLastTwoChosen_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustAttributesForCareerPath(mustSelectAttribute: null, new MockRandomGenerator([0, 6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(8, character.Attributes.Presence);
        Assert.Equal(9, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForCareerPath_RaiseThreeRandomAttributesByOneAndFirstThreeChosenAndMustIncludeInsight_AddsExpectedAttributes()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustAttributesForCareerPath(mustSelectAttribute: AttributeName.Insight, new MockRandomGenerator([1, 2, 3, 4, 5, 6, 7]));

        Assert.Equal(8, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(8, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustDepartmentsForCareerPath_Add2ToASingleDepartmentAnd1ToAnotherTwoRandomlyWithFirstChosen_AddsExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerPath = new CareerPath { Name = "Career", DepartmentModifiers = new Departments { Command = 2 } };  

        character.AdjustDepartmentsForCareerPath(careerPath, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(3, character.Departments.Command);
        Assert.Equal(2, character.Departments.Conn);
        Assert.Equal(2, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForCareerPath_Add2ToASingleDepartmentAnd1ToAnotherTwoRandomlyWithLastChosen_AddsExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerPath = new CareerPath { Name = "Career", DepartmentModifiers = new Departments { Science = 2 } };

        character.AdjustDepartmentsForCareerPath(careerPath, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(2, character.Departments.Security);
        Assert.Equal(2, character.Departments.Medicine);
        Assert.Equal(3, character.Departments.Science);
    }

    [Fact]
    public void AddCareerEvent_RandomlySelectsFirstFocus_AddsCareerEventAndFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { Name = "Career Event", Focuses = ["Focus1", "Focus2"] };

        character.AddCareerEvent(careerEvent, _mockSpeciesSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Single(character.CareerEvents);
        Assert.Contains("Career Event", character.CareerEvents);
        Assert.Single(character.Focuses);
        Assert.Contains("Focus1", character.Focuses);
    }

    [Fact]
    public void AddCareerEvent_RandomlySelectsLastFocus_AddsCareerEventAndFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { Name = "Career Event", Focuses = ["Focus1", "Focus2"] };

        character.AddCareerEvent(careerEvent, _mockSpeciesSelector.Object, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Single(character.CareerEvents);
        Assert.Contains("Career Event", character.CareerEvents);
        Assert.Single(character.Focuses);
        Assert.Contains("Focus2", character.Focuses);
    }

    [Fact]
    public void AddCareerEvent_CareerEventIsLaudedByAnotherCulture_AddsSpeciesSpecificFocusAndTrait()
    {
        var character = new CharacterBuilder().AddBasicDetails().AddTrait("Test").Build();
        var careerEvent = new CareerEvent { Name = "Lauded by Another Culture" };

        _mockSpeciesSelector.Setup(s => s.GetAnotherRandomSpecies(It.IsAny<string>())).Returns(new Species { Name = "Other Species" });

        character.AddCareerEvent(careerEvent, _mockSpeciesSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Single(character.CareerEvents);
        Assert.Contains("Lauded by Another Culture", character.CareerEvents);
        Assert.Single(character.Focuses);
        Assert.Contains("Other Species Culture", character.Focuses);
        Assert.Contains("Friend to the Other Species", character.Traits);
    }

    [Fact]
    public void AddCareerEvent_GainsARandomTraitAndSelectsFirstTrait_AddsCareerEventAndFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { Name = "Career Event", Focuses = ["Focus1"], GainARandomTrait = ["Trait1", "Trait2"] };

        character.AddCareerEvent(careerEvent, _mockSpeciesSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Single(character.CareerEvents);
        Assert.Contains("Career Event", character.CareerEvents);
        Assert.Single(character.Focuses);
        Assert.Contains("Focus1", character.Focuses);
        Assert.Single(character.Traits);
        Assert.Contains("Trait1", character.Traits);
    }

    [Fact]
    public void AddCareerEvent_GainsARandomTraitAndSelectsLastTrait_AddsCareerEventAndFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { Name = "Career Event", Focuses = ["Focus1"], GainARandomTrait = ["Trait1", "Trait2"] };

        character.AddCareerEvent(careerEvent, _mockSpeciesSelector.Object, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Single(character.CareerEvents);
        Assert.Contains("Career Event", character.CareerEvents);
        Assert.Single(character.Focuses);
        Assert.Contains("Focus1", character.Focuses);
        Assert.Single(character.Traits);
        Assert.Contains("Trait2", character.Traits);
    }

    [Fact]
    public void AdjustAttributesForCareerEvent_GainsAnAttributeChoiceAndPicksFirst_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { AttributeModifierChoices = new CharacterAttributes { Fitness = 1, Insight = 1} };

        character.AdjustAttributesForCareerEvent(careerEvent, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(8, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForCareerEvent_GainsAnAttributeChoiceAndPicksLast_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { AttributeModifierChoices = new CharacterAttributes { Fitness = 1, Insight = 1 } };

        character.AdjustAttributesForCareerEvent(careerEvent, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(8, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForCareerEvent_AnyAttributeAndPicksFirst_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { AnyAttribute = true };

        character.AdjustAttributesForCareerEvent(careerEvent, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(8, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForCareerEvent_AnyAttributeAndPicksLast_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { AnyAttribute = true };

        character.AdjustAttributesForCareerEvent(careerEvent, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(8, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustDisciplinesForCareerEvent_AnyDepartmentAndPicksFirst_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { AnyDepartment= true };

        character.AdjustDisciplinesForCareerEvent(careerEvent, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(2, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDisciplinesForCareerEvent_AnyDepartmentAndPicksLast_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { AnyDepartment = true };

        character.AdjustDisciplinesForCareerEvent(careerEvent, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(2, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDisciplinesForCareerEvent_ChoiceOfTwoDepartmentsAndPicksFirst_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { DepartmentModifierChoices = new Departments { Engineering = 1, Security = 1 } };

        character.AdjustDisciplinesForCareerEvent(careerEvent, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(2, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDisciplinesForCareerEvent_ChoiceOfTwoDepartmentsAndPicksLast_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        var careerEvent = new CareerEvent { DepartmentModifierChoices = new Departments { Engineering = 1, Security = 1 } };

        character.AdjustDisciplinesForCareerEvent(careerEvent, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(2, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Theory]
    [InlineData(true, 11)]
    [InlineData(true, 12)]
    [InlineData(true, 13)]
    [InlineData(false, 12)]
    [InlineData(false, 13)]
    public void AdjustAttributesForFinishingTouches_IfControlOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Control = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustAttributesForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(11, character.Attributes.Control);
        else
            Assert.Equal(12, character.Attributes.Control);
    }

    [Theory]
    [InlineData(true, 11)]
    [InlineData(true, 12)]
    [InlineData(true, 13)]
    [InlineData(false, 12)]
    [InlineData(false, 13)]
    public void AdjustAttributesForFinishingTouches_IfDaringOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Daring = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustAttributesForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(11, character.Attributes.Daring);
        else
            Assert.Equal(12, character.Attributes.Daring);
    }

    [Theory]
    [InlineData(true, 11)]
    [InlineData(true, 12)]
    [InlineData(true, 13)]
    [InlineData(false, 12)]
    [InlineData(false, 13)]
    public void AdjustAttributesForFinishingTouches_IfFitnessOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustAttributesForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(11, character.Attributes.Fitness);
        else
            Assert.Equal(12, character.Attributes.Fitness);
    }

    [Theory]
    [InlineData(true, 11)]
    [InlineData(true, 12)]
    [InlineData(true, 13)]
    [InlineData(false, 12)]
    [InlineData(false, 13)]
    public void AdjustAttributesForFinishingTouches_IfInsightOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Insight = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustAttributesForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(11, character.Attributes.Insight);
        else
            Assert.Equal(12, character.Attributes.Insight);
    }

    [Theory]
    [InlineData(true, 11)]
    [InlineData(true, 12)]
    [InlineData(true, 13)]
    [InlineData(false, 12)]
    [InlineData(false, 13)]
    public void AdjustAttributesForFinishingTouches_IfPresenceOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Presence = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustAttributesForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(11, character.Attributes.Presence);
        else
            Assert.Equal(12, character.Attributes.Presence);
    }

    [Theory]
    [InlineData(true, 11)]
    [InlineData(true, 12)]
    [InlineData(true, 13)]
    [InlineData(false, 12)]
    [InlineData(false, 13)]
    public void AdjustAttributesForFinishingTouches_IfReasonOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Reason = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustAttributesForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(11, character.Attributes.Reason);
        else
            Assert.Equal(12, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForFinishingTouches_TwoRandomBoostsAndFirstChosen_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustAttributesForFinishingTouches(new MockRandomGenerator([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]));

        Assert.Equal(9, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForFinishingTouches_TwoRandomBoostsAndLastChosen_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustAttributesForFinishingTouches(new MockRandomGenerator([12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1]));

        Assert.Equal(7, character.Attributes.Control);
        Assert.Equal(7, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(9, character.Attributes.Reason);
    }

    [Fact]
    public void AdjustAttributesForFinishingTouches_TwoRandomBoostsButControlIsMaxedAndFirstChosen_IncreasesExpectedAttribute()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Control = 11;

        character.AdjustAttributesForFinishingTouches(new MockRandomGenerator([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]));

        Assert.Equal(12, character.Attributes.Control);
        Assert.Equal(8, character.Attributes.Daring);
        Assert.Equal(7, character.Attributes.Fitness);
        Assert.Equal(7, character.Attributes.Insight);
        Assert.Equal(7, character.Attributes.Presence);
        Assert.Equal(7, character.Attributes.Reason);
    }

    [Theory]
    [InlineData(true, 4)]
    [InlineData(true, 5)]
    [InlineData(true, 6)]
    [InlineData(false, 5)]
    [InlineData(false, 6)]
    public void AdjustDepartmentsForFinishingTouches_IfCommandOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Departments.Command = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustDepartmentsForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(4, character.Departments.Command);
        else
            Assert.Equal(5, character.Departments.Command);
    }

    [Theory]
    [InlineData(true, 4)]
    [InlineData(true, 5)]
    [InlineData(true, 6)]
    [InlineData(false, 5)]
    [InlineData(false, 6)]
    public void AdjustDepartmentsForFinishingTouches_IfConnOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Departments.Conn = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustDepartmentsForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(4, character.Departments.Conn);
        else
            Assert.Equal(5, character.Departments.Conn);
    }

    [Theory]
    [InlineData(true, 4)]
    [InlineData(true, 5)]
    [InlineData(true, 6)]
    [InlineData(false, 5)]
    [InlineData(false, 6)]
    public void AdjustDepartmentsForFinishingTouches_IfEngineeringOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Departments.Engineering = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustDepartmentsForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(4, character.Departments.Engineering);
        else
            Assert.Equal(5, character.Departments.Engineering);
    }

    [Theory]
    [InlineData(true, 4)]
    [InlineData(true, 5)]
    [InlineData(true, 6)]
    [InlineData(false, 5)]
    [InlineData(false, 6)]
    public void AdjustDepartmentsForFinishingTouches_IfSecurityOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Departments.Security = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustDepartmentsForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(4, character.Departments.Security);
        else
            Assert.Equal(5, character.Departments.Security);
    }

    [Theory]
    [InlineData(true, 4)]
    [InlineData(true, 5)]
    [InlineData(true, 6)]
    [InlineData(false, 5)]
    [InlineData(false, 6)]
    public void AdjustDepartmentsForFinishingTouches_IfScienceOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Departments.Science = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustDepartmentsForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(4, character.Departments.Science);
        else
            Assert.Equal(5, character.Departments.Science);
    }

    [Theory]
    [InlineData(true, 4)]
    [InlineData(true, 5)]
    [InlineData(true, 6)]
    [InlineData(false, 5)]
    [InlineData(false, 6)]
    public void AdjustDepartmentsForFinishingTouches_IfMedicineOverMaxValue_SetsToMaxValue(bool hasUntappedPotientialTalent, int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Departments.Medicine = value;

        if (hasUntappedPotientialTalent)
            character.Talents.Add(new Talent { Name = "Untapped Potential" });

        character.AdjustDepartmentsForFinishingTouches();

        if (hasUntappedPotientialTalent)
            Assert.Equal(4, character.Departments.Medicine);
        else
            Assert.Equal(5, character.Departments.Medicine);
    }

    [Fact]
    public void AdjustDepartmentsForFinishingTouches_TwoRandomBoostsAndFirstChosen_IncreasesExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustDepartmentsForFinishingTouches(new MockRandomGenerator([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]));

        Assert.Equal(3, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForFinishingTouches_TwoRandomBoostsButCommandIsMaxedAndFirstChosen_IncreasesExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Departments.Command = 4;

        character.AdjustDepartmentsForFinishingTouches(new MockRandomGenerator([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]));

        Assert.Equal(5, character.Departments.Command);
        Assert.Equal(2, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(1, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Fact]
    public void AdjustDepartmentsForFinishingTouches_TwoRandomBoostsAndLastChosen_IncreasesExpectedDepartment()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.AdjustDepartmentsForFinishingTouches(new MockRandomGenerator([12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1]));

        Assert.Equal(1, character.Departments.Command);
        Assert.Equal(1, character.Departments.Conn);
        Assert.Equal(1, character.Departments.Engineering);
        Assert.Equal(3, character.Departments.Security);
        Assert.Equal(1, character.Departments.Medicine);
        Assert.Equal(1, character.Departments.Science);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    public void SetStress_NormalStress_SetStressToFitness(int fitness)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = fitness;

        character.SetStress();

        Assert.Equal(character.Attributes.Fitness, character.Stress);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    public void SetStress_StressBasedOnControl_SetStressToControl(int control)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetSpeciesAbility(new SpeciesAbility { StressBasedOn = AttributeName.Control }).Build();
        character.Attributes.Control = control;

        character.SetStress();

        Assert.Equal(character.Attributes.Control, character.Stress);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    public void SetStress_StressBasedOnPresence_SetStressToPresence(int control)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetSpeciesAbility(new SpeciesAbility { StressBasedOn = AttributeName.Presence }).Build();
        character.Attributes.Presence = control;

        character.SetStress();

        Assert.Equal(character.Attributes.Presence, character.Stress);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    public void SetStress_StressBasedOnInsight_SetStressToInsight(int control)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetSpeciesAbility(new SpeciesAbility { StressBasedOn = AttributeName.Insight }).Build();
        character.Attributes.Insight = control;

        character.SetStress();

        Assert.Equal(character.Attributes.Insight, character.Stress);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    public void SetStress_StressBasedOnReason_SetStressToReason(int control)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetSpeciesAbility(new SpeciesAbility { StressBasedOn = AttributeName.Reason }).Build();
        character.Attributes.Reason = control;

        character.SetStress();

        Assert.Equal(character.Attributes.Reason, character.Stress);
    }

    [Theory]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    [InlineData(11)]
    [InlineData(12)]
    public void SetStress_StressBasedOnDaring_SetStressToDaring(int control)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetSpeciesAbility(new SpeciesAbility { StressBasedOn = AttributeName.Daring }).Build();
        character.Attributes.Daring = control;

        character.SetStress();

        Assert.Equal(character.Attributes.Daring, character.Stress);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetStress_TalentAddsCommandToStress_SetStressToFitnessPlusCommand(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = 7;
        character.Departments.Command = value;
        character.Talents.Add(new Talent { Name = "Calm Under Pressure", AddDepartmentToStress = DepartmentName.Command });

        character.SetStress();

        Assert.Equal(character.Attributes.Fitness + character.Departments.Command, character.Stress);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetStress_TalentAddsConnToStress_SetStressToFitnessPlusCommand(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = 7;
        character.Departments.Conn = value;
        character.Talents.Add(new Talent { Name = "Calm Under Pressure", AddDepartmentToStress = DepartmentName.Conn });

        character.SetStress();

        Assert.Equal(character.Attributes.Fitness + character.Departments.Conn, character.Stress);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetStress_TalentAddsSecurityToStress_SetStressToFitnessPlusSecurity(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = 7;
        character.Departments.Security = value;
        character.Talents.Add(new Talent { Name = "Calm Under Pressure", AddDepartmentToStress = DepartmentName.Security });

        character.SetStress();

        Assert.Equal(character.Attributes.Fitness + character.Departments.Security, character.Stress);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetStress_TalentAddScienceToStress_SetStressToFitnessPlusScience(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = 7;
        character.Departments.Science = value;
        character.Talents.Add(new Talent { Name = "Calm Under Pressure", AddDepartmentToStress = DepartmentName.Science });

        character.SetStress();

        Assert.Equal(character.Attributes.Fitness + character.Departments.Science, character.Stress);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetStress_TalentAddEngineeringToStress_SetStressToFitnessPlusEngineering(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = 7;
        character.Departments.Engineering = value;
        character.Talents.Add(new Talent { Name = "Calm Under Pressure", AddDepartmentToStress = DepartmentName.Engineering });

        character.SetStress();

        Assert.Equal(character.Attributes.Fitness + character.Departments.Engineering, character.Stress);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetStress_TalentAddMedicineToStress_SetStressToFitnessPlusMedicine(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = 7;
        character.Departments.Medicine = value;
        character.Talents.Add(new Talent { Name = "Calm Under Pressure", AddDepartmentToStress = DepartmentName.Medicine });

        character.SetStress();

        Assert.Equal(character.Attributes.Fitness + character.Departments.Medicine, character.Stress);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetStress_TalentAddModifierToStress_SetStressToFitnessPlusModifier(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Attributes.Fitness = 7;
        character.Talents.Add(new Talent { Name = "Calm Under Pressure", StressModifier = value});

        character.SetStress();

        Assert.Equal(character.Attributes.Fitness + value, character.Stress);
    }

    [Fact]
    public void SetProtection_Default_SetProtectionToZero()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        character.SetProtection();

        Assert.Equal(0, character.Protection);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetProtection_TalentAddModifierToProtection_SetProtectionToModifier(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();
        character.Talents.Add(new Talent { Name = "Test", ProtectionModifier = value });

        character.SetProtection();

        Assert.Equal(value, character.Protection);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    public void SetProtection_SpeciesAbilityAddsModifierToProtection_SetProtectionToModifier(int value)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetSpeciesAbility(new SpeciesAbility { ProtectionBonus = value }).Build();

        character.SetProtection();

        Assert.Equal(value, character.Protection);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 2)]
    [InlineData(5, 3)]
    public void SetProtection_TalentAndSpeciesModifierAddsToProtection_SetProtectionToTotal(int talentModifier, int speciesModifier)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetSpeciesAbility(new SpeciesAbility { ProtectionBonus = speciesModifier }).Build();
        character.Talents.Add(new Talent { Name = "Test", ProtectionModifier = talentModifier });

        character.SetProtection();

        Assert.Equal(talentModifier + speciesModifier, character.Protection);
    }

    [Fact]
    public void AddRole_NormalRole_SetsCharactersRole()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockRoleSelector.Setup(x => x.ChooseRole(It.IsAny<Character>())).Returns(new Role { Name = "Test Role" });

        character.AddRole(_mockRoleSelector.Object, _mockValueSelector.Object);

        Assert.Single(character.Roles);
        Assert.Equal("Test Role", character.Roles.First().Name);
    }

    [Fact]
    public void AddRole_RoleAddsFocusAndFirstSelected_AddsFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockRoleSelector.Setup(x => x.ChooseRole(It.IsAny<Character>())).Returns(
            new Role { Name = "Test Role", AdditionalFocuses = 1, AdditionalFocusesChoices = ["Focus1", "Focus2"] });

        character.AddRole(_mockRoleSelector.Object, _mockValueSelector.Object, new MockRandomGenerator([1, 2, 3, 4, 5, 6]));

        Assert.Single(character.Focuses);
        Assert.Equal("Focus1", character.Focuses.First());
    }

    [Fact]
    public void AddRole_RoleAddsFocusAndLastSelected_AddsFocus()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockRoleSelector.Setup(x => x.ChooseRole(It.IsAny<Character>())).Returns(
            new Role { Name = "Test Role", AdditionalFocuses = 1, AdditionalFocusesChoices = ["Focus1", "Focus2"] });

        character.AddRole(_mockRoleSelector.Object, _mockValueSelector.Object, new MockRandomGenerator([6, 5, 4, 3, 2, 1]));

        Assert.Single(character.Focuses);
        Assert.Equal("Focus2", character.Focuses.First());
    }

    [Fact]
    public void AddRole_RoleAddsValue_AddsValue()
    {
        var character = new CharacterBuilder().AddBasicDetails().Build();

        _mockRoleSelector.Setup(x => x.ChooseRole(It.IsAny<Character>())).Returns(new Role { Name = "Test Role", AdditionalValues = 1 });
        _mockValueSelector.Setup(x => x.ChooseValue(It.IsAny<Character>())).Returns("Value1");

        character.AddRole(_mockRoleSelector.Object, _mockValueSelector.Object);

        Assert.Single(character.Values);
        Assert.Equal("Value1", character.Values.First());
    }

    [Theory]
    [MemberData(nameof(GetStarfleetTracks))]
    public void IsStarfleet_ReturnsTrue_ForStarfleetTracks(string careerPath)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetCareerPath(careerPath).Build();
        Assert.True(character.IsStarfleet());
    }

    [Theory]
    [MemberData(nameof(GetNonStarfleetTracks))]
    public void IsStarfleet_ReturnsFalse_ForNonStarfleetTracks(string careerPath)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetCareerPath(careerPath).Build();
        Assert.False(character.IsStarfleet());
    }

    [Theory]
    [MemberData(nameof(GetEnlistedTracks))]
    public void IsEnlisted_ReturnsTrue_ForStarfleetTracks(string careerPath)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetCareerPath(careerPath).Build();
        Assert.True(character.IsEnlisted());
    }

    [Theory]
    [MemberData(nameof(GetNonEnlistedTracks))]
    public void IsEnlisted_ReturnsFalse_ForNonStarfleetTracks(string careerPath)
    {
        var character = new CharacterBuilder().AddBasicDetails().SetCareerPath(careerPath).Build();
        Assert.False(character.IsEnlisted());
    }

    [Theory]
    [MemberData(nameof(GetCommandingRanks))]
    public void IsCommandingOfficer_ReturnsTrue_ForCaptainRanks(string rank)
    {
        var character = new CharacterBuilder().AddValidDetails().SetRank(rank).Build();
        Assert.True(character.IsCommandingOfficer());
    }

    [Theory]
    [MemberData(nameof(GetNonCommandingRanks))]
    public void IsCommandingOfficer_ReturnsFalse_ForNonCommandRanks(string rank)
    {
        var character = new CharacterBuilder().AddValidDetails().SetRank(rank).Build();
        Assert.False(character.IsCommandingOfficer());
    }

    [Theory]
    [MemberData(nameof(GetFlagOfficerRanks))]
    public void IsFlagOfficer_ReturnsTrue_ForFlagRanks(string rank)
    {
        var character = new CharacterBuilder().AddValidDetails().SetRank(rank).Build();
        Assert.True(character.IsFlagOfficer());
    }

    [Theory]
    [MemberData(nameof(GetNonFlagOfficerRanks))]
    public void IsFlagOfficer_ReturnsFalse_ForNonFlagRanks(string rank)
    {
        var character = new CharacterBuilder().AddValidDetails().SetRank(rank).Build();
        Assert.False(character.IsFlagOfficer());
    }

    [Fact]
    public void HasPsychologyFocus_ReturnsTrue_IfFocusIsPsychology()
    {
        var character = new Character();
        character.Focuses.Add("Psychology");
        Assert.True(character.HasPsychologyFocus());
    }

    [Fact]
    public void HasPsychologyFocus_ReturnsFalse_IfNoPsychologyFocus()
    {
        var character = new Character();
        character.Focuses.Add("Astrophysics");
        Assert.False(character.HasPsychologyFocus());
    }

    [Fact]
    public void OrderLists_SortsValuesFocusesTalentsCareerEvents()
    {
        var character = new Character
        {
            Values = ["Zeta", "Alpha", "Gamma"],
            Focuses = ["Zeta", "Alpha", "Gamma"],
            Talents = [new Talent { Name = "Zeta" }, new Talent { Name = "Alpha" }, new Talent { Name = "Gamma" }],
            CareerEvents = ["Zeta", "Alpha", "Gamma"]
        };

        character.OrderLists();

        Assert.Equal(["Alpha", "Gamma", "Zeta"], character.Values);
        Assert.Equal(["Alpha", "Gamma", "Zeta"], character.Focuses);
        Assert.Equal(["Alpha", "Gamma", "Zeta"], character.Talents.Select(t => t.Name).ToList());
        Assert.Equal(["Alpha", "Gamma", "Zeta"], character.CareerEvents);
    }

    public static IEnumerable<object[]> GetStarfleetTracks()
    {
        return StarfleetTracks.Select(r => new object[] { r });
    }

    public static IEnumerable<object[]> GetNonStarfleetTracks()
    {
        return GetAllTrackNames()
            .Except(StarfleetTracks)
            .Select(r => new object[] { r });
    }

    public static IEnumerable<object[]> GetEnlistedTracks()
    {
        return EnlistedTracks.Select(r => new object[] { r });
    }

    public static IEnumerable<object[]> GetNonEnlistedTracks()
    {
        return GetAllTrackNames()
            .Except(EnlistedTracks)
            .Select(r => new object[] { r });
    }

    public static IEnumerable<object[]> GetCommandingRanks()
    {
        return CommandingRanks.Select(r => new object[] { r });
    }

    public static IEnumerable<object[]> GetNonCommandingRanks()
    {
        return GetAllRanks()
            .Except(CommandingRanks)
            .Select(r => new object[] { r });
    }

    public static IEnumerable<object[]> GetFlagOfficerRanks()
    {
        return FlagOfficerRanks.Select(r => new object[] { r });
    }

    public static IEnumerable<object[]> GetNonFlagOfficerRanks()
    {
        return GetAllRanks()
            .Except(FlagOfficerRanks)
            .Select(r => new object[] { r });
    }

    private static readonly HashSet<string> StarfleetTracks =
    [
        TrackName.StarfleetOfficerCommand,
        TrackName.StarfleetOfficerOperations,
        TrackName.StarfleetOfficerSciences,
        TrackName.StarfleetIntelligence
    ];

    private static readonly HashSet<string> EnlistedTracks =
    [
        TrackName.StarfleetEnlisted
    ];

    private static readonly HashSet<string> CommandingRanks =
    [
        Rank.Captain,
        Rank.FleetCaptain,
        Rank.Commodore,
        Rank.RearAdmiral,
        Rank.ViceAdmiral,
        Rank.Admiral,
        Rank.FleetAdmiral
    ];

    private static readonly HashSet<string> FlagOfficerRanks =
    [
        Rank.RearAdmiral,
        Rank.ViceAdmiral,
        Rank.Admiral,
        Rank.FleetAdmiral
    ];

    private static IEnumerable<string> GetAllRanks()
    {
        return typeof(Rank)
            .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy)
            .Where(static fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
            .Select(static fi => (string)fi.GetRawConstantValue());
    }

    private static IEnumerable<string> GetAllTrackNames()
    {
        return typeof(TrackName)
            .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.FlattenHierarchy)
            .Where(static fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
            .Select(static fi => (string)fi.GetRawConstantValue());
    }
}
