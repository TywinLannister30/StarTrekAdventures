using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;
using System.Reflection;

namespace StarTrekAdventures.Managers;

public class CharacterManager : ICharacterManager
{
    private readonly IRoleSelector _roleSelector;
    private readonly ISpeciesSelector _speciesSelector;
    private readonly ITalentSelector _talentSelector;
    private readonly IValueSelector _valueSelector;

    public CharacterManager(IRoleSelector roleSelector, ISpeciesSelector speciesSelector, ITalentSelector talentSelector, IValueSelector valueSelector)
    {
        _roleSelector = roleSelector;
        _speciesSelector = speciesSelector;
        _talentSelector = talentSelector;
        _valueSelector = valueSelector;
    }

    public Character CreateCharacter(string species)
    {
        return GenerateCharacter(species);
    }

    private Character GenerateCharacter(string species)
    {
        var character = new Character();

        character = PerformStepOne(character, species);
        character = PerformStepTwo(character);
        character = PerformStepThree(character);
        character = PerformStepFour(character);
        character = PerformStepFive(character);
        character = PerformStepSix(character);
        character = PerformStepSeven(character);

        return character;
    }

    private Character PerformStepOne(Character character, string specificSpecies)
    {
        var chosenSpecies = _speciesSelector.ChooseSpecies(specificSpecies);

        character.Species = chosenSpecies.ToSpeciesName();

        foreach (var species in chosenSpecies)
            character.Traits.Add(species.Name);

        character.AdjustAttributesForSpecies(chosenSpecies.First());
        character.AddSpeciesAbility(chosenSpecies.First().SpeciesAbility, _talentSelector);

        if (Util.GetRandom(100) == 1)
            character.Traits.Add("Augment");

        if (Util.GetRandom(100) == 1)
            character.Traits.Add("Cyborg");

        return character;
    }

    private Character PerformStepTwo(Character character)
    {
        var environment = EnvironmentSelector.ChooseEnvironment();

        character.Environment = environment.Name;

        character.AddValue(_valueSelector);
        character.AdjustAttributesForEnvironment(environment, _speciesSelector);
        character.AdjustDepartmentsForEnvironment(environment);

        return character;
    }

    private Character PerformStepThree(Character character)
    {
        var upbringing = UpbringingSelector.ChooseUpbringing();

        character.Upbringing = upbringing.Name;

        character.AdjustAttributesForUpbringing(upbringing);
        character.AdjustDepartmentsForUpbringing(upbringing);
        character.AddFocuses(upbringing.Focuses, 1);
        character.AddTalent(_talentSelector);

        return character;
    }

    private Character PerformStepFour(Character character)
    {
        var track = CareerPathSelector.ChooseCareerPath(character);

        character.ChosenTrack = track.Name;
        character.CareerPath = track.GetName();

        character.AddValue(_valueSelector);
        character.AddTraitsForCareerPath(track);
        character.AdjustAttributesForCareerPath();
        character.AdjustDepartmentsForCareerPath(track);
        character.AddFocuses(track.Focuses, 3);
        character.AddTalent(_talentSelector);

        return character;
    }

    private Character PerformStepFive(Character character)
    {
        var experience = ExperienceSelector.ChooseExperience(character);

        character.Experience = experience.Name;

        character.AddValue(_valueSelector);
        character.AddTalent(_talentSelector, experience.Talent);

        return character;
    }

    private Character PerformStepSix(Character character)
    {
        var careerEvents = CareerEventSelector.ChooseCareerEvents();

        foreach (var careerEvent in careerEvents)
        {
            character.AddCareerEvent(careerEvent, _speciesSelector);
            character.AdjustAttributesForCareerEvent(careerEvent);
            character.AdjustDisciplinesForCareerEvent(careerEvent);
        }

        return character;
    }

    private Character PerformStepSeven(Character character)
    {
        character.AddValue(_valueSelector);
        character.AdjustAttributesForFinishingTouches();
        character.AdjustDepartmentsForFinishingTouches();

        character.Rank = RankSelector.ChooseRank(character);
        character.AddRole(_roleSelector, _valueSelector);

        character.AddTalent(_talentSelector);

        character.SetStress();
        character.SetProtection();

        if (character.SpeciesAbility.AdditionalFocuses > 0)
        {
            var focuses = typeof(Focus)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(string))
                .Select(f => (string)f.GetValue(null))
                .ToList();

            character.AddFocuses(focuses, character.SpeciesAbility.AdditionalFocuses);
        }

        if (character.Talents.Any(x => x.ExtraRole))
            character.AddRole(_roleSelector, _valueSelector);

        character.Gender = GenderHelper.GetGender(character).ToString();
        character.Name = NameGenerator.GenerateName(character);

        character.OrderLists();

        return character;
    }
}
