using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;
using Xunit;

namespace StarTrekAdventures.Tests.Selectors
{

    public class TalentSelectorTests
    {
        [Fact]
        public void GetTalent_ExistingTalent_ReturnsTalent()
        {
            // Arrange
            string talentName = "Back-up Plans";

            // Act
            var talent = TalentSelector.GetTalent(talentName);

            // Assert
            Assert.NotNull(talent);
            Assert.Equal(talentName, talent.Name);
            Assert.Equal(1, talent.Weight);
            Assert.NotNull(talent.Description);
        }

        [Fact]
        public void ChooseTalent_ValidCharacter_ReturnsTalent()
        {
            // Arrange
            var character = new Character
            {
                Attributes = new CharacterAttributes
                {
                    Control = 11,
                    Daring = 9,
                    Fitness = 10,
                    Insight = 9,
                    Presence = 8,
                    Reason = 9
                },
                Departments = new Departments
                {
                    Command = 4,
                    Conn = 3,
                    Engineering = 2,
                    Security = 2,
                    Science = 2,
                    Medicine = 2
                },
                Focuses = [],
                Roles = [],
                Talents = [],
                Traits = []
            };

            // Act
            var talent = TalentSelector.ChooseTalent(character);

            // Assert
            Assert.NotNull(talent);
            Assert.True(talent.Weight > 0);
        }

        [Fact]
        public void GetAllTalents_ReturnsNonEmptyList()
        {
            // Act
            var talents = TalentSelector.GetAllTalents();

            // Assert
            Assert.NotNull(talents);
            Assert.NotEmpty(talents);
        }
    }
}