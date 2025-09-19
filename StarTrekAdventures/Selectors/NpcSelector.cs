using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using System.Diagnostics.Metrics;
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
        var allNpcs = new List<NonPlayerCharacter>();
        allNpcs.AddRange(GetNextGenerationCrew());
        allNpcs.AddRange(GetPicardSeasonOneCrew());
        allNpcs.AddRange(GetStarfleetNpcs());
        allNpcs.AddRange(GetFederationNpcs());
        allNpcs.AddRange(GetKlingonNpcs());
        allNpcs.AddRange(GetRomulanNpcs());
        allNpcs.AddRange(GetCardassianNpcs());
        allNpcs.AddRange(GetFerengiNpcs());
        allNpcs.AddRange(GetDominionNpcs());
        allNpcs.AddRange(GetCreatures());
        allNpcs.AddRange(GetUnusualLifeforms());
        return allNpcs;
    }

    

    private static IEnumerable<NonPlayerCharacter> GetNextGenerationCrew() => new List<NonPlayerCharacter>
    {
        new()
        {
            Name = "Captain Jean-Luc Picard",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "“I’ve followed Captain Picard’s career for a long time starting with his days aboard the Stargazer and after his promotion to captain of Starfleet’s flagship. It was almost inevitable that his name would become known across the Federation, unfortunately his involvement in the battle of Wolf 359 has made this for the wrong reasons. Memories are long and the loss of life was devastating, and even I had toq uestion his place within Starfleet. However, where some men would have retreated, Picard has strived forward, continuing Starfleet’s mission of exploration and discovery as well as foiling several significant threats to the Federation, reasserting himself into his past position of trust.”"
            },
            Traits = new List<string>
            {
                "Human",
                "Liberated Borg",
                "Starfleet Officer",
                "Artificial Heart",
                "Captain of the Enterprise"
            },
            Values = new List<string>
            {
                "Duty before all else",
                "Haunted by the Borg",
                "Loyal to the ideals of the Federation",
                "Living through one life, I realize what I’ve missed"
            },
            Focuses = new List<string>
            {
                Focus.Astrophysics, Focus.Composure, Focus.Diplomacy, Focus.Infiltration, Focus.StarfleetProtocol, "Xeno-Archaeology"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 9, Fitness = 8, Insight = 10, Presence = 10, Reason = 9 },
            Departments = new Departments { Command = 5, Conn = 3, Engineering = 2, Security = 2, Medicine = 1, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Advisor"),
                TalentSelector.GetTalentAsSpecialRule("Cautious (Command)"),
                new()
                {
                    Name = "Commanding Officer",
                    Description = new List<string>
                    {
                        "You may spend Determination to grant any other character you can communicate with 1 Determination; this does not have to be linked to using or challenging a value."
                    },
                    Source = BookSource.Core,
                },
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Spirit of Discovery"),
                TalentSelector.GetTalentAsSpecialRule("Veteran"),
            },
            Source = BookSource.NextGenerationCrewPack1stEdition,
        },
        new()
        {
            Name = "Commander William Riker",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "“Judging from reports and the brief contact I’ve had with him, Commander Riker has always struck me as an old-school officer in the vein of Captain Kirk, quick to take action but holds responsibility and care for the Federation.",
                "“Riker always seems to be up for a challenge, such as distinguishing himself as the first Starfleet officer to serve aboard a Klingon ship, but the several times he has been offered a command of his own have all been turned down. I have a suspicion that he has at least one eye on the Enterprise after Captain Picard steps down.”"
            },
            Traits = new List<string>
            {
                "Human",
                "Starfleet Officer",
            },
            Values = new List<string>
            {
                "Live life to the full",
                "One true love, Deanna",
                "Worth the risk",
                "When all looks lost, improvise"
            },
            Focuses = new List<string>
            {
                "Anbo-Jyutsu", Focus.Astrophysics, Focus.Diplomacy, Focus.Gambling, Focus.HandPhasers, Focus.StarshipTactics
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 11, Fitness = 10, Insight = 8, Presence = 10, Reason = 9 },
            Departments = new Departments { Command = 5, Conn = 3, Engineering = 2, Security = 4, Medicine = 1, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Bold (Security)"),
                new()
                {
                    Name = "Executive Officer",
                    Description = new List<string>
                    {
                        "When an allied character in communication with you spends Determination, you may spend 3 Momentum (Immediate) to enable that character to regain the spent point of Determination."
                    },
                    Source = BookSource.Core,
                },
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Follow my Lead"),
                TalentSelector.GetTalentAsSpecialRule("Mean Right Hook"),
                TalentSelector.GetTalentAsSpecialRule("Quick to Action"),
            },
            Source = BookSource.NextGenerationCrewPack1stEdition,
        },
        new()
        {
            Name = "Commander Deanna Troi",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "“Over a thousand people call the Enterprise-D home, Starfleet officers as well as their families, and each and every one is goi ng to need to talk to someone about their experiences. This is where Counselor Troi does a fantastic job, her empathic abilities allow her to truly see how her clients are feeling and help them deal with their problems. On the bridge Counselor Troi has also been invaluable as her empathic abilities coupled with her negotiation skills have helped the Enterprise in numerous encounters.",
                " “I once had the pleasure of meeting Commander Troi’s mother, Lwaxana, after the Pacifica conference five years ago, but that is another story...”"
            },
            Traits = new List<string>
            {
                "Betazoid",
                "Human",
                "Starfleet Officer",
                "Psychiatrist"
            },
            Values = new List<string>
            {
                "I can tell when you’re lying",
                "My Imzadi, Will",
                "Mother issues",
                "Whenever possible, talk it out",
            },
            Focuses = new List<string>
            {
                Focus.CulturalStudies, Focus.Diplomacy, Focus.Persuasion, Focus.Psychiatry, Focus.Psychology, "Romulan Engineering"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 8, Insight = 12, Presence = 10, Reason = 9 },
            Departments = new Departments { Command = 4, Conn = 3, Engineering = 1, Security = 1, Medicine = 4, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Cautious (Medicine)"),
                TalentSelector.GetTalentAsSpecialRule("Defuse the Tension"),
                TalentSelector.GetTalentAsSpecialRule("Empathy"),
                TalentSelector.GetTalentAsSpecialRule("Open Book"),
                new()
                {
                    Name = "Ship's Counselor",
                    Description = new List<string>
                    {
                        "When you Assist a character suffering from a trait representing a negative emotional state, you may re-roll your assist die. Additionally, once per mission, you may spend a scene counseling a character who has challenged one of their values during the current mission. At the end of the scene, the character may rewrite their crossed-out value immediately, rather than waiting until the end of the mission. If they do this, they immediately gain 1 Determination as well."
                    },
                    Source = BookSource.Core,
                },
                TalentSelector.GetTalentAsSpecialRule("Studious"),
            },
            Source = BookSource.NextGenerationCrewPack1stEdition,
        },
        new()
        {
            Name = "Doctor Beverly Crusher",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "“I’ve only ever had the chance to meet Doctor Crusher once but even in that short time I knew her, she was an exemplary officer. It was just after she had been appointed head of Starfleet Medical and was due to give a talk at the Academy. She told me about her work on the Enterprise, her hope that her son Wesley would be successful when he reapplied to Starfleet Academy after his initial failure and her anticipation that her own experiences could bring something new to Starfleet Medical. Her level of dedication and expertise are an inspiration to everyone doctor, medic or young officer that has had the opportunity to meet her.”",
            },
            Traits = new List<string>
            {
                "Human",
                "Starfleet Officer",
                "Physician",
                "Briefly Head of Starfleet Medical"
            },
            Values = new List<string>
            {
                "I believe in the sanctity of life",
                "If there’s a problem, I’m going to solve it",
                "My true family and those that might have been",
                "The play’s the thing",
            },
            Focuses = new List<string>
            {
                Focus.Botany, Focus.EmergencyMedicine, Focus.Infiltration, "Pathology", Focus.Surgery, Focus.Xenobiology
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 9, Insight = 11, Presence = 10, Reason = 10 },
            Departments = new Departments { Command = 4, Conn = 1, Engineering = 1, Security = 1, Medicine = 5, Science = 4 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.AnestheticHypospray),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Chief Medical Offier",
                    Description = new List<string>
                    {
                        "You reduce the opportunity cost of medical equipment and medical teams by 1, to a minimum of 0. Further, when you attempt a task using your Medicine rating, and you have assistance, you generate 1 bonus Momentum (bonus Momentum may not be saved)."
                    },
                    Source = BookSource.Core,
                },
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("First Response"),
                TalentSelector.GetTalentAsSpecialRule("Quick Study"),
                TalentSelector.GetTalentAsSpecialRule("Triage"),
                TalentSelector.GetTalentAsSpecialRule("Veteran"),
            },
            Source = BookSource.NextGenerationCrewPack1stEdition,
        },
        new()
        {
            Name = "Lieutenant Commander Data",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "“I was only a Lieutenant when I first heard about Lieutenant Commander Data entering Starfleet Academy but even then I was fascinated by the opportunities he could give the Federation, we could learn so much from him as he learnt about us. It wasn’t until the whole Maddox fiasco that I realized just what Data was, a whole new life form and not just a machine we could observe. Since that shift in perspective I’ve followed Mr. Data’s career not as one views a scientific experiment but as one sees the development of a young officer into someone extraordinary.”",
            },
            Traits = new List<string>
            {
                "Soong-type Android",
                "Starfleet Officer",
                "Unique Artificial Being",
                "No Emotions"
            },
            Values = new List<string>
            {
                "Family matters",
                "Know a man by his friends",
                "Vast repository of information",
                "What is it to be Human?",
            },
            Focuses = new List<string>
            {
                Focus.Astrophysics, Focus.Computers, Focus.Cybernetics, Focus.QuantumMechanics, "Spatial Phenomena,", Focus.WarpFieldDynamics
            },
            PersonalThreat = 8,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 10, Daring = 9, Fitness = 11, Insight = 7, Presence = 8, Reason = 12 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 4, Security = 2, Medicine = 1, Science = 4 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Duranium Polyalloy Construction"),
                new()
                {
                    Name = "Operations Manager",
                    Description = new List<string>
                    {
                        "Whenever you create a trait representing a piece of equipment, or an alteration made to existing equipment, any character who benefits from that trait while you are present in the scene may re-roll a d20."
                    },
                    Source = BookSource.Core,
                },
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.SyntheticLifeForm),
                TalentSelector.GetTalentAsSpecialRule("Technical Expertise"),
                TalentSelector.GetTalentAsSpecialRule("The Power of Math"),
                TalentSelector.GetTalentAsSpecialRule("Veteran"),
            },
            Source = BookSource.NextGenerationCrewPack1stEdition,
        },
        new()
        {
            Name = "Lieutenant Commander Geordi La Forge",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "“During his early career, it soon became obvious that Mr. La Forge was an outstanding officer. When his assignment to the Jovian Run brought him into contact with Captain Picard it eventually earned him a position aboard the Enterprise-D as conn officer, but few could have foreseen his promotion to chief engineer a year later. Since then La Forge has shown himself to be essential to the running of the Enterprise, as well as being integral to solving some of the challenges that have faced the crew over the years. Without his expertise the Federation may be a very different place.”",
            },
            Traits = new List<string>
            {
                "Soong-type Android",
                "Starfleet Officer",
                "Blind"
            },
            Values = new List<string>
            {
                "For every problem, there’s a solution",
                "Great is not good enough, perfection is what’s needed",
                "If I can help, I will",
                "Some friends are built, not born",
            },
            Focuses = new List<string>
            {
                Focus.HelmOperations, Focus.Improvisation, Focus.Linguistics, Focus.SmallCraft, Focus.TransportersAndReplicators, Focus.WarpEngines
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 9, Fitness = 9, Insight = 9, Presence = 9, Reason = 12 },
            Departments = new Departments { Command = 2, Conn = 4, Engineering = 5, Security = 1, Medicine = 1, Science = 3 },
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
                    Name = "Chief Engineer",
                    Description = new List<string>
                    {
                        "You reduce the opportunity cost of engineering teams by 1, to a minimum of 0. Further, when you attempt a task to perform repairs to a starship or attempt to push the ship’s capabilities beyond its normal limits, you may spend 1 Momentum (Immediate) to re-roll a d20."
                    },
                    Source = BookSource.Core,
                },
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("I Know my Ship"),
                TalentSelector.GetTalentAsSpecialRule("In the Nick of Time"),
                TalentSelector.GetTalentAsSpecialRule("Jury-Rig"),
                TalentSelector.GetTalentAsSpecialRule("Technical Expertise"),
                new()
                {
                    Name = "Visor",
                    Description = new List<string>
                    {
                        "Geordi’s VISOR allows him to ‘see’ despite his blindness, and allows him to perceive a much wider portion of the electromagnetic spectrum, in addition to normal visible light."
                    },
                    Source = BookSource.NextGenerationCrewPack1stEdition,
                },
            },
            Source = BookSource.NextGenerationCrewPack1stEdition,
        },
        new()
        {
            Name = "Lieutenant Worf",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "“I have to be honest; when I first heard that a Klingon had applied to Starfleet I was surprised. Although relations between us had improved significantly I never thought I’d see the day when a Klingon warrior would even want to join us. Worf’s adoptive parents may have been responsible for this initial choice, but as records show, Worf has had several significant encounters with his Klingon heritage, and his ideals and dedication to Starfleet have persisted. I look forward to seeing where his career will take him and hope that he may be able to facilitate better relations between us and the Klingon Empire.”",
            },
            Traits = new List<string>
            {
                "Klingon",
                "Starfleet Officer",
                "Eldest Son of Mogh",
                "Entangled in Klingon Politics"
            },
            Values = new List<string>
            {
                "A warrior’s rage",
                "Always the outsider",
                "Legacy of the House of Mogh",
                "Proud and honorable Klingon warrior",
            },
            Focuses = new List<string>
            {
                Focus.CombatTactics, Focus.HandPhasers, Focus.Infiltration, "Klingon Culture", "Mok’bara", Focus.ShipboardTacticalSystems
            },
            PersonalThreat = 8,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 8, Daring = 12, Fitness = 11, Insight = 7, Presence = 10, Reason = 8 },
            Departments = new Departments { Command = 3, Conn = 4, Engineering = 2, Security = 5, Medicine = 1, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.BatLeth),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.BatLeth, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.BrakLul),
                new()
                {
                    Name = "Chief of Security",
                    Description = new List<string>
                    {
                        "You reduce the opportunity cost of weapons and security teams by 1, to a minimum of 0. Further, when you succeed at an Attack against an enemy during personal combat, you may spend 1 Momentum to increase the Difficulty of that enemy’s next Attack by 1."
                    },
                    Source = BookSource.Core,
                },
                TalentSelector.GetTalentAsSpecialRule("Constantly Watching"),
                TalentSelector.GetTalentAsSpecialRule("Dauntless"),
                TalentSelector.GetTalentAsSpecialRule("No Hesitation"),
                TalentSelector.GetTalentAsSpecialRule("Warrior's Spirit"),
            },
            Source = BookSource.NextGenerationCrewPack1stEdition,
        },
        new()
        {
            Name = "Lieutenant Tassha Yar",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "“I never did get a chance to meet Lieutenant Yar. Her brief tenure as chief of security was over quickly and tragically before I had a chance to visit the Enterprise. I’m told she was an incredibly capable officer who may well have gone far if her life had not been cut short. Recent reports from Captain Picard of his most recent encounter with Q, and his return to those early days before Farpoint Station, and the possibility that an alternate Yar may be the mother of one of the Romulan’s most devious and dangerous officers in recent history, Sela, is indeed worrying… but both have brought Lieutenant Yar back to my memory.”",
            },
            Traits = new List<string>
            {
                "Human",
                "Starfleet Officer"
            },
            Values = new List<string>
            {
                "Duty unto death",
                "Everyone has a right to freedom",
                "My crew is my family",
                "Vigorous training regime",
            },
            Focuses = new List<string>
            {
                "Aikido", Focus.CombatTactics, Focus.HandPhasers, Focus.ShipboardTacticalSystems, Focus.SmallCraft, Focus.Survival 
            },
            PersonalThreat = 8,
            Protection = 1,
            Attributes = new CharacterAttributes { Control = 9, Daring = 10, Fitness = 10, Insight = 9, Presence = 9, Reason = 9 },
            Departments = new Departments { Command = 4, Conn = 3, Engineering = 2, Security = 5, Medicine = 1, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Bold (Security)"),
                TalentSelector.GetTalentAsSpecialRule("Call out Targets"),
                new()
                {
                    Name = "Chief of Security",
                    Description = new List<string>
                    {
                        "You reduce the opportunity cost of weapons and security teams by 1, to a minimum of 0. Further, when you succeed at an Attack against an enemy during personal combat, you may spend 1 Momentum to increase the Difficulty of that enemy’s next Attack by 1."
                    },
                    Source = BookSource.Core,
                },
                TalentSelector.GetTalentAsSpecialRule("Extra Effort"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Quick Survey"),
            },
            Source = BookSource.NextGenerationCrewPack1stEdition,
        },
    };

    private static IEnumerable<NonPlayerCharacter> GetPicardSeasonOneCrew() => new List<NonPlayerCharacter>
    {
        new()
        {
            Name = "Admiral Jean-Luc Picard (Retired)",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Once a celebrated Starfleet captain, a hero to millions, Jean-Luc Picard’s heralded career ended abruptly after the synth attack on Mars. Resigning from a Starfleet he no longer recognized, he retreated to his family vineyard and took over the family business. Isolated and brooding, visited by troubling dreams of his deceased friend Data, he remained hidden away in France for a decade and a half. That should have been the end of the story. Then he encountered Dahj Asha, a young woman with a mysterious and compelling connection to his old friend."
            },
            Traits = new List<string>
            {
                "Human",
                "Liberated Borg",
                "Retired Starfleet Flag Officer",
                "Artificial Heart",
                "Former Captain of the Enterprise"
            },
            Values = new List<string>
            {
                "I didn’t abandon Starfleet; Starfleet abandoned me",
                "I have a mission now",
                "I may never pass this way again",
                "I’m still mourning Data"
            },
            Focuses = new List<string>
            {
                Focus.Diplomacy, Focus.History, Focus.Leadership, "Romulan Customs", Focus.StarfleetProtocol, "Winemaking"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 8, Fitness = 7, Insight = 11, Presence = 10, Reason = 10 },
            Departments = new Departments { Command = 5, Conn = 2, Engineering = 1, Security = 2, Medicine = 2, Science = 4 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Advisor"),
                TalentSelector.GetTalentAsSpecialRule("Cautious (Command)"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Reassuring"),
                TalentSelector.GetTalentAsSpecialRule("Veteran"),
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition,
        },
        new()
        {
            Name = "Cristóbal “Cris” Rios",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Rios, former XO of U.S.S. ibn Majid, should never have been a factor in this affair. After learning about his deceased captain’s complicity in the assassination of two of Maddox’s androids and his subsequent actions to cover up the Starfleet-sanctioned crime – orders given by me when I served as the Director of Starfleet Security – he should have been too disillusioned with Starfleet to come back on the scene. His lack of trust in Starfleet had forced him to become a hero-for-hire, as it were. But Picard has a way with words and enlisted Rios to join his vigilante band."
            },
            Traits = new List<string>
            {
                "Human",
                "Former Starfleet Officer",
                "Independent Transport Captain"
            },
            Values = new List<string>
            {
                "Cash gift is always appropriate",
                "Don’t try to get inside my head",
                "Never again allow a Starfleet captain into my heart",
                "Starfleet to the core"
            },
            Focuses = new List<string>
            {
                Focus.Astronavigation, Focus.CriminalOrganizations, Focus.HelmOperations, "Kaplan F17 Speed Freighter Specialist", Focus.Philosophy, Focus.StarfleetProtocol
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 10, Fitness = 9, Insight = 9, Presence = 9, Reason = 9 },
            Departments = new Departments { Command = 4, Conn = 4, Engineering = 3, Security = 3, Medicine = 1, Science = 1 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
                WeaponSelector.GetWeapon(WeaponName.PhaserType3),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType3, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Fly-By"),
                new()
                {
                    Name = "La Sirena",
                    Description = new List<string>
                    {
                        "A Kaplan F17 Speed Freighter operated by Cris Rios, La Sirena is outfitted with a holodeck, a suite of emergency holograms (patterned on Rios himself, but with different personalities and accents), holographic controls, and a small personal arsenal."
                    },
                    Source = BookSource.PicardSeasonOneCrewPack1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Precise Evasion"),
                new()
                {
                    Name = "Show-Off",
                    Description = new List<string>
                    {
                        "When you attempt a task roll, you may choose to increase the Difficulty by 1. If you succeed, you gain 2 bonus Momentum. Bonus Momentum cannot be saved."
                    },
                    Source = BookSource.PicardSeasonOneCrewPack1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Well Informed"),
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition,
        },
        new()
        {
            Name = "Raffaela “Raffi” Musiker",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Once Jean-Luc Picard’s executive officer and close friend, Raffi Musiker became one of the victims of his resignation from Starfleet. Her close association with Picard, as well as her vocal assertions regarding Tal Shiar involvement in the Mars attacks, led to her almost immediate dismissal from Starfleet. Her relationships with her husband and son, already strained by the lengthy evacuation efforts, deteriorated, and she fell into a lonely cycle of addiction and humiliation. While not terribly keen on joining Picard on his fool’s errand, she must have seen in it a way to start rebuilding her life."
            },
            Traits = new List<string>
            {
                "Human",
                "Disgraced Starfleet Officer",
                "Addict"
            },
            Values = new List<string>
            {
                "I’m a survivor",
                "Nothing left to lose",
                "One impossible thing at a time",
                "Trying to undo the damage I’ve done"
            },
            Focuses = new List<string>
            {
                "Conspiracy Theories", Focus.Logistics, "Pattern Recognition", "Romulan Affairs", "Security Procedures", Focus.StarfleetProtocol
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 9, Fitness = 8, Insight = 11, Presence = 8, Reason = 11 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 5, Medicine = 1, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
                WeaponSelector.GetWeapon(WeaponName.PhaserType3),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType3, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Gut Feeling"),
                TalentSelector.GetTalentAsSpecialRule("Lead Investigator"),
                TalentSelector.GetTalentAsSpecialRule("Technical Expertise"),
                TalentSelector.GetTalentAsSpecialRule("Well Informed"),
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition,
        },
        new()
        {
            Name = "Dr. Agnes Jurati",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Dr. Jurati worked in the Division of Advanced Synthetic Research at the Daystrom Institute in Okinawa. She was lured into play by Picard with the possibility that Data had offspring. Yes, I manipulated her into murdering her mentor and lover Bruce Maddox. That should have crushed her. Instead, she accepted responsibility for her actions and quickly lent her genius to Picard’s troupe. In retrospect, I should have erased her from the equation."
            },
            Traits = new List<string>
            {
                "Human",
                "Prominent Cyberneticist",
                "Fellow of the Daystrom Institute"
            },
            Values = new List<string>
            {
                "I Can Sense Mistakes While I Am Making Them",
                "I’m the Earth’s Leading Expert on Synthetic Life",
                "Never Kill Again",
                "One Impossible Thing at a Time",
            },
            Focuses = new List<string>
            {
                Focus.Biology, "Biomechanics", "Neurology", "Research & Development", "Synthetic Life", "Theoretical Cybernetics"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 8, Fitness = 7, Insight = 11, Presence = 8, Reason = 12 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 5, Security = 2, Medicine = 4, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Applied Research"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Quick Study"),
                TalentSelector.GetTalentAsSpecialRule("Testing a Theory"),
                TalentSelector.GetTalentAsSpecialRule("Unconventional Thinking"),
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition,
        },
        new()
        {
            Name = "Dr. Soji Asha",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Soji is a synthetic being created from a single positronic neuron acquired from the terminated android Data. She is the closest thing to a granddaughter that Picard will ever have. During the ban on synthetics, Soji was assigned as an anthropologist to the Borg Reclamation Project on the Romulan-controlled Artifact. We had been tracking her for years as part of our goal to exterminate all synthetic life in the universe. If not for Picard’s manipulations and interference, our operatives would have succeeded in destroying Soji and her synthetic kin."
            },
            Traits = new List<string>
            {
                "Coppelius Android",
                "Human",
                "Anthropologist",
                "Data’s Daughter"
            },
            Values = new List<string>
            {
                "I’m a trusting person by default",
                "I have a story waiting to be claimed",
                "More cut out for wandering",
                "Synthetics have rights too",
            },
            Focuses = new List<string>
            {
                "Androids", Focus.Anthropology, "Artificial Intelligence", "Borg Technology", Focus.Linguistics, "Romulan Culture"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 9, Fitness = 11, Insight = 8, Presence = 8, Reason = 10 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 4, Security = 4, Medicine = 2, Science =4 },
            Attacks = new List<Weapon>
            {
                new()
                {
                    Name = WeaponName.UnarmedStrike,
                    Type = WeaponType.Melee,
                    Injury = InjuryType.Stun,
                    Severity = 3,
                    Size = WeaponSize.OneHanded,
                    Qualities = new List<WeaponQuality>(),
                    Costs = new List<string>()
                },
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Applied Force"),
                TalentSelector.GetTalentAsSpecialRule("Biosynthetic Construction"),
                TalentSelector.GetTalentAsSpecialRule("Computer Expertise"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.SyntheticLifeForm),
                TalentSelector.GetTalentAsSpecialRule("Walking Encyclopedia"),
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition,
        },
        new()
        {
            Name = "Seven, Fenris Ranger",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Annika “Seven-of-Nine” Hansen is a legend in her own right. Liberated from the Borg by U.S.S. Voyager’s Captain Janeway. Returned from the Delta Quadrant in 2378. Disillusioned with the Federation. Seven eventually joined the Fenris Rangers, a vigilante organization helping individuals along the fractured Federation/Romulan Neutral Zone. She joined Picard’s mission to exact revenge on the criminal Bjayzl for the murder of Icheb, a Starfleet officer who was like a son to her. She was a completely unexpected factor in this entire affair that completely disrupted our best-laid plans."
            },
            Traits = new List<string>
            {
                "Human",
                "Liberated Borg",
                "Fenris Ranger"
            },
            Values = new List<string>
            {
                "Help people who have no one else to help them",
                "Never kill someone just because it’s what they deserve",
                "Working on regaining my humanity",
                "XBs fall under my protection"
            },
            Focuses = new List<string>
            {
                Focus.Astrometrics, Focus.Astrophysics, "Borg Collective", Focus.HandPhasers, "Search and Rescue Operations", Focus.SubspaceTheory
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 10, Fitness = 10, Insight = 8, Presence = 8, Reason = 11 },
            Departments = new Departments { Command = 2, Conn = 2, Engineering = 4, Security = 2, Medicine = 2, Science = 4 },
            Attacks = new List<Weapon>
            {
                new()
                {
                    Name = WeaponName.UnarmedStrike,
                    Type = WeaponType.Melee,
                    Injury = InjuryType.StunOrDeadly,
                    Severity = 2,
                    Size = WeaponSize.OneHanded,
                    Qualities = new List<WeaponQuality>(),
                    Costs = new List<string>()
                },
                new()
                {
                    Name = "Assimilation Tubules",
                    Type = WeaponType.Melee,
                    Injury = InjuryType.Deadly,
                    Severity = 3,
                    Size = WeaponSize.OneHanded,
                    Qualities = new List<WeaponQuality>
                    {
                        WeaponSelector.GetWeaponQuality(WeaponQualityName.Debilitating),
                        WeaponSelector.GetWeaponQuality(WeaponQualityName.Intense),
                    },
                    Costs = new List<string>()
                },
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
                WeaponSelector.GetWeapon(WeaponName.PhaserType3),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.PhaserType3, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.BorgImplants),
                new()
                {
                    Name = "Borg Implant - Assimilation Tubules",
                    Description = new List<string>
                    {
                        "You have the assimilation tubules weapon, implanted within your arm. This grants the melee weapon listed above. Enemies defeated by assimilation tubules may become assimilated and become Borg Drones. As you have an Interlink Node, you may also use this weapon to directly interface with a computer, as per the Neural Interface talent."
                    },
                    Source = BookSource.PicardSeasonOneCrewPack1stEdition,
                },
                new()
                {
                    Name = "Borg Implant - Cortical Node",
                    Description = new List<string>
                    {
                        "You may suffer 2 Stress to avoid suffering any trait that represents an emotional state, and you have +1 Protection against Stun attacks. However, if you become Fatigued, choose two attributes to shutdown instead of one."
                    },
                    Source = BookSource.PicardSeasonOneCrewPack1stEdition,
                },
                new()
                {
                    Name = "Borg Implant - Interlink Node",
                    Description = new List<string>
                    {
                        "Even disconnected from the Collective, you can still glean insights from other Borg drones nearby. When Borg are present in a scene, you may add 1 Threat to ask a question as per Obtain Information, attempting to gain some knowledge from Borg communications."
                    },
                    Source = BookSource.PicardSeasonOneCrewPack1stEdition,
                },
                new()
                {
                    Name = "Collective Insights",
                    Description = new List<string>
                    {
                        "Once per session, when you attempt a task, you may suffer 1 Stress to gain one additional Focus of your choice for the remainder of the current session. The Focus should reflect some knowledge that the Borg Collective would have assimilated and thus should not be any subject which the Borg would deem irrelevant."
                    },
                    Source = BookSource.PicardSeasonOneCrewPack1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Martial Artist"),
                TalentSelector.GetTalentAsSpecialRule("Mental Repository"),
                TalentSelector.GetTalentAsSpecialRule("Technical Expertise"),
                TalentSelector.GetTalentAsSpecialRule("Well Informed"),
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition,
        },
        new()
        {
            Name = "Elnor",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Orphaned during the Romulan evacuation, Elnor found himself in the care of the Qowat Milat on the planet Vashti. He became very fond of then-Admiral Picard, who visited the planet frequently until the attacks on Mars. After that, Picard didn’t go back at all, leaving Elnor alone without a father figure. As the evacuation effort fell apart, the Qowat Milat were unable to find a better home for the boy, so they raised and trained him as one of their own. When Picard finally returned 15 years later, Elnor had become a formidable warrior. He was an enormous aid to Picard’s mission but may prove an even better asset to the remnants of the Empire."
            },
            Traits = new List<string>
            {
                "Romulan",
                "Raised by the Qowat Milat"
            },
            Values = new List<string>
            {
                "I have bound my sword to your lost cause",
                "Now is the only moment",
                "Please, my friend: choose to live",
                "The galaxy is a far stranger place than I imagined"
            },
            Focuses = new List<string>
            {
                "Acrobatics", Focus.BladeWeapons, Focus.HandToHandCombat, Focus.Negotiation, "Qowat Milat Teachings", "Vigilance"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 10, Fitness = 11, Insight = 8, Presence = 9, Reason = 8 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 4, Medicine = 3, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                new()
                {
                    Name = "Tan qalanq (blade)",
                    Type = WeaponType.Melee,
                    Injury = InjuryType.Deadly,
                    Severity = 3,
                    Size = WeaponSize.OneHanded,
                    Qualities = new List<WeaponQuality>(),
                    Costs = new List<string>()
                },
                WeaponSelector.GetWeapon(WeaponName.PhaserType2),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Close Protection"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.Paranoia),
                new()
                {
                    Name = "Qalankhkai",
                    Description = new List<string>
                    {
                        "When you make a melee attack, or are targeted by a melee attack, and you buy one or more d20s by adding Threat, you may re-roll the dice pool for your task roll."
                    },
                    Source = BookSource.PicardSeasonOneCrewPack1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Untapped Potential"),
                new()
                {
                    Name = "Untapped Potential (Control)",
                    Description = new List<string>
                    {
                        "You’re inexperienced, but talented and with a bright future. You may not have or increase any attribute to above 11, or any department to above 4 while you have this talent. Whenever you succeed at a task for which you bought one or more additional dice (by any means), roll a d20 after the roll. If you roll equal to or less than your Control, gain 1 bonus Momentum; if you roll higher, add 1 Threat instead. While you possess this talent, you cannot gain any higher rank than Lieutenant (junior grade), or a higher enlisted rate than Petty Officer."
                    },
                    Source = BookSource.Core,
                },
                TalentSelector.GetTalentAsSpecialRule("Wary"),
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition,
        },
        new()
        {
            Name = "Narek",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "An unorthodox agent, Narek comes from a family of Tal Shiar operatives. He’s considered something of a family failure because he left the Zhat Vash faction, to which his sister Narissa still belongs, although he appears to continue serving their interests. Narek is subtle even for the Tal Shiar, preferring to take his time with his target; seduction, rather than coercion, is his tool of choice, which does not always sit well with his superiors. In his pursuit of Dr. Soji Asha, his sister made no secret of her distaste with his techniques, but Narek was convinced that subtlety was the only way to succeed."
            },
            Traits = new List<string>
            {
                "Romulan",
                "Tal Shiar Operative",
                "Disgraced Member of the Zhat Vash"
            },
            Values = new List<string>
            {
                "I won’t let my sister down",
                "I’m sexy and I know it",
                "My back-up plans have back-up plans",
                "Violence isn’t my first option, but it is an option"
            },
            Focuses = new List<string>
            {
                Focus.Espionage, Focus.HandToHandCombat, Focus.Infiltration, Focus.Psychology, "Seduction", "Surveillance"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 10, Fitness = 9, Insight = 9, Presence = 10, Reason = 8 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 4, Medicine = 3, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.Dagger),
                WeaponSelector.GetWeapon(WeaponName.DisruptorPistol),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Back-up Plans"),
                TalentSelector.GetTalentAsSpecialRule("Constantly Watching"),
                TalentSelector.GetTalentAsSpecialRule("Defensive Training (Melee)"),
                TalentSelector.GetTalentAsSpecialRule("Guile and Cunning"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.Paranoia),
            },
            Source = BookSource.PicardSeasonOneCrewPack1stEdition,
        },
    };

    private static IEnumerable<NonPlayerCharacter> GetStarfleetNpcs() => new List<NonPlayerCharacter>
    {
        new()
        {
            Name = "Astrocartographer",
            TypeEnum = NPCType.Minor,
            Description = new List<string>
            {
                "An astrocartographer specializes in the mapping and cataloguing of stars and planets, and any data about those bodies into star charts used by all spacefaring civilizations. An astrocartographer is present on all Starfleet vessels and is integral to maintaining properly updated navigational charts and keeping the onboard science database up to date on all current observations. Astrocartographers in charge of their department are typically lieutenants in rank, and may serve as the single crewmember in their department on smaller ships. On larger vessels there may be multiple astrocartographers of ensign rank and enlisted."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Starfleet Officer"
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 7, Daring = 8, Fitness = 7, Insight = 8, Presence = 8, Reason = 9 },
            Departments = new Departments { Command = 1, Conn = 2, Engineering = 1, Security = 1, Medicine = 1, Science = 2 },
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
                    Name = "Sector Specialist",
                    Description = new List<string>
                    {
                        "The gamemaster may choose to make an Astrocartographer an expert in a specific sector of space. All tasks involving the mapping of that sector, location of bodies, navigation hazards, etc., have their Difficulty reduced by 1. However, this reliance on their own expertise can often trip them up when they encounter something unexpected or outside of their knowledge, increasing their complication range by 1."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Visit Every Star")
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
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
            Name = "Counselor",
            TypeEnum = NPCType.Minor,
            Description = new List<string>
            {
                "Where physicians seek to heal the body, counselors seek to heal the mind and spirit. On board a Starfleet vessel, counselors are typically referred to as ‘doctor,’ ‘counselor,’ or more rarely by their rank."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Starfleet Officer",
                "Counselor"
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 7, Fitness = 8, Insight = 9, Presence = 8, Reason = 8 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 1, Security = 1, Medicine = 3, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Cold Reading"),
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
            },
            Source = BookSource.ScienceDivision1stEdition,
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
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
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
            Name = "Physician",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "Physicians are trained medical personnel that have gone to medical school and have graduated with a doctorate (or its equivalent) in medicine. With the sheer number of lifeforms in the Federation, there is always a need for physicians that are skilled in a particular specialty or species. On a Starfleet vessel, these crewmembers typically are referred to as ‘doctor’ rather than their rank, but may not be the chief medical officer on board.",
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Starfleet Officer",
                "Physician"
            },
            RandomSpecies = true,
            Values = new List<string>
            {
                "First, do no harm",
            },
            Focuses = new List<string>
            {
                Focus.EmergencyMedicine, Focus.Virology
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 9, Fitness = 8, Insight = 8, Presence = 8, Reason = 9 },
            Departments = new Departments { Command = 2, Conn = 1, Engineering = 1, Security = 1, Medicine = 3, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.AnestheticHypospray),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Field Medicine"),
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                new()
                {
                    Name = "Interspecies Medical Exchange",
                    Description = new List<string>
                    {
                        "The Physician may reroll a single d20 on any task using Insight to diagnose a member of a species known to the Federation."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
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
            Name = "Science Officer",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "During the 23rd century, it was common for a single officer to be given the title of science officer. This officer was in charge of the starship’s science teams, but also acted as the primary sensor operator and data analyst on the bridge. As starships became larger and more complex in the late 23rd and early 24th centuries, this position became rare as more bridge stations allowed for a more diverse collection of specialists to operate sensor platforms and analyze data. A science officer’s rank is typically no less than a lieutenant commander, and often a commander given the amount of responsibility they have over the numerous personnel in the science departments.",
            },
            Traits = new List<string>
            {
                "Vulcan",
                "Starfleet Officer"
            },
            RandomSpecies = true,
            Values = new List<string>
            {
                "Fascinating…",
            },
            Focuses = new List<string>
            {
                Focus.SensorOperations, "Science Communication"
            },
            PersonalThreat = 4,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 7, Insight = 10, Presence = 9, Reason = 11 },
            Departments = new Departments { Command = 2, Conn = 1, Engineering = 2, Security = 1, Medicine = 2, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Collaboration (Science)"),
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.MentalDiscipline),
                new()
                {
                    Name = "Scientific Specialty",
                    Description = new List<string>
                    {
                        "Choose a scientific focus."
                    },
                    HideIfGenerating = true,
                    AddRandomFocus = new List<string>
                    {
                        Focus.AlternativeMedicine, Focus.Anesthesiology, Focus.Biotechnology, Focus.Councelling, Focus.Dentistry,
                        Focus.EmergencyMedicine, Focus.Ethics, Focus.FieldMedicine, Focus.FirstAid, Focus.Genetics, Focus.GuidedTherapy,
                        Focus.ImagingSystems, Focus.Immunology, Focus.InfectiousDiseases, Focus.InternalMedicine, Focus.Kinesiology,
                        Focus.MedicalToxicology, Focus.Microbiology, Focus.NeuropsychologyOrPsychiatry, Focus.Parapsychology,
                        Focus.PatientCare, Focus.Pediatrics, Focus.Pharmacology, Focus.Psychiatry, Focus.Psychoanalysis,
                        Focus.PsychosomaticDisorders, Focus.Rheumatology, Focus.StressDisorders, Focus.Surgery, Focus.Triage,
                        Focus.VeterinaryMedicine, Focus.Virology
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
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
                Focus.Espionage, "Intelligence Analysis", "Undercover Operations"
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
            Name = "Starfleet Research Scientist",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "Starfleet R&D has kept the Federation on the cutting edge of technological innovation for centuries. Those that work inside the hangar bays, engineering shops, and research facilities operated by R&D are some of the most forward-thinking and creative people in the Federation. From the outside, they may appear stereotypically bookish or socially awkward, but this is because they think and communicate on a level most don’t understand about their passion, the cutting edge of science. Amongst their own, many of these researchers are like test-pilots of 20th century Earth, pushing the envelope of technology or finding new ways to observe and record dangerous phenomena."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Research Scientist"
            },
            RandomSpecies = true,
            Values = new List<string>
            {
                "On the cutting edge of progress",
            },
            Focuses = new List<string>
            {
                "Federation Technology", "Prototyping", Focus.Research
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 10, Fitness = 8, Insight = 8, Presence = 8, Reason = 9 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 2, Security = 1, Medicine = 1, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Bench Thumping the Black Box",
                    Description = new List<string>
                    {
                        "The Research Scientist may bring along experimental technology, far in advance of anything in widespread service. This equipment trait increases its Potency by +1, but any task performed with the device has its complication range increased by +4."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.IntensiveTraining),
                TalentSelector.GetTalentAsSpecialRule("Jury-Rig"),
                new()
                {
                    Name = "Scientific Method",
                    Description = new List<string>
                    {
                        "After a successful Science task, a Research Scientist may spend 1 Momentum or 1 Threat to create a trait which represents a working hypothesis about the situation. When that trait benefits a task they attempt, they may reroll 1d20."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
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
            Name = "Xenobiology Department Head",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "On a starship, the xenobiology department head is responsible for teams of specialists ranging from microbiologists and molecular biologists to ecologists and biochemists. This person must not only be highly trained in biology, but must also be able to manage large amounts of data about vastly different biochemistries along with ensuring the best person for each new world is assigned where they may best add to the department’s efforts. When a new world filled with strange new life is discovered, the xenobiology department head is often seen as the most important and busiest officer onboard an exploratory vessel.",
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Starfleet Officer",
                "Xenobiologist"
            },
            RandomSpecies = true,
            Values = new List<string>
            {
                "Seek out new life",
            },
            Focuses = new List<string>
            {
                Focus.Biochemistry, Focus.Microbiology, Focus.Xenobiology
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 7, Fitness = 8, Insight = 10, Presence = 8, Reason = 9 },
            Departments = new Departments { Command = 2, Conn = 1, Engineering = 1, Security = 1, Medicine = 3, Science = 3 },
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
                    Name = "On the Final Frotnier",
                    Description = new List<string>
                    {
                        "Some xenobiology department heads haven’t been assigned many deep space missions where they have been able to practice their trade extensively, and instead have become more adept at command tasks and management of their department’s personnel and resources. At the Gamemaster’s discretion the Xenobiology Department Head has had this sort of background and increases their Command Discipline to 03 and decreases their Medicine Discipline to 02."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
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
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
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
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
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
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
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

    private static IEnumerable<NonPlayerCharacter> GetFederationNpcs() => new List<NonPlayerCharacter>
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
            Name = "Explorer (Academic)",
            TypeEnum = NPCType.Minor,
            Description = new List<string>
            {
                "Starfleet doesn’t hold a monopoly on those that wish to explore the Galaxy. There are many civilians who have dedicated their lives to being like naturalists of old such as Darwin and Dioscorides. Instead of researching and analyzing, explorers tend to go out into the universe and turn over rocks to gain a better understanding of the world. While these people tend to not be as respected as those that have spent their lives studying and experimenting, many of their observations and discoveries can go on to influence researchers and academia."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Independent Explorer",
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 7, Insight = 9, Presence = 7, Reason = 8 },
            Departments = new Departments { Command = 0, Conn = 2, Engineering = 3, Security = 0, Medicine = 1, Science = 3 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                WeaponSelector.GetWeapon(WeaponName.ParticleRifle),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.ParticleRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Academic Explorer",
                    Description = new List<string>
                    {
                        "The Explorer has a focus of Stellar Cartography, Planetary Geography, or Geomorphology.",
                    },
                    HideIfGenerating = true,
                    AddRandomFocus = new List<string> { "Geomorphology", "Planetary Geography", Focus.StellarCartography },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Explorer (Exploring Life)",
            TypeEnum = NPCType.Minor,
            Description = new List<string>
            {
                "Starfleet doesn’t hold a monopoly on those that wish to explore the Galaxy. There are many civilians who have dedicated their lives to being like naturalists of old such as Darwin and Dioscorides. Instead of researching and analyzing, explorers tend to go out into the universe and turn over rocks to gain a better understanding of the world. While these people tend to not be as respected as those that have spent their lives studying and experimenting, many of their observations and discoveries can go on to influence researchers and academia."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Independent Explorer",
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 7, Insight = 9, Presence = 7, Reason = 8 },
            Departments = new Departments { Command = 0, Conn = 2, Engineering = 1, Security = 0, Medicine = 3, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                WeaponSelector.GetWeapon(WeaponName.ParticleRifle),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.ParticleRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Explorering Life",
                    Description = new List<string>
                    {
                        "The Explorer has a focus of Xenobiology.",
                    },
                    HideIfGenerating = true,
                    AddRandomFocus = new List<string> { Focus.Xenobiology },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Explorer (Trailblazer)",
            TypeEnum = NPCType.Minor,
            Description = new List<string>
            {
                "Starfleet doesn’t hold a monopoly on those that wish to explore the Galaxy. There are many civilians who have dedicated their lives to being like naturalists of old such as Darwin and Dioscorides. Instead of researching and analyzing, explorers tend to go out into the universe and turn over rocks to gain a better understanding of the world. While these people tend to not be as respected as those that have spent their lives studying and experimenting, many of their observations and discoveries can go on to influence researchers and academia."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Independent Explorer",
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 7, Insight = 9, Presence = 7, Reason = 8 },
            Departments = new Departments { Command = 0, Conn = 3, Engineering = 1, Security = 1, Medicine = 1, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                WeaponSelector.GetWeapon(WeaponName.PhaserType1),
                WeaponSelector.GetWeapon(WeaponName.ParticleRifle),
            },
            EscalationAttacks = new List<(string, int)> { (WeaponName.ParticleRifle, 1) },
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Explorering Life",
                    Description = new List<string>
                    {
                        "The Explorer has a focus of Astronavigation.",
                    },
                    HideIfGenerating = true,
                    AddRandomFocus = new List<string> { Focus.Astronavigation },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
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
            Name = "Professor (Hard Science)",
            TypeEnum = NPCType.Minor,
            Description = new List<string>
            {
                "A professor is a catch-all term for a professional scientist or researcher that has completed what would be equivalent to the doctorate program in their field and has many years of experience. A professor can be found teaching at universities across the Federation, leading a team of researchers or even a whole research lab, or as an officer with a rank of lieutenant or lieutenant junior grade in the sciences division."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Professor",
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 7, Fitness = 7, Insight = 9, Presence = 8, Reason = 10 },
            Departments = new Departments { Command = 2, Conn = 0, Engineering = 1, Security = 0, Medicine = 1, Science = 3 },
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
                    Name = "Hard Science",
                    Description = new List<string>
                    {
                        "The professor gains a focus based on a single scientific field of study, e.g., Astrophysics, Subspace Theory, Quantum Mechanics",
                    },
                    HideIfGenerating = true,
                    AddRandomFocus = new List<string> { Focus.Astrophysics, Focus.SubspaceTheory, Focus.QuantumMechanics },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Professor (Research Lead)",
            TypeEnum = NPCType.Minor,
            Description = new List<string>
            {
                "A professor is a catch-all term for a professional scientist or researcher that has completed what would be equivalent to the doctorate program in their field and has many years of experience. A professor can be found teaching at universities across the Federation, leading a team of researchers or even a whole research lab, or as an officer with a rank of lieutenant or lieutenant junior grade in the sciences division."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Professor",
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 7, Fitness = 7, Insight = 9, Presence = 8, Reason = 9 },
            Departments = new Departments { Command = 3, Conn = 0, Engineering = 1, Security = 0, Medicine = 1, Science = 3 },
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
                    Name = "Research Lead",
                    Description = new List<string>
                    {
                        "The professor has a broad background in the sciences and has honed their people skills to lead other researchers in their projects. They gain a focus of Team Dynamics.",
                    },
                    HideIfGenerating = true,
                    AddRandomFocus = new List<string> { Focus.TeamDynamics },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Professor (Social Scientist)",
            TypeEnum = NPCType.Minor,
            Description = new List<string>
            {
                "A professor is a catch-all term for a professional scientist or researcher that has completed what would be equivalent to the doctorate program in their field and has many years of experience. A professor can be found teaching at universities across the Federation, leading a team of researchers or even a whole research lab, or as an officer with a rank of lieutenant or lieutenant junior grade in the sciences division."
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Professor",
            },
            RandomSpecies = true,
            PersonalThreat = 0,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 7, Fitness = 7, Insight = 9, Presence = 8, Reason = 9 },
            Departments = new Departments { Command = 2, Conn = 0, Engineering = 1, Security = 0, Medicine = 1, Science = 3 },
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
                    Name = "Social Scientist",
                    Description = new List<string>
                    {
                        "A social scientist is trained in how intelligent beings interact with the world around them in fields such as Anthropology, Geography, and Linguistics, and may often specialize in a single world or culture. They gain a focus such as Andorian History, or Tellarite Jurisprudence, or Xenolinguistics.",
                    },
                    HideIfGenerating = true,
                    AddRandomFocus = new List<string> { "Andorian History", Focus.Anthropology, Focus.Geography, Focus.Linguistics, "Tellarite Jurisprudence", "Xenolinguistics"},
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
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
            Name = "Terraformer",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "Terraforming specialists are a broad class of academics doing research into furthering the field of terraforming technologies, scientists researching and studying possible worlds for terraforming, as well as the hard-working engineers of Starfleet’s Corps of Engineers Terraforming Division. These people are found on worlds across the Federation and beyond, expanding the number of worlds able to be settled and assisting newly admitted worlds to the Federation in fixing any environmental damage they may have. Regardless of what part of the terraforming field they may be in, these scientists and engineers typically have a good understanding of physics, climatology, and spacebased engineering. Terraforming specialists can also be found on starbases as they move between new planets or projects, and many larger exploration starships have at least one of these personnel aboard, cataloguing new worlds that could host a colony with some atmospheric adjustments. While terraforming technically refers to making a world more Earth-like, in the Federation the term has come to mean making a world more Class-M-like, and terraformers can be of any species.",
            },
            Traits = new List<string>
            {
                "Species (add 3 points to attributes based on species)",
                "Terraforming Engineer"
            },
            RandomSpecies = true,
            Values = new List<string>
            {
                "Making the Galaxy a better place one world at a time",
            },
            Focuses = new List<string>
            {
                "Geoengineering", "Macro-Engineering", "Terraforming Technology"
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 7, Daring = 9, Fitness = 7, Insight = 10, Presence = 8, Reason = 10 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 3, Security = 0, Medicine = 2, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "The World is my Oyster",
                    Description = new List<string>
                    {
                        "Due to their dedication and a terraformer’s deep insight into the worlds they are reengineering, they can ignore the first complication generated on a task related to their terraforming project."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Vulcan Science Academy Professor Emeritus",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "For centuries the Vulcan Science Academy has been known as one of the Federation’s best learning institutions, with the strictest standards for admission and no tolerance for anything less than perfection. The demand for perfection and intellectual rigor for its professors is even stronger, and only the best minds on Vulcan can ever claim to have taught at the Academy. These positions, however, are temporary, as the Academy refuses to allow its teaching staff to become stagnant or to lose their curiosity of the universe around them; after a time these professors leave to continue their teaching or research elsewhere. A VSA professor emeritus, one who used to teach at the Academy, is highly sought after in other institutions of higher learning, and many go on to find teaching positions at Starfleet Academy and the Daystrom Institute.",
            },
            Traits = new List<string>
            {
                "Vulcan",
                "Professor Emeritus of the Vulcan Science Academy",
                "Respected Expert"
            },
            Values = new List<string>
            {
                "Logic is the beginning, not the end, of wisdom",
            },
            Focuses = new List<string>
            {
                Focus.Teaching, Focus.Physics, Focus.QuantumTheory, Focus.SubspaceTheory
            },
            PersonalThreat = 5,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 10, Daring = 7, Fitness = 9, Insight = 8, Presence = 9, Reason = 11 },
            Departments = new Departments { Command = 3, Conn = 1, Engineering = 2, Security = 0, Medicine = 1, Science = 4 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Kohlinar"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.MentalDiscipline),
                TalentSelector.GetTalentAsSpecialRule("Teacher"),
                new()
                {
                    Name = "Using Reason as our Guide",
                    Description = new List<string>
                    {
                        "A VSA professor emeritus is highly skilled in logic and reason, and during their time teaching and researching at the Vulcan Science Academy, they have become used to determining the validity of ideas based on rationalizing all available data. At the gamemaster’s discretion, once per mission the VSA professor emeritus may use their Reason attribute in place of any other on a task."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
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
            Name = "Dr. Carol Marcus",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Much of Carol Marcus’ worldview was formed by being a ‘Starfleet Brat’, travelling from post to post with her father Admiral Alexander Marcus as she grew up. Seeing alien beings and the almost infinite variety of life on the worlds she visited let her gain a deep interest in knowing about them. After graduating with a doctorate in molecular biology and a M.S. in xenobiology, Doctor Marcus quickly rose to become the preeminent researcher in her field. A string of groundbreaking research papers brought her to the attention of the Daystrom Institute, where she became a permanent fellow. By the early 2270s Doctor Marcus was the lead researcher of Project Genesis, a multi-disciplinary research and development project directly monitored by the Federation Science Council and in cooperation with the Starfleet Corps of Engineers. Although it began as a way to research whether it was possible to artificially create designed lifeforms for biochemical production, or to make new disease-resistant crops, the project became the single most debated scientific discovery and technological breakthrough of the 23rd century, the Genesis Device. The device was capable of scanning an environment, determining what resources weren’t present, and then, using an anti-matter powered detonation, it began to reconstruct matter at the atomic level to produce a Class-M environment fully stocked with plant life. After its initial accidental use in the Mutara Nebula made many question her ethics in making something that could so easily be used as a weapon, and after the death of her son on the Genesis Planet, Doctor Marcus withdrew from public life and resigned from her position at the Daystrom Institute. Even after her withdrawal, Carol Marcus’ papers on molecular biology and artificial creation of biological matter would help researchers develop replicated foodstuffs and assist in new ways to produce large quantities of algae for terraforming new worlds.",
            },
            Traits = new List<string>
            {
                "Human",
                "Legendary Scientist",
                "Creator of Project Genesis",
                "True Believer"
            },
            Values = new List<string>
            {
                "Can I cook, or can’t I?",
                "Life from lifelessness",
                "Feeling young as when the world was new",
            },
            Focuses = new List<string>
            {
                "Geoengineering", "Molecular Biology", Focus.QuantumPyhsics, Focus.Xenobiology,
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 7, Daring = 7, Fitness = 9, Insight = 11, Presence = 10, Reason = 12 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 3, Security = 1, Medicine = 5, Science = 5 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Doctor's Orders"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                new()
                {
                    Name = "Starfleet Brat",
                    Description = new List<string>
                    {
                        "Carol Marcus grew up with Starfleet in her blood and she knows the structure of Starfleet better than most civilians (and knows many who currently serve in it). Succeeding at a task involving Starfleet operations or organizational structure, Carol Marcus gains one bonus Momentum that can only be spent to Obtain Information. This stacks with the Studious talent."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Studious"),
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Dr. Lewis Zimmerman",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "When Lewis Zimmerman graduated Starfleet Academy in 2342 he began his computers career maintaining the complex isolinear networks on board the starships he served. His studies in isolinear database functionality combined with an interest in holo-engineering, and after a breakthrough he made resulted in more life-like holographic people, Starfleet transferred Doctor Zimmerman to Jupiter Station, the primary research facility for holographic technologies. It was here that he collected the largest database of medical facts and practices in the Federation. He even found personal logs of famous Starfleet medical officers and used them to correlate behavior and ethics into the database.",
                "The end result of this work was the creation of the Emergency Medical Hologram, or EMH1. This holographic matrix was more complex than any program written before it and consisted of multiple layers of databases, ethical subroutines and behavioral patterns giving it the skills and knowledge that most biological physicians could only dream of. Problems quickly became apparent as the behavioral routines meant that the EMH typically became contemptuous with patients and had little bedside manner. As the EMH’s appearance was modeled after Zimmerman himself, he felt a great humiliation when the programs were transferred off active Starfleet vessels for being faulty. Instead they were assigned to Federation mining facilities processing dilithium. Since that time, Zimmerman has continued his work on Jupiter Station as the research and development lead for the EMH Mk II, III, and IV programs, even while depressed with the failure of his first great creation."
            },
            Traits = new List<string>
            {
                "Human",
                "Legendary Scientist",
                "Pioneering Holo-Engineer",
                "Jerk"
            },
            Values = new List<string>
            {
                "Like father like son",
                "There’s nothing worse than a room full of pointy-eared blowhards",
                "At least one of you is still doing what I designed you to do",
            },
            Focuses = new List<string>
            {
                "Holo-Engineering", "Isolinear Computer Systems", "Neural Networks", Focus.TransportersAndReplicators
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 11, Daring = 9, Fitness = 7, Insight = 11, Presence = 7, Reason = 12 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 5, Security = 2, Medicine = 3, Science = 4 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Computer Expertise"),
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Studious"),
                new()
                {
                    Name = "Zimmerman Zeal",
                    Description = new List<string>
                    {
                        "More so than most expert holo-engineers, Doctor Zimmerman is able to layer and link multiple levels of programming into each of his creations, sometimes databases or personality traits that may not normally be compatible. When Dr. Zimmerman attempts a task for constructing a holographic character, humanoid or otherwise, the first bonus d20 is free, but the complication range is increased by 2. A complication may produce a  strange quirk to the holographic character, causing them to deviate from their normal parameters, perhaps gaining some personality flaw, or even a holographic pet iguana suddenly gaining the ability to speak and repeating embarrassing things to anyone in earshot."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Dr. Noonian Soong",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Doctor Soong was a rising star in the Federation for his work on cybernetic interfaces in prosthetics. He began research into a new form of neural networking and artificial intelligence systems that he touted as being ground-breaking during conference presentations. But year after year he was unable to present any real working models of his positronic brain, and his papers began to be rejected by journals and the Daystrom Institute. Humiliated and disgraced after giving a rambling and spiteful presentation to the Federation Science Council, Doctor Soong disappeared from public life. He secretly travelled to the colony world of Omicron Theta where he continued to work on his ‘positronic brain’. With the change in location, plus the love and assistance of his new wife Juliana O’Donnell, Soong made a breakthrough in nanoscale circuitry and made a prototype positronic brain. During those years Doctor Soong and Ms. O’Donnell perfected means to build both a positronic brain and network along with advanced cybernetic components, producing a humanoid android named B-4, and two more advanced androids, Lore and Data.",
                "After the attack on Omicron Theta by the Crystalline Entity, Soong made one final android to house the memories of his dying wife, the new Juliana being unaware that she was artificial. Soong would continue to improve upon his positronic AI systems until his death at the hands of his ‘son’ Lore in 2367, even manufacturing an ‘emotion chip’ that could give Data human-like emotions and needs. Now considered to be one of the greatest minds of the 24th century, Soong’s legacy continues to improve as Lt. Commander Data develops as a recognized sentient being."
            },
            Traits = new List<string>
            {
                "Human",
                "Legendary Scientist",
                "Pioneering Cyberneticist",
                "Long Family History of Scientists",
                "Nine Lives"
            },
            Values = new List<string>
            {
                "In my image",
                "Often wrong, but proven right",
                "Everybody dies… well, almost everybody",
            },
            Focuses = new List<string>
            {
                "Artificial Intelligence Systems", Focus.Cybernetics, "Nano-scale Engineering", "Positronic Networks",
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 10, Fitness = 6, Insight = 12, Presence = 7, Reason = 12 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 5, Security = 2, Medicine = 1, Science = 5 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                TalentSelector.GetTalentAsSpecialRule("Computer Expertise"),
                new()
                {
                    Name = "Deus ex Machina",
                    Description = new List<string>
                    {
                        "Dr. Soong’s creations have stunned the world of science and engineering, and thousands of papers have been published on the subject of the construction of simple positronic brains since his death, but none ever comes close to replicating his techniques or ability to cultivate sentience from otherwise lifeless material. Any task to reproduce or recreate Dr. Soong’s work increases in Difficulty by +2, and increases the complication range by 1. Any complication suffered from such a task counts as two complications: if a trait is created, it gains +1 Potency, while if it is paid off in Threat, 4 Threat is added rather than 2."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Studious"),

            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Dr. Richard Daystrom",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Richard Daystrom demands attention with his deep baritone voice and his imposing height, but he is able to keep people’s attention with his quick wit, incredible intelligence, and his sardonic humor. Daystrom seemed to be destined for greatness as he developed a unique way of computing what he termed ‘comptronic circuits’ during his time as a graduate student. Then, when he was only 24 years old he invented duotronic computing, a revolutionary new technology that made the older semi-conductor-based computing of the past obsolete. This single discovery swept through the Federation, technology and sensing equipment that once only fit in sickbay or science labs being able to be miniaturized and made into the standard tricorder systems known from the 23rd century onwards. He won the Nobel and Zee-Magness Prize for his work, honors that few have achieved together. His genius came with paranoia, and he felt that his work was mocked or ignored by others in his field. His feelings of persecution continued to drive him to continue his development of duotronics into what he felt was the next step in computing technology, the ‘multitronic’ M-5 system. Without a doubt, the multitronic concept provided a computer system that wouldn’t be rivaled in complexity or processing power until Dr. Soong’s invention of positronic circuitry in the 24th century, but the technology was unstable and resulted in the murder of hundreds of Starfleet personnel during wargames where the M-5 computer was in command of the Enterprise. Daystrom’s genius was not forgotten even after he was committed to an asylum for rehabilitation, and the Daystrom Institute is the preeminent center of research and development in multiple fields of study for Starfleet and the Federation as a whole.",
            },
            Traits = new List<string>
            {
                "Human",
                "Legendary Scientist",
                "Inventor of Duotronic Computing",
                "Nervous Breakdown"
            },
            Values = new List<string>
            {
                "You must not die!",
                "Living up to my own greatness",
                "Man or machine? Man and machine.",
            },
            Focuses = new List<string>
            {
                "Artificial Intelligence Systems", "Duotronic Computers", "Micro-scale Engineering", "Multitronic Computers"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 7, Daring = 7, Fitness = 9, Insight = 11, Presence = 10, Reason = 12 },
            Departments = new Departments { Command = 2, Conn = 1, Engineering = 5, Security = 2, Medicine = 1, Science = 5 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                TalentSelector.GetTalentAsSpecialRule("Studious"),
                new()
                {
                    Name = "Sure of Greatness",
                    Description = new List<string>
                    {
                        "For Daystrom’s entire adult life he has been exalted as having one of the greatest minds in the Federation. Any character assisting Daystrom increases their Complication range by 2 (18-20). Any Complication generated by this roll imposes the Beneath Me Trait, increasing the Difficulty of that character working with Daystrom again. This same Special Rule applies to the M-5 computer system itself as it uses the memory engrams of Daystrom himself, and will not directly follow commands from crewmembers if they do not fit with its vision of its base programming."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Testing a Theory"),
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Dr. Zephram Cochrane",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Perhaps the most respected scientist and engineer of Earth in the past 300 years, Zefram Cochrane came to represent humanity’s hope for a better tomorrow. Cochrane grew up during Earth’s Third World War and saw what science and progress had done to the world around him when it was used by people who only wanted to take for themselves. Educated in some of the last functioning universities in North America, Cochrane began using the remnants of cyclotrons to explore possible ways to make a more efficient fusion reactor to help bring electricity back to the millions living in darkness across the continent. His discovery of subspace and his subsequent development of warp theory brought him and some of his followers to an abandoned missile silo in Montana where he began retrofitting an ICBM with what he hoped would be a new propulsion system that would not only allow people to leave Earth for less radioactive and polluted worlds, but also could bring him enough wealth and fame that he could retire to a warm island for the rest of his life. The launch of Phoenix, the First Contact with the Vulcans, and his later self-reflection on who and what he was to the planet after his momentous flight made him change his outlook on life and become the symbol society needed as it rebuilt itself from its near destruction. Through the rest of the 21st and much of the early 22nd centuries, Cochrane continued to develop warp theory against the wishes of the Vulcans, paving the way for his final project, the Warp 5 engine. Cochrane would later disappear on a trip between the Solar System and his shipyards at Proxima Centauri, his fate unknown.",
            },
            Traits = new List<string>
            {
                "Human",
                "Legendary Scientist",
                "Pioneering Warp Engineer",
                "Functioning Alcoholic",
                "Survivor of World War 3"
            },
            Values = new List<string>
            {
                "Don’t be a great man, just be a man",
                "Let’s Rock’n’roll!",
                "Imagine it, thousands of inhabited planets at our fingertips",
            },
            Focuses = new List<string>
            {
                "Aerospace Engineering", "Classical Physics", "Rocketry", "Scavenging", Focus.SubspaceTheory, Focus.WarpTheory
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 10, Fitness = 7, Insight = 12, Presence = 7, Reason = 12 },
            Departments = new Departments { Command = 2, Conn = 2, Engineering = 5, Security = 2, Medicine = 1, Science = 5 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
                new()
                {
                    Name = "Broken liquor bottle",
                    Type = WeaponType.Melee,
                    Injury = InjuryType.Deadly,
                    Severity = 2,
                    Size = WeaponSize.OneHanded,
                    Qualities = new List<WeaponQuality>
                    {
                        WeaponSelector.GetWeaponQuality(WeaponQualityName.Intense)
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.FaithOfTheHeart),
                new()
                {
                    Name = "Godspeed",
                    Description = new List<string>
                    {
                        "Cochrane is incredibly skilled at making disparate pieces of technology, scavenged parts, and outdated computer systems work together to form a functioning vehicle and cutting-edge technology. This is often accomplished through brute force, removing safeties, or as Cochrane would put it, “Giving it enough slack to tighten up when it needs to.” This means that while a piece of technology built by Doctor Cochrane may look, act, and actually be incredibly dangerous, it tends to work out in the end. Whenever Cochrane has juryrigged a piece of technology, with the Jury-Rig talent, the gamemaster may spend 3 Momentum or Threat to have the item work again once more after its useful scenes have expired."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Jury-Rig"),
                TalentSelector.GetTalentAsSpecialRule("Testing a Theory"),
            },
            Source = BookSource.ScienceDivision1stEdition,
        },
        new()
        {
            Name = "Federation Science Councilor",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Members of the Federation Science Council are not appointed based on homeworld or population numbers; rather a Councilor is asked to join based on their field of study and the quality of their work. This means that the Science Council is typically staffed with people who have won the Nobel Prize, Zee-Maganes Prize, and Daystrom Award. These are the people who set the goals of the Federation’s major research facilities, redirect resources from industries to universities, and provide direction to Starfleet in specific mission objectives around important scientific matters. When the Science Council asks Starfleet to explore a specific star system, or to keep an eye out for a strange anomaly, it is because the Council has come to the conclusion that there is a lack of understanding or a possibility of making a significant discovery. The Science Council also provides a judicial function of sorts dealing with scientific ethics and philosophical debates about the application of new technologies, and standing in front of a Councilor attempting to justify ethically questionable methods is something no legitimate scientist ever wishes to have happen to them.",
            },
            Traits = new List<string>
            {
                "Tellarite",
                "Prominent Xenoanthropoligist",
                "Zee-Magnees Laureate",
            },
            Values = new List<string>
            {
                "Leading in discovery",
                "Nobody has all the answers, but knowing what questions to ask is the next best thing",
            },
            Focuses = new List<string>
            {
                Focus.Ethics, "The Prime Directive", "Xenoanthropology", "Xenoarchaeology", Focus.Xenobiology
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 9, Daring = 8, Fitness = 8, Insight = 10, Presence = 10, Reason = 11 },
            Departments = new Departments { Command = 3, Conn = 1, Engineering = 2, Security = 1, Medicine = 3, Science = 5 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike),
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Field of Specialty",
                    Description = new List<string>
                    {
                        "A Science Council member always has a specialty in which they are an undisputed expert. Select one of their focuses. When using that focus, the Councilor may double their focus range."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
                TalentSelector.GetTalentAsSpecialRule("Incisive Scrutiny"),
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Menacing1),
                new()
                {
                    Name = "Science on Standby",
                    Description = new List<string>
                    {
                        "The Councilor may increase the amount of Crew Support available to the ship by 2 for a single mission. This Crew Support may only be used to introduce scientists and medical personnel."
                    },
                    Source = BookSource.ScienceDivision1stEdition,
                },
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.Sturdy),
            },
            Source = BookSource.ScienceDivision1stEdition,
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
                SpeciesAbilitySelector.GetSpeciesAbilityAsSpecialRule(SpeciesAbilityName.MentalDiscipline),
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

    private static IEnumerable<NonPlayerCharacter> GetKlingonNpcs() => new List<NonPlayerCharacter>
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

    private static IEnumerable<NonPlayerCharacter> GetRomulanNpcs() => new List<NonPlayerCharacter>
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

    private static IEnumerable<NonPlayerCharacter> GetCardassianNpcs() => new List<NonPlayerCharacter>
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

    private static IEnumerable<NonPlayerCharacter> GetFerengiNpcs() => new List<NonPlayerCharacter>
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

    private static IEnumerable<NonPlayerCharacter> GetDominionNpcs() => new List<NonPlayerCharacter>
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

    private static IEnumerable<NonPlayerCharacter> GetCreatures() => new List<NonPlayerCharacter>
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

    private static IEnumerable<NonPlayerCharacter> GetUnusualLifeforms() => new List<NonPlayerCharacter>
    {
        new()
        {
            Name = "Dikironium Cloud Creature",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "Composed of dikironium gas, these creatures are either invisible or appear as a thin mist. Their presence can be noticed by the sickly-sweet smell they give off. These creatures appear to be intelligent, but utterly hostile to corporeal life. Starfleet has only encountered one of these creatures, but it can breed and there are presumably others. These creatures most likely breed rarely, by fission, potentially producing hundreds or thousands of equally deadly offspring."
            },
            Traits = new List<string>
            {
                "Dikironium Cloud",
                "Predatory Haemovore",
                "Hostile to Corporeal Life"
            },
            Values = new List<string>
            {
                "Devourer of Iron-Based Blood"
            },
            Focuses = new List<string>
            {
                "Gravity Manipulation"
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 11, Daring = 10, Fitness = 12, Insight = 7, Presence = 7, Reason = 7 },
            Departments = new Departments { Command = 0, Conn = 1, Engineering = 0, Security = 3, Medicine = 0, Science = 0 },
            Attacks = new List<Weapon>
            {
                new()
                {
                    Name = "Consumption of Blood",
                    Type = WeaponType.Melee,
                    Injury = InjuryType.Deadly,
                    Severity = 8,
                    Size = WeaponSize.OneHanded,
                    Qualities = new List<WeaponQuality>
                    {
                        WeaponSelector.GetWeaponQuality(WeaponQualityName.Area),
                        WeaponSelector.GetWeaponQuality(WeaponQualityName.Debilitating)
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Consumption Attack",
                    Description = new List<string>
                    {
                        "The Cloud’s attack relies on physical contact with a living creature’s body, so EV suits and other equipment that protects a creature from the environment renders that creature immune to the Cloud’s attacks. Forcefields, and armour which provides less than total protection has no effect. The Cloud cannot affect creatures who lack Iron-based blood, and it will suffer a complication if it attempts to attack them."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                new()
                {
                    Name = "Gaseous Creature",
                    Description = new List<string>
                    {
                        "This ravenous creature is a living cloud of gas that can spread across a space of several meters. As part of a Move minor action, the Cloud can expand to cover an entire zone, putting itself within Reach of all characters within that zone. It can move through any gap that is not air-tight, and it can fly freely through the air, and it can move through space at faster-than-light speeds."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                new()
                {
                    Name = "Invulnerable",
                    Description = new List<string>
                    {
                        "The Cloud is impervious to harm, and cannot suffer Injuries except from direct exposure to antimatter."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                new()
                {
                    Name = "Molecular Metamorphosis",
                    Description = new List<string>
                    {
                        "When being scanned or searched for, it can spend 2 Threat to alter its molecular composition, blending in with its surroundings and becoming near-impossible to detect."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                }
            },
            Source = BookSource.ScienceDivision1stEdition
        },
        new()
        {
            Name = "Eizax",
            TypeEnum = NPCType.Major,
            Description = new List<string>
            {
                "Dark matter beings that are very hard to detect. They only interact with and perceive the material Galaxy through their manipulation of gravity. They can change the force of gravity, manipulating gravitons into forms that can communicate with beings in the normal Galaxy, the strongest being able to compress and collapse stars."
            },
            Traits = new List<string>
            {
                "Eizax",
                "Dark Matter Entity"
            },
            Focuses = new List<string>
            {
                "Gravity"
            },
            PersonalThreat = 8,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 12, Daring = 10, Fitness = 0, Insight = 7, Presence = 8, Reason = 10 },
            Departments = new Departments { Command = 3, Conn = 2, Engineering = 2, Security = 5, Medicine = 0, Science = 1 },
            Attacks = new List<Weapon>
            {
                new()
                {
                    Name = "Gravitic Crush",
                    Type = WeaponType.Melee,
                    Injury = InjuryType.StunOrDeadly,
                    Severity = 6,
                    Size = WeaponSize.OneHanded,
                    Qualities = new List<WeaponQuality>
                    {
                        WeaponSelector.GetWeaponQuality(WeaponQualityName.Debilitating),
                        WeaponSelector.GetWeaponQuality(WeaponQualityName.Piercing),
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Invulerable",
                    Description = new List<string>
                    {
                        "Eizax do not exist in the material universe: they are impervious to harm, and cannot suffer Injuries."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                new()
                {
                    Name = "Gravity Sense",
                    Description = new List<string>
                    {
                        "The Eizax perceive and interact with the galaxy through sensing the mass of objects and manipulating gravity. They cannot detect energy waves or radiation."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                }
            },
            Source = BookSource.ScienceDivision1stEdition
        },
        new()
        {
            Name = "Koinonian",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "Unlike many non-corporeal lifeforms, Koinonians evolved in this form, and while they are powerful, their powers are far more limited than some other non-corporeal entities, seeming no wiser or more intelligent than most humanoids. After the corporeal beings they shared their world with destroyed themselves in a genocidal war, these creatures became aware of how fragile corporeal beings are and continue to feel guilt over not preventing the other species’ destruction. Their energy emissions are detectable to ordinary sensors and a starship’s shields can keep them out, although with effort they can briefly overload these shields. They can read minds, move and manipulate matter, cause living beings to fall unconscious, and create temporary constructs similar to those found in a holodeck, but more realistic. However, they cannot revive the dead, create living beings, or teleport themselves or any matter from one location to another. They must instead move their own non-corporeal form from one location to another, which they can do with great speed. Nothing short of a starship’s weapons is likely to affect  these powerful beings. They are peaceful, but also lack understanding of organic lifeforms."
            },
            Traits = new List<string>
            {
                "Koinonian",
                "Incorporeal Being"
            },
            Values = new List<string>
            {
                "We must atone for letting the corporeals destroy themselves",
                "Reduce the suffering of others"
            },
            Focuses = new List<string>
            {
                "Anti-matter Manipulation", "Telepathy"
            },
            PersonalThreat = 3,
            Protection = 3,
            Attributes = new CharacterAttributes { Control = 8, Daring = 8, Fitness = 8, Insight = 7, Presence = 9, Reason = 9 },
            Departments = new Departments { Command = 1, Conn = 2, Engineering = 2, Security = 2, Medicine = 0, Science = 2 },
            Attacks = new List<Weapon>
            {
                new()
                {
                    Name = "Matter Manipulation",
                    Type = WeaponType.Ranged,
                    Injury = InjuryType.Stun,
                    Severity = 4,
                    Size = WeaponSize.TwoHanded,
                    Qualities = new List<WeaponQuality>(),
                    Source = BookSource.ScienceDivision1stEdition
                },
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Incorporeal),
                new()
                {
                    Name = "Matter/Antimatter Manipulation",
                    Description = new List<string>
                    {
                        "As a major action, with a Control + Engineering or Science task with a Difficulty of 2, a Koinonian can create an object or a replica of an entity that functions almost identically to the original. It cannot create a living being, though it can create realistic-seeming simulacra. This creation is treated as a trait, rather than as a distinct character."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                TalentSelector.GetTalentAsSpecialRule("Telepathy"),
            },
            Source = BookSource.ScienceDivision1stEdition
        },
        new()
        {
            Name = "Organian",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "The Organians are exceptionally powerful entities whose powers can affect thousands of targets many light years away. Millions of years ago, they were corporeal humanoids, but evolved into creatures of pure energy with seemingly limitless powers. When visitors came to their planet, they appeared to be peaceful pre-industrial humanoids and desired only to be left in peace. However, they also abhorred the senseless taking of life and intervened in the affairs of less evolved species. These vastly powerful beings are roughly equal in power to the Q (see p.60 for details of the Q’s power). The Organians are less willing to display the full extent of their powers than the Q, but can do so when they consider it necessary."
            },
            Traits = new List<string>
            {
                "Organian",
                "Evolved Lifeforms",
                "Beings of Pure Thought"
            },
            Values = new List<string>
            {
                "Peace and Privacy"
            },
            Focuses = new List<string>
            {
                "Astral Projection", Focus.Diplomacy, "Resurrection", "Telepathic Control"
            },
            PersonalThreat = 3,
            Protection = 0,
            Attributes = new CharacterAttributes { Control = 8, Daring = 7, Fitness = 8, Insight = 10, Presence = 10, Reason = 11 },
            Departments = new Departments { Command = 3, Conn = 0, Engineering = 1, Security = 1, Medicine = 2, Science = 2 },
            Attacks = new List<Weapon>
            {
                WeaponSelector.GetWeapon(WeaponName.UnarmedStrike)
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                new()
                {
                    Name = "Far Sight",
                    Description = new List<string>
                    {
                        "An Organian ignores all penalties for distance when observing distant objects, and can perceive events occurring over many light years’ distance."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                new()
                {
                    Name = "Invulnerable",
                    Description = new List<string>
                    {
                        "Organians are impervious to harm, and cannot suffer Injuries. If they have assumed physical bodies, they can choose to appear as if injured or dead, but they cannot suffer actual harm."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                new()
                {
                    Name = "Telepathic Control",
                    Description = new List<string>
                    {
                        "An Organian can occupy and control the body of another creature. This is an opposed task, with the Organian rolling Reason + Command against the target’s Reason + Command. Success means that the Organian controls that creature for the remainder of the current scene. They can also use this ability to alter the memories of other beings, often using this to conceal their activities or involvement."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                TalentSelector.GetTalentAsSpecialRule("Telepathic Projection"),
                TalentSelector.GetTalentAsSpecialRule("Telepathy"),
                new()
                {
                    Name = "Ultimate Truth",
                    Description = new List<string>
                    {
                        "The GM may create any truth about the scene by spending 1 Threat, even if it would not naturally flow form actions in the scene, as the Organians can impose their will upon the universe. Organians do not do this frivolously or recklessly, but can use it to, amongst other things, revive the dead, or temporarily prevent all aggressive actions between two nations."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
            },
            Source = BookSource.ScienceDivision1stEdition
        },
        new()
        {
            Name = "Transformed Zalkonian",
            TypeEnum = NPCType.Notable,
            Description = new List<string>
            {
                "Corporeal Zalkonians are relatively ordinary humanoids belonging to a somewhat aggressive and authoritarian culture which values conformity and isolation and whose technology is slightly ahead of the Federation’s. However, this species is in the process of evolving into powerful non-corporeal entities. No non-corporeal Zalkonians have existed for more than a few years, and while they are relatively powerful now, no one knows how mighty they may eventually become. Currently, no one in the Federation knows if transformed Zalkonians can travel at warp speed or simply transport themselves from one star system to another. Currently their powers seem to be less overwhelming and far-reaching than those of the Organians or the Q, but this may change as they learn the full extent of their powers and continue to evolve. Like the Organians and the Q, Starfleet scientists believe that Federation weapons and shields will have no effect on these impressive beings."
            },
            Traits = new List<string>
            {
                "Zalkonian",
                "Evolved into Energy Being"
            },
            Values = new List<string>
            {
                "Evolve and help others of their kind ascend"
            },
            Focuses = new List<string>
            {
                "Recovery"
            },
            PersonalThreat = 3,
            Protection = 3,
            Attributes = new CharacterAttributes { Control = 7, Daring = 8, Fitness = 8, Insight = 10, Presence = 11, Reason = 10 },
            Departments = new Departments { Command = 1, Conn = 1, Engineering = 0, Security = 2, Medicine = 3, Science = 2 },
            Attacks = new List<Weapon>
            {
                new()
                {
                    Name = "Suffocation",
                    Type = WeaponType.Ranged,
                    Injury = InjuryType.StunOrDeadly,
                    Severity = 4,
                    Size = WeaponSize.OneHanded,
                    Qualities = new List<WeaponQuality>(),
                    Source = BookSource.ScienceDivision1stEdition
                },
            },
            EscalationAttacks = new List<(string, int)>(),
            SpecialRules = new List<NpcSpecialRule>
            {
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.ImmuneToVacuum),
                NpcSpecialRuleSelector.GetSpecialRule(NpcSpecialRuleName.Incorporeal),
                new()
                {
                    Name = "Restoration",
                    Description = new List<string>
                    {
                        "A Transformed Zalkonian can heal with a touch, even to the point of resurrecting the recently dead. A Zalkonian can spend 1 Threat to remove an Injury from a character within reach, or they may spend 3 Threat to restore a recently dead character to life (they must have died in the previous scene or current scene."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
                new()
                {
                    Name = "Teleportation",
                    Description = new List<string>
                    {
                        "A Transformed Zalkonian can transport itself and other creatures thousands of kilometers in an instant, attempting a Control + Science Task with a difficulty of 2. The difficulty increases proportionate to the number of people the Zalkonian wishes to transport."
                    },
                    Source = BookSource.ScienceDivision1stEdition
                },
            },
            Source = BookSource.ScienceDivision1stEdition
        },
    };
}
