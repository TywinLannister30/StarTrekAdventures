namespace StarTrekAdventures.Models
{
    public class Experience
    {
        public string Name { get; set; }

        public string Talent { get; set; }

        public bool AnyTalent { get; set; }

        public int? MaxAttribute { get; set; }

        public int? MaxDepartment{ get; set; }

        public int Weight { get; set; }
    }
}
