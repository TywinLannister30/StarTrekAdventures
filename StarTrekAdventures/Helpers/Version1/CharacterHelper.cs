using StarTrekAdventures.Constants;
using StarTrekAdventures.Models.Version1;
using StarTrekAdventures.Selectors.Version1;
using System.Collections.Generic;
using System.Linq;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Helpers.Version1
{
    public static class CharacterHelper
    {
        public static Character AdjustAttributesForSpecies(this Character character, Species species)
        {
            character.Attributes.Control += species.AttributeModifiers.Control;
            character.Attributes.Daring += species.AttributeModifiers.Daring;
            character.Attributes.Fitness += species.AttributeModifiers.Fitness;
            character.Attributes.Insight += species.AttributeModifiers.Insight;
            character.Attributes.Presence += species.AttributeModifiers.Presence;
            character.Attributes.Reason += species.AttributeModifiers.Reason;

            if (species.ThreeRandomAttributes)
            {
                var attributes = typeof(CharacterAttributes).GetProperties();

                var picks = attributes.OrderBy(n => Util.GetRandom()).Take(3).ToList();

                if (picks.Any(x => x.Name == AttributeName.Control))
                    character.Attributes.Control++;

                if (picks.Any(x => x.Name == AttributeName.Daring))
                    character.Attributes.Daring++;

                if (picks.Any(x => x.Name == AttributeName.Fitness))
                    character.Attributes.Fitness++;

                if (picks.Any(x => x.Name == AttributeName.Insight))
                    character.Attributes.Insight++;

                if (picks.Any(x => x.Name == AttributeName.Presence))
                    character.Attributes.Presence++;

                if (picks.Any(x => x.Name == AttributeName.Reason))
                    character.Attributes.Reason++;
            }

            if (species.OneOfTheseModifiers != null)
            {
                var attributes = new List<string>();

                if (species.OneOfTheseModifiers.Control > 0)
                    attributes.Add(AttributeName.Control);

                if (species.OneOfTheseModifiers.Daring > 0)
                    attributes.Add(AttributeName.Daring);

                if (species.OneOfTheseModifiers.Fitness > 0)
                    attributes.Add(AttributeName.Fitness);

                if (species.OneOfTheseModifiers.Insight > 0)
                    attributes.Add(AttributeName.Insight);

                if (species.OneOfTheseModifiers.Presence > 0)
                    attributes.Add(AttributeName.Presence);

                if (species.OneOfTheseModifiers.Reason > 0)
                    attributes.Add(AttributeName.Reason);

                var pick = attributes.OrderBy(n => Util.GetRandom()).First();

                if (pick == AttributeName.Control) character.Attributes.Control++;
                if (pick == AttributeName.Daring) character.Attributes.Daring++;
                if (pick == AttributeName.Fitness) character.Attributes.Fitness++;
                if (pick == AttributeName.Insight) character.Attributes.Insight++;
                if (pick == AttributeName.Presence) character.Attributes.Presence++;
                if (pick == AttributeName.Reason) character.Attributes.Reason++;
            }

            return character;
        }

        public static Character AdjustAttributesForEnvironment(this Character character, Environment environment)
        {
            var choices = new List<string>();

            if (environment.AttributeChoices != null)
            {
                if (environment.AttributeChoices.Control > 0)
                    choices.Add(AttributeName.Control);

                if (environment.AttributeChoices.Daring > 0)
                    choices.Add(AttributeName.Daring);

                if (environment.AttributeChoices.Fitness > 0)
                    choices.Add(AttributeName.Fitness);

                if (environment.AttributeChoices.Insight > 0)
                    choices.Add(AttributeName.Insight);

                if (environment.AttributeChoices.Presence > 0)
                    choices.Add(AttributeName.Presence);

                if (environment.AttributeChoices.Reason > 0)
                    choices.Add(AttributeName.Reason);
            }
            else
            {
                Species species = new Species();

                if (environment.SpeciesAttributes)
                    species = SpeciesSelector.GetSpecies(character.Traits.First());
                else if (environment.AnotherSpeciesAttributes)
                {
                    species = SpeciesSelector.GetAnotherRandomSpecies(character.Traits.First());
                    character.Environment += $" ({species.Name})";
                }

                if (species.AttributeModifiers != null)
                {
                    if (species.AttributeModifiers.Control > 0)
                        choices.Add(AttributeName.Control);

                    if (species.AttributeModifiers.Daring > 0)
                        choices.Add(AttributeName.Daring);

                    if (species.AttributeModifiers.Fitness > 0)
                        choices.Add(AttributeName.Fitness);

                    if (species.AttributeModifiers.Insight > 0)
                        choices.Add(AttributeName.Insight);

                    if (species.AttributeModifiers.Presence > 0)
                        choices.Add(AttributeName.Presence);

                    if (species.AttributeModifiers.Reason > 0)
                        choices.Add(AttributeName.Reason);
                }

                if (species.ThreeRandomAttributes)
                {
                    if (character.Attributes.Control > 7)
                        choices.Add(AttributeName.Control);

                    if (character.Attributes.Daring > 7)
                        choices.Add(AttributeName.Daring);

                    if (character.Attributes.Fitness > 7)
                        choices.Add(AttributeName.Fitness);

                    if (character.Attributes.Insight > 7)
                        choices.Add(AttributeName.Insight);

                    if (character.Attributes.Presence > 7)
                        choices.Add(AttributeName.Presence);

                    if (character.Attributes.Reason > 7)
                        choices.Add(AttributeName.Reason);
                }
            }

            var choice = choices.OrderBy(n => Util.GetRandom()).First();

            if (choice == AttributeName.Control)
                character.Attributes.Control++;

            if (choice == AttributeName.Daring)
                character.Attributes.Daring++;

            if (choice == AttributeName.Fitness)
                character.Attributes.Fitness++;

            if (choice == AttributeName.Insight)
                character.Attributes.Insight++;

            if (choice == AttributeName.Presence)
                character.Attributes.Presence++;

            if (choice == AttributeName.Reason)
                character.Attributes.Reason++;

            return character;
        }

        public static Character AdjustDisciplinesForEnvironment(this Character character, Environment environment)
        {
            var choices = new List<string>();

            if (environment.DisciplineChoices != null)
            {
                if (environment.DisciplineChoices.Command > 0)
                    choices.Add(DisciplineName.Command);

                if (environment.DisciplineChoices.Conn > 0)
                    choices.Add(DisciplineName.Conn);

                if (environment.DisciplineChoices.Engineering > 0)
                    choices.Add(DisciplineName.Engineering);

                if (environment.DisciplineChoices.Medicine > 0)
                    choices.Add(DisciplineName.Medicine);

                if (environment.DisciplineChoices.Science > 0)
                    choices.Add(DisciplineName.Science);

                if (environment.DisciplineChoices.Security > 0)
                    choices.Add(DisciplineName.Security);
            }
            else if (environment.AnyDiscipline)
            {
                choices.Add(DisciplineName.Command);
                choices.Add(DisciplineName.Conn);
                choices.Add(DisciplineName.Engineering);
                choices.Add(DisciplineName.Medicine);
                choices.Add(DisciplineName.Science);
                choices.Add(DisciplineName.Security);
            }

            var choice = choices.OrderBy(n => Util.GetRandom()).First();

            if (choice == DisciplineName.Command)
                character.Disciplines.Command++;

            if (choice == DisciplineName.Conn)
                character.Disciplines.Conn++;

            if (choice == DisciplineName.Engineering)
                character.Disciplines.Engineering++;

            if (choice == DisciplineName.Medicine)
                character.Disciplines.Medicine++;

            if (choice == DisciplineName.Science)
                character.Disciplines.Science++;

            if (choice == DisciplineName.Security)
                character.Disciplines.Security++;

            return character;
        }

        public static Character AdjustAttributesForUpbringing(this Character character, Upbringing upbringing)
        {
            character.Attributes.Control += upbringing.Attributes.Control;
            character.Attributes.Daring += upbringing.Attributes.Daring;
            character.Attributes.Fitness += upbringing.Attributes.Fitness;
            character.Attributes.Insight += upbringing.Attributes.Insight;
            character.Attributes.Presence += upbringing.Attributes.Presence;
            character.Attributes.Reason += upbringing.Attributes.Reason;

            return character;
        }

        public static Character AdjustDisciplinesForUpbringing(this Character character, Upbringing upbringing)
        {
            var choices = new List<string>();

            if (upbringing.DisciplineChoices != null)
            {
                if (upbringing.DisciplineChoices.Command > 0)
                    choices.Add(DisciplineName.Command);

                if (upbringing.DisciplineChoices.Conn > 0)
                    choices.Add(DisciplineName.Conn);

                if (upbringing.DisciplineChoices.Engineering > 0)
                    choices.Add(DisciplineName.Engineering);

                if (upbringing.DisciplineChoices.Medicine > 0)
                    choices.Add(DisciplineName.Medicine);

                if (upbringing.DisciplineChoices.Science > 0)
                    choices.Add(DisciplineName.Science);

                if (upbringing.DisciplineChoices.Security > 0)
                    choices.Add(DisciplineName.Security);
            }
            else if (upbringing.AnyDiscipline)
            {
                choices.Add(DisciplineName.Command);
                choices.Add(DisciplineName.Conn);
                choices.Add(DisciplineName.Engineering);
                choices.Add(DisciplineName.Medicine);
                choices.Add(DisciplineName.Science);
                choices.Add(DisciplineName.Security);
            }

            var choice = choices.OrderBy(n => Util.GetRandom()).First();

            if (choice == DisciplineName.Command)
                character.Disciplines.Command++;

            if (choice == DisciplineName.Conn)
                character.Disciplines.Conn++;

            if (choice == DisciplineName.Engineering)
                character.Disciplines.Engineering++;

            if (choice == DisciplineName.Medicine)
                character.Disciplines.Medicine++;

            if (choice == DisciplineName.Science)
                character.Disciplines.Science++;

            if (choice == DisciplineName.Security)
                character.Disciplines.Security++;

            return character;
        }

        public static Character AdjustAttributesForTrack(this Character character)
        {
            var attributes = typeof(CharacterAttributes).GetProperties();

            var attributesToTaise = Util.GetRandom(2) + 2;

            var picks = attributes.OrderBy(n => Util.GetRandom()).Take(attributesToTaise).ToList();

            if (attributesToTaise == 2)
            {
                if (picks.First().Name == AttributeName.Control)
                    character.Attributes.Control += 2;

                if (picks.First().Name == AttributeName.Daring)
                    character.Attributes.Daring += 2;

                if (picks.First().Name == AttributeName.Fitness)
                    character.Attributes.Fitness += 2;

                if (picks.First().Name == AttributeName.Insight)
                    character.Attributes.Insight += 2;

                if (picks.First().Name == AttributeName.Presence)
                    character.Attributes.Presence += 2;

                if (picks.First().Name == AttributeName.Reason)
                    character.Attributes.Reason += 2;

                picks.RemoveAt(0);
            }

            if (picks.Any(x => x.Name == AttributeName.Control))
                character.Attributes.Control++;

            if (picks.Any(x => x.Name == AttributeName.Daring))
                character.Attributes.Daring++;

            if (picks.Any(x => x.Name == AttributeName.Fitness))
                character.Attributes.Fitness++;

            if (picks.Any(x => x.Name == AttributeName.Insight))
                character.Attributes.Insight++;

            if (picks.Any(x => x.Name == AttributeName.Presence))
                character.Attributes.Presence++;

            if (picks.Any(x => x.Name == AttributeName.Reason))
                character.Attributes.Reason++;

            return character;
        }

        public static Character AdjustDisciplinesForTrack(this Character character, Track track)
        {
            character.Disciplines.Command += track.DisciplineModifiers.Command;
            character.Disciplines.Conn += track.DisciplineModifiers.Conn;
            character.Disciplines.Engineering += track.DisciplineModifiers.Engineering;
            character.Disciplines.Medicine += track.DisciplineModifiers.Medicine;
            character.Disciplines.Science += track.DisciplineModifiers.Science;
            character.Disciplines.Security += track.DisciplineModifiers.Security;

            var displinesAvailable = new List<string>
            {
                DisciplineName.Command,
                DisciplineName.Conn,
                DisciplineName.Engineering,
                DisciplineName.Medicine,
                DisciplineName.Science,
                DisciplineName.Security
            };

            if (track.DisciplineModifiers.Command > 0)
                displinesAvailable.Remove(DisciplineName.Command);

            if (track.DisciplineModifiers.Conn > 0)
                displinesAvailable.Remove(DisciplineName.Conn);

            if (track.DisciplineModifiers.Engineering > 0)
                displinesAvailable.Remove(DisciplineName.Engineering);

            if (track.DisciplineModifiers.Medicine > 0)
                displinesAvailable.Remove(DisciplineName.Medicine);

            if (track.DisciplineModifiers.Science > 0)
                displinesAvailable.Remove(DisciplineName.Science);

            if (track.DisciplineModifiers.Security > 0)
                displinesAvailable.Remove(DisciplineName.Security);

            var choices = displinesAvailable.OrderBy(n => Util.GetRandom()).Take(2);

            foreach (var choice in choices)
            {
                if (choice == DisciplineName.Command)
                    character.Disciplines.Command++;

                if (choice == DisciplineName.Conn)
                    character.Disciplines.Conn++;

                if (choice == DisciplineName.Engineering)
                    character.Disciplines.Engineering++;

                if (choice == DisciplineName.Medicine)
                    character.Disciplines.Medicine++;

                if (choice == DisciplineName.Science)
                    character.Disciplines.Science++;

                if (choice == DisciplineName.Security)
                    character.Disciplines.Security++;
            }

            return character;
        }

        public static Character AdjustAttributesForCareerEvent(this Character character, CareerEvent careerEvent)
        {
            if (careerEvent.AnyAttribute)
            {
                var attributes = typeof(CharacterAttributes).GetProperties();

                var pick = attributes.OrderBy(n => Util.GetRandom()).First();

                if (pick.Name == AttributeName.Control)
                    character.Attributes.Control++;

                if (pick.Name == AttributeName.Daring)
                    character.Attributes.Daring++;

                if (pick.Name == AttributeName.Fitness)
                    character.Attributes.Fitness++;

                if (pick.Name == AttributeName.Insight)
                    character.Attributes.Insight++;

                if (pick.Name == AttributeName.Presence)
                    character.Attributes.Presence++;

                if (pick.Name == AttributeName.Reason)
                    character.Attributes.Reason++;
            }

            if (careerEvent.AttributeModifiers != null)
            {
                character.Attributes.Control += careerEvent.AttributeModifiers.Control;
                character.Attributes.Daring += careerEvent.AttributeModifiers.Daring;
                character.Attributes.Fitness += careerEvent.AttributeModifiers.Fitness;
                character.Attributes.Insight += careerEvent.AttributeModifiers.Insight;
                character.Attributes.Presence += careerEvent.AttributeModifiers.Presence;
                character.Attributes.Reason += careerEvent.AttributeModifiers.Reason;
            }

            return character;
        }

        public static Character AdjustDisciplinesForCareerEvent(this Character character, CareerEvent careerEvent)
        {
            if (careerEvent.AnyDiscipline)
            {
                var disciplines = typeof(CharacterDisciplines).GetProperties();

                var pick = disciplines.OrderBy(n => Util.GetRandom()).First();

                if (pick.Name == DisciplineName.Command)
                    character.Disciplines.Command++;

                if (pick.Name == DisciplineName.Conn)
                    character.Disciplines.Conn++;

                if (pick.Name == DisciplineName.Engineering)
                    character.Disciplines.Engineering++;

                if (pick.Name == DisciplineName.Medicine)
                    character.Disciplines.Medicine++;

                if (pick.Name == DisciplineName.Science)
                    character.Disciplines.Science++;

                if (pick.Name == DisciplineName.Security)
                    character.Disciplines.Security++;
            }

            if (careerEvent.DisciplineModifiers != null)
            {
                character.Disciplines.Command += careerEvent.DisciplineModifiers.Command;
                character.Disciplines.Conn += careerEvent.DisciplineModifiers.Conn;
                character.Disciplines.Engineering += careerEvent.DisciplineModifiers.Engineering;
                character.Disciplines.Medicine += careerEvent.DisciplineModifiers.Medicine;
                character.Disciplines.Science += careerEvent.DisciplineModifiers.Science;
                character.Disciplines.Security += careerEvent.DisciplineModifiers.Security;
            }

            return character;
        }

        public static Character AdjustAttributesForFinishingTouches(this Character character)
        {
            var maxValues = 12;
            var attributeBoosts = 2;

            if (character.Talents.Any(x => x.Name == "Untapped Potential"))
                maxValues = 11;

            if (character.Attributes.Control > maxValues)
            {
                attributeBoosts += character.Attributes.Control - maxValues;
                character.Attributes.Control = maxValues;
            }
            if (character.Attributes.Daring > maxValues)
            {
                attributeBoosts += character.Attributes.Daring - maxValues;
                character.Attributes.Daring = maxValues;
            }
            if (character.Attributes.Fitness > maxValues)
            {
                attributeBoosts += character.Attributes.Fitness - maxValues;
                character.Attributes.Fitness = maxValues;
            }
            if (character.Attributes.Insight > maxValues)
            {
                attributeBoosts += character.Attributes.Insight - maxValues;
                character.Attributes.Insight = maxValues;
            }
            if (character.Attributes.Presence > maxValues)
            {
                attributeBoosts += character.Attributes.Presence - maxValues;
                character.Attributes.Presence = maxValues;
            }
            if (character.Attributes.Reason > maxValues)
            {
                attributeBoosts += character.Attributes.Reason - maxValues;
                character.Attributes.Reason = maxValues;
            }

            for (var i = 0; i < attributeBoosts; i++)
            {
                var choices = new List<string>();

                if (character.Attributes.Control < maxValues)
                    choices.Add(AttributeName.Control);

                if (character.Attributes.Daring < maxValues)
                    choices.Add(AttributeName.Daring);

                if (character.Attributes.Fitness < maxValues)
                    choices.Add(AttributeName.Fitness);

                if (character.Attributes.Insight < maxValues)
                    choices.Add(AttributeName.Insight);

                if (character.Attributes.Presence < maxValues)
                    choices.Add(AttributeName.Presence);

                if (character.Attributes.Reason < maxValues)
                    choices.Add(AttributeName.Reason);

                var pick = choices.OrderBy(n => Util.GetRandom()).First();

                if (pick == AttributeName.Control)
                    character.Attributes.Control++;

                if (pick == AttributeName.Daring)
                    character.Attributes.Daring++;

                if (pick == AttributeName.Fitness)
                    character.Attributes.Fitness++;

                if (pick == AttributeName.Insight)
                    character.Attributes.Insight++;

                if (pick == AttributeName.Presence)
                    character.Attributes.Presence++;

                if (pick == AttributeName.Reason)
                    character.Attributes.Reason++;
            }

            return character;
        }

        public static Character AdjustDisciplinesForFinishingTouches(this Character character)
        {
            var maxValues = 5;
            var disciplineBoosts = 2;

            if (character.Talents.Any(x => x.Name == "Untapped Potential"))
                maxValues = 4;

            if (character.Disciplines.Command > maxValues)
            {
                disciplineBoosts += character.Disciplines.Command - maxValues;
                character.Disciplines.Command = maxValues;
            }
            if (character.Disciplines.Conn > maxValues)
            {
                disciplineBoosts += character.Disciplines.Conn - maxValues;
                character.Disciplines.Conn = maxValues;
            }
            if (character.Disciplines.Engineering > maxValues)
            {
                disciplineBoosts += character.Disciplines.Engineering - maxValues;
                character.Disciplines.Engineering = maxValues;
            }
            if (character.Disciplines.Medicine > maxValues)
            {
                disciplineBoosts += character.Disciplines.Medicine - maxValues;
                character.Disciplines.Medicine = maxValues;
            }
            if (character.Disciplines.Science > maxValues)
            {
                disciplineBoosts += character.Disciplines.Science - maxValues;
                character.Disciplines.Science = maxValues;
            }
            if (character.Disciplines.Security > maxValues)
            {
                disciplineBoosts += character.Disciplines.Security - maxValues;
                character.Disciplines.Security = maxValues;
            }

            for (var i = 0; i < disciplineBoosts; i++)
            {
                var choices = new List<string>();

                if (character.Disciplines.Command < maxValues)
                    choices.Add(DisciplineName.Command);

                if (character.Disciplines.Conn < maxValues)
                    choices.Add(DisciplineName.Conn);

                if (character.Disciplines.Engineering < maxValues)
                    choices.Add(DisciplineName.Engineering);

                if (character.Disciplines.Medicine < maxValues)
                    choices.Add(DisciplineName.Medicine);

                if (character.Disciplines.Science < maxValues)
                    choices.Add(DisciplineName.Science);

                if (character.Disciplines.Security < maxValues)
                    choices.Add(DisciplineName.Security);

                var pick = choices.OrderBy(n => Util.GetRandom()).First();

                if (pick == DisciplineName.Command)
                    character.Disciplines.Command++;

                if (pick == DisciplineName.Conn)
                    character.Disciplines.Conn++;

                if (pick == DisciplineName.Engineering)
                    character.Disciplines.Engineering++;

                if (pick == DisciplineName.Medicine)
                    character.Disciplines.Medicine++;

                if (pick == DisciplineName.Science)
                    character.Disciplines.Science++;

                if (pick == DisciplineName.Security)
                    character.Disciplines.Security++;
            }

            return character;
        }

        public static Character AddFocuses(this Character character, List<string> focusesAvailable, int numToChoose)
        {
            var choices = new List<string>();

            foreach (var focus in focusesAvailable)
            {
                if (!character.Focuses.Any(x => x == focus))
                    choices.Add(focus);
            }

            for (int i = 0; i < numToChoose; i++)
            {
                var focus = choices.OrderBy(n => Util.GetRandom()).First();

                character.Focuses.Add(focus);
                choices.Remove(focus);
            }

            return character;
        }

        public static Character AddCareerEvent(this Character character, CareerEvent careerEvent)
        {
            character.CareerEvents.Add(careerEvent.Name);

            if (careerEvent.Name == "Lauded by Another Culture")
            {
                var species = SpeciesSelector.GetAnotherRandomSpecies(character.Traits.First());

                character.Focuses.Add($"{species.Name} Culture");
                character.Traits.Add($"Friend to the {species.Name}");
            }
            else
            {
                character.AddFocuses(careerEvent.Focuses, 1);
            }

            return character;
        }

        public static Character AddCareerEventFocus(this Character character, CareerEvent careerEvent)
        {
            if (careerEvent.Name == "Lauded by Another Culture")
            {
                var species = SpeciesSelector.GetAnotherRandomSpecies(character.Traits.First());

                character.Focuses.Add($"{species.Name} Culture");
                character.Traits.Add($"Friend to the {species.Name}");
            }

            return character;
        }

        public static Character AddTalent(this Character character, LifepathStage lifepathStage, List<Species> species = null, Experience career = null)
        {
            var talent = TalentSelector.ChooseTalent(character, lifepathStage, species, career);
            character.Talents.Add(talent);

            if (character.Talents.Any(x => x.Symbiote))
            {
                var symbiote = NameGenerator.GetSymbioteName();
                character.Traits.Add($"{symbiote} Symbiote");
            }

            if (!string.IsNullOrEmpty(talent.TraitGained))
                character.Traits.Add(talent.TraitGained);

            for (int i = 0; i < talent.AdditionalValues; i++)
                character.AddValue();

            if (talent.BorgImplants)
            {
                character.BorgImplants = new List<string>();

                var numImplants = Util.GetRandom(3) + 1;

                for (int i = 0; i < numImplants; i++)
                {
                    character.BorgImplants.Add(BorgImplantSelector.ChooseBorgImplant(character));
                }
            }

            return character;
        }

        public static Character AddValue(this Character character)
        {
            character.Values.Add(ValueSelector.ChooseValue(character));

            return character;
        }
    }
}
