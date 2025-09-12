using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;
using StarTrekAdventures.Models.Version1;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public class StarshipTalentSelector
{
    public static StarshipTalent ChooseTalent(Starship starship)
    {
        var weightedTalentsList = new WeightedList<StarshipTalent>();

        foreach (var talent in StarshipTalents)
        {
            if (CanTakeTalent(starship, talent))
                weightedTalentsList.AddEntry(talent, 1);
        }

        return weightedTalentsList.GetRandom();
    }

    private static bool CanTakeTalent(Starship starship, StarshipTalent talent)
    {
        var gmPermission = Util.GetRandom(100) == 1;

        if (starship.Talents.Any(x => x.Name == talent.Name))
            return false;

        if (starship.ServiceYear <= talent.MinimumServiceYear)
            return false;

        if (talent.MaximumServiceYear != 0 && starship.ServiceYear > talent.MaximumServiceYear)
            return false;

        if (talent.GMPermission && !gmPermission)
            return false;

        if (talent.RequiresMines && !starship.HasMines())
            return false;

        if (talent.RequiresTractorBeam && !starship.HasTractorBeam())
            return false;

        if (starship.Scale <= talent.ScaleRequirement)
            return false;

        if (talent.DepartmentRequirements != null)
        {
            if (talent.DepartmentRequirements.Operator == Operator.None || talent.DepartmentRequirements.Operator == Operator.And)
            {
                if (starship.Departments.Command < talent.DepartmentRequirements.Command ||
                    starship.Departments.Conn < talent.DepartmentRequirements.Conn ||
                    starship.Departments.Engineering < talent.DepartmentRequirements.Engineering ||
                    starship.Departments.Medicine < talent.DepartmentRequirements.Medicine ||
                    starship.Departments.Science < talent.DepartmentRequirements.Science ||
                    starship.Departments.Security < talent.DepartmentRequirements.Security)
                    return false;
            }

            if (talent.DepartmentRequirements.Operator == Operator.Or)
            {
                var allowed = false;

                if (talent.DepartmentRequirements.Command > 1 && (starship.Departments.Command > talent.DepartmentRequirements.Command) ||
                    talent.DepartmentRequirements.Conn > 1 && (starship.Departments.Conn > talent.DepartmentRequirements.Conn) ||
                    talent.DepartmentRequirements.Engineering > 1 && (starship.Departments.Engineering > talent.DepartmentRequirements.Engineering) ||
                    talent.DepartmentRequirements.Medicine > 1 && (starship.Departments.Medicine > talent.DepartmentRequirements.Medicine) ||
                    talent.DepartmentRequirements.Science > 1 && (starship.Departments.Science > talent.DepartmentRequirements.Science) ||
                    talent.DepartmentRequirements.Security > 1 && (starship.Departments.Security > talent.DepartmentRequirements.Security))
                    allowed = true;

                if (!allowed)
                    return false;
            }
        }

        if (talent.SystemRequirements != null)
        {
            if (starship.Systems.Structure < talent.SystemRequirements.Structure ||
                starship.Systems.Sensors < talent.SystemRequirements.Sensors ||
                starship.Systems.Weapons < talent.SystemRequirements.Weapons ||
                starship.Systems.Engines < talent.SystemRequirements.Engines ||
                starship.Systems.Comms < talent.SystemRequirements.Comms ||
                starship.Systems.Computers < talent.SystemRequirements.Computers)
                return false;
        }

        return true;
    }

    public static StarshipTalent GetTalent(string name)
    {
        return StarshipTalents.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    internal static StarshipTalent GetTalentFromList(Starship starship, ICollection<string> talentChoices)
    {
        foreach (var talent in starship.Talents)
        {
            if (talentChoices.Contains(talent.Name)) talentChoices.Remove(talent.Name);
        }

        var choice = talentChoices.OrderBy(n => Util.GetRandom()).First();

        return StarshipTalents.First(x => x.Name == choice);
    }

    internal static List<StarshipTalent> GetAllTalents()
    {
        return StarshipTalents;
    }

    private static readonly List<StarshipTalent> StarshipTalents = new()
    {
        new StarshipTalent
        {
            Name = StarshipTalentName.AblativeArmor,
            Description = new List<string>
            {
                "The vessel’s hull plating has an additional ablative layer that disintegrates slowly under extreme temperatures. Increase the ship's Resistance by 2."
            },
            MinimumServiceYear = 2368,
            ResistanceModifier = 2
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AblativeArmorGenerator,
            Description = new List<string>
            {
                "The ship is fitted with several external replicators pre-set to materialize an outer layer of armor plating over the hull, reinforced with structural integrity fields.",
                "When the ship raises its shields, it may deploy armor instead, but this requires using Reserve Power. Deploying the armor increases the ship’s maximum shields capacity by 5 and increases the ship’s Resistance by 3. While armor is deployed, the Modulate Shields and Regenerate Shields actions cannot be taken—the armor cannot be fine-tuned."
            },
            MinimumServiceYear = 2400
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AblativeFieldProjector,
            Description = new List<string>
            {
                "The ship’s shield emitters are combined with an ablative field projector, allowing its graviton field to be shared with another target in Close range. These projectors charge the target’s shields while dissipating its own.",
                "When you attempt the Regenerate Shields action, any Momentum you spend to increase shields regenerated may restore shields on an allied vessel within Close range."
            },
            MinimumServiceYear = 2400
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdaptableEnergyWeapons,
            Description = new List<string>
            {
                "When you select this talent, select one of the energy weapons on your ship, and choose a different energy weapon type (the emitter remains unchanged). When you make an attack using that energy weapon, you may use the alternate energy weapon type for the attack, but the complication range of that attack is increased by 1.",
            },
            MinimumServiceYear = 2300
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdaptiveShieldModulator,
            Description = new List<string>
            {
                "When the Modulate Shields action is taken, the ship’s Resistance is increased by a further +1 by that action. Further, the ship may have its shields raised when operating in silent running.",
            },
            MinimumServiceYear = 2300
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdditionalPropulsionSystemSporeHubDrive,
            Description = new List<string>
            {
                "The ship has been fitted with an additional propulsion system alongside its impulse and warp engines. Select one of the propulsion systems described in the transwarp and other propulsion section. The ship is equipped with that system.",
            },
            GMPermission = true
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdditionalPropulsionSystemProtostarDrive,
            Description = new List<string>
            {
                "The ship has been fitted with an additional propulsion system alongside its impulse and warp engines. Select one of the propulsion systems described in the transwarp and other propulsion section. The ship is equipped with that system.",
            },
            GMPermission = true
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdditionalPropulsionSystemQuantumSlipstreamDrive,
            Description = new List<string>
            {
                "The ship has been fitted with an additional propulsion system alongside its impulse and warp engines. Select one of the propulsion systems described in the transwarp and other propulsion section. The ship is equipped with that system.",
            },
            GMPermission = true
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdvancedEmergencyCrewHolograms,
            Description = new List<string>
            {
                "The ship has several holographic supporting characters (which should be pregenerated) equal to half the ship’s Computers score (round up); their appearance and personality are determined when the ship is created, though the supporting characters have a species trait of Hologram. These can be activated or deactivated as a minor action, and they do not require any Crew Support to appear. They cannot operate outside of the ship, and they do not improve when introduced in subsequent adventures. However, if any character advances are used to improve these supporting characters, all the supporting characters granted by this talent receive the advance."
            },
            MinimumServiceYear = 2380
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdvancedSickbay,
            Description = new List<string>
            {
                "The ship gains the Advanced Sickbay trait, which applies to all tasks related to medicine and biology performed within the sickbay, and stacks with the normal benefits of being in sickbay. This trait is lost if the ship’s Computers system is disabled. In addition, the ship receives one additional Crew Support, which may only be used to introduce supporting characters from the Medical department."
            },
            DepartmentRequirements = new DepartmentRequirements { Medicine = 3 },
            TraitGained = "Advanced Sickbay"
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdvancedResearchFacilities,
            Description = new List<string>
            {
                "The vessel is equipped with additional laboratories and long-term research facilities. Whenever a character aboard the ship succeeds at a task to perform research, and they are assisted by the ship’s Computers + Science, they may ask two additional questions, as if they had spent Momentum to Obtain Information."
            },
            DepartmentRequirements = new DepartmentRequirements { Science = 3 }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdvancedSensorSuites,
            Description = new List<string>
            {
                "Whenever a character performs a task roll assisted by the ship’s Sensors, the ship may roll 2d20 for assistance rather than only one (if Reserve Power is rerouted to Sensors, one of these dice is set to a 1). This talent cannot be used if the ship is suffering one or more breaches to Sensors."
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdvancedShields,
            Description = new List<string>
            {
                "The ship’s shields are state-of-the-art, using the latest developments. The ship's maximum shield capacity is increased by 5."
            },
            ShieldsModifier = 5
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AdvancedTransporters,
            Description = new List<string>
            {
                "When you use the transporters, if you have rerouted Reserve Power to the ship’s Sensors, select one trait in play that is affecting the transporter’s task. If the trait is increasing the task’s Difficulty, ignore the effects of that trait. If the trait instead makes the transporter’s task impossible, change that effect to instead increase the Difficulty by 1."
            },
            MinimumServiceYear = 2200
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AnnularConfinementJacketing,
            Description = new List<string>
            {
                "The ship may make an attack with its energy weapons while at warp; however, the range of these attacks is limited to Close range, and the Difficulty for the attack is increased by 1."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AutomatedDefences,
            Description = new List<string>
            {
                "At the end of a round, if no attacks were made using the ship’s weapons, the ship may make an energy weapon attack using its Weapons + Security (without assistance) against a target within Close range. Momentum may be used and generated as normal for this attack."
            },
            MinimumServiceYear = 2200,
            DepartmentRequirements = new DepartmentRequirements { Security = 3 }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.AutomaticReturn,
            Description = new List<string>
            {
                "The ship’s computer is programmed to recognize a starbase, colony, or some other location as its home base. The shuttles on board have the same programming and recognize the ship as their home base. If the ship’s Computers system goes for 10 days without commands from the crew, it will automatically pilot the ship back to the home base at maximum impulse."
            },
            MinimumServiceYear = 2200
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.BackupEPSConduits,
            Description = new List<string>
            {
                "When the ship is shaken and loses Reserve Power, roll 1d20; if you roll equal to or under your ship’s Structure, regain Reserve Power."
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.CaptainsYacht,
            Description = new List<string>
            {
                "The vessel has a single additional support craft, normally mounted in a dedicated port under the saucer of the ship. These craft, larger than most shuttles, are often used for diplomatic missions and special excursions special excursions.",
                "The ship has one additional small craft, which does not count against the ship’s small craft capacity and does not launch from the shuttlebay. The captain’s yacht statistics can be found in Small Craft."
            },
            ScaleRequirement = 3
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.CloakedMines,
            Description = new List<string>
            {
                "The ship’s mines are equipped with cloaking technology, making them near-impossible to detect. Mines deployed by the ship have the Hidden 2 quality.",
            },
            DepartmentRequirements = new DepartmentRequirements { Security = 3 },
            RequiresMines = true
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.CloakingDevice,
            Description = new List<string>
            {
                "Activating the device is a major action which requires Reserve Power, and which requires a Control + Engineering task with a Difficulty of 2, assisted by the ship’s Engines + Security. This is operated from the ship’s Tactical position. If successful, the vessel gains the Cloaked trait. While cloaked, the vessel cannot attempt any attacks, nor can it be the target of an attack unless the attacker has found some way of detecting the cloaked vessel. While cloaked, a vessel’s shields are down. Deactivating the cloaking device requires a minor action.",
            },
            GMPermission = true
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ClusterTorpedoes,
            Description = new List<string>
            {
                "The ship uses a modified torpedo system, where each casing splits into several smaller projectiles with separate payloads. When the ship fires a torpedo salvo, the attack gains the Versatile 2 quality.",
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.CommandShip,
            Description = new List<string>
            {
                "When a character on the ship succeeds at a Command task to create a trait, they may always be assisted by the ship’s Communications + Command, and they may confer the trait to allied ships, landing parties, or away teams with whom the ship maintains a communication link.",
            },
            DepartmentRequirements = new DepartmentRequirements { Command = 3 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DedicatedPersonnelCommand,
            Description = new List<string>
            {
                "The ship gains 2 additional Crew Support, which may only be used to establish supporting characters who are part of the Command department.",
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DedicatedPersonnelConn,
            Description = new List<string>
            {
                "The ship gains 2 additional Crew Support, which may only be used to establish supporting characters who are part of the Conn department.",
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DedicatedPersonnelEngineering,
            Description = new List<string>
            {
                "The ship gains 2 additional Crew Support, which may only be used to establish supporting characters who are part of the Engineering department.",
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DedicatedPersonnelSecurity,
            Description = new List<string>
            {
                "The ship gains 2 additional Crew Support, which may only be used to establish supporting characters who are part of the Security department.",
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DedicatedPersonnelScience,
            Description = new List<string>
            {
                "The ship gains 2 additional Crew Support, which may only be used to establish supporting characters who are part of the Science department.",
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DedicatedPersonnelMedical,
            Description = new List<string>
            {
                "The ship gains 2 additional Crew Support, which may only be used to establish supporting characters who are part of the Medical department.",
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DedicatedSubspaceTransceiverArray,
            Description = new List<string>
            {
                "This talent enhances the vessel’s communication range and clarity, even at warp. Any tasks involving sending, receiving, or intercepting subspace or standard communications may re-roll the ship’s assistance dice as long as the ship’s Communications system is not disabled.",
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DeluxeGalley,
            Description = new List<string>
            {
                "The ship’s mess hall is equipped with top-of-the-line food preparation systems as well as vast stores of non-replicated food.",
                "Once per adventure, you may create a Fine Dining trait for free when the ship is visited by a VIP, diplomat, or other important guest. When a character attempts a task using Presence and/or Command and benefits from this trait, the character receives 1 bonus Momentum, which may not be saved."
            },
            DepartmentRequirements = new DepartmentRequirements { Command = 3 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DiplomaticSuites,
            Description = new List<string>
            {
                "The ship has numerous high-quality staterooms for hosting VIPs, as well as briefing rooms and other facilities that allow the ship to serve as a neutral ground for diplomatic summits, trade negotiations, and similar functions, including making environmental adjustments to make alien diplomats more comfortable.",
                "When hosting negotiations, members of the crew may be assisted by the ship’s Computers + Command or Structure + Command."
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.DualEnvironment,
            Description = new List<string>
            {
                "The ship is outfitted with redundant system rooms that can be filled with gases or liquids that allow crew members requiring different atmospheric conditions to work side by side with the rest of the crew. A character who is in a redundant system room may assist others in the connected system room as if they were in the same room.",
            },
            MinimumServiceYear = 2300
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ElectronicWarfareSystems,
            Description = new List<string>
            {
                "Whenever a character at the communications station on the ship creates a trait to represent intercepting enemy communications, or to create interference or jamming signals which would hinder enemy communications, they may spend 1 Momentum to increase the Potency of that trait by one step, or to affect a second enemy vessel.",
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.EmergencyMedicalHologram,
            Description = new List<string>
            {
                "The ship has one additional supporting character, an Emergency Medical Hologram (EMH), using the attributes, departments, and so forth as shown in the sidebar, which does not cost any Crew Support to introduce, and which does not automatically improve when introduced. This character can only go to locations on the ship which are equipped with holo-emitters.",
                "For every three years after 2371, the current model of EMH is replaced by a newer model (Mark II in 2374, Mark III in 2377, and Mark IV in 2380). After 2380, this talent is replaced by Advanced Emergency Crew Holograms. Apply the following cumulative changes to these models: MARK II: +1 Presence; MARK III: +1 Medicine; MARK IV: Add the Technical Expertise talent"
            },
            MinimumServiceYear = 2371,
            MaximumServiceYear = 2380
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExpandedEmergencyMedicalFacilities,
            Description = new List<string>
            {
                "Whenever a character attempts a task to identify specific illnesses or injuries, or to determine the severity of a patient’s condition, they may diagnose a number of patients equal to the ship’s Medical rating. If the character also has the Triage talent, they may diagnose two additional patients by spending 1 Momentum (Repeatable).",
                "During an extended task to process and treat many sick or injured patients, a character aboard the ship increases their Impact by 1."
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExpandedMunitions,
            Description = new List<string>
            {
                "The ship may add one weapon to its profile: either an energy weapon (choose an energy type and a delivery mechanism) or a torpedo type. This talent is often taken by Starfleet vessels to add Quantum Torpedoes to a ship’s arsenal.",
            },
            AddRandomWeapon = true
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExpansiveDepartmentCommand,
            Description = new List<string>
            {
                "Whenever a ship assists a task roll using Command, you may ignore a complication by spending 1 Momentum (Immediate, Repeatable).",
            },
            DepartmentRequirements = new DepartmentRequirements { Command = 5 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExpansiveDepartmentConn,
            Description = new List<string>
            {
                "Whenever a ship assists a task roll using Conn, you may ignore a complication by spending 1 Momentum (Immediate, Repeatable).",
            },
            DepartmentRequirements = new DepartmentRequirements { Conn = 5 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExpansiveDepartmentEngineering,
            Description = new List<string>
            {
                "Whenever a ship assists a task roll using Engineering, you may ignore a complication by spending 1 Momentum (Immediate, Repeatable).",
            },
            DepartmentRequirements = new DepartmentRequirements { Engineering = 5 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExpansiveDepartmentSecurity,
            Description = new List<string>
            {
                "Whenever a ship assists a task roll using Security, you may ignore a complication by spending 1 Momentum (Immediate, Repeatable).",
            },
            DepartmentRequirements = new DepartmentRequirements { Security = 5 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExpansiveDepartmentMedical,
            Description = new List<string>
            {
                "Whenever a ship assists a task roll using Medicine, you may ignore a complication by spending 1 Momentum (Immediate, Repeatable).",
            },
            DepartmentRequirements = new DepartmentRequirements { Medicine = 5 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExpansiveDepartmentScience,
            Description = new List<string>
            {
                "Whenever a ship assists a task roll using Science, you may ignore a complication by spending 1 Momentum (Immediate, Repeatable).",
            },
            DepartmentRequirements = new DepartmentRequirements { Science = 5 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExtendedSensorRange,
            Description = new List<string>
            {
                "The ship’s sensors have been refined to be more effective at longer ranges. When you attempt a task assisted by the ship’s Sensors, if there is any increase in Difficulty due to range, then reduce that Difficulty increase by 2. This effect is lost if the Sensors suffer one or more breaches.",
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExtensiveAutomation,
            Description = new List<string>
            {
                "The ship has been configured to operate on a much smaller crew, relying on automation to handle tasks normally performed by personnel. Even purely physical tasks can be replaced by automation, using compact technical drones, such as the DOT-7 present on some 23rd century Starfleet vessels, like the U.S.S. Discovery.",
                "The ship’s Crew Support is reduced to half its normal value (rounded up). However, the ship may attempt tasks by itself, and may even take a turn during a combat round by itself. If it does so, add 1 Threat before a task is attempted, and make the roll using the ship’s systems and departments."
            },
            SystemRequirements = new StarshipSystems { Computers = 10 },
            HalfCrewSupport = true
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExtensiveMedicalLaboratories,
            Description = new List<string>
            {
                "While in sickbay, when an extended task is attempted to study an unknown medical condition, or to develop a treatment for one, the characters performing the extended task each adds 1 to their Impact.",
            },
            DepartmentRequirements = new DepartmentRequirements { Medicine = 4 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ExtensiveShuttlebays,
            Description = new List<string>
            {
                "The vessel’s shuttlebays are large, well-supplied, and able to support a larger number of active shuttle missions simultaneously. The ship’s Small Craft Readiness is increased by an amount equal to the ship’s Scale minus 1, and it may carry up to two Scale 2 small craft (typically runabouts). Starships that do not have this talent may carry Scale 1 small craft only.",
            },
            DoubleSmallCraftReadiness = true,
            ScaleRequirement = 3
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.FastTargetingSystems,
            Description = new List<string>
            {
                "When you use the Targeting Solution minor action, you may gain both benefits: re-roll a d20 on the next attack and choose the system hit by the attack.",
            },
            DepartmentRequirements = new DepartmentRequirements { Security = 3 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.HighIntensityEnergyWeapons,
            Description = new List<string>
            {
                "If Reserve Power is rerouted to Weapons, the next attack using one of the ship’s energy weapons increases Damage by 2.",
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.HighPowerTractorBeam,
            Description = new List<string>
            {
                "The ship’s tractor beam systems channel far greater quantities of power and exert much more force on the target. Increase the strength of the ship’s tractor beam by 2.",
            },
            RequiresTractorBeam = true,
            TractorBeamModifier = 2
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.HighResolutionSensors,
            Description = new List<string>
            {
                "The vessel’s sensors can gain large amounts of accurate data, though they are extremely sensitive. While the vessel is not in combat, any successful task assisted by the ship’s Sensors gains 1 bonus Momentum. Bonus Momentum may not be saved."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ImprovedDamageControl,
            Description = new List<string>
            {
                "When a character takes the Damage Control action aboard the ship, they may re-roll a single d20. When attempting an extended task related to repairing the ship, anyone working on that extended task adds 1 to their Impact."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ImprovedHullIntegrity,
            Description = new List<string>
            {
                "The ship’s hull has been reinforced to better endure stress and damage. The ship’s Resistance is increased by 1."
            },
            ResistanceModifier = 1
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ImprovedImpulseDrive,
            Description = new List<string>
            {
                "When a character uses the Impulse minor action while on this ship, they may spend 2 Momentum to increase the Difficulty of attacks against the ship by +1 until the start of that character’s next turn, due to the ship’s rapid acceleration."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ImprovedPowerSystems,
            Description = new List<string>
            {
                "When a character attempts the Regain Power action, the Difficulty is reduced by 1, to a minimum of 1, and you may spend 1 Momentum (Immediate) to ignore complications suffered on that task roll."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ImprovedProbeBay,
            Description = new List<string>
            {
                "When a character uses the Launch Probe minor action, the probe may be launched to a location up to five zones away. In addition, the probes are no longer destroyed if they take any damage; instead, each probe has 3 Shield points, and are destroyed if they take one breach."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ImprovedReactionControlSystem,
            Description = new List<string>
            {
                "Whenever the ship attempts to move through difficult terrain, reduce the Momentum cost of the difficult terrain by 1, to a minimum of 0."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ImprovedShieldRecharge,
            Description = new List<string>
            {
                "Whenever the Regenerate Shields action is successful, the ship regains shields equal to the character’s Engineering department rating +1, plus 3 more by spending 1 Momentum (Repeatable), instead of the normal amount."
            },
            DepartmentRequirements = new DepartmentRequirements { Security = 3 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ImprovedWarpDrive,
            Description = new List<string>
            {
                "Whenever the ship takes the Warp major action, roll a d20; if you roll equal to or under the ship’s Engines, you do not spend Reserve Power for the ship."
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.IndependentWeaponPower,
            Description = new List<string>
            {
                "The ship’s directed energy weapons are powered from an independent reactor rather than tied to the ship’s main engines.",
                "Increase the Damage rating of the ship’s energy weapons by 1. Further, when you fire one of the ship’s energy weapons, ignore one breach currently affecting the ship’s Weapons system. However, Reserve Power cannot be redirected to the ship’s Weapons."
            },
            EnergyWeaponDamageModifier = 1
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.IndustrialReplicators,
            Description = new List<string>
            {
                "The ship is equipped with high-power, high-capacity replicators which can produce large-scale objects, components for prefabricated buildings, colonial infrastructure, or even vehicles. Tied into the ship’s cargo transporters, they can deposit their output directly onto a planet’s surface from orbit: a valuable ability during crisis relief missions.",
                "The ship has the trait Industrial Replicators, and the ship’s Small Craft Capacity is increased by 2 (if the ship also has Extensive Shuttlebays, apply this bonus afterwards). In addition, characters on the ship may replicate large objects, structures, and vehicles during a mission; these have opportunity cost 3."
            },
            SmallCraftReadinessModifier = 2,
            TraitGained = "Industrial Replicators",
            ScaleRequirement = 3
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.Minelayer,
            Description = new List<string>
            {
                "The ship has been refitted to deploy mines in addition to its existing armaments. Choose a single type of mine for the ship to carry. The Expanded Munitions talent allows the ship to select additional mine types.",
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ModularCargoBays,
            Description = new List<string>
            {
                "The ship’s cargo bays are large, but they’re also fitted with additional equipment, movable partitions, force field generators, and other stowable furnishings that make it easier to refit the cargo bay for other purposes.",
                "When you convert a cargo bay to serve another purpose, it only costs 1 Momentum (Immediate) rather than 2, and the new trait gains +1 Potency."
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ModularLaboratories,
            Description = new List<string>
            {
                "The opportunity cost of establishing a science lab is reduced to 0 for the first laboratory established, and to 1 for the second.",
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.PointDefenseSystem,
            Description = new List<string>
            {
                "The ship is equipped with a system of small energy weapon emitters that operates independently from the main weapons systems. When a torpedo targets the ship, these emitters start firing in the direction the torpedo is traveling from, potentially destroying it before it impacts the shields or the ship’s hull.",
                "This system does not function while the ship is travelling at warp. The ship is considered to have Cover against torpedo attacks, increasing the Difficulty of the attack by 1. This talent stops functioning if the ship has suffered one or more breaches to the Weapons system."
            },
            DepartmentRequirements = new DepartmentRequirements { Security = 3 },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RapidFireTorpedoLauncher,
            Description = new List<string>
            {
                "The vessel’s torpedo launchers have been designed to allow the ship to fire multiple torpedoes much more quickly and accurately. When the ship fires a torpedo salvo, the character at Tactical may re-roll a d20 on the Attack. Also, the weapon’s Damage rating is increased by 1.",
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.ReducedSensorSilhouette,
            Description = new List<string>
            {
                "Through a combination of advanced alloys, EM shielding, and electronic countermeasures, the starship is difficult to detect via electromagnetic radiation and subspace sensors. Tasks attempting to scan or detect the vessel increase in Difficulty by 1.",
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RedundantSystemsComms,
            Description = new List<string>
            {
                "When Comms suffer a breach, the crew may choose to activate this talent in response; doing so immediately patches the breach inflicted. These redundant systems may only be activated once per adventure."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RedundantSystemsStructure,
            Description = new List<string>
            {
                "When Structure suffer a breach, the crew may choose to activate this talent in response; doing so immediately patches the breach inflicted. These redundant systems may only be activated once per adventure."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RedundantSystemsWeapons,
            Description = new List<string>
            {
                "When Weapons suffer a breach, the crew may choose to activate this talent in response; doing so immediately patches the breach inflicted. These redundant systems may only be activated once per adventure."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RedundantSystemsSensors,
            Description = new List<string>
            {
                "When Sensors suffer a breach, the crew may choose to activate this talent in response; doing so immediately patches the breach inflicted. These redundant systems may only be activated once per adventure."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RedundantSystemsEngines,
            Description = new List<string>
            {
                "When Engines suffer a breach, the crew may choose to activate this talent in response; doing so immediately patches the breach inflicted. These redundant systems may only be activated once per adventure."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RedundantSystemsComputers,
            Description = new List<string>
            {
                "When Computers suffer a breach, the crew may choose to activate this talent in response; doing so immediately patches the breach inflicted. These redundant systems may only be activated once per adventure."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RegenerativeHull,
            Description = new List<string>
            {
                "The ship’s hull is infused with reverse-engineered Borg nanite technology that seeks out and repairs the hull immediately when it is damaged, often preventing a breach before it can happen. Each time the ship suffers one or more breaches, roll a d20. If you roll equal to or under your ship’s Structure, ignore one breach inflicted."
            },
            MinimumServiceYear = 2400
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.RuggedDesign,
            Description = new List<string>
            {
                "Whenever a task roll is attempted to patch or repair a breach, a d20 may be re-rolled. Further, if the task is successful, the crew may spend Momentum to patch a second breach; this will cost 2 Momentum, +1 per additional step of Potency on that second breach."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.SecondaryReactors,
            Description = new List<string>
            {
                "The ship has additional impulse and fusion reactors which allow the ship to generate far greater quantities of energy. Once per scene, when you take the Reroute Power action, you may spend 2 Momentum (Immediate) to immediately regain the use of Reserve Power."
            }
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.SelfReplicatingMines,
            Description = new List<string>
            {
                "The ship carries mines which are capable of self-replicating themselves over time, allowing them to replenish detonated mines. This reduces the mines’ Damage rating by 1, and cannot be done with Cumbersome mines, but the Difficulty of the task made to avoid the mines is not reduced when mines are detonated."
            },
            MinimumServiceYear = 2371,
            RequiresMines = true
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.SiphoningShields,
            Description = new List<string>
            {
                "When the ship is hit by an energy weapon, after the attack is resolved, you may add 2 Threat to restore Shields equal to the ship’s Security department."
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.SophisticatedAstrometricsFacilities,
            Description = new List<string>
            {
                "When a character in the stellar cartography laboratory or at navigation attempts a task to plot a course or map a large region of space, they may re-roll a d20. Further, if such a task creates a trait to represent a planned course or knowledge about the region, this trait automatically increases its Potency by one step."
            },
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.TachyonDetectionField,
            Description = new List<string>
            {
                "The ship is equipped with a field generator that projects a cloud of tachyons around it. When a character at sensor operations succeeds at a Reveal major action, all cloaked or hidden vessels within Long range are revealed, rather than only one."
            },
            DepartmentRequirements = new DepartmentRequirements { Science = 3 },
            MinimumServiceYear = 2400
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.TraceablePayloadSystem,
            Description = new List<string>
            {
                "The ship’s armaments have been modified to leave a distinctive radioisotope signature on anything they strike. This signature is difficult to detect unless it has been specifically looked for, but the firing ship can detect it up to five light-years away.",
                "Whenever this ship succeeds at an attack, you may spend 1 Momentum to apply the trait Radioisotope Trace to the target. This trait remains for approximately a day. If a target with that trait is within five lightyears, you may attempt a Reason + Science task with a Difficulty of 2, assisted by the ship’s Sensors + Security to detect the target’s approximate location (the closer you are, the more precise a location you can get). If the target is outside of this range, the task immediately fails."
            },
            MinimumServiceYear = 2400
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.TransportInhibitors,
            Description = new List<string>
            {
                "While transporter inhibitors are active on the ship, nobody may transport onto or off the ship: all tasks to transport people or materials to or from the ship immediately fail. This necessarily means that the ship’s own transporters are shut down, as they will not function alongside the inhibitors."
            },
            MinimumServiceYear = 2260
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.VariableGeometryWarpField,
            Description = new List<string>
            {
                "A ship with a variable geometry warp field can adjust its subspace field in highly turbulent spacetime and can continue to provide propulsive force even then. When you attempt a task to go to warp, you may select one trait in play which affects the task roll, and ignore its effects."
            },
            MinimumServiceYear = 2400
        },
        new StarshipTalent
        {
            Name = StarshipTalentName.WormholeRelaySystem,
            Description = new List<string>
            {
                "The ship has an additional sensor system outfitted with high-energy transceivers, verteron sensors, and neutrino sensors. These sensors, combined with field-generation devices, allow the ship to send and receive data streams through wormholes. The Difficulty of all Science tasks to send or receive data through a wormhole is reduced by 2, to a minimum of 0."
            },
            MinimumServiceYear = 2371
        }
    };
}
