using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class SpeciesSelector : ISpeciesSelector
{
    private readonly ISpeciesAbilitySelector _speciesAbilitySelector;

    public SpeciesSelector(ISpeciesAbilitySelector speciesAbilitySelector)
    {
        _speciesAbilitySelector = speciesAbilitySelector;
    }

    public List<Species> ChooseSpecies(string specificSpecies)
    {
        var chosenSpecies = new List<Species>();

        var mixedHeritage = Util.GetRandom(100) == 1;
        var speciesChoices = 1;

        if (mixedHeritage)
            speciesChoices++;

        var weightedSpeciesList = new WeightedList<Species>();

        foreach (var species in GetSpecies())
            weightedSpeciesList.AddEntry(species, species.Weight);

        for (int i = 0; i < speciesChoices; i++)
        {
            if (i == 0 && !string.IsNullOrWhiteSpace(specificSpecies))
            {
                chosenSpecies.Add(GetSpecies(specificSpecies));
                continue;
            }

            var species = weightedSpeciesList.GetRandom();

            if (!chosenSpecies.Any(x => x.Name == species.Name))
            {
                chosenSpecies.Add(species);
            }
        }

        if (chosenSpecies.First().HasSecondarySpeciesTrait)
        {
            chosenSpecies.Add(GetAnotherRandomSpecies(chosenSpecies.First().Name));
        }

        return chosenSpecies;
    }

    public Species GetSpecies(string name)
    {
        return GetSpecies().FirstOrDefault(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public Species GetAnotherRandomSpecies(string name)
    {
        var availableSpecies = new List<Species>();

        foreach (var species in GetSpecies())
        {
            //if (!species.NonMixed)
                availableSpecies.Add(species);
        }

        availableSpecies.RemoveAll(x => x.Name == name);

        return availableSpecies.OrderBy(n => Util.GetRandom()).First();
    }

    public List<Species> GetAllSpecies()
    {
        return GetSpecies();
    }

    private List<Species> GetSpecies() => new()
    {
        new Species
        {
            Name = SpeciesName.Andorian,
            Description = new List<string>
            {
                "An aggressive, passionate people from the frozen moon Andoria, the Andorians have been part of the Federation since its foundation. Their blue skin, pale hair, and antennae give them a distinctive appearance, and while the Andorian Imperial Guard was demobilized when the Federation was founded, they still maintain strong military traditions, and a tradition of ritualized honor-duels known as Ushaan, using razor-sharp ice-mining tools.",
                "Andorians have developed powerful traditions of ritual, convention, and personal honor to help direct their intensity and energy towards constructive ends."
            },
            ExampleCharacters= "Thy’lek Shran (Enterprise), Jennifer Sh’reyan (Lower Decks), Ryn (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Daring = 1, Presence = 1
            },
            TraitDescription = "This trait may reduce the Difficulty of tasks to resist extreme cold, or tasks impacted by extremely low temperatures. Their antennae aid in balance and spatial awareness; a lost antenna can be debilitating until it regrows. Andorians also have a high metabolism, meaning, among other things, that they tire more quickly than Humans; this also makes them more vulnerable to infection from certain types of injury.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Intense",
                Description = "When you succeed at a task where you purchased one or more d20s by adding to Threat, you generate 1 bonus Momentum for each d20 purchased. Bonus Momentum may not be saved."
            },
            Weight = 4
        },
        new Species
        {
            Name = SpeciesName.Android,
            Description = new List<string>
            {
                "Synthetic humanoids—commonly referred to as androids or synths—have been produced by many civilizations throughout the Galaxy, demonstrated by the partly understood remnants of ancient civilizations. In the 24th century, the Human scientist Noonien Soong sought to develop fully sapient androids using a positronic brain, and eventually found success, creating the androids Data and Lore. While Lore was deeply misanthropic and eventually had to be deactivated, Data became a celebrated and renowned Starfleet officer and a pioneer in cybernetics in his own right.",
                "Soong’s son Altan, along with Starfleet cyberneticist Bruce Maddox, built on theories developed by Data that would allow them to create new androids from positronic neurons taken from Data’s brain, refining the technology to where they could be created from synthetic organic tissues, making them nearly indistinguishable from Humans. These Coppelius androids—named for the planet where they were created—were discovered and their homeworld accepted as a protectorate of the Federation in 2399."
            },
            ExampleCharacters = "Data (The Next Generation), Soji Asha (Picard), Fred (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Reason = 1
            },
            TraitDescription = "The physical and mental capabilities of an android are enhanced compared to that of many organic or cybernetic life-forms. They are highly resistant to the effects of hard vacuum, disease, radiation, suffocation, toxins, and telepathy. Some environmental conditions, such as highly ionized atmospheres, intense electromagnetic discharges, and the like can have a severe effect. The legal personhood of androids has been a controversial matter, and many people look on androids with suspicion or doubt.",
            SpeciesAbility = _speciesAbilitySelector.GetSpeciesAbility(SpeciesAbilityName.SyntheticLifeForm),
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Aenar,
            Description = new List<string>
            {
                "The Aenar are a subspecies of Andorians originally native to an isolated region of the northern wastes of Andoria. Though typically blind, they are telepathic, and their other senses are heightened. Once believed to be a myth, the Aenar are few and most prefer to remain within their isolated settlements, and they rarely bother themselves with matters outside their own communities. They lack the distinctive blue skin pigmentation of other Andorians, instead having skin tones that range from white, to ice blue, to pale gray. Aenar deplore violence, and commonly follow a strictly pacifist ideology.",
                "Compared to their Andorian kin, Aenar often seem calm and restrained. They are no less proud of their heritage, but they express that pride differently, often taking great pride in their skills and the work they do. The few Aenar who leave their homeworld often come off as highly motivated and sure of themselves, maintaining their sense of self even when far from their families."
            },
            ExampleCharacters = "Jhamel (Enterprise), Hemmer (Strange New Worlds)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Biologically similar to Andorians, Aenar differ in a number of ways. Aenar are typically blind, but their other senses are heightened to a degree that more than compensates for their lack of sight. They are also telepathic which further contributes to their awareness of their environment. Aenar are typically pacifists, and thus may be reluctant, or even outright refuse, to carry out violent acts.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Telepathic",
                Description = "Aenar can sense the minds of other living creatures in their vicinity, and can read the thoughts of others, though they have strict taboos about reading a mind without permission. See the Telepathy talent for more details.",
                AddTalents = { TalentName.Telepathy }
            },
            Weight = 1
        },
        new Species
        {
            Name = SpeciesName.Aurelian,
            Description = new List<string>
            {
                "One of the few avian species to be represented within the Federation, the Aurelians are renowned for their study of history and service within the Federation Science Council. While not un  heard of, there are a few Aurelians serving in Starfleet, most commonly as science officers. Aurelians dislike enclosed spaces and many suffer from mild claustrophobia, which makes long-term service aboard a starship difficult.",
                "Most Aurelians pursuing a career in Starfleet request assignments at planetary installations, allowing them to spend their off-duty time outdoors, though some enjoy postings on larger vessels or starbases with sufficiently large recreational spaces. Their homeworld of Aurelia is an abnormally large Class-M planet covered by large expanses of scrub lands and mild deserts. Aurelians on Aurelia make their homes in natural mesa formations. Though they did not join the Federation until several decades after its formation, Aurelians were known to early Human deep space explorers."
            },
            ExampleCharacters = "Aleek-Om (The Animated Series), Adreek-Hu (Prodigy)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Insight = 1
            },
            TraitDescription = "Aurelians are capable of flight, thanks to large and muscular wings. This allows them to quickly traverse distances and avoid obstacles on the ground. They also possess keen eyesight, and a natural directional sense based on the magnetic field of planetary bodies. Nearly all Aurelians suffer from claustrophobia, though the severity of the affliction differs from individual to individual.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Airborne Avian",
                Description = "Your powerful wings allow you to maneuver easily through the air. When you take a Movement minor action or Sprint major action, you may choose to fly; if you fly, you move one additional zone, and you ignore any difficult terrain or obstacles on the ground. However, weather conditions, such as strong winds, can act as difficult terrain when you fly. When in any enclosed space, including the interior of a starship, increase the complication range of all tasks you attempt by 2, as you feel agitated and claustrophobic.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2
        },
        new Species
        {
            Name = SpeciesName.AurelianNovolare,
            Description = new List<string>
            {
                "One of the few avian species to be represented within the Federation, the Aurelians are renowned for their study of history and service within the Federation Science Council. While not un  heard of, there are a few Aurelians serving in Starfleet, most commonly as science officers. Aurelians dislike enclosed spaces and many suffer from mild claustrophobia, which makes long-term service aboard a starship difficult.",
                "Most Aurelians pursuing a career in Starfleet request assignments at planetary installations, allowing them to spend their off-duty time outdoors, though some enjoy postings on larger vessels or starbases with sufficiently large recreational spaces. Their homeworld of Aurelia is an abnormally large Class-M planet covered by large expanses of scrub lands and mild deserts. Aurelians on Aurelia make their homes in natural mesa formations. Though they did not join the Federation until several decades after its formation, Aurelians were known to early Human deep space explorers."
            },
            ExampleCharacters = "Aleek-Om (The Animated Series), Adreek-Hu (Prodigy)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Insight = 1
            },
            TraitDescription = "Aurelians are capable of flight, thanks to large and muscular wings. This allows them to quickly traverse distances and avoid obstacles on the ground. They also possess keen eyesight, and a natural directional sense based on the magnetic field of planetary bodies. Nearly all Aurelians suffer from claustrophobia, though the severity of the affliction differs from individual to individual.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Nimble Avian",
                Description = "Your agile body allows you to navigate your environment more efficiently. When you encounter difficult terrain during movement, you may reduce the Momentum cost of that terrain by 1. You may also reroll 1d20 on any Fitness + Conn task attempted when you take the Sprint major action.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2
        },
        new Species
        {
            Name = SpeciesName.Bajoran,
            Description = new List<string>
            {
                "A spiritual, dauntless people from the planet Bajor, the Bajorans lost much after decades of occupation by the Cardassian Union. Many Bajorans were scattered across the Alpha Quadrant as they fled the Occupation, while those who remained on Bajor often toiled in labor camps or fought as insurgents. The Occupation ended in 2369, but the scars it left will take generations to heal. Bajor sought membership in the Federation soon afterwards (though this application was delayed by the Dominion War), but many Bajorans have found their way into Starfleet. Bajoran culture places a strong belief in the Prophets, celestial beings who are said to have watched over Bajor for millennia; modern religious doctrine states the Bajoran wormhole is the Prophets’ Celestial Temple.",
                "Bajoran spirituality has long been a powerful factor in their lives, even for Bajorans who did not believe strongly in the Prophets. The unifying presence of their religion provided a source of hope and courage. A common sign of this faith is the D’ja pagh, a symbolic earring."
            },
            ExampleCharacters = "Kira Nerys (Deep Space Nine), Lt. Shaxs (Lower Decks)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Daring = 1, Insight = 1
            },
            TraitDescription = "Bajorans tend to be hostile towards Cardassians, and resentful of those who are dismissive of, or turned a blind eye to, the suffering of the Bajoran people. While not all Bajorans are spiritual or religious to the same degree, most have a cultural understanding of the Prophets’ place in their society.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "The Will of the Prophets",
                Description = "You may find strength in the Prophets even when the situation is dire: once per adventure, when the gamemaster spends 3 or more Threat at once, you gain 1 Determination."
            },
            Weight = 4
        },
        new Species 
        { 
            Name = SpeciesName.Barzan,
            Description = new List<string>
            {
                "A hardy and dauntless species from the resource-poor world of Barzan II, the Barzan have long emphasized community, duty, and solidarity as survival strategies, knowing that they cannot endure or thrive if they do not strive together. While known to the Federation as early as the 23rd century, the Barzan civilization lacked its own spaceflight program due to the scarcity of resources on their homeworld to spare on such a project; their early space exploration was limited to automated probes. Barzan II—and the Barzan Planetary Republic—joined the Federation during the 25th century.",
            },
            ExampleCharacters = "Nhan (Discovery), Bhavani (The Next Generation)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Daring = 1, Fitness = 1, Presence = 1 
            },
            TraitDescription = "Barzans cannot breathe without the particular gases present on their homeworld, gases which are toxic to most other species; any Barzan who leaves their homeworld makes use of breather implants to aid their respiration. Barzan culture is used to hardship, placing emphasis on duty, diligence, and sacrifice for the good of many over the desires of the individual.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Unyielding Resolve",
                Description = "You give 100% as often as you are able, and you will not allow setbacks to deter you. When you spend a point of Determination on a task roll, if the task still fails, you regain that spent Determination.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        { 
            Name = SpeciesName.Benzite,
            Description = new List<string>
            {
                "Benzites originate from numerous distinct geostructures upon their homeworld of Benzar. Benzites from the same geostructures tend to be very similar in appearance, often appearing identical to outsiders. Benzites tend to excuse this to outsiders as comparable to a “family resemblance” for other species.",
                "Benzite physiology gives their skin a hairless blueto- green complexion. The Benzite skull has a thick protrusion that extends over the brow and nose, with two facial tendrils above the lip. Highly meticulous, a Benzite officer is a valuable resource when it comes to exploration and investigation. Benzites can only breathe the atmosphere of standard Class-M planets for a short time without suffering harm, and rely on a vaporizer device to supplement their air supply with necessary gases and mineral vapors. Around 2370, some Benzites underwent surgical modifications to enable them to breathe Class-M atmospheres without the vaporizer, allowing them to live on other worlds long-term."
            },
            ExampleCharacters = "Mendon (The Next Generation), Hoya (Deep Space Nine)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Control = 1, Insight = 1, Reason = 1 
            },
            TraitDescription = "A Benzite’s average body temperature is several degrees lower than an average, warm-blooded humanoid, though the Benzites themselves are not cold-blooded. Their blood is mercury and platinum based. Benzites also have two opposable thumbs on each hand, aiding their dexterity. Some Benzites require a breathing apparatus in Class-M atmospheres: add the trait Breathing Apparatus.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "All Fingers and Thumbs",
                Description = "Your hands consist of four fingers and two thumbs each, and you’re used to operating technology swiftly and with precision. When you succeed at a task which would require extremely fine motor skills, you generate 1 bonus Momentum. Bonus Momentum cannot be saved.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Betelgeusian,
            Description = new List<string>
            {
                "Due to their quick reflexes and great physical strength, Betelgeusians are known for their martial abilities and discipline. Their culture prizes honor, discipline, and loyalty to one’s family. Betelgeusian bones are laced with heavy mineral deposits which make them resilient to energy weapons fire, making them ideal soldiers for the battlefields of any war. Though they are known for being mercenaries, the Betelgeusians have a strict code of honor where they will honor their contracts to the letter but refuse to engage in dishonorable cruelty. During the Federation-Klingon War of the mid-23rd century, Klingons were said to enjoy fighting Betelgeusians in battle because they represented a greater challenge than other members of the Federation.",
            },
            ExampleCharacters = "Cosmo Traitt (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Betelgeusians appreciate the study of combat in all its forms. In their culture, survival is never guaranteed and a wise Betelgeusian knows the importance of training their body, their mind, and their soul for all forms of conflict. Though martial, they do not engage in warfare indiscriminately and never take risks unless they are justified. Betelgeusians consider debate to be one of the highest forms of warfare because it can be used to defeat an opponent without having to strike them.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Hardened for Battle",
                Description = "Your body is hardened against harm, and your mind is hardened against fear. You have +1 Protection against any ranged attack from a phaser, disruptor, or comparable energy weapon. In addition, whenever you would suffer a trait or other effect representing fear or panic, you may suffer 1 Stress to ignore that trait or effect.    ",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Betazoid,
            Description = new List<string>
            {
                "The peaceful Betazoid people hail from the idyllic, verdant world Betazed. The world has long been a valued member of the Federation, and its people can be found across Federation space, including Starfleet. Betazoids appear almost identical to Humans but differ in one major way: they are naturally telepathic, developing mental abilities during adolescence. The potency of this ability varies between individuals.",
                "Due to their widespread telepathy, Betazoids have a culture of honesty and directness—there is little reason to be evasive or deceitful in a culture where everyone can read your mind and sense your emotions. Among non-telepaths, and even telepaths of other species, this can result in some Betazoids seeming blunt or even rude. Betazoids who spend a lot of time among other cultures tend to either lean into this notion or choose to temper their honesty with tact."
            },
            ExampleCharacters = "Deanna Troi (The Next Generation), Lon Suder (Voyager)",
            AttributeModifiers = new CharacterAttributes
            {
                Insight = 1, Presence = 1, Reason = 1
            },
            TraitDescription = "All Betazoids are telepathic to varying degrees, and even when not actively using their abilities, they are highly perceptive of others around them, but also highly sensitive to telepathic disturbances and mental assaults. They have little familiarity with lies and deception, due to their open culture and ability to read the thoughts and emotions of others. As they are sensitive to the minds of other living beings, they tend not to be comfortable around animals, for fear of losing themselves in the minds of wild creatures. Similarly, they can find species immune to telepathy to be off-putting. ",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Telepathic",
                Description = "Betazoids can sense the minds of living creatures in their vicinity and can read the thoughts and emotions of others. Each Betazoid has either Telepathy or Empathy (see Talents for more details). Part-Betazoid characters generally have Empathy rather than Telepathy.",
                AddOneOfTheseTalents = new List<string> { TalentName.Telepathy, TalentName.Empathy }
            },
            Weight = 8
        },
        new Species 
        { 
            Name = SpeciesName.Bolian,
            Description = new List<string>
            {
                "Bolians are a good-natured, sociable, even garrulous species native to Bolarus IX in the Beta Quadrant. A long-time ally of the Federation, Bolians see great value in hard work and cooperation, and they are often drawn to environments and professions that allow them to mingle with a variety of other peoples. As a result, Bolians can be found in all walks of life and on countless worlds, including Earth, and they are a common sight throughout Starfleet and civilian life in the Federation. Beyond that, Bolian trading institutions, such as the Bank of Bolias, often serve as intermediaries for trade between other polities such as the Federation and the Ferengi Alliance.",
            },
            ExampleCharacters = "Mot (The Next Generation), Chell (Voyager)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Control = 1, Insight = 1, Presence = 1 
            },
            TraitDescription = "Bolians have a reputation as a gregarious, hospitable people, and they’re commonly found in public-facing roles. Bolian bodily fluids are highly toxic to other species, while their anatomy allows them to consume and withstand foodstuffs that would be inedible to anyone else.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Amiable",
                Description = "You’re outspoken and sociable, always with a supportive word to ease your comrades’ burdens. Whenever you succeed at a Presence-based task roll, the Momentum cost to remove an ally’s Stress is reduced to 1. Whenever you and an ally both rest, and spend a meaningful part of that rest together (the entire breather, at least half of a break, or at least one hour of a longer rest), you each recover 1 more Stress than normal.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 4,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Breen,
            Description = new List<string>
            {
                "A species with an isolationist, militaristic culture, the Breen have been an enigma for centuries; indeed, few had seen a Breen outside of their refrigeration suits and lived to tell of it prior to the 32nd century. Their territory is deep within the Alpha Quadrant, beyond the Cardassian Union and Ferengi Alliance. Contact with the Federation and other Beta Quadrant polities is rare and typically violent, though they are regarded as secretive and untrustworthy even to the Romulans, who have a saying: “Never turn your back on a Breen.”",
                "During the 24th century, little was known of the Breen Confederacy, but they were considered to be one of the most warlike cultures in the Galaxy. They came into wider contact with the other powers of the Alpha and Beta Quadrants when they aligned themselves with the Dominion. Centuries later, the Breen Imperium was similarly militaristic, but also highly territorial and expansionist, though just as secretive about themselves. Among the few facts known was that some Breen technology was based on biotechnology, cultivating engineered strains of algae to possess properties similar to other useful materials, and allowing them to grow technological components."
            },
            ExampleCharacters = "Gor (Deep Space Nine), L’ak (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Insight = 1
            },
            TraitDescription = "Breen physiology is semi-gelatinous in nature, but with effort and concentration they can assume a more solid form with a hardened outer shell, though they dislike doing this: young Breen are taught that solid state was a sign of weakness. Breen are accustomed to extremely low temperatures, and they customarily wear all-concealing refrigeration suits. Breen do not have blood or other bodily fluids, only their natural gelatinous substance, and few non-Breen have any understanding of Breen physiology. The thoughts and emotions of Breen are not detectable by telepaths or empaths.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Gelatinous Form",
                Description = "In your natural gelatinous state, you may reroll 1d20 on any task roll using Control. You may assume a solid state by suffering 2 Stress, gaining 1 Protection, but losing the reroll from your gelatinous form. While wearing a refrigeration suit, you gain 1 Protection without the need to suffer Stress, and may remain in your gelatinous state.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Brikar,
            Description = new List<string>
            {
                "Also sometimes called Brikarians, the Brikar are an unusual species who originate from the planet Brikar in the Beta Quadrant, near the Federation-Klingon border. Brikar are large, powerfully built creatures whose bodies are covered in dense silicate growths that appear like rocks. Brikar skin comes in a variety of colors and patterns, similar to those seen in geological formations. Younger Brikar molt their original rocky skin periodically through their lives as they grow, and older Brikar often require gravity compensators to allow them to move effectively in non-Brikar gravity levels.",
                "For all that their appearance can be intimidating to others, Brikar are generally a curious, thoughtful people, and while they can be formidable in battle, they have no particular inclination towards violence. Indeed, a long history of struggles with the Klingons mean that many Brikar think poorly of warrior cultures, and have a strong drive for fairness and justice.    "
            },
            ExampleCharacters = "Rok-Tahk (Prodigy)",
            AttributeModifiers = new CharacterAttributes
            {
                Fitness = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Brikar are large, powerfully built, stoneskinned humanoids, whose dense silicate hides are highly resistant to impact and even energy weapons. Their size and mass can make them somewhat cumbersome, especially as they age and grow—but they are incredibly strong and durable. Their physical resistance does not extend to extreme cold, however. Brikar are imposing, intimidating creatures due to their size and rocky appearance, which often makes people underestimate their quiet wisdom.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Rock Hard",
                Description = "Your body is huge, heavy, and rocky. You have 2 Protection against all attacks. However, you add 1 Threat whenever you take an action where your mass and size would be a potential risk ",
                ProtectionBonus = 2,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Bynar,
            Description = new List<string>
            {
                "The Bynars are a species of humanoids known for being cybernetically enhanced; shortly after birth, every Bynar child has the parietal lobe of their brain replaced with a powerful synaptic processor, linking them to the central computer of their homeworld, Bynaus, and to other Bynars. Bynars live and work in pairs, their cybernetic link connecting them so closely that their thought patterns naturally flow from one to another: two minds thinking the same thoughts. While they can speak when conversing with other species, Bynars communicate among each other via a binary machine language, transmitted as a high-frequency burst of sound that they can receive using their implants. This form of communication is far more efficient than speech, allowing them to convey far more detailed information in a very short time.",
            },
            ExampleCharacters = "Zero-Zero, Zero-One, One-Zero, One-One (The Next Generation)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Reason = 1
            },
            TraitDescription = "Despite their small stature and slight build, Bynars are surprisingly resistant to harsh environments, due to generations of cybernetic enhancement and genetic engineering performed upon their ancestors millennia ago. Their cybernetics and machinelike thought processes allow them to understand and interact effectively with almost any computer system, even ones unfamiliar to them.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Bynar Pair",
                Description = "You are a Cyborg, and may select cybernetic talents. You always operate in a pair with another Bynar who has been with you since you were both children. Create a Bynar supporting character as your partner; this supporting character starts with one value, which must either be the same as one of yours, or directly reference it. You do not need to use Crew Support to introduce this supporting character each session, and they always accompany you (following the rules for uncontrolled supporting characters on page 144 of the core rulebook).",
                TraitGained = "Cyborg",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species 
        { 
            Name = SpeciesName.Caitian,
            Description = new List<string>
            {
                "A species of felinoid bipeds with a long history of involvement in the Federation and service to Starfleet, Caitians originate from the Class-M planet Cait, a world of plains and grasslands with sprawling cities that respect and integrate with the natural environment. It’s believed that Caitians and the Kzinti have a common ancestor, much as Romulans and Vulcans do. Caitians have a proud military history, and evolved from predatory ancestors, but they also have great appreciation for art and philosophy. Caitians have contributed greatly to the culture of the Federation since they became members.",
            },
            ExampleCharacters = "M’Ress (The Animated Series), T’Ana (Lower Decks)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Daring = 1, Fitness = 1, Insight = 1 
            },
            TraitDescription = "Caitians are smaller and slighter than is common for humanoids, but are significantly more flexible and dexterous, with a flexible tail aiding them in balance. They can hear low-frequency sounds below the normal Human range of hearing. Caitians are broadly carnivorous, and have no difficulty consuming raw meat (or its replicated equivalent).",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Feline Form",
                Description = "You have a prehensile tail, and retractable claws in your fingertips, useful for climbing and hunting. Whenever you attempt a task to maintain your balance or to climb, the first d20 you purchase is free. Further, you may grasp objects with your tail, though not as tightly or easily as with your hands. Due to your claws, your unarmed attacks may inflict both Stun and Deadly Injuries.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2 ,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Cardassian,
            Description = new List<string>
            {
                "Often vilified and distrusted due to the actions of their government, Cardassians have a reputation for being ruthless, deceitful, and aggressive. Due to a dearth of natural resources and an economic collapse, Cardassian culture was overtaken by an oppressive authoritarian regime dominated by the military, which began a decades-long campaign of expansion, conquest, and exploitation, including the occupation of Bajor and a lengthy border conflict with the Federation. In the aftermath of the Dominion War, with the military government overthrown, the rebuilding of Cardassia was a difficult process, not least because of long-held feelings of resentment towards the Cardassians.",
                "Cardassians are a creative, dedicated people, with a strong cultural fascination with intrigue. Cardassians are inclined to keep secrets, and to regard suspicion as wisdom, and the uncovering of secrets is regarded as a valuable skill."
            },
            ExampleCharacters = "Elim Garak (Deep Space Nine), Seska (Voyager)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Presence = 1, Reason = 1
            },
            TraitDescription = "Cardassians are a pseudo-reptilian species, used to an environment somewhat warmer and more humid than is comfortable for Humans, and tend to find bright light uncomfortable. Their culture prizes mental discipline and obedience to strict hierarchies and they have a reputation for arrogance, cruelty, and smug superiority.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Healthy Suspicions",
                Description = "You may add 1 Threat when interacting with an NPC to ask the gamemaster if that NPC is lying about something. The gamemaster must answer either Yes or No, and this answer must be accurate, but the gamemaster does not have to specify what the NPC is lying about."
            },
            Weight = 0
        },
        new Species
        {
            Name = SpeciesName.Cetacean,
            Description = new List<string>
            {
                "Cetaceans are not a single species; rather, it is a term for several species of warm-blooded, air-breathing mammals native to Earth, including various species of whale, dolphin, and porpoise. While highly intelligent, they were regarded more as animals than as sapient beings for much of Human history due to significant communication barriers between Cetacean species and Humans. Major breakthroughs involving those communications problems were made in the late 23rd century when Admiral Kirk and his crew brought two humpback whales to the present from the 20th century to communicate with an alien probe.",
                "Still, Cetaceans are somewhat rare in the Federation, partly due to many species becoming endangered in Earth’s past, and partly because few Federation or Starfleet facilities are built to accommodate aquatic species. Despite this, several larger classes of Starfleet vessels in the 24th century and onwards incorporate Cetacean Operations departments, crewed by a small number of Cetacean officers (and personnel from other aquatic species) using their aquatic perspective and distinct sensory processing abilities to aid interstellar navigation."
            },
            ExampleCharacters = "Matt (Lower Decks), Gillian (Prodigy)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Insight = 1, Reason = 1
            },
            TraitDescription = "This character is a member of one of several species of Cetaceans. You’re an aquatic mammal, adapted to living underwater and efficient swimming, but you have difficulty operating outside of water without adaptive technology. You require air to breath, but can hold your breath for an extended period. You can accurately perceive aquatic environments, and navigate within them, using echolocation. At your discretion, you may replace the name of this trait with the name of a specific species of Cetacean. It is recommended to only play Cetaceans who are approximately Human-sized, rather than larger species of whale.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Aquatic Mammal",
                Description = "You can move freely and without hindrance through the water. You may ignore any traits or injuries caused by exposure to extremely cold aquatic conditions. However, when on land you are always considered to be Prone (core rulebook, page 288).",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Chameloid,
            Description = new List<string>
            {
                "A semi-amorphous species, Chameloids are shapeshifters, able to assume the appearance of a variety of other species, or even specific individuals, right down to their clothing. Without the use of advanced scanning technology, it’s extremely difficult to detect a disguised Chameloid. For this reason, Chameloids are often regarded with suspicion and even fear, though encounters with them are rare enough that many people doubt the existence of Chameloids entirely.",
                "Chameloid culture is little known, and the Chameloids themselves are secretive and elusive at the best of times, often finding themselves involved in criminal activities or covert work where their abilities are most useful, and where the distrust directed at their kind is less of a concern. Chameloids may choose to favor one common form over others for interacting regularly with friends, allies, or colleagues, or even with one specific group of marks. They do not have a physical sex, and they only have a sense of gender within the context of specific adopted forms."
            },
            ExampleCharacters = "Martia (Star Trek VI: The Undiscovered Country), Quasi (Section 31)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Chameloids are a species of shapeshifters, whose rarely-seen natural form is a writhing mass of tubules and tendrils. They can quickly alter their cellular structure to adopt the appearance of other individuals from other species, including their clothing, and it seems to take little effort or cause them little strain to do so. Telling a disguised Chameloid apart from a true member of a species is extremely difficult without technological scanning methods.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Natural Shapeshifter",
                Description = "You commonly exist in a form other than your natural state. At the start of a mission, you gain an additional trait to reflect the form you’ve chosen, which may be the form of a specific individual. You may suffer 1 Stress as a minor action once per turn to change this form. It is difficult (requiring a successful Difficulty 3 task) to detect a disguised Chameloid without technological assistance.",
                Source = BookSource.SpeciesSourcebook
            },
            HasGender = false,
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Changeling,
            Description = new List<string>
            {
                "Also known as the Founders of the Dominion, the Changelings are deeply wreathed in myth, legend, and hearsay. They generally dislike “solids”—their term for other species—and they founded the Dominion in order to protect themselves from what they perceived as the brutality and hostility of other species. Changelings themselves are composed of a morphogenic substance that allows them to adopt the appearance and properties of other creatures and objects. At their most basic level, this allows them to blend into their surroundings, mimicking rocks, plant life, and simple animal life. With practice and experience, they can perfectly mimic the likeness and manner of sapient beings, or even take the form of luminescent displays or even complex cosmozoans able to travel through space on solar winds or by entering subspace. Their shapeshifting is on a molecular level, making them extraordinarily difficult to detect without specially calibrated sensors.",
                "Changelings seldom allow themselves to be seen by outsiders, due to many experiences of being hunted or attacked. They are more willing to appear in disguise, but they prefer to act through proxies, such as the Vorta and Jem’Hadar."
            },
            ExampleCharacters = "Odo (Deep Space Nine), Vadic (Picard)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "A Changeling is a mass of viscous orange-brown fluid, which can arrange its molecular structure to adopt the form of other objects, from living creatures to diffuse substances such as fog. While they cannot become energy, given sufficient skill and practice, a Changeling can adopt almost any other form: it is theorized that they transfer energy and mass to and from subspace to alter size and mass. They are deeply distrustful of “solids,” and often find themselves persecuted for their abilities.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Morphogenic Matrix",
                Description = "You may suffer 1 Stress as a minor action once per turn to assume a different form, gaining one additional trait to reflect whatever form you have chosen. You cannot yet mimic a specific individual, and you must revert to a liquid state for a few hours after sixteen hours in a solid form. While in an alternate form, it is next to impossible (requiring a Difficulty 5 task roll) to detect a hidden Changeling. Your body is highly resistant to physical harm and energy weapons, giving you Protection 2, and your thoughts and emotions cannot be detected by telepaths or empaths. You are immune to extremes of heat, cold, and exposure to vacuum.",
                Source = BookSource.SpeciesSourcebook
            },
            HasGender = false,
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.CoppeliusAndroid,
            Description = new List<string>
            {
                "Synthetic humanoids—commonly referred to as androids or synths—have been produced by many civilizations throughout the Galaxy, demonstrated by the partly understood remnants of ancient civilizations. In the 24th century, the Human scientist Noonien Soong sought to develop fully sapient androids using a positronic brain, and eventually found success, creating the androids Data and Lore. While Lore was deeply misanthropic and eventually had to be deactivated, Data became a celebrated and renowned Starfleet officer and a pioneer in cybernetics in his own right.",
                "Soong’s son Altan, along with Starfleet cyberneticist Bruce Maddox, built on theories developed by Data that would allow them to create new androids from positronic neurons taken from Data’s brain, refining the technology to where they could be created from synthetic organic tissues, making them nearly indistinguishable from Humans. These Coppelius androids—named for the planet where they were created—were discovered and their homeworld accepted as a protectorate of the Federation in 2399."
            },
            ExampleCharacters = "Data (The Next Generation), Soji Asha (Picard), Fred (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Reason = 1
            },
            TraitDescription = "The physical and mental capabilities of an android are enhanced compared to that of many organic or cybernetic life-forms. They are highly resistant to the effects of hard vacuum, disease, radiation, suffocation, toxins, and telepathy. Some environmental conditions, such as highly ionized atmospheres, intense electromagnetic discharges, and the like can have a severe effect. The legal personhood of androids has been a controversial matter, and many people look on androids with suspicion or doubt.",
            SpeciesAbility = _speciesAbilitySelector.GetSpeciesAbility(SpeciesAbilityName.SyntheticLifeForm),
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species 
        { 
            Name = SpeciesName.Deltan,
            Description = new List<string>
            {
                "These humanoids from the Delta system differ in appearance only slightly from Humans, with very little hair across their bodies, aside from eyebrows and lashes. As a telepathic and empathic species, Deltans rank themselves alongside the Vulcans and Betazoids as able to read and communicate via thoughts and feelings. Indeed, some Deltan genealogists have theorized Betazoids are a distant cousin species.",
                "With some of the most potent pheromones the Federation has ever encountered, many other species find the Deltans very sexually appealing. The vast majority of Deltans in Starfleet, therefore, take an oath of celibacy, ensuring their sexuality is not a distraction to their colleagues. By all accounts this is a good thing, as the Deltan act of intimacy involves not only their bodies but also their telepathic minds, which can be overwhelming, or even hazardous, to an unprepared mind."
            },
            ExampleCharacters = "Ilia (Star Trek: The Motion Picture), Melle (Section 31)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Control = 1, Insight = 1, Presence = 1 
            },
            TraitDescription = "Deltans are considered to be beautiful individuals, with powerful empathic abilities and heightened sensuality. The pheromones they excrete are a natural aphrodisiac in most species throughout the Federation, and while serving in Starfleet, they must be very careful with their natural physiology, using chemical suppressants to cancel the effect.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Empath",
                Description = "You have the Empathy talent, described on page 155 of the core rulebook. You may develop this ability further by selecting the Telepathy talent during the course of character advancement.",
                AddTalents = { TalentName.Empathy },
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Denobulan,
            Description = new List<string>
            {
                "Hailing from the planet Denobula, Denobulans are a gregarious, inquisitive people who have been allies of humanity since the 2130s. Denobulans are long-lived and highly sociable, with large families—Denobulans are typically polyamorous, with individuals potentially having several spouses, each of whom may have several spouses of their own, and dozens of children between them—living in relatively close, communal environments. Culturally, Denobulans are an intellectually curious people, highly perceptive, and interested in a wide range of philosophies, with their long lives allowing them to pursue a wide range of fields of study, often granting them unusual perspectives on the different philosophies and fields of expertise they’ve studied.",
                "Denobulans enjoy learning new things, meeting new people, and they revel in the drama, intrigue, and gossip that come from a rich and complex social environment. They are extraordinarily patient, taking a long view of the changes that happen in life, but they dislike solitude, and even a busy starship or starbase can sometimes seem a little empty to a Denobulan."
            },
            ExampleCharacters = "Phlox (Enterprise)",
            AttributeModifiers = new CharacterAttributes
            {
                Fitness = 1, Insight = 1, Reason = 1
            },
            TraitDescription = "Denobulans have a robust immune system, but a vulnerability to various forms of radiation poisoning. They are adept climbers. Denobulans do not need to sleep, but must hibernate for several days each year, becoming disoriented if kept awake during this period.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Breadth of Study",
                Description = "You may select two additional focuses.",
                AdditionalFocuses = 2
            },
            Weight = 2
        },
        new Species 
        { 
            Name = SpeciesName.Edosian,
            Description = new List<string>
            {
                "Edosians are a tripedal species with three arms and three legs. While not a member of the Federation, the Edosians have had a long-standing, loose alliance with the Federation since their first contact. It is rare, though not unknown, for Edosians to serve in Starfleet. Edosian culture tends toward inner reflection and a meticulousness with historical records. Genealogy has a much larger focus than in many other cultures, and Edosians are able to trace their individual family lines back thousands of years. Being a species that lives longer than even Vulcans, an Edosian may spend decades focused on a particular area of study before moving on to a new interest. With practice, an Edosian becomes capable of allocating sections of their brain to each arm, operating independently with nearly full focus and capability.",
            },
            ExampleCharacters = "Arex (The Animated Series), Toz (Lower Decks)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Fitness = 1, Insight = 1, Reason = 1 
            },
            TraitDescription = "With three legs, Edosians are somewhat slower than most humanoids, but far more stable. With three multi-dextrous arms, they are able to operate multiple stations or controls at the same time. They are long-lived and capable of deep thought—which others often mistake as antisocial behavior. Their long lives grant them a perspective most others lack, and they are often able to recall details and facts from disciplines outside their areas of focus due to decades of exposure and broad study.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Trilateral Symmetry",
                Description = "Edosians are capable, with effort and practice, of compartmentalizing their thoughts and operating each arm completely independently, performing multiple complex tasks simultaneously. When you spend Momentum on the Swift Action option, you may suffer 1 Stress to ignore the normal Difficulty increase of your second action. You may also suffer 1 Stress to ignore the Difficulty increase from the Override starship conflict action.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species 
        { 
            Name = SpeciesName.Efrosian,
            Description = new List<string>
            {
                "Hailing from the planet Efros Delta, Efrosians are renowned musicians and historians. Their society is dedicated to oral teaching, most notably in the form of a musical language that all Efrosian children are taught in some form or another. They are also excellent navigators and are often sought out as helm and navigation officers, as well as translators, thanks to being natural linguists and communications experts. While their cranial ridges bear some similarity to Klingon physiology (though less pronounced), a male’s hair is almost always white from birth while females exhibit darker colors. Males often grow long moustaches and both male and female Efrosians grow their hair long.",
            },
            ExampleCharacters = "President Ra-ghoratreii (Star Trek IV: The Undiscovered Country), Hy’Rell (Discovery)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Fitness = 1, Presence = 1, Reason = 1
            },
            TraitDescription = "As the natives to a planet of harsh, freezing storms, Efrosians have natural resilience and survival instincts. They have two stomachs to break down any tough foodstuffs and protect them from infection, while their naturally poor eyesight is made up for by their enhanced senses of smell and taste. Interestingly, even though they have poor vision compared to other humanoids, they can perceive a greater portion of the light spectrum than most.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Visual Spectrum",
                Description = "An Efrosian can see beyond the normal Human visual spectrum, from some infrared to ultraviolet light. Any task in which detecting those parts of the spectrum is useful reduce in Difficulty by 1. Location or situation traits such as low light levels, do not affect the Difficulty of tasks for an Efrosian.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.ElAurian,
            Description = new List<string>
            {
                "Appearing similar to Humans in many ways, El-Aurians are an enigmatic species, a culture of “listeners” who travel far and wide across the Galaxy learning about other cultures and offering advice. Many of their kind had travelled as far as Earth even as early as the 19th century. They seem to possess an unknown perceptive capability which extends beyond the normal boundaries of space-time. The El-Aurians’ homeworld was conquered by the Borg in the mid-22nd century.",
                "While they are biologically very similar to Humans, El- Aurians are notable for their extremely long lifespans, allowing them to remain vital and active for centuries or longer. Further, older El-Aurians have demonstrated the ability to influence the visible signs of their own aging, allowing them to remain unchanging for centuries or superficially age among shorter-lived species to help blend in among them: it’s been said that El-Aurians only age when they choose to. However, young El-Aurians reach maturity at around the same time as Humans."
            },
            ExampleCharacters = "Guinan (The Next Generation), Tolian Soran (Star Trek Generations), Kassia Nox (Lower Decks)",
            AttributeModifiers = new CharacterAttributes
            {
                Insight = 1, Reason = 1, Presence = 1
            },
            TraitDescription = "While they appear almost indistinguishable from a Human, El-Aurian physiology allows them to live for several centuries, and gives them an awareness that transcends the normal bounds of space, time, and dimensions. El-Aurians have a long-standing treaty with the extradimensional entities known as the Q Continuum, and the Q tend to treat El-Aurians warily.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Transtemporal Awareness",
                Description = "You are aware of shifts and changes in the fabric of space-time in ways that few other beings are. Whenever there is a phenomenon present in a scene which was caused by alterations to the timeline, or the influence of alternate dimensions or extradimensional entities, the gamemaster must immediately inform you that something is wrong (though they do not have to specify what). You may add 1, 2, or 3 Threat to ask that many questions (as per Obtain Information) to try and discern details about the phenomenon.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Exocomp,
            Description = new List<string>
            {
                "Sapient machines, Exocomps began as semi-autonomous industrial devices on Tyrus VII, but after being experimentally upgraded by Dr. Farallon grew in complexity and sophistication until they achieved self-awareness by modifying their own programming for greater efficiency. There was resistance to the idea that Exocomps were living, intelligent beings, in part due to their utility as autonomous tools, but also due to the difficulty of communicating effectively with them, and it took the efforts of another artificial life-form—Lieutenant Commander Data—to realize the truth.",
                "Exocomps were designed with an adaptive intellect which could physically construct new circuit pathways to adapt themselves to new assignments. They were also built around a potent, compact micro-replicator which could fabricate whatever tools necessary for a given repair job. Because of these factors, Exocomps are extremely capable when it comes to performing precise, delicate tasks.",
                "With some struggle, Exocomps were eventually recognized as sapient, with sophisticated intelligence, complex social structures, and something equivalent to families. Exocomps can even have children, with groups using their replicators to produce the parts to build a new one of their kind. Though they’ve developed the ability to speak and understand language, they don’t always interact well with humanoid life, as their understanding of humanoid emotion is limited, and they lack the body language and other social cues that humanoids typically use to communicate."
            },
            ExampleCharacters = "Peanut Hamper (Lower Decks), Kevin (Lower Decks)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Daring = 1, Reason = 1
            },
            TraitDescription = "Exocomps are technological lifeforms which can crawl across the ground or hover for short periods of time. They are extremely capable of performing fine, complex tasks, and can replicate any tools needed to complete the job in front of them. As technological beings originally created for dangerous industrial tasks, an Exocomp is unaffected by vacuum and does not need to breathe, and is highly resistant to extremes of temperature and other hostile environments.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Technological Life",
                Description = "You are not an organic being, and are not vulnerable to physical harm as they are: you have +1 Protection against Stun Attacks. You recover from injuries with Engineering, rather than Medicine. In addition, your onboard micro- replicator allows you to produce small tools and one-handed items for your own use with opportunity cost 1 by suffering 1 Stress for each such item created. Due to your lack of hands, you cannot use tools made for other creatures.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            HasGender = false,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Ferengi,
            Description = new List<string>
            {
                "An acquisitive species native to Ferenginar, the Ferengi are unimposing beings, known mostly as merchants and traders. Their culture promotes the accumulation of material wealth, and their society is capitalistic, with most routine activities accompanied by an exchange of money, typically in the form of gold-pressed latinum (a non-replicable liquid metal, suspended within “slips,” “strips,” “bars,” and “bricks” of gold). Ferengi society is strongly patriarchal, with female Ferengi traditionally disallowed from owning property or even wearing clothing (and male Ferengi often having deeply unpleasant attitudes towards non-Ferengi women), though these attitudes start to change by the late 24th century.",
                "Ferengi pride themselves on their ability to acquire wealth, though there are many different approaches to this. For centuries, Ferengi culture has been dominated by the philosophies and lessons of the Rules of Acquisition, though these can be interpreted in a variety of different ways and applied to a Ferengi’s life."
            },
            ExampleCharacters = "Quark (Deep Space Nine), Nog (Deep Space Nine)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Ferengi physiology does not lend itself to physical activity, nor does their culture value such hardship, though they have a resistance to many common diseases. Ferengi have exceptional hearing, and highly sensitive ears, though this also means that intense sounds (and physical force applied to the ears) can inflict debilitating pain. Their unusual brain structure means that telepaths cannot read Ferengi minds. Ferengi regard the accumulation of wealth as the highest virtue, and while this has given them a reputation as cunning negotiators, they are also often seen as duplicitous and manipulative.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "The Great Material Continuum",
                Description = "Once per session, when obtaining additional equipment, you may reduce the Opportunity Cost of an item by 1, to a minimum of 0."
            },
            Weight = 1
        },
        new Species
        {
            Name = SpeciesName.Grazerite,
            Description = new List<string>
            {
                "The Grazerite are a peaceful people whose homeworld, Grazer, is one of the harsher examples of the far ends of the Class-M classification. The three main continents are predominately covered by extensive mountain ranges that reach as far as 10 kilometers above sea level. The Grazerites’ evolutionary development has incorporated not only traditional humanoid traits—but also those of Bovidae—giving them goatlike physical features. Grazerites are a peaceful people with a natural sense of curiosity. Grazerites have a deep dislike of conflict and actively avoid it if possible. Grazerite officers in Starfleet pursue careers in most fields—but it is nearly unheard of to see them serving as tactical or security officers. In Grazerite society, it is considered impolite (bordering on indecent) to leave one’s horns and hands uncovered, and thus Grazerites are usually seen with gloves and a headwrap.",
            },
            ExampleCharacters = "President Jaresh-Inyo (Deep Space Nine) ",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Grazerites possess powerful jaws and durable teeth—allowing them to chew through a surprising number of hardened substances. They cannot, however, digest inorganic materials, despite being able to chew through them, and as evolutionary vegetarians, have a difficult time digesting meats. Their brows are adorned with a pair of durable horns, which slope back in the vast majority. Further, Grazerite fingers evolved from hooves and their fingernails remain extremely dense, and are capable of supporting their full weight, making them excellent climbers.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Agreeable",
                Description = "You are inclined to seek agreement and cooperation in everything you do. When you succeed at an Insight-based task to discern another creature’s mood, or a Presence-based task to try and defuse a conflict or confrontation, you may immediately recover 1 Stress.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Hologram,
            Description = new List<string>
            {
                "While more primitive forms of holotechnology has existed in numerous forms in the Federation and its neighbors as far back as the mid-22nd century, advances—as well as some accidental discoveries—in the late 24th century allow for increasingly-sophisticated holograms that blur the line between simulated behavior and true self-awareness. The introduction of the Emergency Medical Hologram to Starfleet vessels in the 2370s was a major step forward, and though plagued with a few false starts, independent holograms became increasingly common over the decades that followed.",
                "True self-awareness is relatively rare in holograms, and seems to occur as much through the conditions and circumstances they experience as through any intentional programming: many advanced holograms have the potential to become truly sapient, but only a few of them ever do. These few, however, are often staunch advocates for both their own independence and the rights of holographic or photonic beings. As they’re normally programmed to emulate humanoid behavior (and often modelled on individuals), sapient holograms don’t tend to have the same difficulty relating to organic beings that other artificial intelligences do."
            },
            ExampleCharacters = "Professor James Moriarty (The Next Generation), Vic Fontaine (Deep Space Nine), The Doctor (Voyager), Kathryn Janeway (Prodigy)",
            AttributeModifiers = new CharacterAttributes(),
            ThreeRandomAttributes = true,
            TraitDescription = "A hologram can be programmed to any specification, and while they may appear indistinguishable from an organic being, a hologram’s physical presence—or holomatrix—is a combination of light and energy suspended in a force field, colloquially called “holomatter,” which is projected from a holo-emitter. Holograms cannot truly be subject to physical harm (though they can certainly simulate it), though their holomatrix can become disrupted, and holo-emitters can be damaged. A hologram can only exist in locations where there are holo-emitters present. Holograms are often disrespected by flesh-and-blood people, who tend to regard them as tools more than people. Holograms may have a second species trait, to reflect the species they were designed to emulate",
            HasSecondarySpeciesTrait = true,
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Photonic",
                Description = "You are not an organic being, and are not vulnerable to physical harm as they are: you have 2 Protection. Injuries and fatigue you suffer represent disruption to your holomatrix or damage to holo- emitters. You recover from injuries with Engineering tasks, rather than Medicine. You cannot be present in any scene where there are no holo-emitters. In addition, because you were programmed for a specific purpose, you do not have a pastime.",
                ProtectionBonus = 2,
                HasPastime = false,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Horta,
            Description = new List<string>
            {
                "Horta are sapient, silicate life-forms native to the Alpha Quadrant planet Janus VI. Appearing as an amorphous rocky mass, Horta have little in common with carbon- based life, and they were not identified as being sapient until encountered by the crew of the U.S.S. Enterprise NCC-1701 in 2267, after conflict had arisen between a Human mining colony and the native Horta. Indeed, silicon- based life was deemed purely theoretical prior to first contact with the Horta. The Horta have an extraordinarily long life cycle, spanning almost fifty thousand years, at the end of which time a single mother Horta will remain to guard over the eggs for a new generation.",
                "Horta feed upon mineral deposits found within rock, and they absorb these minerals while tunnelling through rock: their bodies secrete a highly potent acid that dissolves rock, metal, and even organic matter with ease, allowing them to tunnel through dense stone as easily as a Human might walk through an empty room. They are, however, highly intelligent and compassionate beings, and once communication was established between the Horta and the miners on Janus VI, they were able to cooperate extremely effectively. Horta cannot speak, but communicate through scent, vibration, and a limited psionic communion; among humanoids, they rely on universal translators, but in an emergency, they can etch writing into solid surfaces with their acid.",
                "Since then, small numbers of Horta have travelled to other worlds, often as part of mining cooperatives, and a handful have even joined Starfleet."
            },
            ExampleCharacters = "Dahai Iohor Naraht (Star Trek novels), Chwolkk (Star Trek: Titan novels)",
            AttributeModifiers = new CharacterAttributes
            {
                Fitness = 1, Insight = 1, Reason = 1
            },
            TraitDescription = "A Horta is a large amorphous mass of orange-brown silicate biomatter. They are silicon- based life, rather than carbon-based, and difficult for conventional scanners and sensors to detect as life, and an immobile Horta is nearly impossible to distinguish from a pile of rock or rubble. They are non-humanoid, but their bodies are flexible enough to allow them to grasp objects and manipulate tools with pseudopod-like projections, though humanoid tools are not always easy for them to wield. They have poor eyesight, and see mainly in the infrared range, but instead navigate by a vibrational sense and a multispectral olfactory sense that can detect the chemical compositions of objects, gases, and terrain in their vicinity. Horta player characters seldom use more physical tools than are absolutely necessary, as their natural acids risk damaging any objects not specially modified for them. They will still carry a communicator and universal translator.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Silicon-Based Burrower",
                Description = "You are nigh-impervious to harm, having Protection 3, and you can move freely through solid rock with little difficulty (very dense rock might count as difficult terrain). Your acidic secretions give you a melee attack which inflicts Deadly 4 Injuries with the Debilitating and Piercing qualities.",
                ProtectionBonus = 3,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Human,
            Description = new List<string>
            {
                "Originating on the planet Earth in the Sol system, Humans are a hardy and ambitious species, who went from the brink of mutual annihilation to a united peaceful society in less than a century. A century after that, humanity had established itself as part of an interplanetary alliance, the United Federation of Planets, bringing former rivals together as allies. Humans often exhibit a dichotomy in their nature—sometimes strongly emotional and passionate like Klingons or Andorians, yet at others highly analytical and rational like Tellarites or Vulcans—which has allowed them to grow beyond their warlike and fractious past, but their capacity for ambition and aggression are as much a part of their success as their curiosity and analytical minds.",
                "Humans tend to draw upon two sets of cultural values. As a central and founding member of the Federation, the traditions and ideals of the Federation (or even those of Starfleet) are often regarded as synonymous with “Human culture” (though the Federation draws a lot from each of its members), to the point where nobody is entirely sure where Earth ends and the Federation begins. Yet, conversely, this can also lead to Humans finding value in preserving the traditions and cultures of their pre-warp ancestors."
            },
            ExampleCharacters = "Ben Sisko (Deep Space Nine), Kathryn Janeway (Voyager)",
            AttributeModifiers = new CharacterAttributes(),
            ThreeRandomAttributes = true,
            TraitDescription = "Humans are adaptable and resilient, and their resolve and ambition often allow them to resist great hardship and triumph despite great adversity. However, Humans can also be reckless, stubborn, irrational, and unpredictable.",
            SpeciesAbility = _speciesAbilitySelector.GetSpeciesAbility(SpeciesAbilityName.FaithOfTheHeart),
            Weight = 20
        },
        new Species
        {
            Name = SpeciesName.HumanAugment,
            Description = new List<string>
            {
                "While genetic engineering is not a science limited to humanity, Humans have a particular history with genetically engineered people, commonly referred to as Augments. In the latter years of the 20th century or the early years of the 21st century—historical records from this era are patchy and sometimes contradictory—scientists on Earth created a number of Augments with superhuman capabilities: heightened strength, speed, resilience, and intellect. However, these Augments were also notably belligerent, violent, ambitious, and amoral. Seizing power over many nations on Earth, these superhuman tyrants wrought havoc on the world during the Eugenics Wars.",
                "Since that time, Humans have been notably wary of genetic augmentation as a science, and it became illegal on Earth to use genetic engineering to enhance the innate capabilities of a person. This ban would remain law within the Federation upon its founding as well. Officially, Augments and other genetically enhanced people are prohibited from entering Starfleet, but this ban has been challenged, and the civil rights of Augments has been a matter for debate within the Federation for some time, with notable cases such as Chin-Riley v. Starfleet and Bashir v. Starfleet Medical creating exceptions and precedents."
            },
            ExampleCharacters = "Khan Noonien Singh (Star Trek), Julian Bashir (Deep Space Nine), Dal R’El (Prodigy) ",
            AttributeModifiers = new CharacterAttributes(),
            ThreeRandomAttributes = true,
            TraitDescription = "An Augment has had their genetic structure artificially altered in order to enhance specific qualities and abilities they possess. The specifics of these enhancements can vary considerably depending on which qualities the geneticist chooses to enhance. Creating Augments is banned in the Federation, and many organizations refuse to recruit or employ Augments. Because of this, many Augments are created by illicit geneticists, whose methods are often dubious and whose creations can have debilitating side-effects. Most Augments have to hide their altered nature their entire lives. You also have the Human trait.",
            AlternateTraitName = TraitName.Augment,
            SpecificSecondarySpeciesTrait = SpeciesName.Human,
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Genetically Enhanced",
                Description = "You are an Augment. You may select one or two talents which require the Augment trait, which you gain in addition to the normal talents you can select. If you select two of these Augment talents, then you must select an additional trait which represents a severe personality flaw or neurological problem, such as Heightened Aggression, or Sensory Processing Disorder.",
                AddAugmentTalents = true,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Illyrian,
            Description = new List<string>
            {
                "Illyrians are a species native to the region once known as the Delphic Expanse, and Illyria itself was located in the Vaultera Nebula, but they have spread and settled countless colony worlds over the centuries. Illyrians have embraced genetic engineering to adapt their bodies to suit the worlds they settle, as an alternative to terraforming or geoengineering to make worlds habitable. As a result, Illyrians live on many worlds that other species might regard as uninhabitable.",
                "However, while many of their colonies are now within Federation space, they exist in an awkward limbo, as their tendency towards genetic engineering puts them in direct conflict with Federation laws against genetic augmentation. This has left them as outcasts, forced to either undo their genetic enhancements, hide their nature, or live in marginalized communities on the fringes of society. The treatment of Illyrians—and by extension, all genetically enhanced persons—is a matter of controversy and the subject of a long-running civil rights movement.",
                "Due to their engineered nature, Illyrians can vary wildly in appearance, ranging from appearing indistinguishable from Humans, to possessing cranial ridges, brow spines, webbed hands and feet, or a range of other visible or invisible physiological alterations."
            },
            ExampleCharacters = "Una Chin-Riley (Strange New Worlds)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Reason = 1, Presence = 1
            },
            TraitDescription = "Illyrian baseline physiology is fairly close to that of Humans, but few Illyrians match this baseline closely, due to countless generations of divergent genetic engineering to suit different planetary environments or to gain other desired capabilities. Illyrians tend to be secretive due to a history of being outcast or dismissed by Federation races for their enhancements.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Adapt and Excel",
                Description = "You may have the Augment trait. In addition, select a single attribute when you create your character: when you attempt a task using that attribute, you may suffer 1 Stress to reroll a single d20.",
                ChanceForAugmentTrait = 75,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.JemHadar,
            Description = new List<string>
            {
                "An artificial species of reptilian humanoids created by the Founders, who serve as the military of the Dominion. Rather than being born naturally, Jem’Hadar are bred in birthing chambers, and their growth cycle is accelerated such that they reach maturity within three days. It was rare for any Jem’Hadar to live longer than 10 or 15 years, and those over 20 were regarded as honored elders.",
                "Jem’Hadar are engineered to be a perfect warrior species. They have exceptional strength, excellent vision and coordination, and they are extremely resilient to attack. They do not require sleep, and receive all their nourishment from a drug known as ketracel-white, which also contains a necessary isogenic enzyme that their metabolism does not produce. Jem’Hadar received regular doses of “the white” from their Vorta overseers, ensuring their loyalty.",
                "The Jem’Hadar worship the Founders as gods, though few of them had ever actually seen a Founder. Those who had were driven to such a fervid loyalty that they would commit suicide if they allowed a Founder to be harmed. Duty was central to their existence, regarding their lives only as having value as long as they continued to triumph. While some have a personal sense of honor, this is not a major part of their culture."
            },
            ExampleCharacters = "Omet’iklan (Deep Space Nine)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Insight = 1
            },
            TraitDescription = "Jem’Hadar are physically powerful, and far stronger and more resilient than Humans. They have keen eyesight, and act without fear or hesitation in battle. They do not regard death with apprehension, and are aggressive, limited only by their absolute obedience to the Founders and the Vorta.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Perfect Soldier",
                Description = "You are built for warfare. Your Unarmed Strike attacks may inflict Deadly Injuries, and have the Intense quality. Further, you have 1 Protection, and cannot suffer any Stun Injuries. However, you are uncomfortable among other species, and cannot easily empathize or relate to them, adding 1 Difficulty to any task rolls to interact with someone in a peaceful manner unless they are a direct Dominion superior. Finally, you require daily doses of ketracel-white to live: while you have your dose, you recover 4 Stress at the start of each scene, but you cannot rest normally, and each day you do not receive the white, you cannot recover Stress, and you gain the Withdrawal Symptoms trait.",
                ProtectionBonus = 1,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Kellerun,
            Description = new List<string>
            {
                "The Kellerun are a species native to the Alpha Quadrant with a long history of space exploration, but also of conflict. Prior to the late 24th century, the Kellerun were embroiled in a centuries-long conflict with a species from a neighboring system, the T’Lani, which had escalated to the point that deadly nano-biogenic weapons—called the Harvester—were used extensively by both sides, which led to mass casualties. When a tentative peace was finally achieved, both sides sought Federation aid in destroying their stockpiles of the Harvester weapon. Centuries later, the Kellerun faced conflict again, as the territories of the Breen Imperium expanded to claim the Kellerun homeworld as an outpost, stripping it of resources.",
                "The Kellerun themselves are a humanoid species with pointed, ridged ears, but who otherwise appear similar to Humans, Betazoids, or Vulcans. The species’ long history of warfare has resulted in the Kellerun being an intense and determined people, but it would be difficult to class them as a warrior culture in the way the Klingons are. Still, Kellerun culture does encourage a pragmatic attitude, which some might see as ruthlessness, when it comes to eliminating dire threats before they can arise."
            },
            ExampleCharacters = "Ambassador Sharat (Deep Space Nine), Rayner (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Control = 1, Presence = 1
            },
            TraitDescription = "Kellerun are a humanoid species with features and physiology similar to Humans and many other species, aside from ridged and pointed ears. The Kellerun have a reputation for being focused and intense, slow to trust, and even humorless.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Intense Defiance",
                Description = "Your people have endured fierce, brutal conflicts, and cultivated a defiant, pragmatic attitude towards hardship. When you suffer one or more Stress, you may add 1 to Threat to reduce the amount of Stress suffered by 1. Once per mission, when you become Fatigued, you may immediately add 2 Threat to recover 1 Stress.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1, 
            Source = BookSource.SpeciesSourcebook
        },
        new Species 
        { 
            Name = SpeciesName.Kelpien,
            Description = new List<string>
            {
                "A sapient humanoid species indigenous to the planet Kaminar, Kelpiens live in an agrarian society. Elders are the leaders of the Kelpien culture, passing down knowledge and history through stories. One of these stories speaks of the Great Balance, a belief that by culling members of their species, the Kelpiens would have peace with the Ba’ul, a powerful species that would hunt their people to extinction if the Kelpien population got out of hand. This meant that when a Kelpien started going through their physiological change known as Vahar’ai, they would be brought in front of the Watchful Eye and culled, releasing them from the pain and threat of mental instability, as well as maintaining the Great Balance.",
                "In the mid-23rd century, Commander Saru—the first Kelpien in Starfleet—discovered that Vahar’ai was actually a natural physical change that made his people expert hunters. The culling and the Great Balance were both lies forced onto the Kelpiens by the Ba’ul. Eventually, the crew of U.S.S. Discovery helped the Kelpiens rise up against the Ba’ul and break free of the lies they had been told for generations."
            },
            ExampleCharacters = "Saru (Discovery), Su’Kal (Discovery)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Control = 1, Fitness = 1, Insight = 1 
            },
            TraitDescription = "The Kelpiens are a bipedal species adapted to living on land and in the water. Kelpiens are physically stronger than most humanoids, and are able to run at considerable speeds for short bursts and can see into the ultraviolet and infrared spectrums of light. In addition, all Kelpiens have an additional trait: either Pre-Vahar’ai or Post-Vahar’ai. If Pre-Vahar’ai is chosen, you may choose for your character to undergo Vahar’ai (changing the trait) as part of a character arc.",
            RandomSecondaryTrait = { TraitName.PreVaharai, TraitName.PostVaharai },
            SpeciesAbilityBasedOnTrait = new List<(SpeciesAbility, string)>
            {
                (new SpeciesAbility
                {
                    Name = "Prey",
                    Description = "Your physiology is finely tuned to evading pursuit. When you take the Movement minor action, reduce the Momentum cost of crossing difficult terrain by 1. When you take the Sprint major action, you move one additional zone. In addition, you have Threat Ganglia. When the gamemaster spends 3 or more Threat at once, you may add 1 point to the group Momentum pool.",
                    Source = BookSource.SpeciesSourcebook
                }, TraitName.PreVaharai),
                (new SpeciesAbility
                {
                    Name = "Hunter",
                    Description = "Your physiology is finely tuned to running down a quarry. When you take the Movement minor action, reduce the Momentum cost of crossing difficult terrain by 1. When you take the Sprint major action, you move one additional zone. In addition, you have Keratin Darts. You have a natural ranged attack, inflicting a Stun/Deadly 2 Injury.",
                    Source = BookSource.SpeciesSourcebook
                }, TraitName.PostVaharai)
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Klingon,
            Description = new List<string>
            {
                "Klingons are a proud, martial people, native to the planet Qo’noS in the Beta Quadrant. Their tall, strong physiques, sharp teeth, and the distinctive dense crest that runs from their brow, over their heads, and down their spines, all contribute to an appearance that is synonymous with martial prowess and ferocity. Hardy and aggressive, Klingons combine a sense of pride and personal conviction with a fatalistic streak, regarding honorable death to be preferable to what they would deem a shameful or cowardly life.",
                "Klingons embrace life and death alike without fear. They are also a people with a powerful sense of honor, both personal and familial, and they are quick to anger when attacked; the greatest slights can result in generations- long blood feuds."
            },
            ExampleCharacters = "Worf (The Next Generation), B’Elanna Torres (Voyager)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Klingon physiology is hardy, with a reinforced skeleton and many redundant internal organs which allow them to withstand harm and numerous toxins that would be deadly to other species, though this has the potential for medical complications. They are significantly stronger and more resilient than Humans, though they have less tolerance for the cold.",
            SpeciesAbility = _speciesAbilitySelector.GetSpeciesAbility(SpeciesAbilityName.BrakLul),
            Weight = 1
        },
        new Species
        {
            Name = SpeciesName.KlingonQuchHa,
            Description = new List<string>
            {
                "In 2154, a lethal, metagenic strain of the Levodian flu ran rampant through the Klingon Empire, infecting vast numbers of Klingons. Though a cure was eventually devised, the combination of the plague’s metagenic effects and the cure itself led to numerous physiological and genetic changes in those afflicted, most notably the dissolution of their cranial ridges and a number of neurological alterations, to a point where they somewhat resemble Humans, with these changes passed onto the descendants of those afflicted. These altered Klingons came to be known as QuchHa’, “the unhappy ones,” for their seeming deformity, while those who escaped the plague’s effects were commonly referred to as the HemQuch. Though still hardy and vigorous, the QuchHa’ tend to express the customary aggression of their culture as a ruthless cunning, and they are often regarded as less honorable and trustworthy. They join the armed forces and intelligence services in great numbers to prove their worth and gain glory as a result of this discrimination. By the early 2270s, almost all QuchHa’ had undergone corrective treatment to restore their Klingon physiology, and Klingons in later eras refuse to discuss the matter with outsiders.",
            },
            ExampleCharacters = "Arne Darvin (Star Trek), Kras (Star Trek)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Those Klingons affected by this metagenic plague are frequently discriminated against or regarded as cowardly, shameful, or un-Klingon in nature, a stigma that they frequently strive to disprove, or which frees them to take actions that other Klingons may not regard as proper. Their altered genetics leave them less susceptible to a number of diseases and disorders that affect Klingons but allows them to contract a number of Human diseases that Klingons are normally immune to. You also have the Klingon trait.",
            AlternateTraitName = TraitName.QuchHa,
            SpecificSecondarySpeciesTrait = SpeciesName.Klingon,
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Superior Ambition",
                Description = "When you spend Determination, you may add 3 Threat to gain two benefits from spending Determination, instead of 1.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Klowahkan,
            Description = new List<string>
            {
                "The Klowahkans are a species of bird-like humanoids native to the Beta Quadrant planet of Klowahka. Klowahkans have bright plumage in a variety of colors, and they possess the ability to “fluff” their down—the inner layer of fine feathers used for insulation—to bulk up their appearance and appear larger when threatened, though many Klowahkans consider the act to be embarrassing.",
                "Klowahkan culture places considerable emphasis on food, with great worth and status afforded those who live epicurean lifestyles. It is said that the Klowahkans developed warp drive in order to “seek out strange new meals,” and the highest regard is given to chefs, food critics, and others similarly devoted to the culinary arts; consequently, the idea of replicated food is an affront to their way of life. The Klowahkan language is rife with food metaphors, which can often cause communication difficulties (or simply annoyance) when translated to other languages."
            },
            ExampleCharacters = "Dr. Gabers Migleemo (Lower Decks)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Reason = 1, Insight = 1
            },
            TraitDescription = "Klowahkans are an avian humanoid species with bright plumage. Their downy feathers can help keep them warm in cold environments, and can be fluffed up to make themselves look larger when threatened. They have extremely sensitive senses of taste and smell, and have a culture of appreciating fine food, meaning that they have an extremely refined palette, able to discern flavors other species often cannot.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Epicurean",
                Description = "Your sense of smell and taste are highly acute. You can detect things by smell and taste that would not be obvious to creatures of other species, and any task roll you attempt which involves your sense of smell or taste is reduced by 2, to a minimum of 0. Furthermore, if you ever suffer Stress from ingesting food other species might regard as toxic, reduce the amount of Stress suffered by 1, to a minimum of 0.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species 
        { 
            Name = SpeciesName.Ktarian,
            Description = new List<string>
            {
                "The Ktarians are a physically diverse species native to the Federation world of Ktaris. They are a common sight throughout Federation space and are one of the many species that maintains its own fleet of vessels, both merchant and military. The Ktarian fleet is considered to be a reserve force, and can be transferred under Starfleet during times of great need. The Ktarians sent representatives to the original Coalition of Planets talks on Earth that preceded the Federation, but Ktaris did not officially join the Federation until much later.",
                "Unlike most Federation species, the Ktarians are comprised of two separate species that evolved together on Ktaris: one whose brows are bisected into two hemispheres and the other with bone ridges along the center of the forehead. Intermarriage among these two species has resulted in both carrying the traits of the other. Predicting which traits will manifest in offspring is extremely difficult, especially when Ktarians mate with other species. Rumors circulate that the Miradorn are an offshoot of Ktarians, but the reclusive nature of the Miradorn makes this difficult to confirm."
            },
            ExampleCharacters = "Etana Jol (The Next Generation), Greskrendtregk (Voyager), Naomi Wildman (Voyager)",
            AttributeModifiers = new CharacterAttributes 
            { 
                Control = 1, Reason = 1 
            }, 
            OneOfTheseModifiers = new CharacterAttributes 
            { 
                Fitness = 1, Presence = 1 
            },
            TraitDescription = "Ktarians are a hard people, determined and relentless in pursuit of their goals. The intertwining of the two native species has led to the Ktarians possessing the best traits of both. They are physically fit and quick witted—adapting and responding to adversity with ease. They dislike entering any situation where they haven’t managed to secure a significant advantage in advance.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Deep Determination",
                Description = "Ktarians have a well-earned reputation for committing absolutely to their goals, and a single-minded determination to achieve success. Once per mission, when you succeed at a task where you could have spent a point of Determination, but you chose not to, you may spend 3 Momentum to gain a point of Determination.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Kwejian,
            Description = new List<string>
            {
                "The Kwejian are a relatively new species to the galactic community, having achieved warp travel during the 31st century during the desperate aftermath of The Burn; subspace disruptions altered the orbit of the Kwejian moon, causing an ecological disaster on a massive scale. Eventually the Kwejian people were forced to trade with the ruthless capitalist syndicate the Emerald Chain in order to survive. Alas, this would not be the last disaster Kwejian would face: the planet was destroyed in 3190 by a Dark Matter Anomaly later discovered to have been engineered by an unknown species from beyond the edge of the Galaxy. The remaining Kwejian people are scattered refugees.",
                "Kwejian society has a deep spirituality, and a reverence for the natural cycles and balance of their homeworld’s ecosystem, though many had compromised on their culture in the name of survival after The Burn. A major element of their culture was the World Root, a root network that spanned the entire planet prior to its destruction, and which symbolized their ancestry and their bond with their home; a cutting of this root was preserved and persists on another world into the 33rd century.",
                "The Kwejian are relatively few in number, and dwelled within a region of their planet called the Sanctuary, which was hidden from sensors and transporters and shielded from orbital bombardment. In each generation, a few of them would demonstrate an innate empathic ability that allows them to communicate with and influence plants and animals; the manifestation of this trait was regarded as a part of the natural balance of their home."
            },
            ExampleCharacters = "Cleveland Booker V (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Kwejians closely resemble Humans, and have a similar biology, biochemistry, and anatomy. A portion of them possess an innate telempathic ability to communicate with and influence plants and animals, which manifests with a glowing pattern appearing on their foreheads.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Natural Balance",
                Description = "Kwejians are sensitive to the cycles and patterns of the natural world. A Kwejian character may select the Empathy talent (page 155 of the core rulebook). Further, whenever you attempt a task to intuit or understand the nature or behavior of an alien life-form, you may reroll 1d20.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Kzinti,
            Description = new List<string>
            {
                "Kzinti (singular, Kzin) are humanoid felines who typically have orange fur and yellow eyes. With sharp fangs and claws along with ears that resemble the structure of bat wings, Kzinti are amazing hunters and obligate carnivores who regard omnivorous and herbivorous species with disdain. A species with a highly aggressive culture, the Kzinti have waged numerous border wars with neighboring cultures for centuries, including Earth in the decades before the Federation. These conflicts ended with the Treaty of Sirius, forcing the Kzinti Patriarchy to demilitarize aside from limited peacekeeping and law enforcement vessels, though Kzinti privateers remained a problem for centuries after.",
                "The Kzinti largely isolated themselves from the wider Galaxy, but suffered greatly during the Dominion War. With no other options, the Kzinti signed additional treaties with their former enemies, destabilizing their government and causing serious shifts in their culture. This time of societal upheaval also included a female rights movement where their women were no longer thought of as “dumb animals” and began to attain both political and military positions, and a small number of Kzinti have even been seen in the Federation and Klingon Defense Forces. Nevertheless, Kzinti aggression and privateering continue to be a threat to Federation worlds to the end of the 24th century.",
            },
            ExampleCharacters = "Ensign Taylor (Lower Decks)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Kzinti physiology is honed towards making them exceptional predators, and they are tall, powerfully-built beings with multiple hearts, providing them with exceptional endurance during times of stress. As obligate carnivores, they cannot digest plant matter, and it can make them sick. Kzinti possess superior hearing and balance compared to many other species, and a small percentage of their population have limited telepathic capabilities.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Feline Predator",
                Description = "You have retractable claws on your fingertips, useful for hunting. Due to your claws, your unarmed attacks may inflict both Stun and Deadly Injuries. Further, your maximum Stress is increased by 2, and when you attempt a Fitness test, you may suffer 1 Stress to reroll 1d20.",
                StressModifier = 2,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Lanthanite,
            Description = new List<string>
            {
                "Lanthanites are a species who are almost indistinguishable from Humans in every way except one: they appear to be immortal. The origin of the Lanthanite species is unknown, but a group of them are known to have dwelled on Earth for several thousand years, leading some to speculate that they may be an ancient offshoot of humanity who age far more slowly (or who simply do not age beyond a certain point), but this is unconfirmed. They had managed to move among Humans undetected until the 22nd century, and there is little idea of how many live on Earth, as not all have been forthcoming about their nature.",
                "As a consequence of their longevity, Lanthanites tend to accumulate quirks about their behavior. Several known Lanthanites demonstrate a strange accent influenced by numerous ancient cultures and dialects over millennia. Some tend to travel light while others are packrats, both often a response to living lives where even the most stable civilization feels temporary. Many hold on to habits and customs from favorite eras of history. They also tend to have idiosyncratic views on the history they lived through.",
            },
            ExampleCharacters = "Pelia (Strange New Worlds)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Lanthanites are physically almost identical to a Human, though with a lifespan of several thousand years or more. Many were able to live among Humans for millennia, remaining undetected on Earth until the 22nd century. During lifepath character creation, Lanthanite characters always select the Veteran option at Step Five.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Lived Nearly Forever",
                Description = "You’ve lived a very long time, and learned a lot. Up to twice per adventure, you may declare you have an experience or expertise in a particular field; you gain an additional focus when you do this, which remains for the rest of the adventure.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.LiberatedBorg,
            Description = new List<string>
            {
                "The horror of the Borg are the drones, sapient beings who have been assimilated: subjugated by advanced technology into the service of the singular will of the Collective. Countless trillions of people—in some cases entire civilizations—have been enslaved by the Borg in this manner, their individual will, sense of self, and their identity suppressed by cybernetic implants and neurochemical conditioning. Once brought into the Collective, these drones are merely an extension of the whole, visiting that same horror upon any unfortunate enough to cross paths with the Borg.",
                "But over the latter decades of the 24th century, an increasing number of former Borg Drones have been liberated from the Collective. Some escaped by chance, separated from the hive mind by an accident. Others were rescued. More still gained independence during the Unimatrix Zero incident, or found the Collective’s control slipping as it began to suffer defeats. These liberated Borg—also known as Ex-Borg, or XBs—often have a long and painful recovery ahead of them, and they may never fully recover what was taken from them. Some seek to reclaim their original identities, while others are so far removed from who they once were that they must learn how to be individuals all over again."
            },
            ExampleCharacters = "Jean-Luc Picard (The Next Generation), Seven of Nine (Voyager), Hugh (The Next Generation, Picard)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Reason = 1
            },
            TraitDescription = "Due to extensive cybernetic, biochemical, and nanotechnological enhancement, Borg are resistant to adverse environmental conditions such as heat, cold, toxins, ionizing radiation, and even vacuum, though this lessens for liberated Borg who have had some of their implants removed. Even those freed are susceptible to influence from the Collective, and their implants can result in health or psychological problems if they malfunction. Borg must periodically undergo a regeneration cycle to recharge their implants and keep them functioning properly. All Liberated Borg characters are mixed heritage (Core Rulebook, page 99), and should select one (or more) other species: this represents what species (or mix of species) the character was before they were assimilated.",
            AlternateTraitName = TraitName.Borg,
            HasSecondarySpeciesTrait = true,
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Borg Implants",
                Description = "You are a Cyborg, and may select cybernetic talents. Further, you may select one, two, or three of the Borg implants from the sidebar on the next page. Medicine tasks performed on you increase their Difficulty by the number of implants you have chosen, as does the complication range of any tasks related to social interaction. You may remove an implant when you receive a milestone, in addition to any other changes you make to your character.",
                TraitGained = TraitName.Cyborg,
                HasBorgImplants = true,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Lurian,
            Description = new List<string>
            {
                "A race as well known for their fierce martial skills as they are for their artistic endeavors, the Lurians are a power whose homeworld is near the Alpha Quadrant side of the Bajoran wormhole. Though their world is controlled by the Royal Family of Luria, they are a frequent sight at outposts and trading posts, and their skill as navigators and warriors makes them prized members of any crew. With multiple hearts and two stomachs, they require large quantities of food and their religious custom dictates that attendees at a Lurian funeral should bring plenty of food and liquor to see the dead through their journey into the afterlife. Though some Lurians have become involved in criminal endeavors such as the Orion Syndicate, they prefer to make their own way, and it is not uncommon to see lone Lurians happily plying their way through space on another great adventure.",
            },
            ExampleCharacters = "Morn (Deep Space Nine), Grom (Prodigy)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Lurians are a passionate people, and never do anything by half measure. Whether it is by devoting themselves to the arts or by trying to become the greatest pilots in the Galaxy, the Lurians live with their emotions on their sleeves despite their normally impassive facial features. Lurians are always great thinkers and dreamers, and even though they may sometimes appear quiet, their minds are often on important matters and on formulating plans for their futures. They take great satisfaction in the sharing of ideas, opinions, and stories.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Resistant Anatomy",
                Description = "Lurians are known for having an extremely hardy constitution. Capable of taking a knife to one of their hearts and keep fighting, Lurians have evolved a physiology that rivals even the redundant anatomy of the Klingons. Lurians have Protection 1 against all attacks, which increases to 2 against Stun Attacks, and you may suffer 1 Stress to ignore any effects or traits caused by toxins, drugs, or poisons. Further, the first time in an adventure you’re Defeated, you may immediately recover from being Defeated, though you still have whatever Injury caused you to become Defeated.",
                ProtectionBonus = 1,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Medusan,
            Description = new List<string>
            {
                "Medusans are a telepathic non-corporeal species with similar drive to explore and understand the universe to many Federation cultures. Their minds and thought processes are considered by other telepathic species to have a sublime elegance and beauty, yet their appearance— an amorphous mass of coherent electromagnetic energy—is anathema to corporeal life, and looking upon a Medusan without protection causes a severe neurological disruption, resulting in madness and potentially even death (though some species demonstrate a limited resistance, and telepaths are more resistant in general to this effect).",
                "In their natural state, Medusans gather together and telepathically bond into hive minds, but they are fully capable of leaving a hive mind to travel alone. Among corporeal life, Medusans tend to use a carrier pod or containment suit to travel, hiding their physical appearance; they dislike doing this, as it feels lonely and isolating to exist in this way. Medusans have a deep appreciation for beauty, which they express through a fascination for art—especially the art of other cultures— but also through a deep understanding of physics and mathematics so that they can better appreciate the natural beauty of the universe. Their incompatibility with corporeal species is the main thing that limits their exploration: Medusans are pacifistic, and do not wish to cause harm, but they’re all too aware of how dangerous their presence is to others. Thus, few Medusans leave the safety and comfort of their hive minds to move alone among other people."
            },
            ExampleCharacters = "Kollos (Star Trek), Zero (Prodigy)",
            AttributeModifiers = new CharacterAttributes
            {
                Reason = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Medusans are non-corporeal beings composed of coherent electromagnetic energy. As incorporeal beings, they have no physical body, are genderless, do not age, and are immune to most biological hazards such as toxins, diseases, heat, cold, and suffocation. Medusans are potent telepaths, and can communicate by projecting their thoughts into the minds of other beings nearby. The electromagnetic form of a Medusan allows them to physically interact with objects in close proximity using magnetic fields, but it also emits wavelengths of EM radiation that can induce severe neurological disruption in corporeal beings who see them.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Sublime Mind, Hideous Form",
                Description = "You have no physical form, but your mind is powerful indeed. You have the Telepathy and Telepathic Projection talents (both on page 156 of the core rulebook). However, corporeal beings who see your form immediately suffer a Deadly 5 Injury with the Debilitating and Piercing qualities (intentionally exposing your form in order to do harm adds 1 Threat per creature that would be affected) unless they’re wearing a protective visor. Telepathic species count the Severity of this injury to 3. Injuries you suffer represent disruptions to your electromagnetic matrix. When living among other species, you are assumed to dwell within a containment pod, which must be carried around by another character.",
                AddTalents = new List<string> { TalentName.Telepathy, TalentName.TelepathicProjection },
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Nanokin,
            Description = new List<string>
            {
                "Nanokin are a rare example of a near-microscopic sapient species. They typically do not interact with the “behemoths,” as they call humanoid creatures, as they exist on an entirely different scale, though they are known to scavenge materials and technology. They reproduce in extremely large numbers, with hundreds of thousands of hatchlings to each brood. Nanokin have extremely volatile emotions, which can cause them to act in erratic or eccentric ways by Human standards. Nanokin are a rare species where first contact was by operatives of Section 31 rather than Starfleet, though this was by accident, as a colony—mistakenly identified as some kind of biological infestation—of Nanokin was discovered on a derelict ship in the late 23rd century.",
                "On the rare occasion they do need to interact with humanoid life, they do so by piloting android suits called conveyances. Conveyances, especially black-market ones, can be extremely lifelike, and they are difficult to discern as artificial. A Nanokin can depart from their conveyance in a near-microscopic backup vehicle able to fly short distances from the conveyance, leaving the conveyance to operate on autopilot while they range around. Given their small size, this backup vehicle can fit into extremely small spaces, including the inner workings of technology, and it is nearly impossible to spot without technological means."
            },
            ExampleCharacters = "Fuzz (Section 31)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "These creatures are extremely small, almost on the scale of microbes, and can only meaningfully interact with humanoid creatures via technology, such as their conveyances, communicators, and so forth. Their physiology is wildly different to that of humanoids, but it allows them—in appropriate craft—to circumvent most barriers or conceal themselves from any search. Nanokin characters also have the trait Conveyance: a conveyance is a piloted android that allows a Nanokin to move among and interact with humanoid life. These all have the same capabilities as a normal Human or similar humanoid being, though they are technological rather than organic. A Nanokin can use a small craft (barely a few millimeters across) to exit its conveyance, leaving the conveyance on autopilot.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Tiny Being in a Lifelike Android",
                Description = "While in your conveyance, you may act freely as if you were any other character. When you leave your conveyance, you cannot be seen with the naked eye, and attacks against you automatically fail. While away from your conveyance, it operates on autopilot, and it cannot attempt any action which requires a task roll with a Difficulty of 1 or higher.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Nausicaan,
            Description = new List<string>
            {
                "Nausicaans are a belligerent species native to the Beta Quadrant world of Nausicaa, and with territories spreading into the Alpha Quadrant. Nausicaan civilization has a long and storied history, whose ancestors had access to advanced technology, but by the 22nd century, they were mainly known as pirates and mercenaries, with little or no stable central government: indeed, Vulcan High Command regarded the Nausicaan government as being “in a state of constant transition.” Little has changed since.",
                "The Nausicaans themselves are tall, powerfully built humanoids with prominent bony ridges across their faces, with sharp tusks framing their mouths. Some also have rows of small horns running along their cranial ridges. Their culture tends towards anarchy, with the only consistent social structures being extended family groups dominated by the strongest and most domineering family members. Nausicaans believe that the strong should prosper and those weaker survive by doing as the strong command. Interactions with others tend to involve a lot of bragging, one-upmanship, and bravado, which can turn into “friendly” violence which seldom results in lasting injury."
            },
            ExampleCharacters = "Zon (The Next Generation)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Nausicaans are a tall, very strong species hailing from Nausicaa. They are generally stronger than an average Human, and more direct in their thinking, preferring brute force over finesse and direct methods as opposed to subtlety. They have little patience for organized forms of government, though they will tolerate following a captain for as long as that captain earns their capricious loyalty. Nausicaans are somewhat resistant to pain and injury, and almost never back down from a challenge, especially when it involves games that carry the potential for serious bodily harm to themselves or their opponents.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Brute Force",
                Description = "You are tall, strong, and have little patience for subtlety or nuance. When you attempt a melee attack or a Fitness-based task roll to break or force your way through an obstacle or other problem, you may reroll 1d20, and you score 1 bonus Momentum if the task succeeds. Bonus Momentum cannot be saved. You have +1 Protection against Stun Attacks.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Ocampa,
            Description = new List<string>
            {
                "An oddity for humanoid species, the Ocampa are an extremely short-lived people. For nearly all of Ocampan history, they have been under the protective watch of the Caretaker—a member of an extremely powerful extra-galactic civilization. At some point in the distant past, the Caretaker was responsible for rendering the Ocampan homeworld nearly uninhabitable. To attempt to atone for this act, the Caretaker then spent the following centuries ensuring the Ocampan people had everything they could need. This relationship continued until the Caretaker’s death—and as a final act, the powerful being provided the Ocampans with sufficient energy reserves to hold out for another several years at best.",
                "While, physically, they are nearly identical to Humans, Ocampan physiology is radically different. The Ocampa only live to be roughly 10 standard years old—though this can be extended significantly through advanced medical technologies. Much like insects, Ocampa development proceeds through a series of stages: alternating periods of stability and rapid aging. Newborn Ocampans remain in a childlike stage for a brief year before rapidly aging and growing into pseudo-adulthood. Following this, they remain in this stage for another few years before reaching sexual maturity, a stage that lasts only a few months before fading. After this, Ocampans gradually continue to age through their adulthood before undergoing one final rapid development stage that marks their twilight. Once this occurs, Ocampa can expect to live for no more than a year or two before expiring.",
                "Interestingly, Ocampa possess powerful, latent telepathic abilities that appear to have become long since dormant. If allowed, or nurtured, into development, these abilities range from simple forms of empathy and telepathy to more powerful and advanced forms of precognition and even telekinesis. The full range and capability of these talents has yet to be fully determined."
            },
            ExampleCharacters = "Kes (Voyager)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Ocampa development is more closely akin to that of insects than to Humans. Long-time support, provided by the enigmatic Caretaker, has left the species in somewhat of a socially stunted state, and their society has since become entirely dependent upon the services the Caretaker provided. When separated from this welfare state, Ocampa are curious and studious learners, voraciously devouring information with incredible speed. They are capable of truly astounding psychic feats, though few develop these abilities.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Extraordinary Mind",
                Description = "Your mind can assimilate new information swiftly, allowing you to gain knowledge and understand techniques quickly. The first time each scene that you Obtain Information after succeeding at a task roll which used   one of your focuses, that use of Obtain Information is free. In addition, you may purchase talents from the Esoteric Talents list on page 155 of the core rulebook.",
                CanTakeEsotericTalents = true,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Orion,
            Description = new List<string>
            {
                "A species with a colorful reputation, the Orions are subject to rumor, speculation, and flights of fancy, to the point where there are numerous common misconceptions about their species and culture. This seems to be at least partially by design. Orions are accustomed to taking full advantage of any opportunity that passes their way, and the uncertainty and misdirection that surrounds them is a considerable advantage. The influence of Orion traders and the Orion Syndicate can be felt across the Alpha and Beta Quadrants, often in ways that flout the laws of other cultures, and often employing agents of other species.",
                "Orion culture appears to be divided along gender lines, and there is evidence to suggest they have a broadly matriarchal culture, with the women serving in leadership roles, while Orion males more often serving as muscle, laborers, and minor operatives, though this has shifted somewhat over the centuries. This appears to be due to a trait of some Orion females, who have been observed to produce pheromones that can make male Orions (and males of some other species, including Humans) compliant. It isn’t known how widespread this trait is."
            },
            ExampleCharacters= "D’Vana Tendi (Lower Decks), Osyraa (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Orions have similar environmental tolerances to Humans and are physically and culturally well-accustomed to interstellar travel. The Orions’ reputation as thieves, pirates, and illicit traders can make others wary of them, but it can also open doors and create opportunities in more unsavory parts of the Galaxy.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Never at Face Value",
                Description = "Once per scene, you may add 1 Threat to ask the gamemaster a question about the situation, as if you had spent Momentum to Obtain Information."
            },
            Weight = 1
        },
        new Species
        {
            Name = SpeciesName.OrionBlue,
            Description = new List<string>
            {
                "A relatively rare, blue-skinned subset of Orions, Blue Orions (who pronounce their species’ name as Or-eeon) represent a minority among the Orion people, largely represented in the Orion Syndicate by House Azure. Unlike the majority green Orions, Blue Orions have a more patriarchal culture, and are generally more uniform and conformist in their behavior. They’re often mocked and derided by the majority Orion culture.",
            },
            ExampleCharacters= "K’Levin (Lower Decks)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Presence = 1
            },
            TraitDescription = "Blue Orions are very similar to the majority of the Orion species, and the largest physical difference is their skin pigmentation. The other differences between the green Orion majority and the Blue Orions are cultural, with the Blue Orions cleaving more strongly to traditions and a narrower definition of “acceptable” pirate behaviors. They are commonly disrespected by other Orions, and have a strong sense of solidarity. You also have the Orion trait (core rulebook, page 109).",
            AlternateTraitName = TraitName.BlueOrion,
            SpecificSecondarySpeciesTrait = SpeciesName.Orion,
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Honor Among Thieves",
                Description = "When an ally attempts to lie, cheat, or steal from an enemy, you may spend 1 Momentum (Immediate) to assist that task roll automatically, by providing a lookout, or distracting the enemy, or otherwise trying to give your ally a better opportunity. Your assistance does not require you to take an action or prevent you doing anything else: you’re accustomed to covering your allies’ illicit ventures out of habit and reflex.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Osnullus,
            Description = new List<string>
            {
                "The Osnullus hail from a homeworld that has only recently begun to shed their caste-based society. Once beholden biologically to queens who governed their individual colonies, Osnullus evolved to a stage where they are more independent minded and are capable of breaking away from their colonies. Though some still prefer to cling to the castes of their births, the Osnullus have embraced independence and the concept of the individual.",
                "Since joining Starfleet, the Osnullus can now be seen across the Alpha Quadrant where they embrace the close communities of their starships as new colonies for them to live in. Some species find the Osnullus method of eating to be disturbing, as their lack of mouths means they absorb their food through specialized feeding ports within their fingers."
            },
            ExampleCharacters= "Rahma (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Reason = 1
            },
            TraitDescription = "The Osnullus exemplify being at peace with themselves and with others. They are able to notice changes in the behavior of their friends and crewmates while also being able to exist on their own. The Osnullus prize their independence and there is nothing more abhorrent to them than the subjugation of others against their will. They see working toward the same goal as something that others should strive for, but being coerced into doing so makes them want to rebel against it.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Unreadable Face",
                Description = "While Osnullus can look at each other’s faces and tell what they are thinking, it is more difficult for other species to do so. This natural trait gives them an advantage when it comes to treachery and deceit. On any task to try to mislead or lie to a member of another species, the first bonus d20 is free.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Pakled,
            Description = new List<string>
            {
                "Pakleds are solidly built, bipedal humanoids with a robust physiology, characterized by a blunt, straightforward, even simplistic approach to life. Pakled culture places emphasis upon strength, directness, and overcoming any obstacles or challenges in their path, and they have little time for subtlety or nuance. While these attitudes have sometimes made the Pakleds the subject of ridicule, the Pakleds themselves seem impervious to shame, and will stop at nothing to achieve the respect— and if necessary, the fear—of anyone they encounter.",
                "Pakleds tend to approach problems with a mixture of brute force and intuition, favoring instinct over logical reasoning. They’ve demonstrated an adeptness for adopting and combining the technologies of other cultures, often through intense trial and error. Pakleds have little fear of failure, and are willing to meet catastrophe time and time again if it eventually leads them to triumph."
            },
            ExampleCharacters= "Grebnedlog (The Next Generation), Rebner (Lower Decks)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Insight = 1
            },
            TraitDescription = "Pakleds have an incredibly resilient physiology, allowing them to resist extremes of temperature or other inhospitable environments, and even endure exposure to hard vacuum for short periods of time with minimal consequences. They have a poor reputation among many other cultures, and are often underestimated.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Straightforward",
                Description = "A Pakled gains +1 Protection against Stun Attacks, and their Maximum Stress is equal to their Fitness +3.",
                StressModifier = 3,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Reman,
            Description = new List<string>
            {
                "Remans are a nocturnal species subjugated by the Romulan Star Empire, hailing from Romulus’ twin world of Remus. Little is known about the Remans outside of the Romulan Empire, due mainly to the Romulans’ secrecy, but some have speculated that they may be a mutant offshoot of early Romulan settlers, their genetics altered over generations by experimentation or contact with micro-organisms native to Remus. The truth is unknown. During the height of the Romulan Empire, Remans were enslaved and forced to toil in the dilithium mines of their homeworld. However, they were also regarded as great warriors, and select Remans often found employment as bodyguards for important Romulan figures, including senators, while others have been employed as expendable shock troops for boarding actions and ground assaults during wars against the Klingons and later, during the Dominion War.",
                "The Remans attempted a coup against the Romulan government in 2379, which would have spilled out into a wider conflict against other Beta Quadrant powers had it not been stopped by Federation involvement. However, while the coup was put down, the Remans would not return quietly to a state of servitude, despite nearly two years of skirmishes and blockades between the Romulans and the Remans. Eventually, however, the Romulans were forced to concede to demands for Reman emancipation simply because of how vital mining on Remus was to Romulan interests. While they were still second-class citizens, the newly freed Remans began to spread across the Empire, some seeking to leave to try their luck outside the Romulan Star Empire, while others sought employment in the mining guilds, as mercenaries, or seeking glory in the military.",
                "The threat of the Romulan supernova changed things considerably. Efforts to evacuate the Romulan system were made, but politics meant that Remans were lower priority for evacuation. When Federation aid for the evacuation disappeared, only those Remans who had already left their home system by themselves were spared, and Remans were pushed to the brink of extinction."
            },
            ExampleCharacters= "Vkruk (Star Trek: Nemesis), Obisek (Star Trek Online)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Insight = 1
            },
            TraitDescription = "Remans are tall, powerfully built beings, stronger and more durable even than Romulans. Their nocturnal nature means that they cannot easily tolerate bright light. Some Remans have telepathic abilities, allowing them to read the minds of others and to project their thoughts to others, though using these powers effectively takes skill and training.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Born to the Dark",
                Description = "You are nocturnal and have keen night vision: you may ignore the effects of any trait relating to low light or darkness, but any penalties suffered from traits caused by bright light are increased as if those traits had +1 Potency. Your tolerance for extreme exertion means your maximum Stress is increased by 2. Finally, you may select the Telepathy and Telepathic Projection talents (both on page 156 of the core rulebook). As subjects of the Romulan Star Empire, Remans may also purchase Romulan species talents.",
                CountAsSpeciesForTalents = SpeciesName.Romulan,
                CanTakeSpecificEsotericTalents = { TalentName.Telepathy, TalentName.TelepathicProjection },
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.RigellianChelon,
            Description = new List<string>
            {
                "Chelons—also called Chelarians—are a hardy, semi-aquatic species from Beta Rigel III, sharing their home solar system of Beta Rigel with Rigellian Jelna. They are descendants of saber-toothed turtles and, though bipedal, they have retained their ancestral beaks, claws, and hard shells. Chelons have only a single sex, and take on masculine or feminine gender roles temporarily at varying points in their lives, reproducing like most reptilians by laying eggs and fertilizing those eggs. Some traditionalists within Chelon society maintain a neutral gender, and refuse to take on male or female roles.  ",
            },
            ExampleCharacters= "Simmerith (Star Trek: Destiny novels), Jetanien (Star Trek: Vanguard novels)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Insight = 1
            },
            TraitDescription = "The Chelon species retains many characteristics from its ancestral species, a type of sabertoothed turtle. They have beaks, and a strong (if clumsy) bite; some have trained to use this in close-quarters combat. During times of stress or physical combat, they also emit a deadly toxin through their skin. This can be used with their claws so that the toxin reaches an opponent’s blood. They are skilled swimmers and prefer a warm, humid climate. They are also resistant to ultraviolet radiation and, to a lesser extent, other radioactivity. This is probably due to the shells that extend over much their bodies.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Atavistic Defenses",
                Description = "Your biology contains a number of physiological defense mechanisms inherited from your ancestral species. Your shell gives you Protection 1, and means you may ignore the negative effects of traits that represent dangerous radiation. Further, your beak and natural toxins mean that your unarmed attacks inflict Stun/Deadly 3 Injuries with the Debilitating quality.",
                ProtectionBonus = 1,
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.RigellianJelna,
            Description = new List<string>
            {
                "The Jelna are natives of the Rigel system, coming from Beta Rigel V. A diligent and hard-working species, the Jelna were the first Rigellians to engage in space flight. Although they took to commerce and systemwide government quicker than the Chelon, the Jelna weren’t aggressive, and they made sure there was democratic representation for all Rigellian species on the Governing Board and the Rigellian Trade Commission. The humanoid Jelnas have four sexes: exomale, endomale, exofemale, and endofemale. The exomales and exofemales— collectively the exosexes—contain an additional Z chromosome, and they outnumber the endosexes two to one. Exosexes are the more aggressive and hardy members of the species, while the endosexes— endomale and endofemale—tend to be more circumspect and subtle.",
            },
            ExampleCharacters = "Beljo Tweekle (Lower Decks) ",
            AttributeModifiers = new CharacterAttributes
            {
                Fitness = 1, Presence = 1, Reason = 1
            },
            TraitDescription = "The Jelna of Beta Rigel V evolved along similar lines to most humanoids, aside from their four sexes. The two endosexes—endomale and endofemale— are comparable to other humanoids, while the two exosexes—exomale and exofemale—possess a more robust physique and aggressive tendencies. Endosexes have exclusively gray skin and red eyes and are more suited to nurture and care; exosexes have a pale brown complexion.",
            RandomSecondaryTrait = { TraitName.Endosex, TraitName.Exosex },
            SpeciesAbilityBasedOnTrait = new List<(SpeciesAbility, string)>
            {
                (new SpeciesAbility
                {
                    Name = "Divergent Physiology (Endosex)",
                    Description = "Whenever you attempt a task using Insight or Reason, the first d20 you purchase is free, and you gain 1 bonus Momentum on a successful task. Bonus Momentum cannot be saved.",
                    Source = BookSource.SpeciesSourcebook
                }, TraitName.Endosex),
                (new SpeciesAbility
                {
                    Name = "Divergent Physiology (Exosex)",
                    Description = "Whenever you attempt a task using Daring or Fitness, the first d20 you purchase is free, and you gain 1 bonus Momentum on a successful task. Bonus Momentum cannot be saved.",
                    Source = BookSource.SpeciesSourcebook
                }, TraitName.Exosex)
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Risian,
            Description = new List<string>
            {
                "Risa was a planet of fierce storms and tectonic instability before the Risians took it upon themselves to essentially terraform their planet. It is now colloquially known throughout the Federation as a “pleasure planet.” It’s a wonder the Risians evolved into the ceremonial society they have today, with tradition and ceremony being central to Risa society.",
                "Risians have an honest and open attitude to sexuality, renowned throughout the Galaxy. Potential mates with a sexual appetite display ceremonial icons, called a horga’hn, that invite partners to participate in the sexual rite jamaharon. However, despite the Risian reputation for hedonism, they are deeply concerned with consent and are extremely generous; Risian hosts are noted for their diligence in providing a good experience for vacationers."
            },
            ExampleCharacters= "Arandis (Deep Space Nine), Ruon Tarka (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "Risians appear much like Humans, save a decorative cultural marking—a ja’risia—in the center of the forehead, which is either a worn decoration or a tattooed mark. Despite this superficial similarity, their internal physiology is significantly different from that of Humans, to the point where many medical techniques usable on Humans do not work on Risians, and vice-versa. Among the differences, Risians live longer than Humans, and age more slowly. They have open and adventurous personalities but also have a great patience with others.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Clarity in Peace",
                Description = "Your demeanor and presence help others reach a clear-minded state where they can be at their best. When an ally spends Determination, and you are present in the scene, both you and that ally may immediately recover 2 Stress each.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Romulan,
            Description = new List<string>
            {
                "A divergent offshoot of the Vulcan species, Romulans fled their original homeworld millennia ago. These Vulcans, “those who marched beneath the Raptor’s wings,” refused to accept the teachings of Surak, and thus did not embrace logic or stoicism, and eventually their ships would reach the worlds known as Romulus and Remus. Much of what is known about the Romulans has been pieced together from secondary and tertiary sources, as the Romulans themselves are secretive bordering on paranoia and do not disclose any information about themselves unless they deem it vital. Indeed, the Federation didn’t even know what Romulans looked like until a century after the Earth-Romulan War.",
                "To the Romulans, trust is something to be placed in only a few, for misplaced trust can be a deadly weapon. A Romulan trusts only their closest family members, and places increasing layers of secrecy, obfuscation, and misdirection as relationships grow more distant. There are exceptions to this, such as the scrupulously candid order Qowat Milat, but most Romulans are highly guarded and suspicious of everyone."
            },
            ExampleCharacters = "Elnor (Picard), T’Rul (Deep Space Nine)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Reason = 1
            },
            TraitDescription = "Romulan physiology is like that of Vulcans, but subtly different in a variety of ways, enough to cause difficulties in using medical techniques designed for Vulcans, and enough that, with difficulty, sensors can distinguish between Vulcan and Romulan life-signs. Psychologically and culturally, Romulans prize cunning and strength of will, and are highly distrustful of outsiders. Romulans have a reputation for manipulation, deception, and betrayal.",
            SpeciesAbility = _speciesAbilitySelector.GetSpeciesAbility(SpeciesAbilityName.Paranoia),
            Weight = 0
        },
        new Species
        {
            Name = SpeciesName.Saurian,
            Description = new List<string>
            {
                "The Saurians were acquainted with humanity by the mid-22nd century, and joined the Federation in the mid-23rd century, but it took them some time to adjust to the norms of being aboard Federation starships. With their native language being a series of clicks, chirps, and growls, older versions of the universal translator sometimes had problems translating Saurian speech into Federation Standard. They are a physically imposing species, with a heightened sense of smell and large eyes capable of seeing long distances.",
                "Saurians are welcome additions to landing parties and away teams because of their ability to be resourceful in almost any environment. Their culture stresses prudence and consideration in all things, though if a Saurian is pushed into conflict, they will respond ferociously. Saurians are omnivores, and frequently enjoy meals consisting of bamboo, fish, and dried insect casings. Saurians reproduce asexually and do not have sexual dimorphism or gender roles—with any of them capable of laying clutches of eggs at certain points in their adult lives—but some Saurians will, when among gendered species, adopt some aspects of a gender presentation for convenience or because they find the idea interesting."
            },
            ExampleCharacters= "Linus (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Daring = 1, Fitness = 1, Reason = 1
            },
            TraitDescription = "Saurians possess enhanced senses that are often superior to their colleagues. With six nasal canals, they can pick up scents from kilometers away and their sharp fangs and claws make them imposing. As a civilization, they respect strength and decisiveness but prefer to avoid aggression if at all possible. Saurians also possess a high tolerance for alcohol, and Saurian brandy is prized throughout the Alpha and Beta Quadrants.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Superior Metabolism",
                Description = "Your biology allows you to process toxins at a much higher rate than other species. Whenever you are exposed to a toxic substance, you may immediately suffer 1 or more Stress to shrug off the effects quickly. Most common toxins can be shrugged off with 1 Stress, but the gamemaster may rule that especially potent toxins require more Stress. In addition, your natural claws mean that your Unarmed Strikes can inflict Stun or Deadly Injuries.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 2,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Sona,
            Description = new List<string>
            {
                "The Son’a are a minor player in the Alpha Quadrant, but one which shot to some prominence after siding with the Dominion during the Dominion War. The Son’a are unique in that they are an offshoot of the Ba’ku, a race of beings hailing from a planet in the sector of space known as the Briar Patch. They are a race of conquerors who had subjugated several neighboring systems into their small but powerful empire, and they were not afraid to employ weaponry such as isolytic subspace weapons which were so deadly they tore holes in subspace to release devastating waves of energy. Their use of enslaved labor and illegal genetic tampering meant the Federation could not initiate trade with them, although a rogue Starfleet admiral was caught offering the Son’a assistance with a plot to drain their homeworld of its metaphasic radiation.",
                "Although some Son’a returned to their homeworld to try to start over, a large number of their race refused to give up the wealth and territory gained when they allied themselves with the Dominion during the war. Although they made up a small portion of the Dominion’s armed forces, the Son’a are technologically sophisticated, and they make for powerful foes. In the years since the Dominion War and their conflict with the Ba’ku, many Son’a have developed a grudge against the Federation, viewing Starfleet to blame for their lost chance at immortality. Some Son’a refuse to join in their species’ vendetta against the Federation, and instead travel as traders of illicit goods; siding with the Dominion during the war means few other cultures have much goodwill for the scattered Son’a."
            },
            ExampleCharacters= "Adhar Ru’afo (Star Trek: Insurrection)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Daring = 1, Insight = 1
            },
            TraitDescription = "The Son’a were once similar to Humans in appearance but centuries of exile from their homeworld has led them to experiment upon themselves to stay alive. Older Son’a spend several hours each day undergoing extensive surgical, chemical, and genetic treatments in order to prolong their lives. Most Son’a can be described as possessing a stretched appearance to their faces, while others develop painful lesions along their body. Son’a children, who are almost never permitted to leave their homeworld, are similar in appearance to the Ba’ku but possess pale skin.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "At All Costs",
                Description = "Though a small power in the region, the Son’a have not become one of the dominant powers in the Briar Patch by engaging in half measures or pulling their punches. When you succeed at a Deadly Attack, you score 1 bonus Momentum. Bonus Momentum may not be saved.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.SoongTypeAndroid,
            Description = new List<string>
            {
                "Synthetic humanoids—commonly referred to as androids or synths—have been produced by many civilizations throughout the Galaxy, demonstrated by the partly understood remnants of ancient civilizations. In the 24th century, the Human scientist Noonien Soong sought to develop fully sapient androids using a positronic brain, and eventually found success, creating the androids Data and Lore. While Lore was deeply misanthropic and eventually had to be deactivated, Data became a celebrated and renowned Starfleet officer and a pioneer in cybernetics in his own right.",
                "Soong’s son Altan, along with Starfleet cyberneticist Bruce Maddox, built on theories developed by Data that would allow them to create new androids from positronic neurons taken from Data’s brain, refining the technology to where they could be created from synthetic organic tissues, making them nearly indistinguishable from Humans. These Coppelius androids—named for the planet where they were created—were discovered and their homeworld accepted as a protectorate of the Federation in 2399."
            },
            ExampleCharacters = "Data (The Next Generation), Soji Asha (Picard), Fred (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Reason = 1
            },
            TraitDescription = "The physical and mental capabilities of an android are enhanced compared to that of many organic or cybernetic life-forms. They are highly resistant to the effects of hard vacuum, disease, radiation, suffocation, toxins, and telepathy. Some environmental conditions, such as highly ionized atmospheres, intense electromagnetic discharges, and the like can have a severe effect. The legal personhood of androids has been a controversial matter, and many people look on androids with suspicion or doubt.",
            SpeciesAbility = _speciesAbilitySelector.GetSpeciesAbility(SpeciesAbilityName.SyntheticLifeForm),
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Talaxian,
            Description = new List<string>
            {
                "Resilient and reliable, the Talaxians became one of the most widely recognizable and dispersed species in the Delta Quadrant. Talaxians have been warp capable for millennia, and during this time they encountered countless species and traveled to nearly all corners of their quadrant. Talaxians have a reputation for being sociable, good-natured travelers who enjoy the company of others. Unlike other species that have been warp capable for such an extended time, Talaxians are not known for their technological capabilities, which can vary wildly from group to group. Like many species in the quadrant, Talaxians do not boast a significant military presence or a large empire, though this may be due to the war between them and the Haakonian Order—a conflict that left both sides exhausted. Unfortunately, the war ended with the surrender of the Talaxian government following the detonation of a weapon of mass destruction on a Talaxian moon.",
                "The trauma suffered by the Talaxian people during the war resulted in a large number of Talaxian refugees seeking safety beyond Talaxian space. Further, most Talaxians seek to avoid confrontation if possible and may even flee from a determined foe. The Talaxians are not, however, cowardly by nature, and when left with no alternative they can display great levels of courage and heroism. This avoidance of physical confrontation does not, however, spill over into their social dealings, as Talaxians are rarely fearful of speaking their mind when offended or upset. Talaxians enjoy good food and good company, and many consider themselves superb culinary experts—though their associates may argue otherwise."
            },
            ExampleCharacters = "Neelix (Voyager)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "While humanoid in most respects, Talaxians do have several interesting biological adaptations. First and foremost, Talaxians are capable of enduring heat well beyond what the average Human can comfortably tolerate and can endure much longer without water. Talaxian skulls have much more pronounced ridges where the plates meet. Talaxian hair tends to be thin and wispy, and large portions of their heads are bald to allow for greater cooling. Talaxian sight is a touch less refined than that of a Human, though their senses of taste and smell are much keener.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Widely Traveled",
                Description = "Having traveled through space for most of your adult life, you’ve seen much and picked up esoteric knowledge and unusual skills along the way. Once per mission, when attempting a task for which none of your focuses apply, you may declare that you have an applicable focus. This remains for the rest of the adventure.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 0,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Tamarian,
            Description = new List<string>
            {
                "The Children of Tama, also known as Tamarians, are bipedal humanoids with long nostrils and ear holes on the sides of their heads. A bony ridge runs from the top of their nose and over the top of their heads. Two smaller ridges usually run along the side of their heads, over their ear holes. Tamarians are hairless and have thick, milky-white blood. Their thumbs are long in proportion to the rest of their fingers and have a sucker-like tip on the end.",
                "Tamarians have a complex language that uses historical and mythological metaphors to describe their feelings and to explain their actions. This language shows a tremendous connection to the stories and actions of their ancestors. In addition, Tamarians participate in sleeping rituals and death rituals that pay homage to their ancestors. These rituals include objects that Tamarians carry with them, including a ceremonial dagger."
            },
            ExampleCharacters = "Dathon (The Next Generation), Kayshon (Lower Decks)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Insight = 1, Presence = 1
            },
            TraitDescription = "The Children of Tama are solid, sturdy humanoids with thick skin that tends towards shades of orange or ochre, with red or red-brown markings. They are most notable for their distinctive form of communication, which relies on idiom and metaphor to an extreme degree, even compared to many other known languages. The sucker-like tip of their thumbs gives them a particularly secure grip, especially on objects of Tamarian design.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Sokath, His Eyes Uncovered",
                Description = "You derive wisdom and understanding from the lessons and stories of the past. When you make a reference to a previous use of one of your values, you may also add 1 Momentum to the group pool.",
                Source = BookSource.SpeciesSourcebook
            },
            Weight = 1,
            Source = BookSource.SpeciesSourcebook
        },
        new Species
        {
            Name = SpeciesName.Tellarite,
            Description = new List<string>
            {
                "The stubborn, argumentative Tellarite species originated upon Tellar Prime, a temperate planet in the Alpha Quadrant. Their bodies are thick-set and covered in dense hair, and they stand a little shorter than Humans on average. Many male Tellarites possess tusks to some degree, though they vary in size and prominence.",
                "Tellarites are known to be highly argumentative, even rude by the standards of other cultures, often complaining frequently or insulting others as part of social interactions. In truth, this comes from a sense of intellectual honesty and rigorous skepticism. To a Tellarite, no idea, concept or person is beyond challenge or analysis, and any notion that cannot stand up to scrutiny is an unworthy one. Tellarites revel in debates, and enjoy arguing, and the criticisms, complaints, and insults issued during conversations are intended to be met in kind: to do otherwise is to display a weak character, an inability to stand up for oneself, or an unwillingness to confront one’s own flaws."
            },
            ExampleCharacters= "Jankom Pog (Prodigy), Zus Tlaggul (Strange New Worlds)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Insight = 1
            },
            TraitDescription = "Tellarites have keen senses of smell and hearing, and excellent spatial awareness, allowing them to judge distance, depth, and dimension with considerable accuracy. They have a high tolerance for many common drugs, toxins, and inebriants (Tellarites don’t get drunk, just ‘feisty’).",
            SpeciesAbility = _speciesAbilitySelector.GetSpeciesAbility(SpeciesAbilityName.Sturdy),
            Weight = 8
        },
        new Species
        {
            Name = SpeciesName.Trill,
            Description = new List<string>
            {
                "The Trill are a pair of species who originate from a world of the same name. The Trill that most outsiders know appear almost identical to Humans or Betazoids, but for a row of irregular spots running down the sides of their bodies. The other Trill species are small invertebrates, which dwell in subterranean caverns. There are relatively few of this second species, species, but they are extremely intelligent and capable of living for centuries.",
                "While not a secret, it is not widely discussed that a small portion of humanoid Trill are capable of bonding with the invertebrates, commonly referred to as symbionts, and in this bond—called a Joining—creates a gestalt person, a combination of the minds, memories, and personalities of both creatures. While a symbiont cannot be removed without killing its host, upon a host’s death, a symbiont will be passed to a new host, preserving knowledge and memory over generations.",
                "Trill society has been shaped by the Joined, with Trill culture tending to take a long view of social development, and pursuing intellectual and philosophical development over interpersonal conflict. The Trill are a firm and dedicated member of the Federation.",
            },
            ExampleCharacters = "Jadzia Dax (Deep Space Nine), Gray Tal (Discovery)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Presence = 1, Reason = 1
            },
            TraitDescription = "Trill are especially resistant to parasites and similar intrusion. However, they tend to have strong allergic reactions to insect bites and other venoms, which can disrupt their neurochemistry, especially if they are Joined. Many of the specifics of Trill physiology—specifically with regards to symbionts—are not widely understood by non-Trill doctors, which can result in medical complications. Many Joined Trill find using a transporter to be uncomfortable.",
            SpeciesAbility = new SpeciesAbility
            {
                Name = "Patient",
                Description = "When you succeed at a task where you purchased one or more d20s by spending Momentum, you generate 1 bonus Momentum for each d20 purchased. Bonus Momentum may not be saved."
            },
            Weight = 8
        },
        new Species
        {
            Name = SpeciesName.Vulcan,
            Description = new List<string>
            {
                "The first species to contact Humans, Vulcans are stoic, rational people. Widely claimed to be emotionless, Vulcans in fact feel emotions deeply and intensely, to their own detriment. Ancient Vulcans were prone to murderous rage and fits of paranoia, and nearly destroyed themselves millennia ago, before Surak taught logic and the purging of emotion. His teachings led to peace among the Vulcans and the establishment of a culture driven by reason.",
                "Vulcans embrace science and logic, but their lives are not purely devoted to such things: they have a deeply philosophical and spiritual side, with art and music as vital to their culture as logic. They are also an intensely private people, with many aspects of their culture largely kept secret from outsiders."
            },
            ExampleCharacters = "Spock (Star Trek), T’Pol (Enterprise), Tuvok (Voyager)",
            AttributeModifiers = new CharacterAttributes
            {
                Control = 1, Fitness = 1, Reason = 1
            },
            TraitDescription = "Vulcans have a naturally high tolerance for extremes of heat, are resistant to dehydration, and can shield their eyes from blinding light with a set of secondary eyelids. Their auditory and olfactory senses are extremely keen, and the gravity of their homeworld means an average Vulcan is about three times as strong as a Human of similar size and weight. Vulcans are innately telepathic, and through extensive training since childhood, Vulcan minds can suppress their emotional responses, and even exert influence upon biological processes, though this takes regular meditation to maintain.",
            SpeciesAbility = _speciesAbilitySelector.GetSpeciesAbility(SpeciesAbilityName.MentalDiscipline),
            Weight = 12
        },
        //new Species { Name = SpeciesName.Ankari, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Arbazan, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Ardanan, AttributeModifiers = new CharacterAttributes { Fitness = 1, Presence = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Argrathi, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Arkarian, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Reason = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.CyberneticallyEnhanced, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, NonMixed = true, SecondSpecies = true, Weight = 1 },
        //new Species { Name = SpeciesName.Dosi, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Drai, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Haliian, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Presence = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Jye, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Karemma, AttributeModifiers = new CharacterAttributes { Control = 1, Reason = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Lokirrim, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Mari, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, MustTakeSpecificTalentInStepOne = "Empath", Weight = 0 },
        //new Species { Name = SpeciesName.Monean, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Paradan, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Pendari, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Rakhari, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Sikarian, AttributeModifiers = new CharacterAttributes { Control = 1, Reason = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Skreeaa, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Tosk, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Fitness = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Turei, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Vorta, AttributeModifiers = new CharacterAttributes { Insight = 1, Presence = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Xahean, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Reason = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.XindiArboreal, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Reason = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.XindiInsectoid, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.XindiPrimate, AttributeModifiers = new CharacterAttributes { Daring = 1, Presence = 1, Reason = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.XindiReptilian, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Wadi, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Zahl, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Zakdorn, AttributeModifiers = new CharacterAttributes { Insight = 1, Presence = 1, Reason = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Zaranite, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, Weight = 2 }
    };
}
