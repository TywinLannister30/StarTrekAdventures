using NUnit.Framework;
using StarTrekAdventures.Constants;
using StarTrekAdventures.Selectors;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;
using StarTrekAdventures.Helpers;
using System.Linq;

namespace StarTrekAdventuresTest
{
    [TestFixture]
    public class LifePathStepOneTests
    {
        private Character _character;

        [SetUp]
        public void SetUp()
        {
            _character = new Character()
            { };
        }

        [Test]
        public void Test()
        {
            var species = SpeciesSelector.GetSpecies(SpeciesName.Betazoid);

            _character.Traits.Add(species.Name);
            _character.AdjustAttributesForSpecies(species);

            _character.Talents.Add(TalentSelector.ChooseTalent(_character, LifepathStage.Species, species));

            Assert.That(_character.Talents.Count == 1 && _character.Talents.All(x => x.Name == "Empath" || x.Name == "Telepathy"));
        }
    }
}
