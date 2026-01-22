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
            Source = BookSource.NextGenerationCrewPack1stEdition
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
            Weight = 8
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
            Source = BookSource.NextGenerationCrewPack1stEdition
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
        //new Species { Name = SpeciesName.Bolian, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 4 },
        //new Species { Name = SpeciesName.Caitian, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Insight = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Changeling, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Presence = 1 }, MustTakeSpecificTalentInStepOne = "Morphogenic Matrix", Weight = 0 },
        //new Species { Name = SpeciesName.CyberneticallyEnhanced, AttributeModifiers = new CharacterAttributes { Control = 1, Fitness = 1, Reason = 1 }, NonMixed = true, SecondSpecies = true, Weight = 1 },
        //new Species { Name = SpeciesName.Deltan, AttributeModifiers = new CharacterAttributes { Control = 1, Insight = 1, Presence = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Dosi, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Drai, AttributeModifiers = new CharacterAttributes { Daring = 1, Fitness = 1, Presence = 1 }, Weight = 0 },
        //new Species { Name = SpeciesName.Edosian, AttributeModifiers = new CharacterAttributes { Fitness = 1, Insight = 1, Reason = 1 }, Weight = 2 },
        //new Species { Name = SpeciesName.Efrosian, AttributeModifiers = new CharacterAttributes { Fitness = 1, Presence = 1, Reason = 1 }, Weight = 4 },
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
