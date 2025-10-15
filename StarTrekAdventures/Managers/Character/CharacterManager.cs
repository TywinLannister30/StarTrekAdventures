using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;
using System.Reflection;

namespace StarTrekAdventures.Managers;

public class CharacterManager : ICharacterManager
{
    private readonly ICareerEventSelector _careerEventSelector;
    private readonly ICareerPathSelector _careerPathSelector;
    private readonly IEnvironmentSelector _environmentSelector;
    private readonly IExperienceSelector _experienceSelector;
    private readonly IRankSelector _rankSelector;
    private readonly IRoleSelector _roleSelector;
    private readonly ISpeciesSelector _speciesSelector;
    private readonly ITalentSelector _talentSelector;
    private readonly IUpbringingSelector _upbringSelector;
    private readonly IValueSelector _valueSelector;

    public CharacterManager(
        ICareerEventSelector careerEventSelector, 
        ICareerPathSelector careerPathSelector,
        IEnvironmentSelector environmentSelector,
        IExperienceSelector experienceSelector,
        IRankSelector rankSelector,
        IRoleSelector roleSelector, 
        ISpeciesSelector speciesSelector, 
        ITalentSelector talentSelector, 
        IUpbringingSelector upbringSelector,
        IValueSelector valueSelector)
    {
        _careerEventSelector = careerEventSelector;
        _careerPathSelector = careerPathSelector;
        _environmentSelector = environmentSelector;
        _experienceSelector = experienceSelector;
        _rankSelector = rankSelector;
        _roleSelector = roleSelector;
        _speciesSelector = speciesSelector;
        _talentSelector = talentSelector;
        _upbringSelector= upbringSelector;
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
        var environment = _environmentSelector.ChooseEnvironment();

        character.Environment = environment.Name;

        character.AddValue(_valueSelector);
        character.AdjustAttributesForEnvironment(environment, _speciesSelector);
        character.AdjustDepartmentsForEnvironment(environment);

        return character;
    }

    private Character PerformStepThree(Character character)
    {
        var upbringing = _upbringSelector.ChooseUpbringing();

        character.Upbringing = upbringing.Name;

        character.AdjustAttributesForUpbringing(upbringing);
        character.AdjustDepartmentsForUpbringing(upbringing);
        character.AddFocuses(upbringing.Focuses, 1);
        character.AddTalent(_talentSelector);

        return character;
    }

    private Character PerformStepFour(Character character)
    {
        var careerPath = _careerPathSelector.ChooseCareerPath(character);

        character.ChosenTrack = careerPath.Name;
        character.CareerPath = careerPath.GetName();

        character.AddValue(_valueSelector);
        character.AddTraitsForCareerPath(careerPath);
        character.AdjustAttributesForCareerPath();
        character.AdjustDepartmentsForCareerPath(careerPath);

        var focusesToChoose = 3;

        if (careerPath.MustTakeFocuses != null)
        {
            foreach (var focus in careerPath.MustTakeFocuses)
            {
                character.AddFocus(focus);
                focusesToChoose--;
            }
        }

        character.AddFocuses(careerPath.Focuses, focusesToChoose);
        character.AddTalent(_talentSelector);

        return character;
    }

    private Character PerformStepFive(Character character)
    {
        var experience = _experienceSelector.ChooseExperience(character);

        character.Experience = experience.Name;

        character.AddValue(_valueSelector);
        character.AddTalent(_talentSelector, experience.Talent);

        return character;
    }

    private Character PerformStepSix(Character character)
    {
        var careerEvents = _careerEventSelector.ChooseCareerEvents();

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

        character.Rank = _rankSelector.ChooseRank(character);
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
