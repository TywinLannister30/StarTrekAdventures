using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class NpcManager : INpcManager
{
    private readonly ICareerPathSelector _careerPathSelector;
    private readonly INpcSelector _npcSelector;
    private readonly ISpeciesSelector _speciesSelector;
    private readonly ITalentSelector _talentSelector;

    public NpcManager(ICareerPathSelector careerPathSelector, INpcSelector npcSelector, ISpeciesSelector speciesSelector, ITalentSelector talentSelector)
    {
        _careerPathSelector = careerPathSelector;
        _npcSelector = npcSelector;
        _speciesSelector = speciesSelector;
        _talentSelector = talentSelector;
    }

    public NonPlayerCharacter GenerateNpc(string name)
    {
        var baseNpc = _npcSelector.GetNonPlayerCharacter(name);

        var npc = new NonPlayerCharacter(baseNpc);

        if (baseNpc.RandomSpecies)
        {
            var oldTrait = baseNpc.Traits.Last();
            npc.Traits.Clear();

            var chosenSpecies = _speciesSelector.ChooseSpecies(null);
            
            foreach (var species in chosenSpecies)
                npc.Traits.Add(species.Name);

            npc.Traits.Add(oldTrait);

            npc.AdjustAttributesForSpecies(chosenSpecies.First());
        }

        if (baseNpc.RandomNonHumanSpecies)
        {
            var oldTrait = baseNpc.Traits.Last();
            npc.Traits.Clear();

            var chosenSpecies = _speciesSelector.GetAnotherRandomSpecies(SpeciesName.Human);

            npc.Traits.Add(chosenSpecies.Name);

            npc.Traits.Add(oldTrait);

            npc.AdjustAttributesForSpecies(chosenSpecies);
        }

        if (npc.Name == "Academy Instructor")
        {
            npc.AdjustForAcademyTeacher(_careerPathSelector, _talentSelector);
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
        return _npcSelector.GetAllNonPlayerCharacters();
    }

    public List<string> GetAllNames()
    {
        return _npcSelector.GetAllNonPlayerCharacters().Select(x => x.Name).ToList();
    }

    public NonPlayerCharacter Get(string name)
    {
        return _npcSelector.GetNonPlayerCharacter(name);
    }

    public List<NonPlayerCharacter> GetAllByTrait(string trait)
    {
        return _npcSelector.GetAllNonPlayerCharacters().Where(x => x.Traits.Any(t => t.Equals(trait, StringComparison.OrdinalIgnoreCase))).ToList();
    }
}
