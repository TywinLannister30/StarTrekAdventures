using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class StarshipManager : IStarshipManager
{
    public Starship CreateStarship(string spaceframe)
    {
        return GenerateStarship(spaceframe);
    }

    private static Starship GenerateStarship(string spaceframe)
    {
        var starship = new Starship();

        starship = PerformStepOne(starship, spaceframe);
        starship = PerformStepTwo(starship);
        starship = PerformStepThree(starship);
        starship = PerformStepFour(starship);
        starship = FinalDetails(starship);

        return starship;
    }

    private static Starship PerformStepOne(Starship starship, string spaceframe)
    {
        var chosenSpaceframe = SpaceframeSelector.ChooseSpaceframe(spaceframe);

        starship.SetSpaceframe(chosenSpaceframe);

        if (chosenSpaceframe.Talents != null)
        {
            foreach (var talent in chosenSpaceframe.Talents)
            {
                starship.AddTalent(StarshipTalentSelector.GetTalent(talent));
            }
        }

        if (chosenSpaceframe.ChooseOneTalent != null)
        {
            var talent = chosenSpaceframe.ChooseOneTalent.OrderBy(n => Util.GetRandom()).First();

            starship.AddTalent(StarshipTalentSelector.GetTalent(talent));
        }

        if (chosenSpaceframe.SpecialRules != null)
        {
            foreach (var specialRule in chosenSpaceframe.SpecialRules)
            {
                starship.AddSpecialRule(StarshipSpecialRuleSelector.GetSpecialRule(specialRule));
            }
        }

        if (starship.SpecialRules.Any(x => x.ChooseMissionPod))
        {
            var chosenMissionPod = MissionPodSelector.ChooseMissionPod();

            starship.AddMissionPodAttributes(chosenMissionPod);

            foreach(var talent in chosenMissionPod.Talents)
            {
                if (!starship.Talents.Any(x => x.Name == talent))
                    starship.AddTalent(StarshipTalentSelector.GetTalent(talent));
                else
                    starship.AddTalent(StarshipTalentSelector.ChooseTalent(starship));
            }

            if (chosenMissionPod.ChooseOneTalent != null)
            {
                var talents = chosenMissionPod.ChooseOneTalent.OrderBy(n => Util.GetRandom());

                foreach (var talent in talents)
                {
                    if (!starship.Talents.Any(x => x.Name == talent))
                    {
                        starship.AddTalent(StarshipTalentSelector.GetTalent(talent));
                        break;
                    }
                }
            }
        }

        foreach (var weapon in chosenSpaceframe.Weapons)
        {
            starship.Weapons.Add(StarshipWeaponSelector.GetWeapon(weapon));
        }

        if (chosenSpaceframe.GrapplerCableStrength > 0)
        {
            starship.Weapons.Add(new StarshipWeapon { Name = StarshipWeaponName.GrapplerCable, Damage = chosenSpaceframe.GrapplerCableStrength, IsTractorBeam = true });
        }

        if (chosenSpaceframe.TractorBeamStrength > 0)
        {
            starship.Weapons.Add(new StarshipWeapon { Name = StarshipWeaponName.TractorBeam, Damage = chosenSpaceframe.TractorBeamStrength, IsTractorBeam = true });
        }

        return starship;
    }

    private static Starship PerformStepTwo(Starship starship)
    {
        var chosenMissionProfile = MissionProfileSelector.ChooseMissionProfile(starship);

        starship.MissionProfile = chosenMissionProfile.Name;
        starship.SetMissionProfileSystems(chosenMissionProfile);
        starship.SetMissionProfileDepartments(chosenMissionProfile);
        starship.AddTalent(StarshipTalentSelector.GetTalentFromList(starship, chosenMissionProfile.TalentChoices));

        return starship;
    }

    private static Starship PerformStepThree(Starship starship)
    {
        var chosenServiceRecord = ServiceRecordSelector.ChooseServiceRecord();

        if (chosenServiceRecord != null)
        {
            starship.AddTrait(chosenServiceRecord.Name);
            starship.AddSpecialRule(StarshipSpecialRuleSelector.GetSpecialRule(chosenServiceRecord.SpecialRule));
        }

        return starship;
    }

    private static Starship PerformStepFour(Starship starship)
    {
        starship.PerformRefits();

        return starship;
    }

    private static Starship FinalDetails(Starship starship)
    {
        var talentsToSelect = starship.Scale - starship.Talents.Count;

        for (int i = 0; i < talentsToSelect; i++)
        {
            starship.AddTalent(StarshipTalentSelector.ChooseTalent(starship));
        }

        foreach (var talent in starship.Talents)
        {
            if (!string.IsNullOrEmpty(talent.TraitGained))
                starship.AddTrait(talent.TraitGained);
        }

        if (starship.Talents.Any(x => x.AddRandomWeapon))
            starship.AddRandomWeapon(); //TODO

        foreach (var weapon in starship.Weapons)
            weapon.SetEffect(starship);

        starship.SetResistance();
        starship.SetShields();
        starship.SetCrewSupport();
        starship.SetSmallCraftReadiness();

        return starship;
    }
}
