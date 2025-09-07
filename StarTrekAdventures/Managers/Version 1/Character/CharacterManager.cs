using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers.Version1;
using StarTrekAdventures.Models.Version1;
using StarTrekAdventures.Selectors.Version1;
using System.Linq;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Managers.Version1
{
    public class CharacterManager : ICharacterManager
    {
        public ActionResult<Character> CreateCharacter(string species)
        {
            return GenerateCharacter(species);
        }

        public ActionResult<CharacterSummary> CreateCharacterSummary(string species)
        {
            return GenerateCharacter(species).ToCharacterSummary();
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
            var chosenSpecies =  SpeciesSelector.ChooseSpecies(specificSpecies);

            character.Species = chosenSpecies.ToSpeciesName();

            foreach (var species in chosenSpecies)
                character.Traits.Add(species.Name);

            character.AdjustAttributesForSpecies(chosenSpecies.First());
            character.AddTalent(LifepathStage.Species, chosenSpecies);

            return character;
        }

        private Character PerformStepTwo(Character character)
        {
            var environment = EnvironmentSelector.ChooseEnvironment();

            character.Environment = environment.Name;

            character.AddValue();
            character.AdjustAttributesForEnvironment(environment);
            character.AdjustDisciplinesForEnvironment(environment);

            return character;
        }

        private Character PerformStepThree(Character character)
        {
            var upbringing = UbringingSelector.ChooseUpringing();

            character.Upbringing = upbringing.Name;

            character.AdjustAttributesForUpbringing(upbringing);
            character.AdjustDisciplinesForUpbringing(upbringing);
            character.AddFocuses(upbringing.Focuses, 1);
            character.AddTalent(LifepathStage.Upbringing, SpeciesSelector.ChooseSpecies(character.Traits.First()));

            return character;
        }

        private Character PerformStepFour(Character character)
        {
            var track = TrackSelector.ChooseTrack(character);

            character.Track = track.Name;

            character.AddValue();
            character.AdjustAttributesForTrack();
            character.AdjustDisciplinesForTrack(track);
            character.AddFocuses(track.Focuses, 3);
            character.AddTalent(LifepathStage.StarfleetAcademy);

            return character;
        }

        private Character PerformStepFive(Character character)
        {
            var career = ExperienceSelector.ChooseCareer();

            character.Career = career.Name;

            character.AddValue();
            character.AddTalent(LifepathStage.Career, career: career);

            return character;
        }

        private Character PerformStepSix(Character character)
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

        private Character PerformStepSeven(Character character)
        {
            character.AddValue();
            character.AdjustAttributesForFinishingTouches();
            character.AdjustDisciplinesForFinishingTouches();

            character.Stress = character.Attributes.Fitness + character.Disciplines.Security + character.Talents.Sum(x => x.StressModifier);
            character.DamageBonus = character.Disciplines.Security;

            character.Gender = GenderHelper.GetGender(character).ToString();
            character.Name = NameGenerator.GenerateName(character);
            character.Rank = RankSelector.ChooseRank(character);

            if (RankHelper.IsFlagOfficer(character))
                character.Traits.Add(Trait.FlagOfficer);

            character.Role = RoleSelector.ChooseRole(character);

            return character;
        }
    }
}
