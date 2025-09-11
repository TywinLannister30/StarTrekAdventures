using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public static class ExperienceSelector
{
    public static Experience ChooseExperience(Character character)
    {
        var weightedCareersList = new WeightedList<Experience>();

        foreach (var experience in Experiences)
        {
            if ((experience.MaxAttribute != null && character.AllAttributesLessThanOrEqualTo(experience.MaxAttribute.Value) &&
                experience.MaxDepartment != null && character.AllDepartmentsLessThanOrEqualTo(experience.MaxDepartment.Value)) ||
                (experience.MaxAttribute == null && experience.MaxDepartment == null))
            {
                weightedCareersList.AddEntry(experience, experience.Weight);
            }
        }

        return weightedCareersList.GetRandom();
    }

    public static Experience GetExperience(string name)
    {
        return Experiences.First(x => x.Name == name);
    }

    private static readonly List<Experience> Experiences = new List<Experience>
    {
        new() { Name = ExperienceName.Novice, Talent = "Untapped Potential", MaxAttribute = 11, MaxDepartment = 4, Weight = 25 },
        new() { Name = ExperienceName.Experienced, AnyTalent = true, Weight = 50 },
        new() { Name = ExperienceName.Veteran, Talent = "Veteran", Weight = 25 }
    };
}
