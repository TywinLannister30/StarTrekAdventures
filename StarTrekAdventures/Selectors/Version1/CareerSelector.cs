using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Selectors.Version1
{
    public static class ExperienceSelector
    {
        public static Experience ChooseCareer()
        {
            var weightedCareersList = new WeightedList<Experience>();

            foreach (var career in Careers)
            {
                weightedCareersList.AddEntry(career, career.Weight);
            }

            return weightedCareersList.GetRandom();
        }

        public static Experience GetCareer(string name)
        {
            return Careers.First(x => x.Name == name);
        }

        private static readonly List<Experience> Careers = new List<Experience>
        {
            new Experience { Name = CareerName.Young, Talent = "Untapped Potential", Weight = 5 },
            new Experience { Name = CareerName.Experienced, AnyTalent = true, Weight = 90 },
            new Experience { Name = CareerName.Veteran, Talent = "Veteran", Weight = 5 }
        };
    }
}
