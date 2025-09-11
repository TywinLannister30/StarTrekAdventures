using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class ValueSelector
{
    public static string ChooseValue(Character character)
    {
        var weightedValuesList = new WeightedList<Value>();

        foreach (var value in Values)
        {
            if (CanTakeValue(character, value))
                weightedValuesList.AddEntry(value, value.Weight);
        }

        return weightedValuesList.GetRandom().Name;
    }

    private static bool CanTakeValue(Character character, Value value)
    {
        if (character.Values.Any(x => x == value.Name))
            return false;

        if (!string.IsNullOrEmpty(value.TraitRequirement) && !character.Traits.Any(x => x == value.TraitRequirement))
            return false;

        if (!string.IsNullOrEmpty(value.TalentRequirement) && !character.Talents.Any(x => x.Name == value.TalentRequirement))
            return false;

        if (!string.IsNullOrEmpty(value.TrackRequirement) && character.ChosenTrack != value.TrackRequirement)
            return false;

        if (!string.IsNullOrEmpty(value.ExperienceRequirement) && character.Experience != value.ExperienceRequirement)
            return false;

        return true;
    }

    private static readonly List<Value> Values = new()
    {
        new Value { Name = "Do not mistake my blindness for helplessness", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "I perceive things your eyes do not", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "Life is incomplete without purpose", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "Pacifism is not passive", TraitRequirement = SpeciesName.Aenar, Weight = 10 },

        new Value { Name = "I always repay my debts", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "No challenge unmet", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "Proud Child of Andoria", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "Question my word, question my honor", TraitRequirement = SpeciesName.Andorian, Weight = 10 },

        new Value { Name = "Fortune Favors the Faithful", TraitRequirement = SpeciesName.Ankari, Weight = 10 },

        new Value { Name = "Propriety First and Always", TraitRequirement = SpeciesName.Arbazan, Weight = 10 },

        new Value { Name = "Nothing Is More Beautiful Than a City in the Sky", TraitRequirement = SpeciesName.Ardanan, Weight = 10 },

        new Value { Name = "The Law is Blind But Also Fair", TraitRequirement = SpeciesName.Argrathi, Weight = 10 },

        new Value { Name = "Dedication and Diligence", TraitRequirement = SpeciesName.Arkarian, Weight = 10 },

        new Value { Name = "Soar High and Achieve Greatness", TraitRequirement = SpeciesName.Aurelian, Weight = 10 },

        new Value { Name = "Faith in the Prophets", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "I help others to be closer to the Prophets", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "Survival at any cost", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "We are in the hands of the Prophets", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "You cannot explain faith to those who lack it", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "I Remember Each and Every Beating I Suffered", TraitRequirement = SpeciesName.Bajoran, Weight = 5 },
        new Value { Name = "The Prophets Have Never Spoken to Me", TraitRequirement = SpeciesName.Bajoran, Weight = 5 },
        new Value { Name = "True Independence for Bajor", TraitRequirement = SpeciesName.Bajoran, Weight = 5 },
        new Value { Name = "Walk with the Prophets, Child", TraitRequirement = SpeciesName.Bajoran, Weight = 5 },

        new Value { Name = "My Greatest Resource Is Myself, and I Will Use It Wisely", TraitRequirement = SpeciesName.Barzan, Weight = 10 },

        new Value { Name = "Report Only What You Know", TraitRequirement = SpeciesName.Benzite, Weight = 10 },

        new Value { Name = "A lie is a story told in bad faith", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "Compassion through Understanding", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "Do not be what others expect you to be", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "I can feel your pain", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "I’m just saying what you’re thinking", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },

        new Value { Name = "A Broad Smile and Warm Heart", TraitRequirement = SpeciesName.Bolian, Weight = 10 },

        new Value { Name = "All Others are Meant to Serve Us", TraitRequirement = SpeciesName.Breen, Weight = 5 },
        new Value { Name = "Brutally Effective", TraitRequirement = SpeciesName.Breen, Weight = 5 },
        new Value { Name = "My Soldiers are My Tools", TraitRequirement = SpeciesName.Breen, Weight = 5 },

        new Value { Name = "War is Instinct, Conflict an Art", TraitRequirement = SpeciesName.Caitian, Weight = 10 },

        new Value { Name = "All my stories are true, especially the lies", TraitRequirement = SpeciesName.Cardassian, Weight = 10 },
        new Value { Name = "Everyone is guilty of something, but who and of what?", TraitRequirement = SpeciesName.Cardassian, Weight = 10 },
        new Value { Name = "If you don't want me knowing, hide it better", TraitRequirement = SpeciesName.Cardassian, Weight = 10 },
        new Value { Name = "State above family; family above self", TraitRequirement = SpeciesName.Cardassian, Weight = 10 },
        new Value { Name = "A Disciplined Cardassian Mind", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Anyone Who Stands in our Way will be Destroyed", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Cardassia Expects Everyone to Do Their Duty", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Cardassia will be Made Whole", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Cardassians Did Not Choose to Be Superior, Fate Made Us This Way", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Loyal Defender of Cardassia", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "They Don’t Know What it Means to be my Enemy", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },

        new Value { Name = "The Founders Are the Will of the Dominion", TraitRequirement = SpeciesName.Changeling, Weight = 10 },
        new Value { Name = "My Terms are not Open to Negotiation", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "The Changelings Are the Dominion", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "There’s Very Little that Escapes our Attention", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "What You Control Can’t Hurt You", TraitRequirement = SpeciesName.Changeling, Weight = 5 },

        new Value { Name = "Artificial but Still Alive", TraitRequirement = SpeciesName.CyberneticallyEnhanced, Weight = 10 },

        new Value { Name = "Bodies and Minds as One", TraitRequirement = SpeciesName.Deltan, Weight = 10 },

        new Value { Name = "Comfort in numbers", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "My patience exceeds your stubbornness", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "There's always someone new to meet", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "You cannot truly learn about people unless you talk to them", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },

        new Value { Name = "I Have Already Proven Myself The Victor", TraitRequirement = SpeciesName.Dosi, Weight = 10 },

        new Value { Name = "There Are No Challenges Like The Hunt", TraitRequirement = SpeciesName.Drai, Weight = 10 },
        new Value { Name = "Cold-Blooded Killer", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "The Hunt Is Everything", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "They Are Insignificant In The Eyes Of The Dominion", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "We Shall Succeed At All Costs", TraitRequirement = SpeciesName.Drai, Weight = 5 },

        new Value { Name = "Perspective Brings Understanding", TraitRequirement = SpeciesName.Edosian, Weight = 10 },

        new Value { Name = "Specialization Furthers Knowledge", TraitRequirement = SpeciesName.Efrosian, Weight = 10 },

        new Value { Name = "1st Rule of Acquisition — Once You Have Their Money, Never Give It Back", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "6th Rule of Acquisition – Never Let Family Stand in the Way of Profit", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "9th Rule of Acquisition – Opportunity plus instinct equals profit", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "31st Rule of Acquisition – Never Make Fun of a Ferengi’s Mother", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "41st Rule of Acquisition – Profit is its Own Reward", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "48th Rule of Acquisition — The Bigger the Smile, the Sharper the Knife", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "62nd Rule of Acquisition — The riskier the road, the greater the profit", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "74th Rule of Acquisition – Knowledge Equals Profit", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "94th Rule of Acquisition – Females and Finances Don’t Mix", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "98th Rule of Acquisition – Every Man Has His Price", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "125th Rule of Acquisition – You can’t make a deal if you’re dead", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "168th Rule of Acquisition – Whisper Your Way to Success", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "190th Rule of Acquisition – Hear All, Trust Nothing", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "211th Rule of Acquisition — Employees are the Rungs on the Ladder to Success; Don’t Hesitate to Step On Them", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "263rd Rule of Acquisition – Never allow doubt to tarnish your lust for latinum", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "285th Rule of Acquisition – No Good Deed Ever Goes Unpunished", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "Profit Above All Else", TraitRequirement = SpeciesName.Ferengi, Weight = 5 },

        new Value { Name = "Patient Study Yields the Best Results", TraitRequirement = SpeciesName.Grazerite, Weight = 10 },

        new Value { Name = "Many Sides to every Tale", TraitRequirement = SpeciesName.Haliian, Weight = 10 },

        new Value { Name = "I believe in what the Federation stands for", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "Learn something new every day", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "Seek out new life and new civilizations", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "The Drive for Exploration", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "We are stronger together", TraitRequirement = SpeciesName.Human, Weight = 10 },

        new Value { Name = "All Traitors Must Be Accounted For", TraitRequirement = SpeciesName.JemHadar, Weight = 5 },
        new Value { Name = "Loyalty to the Founders, Now and Always", TraitRequirement = SpeciesName.JemHadar, Weight = 5 },
        new Value { Name = "We Are Now Dead; We Go into Battle to Reclaim Our Lives", TraitRequirement = SpeciesName.JemHadar, Weight = 5 },

        new Value { Name = "Perfection by the Numbers", TraitRequirement = SpeciesName.Jye, Weight = 10 },

        new Value { Name = "I See Your True Worth", TraitRequirement = SpeciesName.Karemma, Weight = 10 },

        new Value { Name = "The Great Balance Must Be Achieved", TraitRequirement = SpeciesName.KelpianPostVaharai, Weight = 10 },

        new Value { Name = "The Great Balance Must Be Achieved", TraitRequirement = SpeciesName.KelpianPreVaharai, Weight = 10 },

        new Value { Name = "Honor is More Important Than Life", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "I am a Klingon warrior; if you doubt it, a demonstration can be arranged!", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Own the day!", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Revenge is a dish best served cold", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Today is a Good Day to Die!", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Burn It All", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "Death Before Dishonor", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "Defeat Makes my Wounds Ache", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "For the Good of the Empire", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "How Hollow is the Sound of Victory Without Someone to Share it With", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "I Would Rather Die than Dishonor My Uniform", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "Never Trust Starfleet", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "There is Nothing More Honorable Than Victory", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "To Kill the Defenseless is Not True Battle", TraitRequirement = SpeciesName.Klingon, Weight = 5 },

        new Value { Name = "Hold the Course until the End", TraitRequirement = SpeciesName.Ktarian, Weight = 10 },

        new Value { Name = "What Does It Mean to be an Individual?", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 10 },
        new Value { Name = "Borg are More than the Collective, and I Will Show Them", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 5 },
        new Value { Name = "I Have Known Freedom and Will Have it Again", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 5 },
        new Value { Name = "I Must Do as My Programming Instructs", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 5 },
        new Value { Name = "Resistance is Not Futile", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 5 },

        new Value { Name = "Our Creations Will Submit", TraitRequirement = SpeciesName.Lokirrim, Weight = 10 },

        new Value { Name = "Belly Full of Song and Heart Full of Glory", TraitRequirement = SpeciesName.Lurian, Weight = 10 },

        new Value { Name = "Peace in Mind and Action", TraitRequirement = SpeciesName.Mari, Weight = 10 },

        new Value { Name = "Space – the Greatest Ocean of All", TraitRequirement = SpeciesName.Monean, Weight = 10 },

        new Value { Name = "All Others Are Weak", TraitRequirement = SpeciesName.Nausicaan, Weight = 10 },

        new Value { Name = "See All that Life has to Offer", TraitRequirement = SpeciesName.Ocampa, Weight = 10 },

        new Value { Name = "Everything has a price", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "I am not who you expect me to be", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "I thrive because I do not ignore opportunities", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "Your expectations limit you", TraitRequirement = SpeciesName.Orion, Weight = 10 },

        new Value { Name = "I Am as Strong Apart as I Am with Others", TraitRequirement = SpeciesName.Osnullus, Weight = 10 },

        new Value { Name = "I Am Original and That Gives Me Strength", TraitRequirement = SpeciesName.Paradan, Weight = 10 },

        new Value { Name = "Victory or Death", TraitRequirement = SpeciesName.Pendari, Weight = 10 },

        new Value { Name = "I Make The Rules And You Obey Them", TraitRequirement = SpeciesName.Rakhari, Weight = 10 },

        new Value { Name = "My Life for my Charge", TraitRequirement = SpeciesName.Reman, Weight = 5 },

        new Value { Name = "Real Power is in the Service of Others", TraitRequirement = SpeciesName.RigellianChelon, Weight = 10 },
        new Value { Name = "Governance and Trade for the Prosperity of All", TraitRequirement = SpeciesName.RigellianJelna, Weight = 10 },

        new Value { Name = "All That is Ours is Yours", TraitRequirement = SpeciesName.Risian, Weight = 10 },

        new Value { Name = "Even my secrets have secrets!", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Every secret I discover is another weapon in my arsenal", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "I give my life to the service of the Empire", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Secrecy is a shield against betrayal", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Everything I Do, I Do for Romulus", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "I Will Not Fail in My Duty to the Empire", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "My People Should Be Free", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "My Portion is Obedience", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "War is Bought with Blood", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "Outlanders are People, Too", TraitRequirement = SpeciesName.Romulan, Weight = 5 },

        new Value { Name = "Consider Carefully, Then Act Decisively", TraitRequirement = SpeciesName.Saurian, Weight = 10 },

        new Value { Name = "Welcome All Travelers", TraitRequirement = SpeciesName.Sikarian, Weight = 10 },

        new Value { Name = "The Tide Always Breaks Upon The Shore And The Shore Endures", TraitRequirement = SpeciesName.Skreeaa, Weight = 10 },

        new Value { Name = "We Do What We Must", TraitRequirement = SpeciesName.Sona, Weight = 10 },

        new Value { Name = "Ethical Programming Defines My Thinking", TraitRequirement = SpeciesName.SoongTypeAndroid, Weight = 10 },
        new Value { Name = "Know a Man by His Friends", TraitRequirement = SpeciesName.SoongTypeAndroid, Weight = 10 },
        new Value { Name = "Vast Repository of Information", TraitRequirement = SpeciesName.SoongTypeAndroid, Weight = 10 },
        new Value { Name = "What is it to be Human?", TraitRequirement = SpeciesName.SoongTypeAndroid, Weight = 10 },

        new Value { Name = "Only Fools take Risks", TraitRequirement = SpeciesName.Talaxian, Weight = 10 },

        new Value { Name = "An idea left unchallenged can be dangerous", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "No notion is above proper scrutiny", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "No voice silenced, no perspective unheard", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "You’ll never get an answer if you don’t ask questions", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },

        new Value { Name = "Several Lifetimes of Adventure", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined", Weight = 20 },
        new Value { Name = "Even a 400-Year-Old Explorer Can Find Something New", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined", Weight = 5 },
        new Value { Name = "What will this mean a century from now?", TraitRequirement = SpeciesName.Trill, Weight = 10 },
        new Value { Name = "What can I discover today?", TraitRequirement = SpeciesName.Trill, Weight = 10 },
        new Value { Name = "Who I was is only part of who I am", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined",  Weight = 10 },

        new Value { Name = "I Am Tosk", TraitRequirement = SpeciesName.Tosk, Weight = 10 },

        new Value { Name = "No One Shall Be My Master", TraitRequirement = SpeciesName.Turei, Weight = 10 },

        new Value { Name = "I am an Expert on Lies", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        new Value { Name = "I Live to Serve the Founders", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        new Value { Name = "The Dominion Philosophy Is Superior", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        new Value { Name = "The Founders are the Masters", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        new Value { Name = "There Is Nothing I Will Not Do to Succeed", TraitRequirement = SpeciesName.Vorta, Weight = 5 },

        new Value { Name = "In accepting the inevitable, one finds peace", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "Logic is the beginning of wisdom, not the end", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "Nothing that is, is unimportant", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "The Needs of the Many Outweigh the Needs of the Few, or the One", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "Proud of the Vulcan Way", TraitRequirement = SpeciesName.Vulcan, Weight = 5 },

        new Value { Name = "Allamaraine!, Shall We Play Again?", TraitRequirement = SpeciesName.Wadi, Weight = 10 },

        new Value { Name = "Balance Between Oneself and the World Around You.", TraitRequirement = SpeciesName.Xahean, Weight = 10 },

        new Value { Name = "Calm Focuses the Mind", TraitRequirement = SpeciesName.XindiArboreal, Weight = 10 },
        new Value { Name = "Protect your Off-spring at the Expense of Self", TraitRequirement = SpeciesName.XindiInsectoid, Weight = 10 },
        new Value { Name = "Honesty Never Makes a Problem Worse", TraitRequirement = SpeciesName.XindiPrimate, Weight = 10 },
        new Value { Name = "Patience is for the Dead", TraitRequirement = SpeciesName.XindiReptilian, Weight = 10 },

        new Value { Name = "Kindness Wins More Battles than Weapons", TraitRequirement = SpeciesName.Zahl, Weight = 10 },

        new Value { Name = "A Coherent Strategy is the First Line of Defense", TraitRequirement = SpeciesName.Zakdorn, Weight = 10 },

        new Value { Name = "The Tougher the Skin, the Tougher the Being", TraitRequirement = SpeciesName.Zaranite, Weight = 10 },

        new Value { Name = "Starfleet is a promise: I’d give my life for you, you’d give your life for me, and nobody gets left behind", TrackRequirement = TrackName.StarfleetOfficerCommand, Weight = 10 },
        new Value { Name = "The first duty of every Starfleet officer is to the truth", TrackRequirement = TrackName.StarfleetOfficerCommand, Weight = 10 },
        new Value { Name = "The Prime Directive is there to remind us that we are not gods, and should not act like them", TrackRequirement = TrackName.StarfleetOfficerCommand, Weight = 10 },

        new Value { Name = "By the book isn’t worth much in practice", TrackRequirement = TrackName.StarfleetOfficerOperations, Weight = 10 },
        new Value { Name = "Get it done right the first time", TrackRequirement = TrackName.StarfleetOfficerOperations, Weight = 10 },
        new Value { Name = "Sometimes, you just have to improvise", TrackRequirement = TrackName.StarfleetOfficerOperations, Weight = 10 },

        new Value { Name = "First, do no harm", TrackRequirement = TrackName.StarfleetOfficerSciences, Weight = 10 },
        new Value { Name = "I want to see what nobody else has seen", TrackRequirement = TrackName.StarfleetOfficerSciences, Weight = 10 },
        new Value { Name = "No conclusions until I’ve run some tests", TrackRequirement = TrackName.StarfleetOfficerSciences, Weight = 10 },

        new Value { Name = "Don’t call me sir; I work for a living", TrackRequirement = TrackName.StarfleetEnlisted, Weight = 10 },
        new Value { Name = "Nowhere else can I get this experience", TrackRequirement = TrackName.StarfleetEnlisted, Weight = 10 },
        new Value { Name = "The satisfaction of a job well-done is worth the effort", TrackRequirement = TrackName.StarfleetEnlisted, Weight = 10 },

        new Value { Name = "Insufficient information can result in disaster", TrackRequirement = TrackName.StarfleetIntelligence, Weight = 10 },
        new Value { Name = "Secrets are my business", TrackRequirement = TrackName.StarfleetIntelligence, Weight = 10 },
        new Value { Name = "Trust, but verify", TrackRequirement = TrackName.StarfleetIntelligence, Weight = 10 },

        new Value { Name = "Eventually, everyone comes back to the table to talk", TrackRequirement = TrackName.DiplomaticCorps, Weight = 10 },
        new Value { Name = "The right words can shape countless lives", TrackRequirement = TrackName.DiplomaticCorps, Weight = 10 },
        new Value { Name = "You don’t get a better world if you don’t work for it", TrackRequirement = TrackName.DiplomaticCorps, Weight = 10 },

        new Value { Name = "An ounce of prevention is worth a pound of cure", TrackRequirement = TrackName.CivilianPhysician, Weight = 10 },
        new Value { Name = "I must respect my patient’s wishes", TrackRequirement = TrackName.CivilianPhysician, Weight = 10 },
        new Value { Name = "The Hippocratic Oath", TrackRequirement = TrackName.CivilianPhysician, Weight = 10 },

        new Value { Name = "I have devoted my career to this research", TrackRequirement = TrackName.CivilianScientist, Weight = 10 },
        new Value { Name = "Science allows us to seek truth and understanding", TrackRequirement = TrackName.CivilianScientist, Weight = 10 },
        new Value { Name = "With the right tools, we can solve any problem", TrackRequirement = TrackName.CivilianScientist, Weight = 10 },

        new Value { Name = "Keeping the wheels of civilization turning is vital", TrackRequirement = TrackName.CivilianOfficial, Weight = 10 },
        new Value { Name = "My decisions can affect a great many people; I must choose carefully", TrackRequirement = TrackName.CivilianOfficial, Weight = 10 },
        new Value { Name = "The law should serve the needs of the people", TrackRequirement = TrackName.CivilianOfficial, Weight = 10 },

        new Value { Name = "When all your needs are met, it’s the experience that matters", TrackRequirement = TrackName.CivilianTrader, Weight = 10 },
        new Value { Name = "Today’s strangers are tomorrow’s customers", TrackRequirement = TrackName.CivilianTrader, Weight = 10 },
        new Value { Name = "You wouldn’t begrudge me a little profit in this venture?", TrackRequirement = TrackName.CivilianTrader, Weight = 10 },

        new Value { Name = "I can’t wait to see what’s out there", ExperienceRequirement = ExperienceName.Novice, Weight = 10 },
        new Value { Name = "I must prove myself", ExperienceRequirement = ExperienceName.Novice, Weight = 10 },
        new Value { Name = "The Galaxy isn’t what I expected", ExperienceRequirement = ExperienceName.Novice, Weight = 10 },

        new Value { Name = "I’ve trusted my instincts long enough to doubt them now", ExperienceRequirement = ExperienceName.Veteran, Weight = 10 },
        new Value { Name = "There’s not much that can surprise me anymore", ExperienceRequirement = ExperienceName.Veteran, Weight = 10 },
        new Value { Name = "You don’t survive this long without facing loss", ExperienceRequirement = ExperienceName.Veteran, Weight = 10 },

        new Value { Name = "A Failure to Act Can Be As Dangerous As Acting Rashly", Weight = 1 },
        new Value { Name = "A Questioning Mind is Essential for Exploration", Weight = 1 },
        new Value { Name = "A Prodigy of Starfleet Intelligence", Weight = 1 },
        new Value { Name = "A Responsibility to the Truth", Weight = 1 },
        new Value { Name = "A Ship is a Home, it’s Crew a Family", Weight = 1 },
        new Value { Name = "A Theory For Every Situation", Weight = 1 },
        new Value { Name = "A Treaty is Just a Piece of Paper", Weight = 1 },
        new Value { Name = "Always Pad Your Estimates", Weight = 1 },
        new Value { Name = "Always Prepared, Always Vigilant", Weight = 1 },
        new Value { Name = "Are You Sure These Are the Right Coordinates?", Weight = 1 },
        new Value { Name = "Better to be Too Thorough than Not Thorough Enough", Weight = 1 },
        new Value { Name = "Body and Mind Alike Must Be Healthy", Weight = 1 },
        new Value { Name = "Body and Mind Alike Must Be Healthy", Weight = 1 },
        new Value { Name = "Breaking Federation Principles in Order to Keep It Safe", Weight = 1 },
        new Value { Name = "Can I Cook, or Can’t I?", Weight = 1 },
        new Value { Name = "Compelled to Ease the Plight of Others", Weight = 1 },
        new Value { Name = "Concessions Must Be Made to Ensure Our Safety", Weight = 1 },
        new Value { Name = "Crucial Business Demands Immediate Attention", Weight = 1 },
        new Value { Name = "Deny by Demolition", Weight = 1 },
        new Value { Name = "Design Moves Technology to its Preferred State", Weight = 1 },
        new Value { Name = "Do Not Be What Others Expect of You", Weight = 1 },
        new Value { Name = "Do Not Cross Me", Weight = 1 },
        new Value { Name = "Don’t Say It Unless You Mean It", Weight = 1 },
        new Value { Name = "Driven to Ease Suffering", Weight = 1 },
        new Value { Name = "Duty Before All Else", Weight = 1 },
        new Value { Name = "Engineer at Heart", Weight = 1 },
        new Value { Name = "Every Day is an Adventure", Weight = 1 },
        new Value { Name = "Everything I Have Lost, I Will Regain", Weight = 1 },
        new Value { Name = "Exploring to Test New Theories", Weight = 1 },
        new Value { Name = "Fail to Prepare and You Prepare to Fail", Weight = 1 },
        new Value { Name = "Family Matters", Weight = 1 },
        new Value { Name = "Fast Ships and Strange New Worlds", Weight = 1 },
        new Value { Name = "Fear Is As Effective As A Warship", Weight = 1 },
        new Value { Name = "First, Do No Harm", Weight = 1 },
        new Value { Name = "For Every Problem, There’s a Solution", Weight = 1 },
        new Value { Name = "Friends Are the Family You Choose", Weight = 1 },
        new Value { Name = "From This Chair I Am in Control", Weight = 1 },
        new Value { Name = "Get it Done Right the First Time", Weight = 1 },
        new Value { Name = "Go Down Swinging", Weight = 1 },
        new Value { Name = "Great Men Make History", Weight = 1 },
        new Value { Name = "Haunted by the Borg", Weight = 1 },
        new Value { Name = "Holds Everyone to the Highest Standards", Weight = 1 },
        new Value { Name = "Hungry for Dangerous Situations", Weight = 1 },
        new Value { Name = "I Am a Man of Secrets", Weight = 1 },
        new Value { Name = "I Am the Unseen Hand of Starfleet", Weight = 1 },
        new Value { Name = "I Ask of My Crew Only What I Ask of Myself", Weight = 1 },
        new Value { Name = "I Can Always Do More for My People", Weight = 1 },
        new Value { Name = "I Don’t Believe in a No-Win Scenario", Weight = 1 },
        new Value { Name = "I Feel the Need for Speed", Weight = 1 },
        new Value { Name = "I Seize Opportunity and Take What I Want", Weight = 1 },
        new Value { Name = "I Will Never be Defeated", Weight = 1 },
        new Value { Name = "I’ll Try My Luck Again", Weight = 1 },
        new Value { Name = "I’m Beginning a New Life", Weight = 1 },
        new Value { Name = "I’m Not Going to Let Anything Stop Me from Getting What I Want", Weight = 1 },
        new Value { Name = "If I Can Help, I Will", Weight = 1 },
        new Value { Name = "If We Go, We Go Together", Weight = 1 },
        new Value { Name = "Indefatigable Confidence", Weight = 1 },
        new Value { Name = "Inexperienced and Idealistic", Weight = 1 },
        new Value { Name = "Insatiable Curiosity", Weight = 1 },
        new Value { Name = "It’s Not Illegal if You Don’t get Caught", Weight = 1 },
        new Value { Name = "Knowledge is Power, and Power is Everything", Weight = 1 },
        new Value { Name = "Language Is the Key to Exploring New Civilizations", Weight = 1 },
        new Value { Name = "Law is the Foundation Upon Which an Orderly Society is Built", Weight = 1 },
        new Value { Name = "Learn All We Can Until The Fighting Begins", Weight = 1 },
        new Value { Name = "Leading in Discovery", Weight = 1 },
        new Value { Name = "Life from Lifelessness", Weight = 1 },
        new Value { Name = "Life is Meant to Be Lived", Weight = 1 },
        new Value { Name = "Life’s True Gift is the Capacity to Enjoy Enjoyment", Weight = 1 },
        new Value { Name = "Live Life to the Full", Weight = 1 },
        new Value { Name = "Living with the Ghosts of War", Weight = 1 },
        new Value { Name = "Making the Galaxy a Better Place One World at a Time", Weight = 1 },
        new Value { Name = "Man or Machine? Man and Machine", Weight = 1 },
        new Value { Name = "Meticulous Scrutiny and Pride in Their Work", Weight = 1 },
        new Value { Name = "More Comfortable with Engine Schematics than People", Weight = 1 },
        new Value { Name = "Most Comfortable in a Crowd", Weight = 1 },
        new Value { Name = "Most Comfortable in the Center Chair", Weight = 1 },
        new Value { Name = "My Crew is My Family", Weight = 1 },
        new Value { Name = "My Faith Will Keep Me Warm", Weight = 1 },
        new Value { Name = "Never Give Less than What I’m Capable of Giving", Weight = 1 },
        new Value { Name = "Never let Others Define Who You Are", Weight = 1 },
        new Value { Name = "No Price is Too High for Security", Weight = 1 },
        new Value { Name = "No Regrets for a Life Lived Well", Weight = 1 },
        new Value { Name = "No Stranger to Violence", Weight = 1 },
        new Value { Name = "Nothing Better Than Practical Experience", Weight = 1 },
        new Value { Name = "Nothing is Certain", Weight = 1 },
        new Value { Name = "Nothing’s More Important than Family", Weight = 1 },
        new Value { Name = "On the Cutting Edge of Progress", Weight = 1 },
        new Value { Name = "Our First Priority is the Lives of Federation Citizens", Weight = 1 },
        new Value { Name = "Peace can be attained through effort and compromise", Weight = 1 },
        new Value { Name = "Precise to a Fault", Weight = 1 },
        new Value { Name = "Protecting the Federation is Paramount", Weight = 1 },
        new Value { Name = "Proud and Honest", Weight = 1 },
        new Value { Name = "Rarely Refuses an Interesting Challenge", Weight = 1 },
        new Value { Name = "Respect the Chain of Command, Whether You Agree with It or Not", Weight = 1 },
        new Value { Name = "Risk Is Our Business", Weight = 1 },
        new Value { Name = "Risk is Part of the Game if You Want the Captain’s Chair", Weight = 1 },
        new Value { Name = "Sacrifice Makes Us Strong", Weight = 1 },
        new Value { Name = "Safeguard the Federation from All Threats", Weight = 1 },
        new Value { Name = "Safety of the Family First", Weight = 1 },
        new Value { Name = "Serving Starfleet is a Family Tradition", Weight = 1 },
        new Value { Name = "Silent Vigilance", Weight = 1 },
        new Value { Name = "Sometimes Family Hurts Family", Weight = 1 },
        new Value { Name = "Strange New Life", Weight = 1 },
        new Value { Name = "The Captain’s Second Opinion", Weight = 1 },
        new Value { Name = "The Ends Justify the Means", Weight = 1 },
        new Value { Name = "The Federation Must be Protected at All Costs", Weight = 1 },
        new Value { Name = "The First to See Those Stars Up Close", Weight = 1 },
        new Value { Name = "The Maquis are a Bunch of Irresponsible Hotheads", Weight = 1 },
        new Value { Name = "The Price of Peace is Vigilance", Weight = 1 },
        new Value { Name = "There is No Greater Enemy than One’s Own Fears", Weight = 1 },
        new Value { Name = "There Is No Higher Calling Than to Serve", Weight = 1 },
        new Value { Name = "There’s Nothing as Important as Shaping the Next Generation", Weight = 1 },
        new Value { Name = "There’s No Such Thing as the Unknown", Weight = 1 },
        new Value { Name = "They Will Respect My Authority", Weight = 1 },
        new Value { Name = "Things Don’t Always Turn Out Quite the Way You Expect Them To", Weight = 1 },
        new Value { Name = "This Job Requires a Keen Mind and an Iron Will", Weight = 1 },
        new Value { Name = "Threw Out The Handbook and Wrote My Own", Weight = 1 },
        new Value { Name = "To Achieve High Standards, You Must Expect High Standards", Weight = 1 },
        new Value { Name = "To Explore Strange New Worlds...", Weight = 1 },
        new Value { Name = "Too Many People Underestimate the Threats We Face", Weight = 1 },
        new Value { Name = "Understands Machines Better Than People", Weight = 1 },
        new Value { Name = "Understands Technology Better Than People", Weight = 1 },
        new Value { Name = "Voice of the Crew", Weight = 1 },
        new Value { Name = "We Endure Hardship, So That Others Do Not Have To", Weight = 1 },
        new Value { Name = "We Will Take Care of Ourselves", Weight = 1 },
        new Value { Name = "We’ll Get It Done...", Weight = 1 },
        new Value { Name = "We’re in a War and I Intend to Win It", Weight = 1 },
        new Value { Name = "What is Necessary is Never Unwise", Weight = 1 },
        new Value { Name = "What Matters the Most is Company", Weight = 1 },
        new Value { Name = "You Must Not Die!", Weight = 1 },
    };
}
