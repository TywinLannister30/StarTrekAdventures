namespace StarTrekAdventures.Models.Version1
{
    public class Species
    {
        public string Name { get; set; }

        public CharacterAttributes AttributeModifiers { get; set; }

        public bool ThreeRandomAttributes { get; set; }

        public int Weight { get; set; }

        public bool MustTakeRacialTalentInStepOne { get; set; }

        public string MustTakeSpecificTalentInStepOne { get; set; }

        public string MustTakeAnotherSpecificTalentInStepOne { get; set; }

        public CharacterAttributes OneOfTheseModifiers { get; set; }

        public bool NonMixed { get; set; }

        public bool SecondSpecies { get; set; }
    }
}
