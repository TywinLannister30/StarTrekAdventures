using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public class SmallCraftSelector
{
    public static SmallCraft GetSmallCraft(string name)
    {
        var selectedSmallCraft = SmallCrafts.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        return CreateSmallCraft(selectedSmallCraft);
    }

    internal static List<SmallCraft> GetAllSmallCraft()
    {
        var selectedSmallCrafts = SmallCrafts;

        var smallCrafts = new List<SmallCraft>();

        foreach (var smallCraft in selectedSmallCrafts)
        {
            smallCrafts.Add(CreateSmallCraft(smallCraft));
        }

        return smallCrafts;
    }

    private static SmallCraft CreateSmallCraft(SmallCraft smallCraft)
    {
        var npc = new SmallCraft(smallCraft);

        npc.SetResistance();
        npc.SetShields();

        foreach (var weapon in npc.Weapons)
            weapon.SetEffect(npc);

        return npc;
    }

    private static readonly List<SmallCraft> SmallCrafts = new()
    {
        new SmallCraft
        {
            Name = "Shuttlepod",
            Description = new List<string> 
            {
                "A tiny craft, designed to move small numbers of personnel or small quantities of cargo over short distances. They are unarmed, not fitted with a transporter, and not capable of travelling at warp."
            },
            Traits = new List<string>
            {
                "Shuttlepod",
                "Sublight",
                "Small Craft",
                "Unarmed"
            },
            CrewCompliment = "1 or 2, plus 2 passengers",
            Scale = 1,
            Systems = new StarshipSystems { Comms = 3, Computers = 2, Engines = 3, Sensors = 3, Structure = 3, Weapons = 0 },
            Departments = new Departments { Command = 0, Conn = 1, Engineering = 1, Security = 0, Medicine = 0, Science = 1 },
            //Weapons = new List<StarshipWeapon>
            //{
            //    StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
            //    StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            //},
            Weapons = new List<StarshipWeapon>(),
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            },
            SpecialRules = new List<StarshipSpecialRule>()
        },
        new SmallCraft
        {
            Name = "Shuttlecraft",
            Description = new List<string>
            {
                "A small vessel, designed to move groups of personnel or modest quantities of cargo over intrasystem and short interstellar distances. They are often fitted with a small phaser bank, and they can travel at low warp, or match the cruising speed of starships only for short periods."
            },
            Traits = new List<string>
            {
                "Shuttlecraft",
                "Short-Range",
                "Small Craft",
                "Unarmed"
            },
            CrewCompliment = "1 or 2, plus up to 6 passengers depending on shuttle type",
            Scale = 1,
            Systems = new StarshipSystems { Comms = 5, Computers = 5, Engines = 5, Sensors = 4, Structure = 5, Weapons = 0 },
            Departments = new Departments { Command = 0, Conn = 1, Engineering = 1, Security = 0, Medicine = 0, Science = 1 },
            //Weapons = new List<StarshipWeapon>
            //{
            //    StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
            //    StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhotonTorpedoes),
            //},
            Weapons = new List<StarshipWeapon>(),
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                new()
                {
                    Name = "Transporter",
                    Description = new List<string>
                    {
                        "Some shuttlecraft are fitted with a escape transporter. Taking this option has opportunity cost 1."
                    }

                }
            }
        },
        new SmallCraft
        {
            Name = "Shuttlecraft (Armed)",
            Description = new List<string>
            {
                "A small vessel, designed to move groups of personnel or modest quantities of cargo over intrasystem and short interstellar distances. They are often fitted with a small phaser bank, and they can travel at low warp, or match the cruising speed of starships only for short periods."
            },
            Traits = new List<string>
            {
                "Shuttlecraft",
                "Short-Range",
                "Small Craft"
            },
            CrewCompliment = "1 or 2, plus up to 6 passengers depending on shuttle type",
            Scale = 1,
            Systems = new StarshipSystems { Comms = 5, Computers = 5, Engines = 5, Sensors = 4, Structure = 5, Weapons = 0 },
            Departments = new Departments { Command = 0, Conn = 1, Engineering = 1, Security = 0, Medicine = 0, Science = 1 },
            Weapons = new List<StarshipWeapon>
            {
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
            },
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                new()
                {
                    Name = "Transporter",
                    Description = new List<string>
                    {
                        "Some shuttlecraft are fitted with a escape transporter. Taking this option has opportunity cost 1."
                    }
                }
            }
        },
        new SmallCraft
        {
            Name = "Runabout",
            Description = new List<string>
            {
                "These larger auxiliary craft—such as the Danube-class runabouts used by Starfleet—are technically small starships, and are used for independent operations from larger starships and starbases. Runabouts are capable of a sustained warp speed (usually around warp 5), contain a small transporter pad and replicator."
            },
            Traits = new List<string>
            {
                "Light Starship",
                "Short-Range"
            },
            CrewCompliment = "1 to 4",
            Scale = 2,
            Systems = new StarshipSystems { Comms = 9, Computers = 8, Engines = 7, Sensors = 7, Structure = 7, Weapons = 7 },
            Departments = new Departments { Command = 0, Conn = 2, Engineering = 1, Security = 1, Medicine = 0, Science = 0 },
            Weapons = new List<StarshipWeapon>
            {
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.MicroTorpedoes),
            },
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.RuggedDesign),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                new()
                {
                    Name = "Customizable Modules",
                    Description = new List<string>
                    {
                        "The runabout may be fitted with one of the following modules for additional functionality. Taking any of these options has an opportunity cost 1, but these options can only be taken when preparing the runabout from a starbase, surface facility, or a starship with Extensive Shuttlebays.",
                        "CARGO TRANSPORT: The runabout’s aft module has been configured to carry bulk cargo.",
                        "COMBAT MISSION: Add 1 to damage of the runabout’s weapons, and add 2 to the ship’s maximum Shields. This has an escalation cost 1.",
                        "LONG DURATION MISSION: The runabout’s aft module has been configured to serve as a rest area and sleeping quarters for up to four personnel.",
                        "PASSENGER TRANSPORT: The runabout may carry up to 10 passengers, or up to 40 in an emergency, for a maximum of 2 hours.",
                        "SENSOR MODULE: Add 1 to the runabout’s Computers and Sensors, and add the High- Resolution Sensors talent.",
                    }
                }
            }
        },
        new SmallCraft
        {
            Name = "Captain’s Yacht",
            Description = new List<string>
            {
                "A specialty small craft often attached to diplomatic vessels, the captain’s yacht was a large shuttlecraft designed to aid commanding officers during diplomatic missions."
            },
            Traits = new List<string>
            {
                "Specialized Shuttle",
                "Small Craft",
                "Luxurious"
            },
            CrewCompliment = "1 to 2, plus up to 10 passengers",
            Scale = 2,
            Systems = new StarshipSystems { Comms = 9, Computers = 8, Engines = 8, Sensors = 7, Structure = 7, Weapons = 7 },
            Departments = new Departments { Command = 2, Conn = 1, Engineering = 1, Security = 0, Medicine = 0, Science = 0 },
            Weapons = new List<StarshipWeapon>
            {
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaserBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.MicroTorpedoes),
            },
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.DiplomaticSuites),
            },
            SpecialRules = new List<StarshipSpecialRule>()
        },
        new SmallCraft
        {
            Name = "Attack Fighter",
            Description = new List<string>
            {
                "At various times, different civilizations have attempted to make widespread use of small craft in combat, with armed shuttles and high-agility attack fighters developed for this purpose. The Federation has, on several occasions, developed attack fighters to supplement a fleet stretched thin during wartime, with varying degrees of success. Their small size means that their armaments draw most of the available power, and they are very rarely capable of traveling at warp. Even 24th century versions can only sustain low warp speeds for under an hour."
            },
            Traits = new List<string>
            {
                "Attack Fighter",
                "Small Craft",
                "Agile"
            },
            CrewCompliment = "1 to 2",
            Scale = 1,
            Systems = new StarshipSystems { Comms = 5, Computers = 5, Engines = 7, Sensors = 6, Structure = 5, Weapons = 7 },
            Departments = new Departments { Command = 0, Conn = 1, Engineering = 0, Security = 2, Medicine = 0, Science = 0 },
            Weapons = new List<StarshipWeapon>
            {
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaseCannons),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.MicroTorpedoes),
            },
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedImpulseDrive),
            },
            SpecialRules = new List<StarshipSpecialRule>()
        },
        new SmallCraft
        {
            Name = "Type-9 Shuttle",
            Description = new List<string>
            {
                "The Type-9 shuttlecraft was also referred to as the Class 2 (second-class) after the Type-8 shuttlecraft was given priority in production over the arguably more elegant and smaller Type-9. The Type-9 was originally designed as a single crew warp-capable fighter to replace the larger multicrewed fighters currently deployed in defensive formations across the Federation, but initial flight tests showed that the design would be far more successful as a small shuttlecraft with its internal space dedicated to sensors and cargo rather than shielding and offensive systems."
            },
            Traits = new List<string>
            {
                "Federation Shuttlecraft",
                "Short-Range",
                "Small Craft",
                "Nimble"
            },
            CrewCompliment = "2, plus 4 passengers",
            Scale = 1,
            Systems = new StarshipSystems { Comms = 6, Computers = 7, Engines = 7, Sensors = 6, Structure = 6, Weapons = 6 },
            Departments = new Departments { Command = 0, Conn = 2, Engineering = 0, Security = 2, Medicine = 0, Science = 0 },
            Weapons = new List<StarshipWeapon>
            {
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaseBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.MicroTorpedoes),
            },
            Talents = new List<StarshipTalent>
            {
                StarshipTalentSelector.GetTalent(StarshipTalentName.ImprovedImpulseDrive),
            },
            SpecialRules = new List<StarshipSpecialRule>
            {
                new()
                {
                    Name = "Transporter",
                    Description = new List<string>
                    {
                        "A Class-9 Shuttle carries a small transporter able to beam two people at once."
                    }
                }
            },
            Source = BookSource.CommandDivision1stEdition
        },
        new SmallCraft
        {
            Name = "Type-10 Shuttle",
            Description = new List<string>
            {
                "With the new smaller starships beginning to be put into production by Starfleet, compact shuttles were needed to give these vessels the versatility expected by the officers and enlisted of the service. To accomplish this, designers had to make compromises in the design, electing for compact systems rather than the best available for Federation shuttles. The Type-10 shuttlecraft, also known as the Chaffee class, ended up using technology that had been discarded for a century or more as refinements to the equipment made them small enough to be required for this design. Loved and hated in equal measures by crew serving aboard them, the Type-10 is only permanently assigned to Defiant and some Nova-class starships."
            },
            Traits = new List<string>
            {
                "Federation Shuttlecraft",
                "Very Short-Range",
                "Small Craft",
                "Extremely Compact"
            },
            CrewCompliment = "2, plus 4 passengers",
            Scale = 1,
            Systems = new StarshipSystems { Comms = 6, Computers = 7, Engines = 6, Sensors = 6, Structure = 6, Weapons = 5 },
            Departments = new Departments { Command = 0, Conn = 2, Engineering = 0, Security = 1, Medicine = 0, Science = 0 },
            Weapons = new List<StarshipWeapon>
            {
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.PhaseBanks),
                StarshipWeaponSelector.GetWeapon(StarshipWeaponName.MicroTorpedoes),
                new() 
                {
                    Name = StarshipWeaponName.QuantumTorpedoes + " (One use only)",
                    Type = StarshipWeaponType.Torpedo,
                    Range = StarshipWeaponRange.Long,
                    Damage = 4,
                    Qualities = new List<WeaponQuality>
                    {
                        StarshipWeaponSelector.GetWeaponQuality(WeaponQualityName.Calibration),
                        StarshipWeaponSelector.GetWeaponQuality(WeaponQualityName.HighYield),
                        StarshipWeaponSelector.GetWeaponQuality(WeaponQualityName.Intense)
                    }
                },
            },
            Talents = new List<StarshipTalent>(),
            SpecialRules = new List<StarshipSpecialRule>
            {
                new()
                {
                    Name = "External Hardware",
                    Description = new List<string>
                    {
                        "A Class-10 Shuttle is difficult to repair while in space, as most of the systems are only accessible from outside. Repairs made while the shuttle is in space increase in difficulty by 1. The same tasks reduce in difficulty by 1, to a minimum of 0, when made within a proper shuttlebay."
                    }
                }
            },
            Source = BookSource.CommandDivision1stEdition
        },
    };
}
