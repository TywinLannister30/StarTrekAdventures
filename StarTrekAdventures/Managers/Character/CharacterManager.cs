using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;
using System.Reflection;

namespace StarTrekAdventures.Managers;

public class CharacterManager : ICharacterManager
{
    public Character CreateCharacter(string species)
    {
        return GenerateCharacter(species);
    }

    private static Character GenerateCharacter(string species)
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

    private static Character PerformStepOne(Character character, string specificSpecies)
    {
        var chosenSpecies = SpeciesSelector.ChooseSpecies(specificSpecies);

        character.Species = chosenSpecies.ToSpeciesName();

        foreach (var species in chosenSpecies)
            character.Traits.Add(species.Name);

        character.AdjustAttributesForSpecies(chosenSpecies.First());
        character.AddSpeciesAbility(chosenSpecies.First().SpeciesAbility);

        if (Util.GetRandom(100) == 1)
            character.Traits.Add("Augment");

        if (Util.GetRandom(100) == 1)
            character.Traits.Add("Cyborg");

        return character;
    }

    private static Character PerformStepTwo(Character character)
    {
        var environment = EnvironmentSelector.ChooseEnvironment();

        character.Environment = environment.Name;

        character.AddValue();
        character.AdjustAttributesForEnvironment(environment);
        character.AdjustDepartmentsForEnvironment(environment);

        return character;
    }

    private static Character PerformStepThree(Character character)
    {
        var upbringing = UbringingSelector.ChooseUpringing();

        character.Upbringing = upbringing.Name;

        character.AdjustAttributesForUpbringing(upbringing);
        character.AdjustDepartmentsForUpbringing(upbringing);
        character.AddFocuses(upbringing.Focuses, 1);
        character.AddTalent();

        return character;
    }

    private static Character PerformStepFour(Character character)
    {
        var track = TrackSelector.ChooseTrack(character);

        character.ChosenTrack = track.Name;
        character.Track = track.GetName();

        character.AddValue();
        character.AddTraitsForTrack(track);
        character.AdjustAttributesForTrack();
        character.AdjustDisciplinesForTrack(track);
        character.AddFocuses(track.Focuses, 3);
        character.AddTalent();

        return character;
    }

    private static Character PerformStepFive(Character character)
    {
        var experience = ExperienceSelector.ChooseExperience(character);

        character.Experience = experience.Name;

        character.AddValue();
        character.AddTalent(experience.Talent);

        return character;
    }

    private static Character PerformStepSix(Character character)
    {
        var careerEvents = CareerEventSelector.ChooseCareerEvents();

        foreach (var careerEvent in careerEvents)
        {
            character.AddCareerEvent(careerEvent);
            character.AdjustAttributesForCareerEvent(careerEvent);
            character.AdjustDisciplinesForCareerEvent(careerEvent);
        }

        return character;
    }

    private static Character PerformStepSeven(Character character)
    {
        character.AddValue();
        character.AdjustAttributesForFinishingTouches();
        character.AdjustDepartmentsForFinishingTouches();

        character.Rank = RankSelector.ChooseRank(character);
        character.AddRole();

        character.AddTalent();

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
            character.AddRole();

        character.Gender = GenderHelper.GetGender(character).ToString();
        character.Name = NameGenerator.GenerateName(character);

        character.OrderLists();

        return character;
    }
}
