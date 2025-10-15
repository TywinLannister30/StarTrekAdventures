using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class AwardSelector : IAwardSelector
{
    public Award GetAward(string name)
    {
        return Awards.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<Award> GetAllAwards()
    {
        return Awards;
    }

    private static readonly List<Award> Awards = new()
    {
        new Award {
            Name = "Carrington Award",
            Description = "The Carrington Award is one of the highest honors the Federation can bestow in the field of medicine. It is widely considered to be a lifetime achievement award for physicians, but there are a handful of examples of nominees and even winners from outside the medical field, particularly for humanitarian work. Each year, the Federation Medical Council selects five nominees and then chooses a winner from among them.",
            CostString = "When you select this award, choose whether you are a nominee or a winner. The cost is 2 for nominees, and 5 for winners.",
            Conditions = "The character has a prestigious career in medicine, or a long history of humanitarian work, and has recently made a significant breakthrough or contribution to medical science.",
            Benefit = "Whenever you attempt a Medicine task to overcome an extended task, you may increase your Impact by 1. If you are a winner, then you may also select a single Medicine talent. You gain the trait Carrington Winner or Carrington Nominee, as appropriate.",
            Source = BookSource.ExplorationGuide},

        new Award {
            Name = "Christopher Pike Medal of Valor",
            Description = "A prestigious medal awarded to Starfleet officers in recognition of remarkable leadership, meritorious conduct, and acts of personal bravery, named for legendary Starfleet officer Christopher Pike. Prior to the 2260s, similar medals existed under different names.",
            Cost = 4,
            Conditions = "The character must be an officer in a command or leadership position who led their crew in a succession of several difficult missions, and who faced personal danger on at least two of those missions.",
            Benefit = "Once per mission, when the character uses the Direct task, they may treat their d20 as if it had rolled a 1." },

        new Award {
            Name = "Cochrane Medal of Excellence",
            Description = "The Cochrane Medal of Excellence is awarded by the Zefram Cochrane Institute for Advanced Theoretical Physics to Starfleet officers and cadets who perform outstanding feats in various fields of science and engineering.",
            Cost = 3,
            Conditions = "The character must have significantly contributed to a field of scientific study or engineering, such as making and documenting an important discovery, or finding a solution to a long-standing problem. ",
            Benefit = "Select a single focus the character possesses, which must relate to the scientific or engineering field they earned the medal for. Once per mission, when the character spends a point of Determination on a task involving that focus, the character may select two benefits of spending a point of Determination instead of one." },

        new Award {
            Name = "Daystrom Award",
            Description = "Also known as the Daystrom Prize, the Daystrom Award is given to individuals who have made significant scientific or technical achievements. It is named for Dr. Richard Daystrom, administered by the Daystrom Institute on Earth, and is commonly awarded to pioneering breakthroughs or technological ‘firsts’.",
            Cost = 4,
            Conditions = "The character must have made a major contribution to a field of scientific study or engineering.",
            Benefit = "Select a single focus you possess, which must relate to the scientific or technical field you received the award for. Once per mission, when you succeed at a task using that focus, you gain 3 bonus Momentum. Bonus Momentum may not be saved.",
            Source = BookSource.ExplorationGuide},

        new Award {
            Name = "Grankite Order of Tactics",
            Description = "The Grankite Order of Tactics is awarded to new members of the Grankite Order, a ceremonial order within Starfleet recognizing officers who demonstrate exceptional tactical acumen.",
            Cost = 3,
            Conditions = "The character must have demonstrated exceptional skill and tactical thinking during combat or some other crisis, which directly contributed to the success of the mission or the survival of the ship and crew.",
            Benefit = "Once per mission, when the character creates a trait that reflects or represents some strategy or tactic, they may automatically add a level of Potency to that trait. " },

        new Award {
            Name = "Karagite Order of Heroism",
            Description = "The Karagite Order of Heroism is awarded to new members of the Karagite Order, a ceremonial order within Starfleet recognizing officers who demonstrate exceptional heroism in defense of the Federation and its people.",
            Cost = 3,
            Conditions = "The character must have personally faced extreme danger and overwhelming odds in combat or a similar crisis, and both survived and succeeded in defending a Federation world or outpost from loss or destruction.",
            Benefit = "Once per mission, when the character would suffer an Injury, the character may Avoid the Injury for free. Alternatively, once per mission, when the character’s ship would suffer one or more breaches, the character may spend 2 Momentum (Immediate) and suffer a complication to ignore one of those breaches. Only one of these benefits may apply in any given mission." },

        new Award {
            Name = "Legion of Honor",
            Description = "The Legion of Honor is a commendation given to Starfleet personnel who have acted in a way that exemplifies the best qualities of Starfleet.",
            Cost = 4,
            Conditions = "None",
            Benefit = "Once per mission, the character may perform one of the following: gain 2 bonus Momentum on a successful task (bonus Momentum may not be saved), or ignore a single complication suffered on a task (choose to do this before the gamemaster announces the complication’s effect)." },

        new Award {
            Name = "Nobel Prize",
            Description = "A traditional United Earth award, established in 1895 by the Human chemist, engineer, and industrialist Alfred Nobel in his will to celebrate those who have conferred the greatest benefit to humankind. Originally, there were five prizes given annually for achievements in the fields of physics, chemistry, medicine, literature, and peace: they have since been joined by additional prizes, including economics and archaeology.",
            Cost = 3,
            Conditions = "The character must have made a meaningful contribution to the good of humanity (specifically, not just the Federation as a whole) in the fields of physics, chemistry, medicine, literature, economics, archaeology, or peace. Most, but not all Nobel prizes are awarded to Humans, as the award is specific to Earth.",
            Benefit = "The character may take the trait Nobel Laureate. Select a single focus when you receive this award, which relates to the prize you won. Once per mission, when you succeed at a task using that focus, you may spend 3 Momentum to immediately gain 1 Determination.",
            Source = BookSource.ExplorationGuide},

        new Award {
            Name = "Palm Leaf of (X)",
            Description = "Peace Mission Palm Leaves of this sort are commendations awarded to Starfleet officers who participate in successful peace missions, such as that to the planet Axanar in the 23rd century. In each case, the award includes the name of the peace mission.",
            Cost = 3,
            Conditions = "The mission in which this award was earned must have involved securing peace between warring nations, or the signing of a peace treaty. All characters involved in the mission are eligible.",
            Benefit = "Once per mission, when attempting a Persuade task to prevent violence, the character may automatically succeed at the task by spending Momentum equal to the task’s Difficulty." },

        new Award {
            Name = "Rigel Cup",
            Description = "In the Federation, this is an award won for exceptional sublight piloting skills. Many younger Starfleet officers have won the award as a demonstration of their skill at the helm of a starship.",
            Cost = 3,
            Conditions = "The character has demonstrated exceptional proficiency when piloting a starship, shuttlecraft, or other vessel at sublight speeds through difficult conditions.",
            Benefit = "When the character attempts a task to maneuver a vessel at sublight speeds, they may re-roll one d20; Further, they may ignore the first complication rolled.",
            Source = BookSource.ExplorationGuide},

        new Award {
            Name = "Star Cross",
            Description = "The Star Cross is a medal awarded to Starfleet personnel for distinguished actions.",
            Cost = 3,
            Conditions = "None",
            Benefit = "Once per mission, before attempting a task that one of their focuses applies to, the character may choose to double their focus range. For that task, the character scores two successes for any die that rolls equal to or less than twice their department rating (for example, if the character has a department rating of 4, any die that rolls an 8 or lower scores two successes for that task)." },

        new Award {
            Name = "Starfleet Citation for Conspicuous Gallantry",
            Description = "The Starfleet Citation for Conspicuous Gallantry is an award declaring an act of heroism by a Starfleet officer.",
            Cost = 2,
            Conditions = "The character must have succeeded at a particularly heroic, risky, or daring action during the mission.",
            Benefit = "Once per mission, when the character pays for an Immediate Momentum spend by adding Threat, they may roll 1d20. If the result is equal to or less than the character’s Daring, 1 Threat is immediately removed from the gamemaster’s pool." },

        new Award {
            Name = "Starfleet Decoration of Gallantry",
            Description = "The Starfleet Decoration of Gallantry is a medal awarded to Starfleet officers who show extreme bravery in the line of duty.",
            Cost = 2,
            Conditions = "The character must have faced an extremely difficult or dangerous situation and triumphed despite the peril.",
            Benefit = "Once per mission, whenever the character suffers an Injury, halve the Severity of that Injury before avoiding it." },

        new Award {
            Name = "Starfleet Medal of Honor",
            Description = "The Starfleet Medal of Honor is a medal for valor presented to Starfleet personnel who are deemed to have acted above and beyond the call of duty.",
            Cost = 5,
            Conditions = "It is possible to earn this medal multiple times.",
            Benefit = "Once per mission, the character may gain 2 bonus Momentum on a successful task (bonus Momentum may not be saved). If the character has earned this medal multiple times, this benefit may be used once per mission per Medal of Honor the character has earned, but no more than once per task." },

        new Award {
            Name = "Starfleet Surgeons’ Decoration",
            Description = "This is a special medal for valor awarded exclusively to Starfleet medical personnel for acts above and beyond the call of duty.",
            Cost = 3,
            Conditions = "The character must be a Medical officer of some description, who acted above and beyond the call of duty in an attempt to save a patient or patients or otherwise alleviate some medical crisis.",
            Benefit = "Once per mission, the character may reduce the Difficulty of a single Medical task by 2, to a minimum of 1." },

        new Award {
            Name = "Zee-Magnees Prize",
            Description = "A prestigious award comparable to Earth’s Nobel prize, awarded to those who have contributed significant advancements to the United Federation of Planets. The award originated from Alpha Centauri, and has been expanded over the centuries to include new fields and disciplines that did not exist when the awards were originally conceived.",
            Cost = 4,
            Conditions = "The character must have made a meaningful scientific contribution to the benefit of the Federation.",
            Benefit = "The character may take the trait Zee- Magnees Laureate. Select a single focus when you receive this award, which relates to the reason you won the award. Once per mission, you may automatically succeed at a task using that focus by spending Momentum (Immediate) equal to the Difficulty.",
            Source = BookSource.ExplorationGuide},
    };
}
