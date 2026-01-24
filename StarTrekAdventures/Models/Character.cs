using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using StarTrekAdventures.Selectors;
using System.Text.Json.Serialization;

namespace StarTrekAdventures.Models;

public class Character
{
    public Character()
    {
        Traits = new List<string>();
        Values = new List<string>();
        Focuses = new List<string>();
        Talents = new List<Talent>();
        CareerEvents = new List<string>();
        Roles = new List<Role>();

        Attributes = new CharacterAttributes
        {
            Control = 7,
            Daring = 7,
            Fitness = 7,
            Insight = 7,
            Presence = 7,
            Reason = 7
        };

        Departments = new Departments
        {
            Command = 1,
            Conn = 1,
            Engineering = 1,
            Security = 1,
            Science = 1,
            Medicine = 1
        };
    }

    public string Name { get; set; }
    public string Gender { get; set; }
    public string Rank { get; set; }
    public List<Role> Roles { get; set; }

    public string Species { get; set; }
    public string SecondarySpecies { get; set; }
    public SpeciesAbility SpeciesAbility { get; set; }
    public string Environment { get; set; }
    public string Upbringing { get; set; }

    [JsonIgnore]
    public string PrimarySpecies { get; set; }
    [JsonIgnore]
    public string ChosenTrack { get; set; }

    public string CareerPath { get; set; }

    public string Experience { get; set; }
    
    public List<string> CareerEvents { get; set; }

    public ICollection<string> Traits { get; set; }

    public ICollection<string> Values { get; set; }

    public CharacterAttributes Attributes { get; set; }

    public Departments Departments { get; set; }

    public int Stress { get; set; }

    public int Protection { get; set; }

    public ICollection<string> Focuses { get; set; }

    public string Pastime { get; set; }

    public ICollection<Talent> Talents { get; set; }

    public ICollection<string> BorgImplants { get; set; }

    public bool IsValid
    {
        get
        {
            var attributeSum = 0;
            attributeSum += Attributes.Control;
            attributeSum += Attributes.Daring;
            attributeSum += Attributes.Fitness;
            attributeSum += Attributes.Insight;
            attributeSum += Attributes.Presence;
            attributeSum += Attributes.Reason;

            if (attributeSum != 56)
            {
                ValidationIssue = $"Sum of attributes is {attributeSum}. It should be 56.";
                return false;
            }

            var departmentSum = 0;
            departmentSum += Departments.Command;
            departmentSum += Departments.Conn;
            departmentSum += Departments.Engineering;
            departmentSum += Departments.Medicine;
            departmentSum += Departments.Science;
            departmentSum += Departments.Security;

            if (departmentSum != 16)
            {
                ValidationIssue = $"Sum of departments is {departmentSum}. It should be 16.";
                return false;
            }

            if (Values.Count != 4 + Roles.Sum(x => x.AdditionalValues))
            {
                ValidationIssue = $"The character has {Values.Count} values. It should be {4 + Roles.Sum(x => x.AdditionalValues)}.";
                return false;
            }

            if (SpeciesAbility.AddAugmentTalents)
            {
                if (Talents.Count < 5 || Talents.Count > 6)
                {
                    ValidationIssue = $"The character has {Talents.Count} talents. It should be 5 or 6.";
                    return false;
                }
            }
            else if (SpeciesAbility.AddOneOfTheseTalents != null || !string.IsNullOrEmpty(SpeciesAbility.AddTalent))
            {
                if (Talents.Count != 5)
                {
                    ValidationIssue = $"The character has {Talents.Count} talents. It should be 5.";
                    return false;
                }
            }
            else
            {
                if (Talents.Count != 4)
                {
                    ValidationIssue = $"The character has {Talents.Count} talents. It should be 4.";
                    return false;
                }
            }

            if (Focuses.Count != 6 + SpeciesAbility.AdditionalFocuses + Roles.Sum(x => x.AdditionalFocuses) + Talents.Sum(x => x.AdditionalFocuses) + Talents.Where(x => x.GainRandomFocus != null).Count())
            {
                ValidationIssue = $"The character has {Focuses.Count} focuses. It should be {6 + SpeciesAbility.AdditionalFocuses + Roles.Sum(x => x.AdditionalFocuses) + Talents.Where(x => x.GainRandomFocus != null).Count()}.";
                return false;
            }

            return true;
        }
    }

    public string ValidationIssue { get; set; }

    public bool AllAttributesLessThanOrEqualTo(int value)
    {
        if (Attributes.Insight > value) return false;
        if (Attributes.Fitness > value) return false;
        if (Attributes.Presence > value) return false;
        if (Attributes.Reason > value) return false;
        if (Attributes.Control > value) return false;
        if (Attributes.Daring > value) return false;

        return true;
    }

    public bool AllDepartmentsLessThanOrEqualTo(int value)
    {
        if (Departments.Command > value) return false;
        if (Departments.Conn > value) return false;
        if (Departments.Engineering > value) return false;
        if (Departments.Security > value) return false;
        if (Departments.Science > value) return false;
        if (Departments.Medicine > value) return false;

        return true;
    }

    public void AdjustAttributesForSpecies(Species species, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        Attributes.Control += species.AttributeModifiers.Control;
        Attributes.Daring += species.AttributeModifiers.Daring;
        Attributes.Fitness += species.AttributeModifiers.Fitness;
        Attributes.Insight += species.AttributeModifiers.Insight;
        Attributes.Presence += species.AttributeModifiers.Presence;
        Attributes.Reason += species.AttributeModifiers.Reason;

        if (species.ThreeRandomAttributes)
        {
            var attributes = typeof(CharacterAttributes).GetProperties();

            var picks = attributes.OrderBy(n => randomGenerator.GetRandom()).Take(3).ToList();

            if (picks.Any(x => x.Name == AttributeName.Control)) Attributes.Control++;
            if (picks.Any(x => x.Name == AttributeName.Daring)) Attributes.Daring++;
            if (picks.Any(x => x.Name == AttributeName.Fitness)) Attributes.Fitness++;
            if (picks.Any(x => x.Name == AttributeName.Insight)) Attributes.Insight++;
            if (picks.Any(x => x.Name == AttributeName.Presence)) Attributes.Presence++;
            if (picks.Any(x => x.Name == AttributeName.Reason)) Attributes.Reason++;
        }

        if (species.OneOfTheseModifiers != null)
        {
            var attributes = new List<string>();

            if (species.OneOfTheseModifiers.Control > 0) attributes.Add(AttributeName.Control);
            if (species.OneOfTheseModifiers.Daring > 0) attributes.Add(AttributeName.Daring);
            if (species.OneOfTheseModifiers.Fitness > 0) attributes.Add(AttributeName.Fitness);
            if (species.OneOfTheseModifiers.Insight > 0) attributes.Add(AttributeName.Insight);
            if (species.OneOfTheseModifiers.Presence > 0) attributes.Add(AttributeName.Presence);
            if (species.OneOfTheseModifiers.Reason > 0) attributes.Add(AttributeName.Reason);

            var pick = attributes.OrderBy(n => randomGenerator.GetRandom()).First();

            if (pick == AttributeName.Control) Attributes.Control++;
            if (pick == AttributeName.Daring) Attributes.Daring++;
            if (pick == AttributeName.Fitness) Attributes.Fitness++;
            if (pick == AttributeName.Insight) Attributes.Insight++;
            if (pick == AttributeName.Presence) Attributes.Presence++;
            if (pick == AttributeName.Reason) Attributes.Reason++;
        }
    }

    public void AddSpeciesAbility(SpeciesAbility speciesAbility, ITalentSelector talentSelector, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        if (!string.IsNullOrEmpty(speciesAbility.AddTalent))
        {
            Talents.Add(talentSelector.GetTalent(speciesAbility.AddTalent));
        }

        if (speciesAbility.AddOneOfTheseTalents != null)
        {
            var pick = speciesAbility.AddOneOfTheseTalents.OrderBy(n => randomGenerator.GetRandom()).First();
            Talents.Add(talentSelector.GetTalent(pick));
        }

        SpeciesAbility = speciesAbility;
    }

    public void AddValue(IValueSelector valueSelector)
    {
        Values.Add(valueSelector.ChooseValue(this));
    }

    public void AdjustAttributesForEnvironment(CharacterEnvironment environment, ISpeciesSelector speciesSelector, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        var choices = new List<string>();

        if (environment.AttributeChoices != null)
        {
            if (environment.AttributeChoices.Control > 0) choices.Add(AttributeName.Control);
            if (environment.AttributeChoices.Daring > 0) choices.Add(AttributeName.Daring);
            if (environment.AttributeChoices.Fitness > 0) choices.Add(AttributeName.Fitness);
            if (environment.AttributeChoices.Insight > 0) choices.Add(AttributeName.Insight);
            if (environment.AttributeChoices.Presence > 0) choices.Add(AttributeName.Presence);
            if (environment.AttributeChoices.Reason > 0) choices.Add(AttributeName.Reason);
        }
        else
        {
            Species species = new();

            if (environment.SpeciesAttributes)
            {
                species = speciesSelector.GetSpecies(PrimarySpecies);
            }
            else if (environment.AnotherSpeciesAttributes)
            {
                species = speciesSelector.GetAnotherRandomSpecies(PrimarySpecies);
                Environment += $" ({species.Name})";
            }

            if (species.AttributeModifiers != null)
            {
                if (species.AttributeModifiers.Control > 0) choices.Add(AttributeName.Control);
                if (species.AttributeModifiers.Daring > 0) choices.Add(AttributeName.Daring);
                if (species.AttributeModifiers.Fitness > 0) choices.Add(AttributeName.Fitness);
                if (species.AttributeModifiers.Insight > 0) choices.Add(AttributeName.Insight);
                if (species.AttributeModifiers.Presence > 0) choices.Add(AttributeName.Presence);
                if (species.AttributeModifiers.Reason > 0) choices.Add(AttributeName.Reason);
            }

            if (species.ThreeRandomAttributes)
            {
                if (Attributes.Control > 7) choices.Add(AttributeName.Control);
                if (Attributes.Daring > 7) choices.Add(AttributeName.Daring);
                if (Attributes.Fitness > 7) choices.Add(AttributeName.Fitness);
                if (Attributes.Insight > 7) choices.Add(AttributeName.Insight);
                if (Attributes.Presence > 7) choices.Add(AttributeName.Presence);
                if (Attributes.Reason > 7) choices.Add(AttributeName.Reason);
            }
        }

        var choice = choices.OrderBy(n => randomGenerator.GetRandom()).First();

        if (choice == AttributeName.Control) Attributes.Control++;
        if (choice == AttributeName.Daring) Attributes.Daring++;
        if (choice == AttributeName.Fitness) Attributes.Fitness++;
        if (choice == AttributeName.Insight) Attributes.Insight++;
        if (choice == AttributeName.Presence) Attributes.Presence++;
        if (choice == AttributeName.Reason) Attributes.Reason++;
    }

    public void AdjustDepartmentsForEnvironment(CharacterEnvironment environment, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        var choices = new List<string>();

        if (environment.DepartmentChoices != null)
        {
            if (environment.DepartmentChoices.Command > 0) choices.Add(DepartmentName.Command);
            if (environment.DepartmentChoices.Conn > 0) choices.Add(DepartmentName.Conn);
            if (environment.DepartmentChoices.Engineering > 0) choices.Add(DepartmentName.Engineering);
            if (environment.DepartmentChoices.Medicine > 0) choices.Add(DepartmentName.Medicine);
            if (environment.DepartmentChoices.Science > 0) choices.Add(DepartmentName.Science);
            if (environment.DepartmentChoices.Security > 0) choices.Add(DepartmentName.Security);
        }
        else if (environment.AnyDepartment)
        {
            choices.Add(DepartmentName.Command);
            choices.Add(DepartmentName.Conn);
            choices.Add(DepartmentName.Engineering);
            choices.Add(DepartmentName.Medicine);
            choices.Add(DepartmentName.Science);
            choices.Add(DepartmentName.Security);
        }

        var choice = choices.OrderBy(n => randomGenerator.GetRandom()).First();

        if (choice == DepartmentName.Command) Departments.Command++;
        if (choice == DepartmentName.Conn) Departments.Conn++;
        if (choice == DepartmentName.Engineering) Departments.Engineering++;
        if (choice == DepartmentName.Medicine) Departments.Medicine++;
        if (choice == DepartmentName.Science) Departments.Science++;
        if (choice == DepartmentName.Security) Departments.Security++;
    }

    public void AdjustAttributesForUpbringing(Upbringing upbringing)
    {
        Attributes.Control += upbringing.Attributes.Control;
        Attributes.Daring += upbringing.Attributes.Daring;
        Attributes.Fitness += upbringing.Attributes.Fitness;
        Attributes.Insight += upbringing.Attributes.Insight;
        Attributes.Presence += upbringing.Attributes.Presence;
        Attributes.Reason += upbringing.Attributes.Reason;
    }

    public void AdjustDepartmentsForUpbringing(Upbringing upbringing, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        var choices = new List<string>();

        if (upbringing.DepartmentChoices != null)
        {
            if (upbringing.DepartmentChoices.Command > 0)  choices.Add(DepartmentName.Command);
            if (upbringing.DepartmentChoices.Conn > 0) choices.Add(DepartmentName.Conn);
            if (upbringing.DepartmentChoices.Engineering > 0) choices.Add(DepartmentName.Engineering);
            if (upbringing.DepartmentChoices.Medicine > 0) choices.Add(DepartmentName.Medicine);
            if (upbringing.DepartmentChoices.Science > 0) choices.Add(DepartmentName.Science);
            if (upbringing.DepartmentChoices.Security > 0) choices.Add(DepartmentName.Security);
        }
        else if (upbringing.AnyDepartment)
        {
            choices.Add(DepartmentName.Command);
            choices.Add(DepartmentName.Conn);
            choices.Add(DepartmentName.Engineering);
            choices.Add(DepartmentName.Medicine);
            choices.Add(DepartmentName.Science);
            choices.Add(DepartmentName.Security);
        }

        var choice = choices.OrderBy(n => randomGenerator.GetRandom()).First();

        if (choice == DepartmentName.Command) Departments.Command++;
        if (choice == DepartmentName.Conn) Departments.Conn++;
        if (choice == DepartmentName.Engineering) Departments.Engineering++;
        if (choice == DepartmentName.Medicine) Departments.Medicine++;
        if (choice == DepartmentName.Science) Departments.Science++;
        if (choice == DepartmentName.Security) Departments.Security++;
    }

    public void AdjustAttributesForHatchery(Hatchery hatchery, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        Attributes.Control += hatchery.Attributes.Control;
        Attributes.Daring += hatchery.Attributes.Daring;
        Attributes.Fitness += hatchery.Attributes.Fitness;
        Attributes.Insight += hatchery.Attributes.Insight;
        Attributes.Presence += hatchery.Attributes.Presence;
        Attributes.Reason += hatchery.Attributes.Reason;

        var choices = new List<string>();

        if (hatchery.Attributes.Control > 0) choices.Add(AttributeName.Control);
        if (hatchery.Attributes.Daring > 0) choices.Add(AttributeName.Daring);
        if (hatchery.Attributes.Fitness > 0) choices.Add(AttributeName.Fitness);
        if (hatchery.Attributes.Insight > 0) choices.Add(AttributeName.Insight);
        if (hatchery.Attributes.Presence > 0) choices.Add(AttributeName.Presence);
        if (hatchery.Attributes.Reason > 0) choices.Add(AttributeName.Reason);

        var choice = choices.OrderBy(n => randomGenerator.GetRandom()).First();

        if (choice == AttributeName.Control) Attributes.Control++;
        if (choice == AttributeName.Daring) Attributes.Daring++;
        if (choice == AttributeName.Fitness) Attributes.Fitness++;
        if (choice == AttributeName.Insight) Attributes.Insight++;
        if (choice == AttributeName.Presence) Attributes.Presence++;
        if (choice == AttributeName.Reason) Attributes.Reason++;
    }

    public void AdjustDepartmentsForHatchery(Hatchery hatchery, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        Departments.Command += hatchery.DepartmentModifiers.Command;
        Departments.Conn += hatchery.DepartmentModifiers.Conn;
        Departments.Engineering += hatchery.DepartmentModifiers.Engineering;
        Departments.Medicine += hatchery.DepartmentModifiers.Medicine;
        Departments.Science += hatchery.DepartmentModifiers.Science;
        Departments.Security += hatchery.DepartmentModifiers.Security;

        var departmentsAvailable = new List<string>
        {
            DepartmentName.Command,
            DepartmentName.Conn,
            DepartmentName.Engineering,
            DepartmentName.Medicine,
            DepartmentName.Science,
            DepartmentName.Security
        };

        if (hatchery.DepartmentModifiers.Command > 0) departmentsAvailable.Remove(DepartmentName.Command);
        if (hatchery.DepartmentModifiers.Conn > 0) departmentsAvailable.Remove(DepartmentName.Conn);
        if (hatchery.DepartmentModifiers.Engineering > 0) departmentsAvailable.Remove(DepartmentName.Engineering);
        if (hatchery.DepartmentModifiers.Medicine > 0) departmentsAvailable.Remove(DepartmentName.Medicine);
        if (hatchery.DepartmentModifiers.Science > 0) departmentsAvailable.Remove(DepartmentName.Science);
        if (hatchery.DepartmentModifiers.Security > 0) departmentsAvailable.Remove(DepartmentName.Security);

        var choice = departmentsAvailable.OrderBy(n => randomGenerator.GetRandom()).First();

        if (choice == DepartmentName.Command) Departments.Command++;
        if (choice == DepartmentName.Conn) Departments.Conn++;
        if (choice == DepartmentName.Engineering) Departments.Engineering++;
        if (choice == DepartmentName.Medicine) Departments.Medicine++;
        if (choice == DepartmentName.Science) Departments.Science++;
        if (choice == DepartmentName.Security) Departments.Security++;
    }

    public void AddFocuses(ICollection<string> focusesAvailable, int numToChoose, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        var choices = new List<string>();

        foreach (var focus in focusesAvailable)
        {
            if (!Focuses.Any(x => x == focus)) choices.Add(focus);
        }

        if (choices.Count == 0)
        {
            foreach (var focus in FocusHelper.GetAllFocuses())
            {
                if (!Focuses.Any(x => x == focus)) choices.Add(focus);
            }
        }

        for (int i = 0; i < numToChoose; i++)
        {
            var focus = choices.OrderBy(n => randomGenerator.GetRandom()).First();

            Focuses.Add(focus);
            choices.Remove(focus);
        }
    }

    public void AddFocus(string focus)
    {
        Focuses.Add(focus);
    }

    public void AddTalent(ITalentSelector talentSelector, string talentName = null, string traitName = null, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        Talent talent;

        if (!string.IsNullOrEmpty(talentName))
            talent = talentSelector.GetTalent(talentName);
        else if (!string.IsNullOrEmpty(talentName))
            talent = talentSelector.ChooseTalent(this, traitName);
        else
            talent = talentSelector.ChooseTalent(this);

        Talents.Add(talent);

        if (talent.Symbiote)
        {
            var symbiote = NameGenerator.GetSymbioteName();
            Traits.Add($"{symbiote} Symbiote");
        }

        if (talent.GainRandomFocus != null)
            AddFocuses(talent.GainRandomFocus, 1, randomGenerator);

        if (talent.ChooseFocus)
            talent.Name += " (" + Focuses.OrderBy(n => randomGenerator.GetRandom()).First() + ")";

        if (!string.IsNullOrEmpty(talent.TraitGained))
            Traits.Add(talent.TraitGained);

        if (talent.AdditionalFocuses > 0)
            AddFocuses(FocusHelper.GetAllFocuses(), talent.AdditionalFocuses, randomGenerator);
    }

    public void AddAugmentTalents(ITalentSelector talentSelector, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        AddTalent(talentSelector, traitName: TraitName.Augment);

        if (Util.GetRandom(100) < 50)
        {
            AddTalent(talentSelector, traitName: TraitName.Augment);

            var traitChoices = new List<string>
            {
                "Heightened Aggression",
                "Sensory Processing Disorder"
            };

            Traits.Add(traitChoices.OrderBy(n => randomGenerator.GetRandom()).First());
        }
    }

    public void AddTraitsForCareerPath(CareerPath track, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        if (!string.IsNullOrEmpty(track.Trait))
            Traits.Add(track.Trait);

        if (track.RandomTrait != null)
            Traits.Add(track.RandomTrait.OrderBy(n => randomGenerator.GetRandom()).First());
    }

    public void AdjustAttributesForCareerPath(string mustSelectAttribute = null, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        var attributes = typeof(CharacterAttributes).GetProperties();

        var attributesToRaise = randomGenerator.GetRandom(2) + 2;

        var picks = attributes.OrderBy(n => randomGenerator.GetRandom()).ToList();

        // If we have a must-select attribute, ensure it's included
        if (!string.IsNullOrWhiteSpace(mustSelectAttribute))
        {
            var mustPick = attributes.FirstOrDefault(x => x.Name == mustSelectAttribute);
            if (mustPick != null)
            {
                picks.Remove(mustPick);
                picks.Insert(0, mustPick); // put it first so it has a higher chance of getting +2 if only 2 attributes
            }
        }

        // Trim back down to the desired count
        picks = picks.Take(attributesToRaise).ToList();

        if (attributesToRaise == 2)
        {
            if (picks.First().Name == AttributeName.Control) Attributes.Control += 2;
            if (picks.First().Name == AttributeName.Daring) Attributes.Daring += 2;
            if (picks.First().Name == AttributeName.Fitness) Attributes.Fitness += 2;
            if (picks.First().Name == AttributeName.Insight) Attributes.Insight += 2;
            if (picks.First().Name == AttributeName.Presence) Attributes.Presence += 2;
            if (picks.First().Name == AttributeName.Reason) Attributes.Reason += 2;

            picks.RemoveAt(0);
        }

        if (picks.Any(x => x.Name == AttributeName.Control)) Attributes.Control++;
        if (picks.Any(x => x.Name == AttributeName.Daring)) Attributes.Daring++;
        if (picks.Any(x => x.Name == AttributeName.Fitness)) Attributes.Fitness++;
        if (picks.Any(x => x.Name == AttributeName.Insight)) Attributes.Insight++;
        if (picks.Any(x => x.Name == AttributeName.Presence)) Attributes.Presence++;
        if (picks.Any(x => x.Name == AttributeName.Reason)) Attributes.Reason++;
    }

    public void AdjustDepartmentsForCareerPath(CareerPath careerPath, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        Departments.Command += careerPath.DepartmentModifiers.Command;
        Departments.Conn += careerPath.DepartmentModifiers.Conn;
        Departments.Engineering += careerPath.DepartmentModifiers.Engineering;
        Departments.Medicine += careerPath.DepartmentModifiers.Medicine;
        Departments.Science += careerPath.DepartmentModifiers.Science;
        Departments.Security += careerPath.DepartmentModifiers.Security;

        var departmentsAvailable = new List<string>
        {
            DepartmentName.Command,
            DepartmentName.Conn,
            DepartmentName.Engineering,
            DepartmentName.Medicine,
            DepartmentName.Science,
            DepartmentName.Security
        };

        if (careerPath.DepartmentModifiers.Command > 0) departmentsAvailable.Remove(DepartmentName.Command);
        if (careerPath.DepartmentModifiers.Conn > 0) departmentsAvailable.Remove(DepartmentName.Conn);
        if (careerPath.DepartmentModifiers.Engineering > 0) departmentsAvailable.Remove(DepartmentName.Engineering);
        if (careerPath.DepartmentModifiers.Medicine > 0) departmentsAvailable.Remove(DepartmentName.Medicine);
        if (careerPath.DepartmentModifiers.Science > 0) departmentsAvailable.Remove(DepartmentName.Science);
        if (careerPath.DepartmentModifiers.Security > 0) departmentsAvailable.Remove(DepartmentName.Security);

        var choices = departmentsAvailable.OrderBy(n => randomGenerator.GetRandom()).Take(2);

        foreach (var choice in choices)
        {
            if (choice == DepartmentName.Command) Departments.Command++;
            if (choice == DepartmentName.Conn) Departments.Conn++;
            if (choice == DepartmentName.Engineering) Departments.Engineering++;
            if (choice == DepartmentName.Medicine) Departments.Medicine++;
            if (choice == DepartmentName.Science) Departments.Science++;
            if (choice == DepartmentName.Security) Departments.Security++;
        }
    }

    public void AddCareerEvent(CareerEvent careerEvent, ISpeciesSelector speciesSelector, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        CareerEvents.Add(careerEvent.Name);

        if (careerEvent.Name == "Lauded by Another Culture")
        {
            var species = speciesSelector.GetAnotherRandomSpecies(Traits.First());

            Focuses.Add($"{species.Name} Culture");
            Traits.Add($"Friend to the {species.Name}");
        }
        else
        {
            if (careerEvent.RandomFocus)
            {
                AddFocuses(FocusHelper.GetAllFocuses(), 1, randomGenerator);
            }
            else
            {
                AddFocuses(careerEvent.Focuses, 1, randomGenerator);

                if (careerEvent.GainARandomTrait != null)
                    Traits.Add(careerEvent.GainARandomTrait.OrderBy(n => randomGenerator.GetRandom()).First());
            }
        }
    }

    public void AdjustAttributesForCareerEvent(CareerEvent careerEvent, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        if (careerEvent.AnyAttribute)
        {
            var attributes = typeof(CharacterAttributes).GetProperties();

            var pick = attributes.OrderBy(n => randomGenerator.GetRandom()).First();

            if (pick.Name == AttributeName.Control) Attributes.Control++;
            if (pick.Name == AttributeName.Daring) Attributes.Daring++;
            if (pick.Name == AttributeName.Fitness) Attributes.Fitness++;
            if (pick.Name == AttributeName.Insight) Attributes.Insight++;
            if (pick.Name == AttributeName.Presence) Attributes.Presence++;
            if (pick.Name == AttributeName.Reason) Attributes.Reason++;
        }
        else
        {
            var choices = new List<string>();

            if (careerEvent.AttributeModifierChoices.Control > 0) choices.Add(AttributeName.Control);
            if (careerEvent.AttributeModifierChoices.Daring > 0) choices.Add(AttributeName.Daring);
            if (careerEvent.AttributeModifierChoices.Fitness > 0) choices.Add(AttributeName.Fitness);
            if (careerEvent.AttributeModifierChoices.Insight > 0) choices.Add(AttributeName.Insight);
            if (careerEvent.AttributeModifierChoices.Presence > 0) choices.Add(AttributeName.Presence);
            if (careerEvent.AttributeModifierChoices.Reason > 0) choices.Add(AttributeName.Reason);

            var pick = choices.OrderBy(n => randomGenerator.GetRandom()).First();

            if (pick == AttributeName.Control) Attributes.Control++;
            if (pick == AttributeName.Daring) Attributes.Daring++;
            if (pick == AttributeName.Fitness) Attributes.Fitness++;
            if (pick == AttributeName.Insight) Attributes.Insight++;
            if (pick == AttributeName.Presence) Attributes.Presence++;
            if (pick == AttributeName.Reason) Attributes.Reason++;
        }
    }

    public void AdjustDisciplinesForCareerEvent(CareerEvent careerEvent, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        if (careerEvent.AnyDepartment)
        {
            var departments = typeof(Departments).GetProperties();

            var pick = departments.OrderBy(n => randomGenerator.GetRandom()).First();

            if (pick.Name == DepartmentName.Command) Departments.Command++;
            if (pick.Name == DepartmentName.Conn) Departments.Conn++;
            if (pick.Name == DepartmentName.Engineering) Departments.Engineering++;
            if (pick.Name == DepartmentName.Medicine) Departments.Medicine++;
            if (pick.Name == DepartmentName.Science) Departments.Science++;
            if (pick.Name == DepartmentName.Security) Departments.Security++;
        }

        if (careerEvent.DepartmentModifierChoices != null)
        {
            var choices = new List<string>();

            if (careerEvent.DepartmentModifierChoices.Command > 0) choices.Add(DepartmentName.Command);
            if (careerEvent.DepartmentModifierChoices.Conn > 0) choices.Add(DepartmentName.Conn);
            if (careerEvent.DepartmentModifierChoices.Engineering > 0) choices.Add(DepartmentName.Engineering);
            if (careerEvent.DepartmentModifierChoices.Medicine > 0) choices.Add(DepartmentName.Medicine);
            if (careerEvent.DepartmentModifierChoices.Science > 0) choices.Add(DepartmentName.Science);
            if (careerEvent.DepartmentModifierChoices.Security > 0) choices.Add(DepartmentName.Security);

            var pick = choices.OrderBy(n => randomGenerator.GetRandom()).First();

            if (pick == DepartmentName.Command) Departments.Command++;
            if (pick == DepartmentName.Conn) Departments.Conn++;
            if (pick == DepartmentName.Engineering) Departments.Engineering++;
            if (pick == DepartmentName.Medicine) Departments.Medicine++;
            if (pick == DepartmentName.Science) Departments.Science++;
            if (pick == DepartmentName.Security) Departments.Security++;
        }
    }

    public void AdjustAttributesForFinishingTouches(IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        var maxValues = 12;
        var attributeBoosts = 2;

        if (Talents.Any(x => x.Name == TalentName.UntappedPotential))
            maxValues = 11;

        if (Attributes.Control > maxValues)
        {
            attributeBoosts += Attributes.Control - maxValues;
            Attributes.Control = maxValues;
        }
        if (Attributes.Daring > maxValues)
        {
            attributeBoosts += Attributes.Daring - maxValues;
            Attributes.Daring = maxValues;
        }
        if (Attributes.Fitness > maxValues)
        {
            attributeBoosts += Attributes.Fitness - maxValues;
            Attributes.Fitness = maxValues;
        }
        if (Attributes.Insight > maxValues)
        {
            attributeBoosts += Attributes.Insight - maxValues;
            Attributes.Insight = maxValues;
        }
        if (Attributes.Presence > maxValues)
        {
            attributeBoosts += Attributes.Presence - maxValues;
            Attributes.Presence = maxValues;
        }
        if (Attributes.Reason > maxValues)
        {
            attributeBoosts += Attributes.Reason - maxValues;
            Attributes.Reason = maxValues;
        }

        for (var i = 0; i < attributeBoosts; i++)
        {
            var choices = new List<string>();

            if (Attributes.Control < maxValues) choices.Add(AttributeName.Control);
            if (Attributes.Daring < maxValues) choices.Add(AttributeName.Daring);
            if (Attributes.Fitness < maxValues) choices.Add(AttributeName.Fitness);
            if (Attributes.Insight < maxValues) choices.Add(AttributeName.Insight);
            if (Attributes.Presence < maxValues) choices.Add(AttributeName.Presence);
            if (Attributes.Reason < maxValues) choices.Add(AttributeName.Reason);

            var pick = choices.OrderBy(n => randomGenerator.GetRandom()).First();

            if (pick == AttributeName.Control) Attributes.Control++;
            if (pick == AttributeName.Daring) Attributes.Daring++;
            if (pick == AttributeName.Fitness) Attributes.Fitness++;
            if (pick == AttributeName.Insight) Attributes.Insight++;
            if (pick == AttributeName.Presence) Attributes.Presence++;
            if (pick == AttributeName.Reason) Attributes.Reason++;
        }
    }

    public void AdjustDepartmentsForFinishingTouches(IRandomGenerator randomGenerator = null)
    {
        randomGenerator = randomGenerator ?? new RandomGenerator();

        var maxValues = 5;
        var departmentBoosts = 2;

        if (Talents.Any(x => x.Name == TalentName.UntappedPotential))
            maxValues = 4;

        if (Departments.Command > maxValues)
        {
            departmentBoosts += Departments.Command - maxValues;
            Departments.Command = maxValues;
        }
        if (Departments.Conn > maxValues)
        {
            departmentBoosts += Departments.Conn - maxValues;
            Departments.Conn = maxValues;
        }
        if (Departments.Engineering > maxValues)
        {
            departmentBoosts += Departments.Engineering - maxValues;
            Departments.Engineering = maxValues;
        }
        if (Departments.Medicine > maxValues)
        {
            departmentBoosts += Departments.Medicine - maxValues;
            Departments.Medicine = maxValues;
        }
        if (Departments.Science > maxValues)
        {
            departmentBoosts += Departments.Science - maxValues;
            Departments.Science = maxValues;
        }
        if (Departments.Security > maxValues)
        {
            departmentBoosts += Departments.Security - maxValues;
            Departments.Security = maxValues;
        }

        for (var i = 0; i < departmentBoosts; i++)
        {
            var choices = new List<string>();

            if (Departments.Command < maxValues) choices.Add(DepartmentName.Command);
            if (Departments.Conn < maxValues) choices.Add(DepartmentName.Conn);
            if (Departments.Engineering < maxValues) choices.Add(DepartmentName.Engineering);
            if (Departments.Medicine < maxValues) choices.Add(DepartmentName.Medicine);
            if (Departments.Science < maxValues) choices.Add(DepartmentName.Science);
            if (Departments.Security < maxValues) choices.Add(DepartmentName.Security);

            var pick = choices.OrderBy(n => randomGenerator.GetRandom()).First();

            if (pick == DepartmentName.Command) Departments.Command++;
            if (pick == DepartmentName.Conn) Departments.Conn++;
            if (pick == DepartmentName.Engineering) Departments.Engineering++;
            if (pick == DepartmentName.Medicine) Departments.Medicine++;
            if (pick == DepartmentName.Science) Departments.Science++;
            if (pick == DepartmentName.Security) Departments.Security++;
        }
    }

    public void SetStress()
    {
        if (SpeciesAbility.StressBasedOn == AttributeName.Control) Stress = Attributes.Control;
        if (SpeciesAbility.StressBasedOn == AttributeName.Daring) Stress = Attributes.Daring;
        if (SpeciesAbility.StressBasedOn == AttributeName.Fitness) Stress = Attributes.Fitness;
        if (SpeciesAbility.StressBasedOn == AttributeName.Insight) Stress = Attributes.Insight;
        if (SpeciesAbility.StressBasedOn == AttributeName.Presence) Stress = Attributes.Presence;
        if (SpeciesAbility.StressBasedOn == AttributeName.Reason) Stress = Attributes.Reason;

        foreach (var talent in Talents)
        {
            if (!string.IsNullOrEmpty(talent.AddDepartmentToStress))
            {
                if (talent.AddDepartmentToStress == DepartmentName.Command) Stress += Departments.Command;
                if (talent.AddDepartmentToStress == DepartmentName.Conn) Stress += Departments.Conn;
                if (talent.AddDepartmentToStress == DepartmentName.Engineering) Stress += Departments.Engineering;
                if (talent.AddDepartmentToStress == DepartmentName.Security) Stress += Departments.Security;
                if (talent.AddDepartmentToStress == DepartmentName.Science) Stress += Departments.Science;
                if (talent.AddDepartmentToStress == DepartmentName.Medicine) Stress += Departments.Medicine;
            }
        }

        Stress += Talents.Sum(x => x.StressModifier);
        Stress += SpeciesAbility.StressModifier;
    }

    public void SetProtection()
    {
        Protection = 0;

        Protection += Talents.Sum(x => x.ProtectionModifier);
        Protection += SpeciesAbility.ProtectionBonus;
    }

    public void AddRole(IRoleSelector roleSelector, IValueSelector valueSelector, List<string> rolesToChooseFrom = null, IRandomGenerator randomGenerator = null)
    {
        randomGenerator ??= new RandomGenerator();

        Role role = null;

        if (rolesToChooseFrom != null && rolesToChooseFrom.Count > 0)
        {
            var availableRoles = rolesToChooseFrom.Where(r => !Roles.Any(cr => cr.Name == r)).ToList();

            if (availableRoles.Count == 0)
                throw new Exception("No available roles to choose from.");

            var chosenRole = availableRoles.OrderBy(_ => Util.GetRandom()).First();

            role = roleSelector.GetRole(chosenRole);
        }
        else
        {
            role = roleSelector.ChooseRole(this);
        }
        
        Roles.Add(role);

        if (role.AdditionalFocuses > 0)
            AddFocuses(role.AdditionalFocusesChoices, role.AdditionalFocuses, randomGenerator);

        if (role.AdditionalValues > 0)
        {
            for (int i = 0; i < role.AdditionalValues; i++)
                AddValue(valueSelector);
        }
    }

    public bool IsStarfleet()
    {
        if (CareerPath.StartsWith(TrackName.StarfleetOfficerCommand) || 
            CareerPath.StartsWith(TrackName.StarfleetOfficerOperations) ||
            CareerPath.StartsWith(TrackName.StarfleetOfficerSciences) ||
            CareerPath.StartsWith(TrackName.StarfleetIntelligence))
        {
            return true;
        }

        return false;
    }

    public bool IsEnlisted()
    {
        return CareerPath.StartsWith(TrackName.StarfleetEnlisted);
    }

    public bool IsCommandingOfficer()
    {
        return (
            Rank == Constants.Rank.Captain ||
            Rank == Constants.Rank.FleetCaptain ||
            Rank == Constants.Rank.Commodore ||
            Rank == Constants.Rank.RearAdmiral ||
            Rank == Constants.Rank.ViceAdmiral ||
            Rank == Constants.Rank.Admiral ||
            Rank == Constants.Rank.FleetAdmiral
            );
    }

    public bool IsFlagOfficer()
    {
        return (
            Rank == Constants.Rank.RearAdmiral ||
            Rank == Constants.Rank.ViceAdmiral ||
            Rank == Constants.Rank.Admiral ||
            Rank == Constants.Rank.FleetAdmiral
            );
    }

    public bool HasPsychologyFocus()
    {
        foreach (var focus in Focuses)
        {
            if (FocusHelper.IsPsychologyFocus(focus)) return true;
        }

        return false;
    }

    public void OrderLists()
    {
        CareerEvents = CareerEvents.OrderBy(x => x).ToList();
        Values = Values.OrderBy(x => x).ToList();
        Focuses = Focuses.OrderBy(x => x).ToList();
        Talents = Talents.OrderBy(x => x.Name).ToList();
    }
}
