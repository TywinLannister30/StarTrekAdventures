using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public class NpcSelector
{
    public static NonPlayerCharacter GetNonPlayerCharacter(string name)
    {
        var selectedNpc = NonPlayerCharacters.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

        var npc = new NonPlayerCharacter(selectedNpc);

        foreach (var weapon in npc.Attacks)
            weapon.SetEffect(npc);

        return npc;
    }

    internal static List<NonPlayerCharacter> GetAllNonPlayerCharacters()
    {
        var selectedNpcs = NonPlayerCharacters;

        var npcs = new List<NonPlayerCharacter>();

        foreach (var selectedNpc in selectedNpcs)
        {
            var npc = new NonPlayerCharacter(selectedNpc);

            foreach (var weapon in npc.Attacks)
                weapon.SetEffect(npc);

            npcs.Add(npc);
        }

        return npcs;
    }

    private static readonly List<NonPlayerCharacter> NonPlayerCharacters = GetAllNonPlayerCharactersList();

    private static List<NonPlayerCharacter> GetAllNonPlayerCharactersList()
    {
        var allTalents = new List<NonPlayerCharacter>();
        allTalents.AddRange(GetStarfleetNpcs());
        allTalents.AddRange(GetFederationNpcs());
        allTalents.AddRange(GetKlingonNpcs());
        allTalents.AddRange(GetRomulanNpcs());
        allTalents.AddRange(GetCardassianNpcs());
        allTalents.AddRange(GetFerengiNpcs());
        allTalents.AddRange(GetDominionNpcs());
        allTalents.AddRange(GetCreatures());
        return allTalents;
    }

    private static IEnumerable<NonPlayerCharacter> GetStarfleetNpcs()
    {
        return new List<NonPlayerCharacter>
        {
            new()
            {
                Name = "Cadet",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "The next generation of Starfleet officers can be found both at Starfleet Academy, and on field assignments (“cadet cruises”) aboard starships and starbases. This gives them practical experience while they continue studying. A little over-eager to please their superiors, with rules and regulations at their fingertips, cadets need guidance as they become young officers."
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Cadet"
                },
                RandomSpecies = true,
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 8, Insight = 8, Presence = 8, Reason = 8 },
                Departments = new Departments { Command = 1, Conn = 1, Engineering = 1, Security = 1, Medicine = 1, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "Gamemaster's Note",
                        Description = new List<string>
                        {
                            "Add 1 point to two different department ratings to create different types (e.g., +1 to Engineering and Conn for a conn cadet)."
                        },
                        HideIfGenerating = true,
                        AddOneToTwoDifferentDepartments = true,
                        Source = BookSource.CommandDivision1stEdition,
                    }
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Engineering Specialist",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "An engineering specialist, or systems engineer, is a Starfleet engineer with a particular Focus. These individuals are often brought aboard a starship or starbase to facilitate repairs or upgrades in a particular area, such as the warp fields, computing, replicators and transporters, phasers, or torpedo technology. Their knowledge often strays into the theoretical too, and commissioned Starfleet officers who are deemed “specialists” are often pioneers in their own field of expertise."
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Enlisted Personnel"
                },
                RandomSpecies = true,
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 8, Insight = 8, Presence = 7, Reason = 9 },
                Departments = new Departments { Command = 1, Conn = 1, Engineering = 2, Security = 1, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Field of Expertise",
                        Description = new List<string>
                        {
                            "The NPC has a single focus from the following fields of engineering or science, even though they are minor NPCs. When this NPC attempts a task using that focus, the first bonus d20 is free: Warp fields, Electro-plasma power systems, Structural integrity fields, Energy-matter-scrambler technology, Quantum mechanics"
                        },
                        HideIfGenerating = true,
                        AddRandomFocus = new List<string>
                        {
                            Focus.ElectroPlasmaPowerSystems, "Energy-matter-scrambler technology", Focus.QuantumMechanics, "Structural integrity fields", "Warp fields"
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Starfleet Officer",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "A typical Starfleet officer."
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Officer"
                },
                RandomSpecies = true,
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 10, Daring = 10, Fitness = 8, Insight = 8, Presence = 9, Reason = 9 },
                Departments = new Departments { Command = 1, Conn = 1, Engineering = 1, Security = 1, Medicine = 1, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType2, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "Gamemaster's Note",
                        Description = new List<string>
                        {
                            "Add 1 point to two different department ratings to create different types (e.g., +1 to Engineering and Conn for a conn officer)."
                        },
                        HideIfGenerating = true,
                        AddOneToTwoDifferentDepartments = true,
                    }
                }
            },
            new()
            {
                Name = "Academy Instructor",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Starfleet Academy requires a large number of instructors, and drawn from officers and enlisted personnel across Starfleet. Many distinguished officers have spent a year or two teaching classes at the Academy, often while between more active or dangerous postings. The really good officers see it as an opportunity to pass on what they have experienced.",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Officer",
                    "Starfleet Academy Instructor"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "There’s little so important as shaping the next generation",
                },
                Focuses = new List<string>
                {
                    Focus.Teaching
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 7, Fitness = 8, Insight = 9, Presence = 9, Reason = 9 },
                Departments = new Departments { Command = 3, Conn = 1, Engineering = 1, Security = 1, Medicine = 1, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Collaboration (Talent)",
                        Description = new List<string>
                        {
                            "Select a single department for this talent."
                        },
                        HideIfGenerating = true,
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Teacher",
                        Description = new List<string>
                        {
                            "Choose a single department other than Command, and increase it by +1. Select one additional focus to represent the subject the NPC teaches at the Academy."
                        },
                        HideIfGenerating = true,
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Admiral Raner",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Admiral Raner served as the head of Starfleet Security until 2370, when she was dishonorably discharged for restarting the covert program to develop a phasing cloaking device, a project Starfleet Intelligence had covered up several years before. As chief of Starfleet Security her remit covered the security and safety of the Federation, instigating criminal investigations, and guarding Starfleet and civilian facilities across Federation space.",
                },
                Traits = new List<string>
                {
                    "Human",
                    "Starfleet Flag Officer",
                    "Head of Starfleet Security"
                },
                Values = new List<string>
                {
                    "Safeguard the Federation from all threats",
                },
                Focuses = new List<string>
                {
                    "Starfleet Command", "Intelligence", "Federation Law"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 8, Insight = 9, Presence = 11, Reason = 10 },
                Departments = new Departments { Command = 4, Conn = 1, Engineering = 1, Security = 3, Medicine = 1, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Menacing1),
                    new()
                    {
                        Name = "The Bigger Picture",
                        Description = new List<string>
                        {
                            "When Admiral Raner attempts a Persuasion task and uses Threat to buy one or more additional d20s, she may reroll 1d20."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Commander Mahmud Al-Khaled",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Lt. Commander Al-Khaled is a well-regarded repair specialist, and eventually Command Liaison in the Corps of Engineers in 2280. He had command of the U.S.S. Aephas, a Mirandaclass starship during his field work before he lead the Corps at the Tucker Memorial Building in Starfleet Command HQ. Mahmud is passionate about his work, insisting that the efficiency of the personnel under his guidance is of the highest standard.",
                },
                Traits = new List<string>
                {
                    "Human",
                    "Starfleet Officer",
                    "Starfleet Corps of Engineers"
                },
                Values = new List<string>
                {
                    "To achieve high standards, you must expect high standards.",
                },
                Focuses = new List<string>
                {
                    Focus.GroundVehicles, "Starship Repair", "Warp Core Maintenance"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 9, Insight = 10, Presence = 8, Reason = 10 },
                Departments = new Departments { Command = 2, Conn = 2, Engineering = 4, Security = 1, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Faith of the Heart",
                        Description = new List<string>
                        {
                            "When Al-Khaled uses one of his values, add 1 Threat if he is an adversary or add 1 to the group’s Momentum pool if he is an ally."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    new()
                    {
                        Name = "I Know Starfleet Ships",
                        Description = new List<string>
                        {
                            "Whenever Commander Al-Khaled attempts a task to determine the source of a technical problem aboard a vessel with the Federation Starship trait, the first bonus d20 is free."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "My Repairs do the Talking",
                        Description = new List<string>
                        {
                            "Whenever Al-Khaled attempts a task to direct or give orders to Engineering personnel, he may use Engineering instead of Command."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Communications Officer",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "The communications officer was a separate bridge position until the late 23rd Century. These operations staff were responsible for ship-wide, local and long-distance (subspace) communications. Early in Starfleet history, before the proliferation of the universal translator, communications officers were required to be fluent in several Federation languages, and have a familiarity with other key languages such as Klingon.",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Officer",
                    "Polyglot"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "Language is the key to exploring new civilizations",
                },
                Focuses = new List<string>
                {
                    "Cryptography", Focus.SubspaceCommunications, "Xenolinguistics"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 7, Insight = 9, Presence = 10, Reason = 9 },
                Departments = new Departments { Command = 2, Conn = 2, Engineering = 3, Security = 1, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Cautious (Engineering)"),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "Interpretive Translation",
                        Description = new List<string>
                        {
                            "The communications officer may always choose to Succeed at Cost when attempting to translate a message in an unfamiliar language, or piece together a distorted or corrupted transmission. The complication represents any flaws or limitations in the translation or reconstruction of the message."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "JAG Officer",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "As part of the Judge Advocate General’s office, this officer is especially knowledgeable about the law. In most situations, a JAG Officer provides legal advice to Starfleet personnel, especially commanding officers, in their assigned region or facility. They also serve as prosecuting and defense counsels during courts-martial, and as judges during inquiries, hearings, and courts-martial. JAGs can judge or advise on civilian matters as well, particularly where a ruling may affect (or serve as precedent for) Starfleet operations, or in frontier regions where Starfleet is the established Federation presence.",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Officer",
                    "Lawyer"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "Law is the foundation upon which an orderly society is built",
                },
                Focuses = new List<string>
                {
                    Focus.History, Focus.Law, Focus.Rhetoric
                },
                PersonalThreat = 6,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 7, Insight = 9, Presence = 9, Reason = 10 },
                Departments = new Departments { Command = 3, Conn = 1, Engineering = 1, Security = 2, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Advisor"),
                    new()
                    {
                        Name = "Jurisprudence",
                        Description = new List<string>
                        {
                            "The JAG Officer is extremely well-versed in the theory and philosophy of law, and may re-roll 1d20 on any task that uses their Reason attribute and their Law focus."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Operations Officer",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "The operations officer, at the bridge ops station, is the head of ship operations. The two bridge positions of communications and science officer were amalgamated into this role in the 24th Century. These officers must be familiar with both the Science and Engineering Disciplines. They interpret key data and act on the orders of the commanding officers aboard a ship maintaining communication, scanning and other operational duties.",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Officer",
                    "Polymath"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "From this chair, I am in control",
                },
                Focuses = new List<string>
                {
                    Focus.PowerManagement, Focus.SensorOperations, "Starfleet Reporting Procedures"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 10, Daring = 8, Fitness = 8, Insight = 9, Presence = 8, Reason = 8 },
                Departments = new Departments { Command = 1, Conn = 3, Engineering = 2, Security = 1, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "Operational Insight",
                        Description = new List<string>
                        {
                            "Whenever the operations officer uses the Override major action, they ignore the normal increase in difficulty from that action."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Pathfinder Specialist",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Across the Galaxy, there are regions of space that are difficult to navigate. The Delphic Expanse, home to the Xindi and rife with spatial anomalies is one such example; the Badlands, often used by Maquis raiders to evade pursuit, is another. These regions, as well as border and frontier regions of space, are difficult and dangerous to travel, and possess numerous unknown hazards that could destroy a ship.",
                    "A pathfinder — not a formal title — is an expert at navigating these uncharted regions safely. Their expertise allows them to map dangerous or unexplored space, making subsequent voyages easier and safer. Elite pilots with this kind of skill are often a valuable resource for an Admiral, to be deployed as and when needed. They are often assigned to scout and reconnaissance vessels and sent on long-range exploratory missions."
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Officer"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "The first to see those stars up-close",
                },
                Focuses = new List<string>
                {
                    Focus.Astronavigation, Focus.HelmOperations
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 10, Daring = 9, Fitness = 8, Insight = 8, Presence = 7, Reason = 9 },
                Departments = new Departments { Command = 2, Conn = 3, Engineering = 1, Security = 1, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Find the Path",
                        Description = new List<string>
                        {
                            "When attempting a task to chart or navigate through a difficult or dangerous region of space, and the Pathfinder Specialist buys one or more additional d20s, they may re-roll a single d20. Further, during any extended task attempted to navigate through a perilous region of space, a Pathfinder Specialist, or a character assisted by a Pathfinder Specialist, may ignore any Resistance on the extended task."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Quartermaster",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "The quartermaster was a highly visible and important position in the 22nd Century era of Starfleet. Quartermasters can still be found on the occasional Starfleet installation, and are responsible for the distribution and allocation of supplies and resources. They can requisition supplies and equipment from Fleet Operations, and are a department head’s point of contact for requesting gear for their team.",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Officer"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "Fail to prepare and you prepare to fail",
                },
                Focuses = new List<string>
                {
                    "Repair Procedures", "Resources Management"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 8, Insight = 9, Presence = 9, Reason = 9 },
                Departments = new Departments { Command = 2, Conn = 1, Engineering = 3, Security = 1, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Contacts in Fleet Ops",
                        Description = new List<string>
                        {
                            "Whenever the quartermaster attempts, or assists in, a Persuasion task to request resources from Starfleet Command, the first bonus d20 is free."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "Requisitions",
                        Description = new List<string>
                        {
                            "Whenever the player characters seek assistance from the quartermaster when requisitioning equipment, select one item the player characters are obtaining that has an Opportunity Cost of 1 or higher. By increasing the Opportunity cost by 1, they may increase the Potency of that item’s equipment trait by 1."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Repair Team Leader",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Often members of the Corps of Engineers when in space dock, and officers in the engineering division aboard a starship, repair team leaders lead groups of engineers. They restore systems from serious damage aboard Starfleet vessels and, when in combat or a crisis, damage control teams will be sent out to keep systems online. It is their job to fight fires, both literally and metaphorically. In space dock, these repair teams work long hours to help maintain, upgrade and otherwise repair ships on the frontline of Federation space.",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Personnel"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "We’ll get it done",
                },
                Focuses = new List<string>
                {
                    Focus.DamageControlProcedures, "Damage Reporting", "Hazard Containment"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 9, Fitness = 9, Insight = 9, Presence = 7, Reason = 8 },
                Departments = new Departments { Command = 1, Conn = 2, Engineering = 3, Security = 1, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "Pushing the Deadline",
                        Description = new List<string>
                        {
                            "Whenever the repair team leader succeeds at an Engineering or Science task as part of a timed challenge or timed extended task, the cost to reduce the amount of time taken is 1 Momentum."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Section 31 Operative",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "A member of Starfleet’s secret branch of intelligence, Section 31."
                },
                Traits = new List<string>
                {
                    "Federation Species (add 3 points to attributes based on species)",
                    "Starfleet Intelligence Operative"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "The ends justify the means",
                },
                Focuses = new List<string>
                {
                    Focus.Espionage, Focus.Infiltration
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 11, Daring = 8, Fitness = 7, Insight = 10, Presence = 9, Reason = 9 },
                Departments = new Departments { Command = 2, Conn = 1, Engineering = 2, Security = 3, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType2, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Adapable",
                        Description = new List<string>
                        {
                            "A Section 31 operative may spend 2 Threat to gain a single focus for the remainder of the scene."
                        }
                    },
                    new()
                    {
                        Name = "Covert",
                        Description = new List<string>
                        {
                            "Whenever required to attempt a task to conceal their activities for Section 31—including to maintain their cover identity—they may roll an additional d20."
                        }
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                }
            },
            new()
            {
                Name = "Starfleet Intelligence Agent",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Intelligence agents are specialists within Starfleet, with proficiency in covert operations and espionage inside and outside the Federation. Their role in gathering information on threats to the Federation is invaluable, and several breakthroughs in criminal investigations and strategic planning have been credited to their actions. This includes stings on Orion smuggling operations, and intelligence on the Romulan Star Empire on the other side of the Neutral Zone."
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Intelligence Operative",
                    "Professionally Cautious"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "I am the unseen hand of Starfleet",
                },
                Focuses = new List<string>
                {
                    Focus.Espionage, "Intelligence Analysis", "Undercover Operations,"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 9, Fitness = 8, Insight = 8, Presence = 9, Reason = 8 },
                Departments = new Departments { Command = 2, Conn = 1, Engineering = 1, Security = 4, Medicine = 1, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Constantly Watching"),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Menacing1),
                    new()
                    {
                        Name = "Personal Forcefield (Escalation 1)",
                        Description = new List<string>
                        {
                            "Protection 3; may be sacrificed when suffering an Injury – the Injury becomes a Stun Injury and the forcefield stops working"
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Trained to Withstand Interrogation",
                        Description = new List<string>
                        {
                            "Whenever the agent would be intimidated or threatened, spend 2 Threat to ignore that attempt."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Transporter Chief",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Transporter chiefs are key personnel aboard Starfleet installations and ships, and report to the chief of operations. They monitor and coordinate energy-matter-scrambler transportation of personnel and cargo, often in person from a transporter room or cargo bay. They are usually a petty officer, ensign or lieutenant aboard Starfleet ships and stations."
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Starfleet Enlisted Personnel",
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "Are you sure these are the right coordinates?",
                },
                Focuses = new List<string>
                {
                    "Containment Procedures", Focus.TransportersAndReplicators
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 10, Daring = 8, Fitness = 8, Insight = 9, Presence = 8, Reason = 8 },
                Departments = new Departments { Command = 1, Conn = 1, Engineering = 3, Security = 2, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    TalentSelector.GetTalentAsSpecialRule("Technical Expertise"),
                    TalentSelector.GetTalentAsSpecialRule("Transporter Chief"),
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Admiral John Harriman",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Admiral Harriman served as commanding officer of the U.S.S. Enterprise-B, in 2293. The events of its maiden voyage left a lasting impression on him with the loss of his childhood hero, James T. Kirk. He had a dedication plaque to Kirk made and installed in main engineering of the Enterprise-B. His missions quickly took him away from the bridge of the Enterprise, and he moved into more covert operations along the Romulan Neutral Zone. After almost resigning his commission in 2311, he was promoted to Admiral, and this eventually led to his role as Starfleet Corps of Engineers Command Liaison in the 2360s and after. He coordinates the efforts of the Engineer Corps with Starfleet Command itself, assigning personnel and equipment throughout Starfleet. Unlike some more formal Admirals, Harriman recognizes potential and welcomes questions and opinions in many of his meetings with Starfleet personnel.",
                },
                Traits = new List<string>
                {
                    "Human",
                    "Starfleet Flag Officer",
                    "Elderly",
                    "Command Liaison to Starfleet Corps of Engineers"
                },
                Values = new List<string>
                {
                    "Starfleet is a family tradition",
                    "Keeping an old admiral busy",
                    "Risk is part of the game if you want the captain’s chair"
                },
                Focuses = new List<string>
                {
                    Focus.Espionage, Focus.HandPhasers, "Quantum Singularity Technology", Focus.Saboteur, "Personnel Management,", "The Romulan Star Empire"
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 10, Fitness = 8, Insight = 10, Presence = 8, Reason = 10 },
                Departments = new Departments { Command = 4, Conn = 2, Engineering = 4, Security = 3, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Advisor"),
                    new()
                    {
                        Name = "Dauntless",
                        Description = new List<string>
                        {
                            "Whenever another character attempts to intimidate or threaten you, you may spend 2 Threat (or add 2 Threat, if an ally to the PCs) to ignore their attempt."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Faith of the Heart",
                        Description = new List<string>
                        {
                            "When Harriman uses one of his values, add 1 Threat if he is an adversary or add 1 to the group’s Momentum pool if he is an ally."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Menacing1),
                    new()
                    {
                        Name = "Sabotage",
                        Description = new List<string>
                        {
                            "When Admiral Harriman attempts an Engineering task to sabotage equipment, the first die he purchases is free."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Admiral Robert April",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Admiral April is perhaps best known because he is part of a small group of officers who captained the Enterprise. As commander of the San Francisco Naval Yards in the 2240s, April oversaw the development of the Constitutionclass starships, including the hull that would become the Enterprise. He then took command of the Enterprise for its initial missions from 2245 onwards.",
                    "After 5 years in the captain’s chair, April was promoted to commodore and created as Ambassador-at-Large, representing Federation interests across numerous worlds. He was accompanied by his wife, the noted physician Doctor Sarah April, who had been his chief medical officer on the Enterprise. He was due to retire from active service in 2270, but this has been indefinitely postponed.",
                    "Like the men who followed him on the Enterprise, April is headstrong and bold, unafraid of personal risk, but also deeply compassionate. His age and experience have tempered his audacity, but he is nevertheless a man who desires action and activity, and one who has little tolerance for suffering inflicted on others."
                },
                Traits = new List<string>
                {
                    "Human",
                    "Starfleet Flag Officer",
                    "First Captain of the Enterprise (NCC-1701)"
                },
                Values = new List<string>
                {
                    "A ship is a home, and its crew is a family",
                    "No regrets for a life lived well",
                    "To explore strange, new worlds...",
                    "Compelled to ease the plight of others",
                },
                Focuses = new List<string>
                {
                    Focus.Diplomacy, Focus.Inspiration, Focus.Politics, Focus.StarshipDesign, Focus.StarshipTactics, Focus.Willpower
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 11, Fitness = 8, Insight = 10, Presence = 10, Reason = 9 },
                Departments = new Departments { Command = 5, Conn = 2, Engineering = 3, Security = 3, Medicine = 1, Science = 3 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Audacious Commander",
                        Description = new List<string>
                        {
                            "When attempting a Command task, and spending one or more Threat to buy additional dice, April may re-roll one 1d20."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Faith of the Heart",
                        Description = new List<string>
                        {
                            "When April uses one of his values, add 1 Threat if he is an adversary or add 1 to the group’s Momentum pool if he is an ally."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "Lead by Doing",
                        Description = new List<string>
                        {
                            "Whenever a point of Determination is spent on a Directive which was one of April’s values, roll 1d20. If the roll is equal to or under April’s Presence, that point of Determination is immediately refunded."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Renowned",
                        Description = new List<string>
                        {
                            "When a mission concludes under April’s command, or where he was involved, each player character may re-roll 1d20 on their Reputation roll."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Captain Herman Zimmerman",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Captain Zimmerman has had a long career commanding various starships but, most notably, he is a contributing design specialist for Shipyard Operations, and worked on the designs of the Galaxy- and Defiant-class starships, notably the U.S.S. Enterprise-D and the U.S.S. Defiant.",
                },
                Traits = new List<string>
                {
                    "Human",
                    "Starfleet Officer",
                    "Starfleet Corps of Engineers",
                    "Starship Designer"
                },
                Values = new List<string>
                {
                    "Design moves technology to its preferred state",
                    "Most comfortable in the center chair",
                },
                Focuses = new List<string>
                {
                    Focus.Composure, Focus.StarshipTactics, "Structural Integrity Fields", "Technological Innovation", Focus.WarpFieldDynamics, "Weapon Array Configuration"
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 10, Daring = 8, Fitness = 8, Insight = 9, Presence = 10, Reason = 11 },
                Departments = new Departments { Command = 4, Conn = 3, Engineering = 5, Security = 1, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Faith of the Heart",
                        Description = new List<string>
                        {
                            "When Zimmerman uses one of his values, add 1 Threat if he is an adversary or add 1 to the group’s Momentum pool if he is an ally."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Innovation",
                        Description = new List<string>
                        {
                            "Whenever Capt. Zimmerman assists a player character in developing a prototype piece of technology, Zimmerman or the player character may reroll 1d20 during any task to create that prototype."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    TalentSelector.GetTalentAsSpecialRule("More Power!"),
                    TalentSelector.GetTalentAsSpecialRule("Starship Expert"),
                    new()
                    {
                        Name = "Veteran",
                        Description = new List<string>
                        {
                            "Should Capt. Zimmerman spend Threat in place of Determination, roll 1d20: if the result is equal to or under his Control, those points of Threat are regained (if Zimmerman is an ally, he would add to Threat in place of Determination, and this would prevent those points being added)."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Captain T'Mek",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Starfleet captains command most Starfleet starships and space stations, and are responsible for their crews and for executing Starfleet’s orders. Captain T’Mek is representative of this type of officer."
                },
                Traits = new List<string>
                {
                    "Vulcan",
                    "Starfleet Officer",
                    "Commanding Officer"
                },
                Values = new List<string>
                {
                    "A failure to act can be as dangerous as acting rashly",
                    "Wisdom is the beginning of logic, not the end",
                },
                Focuses = new List<string>
                {
                    Focus.Astrophysics, Focus.Composure, Focus.Diplomacy, Focus.StarshipTactics
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 12, Daring = 9, Fitness = 9, Insight = 8, Presence = 10, Reason = 11 },
                Departments = new Departments { Command = 4, Conn = 3, Engineering = 2, Security = 2, Medicine = 1, Science = 4 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.VulcanNervePinch),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType2, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Considered Every Outcome",
                        Description = new List<string>
                        {
                            "When she succeeds at a Reason + Command task, T’Mek scores one more Momentum than normal."
                        }
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    TalentSelector.GetTalentAsSpecialRule("Nerve Pinch")
                }
            },
            new()
            {
                Name = "Luthor Sloan",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Luther Sloan is the supposed director of Section 31, the unrecognized covert department of Federation “dirty tricks”. Little is known about his personal life, though hints about an early career in Starfleet Intelligence indicate how he ended up leading the Section 31 organization. Records, of course, can’t corroborate any theory of his origin or profession.",
                    "Sloane is a calculating individual, who twists facts to suit his objectives or ambitions, but that’s not to say he is selfishly driven. He is someone who must protect Federation citizens from a universe that doesn’t share their sense of right and wrong, and his motivations seem to be the preservation of the Federation and its member species. His methods, however, are questionable. As the leader of Section 31 he’s not scared to get his hands rather dirty in the line of duty."
                },
                Traits = new List<string>
                {
                    "Human",
                    "Director of Section 31",
                    "Covert Mastermind"
                },
                Values = new List<string>
                {
                    "I am a man of secrets",
                    "The ends justify the means",
                    "A prodigy of Starfleet Intelligence",
                    "Breaking the Federation’s principles in order to keep it safe"
                },
                Focuses = new List<string>
                {
                    "Disguise", Focus.Espionage, Focus.Infiltration, Focus.Interrogation, "Manipulation", "Starfleet Security"
                },
                PersonalThreat = 12,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 10, Daring = 9, Fitness = 8, Insight = 10, Presence = 12, Reason = 10 },
                Departments = new Departments { Command = 4, Conn = 2, Engineering = 2, Security = 5, Medicine = 2, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Commission",
                        Description = new List<string>
                        {
                            "Sloan can counterfeit records to give himself a Starfleet commission or civilian identity (excluding flag officer ranks), and he can remove those records just as easily. Sloan may give himself a trait representing this fake rank or status at the start of a mission for no cost, and this trait has a potency of 2. During a mission, he may spend 2 Threat to change this trait and adopt a different persona."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Counterintelligence",
                        Description = new List<string>
                        {
                            "Whenever Obtain Information is used to enquire about Sloan, you may spend 1 Threat to choose to mislead the players. You may try to double-bluff players with this, by spending the Threat but still revealing truthful information."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    new()
                    {
                        Name = "Lethal Implant",
                        Description = new List<string>
                        {
                            "Sloan may activate an implant which kills him instantly to avoid exposing Section 31 or its operations. This costs a number of Threat equal to the number of main characters in the scene."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Profiling",
                        Description = new List<string>
                        {
                            "Whenever Sloan attempts to intimidate or deceive a character during a social conflict, the first d20 he purchases is free."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Rear Admiral Thy'Ran",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Starfleet admirals command Starfleet assets in entire regions or sectors of space, and often act with great latitude as required. Thyran is representative of this type of officer."
                },
                Traits = new List<string>
                {
                    "Andorian",
                    "Starfleet Flag Officer",
                    "Strategist"
                },
                Values = new List<string>
                {
                    "There is no higher calling than to serve",
                    "We endure hardship, so that others do not have to",
                },
                Focuses = new List<string>
                {
                    Focus.Endurance, Focus.FleetStrategyAndTactics, Focus.Inspiration, Focus.MilitaryHistory
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 11, Fitness = 9, Insight = 9, Presence = 12, Reason = 10 },
                Departments = new Departments { Command = 4, Conn = 3, Engineering = 3, Security = 3, Medicine = 2, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Proud and Honorable"),
                    new()
                    {
                        Name = "Accomplished Strategist",
                        Description = new List<string>
                        {
                            "Whenever he attempts to create a trait representing a strategy or plan, he may spend 1 Threat to re-roll his dice pool."
                        }
                    },
                    new()
                    {
                        Name = "Counter-Ploy",
                        Description = new List<string>
                        {
                            "Whenever an enemy attempts a task to create a trait representing some manner of strategy or tactic, Thyran may spend 1 Threat to increase the Difficulty by 1. Further, if this task then fails, Thyran may immediately spend one additional Threat to create a trait of his own, representing his own stratagem."
                        }
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining)
                }
            },
            new()
            {
                Name = "Rear Admiral Torthem jav Brin",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Admiral Brin is an acerbic and driven individual currently commanding a research and exploratory fleet on the edges of the Federation. She expects only the best from the officers in her command, and sets an even higher standard for herself. Brin embraces the politics of her station, but her meticulous and piercing insight means that few are inclined to play politics with her. Instead, she makes do with a good battle of words, and frequently engages the captains under her command in debate. Brin is given considerable leeway to run her fleet as she sees fit.",
                    "She is quick to criticize flaws, but just as quick to offer praise for a job well done; those who know her well value her honesty and insights.",
                },
                Traits = new List<string>
                {
                    "Tellarite",
                    "Starfleet Flag Officer",
                },
                Values = new List<string>
                {
                    "A questioning mind is essential for exploration",
                    "This job requires a keen mind and an iron will"
                },
                Focuses = new List<string>
                {
                    Focus.Astrophysics, Focus.Composure, Focus.Debate, Focus.Exoarchaeology, Focus.Politics, Focus.Psychology
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 10, Insight = 10, Presence = 10, Reason = 10 },
                Departments = new Departments { Command = 5, Conn = 3, Engineering = 2, Security = 2, Medicine = 1, Science = 3 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Shrewd Politician",
                        Description = new List<string>
                        {
                            "Brin’s political and debating skills are considerable and few willingly engage her in a battle of words. Whenever anyone attempts a Persuade task against Admiral Brin, increase the Complication range by 2, due to her ability to spot flaws in an argument."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Insightful Commander",
                        Description = new List<string>
                        {
                            "Brin is keenly observant and understands people. Once per mission, during any scene where Brin is an ally to the player characters, she may grant one player character in the same scene a point of Determination, as her advice and guidance help reassure and direct that character."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Menacing1),
                    new()
                    {
                        Name = "Sturdy",
                        Description = new List<string>
                        {
                            "+1 Protection against Stun Attacks, and Brin may spend 1 Threat to ignore a complication which represents a physical hindrance or being stunned, dazed, or disoriented."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Vice Admiral Alynna Nechayev",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Alynna Nechayev is a senior Starfleet Admiral of considerable renown and importance in the Alpha Quadrant. In the late 2360s, she oversaw the Federation-Cardassian border, and she was instrumental in the peace treaty that led to the Cardassian Demilitarized Zone in 2370.",
                    "Her highest priority is the security of the Federation whether through peaceful negotiation, or preemptive actions such as direct strikes and covert operations. She has little patience for anything that doesn’t serve that aim, and she is willing to make the tough decisions and, sometimes, concessions necessary to maintain peace and stability. Security is what matters.",
                },
                Traits = new List<string>
                {
                    "Human",
                    "Starfleet Flag Officer",
                    "Instrumental in peace with the Cardassians"
                },
                Values = new List<string>
                {
                    "Our first priority is the lives of Federation citizens",
                    "Concessions must be made to ensure our safety",
                    "The Maquis are a bunch of irresponsible hotheads",
                    "The ends justify the means"
                },
                Focuses = new List<string>
                {
                    "Cardassian Politics", "Command Procedure", Focus.CovertOperations, Focus.Diplomacy, "Federation Politics", "Peace Treaties"
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 10, Fitness = 8, Insight = 9, Presence = 12, Reason = 10 },
                Departments = new Departments { Command = 5, Conn = 2, Engineering = 1, Security = 4, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "By the Book",
                        Description = new List<string>
                        {
                            "When engaged in social conflict with the player characters over Starfleet orders, protocols, or procedures, if Nechayev buys any additional d20s, she may re-roll a single d20."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Menacing1),
                    new()
                    {
                        Name = "Point of Order",
                        Description = new List<string>
                        {
                            "When Nechayev assists another character and uses her Diplomacy focus, she may re-roll her assist die."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Understands the Cardassians",
                        Description = new List<string>
                        {
                            "When negotiating with Cardassians, Nechayev may reduce the difficulty of any Persuasion task by 1, to a minimum of 1."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Vice Admiral James Leyton",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Admiral Leyton is the Chief of Starfleet Operations, at Starfleet Headquarters in San Francisco on Earth. He has operational authority over fleet and ship deployments across the entire Federation and beyond but, in practice, this authority is delegated. Vice admirals, rear admirals, and captains operating in particular regions are trusted to have more understanding of their commands and regions.",
                    "Leyton is a veteran of several conflicts and police actions, including wars against the Cardassians and the Tzenkethi, and skirmishes with the Romulans, Tholians, and Borg. He is a firm believer in preparing to deal with new threats; he has openly stated his belief that war with the Dominion is inevitable.",
                    "He has strong relationships with many officers who served under him earlier in his career. He uses his knowledge of those officers, and his role as Chief of Starfleet Operations, to ensure that each is posted where their skills are most needed."
                },
                Traits = new List<string>
                {
                    "Human",
                    "Starfleet Flag Officer",
                    "Chief of Starfleet Operations",
                    "Veteran of Several Conflicts"
                },
                Values = new List<string>
                {
                    "Respect the chain of command, whether you agree with it or not",
                    "Too many people underestimate the threats we face",
                    "Protecting the Federation is paramount",
                    "No price is too high for security"
                },
                Focuses = new List<string>
                {
                    Focus.Deception, "Intelligence Briefings", "Military Strategy", Focus.Politics, Focus.Psychology, "Security Policy"
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 8, Insight = 9, Presence = 10, Reason = 8 },
                Departments = new Departments { Command = 5, Conn = 3, Engineering = 2, Security = 4, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType2)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Authorative",
                        Description = new List<string>
                        {
                            "When involved in a social conflict to give or explain orders, or to remain with a course of action when a subordinate officer attempts to persuade him otherwise, if Leyton buys additional dice, he may re-roll any number of d20s in his dice pool."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Menacing1),
                    new()
                    {
                        Name = "Paranoia",
                        Description = new List<string>
                        {
                            "When attempting a task to detect a threat or peril (personal, to a starship, or politically through intelligence reports), the first bonus d20 Leyton buys is free; if he assists a player character in such a task, the player character gains this benefit. All such tasks that Leyton attempts or assists increase in complication range by 1, as Leyton may misjudge the scale of the Threat."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                },
                Source = BookSource.CommandDivision1stEdition,
            },
        };
    }

    private static IEnumerable<NonPlayerCharacter> GetFederationNpcs()
    {
        return new List<NonPlayerCharacter>
        {
            new()
            {
                Name = "Attaché",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Attachés are members of a high-ranking diplomat’s support staff: advisors, researchers, and assistants. Many attachés have a particular expertise: military (sometimes a retired military officer), legal (a lawyer with appropriate expertise), scientific (a scientist of particular prominence), or trade (an expert in macroeconomics).",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Diplomatic Attaché"
                },
                RandomSpecies = true,
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 7, Fitness = 7, Insight = 9, Presence = 8, Reason = 9 },
                Departments = new Departments { Command = 2, Conn = 0, Engineering = 1, Security = 1, Medicine = 0, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Specialist Subject",
                        Description = new List<string>
                        {
                            "An Attaché may be given a specialty, granting them a single focus (in spite of the fact that Minor NPCs cannot normally have focuses), and possibly modifying their departments. Specialties may be chosen from the following list:",
                            "CULTURAL ATTACHÉ: Gain either Art or Cultural Studies as a focus.",
                            "HEALTH ATTACHÉ: Gain Public Health as a focus. Increase Medicine to 02, Reduce Science to 01, reduce Security to 00.",
                            "LEGAL ATTACHÉ: Gain Law as a focus.",
                            "MILITARY ATTACHÉ: Gain Military Strategy or Military Protocol as a focus. Increase Security to 02, reduce Science to 01.",
                            "PRESS ATTACHÉ: Gain Journalism or Public Relations as a focus.",
                            "SCIENCE ATTACHÉ: Gain a single field of scientific study as a focus.",
                            "TRADE ATTACHÉ: Gain Economics as a focus."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Informant",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Informants provide their Starfleet Intelligence contacts with intelligence on events, people and items with which they have close contact. These individuals can come from any walk of life, but often have a deep-seated appreciation for the Federation and its principals. This makes them valuable in the fight against moral corruption and external threats.",
                },
                Traits = new List<string>
                {
                    "Alien (Choose Species)",
                    "Confidential Informant",
                    "Justifiably Paranoid"
                },
                RandomNonHumanSpecies = true,
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 7, Daring = 8, Fitness = 8, Insight = 10, Presence = 9, Reason = 9 },
                Departments = new Departments { Command = 0, Conn = 2, Engineering = 1, Security = 2, Medicine = 1, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>(),
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Negotiator",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Diplomacy is the responsibility of diplomats and ambassadors but they cannot do the job alone. They will normally be accompanied by a staff of aides, assistants, and negotiators of lower rank. Subordinate negotiators often handle individual sessions in a larger set of talks, negotiating the nitty-gritty of individual treaty clauses or details of an agenda.",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Negotiator"
                },
                RandomSpecies = true,
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 7, Insight = 8, Presence = 9, Reason = 8 },
                Departments = new Departments { Command = 2, Conn = 0, Engineering = 1, Security = 1, Medicine = 0, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Focused Training",
                        Description = new List<string>
                        {
                            "The NPC has a single focus, even though they are minor NPCs.",
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Diplomat",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Diplomatic functionaries are a natural part of any missions where one world or civilization speaks with another. Starship captains are expected to act as diplomats when necessary but, for long-term talks, a professional is preferable.",
                },
                Traits = new List<string>
                {
                    "Species (add 3 points to attributes based on species)",
                    "Diplomat"
                },
                RandomSpecies = true,
                Values = new List<string>
                {
                    "Peace can be attained through effort and compromise",
                },
                Focuses = new List<string>
                {
                    Focus.Diplomacy, Focus.Politics, Focus.Research
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 7, Insight = 9, Presence = 10, Reason = 9 },
                Departments = new Departments { Command = 3, Conn = 1, Engineering = 2, Security = 1, Medicine = 0, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Defuse the Tension"),
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Doctor Leah Brahms",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Dr. Brahms is a key designer of the propulsion systems of the Galaxy and Nebula-class starships at the Utopia Planitia Fleet Yards. A graduate of the Daystrom Institute of Technology, she has a brilliant mind for the theory of propulsion and subspace designs.",
                },
                Traits = new List<string>
                {
                    "Human",
                    "Professor of Theoretical Physics",
                    "Daystrom Fellow",
                    "A Leader in Warp Field Theory"
                },
                Values = new List<string>
                {
                    "More comfortable with engine schematics than people",
                },
                Focuses = new List<string>
                {
                    Focus.ImpulseEngines, Focus.SubspacePhysics, Focus.WarpFieldDynamics
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 7, Insight = 9, Presence = 10, Reason = 12 },
                Departments = new Departments { Command = 0, Conn = 2, Engineering = 4, Security = 1, Medicine = 1, Science = 4 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "All Theory",
                        Description = new List<string>
                        {
                            "Dr. Brahms’ theories are well-documented in published papers and technical manuals. Accessing her published works aboard a Starfleet vessel or Federation facility allows you to create an equipment trait, Technical Documentation, with an Opportunity cost of 1, which can benefit any task roll for which one of Dr. Brahms focuses would apply. However, lengthy reading and referencing means that tasks benefitting from this equipment may take longer."
                        },
                        Source = BookSource.OperationsDivision1stEdition,
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ExtraordinaryReason1),
                    TalentSelector.GetTalentAsSpecialRule("Procedural Compliance"),
                },
                Source = BookSource.OperationsDivision1stEdition,
            },
            new()
            {
                Name = "Ambassador Lwaxana Troi",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "“Memorable” is a polite description of Lwaxana Troi. She is a woman with larger-than-life flamboyance and hardly what most people imagine a diplomat to be but, once met, she is seldom forgotten. Her flirtatious manner often leaves people flustered or embarrassed, while her blunt honesty and her telepathy mean that few people can hide anything from her. These talents are employed to cut through formality to reach the heart of a matter, or sometimes just for amusement.",
                    "Daughter of a noble house, Lwaxana Troi has served as an ambassador for Betazed, and the Federation as a whole. Her unorthodox and outlandish manner has helped create lasting treaties and agreements in many situations and with many diverse cultures. Her status as Federation Ambassador involves her in a wide variety of different situations, bringing her into contact with many different people from all walks of life.",
                    "She is fiercely protective of her family, and especially her daughter, Deanna. She feels the same about anyone she considers a friend, and she makes friends easily. As someone who prides herself on brutal honesty she often seems  reluctant to take things seriously. Whether this is part of the way she carries herself, or true part of her nature is, and should remain, bit of a mystery.",
                    "Ambassador Troi is routinely accompanied by her laconic valet, Mr. Homn."
                },
                Traits = new List<string>
                {
                    "Betazoid",
                    "Ambassador",
                    "Betazed Royalty",
                },
                Values = new List<string>
                {
                    "Daughter of the Fifth House, Holder of the Sacred Chalice of Rixx, and Heir to the Holy Rings of Betazed",
                    "Do not be what others expect of you",
                    "Life’s true gift is the capacity to enjoy enjoyment",
                    "What matters the most is company"
                },
                Focuses = new List<string>
                {
                    "Betazoid Culture", Focus.CulturalStudies, Focus.Etiquette, Focus.Persuasion, Focus.Psychiatry, Focus.Politics
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 9, Fitness = 9, Insight = 10, Presence = 11, Reason = 10 },
                Departments = new Departments { Command = 5, Conn = 2, Engineering = 2, Security = 1, Medicine = 3, Science = 3 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Break the Ice",
                        Description = new List<string>
                        {
                            "Ambassador Troi’s manner breaks through formality in a way that sometimes puts other diplomats and negotiators ill-at-ease, but which tends to open up talks in a way that proper etiquette and procedure cannot. When attempting a task during a social conflict, Lwaxana may choose to increase her complication range by 1, 2, or 3. If the task succeeds, she gains bonus Momentum equal to the amount by which she increased her Complication range. Bonus Momentum may not be saved."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Diplomatic Expertise",
                        Description = new List<string>
                        {
                            "Whenever Ambassador Troi attempts a task within a social conflict, and buys one or more additional dice, she may re-roll her dice pool."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Object Affection",
                        Description = new List<string>
                        {
                            "When she first appears in a mission, Lwaxana Troi may select a single player character or NPC to serve as the object of her affections for that mission. She will typically choose an older male character, and commonly someone quiet and dignified, though this is not required. The chosen character gains an additional Directive: Lwaxana Troi’s Affections. This is most likely to be used negatively, creating a complication (representing some embarrassment or awkward situation Mrs. Troi has caused) and giving the chosen character a point of Determination. This Directive may not be challenged."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    TalentSelector.GetTalentAsSpecialRule("Telepathy"),
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Curzon Dax",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Curzon Dax was the seventh host of the Dax symbiont and best known for his service as Federation Ambassador to the Klingon Empire. Before that his efforts in the creation and ratification of peace treaties between the Federation and the Klingons were notable. Curzon was, famously, a gambler and womanizer, known for his unorthodox approaches to challenging situations, and his enthusiasms for other cultures. Indeed, his love of the good life was such that it is surprising that he managed to accomplish as much as he did.",
                    "Continuing a tradition begun by an earlier Dax host, Curzon served as a field docent at the Trill Symbiosis Commission, continuing the Dax reputation for ‘breaking’ initiates who did not meet his standards. His long life allowed him to meet a great many important people: he studied under Sarek of Vulcan; established a lasting friendship with the Klingons Kor, Koloth, and Kang; and encountered many Starfleet officers at various stages in their careers, from Captain Hikaru Sulu of the Excelsior to being a friend and mentor to a young Benjamin Sisko.",
                    "Curzon died in 2367, over a century old, after over-exerting himself seeking jamaharon on Risa, a testament to a long life lived to the fullest. His memories and experiences live on in Lieutenant Jadzia Dax, a Starfleet officer serving aboard Deep Space 9."
                },
                Traits = new List<string>
                {
                    "Trill",
                    "Diplomat",
                    "Dax Symbiont",
                    "Honored Among the Klingons"
                },
                Values = new List<string>
                {
                    "Life is meant to be lived",
                    "Hold yourself and others to the highest standards",
                    "Sometimes, a Dax doesn’t think; they just act",
                    "Godfather and namesake of the Son of Kang"
                },
                Focuses = new List<string>
                {
                    Focus.CulturalStudies, Focus.Diplomacy, Focus.Intimidation, Focus.Gambling, Focus.Persuasion, "Trill Symbiosis"
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 8, Daring = 10, Fitness = 8, Insight = 9, Presence = 11, Reason = 9 },
                Departments = new Departments { Command = 5, Conn = 3, Engineering = 2, Security = 3, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Advisor"),
                    TalentSelector.GetTalentAsSpecialRule("Collaboration (Command)"),
                    new()
                    {
                        Name = "Ebullient and Reckless",
                        Description = new List<string>
                        {
                            "When attempting a task during a social conflict, Curzon may choose to suffer a complication in addition to the results of the task. If he does this, the first bonus d20 he purchases for the task is free. The limit of three additional d20s applies as normal."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    TalentSelector.GetTalentAsSpecialRule("Joined"),
                    new()
                    {
                        Name = "Patient",
                        Description = new List<string>
                        {
                            "When he succeeds at a task where he purchased one or more bonus d20s, he generates 1 bonus Momentum for each d20 purchased. Bonus Momentum may not be saved."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                },
                Source = BookSource.CommandDivision1stEdition,
            },
            new()
            {
                Name = "Sarek",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Sarek of Vulcan gave the greater part of his life to the Federation. A scientist, diplomat, ambassador and politician of great wisdom and experience, he served as Vulcan’s Ambassador to Earth, a member of the Federation Council, and as representative of the Federation to many worlds.",
                    "Those accomplishments are enough for Sarek’s name to be spoken with reverence, and his words quoted over decades by those seeking peace. His contributions to the Federation are many, and often subtle, but he left a lasting mark. While proud of his Vulcan heritage he had an appreciation of humanity, and both of his marriages were to human women.",
                    "In 2366, at the age of 201, Sarek was diagnosed with Bendii syndrome. This neurological disorder afflicts elderly Vulcans, impairing their emotional control and broadcasting their emotions telepathically. His condition was stabilized through a mind-meld with Captain Picard so that he could continue his last diplomatic work. He retired to Vulcan shortly afterwards. He died in 2368, survived by his second wife and the younger of his two sons, Spock. His eldest son, Sybok, had died some 80 years earlier."
                },
                Traits = new List<string>
                {
                    "Vulcan",
                    "Ambassador",
                    "Legendary Diplomat"
                },
                Values = new List<string>
                {
                    "What is necessary is never unwise",
                    "My logic is uncertain where my family is concerned",
                    "Proud of the Vulcan way"
                },
                Focuses = new List<string>
                {
                    Focus.Astrophysics, Focus.Composure, Focus.Diplomacy, Focus.History, Focus.Politics, "Vulcan Philosophy"
                },
                PersonalThreat = 12,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 12, Daring = 7, Fitness = 9, Insight = 8, Presence = 10, Reason = 11 },
                Departments = new Departments { Command = 5, Conn = 1, Engineering = 2, Security = 1, Medicine = 2, Science = 4 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.VulcanNervePinch)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Bendii Syndrome",
                        Description = new List<string>
                        {
                            "This rule applies only to Sarek in games set in the 2360s. Sarek has +2 complication range on all tasks that involve social interaction and control of his emotions. Additionally, Sarek loses the Composure focus, he may not pay to avoid any emotion-related traits, and increases the Potency of any emotion-related trait by 1. These penalties can be removed for the duration of a scene if a psychic character succeeds at a Difficulty 3 Control + Medicine task; they can be removed for the remainder of a mission if Sarek can perform a mind-meld with someone suitably disciplined and orderly (gamemaster’s discretion), though this can have massive side-effects for the recipient of the meld (gamemaster’s discretion again)."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    TalentSelector.GetTalentAsSpecialRule("Cold Reading"),
                    TalentSelector.GetTalentAsSpecialRule("Mind Meld"),
                    TalentSelector.GetTalentAsSpecialRule("Nerve Pinch"),
                    new()
                    {
                        Name = "Mental Discipline",
                        Description = new List<string>
                        {
                            "Sarek’s Personal Threat is equal to his Control, and he may suffer 2 Stress to avoid suffering any trait which represents an emotional state. If he becomes Fatigued, he increases the potency of any such emotion-related trait by 1."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                    new()
                    {
                        Name = "Renowned Diplomat",
                        Description = new List<string>
                        {
                            "Sarek’s renown and reputation are such that his mere presence can serve as the groundwork for diplomatic talks. Once per scene, when a character is involved in a social conflict reflecting peace talks, negotiations, or some other diplomatic mission, they may re-roll 1d20 as long as Sarek is present in the scene or was involved in establishing the talks."
                        },
                        Source = BookSource.CommandDivision1stEdition,
                    },
                },
                Source = BookSource.CommandDivision1stEdition,
            },
        };
    }

    private static IEnumerable<NonPlayerCharacter> GetKlingonNpcs()
    {
        return new List<NonPlayerCharacter>
        {
            new()
            {
                Name = "Klingon Warrior",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "A worthy warrior of the Klingon Empire."
                },
                Traits = new List<string>
                {
                    "Klingon",
                    "Warrior"
                },
                PersonalThreat = 0,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 7, Daring = 10, Fitness = 10, Insight = 7, Presence = 9, Reason = 8 },
                Departments = new Departments { Command = 1, Conn = 2, Engineering = 1, Security = 2, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.DkTahgDagger),
                    WeaponSelector.GetWeapon(WeaponName.BatLeth),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.BatLeth, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Warrior's Spirit"),
                }
            },
            new()
            {
                Name = "Klingon Veteran",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "A battle-hardened Klingon warrior."
                },
                Traits = new List<string>
                {
                    "Klingon",
                    "Warrior"
                },
                Values = new List<string>
                {
                    "Today is a Good Day to Die!"
                },
                Focuses = new List<string>
                {
                    Focus.HandToHandCombat, Focus.Resilience
                },
                PersonalThreat = 3,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 8, Daring = 11, Fitness = 10, Insight = 8, Presence = 10, Reason = 7 },
                Departments = new Departments { Command = 2, Conn = 2, Engineering = 1, Security = 3, Medicine = 1, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.DkTahgDagger),
                    WeaponSelector.GetWeapon(WeaponName.BatLeth),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.BatLeth, 1), (WeaponName.DisruptorRifle, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Lead by Example",
                        Description = new List<string>
                        {
                            "When the Klingon Officer makes a successful attack, they may spend 2 Threat to assist another Klingon’s next attack with his Daring + Command."
                        }
                    },
                    TalentSelector.GetTalentAsSpecialRule("Warrior's Spirit"),
                }
            },
            new()
            {
                Name = "Moq'var, son of Koloth",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Klingon commanders guide their ships through the quadrants, seeking honor and glory for themselves and their crews, and resources to benefit the Empire. Moq’var is representative of this type of officer."
                },
                Traits = new List<string>
                {
                    "Klingon",
                    "Commanding Officer"
                },
                Values = new List<string>
                {
                    "There is nothing more honorable than victory",
                    "To kill the defenseless is not true battle"
                },
                Focuses = new List<string>
                {
                    Focus.HandToHandCombat, Focus.Intimidation, Focus.Resilience, Focus.StarshipTactics
                },
                PersonalThreat = 8,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 9, Daring = 12, Fitness = 10, Insight = 9, Presence = 11, Reason = 8 },
                Departments = new Departments { Command = 3, Conn = 3, Engineering = 2, Security = 5, Medicine = 1, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.DkTahgDagger),
                    WeaponSelector.GetWeapon(WeaponName.BatLeth),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.BatLeth, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Hardy",
                        Description = new List<string>
                        {
                            "Moq’var is resilient and can shrug off wounds that would down normal combatants. Moq’var’s Personal Threat is increased by +2 (included above)."
                        }
                    },
                    new()
                    {
                        Name = "Lead by Example",
                        Description = new List<string>
                        {
                            "When Moq’var makes a successful attack, they may spend 2 Threat to assist another Klingon’s next attack with his Daring + Command."
                        }
                    },
                    TalentSelector.GetTalentAsSpecialRule("Warrior's Spirit"),
                }
            },
        };
    }

    private static IEnumerable<NonPlayerCharacter> GetRomulanNpcs()
    {
        return new List<NonPlayerCharacter>
        {
            new()
            {
                Name = "Romulan Uhlan",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "A rank-and-file soldier of the Romulan Star Empire."
                },
                Traits = new List<string>
                {
                    "Romulan",
                    "Soldier"
                },
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 10, Daring = 8, Fitness = 9, Insight = 8, Presence = 7, Reason = 10 },
                Departments = new Departments { Command = 1, Conn = 2, Engineering = 1, Security = 2, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.Dagger),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Guile and Cunning"),
                    TalentSelector.GetTalentAsSpecialRule("Wary"),
                }
            },
            new()
            {
                Name = "Romulan Centurion",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "An experienced soldier in the Romulan services."
                },
                Traits = new List<string>
                {
                    "Romulan",
                    "Imperial Navy Officer"
                },
                Values = new List<string>
                {
                    "I will not fail in my duty to the Empire"
                },
                Focuses = new List<string>
                {
                    "Guerilla Tactics", "Paranoia"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 9, Insight = 9, Presence = 7, Reason = 9 },
                Departments = new Departments { Command = 3, Conn = 2, Engineering = 1, Security = 2, Medicine = 0, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.Dagger),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Group Ambush",
                        Description = new List<string>
                        {
                            "When the centurion makes an attack against an enemy who is unaware of their presence, they may spend 2 Threat to increase the severity of this and all other attacks made this round by them and their subordinates by 1."
                        }
                    },
                    TalentSelector.GetTalentAsSpecialRule("Guile and Cunning"),
                    TalentSelector.GetTalentAsSpecialRule("Wary"),
                }
            },
            new()
            {
                Name = "Major Verohk, Tal Shiar Agent",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Verohk is a member of the Romulan Empire’s intelligence arm, the Tal Shiar."
                },
                Traits = new List<string>
                {
                    "Romulan",
                    "Agent of the Tal Shiar"
                },
                Values = new List<string>
                {
                    "The ends justify the means",
                    "Everything I do, I do for Romulus"
                },
                Focuses = new List<string>
                {
                    Focus.Deception, Focus.Infiltration, Focus.Interrogation, "Propaganda"
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 9, Insight = 10, Presence = 9, Reason = 11 },
                Departments = new Departments { Command = 4, Conn = 2, Engineering = 3, Security = 2, Medicine = 2, Science = 3 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.Dagger),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Guile and Cunning"),
                    new()
                    {
                        Name = "Supreme Authority",
                        Description = new List<string>
                        {
                            "Whenever a Romulan under Major Verohk’s command attempts a task to resist persuasion or intimidation, Verohk may spend 1 Threat to allow that Romulan to re-roll, even if Verohk is not present in the scene herself."
                        }
                    },
                    TalentSelector.GetTalentAsSpecialRule("Wary"),
                }
            },
        };
    }

    private static IEnumerable<NonPlayerCharacter> GetCardassianNpcs()
    {
        return new List<NonPlayerCharacter>
        {
            new()
            {
                Name = "Cardassian Soldier",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Representative of countless Cardassian soldiers protecting Cardassian interests."
                },
                Traits = new List<string>
                {
                    "Cardassian",
                    "Soldier"
                },
                PersonalThreat = 0,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 10, Daring = 9, Fitness = 8, Insight = 7, Presence = 8, Reason = 9 },
                Departments = new Departments { Command = 1, Conn = 3, Engineering = 1, Security = 2, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Healthy Suspicions",
                        Description = new List<string>
                        {
                            "The Cardassian Soldier may buy their first d20 for free when attempting to determine if someone is lying."
                        }
                    },
                    new()
                    {
                        Name = "Loyal",
                        Description = new List<string>
                        {
                            "Whenever a Cardassian assists a task performed by someone they deem their superior, they may reroll their assistance die."
                        }
                    },
                }
            },
            new()
            {
                Name = "Cardassian Glinn",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "An experienced and loyal Cardassian soldier with rank and responsibility to lead others."
                },
                Traits = new List<string>
                {
                    "Cardassian",
                    "Military Officer"
                },
                Values = new List<string>
                {
                    "Cardassians did not choose to be superior, fate made us this way"
                },
                Focuses = new List<string>
                {
                    Focus.MilitaryTactics, Focus.Willpower
                },
                PersonalThreat = 3,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 11, Daring = 8, Fitness = 7, Insight = 8, Presence = 10, Reason = 10 },
                Departments = new Departments { Command = 2, Conn = 2, Engineering = 1, Security = 2, Medicine = 0, Science = 1 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Healthy Suspicions",
                        Description = new List<string>
                        {
                            "The Cardassian Glinn may buy their first d20 for free when attempting to determine if someone is lying."
                        }
                    },
                    new()
                    {
                        Name = "Expects Success",
                        Description = new List<string>
                        {
                            "Whenever the Cardassian Glinn uses the Direct or Assist task to aid a subordinate, that task may always Succeed at Cost."
                        }
                    },
                    new()
                    {
                        Name = "Loyal",
                        Description = new List<string>
                        {
                            "Whenever a Cardassian Glinn assists a task performed by someone they deem their superior, they may reroll their assistance die."
                        }
                    },
                }
            },
            new()
            {
                Name = "Gul Tremak",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "An experienced and loyal Cardassian soldier with rank and responsibility to lead others."
                },
                Traits = new List<string>
                {
                    "Cardassian",
                    "Military Officer"
                },
                Values = new List<string>
                {
                    "Cardassia expects everyone to do their duty",
                    "Knowledge is power, and power is everything"
                },
                Focuses = new List<string>
                {
                    Focus.Debate, Focus.MilitaryTactics, Focus.Politics, Focus.Willpower
                },
                PersonalThreat = 8,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 8, Insight = 9, Presence = 12, Reason = 10 },
                Departments = new Departments { Command = 4, Conn = 4, Engineering = 2, Security = 2, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorRifle)
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.DisruptorRifle, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Cultured",
                        Description = new List<string>
                        {
                            "When engaged in social conflict, and given an opportunity to speak at length on a subject, Gul Tremak if he purchases any bonus d20s he may re-roll his dice pool."
                        }
                    },
                    new()
                    {
                        Name = "Healthy Suspicions",
                        Description = new List<string>
                        {
                            "Gul Tremak may buy their first d20 for free when attempting to determine if someone is lying."
                        }
                    },
                    new()
                    {
                        Name = "Loyal",
                        Description = new List<string>
                        {
                            "Whenever Gul Tremak assists a task performed by someone they deem their superior, they may reroll their assistance die."
                        }
                    },
                    new()
                    {
                        Name = "Ruthless",
                        Description = new List<string>
                        {
                            "When Gul Tremak makes an attack against an enemy that was not aware of or prepared for an attack, or against an enemy that is defenseless, he may spend 1 Threat to re-roll any number of d20s in his dice pool."
                        }
                    },
                }
            },
        };
    }

    private static IEnumerable<NonPlayerCharacter> GetFerengiNpcs()
    {
        return new List<NonPlayerCharacter>
        {
            new()
            {
                Name = "Ferengi Menial",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Representative of a young Ferengi working their way up into the world, or of a Ferengi lacking the lobes for independent success."
                },
                Traits = new List<string>
                {
                    "Ferengi",
                    "Underling"
                },
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 7, Fitness = 7, Insight = 10, Presence = 10, Reason = 8 },
                Departments = new Departments { Command = 1, Conn = 2, Engineering = 2, Security = 1, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.PhaserType1)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Greed is Eternal"),
                }
            },
            new()
            {
                Name = "Ferengi Salesman",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "An experienced Ferengi with some latinum and prestige to their name, always looking for the next deal to make themselves wealthier."
                },
                Traits = new List<string>
                {
                    "Ferengi",
                    "Merchant"
                },
                Values = new List<string>
                {
                    "First Rule of Acquisition: Once you have their money, never give it back"
                },
                Focuses = new List<string>
                {
                    Focus.Economics, Focus.Negotiation
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 7, Insight = 9, Presence = 10, Reason = 8 },
                Departments = new Departments { Command = 3, Conn = 1, Engineering = 2, Security = 1, Medicine = 0, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    TalentSelector.GetTalentAsSpecialRule("Greed is Eternal"),
                    TalentSelector.GetTalentAsSpecialRule("Never Place Friendship Above Profit"),
                }
            },
            new()
            {
                Name = "DaiMon Skel",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "A DaiMon is often either an experienced businessman, with large lobes for business, or a military officer with a ship of their own and the will to use it effectively. The most cunning are both. DaiMon Skel is representative of such an officer."
                },
                Traits = new List<string>
                {
                    "Ferengi",
                    "Entrepreneur"
                },
                Values = new List<string>
                {
                    "48th Rule of Acquisition: The bigger the smile, the sharper the knife",
                    "211th Rule of Acquisition: Employees are the rungs on the ladder to success; don’t hesitate to step on them"
                },
                Focuses = new List<string>
                {
                    "Bribery", Focus.Negotiation, Focus.StarshipTactics, Focus.Subterfuge
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 10, Daring = 11, Fitness = 8, Insight = 10, Presence = 11, Reason = 9 },
                Departments = new Departments { Command = 4, Conn = 3, Engineering = 3, Security = 3, Medicine = 1, Science = 2 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.EnergyWhip),
                    WeaponSelector.GetWeapon(WeaponName.DisruptorPistol)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Free Advice is Seldom Cheap",
                        Description = new List<string>
                        {
                            "Increase the Difficulty of all social conflict tasks to persuade DaiMon Skel by 2. This Difficulty increase is removed as soon as Skel is offered something in trade."
                        }
                    },
                    TalentSelector.GetTalentAsSpecialRule("Greed is Eternal"),
                    new()
                    {
                        Name = "You Can't Make a Deal if You're Dead",
                        Description = new List<string>
                        {
                            "DaiMon Skel will never make a Deadly attack. Further, when attempting a task to make a deal or persuade an enemy he has previously incapacitated, or an enemy who obviously outmatches him, he may add a bonus d20 to the roll for free."
                        }
                    },
                }
            },
        };
    }

    private static IEnumerable<NonPlayerCharacter> GetDominionNpcs()
    {
        return new List<NonPlayerCharacter>
        {
            new()
            {
                Name = "Jem'Hadar Warrior",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "One of countless genetically engineered warriors designed to obey and to follow the Founders’ will through their Vorta handlers."
                },
                Traits = new List<string>
                {
                    "Jem'Hadar",
                    "Warrior"
                },
                PersonalThreat = 0,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 8, Daring = 10, Fitness = 10, Insight = 9, Presence = 7, Reason = 7 },
                Departments = new Departments { Command = 1, Conn = 2, Engineering = 2, Security = 2, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.Blade),
                    WeaponSelector.GetWeapon(WeaponName.JemHadarPlasmaRifle),
                    WeaponSelector.GetWeapon(WeaponName.KarTakin),
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.KarTakin, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Brute Force",
                        Description = new List<string>
                        {
                            "Jem’Hadar add the Intense effect to their Unarmed Strike, and may attack with Deadly force."
                        },
                        UnarmedStrikesCanBeDeadly = true,
                        AddQualitiesToUnarmedStrikes = new List<string> { "Intense" }
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToFear),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToPain),
                    new()
                    {
                        Name = "The Shroud",
                        Description = new List<string>
                        {
                            "A Jem’Hadar may spend 1 Threat as a minor action to become virtually invisible, increasing the Difficulty of all tasks to observe, locate, or target the Jem’Hadar by 3. This effect ends when the Jem’Hadar makes an Attack, or takes a minor action to end the effect. The Jem’Hadar loses this ability when deprived of ketracel-white."
                        }
                    },
                },
            },
            new()
            {
                Name = "Jem'Hadar First",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "A battle-tested warrior who has seen their share of battle, a Jem’Hadar First is a fearsome opponent on the battlefield."
                },
                Traits = new List<string>
                {
                    "Jem'Hadar",
                    "Warrior"
                },
                Values = new List<string>
                {
                    "We are now dead; we go into battle to reclaim our lives",
                },
                Focuses = new List<string>
                {
                    Focus.CombatTactics, Focus.HandToHandCombat
                },
                PersonalThreat = 3,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 9, Daring = 10, Fitness = 11, Insight = 9, Presence = 8, Reason = 7 },
                Departments = new Departments { Command = 2, Conn = 2, Engineering = 1, Security = 3, Medicine = 1, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                    WeaponSelector.GetWeapon(WeaponName.Blade),
                    WeaponSelector.GetWeapon(WeaponName.JemHadarPlasmaRifle),
                    WeaponSelector.GetWeapon(WeaponName.KarTakin),
                },
                EscalationAttacks = new List<(string, int)> { (WeaponName.KarTakin, 1) },
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Brute Force",
                        Description = new List<string>
                        {
                            "Jem’Hadar add the Intense effect to their Unarmed Strike, and may attack with Deadly force."
                        },
                        UnarmedStrikesCanBeDeadly = true,
                        AddQualitiesToUnarmedStrikes = new List<string> { "Intense" }
                    },
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToFear),
                    NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToPain),
                    new()
                    {
                        Name = "The Shroud",
                        Description = new List<string>
                        {
                            "A Jem’Hadar may spend 1 Threat as a minor action to become virtually invisible, increasing the Difficulty of all tasks to observe, locate, or target the Jem’Hadar by 3. This effect ends when the Jem’Hadar makes an Attack, or takes a minor action to end the effect. The Jem’Hadar loses this ability when deprived of ketracel-white."
                        }
                    },
                    new()
                    {
                        Name = "Victory is Life",
                        Description = new List<string>
                        {
                            "Whenever a Jem’Hadar First or one of its subordinates inflicts an Injury or achieves an objective, add 1 Threat."
                        }
                    },
                },
            },
            new()
            {
                Name = "Taris, Vorta Overseer",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "Vorta act as the mouthpieces for the Founders, the leaders of the Dominion. Vorta oversee the Jem’Hadar and command them through threats and through the warriors’ dependence on ketracel-white. Taris is representative of the genetically-engineered Vorta."
                },
                Traits = new List<string>
                {
                    "Vorta",
                    "Diplomat"
                },
                Values = new List<string>
                {
                    "I live to serve the Founders",
                    "There is nothing I will not do to succeed"
                },
                Focuses = new List<string>
                {
                    Focus.Deception, Focus.Diplomacy, Focus.Observation, Focus.Psychology
                },
                PersonalThreat = 8,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 9, Insight = 11, Presence = 12, Reason = 10 },
                Departments = new Departments { Command = 4, Conn = 3, Engineering = 2, Security = 2, Medicine = 2, Science = 3 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "In the Name of the Founders",
                        Description = new List<string>
                        {
                            "When using the Direct or Assist task to command other servants of the Dominion, a Vorta may roll 2d20 instead of 1d20."
                        },
                    },
                    new()
                    {
                        Name = "Manipulative",
                        Description = new List<string>
                        {
                            "If Taris purchases one or more d20s when attempting a task to deceive or intimidate another, she may re-roll her dice pool."
                        }
                    },
                },
            },
        };
    }

    private static IEnumerable<NonPlayerCharacter> GetCreatures()
    {
        return new List<NonPlayerCharacter>
        {
            new()
            {
                Name = "Berengarian Dragon",
                TypeEnum = NPCType.Major,
                Description = new List<string>
                {
                    "A huge animal more than 200 meters in length from nose to tail-tip, the dragons of Berengaria VII are capable of flight and breath fire. Their scale colors tend to vary from lavender to purple to violet."
                },
                Traits = new List<string>
                {
                    "Berengarian Dragon",
                    "Flying",
                    "Massive",
                    "Animal"
                },
                Values = new List<string>
                {
                    "Arboreal hunter",
                    "Pays small creatures little heed"
                },
                Focuses = new List<string>
                {
                    "Hunting", "Melee", Focus.Observation
                },
                PersonalThreat = 8,
                Protection = 4,
                Attributes = new CharacterAttributes { Control = 10, Daring = 12, Fitness = 12, Insight = 5, Presence = 10, Reason = 4 },
                Departments = new Departments { Command = 3, Conn = 0, Engineering = 0, Security = 2, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    new()
                    {
                        Name = "Claws",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.Deadly,
                        Severity = 4,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>
                        {
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Area)
                        }
                    },
                    new()
                    {
                        Name = "Bite",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.Deadly,
                        Severity = 5,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>
                        {
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Debilitating),
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Piercing)
                        }
                    },
                    new()
                    {
                        Name = "Fire Breath",
                        Type = WeaponType.Ranged,
                        Injury = InjuryType.Deadly,
                        Severity = 3,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>
                        {
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Area)
                        }
                    },
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Massive",
                        Description = new List<string>
                        {
                            "The Berengarian Dragon is massive. It must suffer three Injuries before it is defeated."
                        }
                    }
                },
            },
            new()
            {
                Name = "Moopsy",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Deceptively cute, the moopsy is actually a terrifying predatory creature that bites its prey and injects venom that dissolves bone. It then slurps up the prey’s skeletal slush."
                },
                Traits = new List<string>
                {
                    "Moopsy",
                    "Deceptive",
                    "Small",
                    "Venomous"
                },
                Values = new List<string>
                {
                    "Moopsy!"
                },
                PersonalThreat = 3,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 3, Daring = 5, Fitness = 3, Insight = 5, Presence = 6, Reason = 3 },
                Departments = new Departments { Command = 0, Conn = 0, Engineering = 0, Security = 2, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    new()
                    {
                        Name = "Venomous Bite",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.Deadly,
                        Severity = 4,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>
                        {
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Intense),
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Piercing),
                        }
                    }
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Bone-Dissolving Venom",
                        Description = new List<string>
                        {
                            "When the moopsy successfully injures a living being, it injects a lethal venom that dissolves the being’s skeletal system."
                        }
                    }
                },
            },
            new()
            {
                Name = "Mugato",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Native to Neural, mugato are powerful, white-furred creatures with a large horn on their head and a venomous bite. In some regions, they are known as gumato, mugutu, mogatu, or muguto."
                },
                Traits = new List<string>
                {
                    "Mugato",
                    "Venomous",
                    "Animal"
                },
                Values = new List<string>
                {
                    "Territorial hunter"
                },
                Focuses = new List<string>
                {
                    "Melee", Focus.Tracking
                },
                PersonalThreat = 3,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 6, Daring = 8, Fitness = 11, Insight = 4, Presence = 10, Reason = 6 },
                Departments = new Departments { Command = 0, Conn = 0, Engineering = 0, Security = 2, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    new()
                    {
                        Name = "Claws",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.Deadly,
                        Severity = 3,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>
                        {
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Intense)
                        }
                    },
                    new()
                    {
                        Name = "Bite",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.Deadly,
                        Severity = 4,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>
                        {
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Cumbersome),
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Debilitating)
                        }
                    },
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Venomous",
                        Description = new List<string>
                        {
                            "After successfully biting an enemy, a mugato may spend 1 Threat to inject them with venom. This creates a Poisoned Injury, and the creature remains defeated until a cure for the poison is found."
                        }
                    }
                },
            },
            new()
            {
                Name = "Neural Parasite",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Neural parasites are small creatures that attach themselves to targets and take over the host body, inducing insanity and then death. Neural parasites are migratory, and have been encountered in a number of locations across the Galaxy, including Deneva, Levinius V, and Ingraham B."
                },
                Traits = new List<string>
                {
                    "Neural Parasite",
                    "Limited Flight",
                    "Animal"
                },
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 9, Daring = 4, Fitness = 8, Insight = 4, Presence = 5, Reason = 6 },
                Departments = new Departments { Command = 1, Conn = 0, Engineering = 0, Security = 1, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Attach",
                        Description = new List<string>
                        {
                            "When a neural parasite makes a melee attack, it attaches itself to its victim rather than inflicting an Injury. If it succeeds, it fuses with the creature’s nervous system and takes control of it."
                        }
                    }
                },
            },
            new()
            {
                Name = "Sehlat",
                TypeEnum = NPCType.Notable,
                Description = new List<string>
                {
                    "Native to Vulcan, sehlats are large predatory creatures with fangs and claws, and are generally light brown to dark gray in color. They are fearsome in the wild, but can be domesticated up to a point."
                },
                Traits = new List<string>
                {
                    "Sehlat",
                    "Desert Predator",
                    "Animal"
                },
                Values = new List<string>
                {
                    "Territorial hunter"
                },
                Focuses = new List<string>
                {
                    "Melee", Focus.Stealth
                },
                PersonalThreat = 3,
                Protection = 2,
                Attributes = new CharacterAttributes { Control = 8, Daring = 11, Fitness = 12, Insight = 6, Presence = 9, Reason = 2 },
                Departments = new Departments { Command = 2, Conn = 0, Engineering = 0, Security = 3, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    new()
                    {
                        Name = "Claws and Teeth",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.Deadly,
                        Severity = 4,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>
                        {
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Intense),
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Debilitating)
                        }
                    },
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>()
            },
            new()
            {
                Name = "Talarian Hook Spider",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Found in warm environments, Talarian hook spiders are small arachnids with legs a half-meter in length."
                },
                Traits = new List<string>
                {
                    "Talarian Hook Spider",
                    "Lurking",
                    "Arachnid"
                },
                PersonalThreat = 0,
                Protection = 1,
                Attributes = new CharacterAttributes { Control = 10, Daring = 7, Fitness = 8, Insight = 2, Presence = 2, Reason = 4 },
                Departments = new Departments { Command = 1, Conn = 0, Engineering = 0, Security = 3, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    new()
                    {
                        Name = "Hooks",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.Stun,
                        Severity = 3,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>()
                    },
                    new()
                    {
                        Name = "Bite",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.Deadly,
                        Severity = 4,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>
                        {
                            WeaponSelector.GetWeaponQuality(WeaponQualityName.Intense)
                        }
                    },
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Web",
                        Description = new List<string>
                        {
                            "As a major action, a hook spider can fill its zone with sticky webbing. This makes the zone difficult terrain with a cost of 1, or adds 1 to the cost of any existing difficult terrain."
                        }
                    }
                },
            },
            new()
            {
                Name = "Targ",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Native to Qo’noS, targs are cultivated as livestock or pets, though wild targs are hunted for their meat and milk."
                },
                Traits = new List<string>
                {
                    "Targ",
                    "Stubborn Beast",
                    "Animal"
                },
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 4, Daring = 10, Fitness = 11, Insight = 5, Presence = 8, Reason = 2 },
                Departments = new Departments { Command = 2, Conn = 0, Engineering = 0, Security = 2, Medicine = 0, Science = 0 },
                Attacks = new List<Weapon>
                {
                    new()
                    {
                        Name = "Tusks",
                        Type = WeaponType.Melee,
                        Injury = InjuryType.StunOrDeadly,
                        Severity = 3,
                        Size = WeaponSize.OneHanded,
                        Qualities = new List<WeaponQuality>()
                    }
                },
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Rush",
                        Description = new List<string>
                        {
                            "As a major action, a targ may charge at an enemy within Medium range. The targ moves to any adjacent zone, and makes a melee attack against the chosen enemy. If the attack hits, the enemy is also knocked prone."
                        }
                    }
                },
            },
            new()
            {
                Name = "Tribble",
                TypeEnum = NPCType.Minor,
                Description = new List<string>
                {
                    "Tribbles are small, furry life-forms native to the plant Iota Geminorum IV. They make soft, calming, purring sounds when touched, and breed at an alarming rate. When close to Klingons, tribbles emit a high-pitched shriek."
                },
                Traits = new List<string>
                {
                    "Tribble",
                    "Animal"
                },
                PersonalThreat = 0,
                Protection = 0,
                Attributes = new CharacterAttributes { Control = 4, Daring = 8, Fitness = 4, Insight = 6, Presence = 9, Reason = 6 },
                Departments = new Departments { Command = 0, Conn = 0, Engineering = 1, Security = 0, Medicine = 0, Science = 1 },
                Attacks = new List<Weapon>(),
                EscalationAttacks = new List<(string, int)>(),
                SpecialRules = new List<NpcSpecialRule>
                {
                    new()
                    {
                        Name = "Klingon Disdain",
                        Description = new List<string>
                        {
                            "A tribble’s reaction is strong enough to automatically detect the presence of a Klingon—even one disguised or surgically altered— within Close range, while a disguised Klingon must attempt a Control + Command task with a Difficulty of 2 to mask their disgust at the tribble’s presence."
                        }
                    }
                },
            },
        };
    }
}
