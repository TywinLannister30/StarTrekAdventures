using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public static class SpaceframeSelector
{
    public static Spaceframe ChooseSpaceframe(string specificSpaceframe)
    {
        if (!string.IsNullOrEmpty(specificSpaceframe))
            return GetSpaceframe(specificSpaceframe);

        var weightedSpaceframeList = new WeightedList<Spaceframe>();

        foreach (var spaceframe in Spaceframes)
            weightedSpaceframeList.AddEntry(spaceframe, spaceframe.Weight);

        return weightedSpaceframeList.GetRandom();
    }

    public static Spaceframe GetSpaceframe(string name)
    {
        return Spaceframes.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
    }

    private static readonly ICollection<Spaceframe> Spaceframes = new List<Spaceframe>
    {
        new()
        {
            Name = SpaceframeName.Freedom,
            LaunchYear = 2148,
            Overview = "The Freedom-class was developed in parallel with the NX class and entered service a few years earlier due to its less resource-intensive design. The U.S.S. Franklin was the first vessel able to reach Warp 4. The Freedom class’s small size, limited crew requirements, and high speed meant these vessels were produced in greater numbers than the NX class, and many continued in service once the Federation was founded. The class was phased out by the end of the 22nd century.",
            Capabilities = "Freedom-class vessels were well-liked in the lead-up to the Earth-Romulan War, and they served with distinction as scouts and escorts. It relied on polarized hull plating for defense and the ship’s transporter was intended only for cargo use. The ship’s small size limited the crew complement and meant it could not support small craft. Crew embarked and disembarked by docking with another vessel.",
            RefitsAndVariants = "Many Freedom-class ships were given uprated armaments during the Earth- Romulan War.",
            NameingConventions = "Freedom-class vessels utilized names associated with notable individuals throughout Earth history, often revolutionaries and leaders.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "United Earth Starship",
                "NX class",
                "Compact Size",
                "No Personnel Transporter"
            },
            Scale = 2,
            Systems = new StarshipSystems
            {
                Comms = 5, Computers = 5, Engines = 5, Sensors = 5, Structure = 5, Weapons = 6
            },
            Departments = new Departments
            {
                Conn = 2, Engineering = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaseCannons,
                StarshipWeaponName.SpatialTorpedoes,
            },
            GrapplerCableStrength = 1,
            Talents = new List<string>(),
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.CompactVessel,
                StarshipSpecialRuleName.GrapplerCable,
                StarshipSpecialRuleName.PolarizedHullPlating
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.NX,
            LaunchYear = 2151,
            Overview = "Designed and developed by Zefram Cochrane’s Warp Five Project and the joint Starfleet/ United Earth Space Probe Agency NX Project, the NX class was groundbreaking in nearly every way. Its large saucer-like hull was different from earlier spherical or cylindrical hulls of most UESPA vessels. The ship also had two long warp nacelles connected to trailing pylons, isolating the experimental warp coils from the rest of the ship.",
            Capabilities = "At the time of its launch, the NX class was the fastest starship in service to United Earth. The spaceframe was capable of cruising at warp 4.5 and could produce emergency speeds of warp 5.2 in short bursts. In an era before energy shielding, the spaceframe boasted an impressive amount of polarized hull-plating that helped protect the inner hull and inhabited areas. The spaceframe had the capability of launching two shuttlepods, with a third held in reserve.",
            RefitsAndVariants = "NX-class vessels were used during the decade prior to the Earth-Romulan War and rarely afterward. The largest refit was conducted during the war, adding a secondary hull with an improved warp core and additional weapon systems.",
            NameingConventions = "NX-class vessels utilize names from famous Earth ships—both maritime vessels and early spacecraft—often names with long legacies. NX-class vessels have registries that begin with NX, and are numbered sequentially.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "United Earth Starship",
                "NX class"
            },
            Scale = 3,
            Systems = new StarshipSystems
            {
                Comms = 5, Computers = 5, Engines = 6, Sensors = 6, Structure = 6, Weapons = 6
            },
            Departments = new Departments
            {
                Conn = 1, Engineering = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaseCannons,
                StarshipWeaponName.SpatialTorpedoes,
            },
            GrapplerCableStrength = 2,
            Talents = new List<string>
            {
                StarshipTalentName.HighResolutionSensors
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.GrapplerCable,
                StarshipSpecialRuleName.PolarizedHullPlating
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Walker,
            LaunchYear = 2195,
            Overview = "The formation of the Federation after the Earth-Romulan War and the difficulties in meshing the founding members’ navies together meant introducing standardized designs beyond those developed during the war was put off as late as possible. The Walker class was one of the first joint spaceframes to be developed as a multirole explorer.",
            Capabilities = "Walker-class vessels had a large saucer containing the crew’s quarters, weapon systems, laboratories, and sickbay. Integrated with the saucer was a secondary hull containing the vessel’s engineering section, aft-facing shuttlebay, and cargo area. Warp field enhancements allowed the class to achieve sustained warp velocities of 5.7 and brief sprints of warp 6.9.",
            RefitsAndVariants = "Refits focused on improving sensor platforms and subspace communications equipment.",
            NameingConventions = "Walker-class vessels are named after early aviation heroes of Earth and other founding members of the Federation, and mythical ideas of flight. Valkyrie, Thunderbird, and Vimana are all examples. Registry numbers of Walker-class vessels range from 1200 to 1249.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.ScientificAndSurveyOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Walker class"
            },
            Scale = 3,
            Systems = new StarshipSystems
            {
                Comms = 6, Computers = 7, Engines = 6, Sensors = 7, Structure = 6, Weapons = 6
            },
            Departments = new Departments
            {
                Engineering = 1, Medicine = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaseCannons,
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes,
            },
            TractorBeamStrength = 2,
            Talents = new List<string>
            {
                StarshipTalentName.RuggedDesign
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Pioneer,
            LaunchYear = 2241,
            Overview = "Designed and built as one of the first implementations of the revolutionary Marvick-style warp drive, the Pioneer class was intended to be the vanguard of a new generation of Starfleet starships. Instead, only a few Pioneers were built as Starfleet decided to eschew new construction in favor of maintaining its large reserve of Magee- and Malachowski-class ships. After most of the fleet’s light units were destroyed in the Federation-Klingon War, the Admiralty revived the Pioneer program, and it eventually became Starfleet’s de-facto light cruiser until the 2270s.",
            Capabilities = "Small and flexible, the Pioneer class centered around patrol, surveillance, and logistics. Intended to supplement and support the larger Constitution class, the Pioneer has a medium range and modular construction. While a fast and flexible light cruiser, the Pioneer did not offer much offensive capability.",
            RefitsAndVariants = "Refits focused on improving the class’s computer systems and sensor pallets.",
            NameingConventions = "Pioneer-class vessels are named using synonyms for pioneers, such as Trailblazer, Wanderer, Pathfinder, and Explorer. NCC numbers range from 1500-1599.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.ScientificAndSurveyOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Pioneer class"
            },
            Scale = 3,
            Systems = new StarshipSystems
            {
                Comms = 8, Computers = 7, Engines = 8, Sensors = 7, Structure = 7, Weapons = 6
            },
            Departments = new Departments
            {
                Engineering = 1, Medicine = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes,
            },
            TractorBeamStrength = 2,
            Talents = new List<string>
            {
                StarshipTalentName.RuggedDesign
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Constitution,
            LaunchYear = 2243,
            Overview = "The symbol of Starfleet in the mid-to-late 23rd century, the Constitution class became legendary due to its five-year missions that expanded the Federation’s borders and its scientific knowledge. The Constitution class became the testbed of new technologies in the early 2270s developed out of the five-year missions and lessons learned from the brief war with the Klingon Empire. The spaceframe continued in service until the mid-24th century.",
            Capabilities = "The Constitution class defined what a starship should be able to accomplish when on extended deep-space exploration assignments. The spaceframe had accommodations for over 400 crew members, enough to provide redundancy for crew positions ranging from astrocartographers to xenobiologists, allowing for crew losses typical on five-year missions. The ship had a spacious shuttlebay and cargo area at the aft of the secondary hull that allowed the class to move large amounts of supplies or personnel even without the use of transporters.",
            RefitsAndVariants = "Vessels produced by other founding members of the Federation tended to focus on their own fleets’ specialties. Andorian-built vessels had larger fusion reactors and Tellarite-built vessels were sought after for their powerful duotronic computer networks. Vulcan-produced vessels focused on improving sensors and communications.",
            NameingConventions = "Constitution-class vessels are often named after famous Earth navy vessels and pre-warp spacecraft. Registry numbers range between 1700 and 1799, though there are exceptions.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.Flagship,
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.ScientificAndSurveyOperations,
                MissionProfileName.StrategicAndDiplomaticOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Constitution class"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 7, Computers = 7, Engines = 8, Sensors = 8, Structure = 7, Weapons = 7
            },
            Departments = new Departments
            {
                Command = 1, Security = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes,
            },
            TractorBeamStrength = 3,
            Talents = new List<string>
            {
                StarshipTalentName.ModularLaboratories,
                StarshipTalentName.RuggedDesign
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.SaucerSeperation
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Crossfield,
            LaunchYear = 2255,
            Overview = "Designed and produced in secret, the Crossfield class was produced solely to test the theoretical “displacement-activated spore hub drive” developed by Doctors Paul Stamets and Justin Straal. The launch of U.S.S. Crossfield in 2255 was a success for starship research and development, but initial tests of the spore drive were unsuccessful. With the limited number of spaceframes produced and the loss of both Glenn and Discovery, only U.S.S. Crossfield was left in service, and further spaceframes had their production cancelled. The Crossfield continued in service with the Starfleet Corps of Engineers until a collision with a sizable piece of an asteroid rendered the vessel unsalvageable. It remained in use as a testbed for new technologies until it was broken up in 2290.",
            Capabilities = "Each starship consisted of a large saucer for a primary hull that included the majority of crew quarters, the bridge, and sickbay. An angular secondary hull contained the engineering areas, including the warp core and two separate impulse reactor rooms. Crossfield had a solid saucer section, but later tests involving the spore drive indicated a large rotating subspace field was required to “activate” the drive. Glenn and Discovery were converted by removing the outermost part of the saucer section and converting it into a rotating ring housing subspace coils; adding fusion reactors to power the coils; and installing heavy shield emitters to protect the crew in the inner ring and command section from the intense subspace field generated by the spore drive.",
            RefitsAndVariants = "The class was not produced in quantities to support a refit program.",
            NameingConventions = "Three known Crossfieldclass vessels were produced, with no pattern of naming conventions among them.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Crossfield class",
                "Experimental"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 7, Computers = 8, Engines = 8, Sensors = 8, Structure = 7, Weapons = 7
            },
            Departments = new Departments
            {
                Engineering = 1, Science = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes,
            },
            TractorBeamStrength = 3,
            Talents = new List<string>
            {
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.HighResolutionSensors,
                StarshipTalentName.ModularLaboratories,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.ClassifiedDesign
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Miranda,
            LaunchYear = 2264,
            Overview = "Starfleet conceived the Miranda class as a dual-purpose patrol and combat vessel to counter the most advanced Klingon D7s. Upon the signing of the Treaty of Organia, manufacturing of the Miranda was halted. A radical redesign was proposed using the systems and design philosophy going into the refit of Constitution-class vessels, and the Miranda was re-welcomed into the fleet as a multipurpose cruiser.",
            Capabilities = "The Miranda class included a photon torpedo launcher mounted on a separate pod at the apex of a “roll-bar.” This made the launchers difficult to repair, but also allowed the addition of aft-facing launch tubes to give the vessel a wider range of fire. The class also included two large shuttle / cargo bays at the aft. This class became seen as a jack of all trades, and saw continual use through the late 24th century.",
            RefitsAndVariants = "Miranda-class vessels received refit programs that followed along paths determined by their typical crew. By the outbreak of the Dominion War, most Miranda-class vessels were nearing the limits of what they could handle, but some received upgrades to quantum torpedoes and a few tested transwarp and quantum slipstream engines.",
            NameingConventions = "Miranda-class vessels take names from nearly every aspect of naval traditions from across the Federation. Empress Sh’Thia XI, Repulse, and Lake Baikal are examples. Registry numbers range as low as 1850 and continue upward.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.ScientificAndSurveyOperations,
                MissionProfileName.TacticalOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Miranda class",
                "Long-serving"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 7, Computers = 8, Engines = 8, Sensors = 8, Structure = 8, Weapons = 8
            },
            Departments = new Departments
            {
                Command = 1, Conn = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes,
            },
            TractorBeamStrength = 3,
            Talents = new List<string>
            {
                StarshipTalentName.ExtensiveShuttlebays
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Oberth,
            LaunchYear = 2269,
            Overview = "Starfleet saw a need for a more dedicated science vessel that could also be deployed on short duration missions to perform detailed biological surveys, assist rescue and recovery operations, and test new technologies. The rapid advancements in technology and engineering techniques meant the Oberth class became increasingly difficult to refit. The class was retired from active deployments in 2310 but continued to be used in a reserve role and for rescue operations well into the late 24th century.",
            Capabilities = "The Oberth class utilized highly efficient warp coils, allowing the vessel to only carry small amounts of antimatter and freeing up more space to be dedicated to sensors and a small shuttlebay at the far forward of the primary hull. The secondary hull, containing planetary survey and subspace scanning equipment, was inaccessible except through access tubes during normal operation.",
            RefitsAndVariants = "The primary refit program for the Oberth class involved improving or replacing the vessel’s already advanced warp coils developed from the Excelsior transwarp project. Refit programs beyond those of the 2280s and 90s saw the Oberth customized more for their specific university or test program than any fleet-wide program.",
            NameingConventions = "Oberth-class vessels are often named after physicists from across the Federation. Newton, Hawking and Von Neumann are examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.ScientificAndSurveyOperations,
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Oberth class"
            },
            Scale = 3,
            Systems = new StarshipSystems
            {
                Comms = 8, Computers = 9, Engines = 7, Sensors = 9, Structure = 6, Weapons = 6
            },
            Departments = new Departments
            {
                Engineering = 1, Science = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserBanks
            },
            TractorBeamStrength = 2,
            Talents = new List<string>
            {
                StarshipTalentName.HighResolutionSensors,
                StarshipTalentName.ImprovedWarpDrive
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Columbia,
            LaunchYear = 2284,
            Overview = "Originally pitched as a long-range, extended endurance class, the Columbia’s initial design sported more efficient warp engines and heavier phaser armament than other classes of similar size. Though relations with the Klingons had not yet escalated to a “hot” war, there had been several skirmishes to mixed success for the Federation. The promise of the Columbia was a ship that was faster and more capable than the B’rel, without increased production requirements. Several Columbia-class starships saw deployment along the far reaches of Federation space in the Beta Quadrant.",
            Capabilities = "The Columbia class has more phaser banks and a slightly higher acceleration curve than other ships of her size, properties that helped the Columbia match the notorious Klingon B’rel-class bird-of-prey. Its warp engines were more efficient too, allowing for a longer uptime at higher warp factors.",
            RefitsAndVariants = "As the Columbia’s development proceeded, some in the Admiralty decried the tactical focus, and demanded the Columbia be supplemented with more scientific equipment. The ship gained a small secondary hull with a large deflector dish and sensitive lateral sensor arrays.",
            NameingConventions = "Columbia-class starships are often named after crewed vehicles from the history of space exploration across Federation worlds. NCC numbers range from 2200-2299.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.Patrol,
                MissionProfileName.ScientificAndSurveyOperations,
                MissionProfileName.TacticalOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Columbia class"
            },
            Scale = 3,
            Systems = new StarshipSystems
            {
                Comms = 8, Computers = 8, Engines = 8, Sensors = 8, Structure = 7, Weapons = 8
            },
            Departments = new Departments
            {
                Conn = 1, Security = 1, Science = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 2,
            Talents = new List<string>
            {
                StarshipTalentName.ImprovedWarpDrive
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.PreferentialTargeting
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Constellation,
            LaunchYear = 2285,
            Overview = "The Constellation class was developed as both a response to increasing tension with the Klingon Empire and to the difficulties in the development of the new transwarp system for Excelsior-class vessels. This class’s intended use never occurred, as the Khitomer Accords were signed soon after the class’s deployment. Instead of being taken out of service, Constellation-class vessels were given different assignments, often acting as first responders to crises across the Federation.",
            Capabilities = "The use of four warp nacelles on starships hadn’t been common in Starfleet prior to the Constellation, but third generation duotronic computer systems allowed greater response time to changes in the warp field and a higher degree of control. The Constellation class used two nacelles actively while utilizing the inactive nacelles’ warp coils to act as field repeaters, allowing the vessel to cruise at higher warp velocities for far less energy.",
            RefitsAndVariants = "Refit programs focused on improving power generation and warp coils and reinforcing the vessel’s structural integrity. During the Dominion War, Constellation-class vessels also had their hulls reinforced.",
            NameingConventions = "Constellation-class vessels are named after astronomers, terms associated with astronomy, constellations, or mythological sky deities. Cassiopeia, Nyx, and Ratri are examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.MultiroleExplorer
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Constellation class"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 8, Computers = 7, Engines = 9, Sensors = 9, Structure = 8, Weapons = 7
            },
            Departments = new Departments
            {
                Conn = 1, Engineering = 1, Security = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 3,
            Talents = new List<string>
            {
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.ImprovedWarpDrive
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.FourNacelleStability
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Excelsior,
            LaunchYear = 2285,
            Overview = "What was originally intended as a testbed for the highly experimental “transwarp” propulsion system, the “Great Experiment” was seen as a disaster after the complete failure of Excelsior’s propulsion systems in 2285. After a total redesign was performed on nearly all ship’s systems, the transwarp propulsion was replaced with standard warp propulsion. The versatile Excelsior spaceframe became a standard sight across the Federation and beyond, and it continued to be manufactured into the 2390s.",
            Capabilities = "Originally intended for the large transwarp coils, the spaceframe’s nacelles provided ample room for extra standard coils that allowed the class to have some of the highest sustained warp speeds for a ship of its size. Stemming from the initial high-power needs for the transwarp system, the spaceframe had nearly double the amount of fusion reactors required for secondary power systems and the impulse drive. These same reactors provide extra power to the ship’s defensive shielding. The Excelsior also had two dedicated shuttlebays, the main shuttlebay and a lower bay on the underside of the secondary hull used for cargo transport and storage.",
            RefitsAndVariants = "A single variant built at San Francisco Shipyards spread across the Federation. While visually similar to the standard spaceframe, the saucer section of the vessel contained double the number of fusion reactors and added two additional impulse drive units. The incredible sublight acceleration this provided meant the secondary hull had two extensions built to contain improvements to the inertial dampeners.",
            NameingConventions = "Excelsior-class vessels take names from concepts of exploration, achievement, and great leaders from across the Federation; many are also named after famous ships from previous generations. Forrest, Archer, and Victory are all examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.StrategicAndDiplomaticOperations,
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Excelsior class",
                "Starfleet Mainstay",
                "Long-serving"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 8, Computers = 7, Engines = 9, Sensors = 8, Structure = 9, Weapons = 8
            },
            Departments = new Departments
            {
                Command = 1, Engineering = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>
            {
                StarshipTalentName.ImprovedWarpDrive,
                StarshipTalentName.SecondaryReactors,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.SaucerSeperation
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Ambassador,
            LaunchYear = 2335,
            Overview = "Starfleet had been relying on Excelsior-class and the few Constitution-class starships still in service to continue its aims of discovery, but even with the planned refits of those spaceframes, they still required visits to logistical hubs every five years as systems wore down. Utopia Planitia Fleet Yards began to develop a new deep-space exploration cruiser that would address these concerns. The Ambassador class was developed and launched, and many of the engineering techniques, design ideas, and technologies created would be refined and become the basis for the Galaxy class.",
            Capabilities = "The Ambassador class was designed in a similar way to previous Starfleet cruisers, with a saucer-shaped primary hull and a cylindrical secondary engineering hull. The most obvious difference is the then-unique warp nacelles containing high-efficiency warp coils with directional subspace buffers. The Ambassador class was wildly successful, but also a victim of its own innovation. Research and development continued on the ground-breaking systems, improving them faster than they could be installed, and it became apparent the Ambassador class wasn’t able to keep up with technological development. Production was halted on further spaceframes, replacing newer construction with the Galaxy class beginning in the 2360s.",
            RefitsAndVariants = "Two separate refit programs were used. The Enterprise program improved the vessel’s subspace communication and sensor platforms. The Pollux program was dedicated to improving the vessel’s weapon systems and warp drive.",
            NameingConventions = "Ambassador-class vessels are often named after important ambassadors and peacemakers, great battles and ships of the past, or hopeful ideas for the future. T’Pau, Merrimack, and Progress are all examples. The U.S.S. Ambassador had a registry of NX/NCC-10521, and subsequent vessels have higher registries.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.ScientificAndSurveyOperations,
                MissionProfileName.StrategicAndDiplomaticOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Ambassador class"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 9, Engines = 9, Sensors = 9, Structure = 9, Weapons = 9
            },
            Departments = new Departments
            {
                Command = 1, Conn = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>
            {
                StarshipTalentName.HighResolutionSensors,
                StarshipTalentName.ImprovedImpulseDrive,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.SaucerSeperation
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.California,
            LaunchYear = 2358,
            Overview = "As the Federation spread in the 2350s, Starfleet saw a lack of vessels able to respond to needs of all kinds inside the borders. Starfleet asked member worlds to design and build their own starship class to be able to respond to issues they felt were pressing to their own interests. Earth presented the California class, which would go on to influence the design of the Galaxy class. California-class vessels were seen as dependable workhorses.",
            Capabilities = "California-class vessels included a dedicated section to provide the growing number of Cetaceans graduating from Starfleet Academy a more natural environment in which to work and live. These vessels also included multiple shuttlebays allowing Cetacean and humanoid crew access to small craft. California-class vessels contained most of their livable volume in their primary saucer-like hull. The secondary hull contained main engineering, primary antimatter storage, and the main deflector array. This entire section could be ejected in an emergency and limited warp propulsion could be maintained by the ship’s fusion reactors.",
            RefitsAndVariants = "Most refits centered on improving the power output of the warp reactor or improving power output from the phaser arrays.",
            NameingConventions = "California-class vessels are named after locations found within the North American state of California. Burbank, Fresno, and West Covina are examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.ColonySupport,
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.LogisticalOrQuartermaster,
                MissionProfileName.ReserveFleet,
                MissionProfileName.ScientificAndSurveyOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "California class"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 10, Computers = 10, Engines = 8, Sensors = 9, Structure = 10, Weapons = 8
            },
            Departments = new Departments
            {
                Engineering = 1, Medicine = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 3,
            Talents = new List<string>
            {
                StarshipTalentName.ExtensiveShuttlebays,
            },
            ChooseOneTalent = new List<string>
            {
                StarshipTalentName.DedicatedPersonnelCommand,
                StarshipTalentName.DedicatedPersonnelConn,
                StarshipTalentName.DedicatedPersonnelEngineering,
                StarshipTalentName.DedicatedPersonnelMedical,
                StarshipTalentName.DedicatedPersonnelScience,
                StarshipTalentName.DedicatedPersonnelSecurity,
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Galaxy,
            LaunchYear = 2359,
            Overview = "The Galaxy class was designed to surpass any exploration and science vessel yet developed by Starfleet. This spaceframe also represented a new philosophy for crew mental well-being on long duration assignments, as Starfleet provided facilities for civilian dependents and volunteers. The concept centered on not separating families from loved ones for years at a time, and the morale on Galaxy-class vessels was correspondingly higher.",
            Capabilities = "As one of the largest spaceframes manufactured by Starfleet, the interior volume of was often not fully allocated by the time it began its first mission assignment. This modular customization meant these vessels often had civilian specialists on board for even the most obscure research paths. As the Galaxy class was meant to probe far away from Federation space, the vessel had both the most powerful warp core of its day and the most advanced warp coils, allowing even a ship of its size to maintain a cruising warp velocity of 6 and a maximum velocity of warp 9.8. Galaxy class vessels were also the first that could separate and re-dock their primary hull to the engineering hull without the assistance of a drydock or support vessels. This meant Galaxy-class vessels could split their focus efficiently, or put civilians and dependents out of harm’s way in hostile situations.",
            RefitsAndVariants = "During the Dominion War, Galaxy-class vessels nearing completion were repurposed as command-and-control vessels for rear admirals to use in fleet actions.",
            NameingConventions = "Galaxy-class vessels take their names from many different cultures across the Federation. Most are associated with exploration and scientific discovery. Odyssey, Hanson, and Surok are examples. The U.S.S. Galaxy was NX/NCC-70637, and all vessels of the class have registries higher than this, barring the Enterprise, which used its own legacy number.",
            SuggestedMissionProfiles = new List<string>
            {

                MissionProfileName.MultiroleExplorer,
                MissionProfileName.Flagship,
                MissionProfileName.ScientificAndSurveyOperations,
                MissionProfileName.StrategicAndDiplomaticOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Galaxy class",
                "A City in Space"
            },
            Scale = 6,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 10, Engines = 10, Sensors = 8, Structure = 10, Weapons = 10
            },
            Departments = new Departments
            {
                Command = 1, Medicine = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 5,
            Talents = new List<string>
            {
                StarshipTalentName.ModularLaboratories,
            },
            ChooseOneTalent = new List<string>
            {
                StarshipTalentName.RedundantSystemsComms,
                StarshipTalentName.RedundantSystemsComputers,
                StarshipTalentName.RedundantSystemsEngines,
                StarshipTalentName.RedundantSystemsSensors,
                StarshipTalentName.RedundantSystemsStructure,
                StarshipTalentName.RedundantSystemsWeapons,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.AbundantPersonnel,
                StarshipSpecialRuleName.SaucerSeperationAndReconnection,
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Nebula,
            LaunchYear = 2361,
            Overview = "During the development of the Galaxy class, Starfleet felt that it could make the next evolutionary step of the Miranda class based on the design elements of the future flagship class, in the same way the Miranda had incorporated elements from the Constitution class refit. The Nebula would prove to be even more adaptable than the Miranda, but full-scale replacement of the older class became impossible with the outbreak of the Dominion War.",
            Capabilities = "Internally, the Nebula had less mission- adaptable volume than her sister class, but the rollbar mount was much stronger structurally and provided more EPS connections. This allowed a far wider selection of modular pods to be made available for use.",
            RefitsAndVariants = "Most Nebula-class vessels went through a single refit cycle before the outbreak of the Dominion War, the standard being improvements in the sensitivity of their sensor platforms.",
            NameingConventions = "Nebula-class vessels take their names from across the Federation, based on famous ships from the past. Bennion, Beagle, and Golden Hind are examples. Most Nebula-class vessels have registry numbers over 60000; a few have much lower numbers, indicating production at smaller, less-used shipyards.",
            SuggestedMissionProfiles = new List<string>(),
            Traits = new List<string>
            {
                "Federation Starship",
                "Nebula class",
                "Adaptable"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 10, Engines = 10, Sensors = 8, Structure = 9, Weapons = 9
            },
            Departments = new Departments
            {
                Engineering = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>(),
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.MissionPod,
                StarshipSpecialRuleName.SaucerSeperationAndReconnection,
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Akira,
            LaunchYear = 2368,
            Overview = "In the aftermath of the Battle of Wolf 359, Starfleet saw the need for a heavily armed and combat-capable starship to perform patrol assignments and maintain a constant presence in a sector of space, but still contribute to exploration and discovery. When updated with the latest technologies, U.S.S. Akira was so successful in its initial patrols that Starfleet immediately ordered the class into wide production.",
            Capabilities = "The vessel is designed to present the smallest sensor profile possible to augment the small surface area for its defensive shields. The sloped surfaces of the outer hull were augmented with ablative duranium armor plating, providing additional protection to key systems and power distribution nodes. The ship’s weapons pod, located between its large “pontoons” that were attached to the saucer and also mounted to the vessel’s warp nacelles, contained the same phaser arrays and forward and aft firing photon torpedo systems. The vessel was also designed with spacious flight decks and maintenance areas, allowing it to deploy runabouts and fighters.",
            RefitsAndVariants = "The 2378 refit program involved installation of bioneural computer pathways to augment its isolinear core.",
            NameingConventions = "Akira-class vessels are often named after famed or fictional warriors or fighting vessels, particularly those who stood against impossible odds, or after places where such battles were fought. Thermopylae, Gawain, and Argo are some examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.Battlecruiser,
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.TacticalOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Akira class",
                "Extensive Tactical Systems"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 9, Engines = 9, Sensors = 8, Structure = 10, Weapons = 11
            },
            Departments = new Departments
            {
                Command = 1, Security = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>
            {
                StarshipTalentName.AblativeArmor,
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.RapidFireTorpedoLauncher
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.SpecializedShuttlebay
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Nova,
            LaunchYear = 2368,
            Overview = "Starfleet Command and the Federation Science Council formed a committee in 2363 to discuss the state of Starfleet’s aging science and exploration vessels. The conclusion was Starfleet required a new easy to maintain science and exploration vessel, equipped with the latest sensors and scientific gear. The Nova class went on to be the inspiration for the Intrepid class, and the lessons learned influenced Starfleet designers for decades to come.",
            Capabilities = "Two standard isolinear computer cores were included to help maintain control over the ship’s small warp field, generated from subspace- friendly warp coils but mounted in standard nacelle housings. These computers had powerful subspace fields, allowing even faster processing time for the vessel’s integrated sensor networks. The Nova class was a superb scientific research vessel, but at the expense of creature comforts.",
            RefitsAndVariants = "Starfleet’s refit plans for the Nova class included replacement of the vessel’s warp coils with smaller and more efficient systems.",
            NameingConventions = "Nova-class vessels take names from astronomical and astrological terms from the many languages of the Federation, and place names from the worlds that manufacture the spaceframes. Nova-class starships use registry numbers that begin in the 72300s.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.ScientificAndSurveyOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Nova class",
                "Efficient but Austere"
            },
            Scale = 3,
            Systems = new StarshipSystems
            {
                Comms = 10, Computers = 10, Engines = 9, Sensors = 10, Structure = 8, Weapons = 8
            },
            Departments = new Departments
            {
                Engineering = 1, Science = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 2,
            Talents = new List<string>
            {
                StarshipTalentName.AdvancedSensorSuites
            },
            SpecialRules = new List<string>(),
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Defiant,
            LaunchYear = 2371,
            Overview = "As Starfleet had little experience in designing a warship from the ground up, the development of the Defiant class began after the destruction of the fleet at Wolf 359 by the Borg in 2367 and wouldn’t see the construction of the first spaceframe until 2371—and only then after delays and massive redesigns, as new technology was developed to fight the Borg. Defiant class vessels served in Starfleet into the early 25th century, often as scouts.",
            Capabilities = "The Defiant-class vessel consisted of a single flattened hull to provide as small a silhouette as possible to protect against incoming fire. Developments from Starfleet Research and Development meant the phaser arrays, pulsed phaser cannons, and rapid-fire torpedo systems operated without losing maneuvering power. In order to keep the compact silhouette, the vessel’s nacelles were integrated into the vessel. These starships required just 50 crew and were cramped, not designed for long-duration assignments.",
            RefitsAndVariants = "Starfleet continued to improve reactor output and structural integrity fields through the last decades of the 24th century, adding to the vessel’s survivability in fleet engagements.",
            NameingConventions = "Defiant-class starships are often named for adjectives in the languages of the Federation associated with honorable combat and heroism. Courageous, Dauntless, and Resolute are examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.EspionageOrIntelligence,
                MissionProfileName.TacticalOperations,
                MissionProfileName.Patrol,
                MissionProfileName.ReconnaissanceOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Defiant class",
                "Warship"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 9, Engines = 8, Sensors = 9, Structure = 8, Weapons = 13
            },
            Departments = new Departments
            {
                Conn = 1, Security = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PulsePhaserCannons,
                StarshipWeaponName.PhotonTorpedoes,
                StarshipWeaponName.QuantumTorpedoes,
            },
            TractorBeamStrength = 2,
            Talents = new List<string>
            {
                StarshipTalentName.AblativeArmor
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.LandingGear
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Intrepid,
            LaunchYear = 2371,
            Overview = "Containing the best technology of the early 2370s and evolved from the Nova class’s design, the Intrepid class was a symbol of the Federation Science Council’s intent to have Starfleet return to its goals of exploration and science. The Dominion War reduced the number of hulls constructed, but the end of the war—and the return of U.S.S. Voyager in 2378—meant renewed passion for this spaceframe. Many Intrepidclass vessels remain in active service well into the 25th century.",
            Capabilities = "The Intrepid class was designed around being as efficient in its warp field geometry as possible, while also allowing for rapid transit of turbulent space-time. The vessel also has variable geometry warp nacelles that allow fine adjustment to the warp field, improving warp stability, allowing high sustained warp speeds, and granting an impressive maximum emergency speed of warp 9.975. Intrepid-class vessels were the first to have bioneural computer components installed to augment the advanced isolinear computer core. These bioneural systems allowed the ship to “learn” as it formed data connections in a more efficient way than standard isolinear indexing.",
            RefitsAndVariants = "Refits for the Intrepid class focused on improving and expanding the sensor platforms.",
            NameingConventions = "Intrepid-class vessels take names from mythology and space exploration across the Federation. Pathfinder, Odysseus, and Bellerophon are some examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.ScientificAndSurveyOperations,
                MissionProfileName.TechnicalTestbed
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Intrepid class",
                "Advanced Warp Drive"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 11, Engines = 11, Sensors = 10, Structure = 8, Weapons = 8
            },
            Departments = new Departments
            {
                Conn = 1, Engineering = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes,
            },
            TractorBeamStrength = 3,
            Talents = new List<string>
            {
                StarshipTalentName.AdvancedSensorSuites,
                StarshipTalentName.EmergencyMedicalHologram,
                StarshipTalentName.ImprovedWarpDrive
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.LandingGear
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Sovereign,
            LaunchYear = 2371,
            Overview = "The Sovereign class began development in 2368 after Starfleet Command felt that starships probing deep space would need to be better equipped to handle hostile and more technologically advanced races such as the Borg. The first vessels were launched in the months before the conflict with the Klingon Empire began. After the Dominion War, these vessels became a part of Starfleet’s renewed push to return to exploration and research.",
            Capabilities = "The Sovereign class utilizes variable geometry warp drive, able to replicate the same qualities of the Intrepid class’s variable pitch warp nacelles without the adjustable pylons. The Sovereign class has extensive laboratories, sensor systems, and subspace transmitters that make it an excellent deep-space explorer. The design includes significant firepower, including a dedicated quantum torpedo launcher and multiple Type-10a phaser strips.",
            RefitsAndVariants = "One major variant was designed and constructed at the Andorian Imperial Ship Yards, named Sheetar, NCC-73850. The Andorian engineers who designed her wanted to show a ship of exploration could also double as a combat vessel when needed.",
            NameingConventions = "Sovereign-class vessels are often named after famous ships from Federation history. Farragut, Wasp, and Shran are all examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.StrategicAndDiplomaticOperations,
                MissionProfileName.ScientificAndSurveyOperations,
                MissionProfileName.MultiroleExplorer
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Sovereign class"
            },
            Scale = 6,
            Systems = new StarshipSystems
            {
                Comms = 10, Computers = 9, Engines = 10, Sensors = 10, Structure = 10, Weapons = 10
            },
            Departments = new Departments
            {
                Command = 1, Security = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes,
                StarshipWeaponName.QuantumTorpedoes
            },
            TractorBeamStrength = 5,
            Talents = new List<string>
            {
                StarshipTalentName.CommandShip,
                StarshipTalentName.EmergencyMedicalHologram,
                StarshipTalentName.ImprovedWarpDrive
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.SaucerSeperation
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Luna,
            LaunchYear = 2372,
            Overview = "With the design success of the Intrepid class, Starfleet began the parallel development of an explorer capable of the same exploratory and scientific assignments, but with larger research facilities, more computer processing power, and longer mission duration. The Luna class exited its design phase eight months after her sister class, and while there were engineering delays, U.S.S. Luna slipped her drydock over Mars in late 2372. Further delays occurred because of the outbreak of war between the Klingon Empire, and later, the Dominion. While the Luna class was approved for production, further vessels weren’t launched until 2375.",
            Capabilities = "The Luna class is equipped with variable geometry warp nacelles, allowing the starship to maintain warp field stability in turbulent space-time and to generate a subspace field with less power. This allows the Luna class a cruising speed of warp 7 and a maximum speed of warp 9.975. Like the Intrepid class, these vessels are designed to incorporate holo-emitters in sickbay to facilitate an Emergency Medical Hologram, but these emitters are also installed in mission-critical areas of the ship. Unlike its sister class, the Luna class has a modular equipment pod.",
            RefitsAndVariants = "Refits expand the vessel’s phaser capacitors to improve fire rate and duration. One Luna, the U.S.S. Enceladus, was heavily modified to be staffed entirely by Cetacean officers and crew and became the lead ship of three vessels of the Enceladus subclass.",
            NameingConventions = "Luna-class vessels are named after moons, with the earliest vessels in the class using the names of moons from the Sol system. Deimos, Uriel, and Oberon are examples. Registry numbers in the 80100s are commonplace.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Luna class"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 10, Computers = 10, Engines = 10, Sensors = 10, Structure = 8, Weapons = 8
            },
            Departments = new Departments
            {
                Engineering = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes,
                StarshipWeaponName.QuantumTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>
            {
                StarshipTalentName.AdvancedResearchFacilities,
                StarshipTalentName.AdvancedSensorSuites,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.MissionPod
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.ConstitutionIII,
            LaunchYear = 2396,
            Overview = "The first Constitution III-class ships entered service in 2396, after a short development period. Many of the earliest vessels of the class had their construction accelerated by repurposing many components from vessels which had suffered catastrophic damage or were otherwise being decommissioned. The overall design of the Constitution III-class, however, owes more to a different legacy. Often referred to as the Neo-Constitution, the design resembles the Constitution-class ships of the 23rd century, particularly the refit (or Constitution II) design which entered service in 2270.",
            Capabilities = "Constitution III-class ships are built to function as versatile exploratory craft, able to fulfill a wide range of mission objectives. The design and construction coincided with new developments in propulsion technology, which were integrated into the project development; the result is a class with the highest Impulse power-to-geometry ratio in the fleet, and a top speed of warp 9.99. This makes it ideal for rapidly responding to emergencies and changing circumstances in densely populated regions.",
            RefitsAndVariants = "The class is often regarded more as a refit project than a dedicated class, blurring the line between creating a new ship and rebuilding an existing one.",
            NameingConventions = "Constitution III-class vessels are mostly named after previous Starfleet vessels, often the ones which contributed components to the new design, such as the Titan.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.StrategicAndDiplomaticOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Constitution III class",
                "Legacy Components"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 10, Engines = 11, Sensors = 10, Structure = 10, Weapons = 10
            },
            Departments = new Departments
            {
                Conn = 1, Engineering = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>
            {
                StarshipTalentName.ExtensiveShuttlebays,
                StarshipTalentName.ImprovedImpulseDrive,
                StarshipTalentName.ImprovedWarpDrive,
            },
            SpecialRules = new List<string>(),
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Odyssey,
            LaunchYear = 2398,
            Overview = "Following encounters with the massive starships fielded by the Borg, Dominion, and Remans, Starfleet planners were concerned Starfleet was falling behind on defensive and offensive capability. In response, the Admiralty invested in Starfleet’s own iteration of a massive star cruiser that could compete. The project yielded the U.S.S. Odyssey, the U.S.S. Verity, and eventually the Starship Enterprise, NCC-1701-F.",
            Capabilities = "The Odyssey class represents a significant evolutionary advancement in the tradition of Starfleet multi-role cruisers. Requiring a crew of 1,600 and an emergency capacity of over 10,000, the Odyssey was designed to tackle any mission. Its suite of active and passive sensor arrays is one of the most advanced in Starfleet, and it is impressively armed. Its massive Yoyodyne 46A warp core powers both a standard warp drive and an experimental quantum slipstream burst drive. In addition, the Odyssey has an Aquarius embedded escort. The Aquarius escort is a small ship assigned to its parent Odyssey and docked in a bay in the aft of its mothership. Its crew is part of the Odyssey’s crew, and it operates at the captain’s discretion. The Aquarius offers additional tactical flexibility, especially when deployed during a saucer separation maneuver.",
            RefitsAndVariants = "After the Romulan supernova, Starfleet began a program to modernize and update several Odyssey hulks involved in heavy fighting along the former border with rogue elements of the Romulan Navy. Starfleet decided on three different sub-classes for the refits, each specializing in a different mission profile. The Endeavour subclass’s focus was on tactical operations. The Sojourner’s focus was on engineering and operational support. The Yorktown was focused on exploration and scientific discovery. The Enterprise-F received the Yorktown refit after taking heavy damage in the Battle at Midnight.",
            NameingConventions = "The Odyssey is named in honor of both Odysseus’s original daring voyage and other Starfleet ships. As Starfleet’s flagship class of the 25th century, other Odyssey-class ships inherit names from renowned vessels.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.Flagship,
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.StrategicAndDiplomaticOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Odyssey class",
                "Mobile Starbase"
            },
            Scale = 7,
            Systems = new StarshipSystems
            {
                Comms = 10, Computers = 11, Engines = 10, Sensors = 10, Structure = 11, Weapons = 10
            },
            Departments = new Departments
            {
                Command = 1, Engineering = 1, Security = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.QuantumTorpedoes
            },
            TractorBeamStrength = 6,
            Talents = new List<string>
            {
                StarshipTalentName.CommandShip,
                StarshipTalentName.ImprovedWarpDrive,
                StarshipTalentName.RedundantSystemsEngines,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.AquariusEscort,
                StarshipSpecialRuleName.QuantumSlipstreamBurstDrive,
                StarshipSpecialRuleName.SaucerSeperationAndReconnection
            },
            Weight = 1
        },
        new()
        {
            Name = SpaceframeName.Sagan,
            LaunchYear = 2401,
            Overview = "The Sagan class served as a testing ground for new technologies derived from research into “the Artifact,” a derelict Borg Cube found in the Beta Quadrant in the 2380s and studied by a joint Federation and Romulan research project. Borg technology had been integrated into Starfleet vessels on a smaller scale before, but it had taken nearly two decades of study and testing before Starfleet was willing to adopt such advancements on a wider scale.",
            Capabilities = "The spaceframe is heavily reinforced and integrates extensive multiphasic shielding to protect the crew from radiation and other spatial phenomena. Borg technology allows the weapons to be more potent and more efficient relative to their size and power draw. The class boasts a sustained cruising speed of warp 7.8, and nearly double the endurance for long-duration warp flight than any other class.",
            RefitsAndVariants = "The technologies involved in developing the Sagan-class are new and the impact of them in the field is still being tested and analyzed. However, Starfleet committed to the production of this class, with over a dozen already in active service as of 2401 and several more under construction.",
            NameingConventions = "Sagan-class vessels are commonly named after terms relating to exploration, and after notable figures in space science and exploration. The first vessel of the class was the U.S.S. Stargazer (NCC-82893). Pioneer, Hathaway, and Hubble are other examples.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.ScientificAndSurveyOperations,
            },
            Traits = new List<string>
            {
                "Federation Starship",
                "Sagan class",
                "Borg Technology"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 10, Computers = 10, Engines = 11, Sensors = 11, Structure = 10, Weapons = 9
            },
            Departments = new Departments
            {
                Conn = 1, Engineering = 1, Science = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.PhaserArrays,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>
            {
                StarshipTalentName.AdvancedSensorSuites,
                StarshipTalentName.AdvancedShields,
                StarshipTalentName.ImprovedWarpDrive,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.FourNacelleStability
            },
            Weight = 1
        },

        // KLINGON
        new()
        {
            Name = SpaceframeName.D7,
            LaunchYear = 2257,
            Overview = "The Klingon fleets of the mid-23rd century were a scattered collection of individual House fleets up until the late 2250s. After the ascension of Chancellor L’Rell of House Mo’Kai, the Klingon Empire began a concerted fleet reconstruction effort, consolidating military power with the Klingon Defense Force. Central to this was a ship design presented by the Chancellor as a new symbol of Klingon unity: this design would become known as the D7 Battlecruiser, and it would remain as the cornerstone of Klingon military might in space for decades to come.",
            Capabilities = "The D7 continues the long design traditions of the KDF by having a command pod at the end of a long detachable boom that connects to the engineering hull. With the primary purpose of the D7 being war, the weapon systems on board had top priority for the use of internal volume. Two separate photon torpedo launchers provide the spaceframe’s primary destructive capabilities.",
            RefitsAndVariants = "Refits for the D7, and its successor the K’t’inga-class depended greatly on if it was in service to the KDF or a Great House. One major development was the reintroduction of cloaking to the fleet in 2269.",
            NameingConventions = "Klingon vessels have little in the way of standard naming conventions. Each House has its own traditions, as does the KDF.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.Battlecruiser,
                MissionProfileName.StrategicAndDiplomaticOperations,
                MissionProfileName.ReserveFleet,
            },
            Traits = new List<string>
            {
                "Klingon Starship",
                "D7 class",
                "Symbol of Klingon Unity"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 7, Computers = 7, Engines = 8, Sensors = 5, Structure = 8, Weapons = 9
            },
            Departments = new Departments
            {
                Conn = 1, Security = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.DisruptorCannons,
                StarshipWeaponName.PhaserBanks,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 3,
            Talents = new List<string>
            {
                StarshipTalentName.RuggedDesign
            },
            Weight = 0
        },
        new()
        {
            Name = SpaceframeName.Brel,
            LaunchYear = 2280,
            Overview = "Before K’tinga discovered the Romulan treachery with trading faulty cloaking devices, the engineers in the KDF began designing a starship capable of using the faulty cloaking device as is. It was determined that a bird-of-prey design similar to the Vo’n’talk class would provide the ideal form for the new vessel, and the first B’rel launched in 2280.",
            Capabilities = "The forward command pod contains the bridge and large captain’s quarters that contained an area dedicated to either a targ-pit or gagh breeding tub so the commanding officer may always have fresh food. The majority of the small crew lived and worked in the engineering hull. The power generated from the multistage fusion reactors give the class an impressive sublight acceleration and a top warp velocity of 9.9 for a short duration. While the cloak is active, the drain on power is extreme, and cruising warp velocities are reduced to warp 5.",
            RefitsAndVariants = "Engineers continued to improve the cloaking devices through the 23rd and early 24th centuries, allowing for greater warp speeds while cloaked. Improvements to weapons systems and targeting arrays were also prioritized.",
            NameingConventions = "Klingon vessels have little in the way of standard naming conventions. Each House has its own traditions, as does the KDF.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.CrisisAndEmergencyResponse,
                MissionProfileName.Patrol,
                MissionProfileName.TacticalOperations,
            },
            Traits = new List<string>
            {
                "Klingon Starship",
                "Bird of Prey",
                "B’rel class",
                "Agile Raider"
            },
            Scale = 3,
            Systems = new StarshipSystems
            {
                Comms = 8, Computers = 7, Engines = 9, Sensors = 7, Structure = 7, Weapons = 9
            },
            Departments = new Departments
            {
                Conn = 1, Security = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.DisruptorCannons,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 2,
            Talents = new List<string>
            {
                StarshipTalentName.CloakingDevice,
                StarshipTalentName.FastTargetingSystems,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.LandingGear                
            },
            Weight = 0
        },
        new()
        {
            Name = SpaceframeName.VorCha,
            LaunchYear = 2367,
            Overview = "Peace with the Federation and the static border with the Romulan Star Empire during the first half of the 24th century led the KDF to become complacent with battle cruiser design. With some stunning tactical defeats with the Gorn Hegemony, the Chancellor ordered the KDF to design a new vessel, impressive enough to be a flagship for the Empire. Rapid advancements in warp core design, computer technology, and sensor systems from the Empire’s friendship with the Federation meant the design of the Vor’cha class kept undergoing revisions.",
            Capabilities = "The Vor’cha continues the tradition of the KDF having its battle cruisers consist of a command pod at the end of a long boom and an engineering hull. The Vor’cha could separate just the command pod. The engineering hull also has a ‘flying bridge’ in a triangular section that can take over command and control functions from the forward bridge. Other weapon systems installed include disruptor cannons on the warp nacelles, two torpedo tubes in the command pod, two tubes in the engineering hull, and two tubes straddling the shuttle bay. Each Vor’cha-class vessel could accommodate nearly 2,000 warriors.",
            RefitsAndVariants = "The KDF debated the priority for the first refit cycle of the Vor’cha class. While some generals felt that additional subspace communication relays and boosted transmission strength was needed for properly utilizing this class against enemies as advanced as the Dominion, others felt that all problems can be solved with the installation of additional disruptor cannons.",
            NameingConventions = "Klingon vessels have little in the way of standard naming conventions. Each House has its own traditions, as does the KDF.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.Battlecruiser,
                MissionProfileName.StrategicAndDiplomaticOperations,
                MissionProfileName.TacticalOperations,
            },
            Traits = new List<string>
            {
                "Klingon Starship",
                "Vor'cha class",
                "Formidable Reputation"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 9, Engines = 10, Sensors = 9, Structure = 10, Weapons = 10
            },
            Departments = new Departments
            {
                Command = 1, Security = 2
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.DisruptorCannons,
                StarshipWeaponName.DisruptorBanks,
                StarshipWeaponName.PhotonTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>
            {
                StarshipTalentName.CloakingDevice,
                StarshipTalentName.FastTargetingSystems,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.AbundantPersonnel
            },
            Weight = 0
        },

        // ROMULAN
        new()
        {
            Name = SpaceframeName.TLiss,
            LaunchYear = 2260,
            Overview = "For the hundred years since the Earth-Romulan War, the Empire had continued to improve its weapon systems and ship building capabilities. Covert acquisition of duotronic technology from the Federation meant a new generation of warbirds would need to be built. The Romulan Senate gave approval to the Imperial Navy’s design that harkened back to the older birds-of-prey used against the Coalition of Planets, with the first leaving Romulus orbit in late 2265, and first being seen by the Federation in 2266. The T’Liss class would continue to be manufactured by the Empire into the early 24th century.",
            Capabilities = "T’Liss class birds of prey are larger vessels than their older counterparts. Four decks and crewed by 170, the vessel is both compact and uses much of its habitable space efficiently through shared bunks in officer and enlisted quarters. This highly compact habitable space is needed as the powerful plasma torpedo system takes up nearly half the internal volume of the vessel, with a significant percentage of the remaining space taken by the ship’s paired matter/ antimatter warp cores and dual fusion reactors. The ship also used a small and effective cloaking device that was tied into the vessel’s shield emitters to reduce power demands.",
            RefitsAndVariants = "Romulan engineers continually improved the power output of their matter/antimatter reactors and reduced the power needs of the plasma torpedo system to the point that only a single reactor was needed.",
            NameingConventions = "T’Liss warbirds are named after powerful senators the navy wished to gain favor with, and concepts of martial prowess.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.EspionageOrIntelligence,
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.TacticalOperations,
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "Romulan Starship",
                "T’Liss class",
                "Bird of Prey",
                "Experimental"
            },
            Scale = 4,
            Systems = new StarshipSystems
            {
                Comms = 6, Computers = 8, Engines = 7, Sensors = 9, Structure = 7, Weapons = 9
            },
            Departments = new Departments
            {
                Conn = 1, Engineering = 1, Security = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.DisruptorBanks,
                StarshipWeaponName.PlasmaTorpedoes
            },
            TractorBeamStrength = 3,
            Talents = new List<string>
            {
                StarshipTalentName.CloakingDevice,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.Prototype
            },
            Weight = 0
        },
        new()
        {
            Name = SpaceframeName.DDeridex,
            LaunchYear = 2350,
            Overview = "The Romulan Empire kept to itself through the first half of the 24th century, continually expanding its borders away from the Federation. Using ideas gleaned from the Klingon Empire’s trade of D7s in the late 2260s and further native technological advances, the Empire produced the D’Deridex class warbird beginning in 2350. The D’Deridex was successful enough that the Empire continued to produce it until the shipyards capable of building them were destroyed in the Romulan supernova.",
            Capabilities = "The massive spaceframe utilizes two different types of warp coil design. At each side standard warp nacelles and coils produce the warp field, but monopolar subspace field generators installed across the dorsal and ventral ‘wings’ of the vessel provide stability while at high warp velocities. This class is the first vessel of its size to be powered by an artificial quantum singularity, essentially a subspace compressed mass replicating a black hole on a small scale. The immense amount of power this can produce is augmented by standard fusion reactors and allows the ship to move at speeds of warp 9.6, and warp 6 even while under cloak.",
            RefitsAndVariants = "Refits leading into the Dominion War saw improvements to weapon and sensor systems. Plans for improving the quantum singularity reactor were begun in the 2380s but halted with the destruction of the Romulan star system.",
            NameingConventions = "D’Deridex names include famous starship commanders from Romulan history and important Imperial worlds.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.Battlecruiser,
                MissionProfileName.MultiroleExplorer,
                MissionProfileName.EspionageOrIntelligence,
                MissionProfileName.TacticalOperations,
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "Romulan Starship",
                "D'Deridex class",
                "Imposing"
            },
            Scale = 7,
            Systems = new StarshipSystems
            {
                Comms = 8, Computers = 9, Engines = 10, Sensors = 10, Structure = 11, Weapons = 9
            },
            Departments = new Departments
            {
                Command = 1, Engineering = 1, Security = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.DisruptorBanks,
                StarshipWeaponName.PlasmaTorpedoes
            },
            TractorBeamStrength = 5,
            Talents = new List<string>
            {
                StarshipTalentName.CloakingDevice,
            },
            SpecialRules = new List<string>
            {
                StarshipSpecialRuleName.AbundantPersonnel
            },
            Weight = 0
        },
        new()
        {
            Name = SpaceframeName.Mogai,
            LaunchYear = 2374,
            Overview = "With the D’deridex class warbird approaching two decades old, the Romulan Empire began prototyping a new warbird design. The success of these early vessels in the Shackleton Expanse, and then as assault ships against the Breen Confederacy during the Dominion War, led to large-scale production in 2376. Refit plans were scrapped as Praetor Shinzon took control of the Empire. After his defeat, the Imperial Navy wished to focus on rebuilding its forces but the shipyards capable of producing the new warbird were destroyed in the Romulan supernova, and it is uncertain if this class will resume production.",
            Capabilities = "The Mogai was powered by an artificial quantum singularity, providing ample power for all primary systems and allowing cruising speeds of warp 7.1, and even with the cloaking device active, warp 6.8. Enough mass was forced into the singularity to allow normal operations for up to four years, but extra mass was collected via ramscoops along the leading edges of the vessel’s wings.",
            RefitsAndVariants = "The Imperial Navy had planned on improving the class’s subspace communication gear to range further from the Imperial core, but these plans were shelved.",
            NameingConventions = "Mogai-class vessels take their names from sea birds found across the Empire, as well as influential families who lost children during the Dominion War.",
            SuggestedMissionProfiles = new List<string>
            {
                MissionProfileName.Battlecruiser,
                MissionProfileName.EspionageOrIntelligence,
                MissionProfileName.PathfinderAndReconnaissanceOperations,
                MissionProfileName.TacticalOperations,
                MissionProfileName.TechnicalTestbed,
            },
            Traits = new List<string>
            {
                "Romulan Starship",
                "Mogai class",
                "Warbird"
            },
            Scale = 5,
            Systems = new StarshipSystems
            {
                Comms = 9, Computers = 9, Engines = 10, Sensors = 10, Structure = 10, Weapons = 10
            },
            Departments = new Departments
            {
                Conn = 1, Engineering = 1, Security = 1
            },
            Weapons = new List<string>
            {
                StarshipWeaponName.DisruptorBanks,
                StarshipWeaponName.PlasmaTorpedoes
            },
            TractorBeamStrength = 4,
            Talents = new List<string>
            {
                StarshipTalentName.CloakingDevice,
            },
            Weight = 0
        },
    };
}
