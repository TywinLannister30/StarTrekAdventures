using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Models;

public class Species
{
    public Species()
    {
        Source = BookSource.Core;
    }

    public string Name { get; set; }

    public ICollection<string> Description { get; set; }

    public string ExampleCharacters { get; set; }

    public CharacterAttributes AttributeModifiers { get; set; }
    
    public bool ThreeRandomAttributes { get; set; }

    public string TraitDescription { get; set; }

    public SpeciesAbility SpeciesAbility { get; set; }

    public int Weight { get; set; }

    public CharacterAttributes OneOfTheseModifiers { get; set; }

    public bool HasGender { get; set; } = true;

    public bool HasSecondarySpeciesTrait{ get; set; } = false;

    public string Source { get; set; }
}
