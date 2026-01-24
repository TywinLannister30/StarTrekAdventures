using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class Species
{
    public Species()
    {
        Source = BookSource.Core;
        RandomSecondaryTrait = new List<string>();
        SpeciesAbilityBasedOnTrait = new List<(SpeciesAbility, string)>();
    }

    public string Name { get; set; }

    public ICollection<string> Description { get; set; }

    public string ExampleCharacters { get; set; }

    public CharacterAttributes AttributeModifiers { get; set; }
    
    public bool ThreeRandomAttributes { get; set; }

    public string TraitDescription { get; set; }

    public SpeciesAbility SpeciesAbility { get; set; }

    public List<(SpeciesAbility, string)> SpeciesAbilityBasedOnTrait { get; set; }

    public int Weight { get; set; }

    public CharacterAttributes OneOfTheseModifiers { get; set; }

    public bool HasGender { get; set; } = true;

    public bool HasSecondarySpeciesTrait{ get; set; } = false;

    public string SpecificSecondarySpeciesTrait { get; set; }

    public List<string> RandomSecondaryTrait { get; set; }

    public string Source { get; set; }
}
