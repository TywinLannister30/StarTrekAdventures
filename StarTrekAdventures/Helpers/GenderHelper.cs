using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Helpers;

public static class GenderHelper
{
    public static Gender GetGender(Character character, ISpeciesSelector speciesSelector)
    {
        var species = speciesSelector.GetSpecies(character.PrimarySpecies);

        if (!species.HasGender)
            return Gender.None;

        var randomNumber = Util.GetRandom(2) + 1;

        return (Gender)randomNumber;
    }
}
