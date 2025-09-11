using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public static class ServiceRecordSelector
{
    public static ServiceRecord ChooseServiceRecord()
    {
        var shouldTakeServiceRecord = Util.GetRandom(100) <= 75;

        if (shouldTakeServiceRecord)
            return ServiceRecords.OrderBy(n => Util.GetRandom()).First();

        return null;
    }

    private static readonly List<ServiceRecord> ServiceRecords = new()
    {
        new ServiceRecord
        {
            Name = "Aging Relic",
            Description = "The ship has been in service for decades, and has been home to many crews. Only the longest-serving crew are likely to remember when it was new.",
            SpecialRule = StarshipSpecialRuleName.LargerCrew,
        },
        new ServiceRecord
        {
            Name = "Anomoly Magnet",
            Description = "There are many strange things out in the depths of space, but some ships seem to encounter these bizarre phenomena more often than others. This ship has encountered more than its fair share of spatial anomalies, temporal paradoxes, interdimensional travel, and aliens claiming to be gods.",
            SpecialRule = StarshipSpecialRuleName.EncounterTheStrange,
        },
        new ServiceRecord
        {
            Name = "Brought out of Mothballs",
            Description = "The ship is old, and had been partly or fully decommissioned previously, sitting dormant for long stretches of time as part of the reserve fleet. These ships can be brought back into service quickly during times of emergency. This service record is intended to be used with a ship that is several decades old.",
            SpecialRule = StarshipSpecialRuleName.TheLastGeneration,
        },
        new ServiceRecord
        {
            Name = "Dependable Workhorse",
            Description = "The ship is dependable, with a solid record of successful missions and accomplishments. While overshadowed by more famous ships, this vessel is nevertheless a mainstay of the fleet, with a competent, dedicated crew.",
            SpecialRule = StarshipSpecialRuleName.Reliable,
        },
        new ServiceRecord
        {
            Name = "Legendary",
            Description = "This ship is famous, having been at the center of one or more major events that shaped the history and politics of one or more civilizations. This comes with great prestige for those involved.",
            SpecialRule = StarshipSpecialRuleName.PrestigiousPosting,
        },
        new ServiceRecord
        {
            Name = "Long-Term Mission",
            Description = "The ship has carried out one or more extended missions, spending years out on the frontier, with minimal support from command and minimal oversight. The crew needs to be resourceful and disciplined to thrive.",
            SpecialRule = StarshipSpecialRuleName.FarFromHome,
        },
        new ServiceRecord
        {
            Name = "Hope Ship",
            Description = "This vessel’s service has been spent responding to distress calls and disasters, warping to the rescue of those in danger or subjected to great hardship. The ship is heavily refitted for disaster relief, evacuation, and medical catastrophes, and the crew often have additional emergency medical training.",
            SpecialRule = StarshipSpecialRuleName.MissionOfMercy,
        },
        new ServiceRecord
        {
            Name = "Major Refit",
            Description = "The ship recently underwent extensive refits, essentially rebuilding the ship from the spaceframe up. It may as well be a brand-new ship.",
            SpecialRule = StarshipSpecialRuleName.UpgradedSystem,
        },
        new ServiceRecord
        {
            Name = "Prototype",
            Description = "The ship is brand new, first of her class, and laden with the newest technologies, assembled to be tested and studied. There are potentially a whole host of unknown problems and challenges to face, as novel systems clash or malfunction as they interact in unexpected ways.",
            SpecialRule = StarshipSpecialRuleName.ExperimentalVessel,
        },
        new ServiceRecord
        {
            Name = "State of the Art",
            Description = "The ship represents a combination of the best technologies available to its creators at the time. Rather than being a prototype, this is no testbed for experimental technology, but rather a step beyond that: advanced technology that has been tested and refined. This service record is intended to be used with a recently- launched ship of a new class.",
            SpecialRule = StarshipSpecialRuleName.PeakPerformance,
        },
        new ServiceRecord
        {
            Name = "Survivor of [Major Battle]",
            Description = "This ship was involved in some of the fiercest battles, surviving the fighting, though not without scars. The crew is battle-hardened and prepared for anything.",
            SpecialRule = StarshipSpecialRuleName.ReadyForBattle,
        },
        new ServiceRecord
        {
            Name = "Anomoly Magnet",
            Description = "There are many strange things out in the depths of space, but some ships seem to encounter these bizarre phenomena more often than others. This ship has encountered more than its fair share of spatial anomalies, temporal paradoxes, interdimensional travel, and aliens claiming to be gods.",
            SpecialRule = StarshipSpecialRuleName.EncounterTheStrange,
        },
        new ServiceRecord
        {
            Name = "Anomoly Magnet",
            Description = "There are many strange things out in the depths of space, but some ships seem to encounter these bizarre phenomena more often than others. This ship has encountered more than its fair share of spatial anomalies, temporal paradoxes, interdimensional travel, and aliens claiming to be gods.",
            SpecialRule = StarshipSpecialRuleName.EncounterTheStrange,
        },
        new ServiceRecord
        {
            Name = "Anomoly Magnet",
            Description = "There are many strange things out in the depths of space, but some ships seem to encounter these bizarre phenomena more often than others. This ship has encountered more than its fair share of spatial anomalies, temporal paradoxes, interdimensional travel, and aliens claiming to be gods.",
            SpecialRule = StarshipSpecialRuleName.EncounterTheStrange,
        },
        new ServiceRecord
        {
            Name = "Anomoly Magnet",
            Description = "There are many strange things out in the depths of space, but some ships seem to encounter these bizarre phenomena more often than others. This ship has encountered more than its fair share of spatial anomalies, temporal paradoxes, interdimensional travel, and aliens claiming to be gods.",
            SpecialRule = StarshipSpecialRuleName.EncounterTheStrange,
        },
        new ServiceRecord
        {
            Name = "Anomoly Magnet",
            Description = "There are many strange things out in the depths of space, but some ships seem to encounter these bizarre phenomena more often than others. This ship has encountered more than its fair share of spatial anomalies, temporal paradoxes, interdimensional travel, and aliens claiming to be gods.",
            SpecialRule = StarshipSpecialRuleName.EncounterTheStrange,
        },
        new ServiceRecord
        {
            Name = "Anomoly Magnet",
            Description = "There are many strange things out in the depths of space, but some ships seem to encounter these bizarre phenomena more often than others. This ship has encountered more than its fair share of spatial anomalies, temporal paradoxes, interdimensional travel, and aliens claiming to be gods.",
            SpecialRule = StarshipSpecialRuleName.EncounterTheStrange,
        },
    };
}
