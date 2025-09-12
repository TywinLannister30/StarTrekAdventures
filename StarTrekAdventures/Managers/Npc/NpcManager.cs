using StarTrekAdventures.Models;
using StarTrekAdventures.Models.Version1;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class NpcManager : INpcManager
{
    public NonPlayerCharacter GenerateNpc(string name)
    {
        var baseNpc = NpcSelector.GetNonPlayerCharacter(name);

        var npc = new NonPlayerCharacter(baseNpc);

        if (baseNpc.RandomSpecies)
        {
            var oldTrait = baseNpc.Traits.Last();
            npc.Traits.Clear();

            var chosenSpecies = SpeciesSelector.ChooseSpecies(null);
            
            foreach (var species in chosenSpecies)
                npc.Traits.Add(species.Name);

            npc.Traits.Add(oldTrait);

            npc.AdjustAttributesForSpecies(chosenSpecies.First());
        }

        var specialRulesToRemove = new List<NpcSpecialRule>();

        foreach (var specialRule in npc.SpecialRules)
        {
            if (specialRule.AddOneToTwoDifferentDepartments)
            {
                npc.AddOneToTwoDifferentDepartments();
            }

            if (specialRule.HideIfGenerating)
            {
                specialRulesToRemove.Add(specialRule);
            }
        }

        foreach (var specialRule in specialRulesToRemove)
        {
            npc.SpecialRules.Remove(specialRule);
        }

        return npc;
    }

    public List<NonPlayerCharacter> GetAll()
    {
        return NpcSelector.GetAllNonPlayerCharacters();
    }

    public List<string> GetAllNames()
    {
        return NpcSelector.GetAllNonPlayerCharacters().Select(x => x.Name).ToList();
    }

    public NonPlayerCharacter Get(string name)
    {
        return NpcSelector.GetNonPlayerCharacter(name);
    }
}
