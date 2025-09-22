using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Managers;

public class StarshipManager : IStarshipManager
{
    private readonly IMissionPodSelector _missionPodSelector;
    private readonly IMissionProfileSelector _missionProfileSelector;
    private readonly IServiceRecordSelector _serviceRecordSelector;
    private readonly ISpaceframeSelector _spaceframeSelector;
    private readonly IStarshipSpecialRuleSelector _starshipSpecialRuleSelector;
    private readonly IStarshipTalentSelector _starshipTalentSelector;
    private readonly IStarshipWeaponSelector _starshipWeaponSelector;

    public StarshipManager(
        IMissionPodSelector missionPodSelector, 
        IMissionProfileSelector missionProfileSelector, 
        IServiceRecordSelector serviceRecordSelector,
        ISpaceframeSelector spaceframeSelector,
        IStarshipSpecialRuleSelector starshipSpecialRuleSelector,
        IStarshipTalentSelector starshipTalentSelector,
        IStarshipWeaponSelector starshipWeaponSelector)
    {
        _missionPodSelector = missionPodSelector;
        _missionProfileSelector = missionProfileSelector;
        _serviceRecordSelector = serviceRecordSelector;
        _spaceframeSelector = spaceframeSelector;
        _starshipSpecialRuleSelector = starshipSpecialRuleSelector;
        _starshipTalentSelector = starshipTalentSelector;
        _starshipWeaponSelector = starshipWeaponSelector;
    }

    public Starship CreateStarship(string spaceframe)
    {
        return GenerateStarship(spaceframe);
    }

    private Starship GenerateStarship(string spaceframe)
    {
        var starship = new Starship();

        starship = PerformStepOne(starship, spaceframe);
        starship = PerformStepTwo(starship);
        starship = PerformStepThree(starship);
        starship = PerformStepFour(starship);
        starship = FinalDetails(starship);

        return starship;
    }

    private Starship PerformStepOne(Starship starship, string spaceframe)
    {
        var chosenSpaceframe = _spaceframeSelector.ChooseSpaceframe(spaceframe);

        starship.SetSpaceframe(chosenSpaceframe);

        if (chosenSpaceframe.Talents != null)
        {
            foreach (var talent in chosenSpaceframe.Talents)
            {
                starship.AddTalent(_starshipTalentSelector.GetTalent(talent));
            }
        }

        if (chosenSpaceframe.ChooseOneTalent != null)
        {
            var talent = chosenSpaceframe.ChooseOneTalent.OrderBy(n => Util.GetRandom()).First();

            starship.AddTalent(_starshipTalentSelector.GetTalent(talent));
        }

        if (chosenSpaceframe.SpecialRules != null)
        {
            foreach (var specialRule in chosenSpaceframe.SpecialRules)
            {
                starship.AddSpecialRule(_starshipSpecialRuleSelector.GetSpecialRule(specialRule));
            }
        }

        if (starship.SpecialRules.Any(x => x.ChooseMissionPod))
        {
            var chosenMissionPod = _missionPodSelector.ChooseMissionPod();

            starship.AddMissionPodAttributes(chosenMissionPod);

            foreach(var talent in chosenMissionPod.Talents)
            {
                if (!starship.Talents.Any(x => x.Name == talent))
                    starship.AddTalent(_starshipTalentSelector.GetTalent(talent));
                else
                    starship.AddTalent(_starshipTalentSelector.ChooseTalent(starship));
            }

            if (chosenMissionPod.ChooseOneTalent != null)
            {
                var talents = chosenMissionPod.ChooseOneTalent.OrderBy(n => Util.GetRandom());

                foreach (var talent in talents)
                {
                    if (!starship.Talents.Any(x => x.Name == talent))
                    {
                        starship.AddTalent(_starshipTalentSelector.GetTalent(talent));
                        break;
                    }
                }
            }
        }

        foreach (var weapon in chosenSpaceframe.Weapons)
        {
            starship.Weapons.Add(_starshipWeaponSelector.GetWeapon(weapon));
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

    private Starship PerformStepTwo(Starship starship)
    {
        var chosenMissionProfile = _missionProfileSelector.ChooseMissionProfile(starship);

        starship.MissionProfile = chosenMissionProfile.Name;
        starship.SetMissionProfileSystems(chosenMissionProfile);
        starship.SetMissionProfileDepartments(chosenMissionProfile);
        starship.AddTalent(_starshipTalentSelector.GetTalentFromList(starship, chosenMissionProfile.TalentChoices));

        return starship;
    }

    private Starship PerformStepThree(Starship starship)
    {
        var chosenServiceRecord = _serviceRecordSelector.ChooseServiceRecord();

        if (chosenServiceRecord != null)
        {
            starship.AddTrait(chosenServiceRecord.Name);
            starship.AddSpecialRule(_starshipSpecialRuleSelector.GetSpecialRule(chosenServiceRecord.SpecialRule));
        }

        return starship;
    }

    private Starship PerformStepFour(Starship starship)
    {
        starship.PerformRefits();

        return starship;
    }

    private Starship FinalDetails(Starship starship)
    {
        var talentsToSelect = starship.Scale - starship.Talents.Count;

        for (int i = 0; i < talentsToSelect; i++)
        {
            starship.AddTalent(_starshipTalentSelector.ChooseTalent(starship));
        }

        foreach (var talent in starship.Talents)
        {
            if (!string.IsNullOrEmpty(talent.TraitGained))
                starship.AddTrait(talent.TraitGained);
        }

        if (starship.Talents.Any(x => x.AddRandomWeapon))
            starship.AddWeapon(_starshipWeaponSelector.GetRandomWeapon(starship));

        if (starship.Talents.Any(x => x.AddRandomMine))
            starship.AddWeapon(_starshipWeaponSelector.GetRandomTypedWeapon(starship, StarshipWeaponType.Mine));

        foreach (var weapon in starship.Weapons)
            weapon.SetEffect(starship);

        starship.SetResistance();
        starship.SetShields();
        starship.SetCrewSupport();
        starship.SetSmallCraftReadiness();

        return starship;
    }
}
