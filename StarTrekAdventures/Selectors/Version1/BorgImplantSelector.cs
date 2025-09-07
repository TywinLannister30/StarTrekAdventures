using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class BorgImplantSelector
    {
        public static string ChooseBorgImplant(Character character)
        {
            var availableImplants = new List<string>();

            foreach (var implant in BorgImplants)
            {
                if (character.BorgImplants != null && !character.BorgImplants.Any(x => x == implant))
                    availableImplants.Add(implant);
            }

            return availableImplants.OrderBy(n => Util.GetRandom()).First();
        }

        private static readonly List<string> BorgImplants = new List<string>
        {
            "Adaptive Shielding",
            "Cardiopulmonary Strengthener",
            "Cortical Array (Bio-Synthetic Gland)",
            "Cortical Array (Cortical Node)",
            "Cortical Array (Interlink Node)",
            "Cortical Array (Neural Subspace Transceiver)",
            "Cybernetic Arm (Tactical)",
            "Cybernetic Arm (Medical)",
            "Cybernetic Arm (Engineering)",
            "Exo-Plating",
            "Ocular Sensory Enhancer",
        };
    }
}
