using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
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

        if (baseNpc.RandomNonHumanSpecies)
        {
            var oldTrait = baseNpc.Traits.Last();
            npc.Traits.Clear();

            var chosenSpecies = SpeciesSelector.GetAnotherRandomSpecies(SpeciesName.Human);

            npc.Traits.Add(chosenSpecies.Name);

            npc.Traits.Add(oldTrait);

            npc.AdjustAttributesForSpecies(chosenSpecies);
        }

        if (npc.Name == "Academy Instructor")
        {
            npc.AdjustForAcademyTeacher();
        }

        var specialRulesToRemove = new List<NpcSpecialRule>();

        foreach (var specialRule in npc.SpecialRules)
        {
            if (specialRule.AddOneToTwoDifferentDepartments)
            {
                npc.AddOneToTwoDifferentDepartments();
            }

            if (specialRule.AddRandomFocus != null && specialRule.AddRandomFocus.Count > 0)
            {
                npc.AddFocuses(specialRule.AddRandomFocus, 1);
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

        npc.OrderLists();

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

    public List<NonPlayerCharacter> GetAllByTrait(string trait)
    {
        return NpcSelector.GetAllNonPlayerCharacters().Where(x => x.Traits.Any(t => t.Equals(trait, StringComparison.OrdinalIgnoreCase))).ToList();
    }
}
