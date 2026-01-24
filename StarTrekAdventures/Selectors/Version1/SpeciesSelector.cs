using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class SpeciesSelector
    {
        public static List<Species> ChooseSpecies(string specificSpecies)
        {
            var chosenSpecies = new List<Species>();

            var mixedHeritage = Util.GetRandom(100) == 1;
            var speciesChoices = 1;

            if (mixedHeritage)
                speciesChoices++;

            var weightedSpeciesList = new WeightedList<Species>();

            foreach (var species in Species)
                weightedSpeciesList.AddEntry(species, species.Weight);

            for (int i = 0; i < speciesChoices; i++)
            {
                if (i == 0 && !string.IsNullOrWhiteSpace(specificSpecies))
                {
                    chosenSpecies.Add(GetSpecies(specificSpecies));
                    continue;
                }

                var species = weightedSpeciesList.GetRandom();

                if (!chosenSpecies.Any(x => x.Name == species.Name))
                {
                    chosenSpecies.Add(species);
                }
            }

            if (chosenSpecies.First().SecondSpecies)
            {
                chosenSpecies.Add(GetAnotherRandomSpecies(SpeciesName.LiberatedBorg));
            }

            return chosenSpecies;
        }

        public static Species GetSpecies(string name)
        {
            return Species.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public static Species GetAnotherRandomSpecies(string name)
        {
            var availableSpecies = new List<Species>();

            foreach (var species in Species)
            {
                if (!species.NonMixed)
                    availableSpecies.Add(species);
            }

            availableSpecies.RemoveAll(x => x.Name == name);

            return availableSpecies.OrderBy(n => Util.GetRandom()).First();
        }

        public static List<Species> GetAllSpecies()
        {
            return Species;
        }

        private static readonly List<Species> Species = new List<Species>
        {
            new Species { Name = SpeciesName.Andorian, AttributeModifiers = new CharacterAttributes { Daring = 1, Control = 1, Presence = 1 }, Weight = 4 },
            new Species { Name = SpeciesName.Ankari, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Arbazan, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Ardanan, AttributeModifiers = new CharacterAttributes { Fitness = 1, Presence = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Argrathi, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Arkarian, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Reason = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Aurelian, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Bajoran, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Insight = 1 }, Weight = 4 },
            new Species { Name = SpeciesName.Barzan, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Benzite, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Reason = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Betazoid, AttributeModifiers = new CharacterAttributes { Insight = 1, Presence = 1, Reason = 1 }, MustTakeRacialTalentInStepOne = true, Weight = 8 },
            new Species { Name = SpeciesName.Bolian, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 4 },
            new Species { Name = SpeciesName.Caitian, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Cardassian, AttributeModifiers = new CharacterAttributes { Control = 1, Presence = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Changeling, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Presence = 1 }, MustTakeSpecificTalentInStepOne = "Morphogenic Matrix", Weight = 0 },
            new Species { Name = SpeciesName.CyberneticallyEnhanced, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, NonMixed = true, SecondSpecies = true, Weight = 1 },
            new Species { Name = SpeciesName.Deltan, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Denobulan, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 8 },
            new Species { Name = SpeciesName.Dosi, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Drai, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Edosian, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Reason = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Efrosian, AttributeModifiers = new CharacterAttributes { Fitness = 1, Presence = 1, Reason = 1 }, Weight = 4 },
            new Species { Name = SpeciesName.Ferengi, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 1 },
            new Species { Name = SpeciesName.Grazerite, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Haliian, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Presence = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Human, AttributeModifiers = new CharacterAttributes(), ThreeRandomAttributes = true, Weight = 20 },
            new Species { Name = SpeciesName.JemHadar, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Jye, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Karemma, AttributeModifiers = new CharacterAttributes { Control = 1, Reason = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Kelpien, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Insight = 1 }, Weight = 1 },
            new Species { Name = SpeciesName.Klingon, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 1 },
            new Species { Name = SpeciesName.Ktarian, AttributeModifiers = new CharacterAttributes { Control = 1, Reason = 1 }, OneOfTheseModifiers = new CharacterAttributes { Fitness = 1, Presence = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.LiberatedBorg, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Presence = 1 }, NonMixed = true, SecondSpecies = true, MustTakeSpecificTalentInStepOne = "Borg Implants", Weight = 1 },
            new Species { Name = SpeciesName.Lokirrim, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Lurian, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Mari, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, MustTakeSpecificTalentInStepOne = "Empath", Weight = 0 },
            new Species { Name = SpeciesName.Monean, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Ocampa, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Orion, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Osnullus, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Reason = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Paradan, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Pendari, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Rakhari, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Reman, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.RigellianChelon, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.RigellianJelna, AttributeModifiers = new CharacterAttributes { Fitness = 1, Presence = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Risian, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Romulan, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Saurian, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Reason = 1 }, Weight = 2, MustTakeSpecificTalentInStepOne = "Enhanced Metabolism" },
            new Species { Name = SpeciesName.Sikarian, AttributeModifiers = new CharacterAttributes { Control = 1, Reason = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Skreeaa, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Sona, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Insight = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.SoongTypeAndroid, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, NonMixed = true, MustTakeSpecificTalentInStepOne = "Polyalloy Construction", MustTakeAnotherSpecificTalentInStepOne = "Positronic Brain", Weight = 0 },
            new Species { Name = SpeciesName.Talaxian, AttributeModifiers = new CharacterAttributes { Control = 1, Presence = 1, Insight = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Tellarite, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Insight = 1 }, Weight = 8 },
            new Species { Name = SpeciesName.Tosk, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Fitness = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Trill, AttributeModifiers = new CharacterAttributes { Control = 1, Presence = 1, Reason = 1 }, Weight = 8 },
            new Species { Name = SpeciesName.Turei, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Vorta, AttributeModifiers = new CharacterAttributes { Insight = 1, Presence = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Xahean, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Reason = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.XindiArboreal, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Reason = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.XindiInsectoid, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Reason = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.XindiPrimate, AttributeModifiers = new CharacterAttributes { Daring = 1, Presence = 1, Reason = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.XindiReptilian, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Vulcan, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, Weight = 12 },
            new Species { Name = SpeciesName.Wadi, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Zahl, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 0 },
            new Species { Name = SpeciesName.Zakdorn, AttributeModifiers = new CharacterAttributes { Insight = 1, Presence = 1, Reason = 1 }, Weight = 2 },
            new Species { Name = SpeciesName.Zaranite, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, Weight = 2 }
        };
    }
}
