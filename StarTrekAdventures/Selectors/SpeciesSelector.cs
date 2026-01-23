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

        //if (chosenSpecies.First().SecondSpecies)
        //{
        //    chosenSpecies.Add(GetAnotherRandomSpecies(SpeciesName.LiberatedBorg));
        //}

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
                AddTalent = "Telepathy"
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
                AddOneOfTheseTalents = new List<string> { "Telepathy", "Empathy" }
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
                AddTalent = "Empathy",
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
        //new Species { Name = SpeciesName.Grazerite, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Haliian, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Presence = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.JemHadar, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Jye, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Karemma, AttributeModifiers = new CharacterAttributes { Control = 1, Reason = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.KelpianPostVaharai, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Insight = 1 }, Weight = 1 },
        //new Species { Name = SpeciesName.KelpianPreVaharai, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Insight = 1 }, Weight = 1 },
        //new Species { Name = SpeciesName.Ktarian, AttributeModifiers = new CharacterAttributes { Control = 1, Reason = 1 }, OneOfTheseModifiers = new CharacterAttributes { Fitness = 1, Presence = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.LiberatedBorg, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Presence = 1 }, NonMixed = true, SecondSpecies = true, MustTakeSpecificTalentInStepOne = "Borg Implants", Weight = 1 },
        //new Species { Name = SpeciesName.Lokirrim, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Lurian, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Mari, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, MustTakeSpecificTalentInStepOne = "Empath", Weight = 0 },
        //new Species { Name = SpeciesName.Monean, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Ocampa, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Osnullus, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Reason = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Paradan, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Pendari, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Rakhari, AttributeModifiers = new CharacterAttributes { Daring = 1, Insight = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Reman, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.RigellianChelon, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.RigellianJelna, AttributeModifiers = new CharacterAttributes { Fitness = 1, Presence = 1, Reason = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Risian, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Saurian, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Reason = 1 }, Weight = 2, MustTakeSpecificTalentInStepOne = "Enhanced Metabolism" },
        //new Species { Name = SpeciesName.Sikarian, AttributeModifiers = new CharacterAttributes { Control = 1, Reason = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Skreeaa, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Sona, AttributeModifiers = new CharacterAttributes { Control = 1, Daring = 1, Insight = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.SoongTypeAndroid, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, NonMixed = true, MustTakeSpecificTalentInStepOne = "Polyalloy Construction", MustTakeAnotherSpecificTalentInStepOne = "Positronic Brain", Weight = 0 },
        //new Species { Name = SpeciesName.Talaxian, AttributeModifiers = new CharacterAttributes { Control = 1, Presence = 1, Insight = 1 }, Weight = 0 },
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
