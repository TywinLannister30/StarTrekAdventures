using System.Collections.Generic;

namespace StarTrekAdventures.Models
{
    public class Track
    {
        public string Name { get; set; }

        public string Major { get; set; }

        public string Trait { get; set; }

        public string MustSelectAttribute { get; set; }

        public List<string> RandomTrait { get; set; }

        public CharacterDepartments DepartmentModifiers { get; set; }

        public List<string> Focuses { get; set; }

        public int Weight { get; set; }

        internal string GetName()
        {
            if (string.IsNullOrEmpty(Major))
                return Name;

            return Name + " - " + Major;
        }
    }
}
