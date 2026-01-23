using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Helpers;

public static class SpeciesHelper
{
    public static string ToSpeciesName (this List<Species> chosenSpecies)
    {
        if (chosenSpecies.First().Name == SpeciesName.CyberneticallyEnhanced)
            return $"{chosenSpecies.First().Name} {chosenSpecies.Last().Name}";

        if (chosenSpecies.First().Name == SpeciesName.LiberatedBorg)
            return $"{chosenSpecies.First().Name} ({chosenSpecies.Last().Name})";

        if (chosenSpecies.First().Name == SpeciesName.Hologram)
            return $"{chosenSpecies.First().Name} ({chosenSpecies.Last().Name})";

        var retVal = string.Join("-", chosenSpecies.Select(x => x.Name));

        if (chosenSpecies.Count > 1)
            retVal += " (mixed heritage)";


        return retVal;
    }
}
