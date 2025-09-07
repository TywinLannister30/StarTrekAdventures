using StarTrekAdventures.Models.Version1;
using System.Linq;

namespace StarTrekAdventures.Helpers.Version1
{
    public static class CharacterSummaryHelper
    {
        public static CharacterSummary ToCharacterSummary(this Character character)
        {
            return new CharacterSummary
            {
                Role = character.Role,
                Rank = character.Rank,
                Name = character.Name,
                Gender = character.Gender,
                Traits = string.Join(", ", character.Traits),
                Values = character.Values,
                Attributes = character.Attributes,
                Disciplines = character.Disciplines,
                Focuses = string.Join(", ", character.Focuses),
                Talents = character.Talents != null ? string.Join(", ", character.Talents.Select(x => x.Name)) : "",
                BorgImplants = character.BorgImplants != null ? string.Join(", ", character.BorgImplants) : null,
                Stress = character.Stress,
                DamageBonus = character.DamageBonus,
                Species = character.Species,
                Environment = character.Environment,
                Track = character.Track,
                Career = character.Career,
                CareerEvents = string.Join(", ", character.CareerEvents)
            };
        }
    }
}
