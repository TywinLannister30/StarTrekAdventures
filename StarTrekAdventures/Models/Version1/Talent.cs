namespace StarTrekAdventures.Models.Version1
{
    public class Talent
    {
        public string Name { get; set; }
        public string TraitRequirement { get; set; }
        public string FocusRequirement { get; set; }
        public string TalentRequirement { get; set; }
        public bool GMPermission { get; set; }
        public string MayNotTakeWithTalent { get; set; }
        public DisciplineRequirements DiscplineRequirements { get; set; }
        public CharacterAttributes AttributeRequirements { get; set; }
        public string TraitGained { get; set; }

        public int StressModifier { get; set; }
        public bool MixedHeritageAllowed { get; set; } = true;
        public bool Symbiote { get; set; }
        public bool MayBeSelected { get; set; } = true;
        public int AdditionalValues { get; set; }
        public bool BorgImplants { get; set; }

        public int Weight { get; set; }
    }
}
