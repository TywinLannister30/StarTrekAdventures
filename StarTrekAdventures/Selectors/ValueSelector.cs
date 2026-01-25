using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class ValueSelector : IValueSelector
{
    public string ChooseValue(Character character)
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

        if (value.AnyTraitRequirement != null && value.AnyTraitRequirement.Count != 0)
        {
            if (!character.Traits.Any(t => value.AnyTraitRequirement.Contains(t)))
                return false;
        }

        if (value.AllTraitRequirement != null && value.AllTraitRequirement.Count != 0)
        {
            if (!value.AllTraitRequirement.All(req => character.Traits.Contains(req)))
                return false;
        }

        if (!string.IsNullOrEmpty(value.TalentRequirement) && !character.Talents.Any(x => x.Name == value.TalentRequirement))
            return false;

        if (!string.IsNullOrEmpty(value.TrackRequirement) && character.ChosenTrack != value.TrackRequirement)
            return false;

        if (!string.IsNullOrEmpty(value.ExperienceRequirement) && character.Experience != value.ExperienceRequirement)
            return false;

        return true;
    }

    public List<Value> GetAllValues()
    {
        return Values;
    }

    public Value GetSpecificValue(string name)
    {
        return Values.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    private static readonly List<Value> Values = new()
    {
        new Value { Name = "Do not mistake my blindness for helplessness", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "I perceive things your eyes do not", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "Ice runs in my veins, but that doesn’t mean I’m cold-hearted", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "Life is incomplete without purpose", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "Pacifism is not passive", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "Stubborn as a glacier", TraitRequirement = SpeciesName.Aenar, Weight = 10 },

        new Value { Name = "I always repay my debts", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "Ice runs in my veins, but that doesn’t mean I’m cold-hearted", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "No challenge unmet", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "Proud child of Andoria", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "Question my word, question my honor", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "Stubborn as a glacier", TraitRequirement = SpeciesName.Andorian, Weight = 10 },

        new Value { Name = "A whole Galaxy to explore and experience", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Ethical programming defines my thinking", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Just because I am synthetic doesn’t mean I’m not a person", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Know a man by his friends", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },
        new Value { Name = "Vast repository of information", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },
        new Value { Name = "What does it mean to be alive?", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "What is it to be human?", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },

        new Value { Name = "Fortune favors the faithful", TraitRequirement = SpeciesName.Ankari, Weight = 10 },
        
        new Value { Name = "Propriety first and always", TraitRequirement = SpeciesName.Arbazan, Weight = 10 },
        
        new Value { Name = "Nothing is more beautiful than a city in the sky", TraitRequirement = SpeciesName.Ardanan, Weight = 10 },
        
        new Value { Name = "The law is blind but also fair", TraitRequirement = SpeciesName.Argrathi, Weight = 10 },
        
        new Value { Name = "Dedication and diligence", TraitRequirement = SpeciesName.Arkarian, Weight = 10 },

        new Value { Name = "By knowing our past, we can see better what’s coming", AnyTraitRequirement = { SpeciesName.Aurelian, SpeciesName.AurelianNovolare }, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I need an open sky and the wind in my feathers", AnyTraitRequirement = { SpeciesName.Aurelian, SpeciesName.AurelianNovolare }, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Soar high and achieve greatness", AnyTraitRequirement = { SpeciesName.Aurelian, SpeciesName.AurelianNovolare }, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "There is always something more to explore", AnyTraitRequirement = { SpeciesName.Aurelian, SpeciesName.AurelianNovolare }, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I stand apart because I have to keep part of myself secret", TraitRequirement = TraitName.Augment, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I’m not dangerous; I just see the world differently ", TraitRequirement = TraitName.Augment, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Superior ability breeds superior ambition", TraitRequirement = TraitName.Augment, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Faith in the prophets", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "I help others to be closer to the prophets", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "Survival at any cost", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "We are in the hands of the prophets", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "You cannot explain faith to those who lack it", TraitRequirement = SpeciesName.Bajoran, Weight = 10 },
        new Value { Name = "I remember each and every beating I suffered", TraitRequirement = SpeciesName.Bajoran, Weight = 5 },
        new Value { Name = "The prophets have never spoken to me", TraitRequirement = SpeciesName.Bajoran, Weight = 5 },
        new Value { Name = "True independence for Bajor", TraitRequirement = SpeciesName.Bajoran, Weight = 5 },
        new Value { Name = "Walk with the prophets, child", TraitRequirement = SpeciesName.Bajoran, Weight = 5 },

        new Value { Name = "My greatest resource is myself, and I will use it wisely", TraitRequirement = SpeciesName.Barzan, Weight = 10 },
        new Value { Name = "Anything less than my best is a waste", TraitRequirement = SpeciesName.Barzan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Duty above all", TraitRequirement = SpeciesName.Barzan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My skill and resolve are the only resources I need", TraitRequirement = SpeciesName.Barzan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "What is required of me that others may survive?", TraitRequirement = SpeciesName.Barzan, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Devise a solution for any problem you discover", TraitRequirement = SpeciesName.Benzite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Information is only worth sharing if it’s useful", TraitRequirement = SpeciesName.Benzite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Report only what you know", TraitRequirement = SpeciesName.Benzite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Rushing to conclusions is a sure path to disaster", TraitRequirement = SpeciesName.Benzite, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "A lie is a story told in bad faith", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "Compassion through understanding", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "Do not be what others expect you to be", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "I can feel your pain", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "I’m just saying what you’re thinking", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "Openness and honesty are just easier ways to live", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "Privacy is a luxury among telepaths", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },

        new Value { Name = "I am nothing without my conduct", TraitRequirement = SpeciesName.Betelgeusian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My foe deserves every respect as a fellow warrior", TraitRequirement = SpeciesName.Betelgeusian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My word is absolute, and I will not break it", TraitRequirement = SpeciesName.Betelgeusian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "There will be one victor here, and it shall be me", TraitRequirement = SpeciesName.Betelgeusian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "A broad smile and warm heart", TraitRequirement = SpeciesName.Bolian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "A shared task is half the work and twice the satisfaction", TraitRequirement = SpeciesName.Bolian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "If you don’t speak your mind, how can anyone know you?", TraitRequirement = SpeciesName.Bolian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Who am I going to meet today?", TraitRequirement = SpeciesName.Bolian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I do not care what happens as long as I achieve my objectives", TraitRequirement = SpeciesName.Breen, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My code of honor is for me and mine; I’m not obliged to treat you honorably", TraitRequirement = SpeciesName.Breen, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My regard for you lasts only as long as I benefit", TraitRequirement = SpeciesName.Breen, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Your pain does not concern me", TraitRequirement = SpeciesName.Breen, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "All others are meant to serve us", TraitRequirement = SpeciesName.Breen, Weight = 5 },
        new Value { Name = "Brutally effective", TraitRequirement = SpeciesName.Breen, Weight = 5 },
        new Value { Name = "My soldiers are my tools", TraitRequirement = SpeciesName.Breen, Weight = 5 },

        new Value { Name = "I do not want to fight, but I will resist you if I must", TraitRequirement = SpeciesName.Brikar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The Galaxy’s a perilous place, but we can make it less so", TraitRequirement = SpeciesName.Brikar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Patience and curiosity are more valuable than aggression", TraitRequirement = SpeciesName.Brikar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Your fear of my appearance blinds you to who I am", TraitRequirement = SpeciesName.Brikar, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Two minds are…", TraitRequirement = SpeciesName.Bynar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "…Better than one", TraitRequirement = SpeciesName.Bynar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "All that we are will remain forever in the central computer", TraitRequirement = SpeciesName.Bynar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The group endures better than any individual", TraitRequirement = SpeciesName.Bynar, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Don’t cross me; I do not hold back if pressed", TraitRequirement = SpeciesName.Caitian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Family, whether born or found, is the strongest bond", TraitRequirement = SpeciesName.Caitian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I may not need to hunt, but it pays to keep my senses sharp", TraitRequirement = SpeciesName.Caitian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "War is instinct, conflict an art", TraitRequirement = SpeciesName.Caitian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "All my stories are true, especially the lies", TraitRequirement = SpeciesName.Cardassian, Weight = 10 },
        new Value { Name = "Everyone is guilty of something, but who and of what?", TraitRequirement = SpeciesName.Cardassian, Weight = 10 },
        new Value { Name = "If you don't want me knowing, hide it better", TraitRequirement = SpeciesName.Cardassian, Weight = 10 },
        new Value { Name = "State above family; family above self", TraitRequirement = SpeciesName.Cardassian, Weight = 10 },
        new Value { Name = "A disciplined Cardassian mind", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Anyone who stands in our way will be destroyed", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Cardassia expects everyone to do their duty", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Cardassia will be made whole", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Cardassians did not choose to be superior, fate made us this way", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "Loyal defender of Cardassia", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },
        new Value { Name = "They don’t know what it means to be my enemy", TraitRequirement = SpeciesName.Cardassian, Weight = 5 },

        new Value { Name = "I do this for curiosity, duty, honor, and unlimited fish", TraitRequirement = SpeciesName.Cetacean, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "No thumbs, but I’m still a member of this crew", TraitRequirement = SpeciesName.Cetacean, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "To seek out strange new oceans", TraitRequirement = SpeciesName.Cetacean, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Work can be fun and rewarding with the right attitude", TraitRequirement = SpeciesName.Cetacean, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I am safest when I’m anonymous", TraitRequirement = SpeciesName.Chameloid, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I lie to keep myself alive", TraitRequirement = SpeciesName.Chameloid, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Keep everyone guessing about who you really are", TraitRequirement = SpeciesName.Chameloid, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Which face would you like to meet today?", TraitRequirement = SpeciesName.Chameloid, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Solids will never understand us", TraitRequirement = SpeciesName.Changeling, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The Founders’ will defines the Dominion", TraitRequirement = SpeciesName.Changeling, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The Galaxy is dangerous, and safety comes from order", TraitRequirement = SpeciesName.Changeling, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The ocean becomes the drop, and the drop becomes the ocean", TraitRequirement = SpeciesName.Changeling, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My terms are not open to negotiation", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "The Changelings are the Dominion", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "There’s very little that escapes our attention", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "What you control can’t hurt you", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        
        new Value { Name = "Artificial but still alive", TraitRequirement = SpeciesName.CyberneticallyEnhanced, Weight = 10 },

        new Value { Name = "Bodies and minds as one", TraitRequirement = SpeciesName.Deltan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Emotions are central to how we experience life", TraitRequirement = SpeciesName.Deltan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Peace is only possible if we’re honest with one another", TraitRequirement = SpeciesName.Deltan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "You are not ready to feel as deeply as I do", TraitRequirement = SpeciesName.Deltan, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "A new neighbor is a potential friend", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "Comfort in numbers", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "Everyone is connected somehow", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "My patience exceeds your stubbornness", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "There's always someone new to meet", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "You cannot truly learn about people unless you talk to them", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        
        new Value { Name = "I have already proven myself the victor", TraitRequirement = SpeciesName.Dosi, Weight = 10 },
        
        new Value { Name = "There are no challenges like the hunt", TraitRequirement = SpeciesName.Drai, Weight = 10 },
        new Value { Name = "Cold-blooded killer", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "The hunt is everything", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "They are insignificant in the eyes of the Dominion", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "We shall succeed at all costs", TraitRequirement = SpeciesName.Drai, Weight = 5 },

        new Value { Name = "Do not mistake contemplation for hesitation", TraitRequirement = SpeciesName.Edosian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Perspective brings understanding", TraitRequirement = SpeciesName.Edosian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Preserve the present, for our future is shaped by its past", TraitRequirement = SpeciesName.Edosian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The differences between our fields of study are lines we draw ourselves", TraitRequirement = SpeciesName.Edosian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Music and stories are how we appreciate the universe more deeply", TraitRequirement = SpeciesName.Efrosian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Specialization furthers knowledge", TraitRequirement = SpeciesName.Efrosian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The universe shows you the way, as long as you’re paying attention", TraitRequirement = SpeciesName.Efrosian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "True knowledge takes understanding, not merely reading from a PADD", TraitRequirement = SpeciesName.Efrosian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I have seen too much tragedy to be able to stand by and witness more", TraitRequirement = SpeciesName.ElAurian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I have the time to find the answers I want", TraitRequirement = SpeciesName.ElAurian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The sound of the universe is always there", TraitRequirement = SpeciesName.ElAurian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "You can learn anything if you just pay attention", TraitRequirement = SpeciesName.ElAurian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I am alive and I am a machine; this is not a contradiction", TraitRequirement = SpeciesName.Exocomp, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I am the right tool for the job", TraitRequirement = SpeciesName.Exocomp, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I can always adapt", TraitRequirement = SpeciesName.Exocomp, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My life is my own to build, and mine to give", TraitRequirement = SpeciesName.Exocomp, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "1st rule of acquisition — once you have their money, never give it back", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "6th rule of acquisition – never let family stand in the way of profit", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "9th rule of acquisition – opportunity plus instinct equals profit", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "31st rule of acquisition – never make fun of a Ferengi’s mother", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "41st rule of acquisition – profit is its own reward", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "48th rule of acquisition — the bigger the smile, the sharper the knife", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "62nd rule of acquisition — the riskier the road, the greater the profit", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "74th rule of acquisition – knowledge equals profit", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "94th rule of acquisition – females and finances don’t mix", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "98th rule of acquisition – every man has his price", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "125th rule of acquisition – you can’t make a deal if you’re dead", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "168th rule of acquisition – whisper your way to success", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "190th rule of acquisition – hear all, trust nothing", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "211th rule of acquisition — employees are the rungs on the ladder to success; don’t hesitate to step on them", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "263rd rule of acquisition – never allow doubt to tarnish your lust for latinum", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "285th rule of acquisition – no good deed ever goes unpunished", TraitRequirement = SpeciesName.Ferengi, Weight = 10 },
        new Value { Name = "Profit above all else", TraitRequirement = SpeciesName.Ferengi, Weight = 5 },

        new Value { Name = "A community shares its boons and burdens alike", TraitRequirement = SpeciesName.Grazerite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Anger never led to constructive decisions", TraitRequirement = SpeciesName.Grazerite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Patient study yields the best results", TraitRequirement = SpeciesName.Grazerite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The best way to resolve conflict is to prevent it arising", TraitRequirement = SpeciesName.Grazerite, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Many sides to every tale", TraitRequirement = SpeciesName.Haliian, Weight = 10 },

        new Value { Name = "Few organics pay a hologram much mind", TraitRequirement = SpeciesName.Hologram, Weight = 20, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I am not flesh and blood, but I am real", TraitRequirement = SpeciesName.Hologram, Weight = 20, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Photons be free!", TraitRequirement = SpeciesName.Hologram, Weight = 20, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Where does my programming end and my personality begin?", TraitRequirement = SpeciesName.Hologram, Weight = 20, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "All things, even rocks and stones, grow and change with time", TraitRequirement = SpeciesName.Horta, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Be your best, so that all may thrive", TraitRequirement = SpeciesName.Horta, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I am not a monster", TraitRequirement = SpeciesName.Horta, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We may not resemble what you think of as life, but we are alive", TraitRequirement = SpeciesName.Horta, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Earth is a paradise, but not everywhere is so fortunate", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "I believe in what the Federation stands for", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "Learn something new every day", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "Seek out new life and new civilizations", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "The drive for exploration", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "The Federation has brought peace to countless worlds", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "We are stronger together", TraitRequirement = SpeciesName.Human, Weight = 10 },

        new Value { Name = "Just because my genes were altered, that doesn’t make me any less Human", AllTraitRequirement = { SpeciesName.Human, TraitName.Augment }, Weight = 20, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Ad astra per aspera—through hardship to the stars", TraitRequirement = SpeciesName.Illyrian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We must choose between a piece of ourselves and a place among the stars", TraitRequirement = SpeciesName.Illyrian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We seek to live in harmony with nature, not to dominate it", TraitRequirement = SpeciesName.Illyrian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Your history should not dictate our future ", TraitRequirement = SpeciesName.Illyrian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I will do as ordered, but I will seek to do so honorably ", TraitRequirement = SpeciesName.JemHadar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Obedience brings victory, and victory is life!", TraitRequirement = SpeciesName.JemHadar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Relaxation and recreation are weaknesses", TraitRequirement = SpeciesName.JemHadar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We pledge loyalty to the Founders from now until death", TraitRequirement = SpeciesName.JemHadar, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "All traitors must be accounted for", TraitRequirement = SpeciesName.JemHadar, Weight = 5 },
        new Value { Name = "We are now dead; we go into battle to reclaim our lives", TraitRequirement = SpeciesName.JemHadar, Weight = 5 },
        
        new Value { Name = "Perfection by the numbers", TraitRequirement = SpeciesName.Jye, Weight = 10 },
        
        new Value { Name = "I see your true worth", TraitRequirement = SpeciesName.Karemma, Weight = 10 },

        new Value { Name = "Harsh action now may prevent something worse later", TraitRequirement = SpeciesName.Kellerun, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I care about what you can do more than who you are", TraitRequirement = SpeciesName.Kellerun, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I have no taste for battle, but I will not yield meekly to threats", TraitRequirement = SpeciesName.Kellerun, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I’ve seen too much destruction to allow more ", TraitRequirement = SpeciesName.Kellerun, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I am keenly aware of the coming of danger", TraitRequirement = SpeciesName.Kelpien, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The universe requires a balance; if it does not exist, we must find it", TraitRequirement = SpeciesName.Kelpien, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We are predators, and I study my prey carefully", TraitRequirement = SpeciesName.Kelpien, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "You call it fear, I call it healthy caution", TraitRequirement = SpeciesName.Kelpien, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Honor is more important than life", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "I am a Klingon warrior; if you doubt it, a demonstration can be arranged!", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Own the day!", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Revenge is a dish best served cold", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "The strong will prosper, but what they do with that strength is what matters", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "The Galaxy is a dangerous place for the unwary", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Today is a good day to die!", TraitRequirement = SpeciesName.Klingon, Weight = 10 },

        new Value { Name = "Burn it all", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "Death before dishonor", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "Defeat makes my wounds ache", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "For the good of the Empire", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "How hollow is the sound of victory without someone to share it with", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "I would rather die than dishonor my uniform", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "Never trust Starfleet", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "There is nothing more honorable than victory", TraitRequirement = SpeciesName.Klingon, Weight = 5 },
        new Value { Name = "To kill the defenseless is not true battle", TraitRequirement = SpeciesName.Klingon, Weight = 5 },

        new Value { Name = "I am a Klingon in my heart, even if I must prove it continually", TraitRequirement = TraitName.QuchHa, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Survival must be earned ", TraitRequirement = TraitName.QuchHa, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "There is always a path to victory", TraitRequirement = TraitName.QuchHa, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "There is nothing more honorable than victory ", TraitRequirement = TraitName.QuchHa, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Be a can-alope, not a can’t-alope", TraitRequirement = SpeciesName.Klowahkan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Life is too short to be wasted on blandness", TraitRequirement = SpeciesName.Klowahkan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The Galaxy is a sumptuous buffet just waiting to be sampled", TraitRequirement = SpeciesName.Klowahkan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We appreciate a meal more when we are hungry ", TraitRequirement = SpeciesName.Klowahkan, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Hold the course until the end", TraitRequirement = SpeciesName.Ktarian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "See an obstacle, overcome it", TraitRequirement = SpeciesName.Ktarian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Only the foolish fail to prepare", TraitRequirement = SpeciesName.Ktarian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Find a solution before the problem arises", TraitRequirement = SpeciesName.Ktarian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Be careful not to let trouble follow you home", TraitRequirement = SpeciesName.Kwejian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The universe is in careful balance, but care is needed to maintain it", TraitRequirement = SpeciesName.Kwejian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The world gives back what we put into it", TraitRequirement = SpeciesName.Kwejian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We few carry the legacy of the lost", TraitRequirement = SpeciesName.Kwejian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I need to make a name for myself", TraitRequirement = SpeciesName.Kzinti, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "If you wound me but do not kill me, expect retaliation", TraitRequirement = SpeciesName.Kzinti, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Once you smell blood, you finish the job", TraitRequirement = SpeciesName.Kzinti, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Plant-eaters do not deserve my respect", TraitRequirement = SpeciesName.Kzinti, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Boredom is the worst part of living almost forever", TraitRequirement = SpeciesName.Lanthanite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Cherish those who walk through life with you, no matter how briefly", TraitRequirement = SpeciesName.Lanthanite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I keep mementos of my past, and I’m always looking for the next one", TraitRequirement = SpeciesName.Lanthanite, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Sooner or later, everything ends; so enjoy it now", TraitRequirement = SpeciesName.Lanthanite, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I aspire to perfection on my own terms", TraitRequirement = TraitName.Borg, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My crew is my collective", TraitRequirement = TraitName.Borg, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Resistance is imperative", TraitRequirement = TraitName.Borg, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "What does it mean to be an individual?", TraitRequirement = TraitName.Borg, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Borg are more than the collective, and I will show them", TraitRequirement = TraitName.Borg, Weight = 5 },
        new Value { Name = "I have known freedom and will have it again", TraitRequirement = TraitName.Borg, Weight = 5 },
        new Value { Name = "I must do as my programming instructs", TraitRequirement = TraitName.Borg, Weight = 5 },
        new Value { Name = "Resistance is not futile", TraitRequirement = TraitName.Borg, Weight = 5 },
        
        new Value { Name = "Our creations will submit", TraitRequirement = SpeciesName.Lokirrim, Weight = 10 },

        new Value { Name = "A good story starts with a grand adventure", TraitRequirement = SpeciesName.Lurian, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "Bellies full of song and hearts full of glory", TraitRequirement = SpeciesName.Lurian, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "Live life fully and unashamedly", TraitRequirement = SpeciesName.Lurian, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "There is inspiration and fortune to be had among the stars", TraitRequirement = SpeciesName.Lurian, Weight = 10, Source = BookSource.SpeciesSourcebook},

        new Value { Name = "Peace in mind and action", TraitRequirement = SpeciesName.Mari, Weight = 10 },

        new Value { Name = "I care not for solitude or isolation", TraitRequirement = SpeciesName.Medusan, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "I must balance my desire to explore with the harm my presence may do", TraitRequirement = SpeciesName.Medusan, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "The universe contains countless wonders waiting to be experienced", TraitRequirement = SpeciesName.Medusan, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "We are all bettered by learning from perspectives other than our own", TraitRequirement = SpeciesName.Medusan, Weight = 10, Source = BookSource.SpeciesSourcebook},

        new Value { Name = "Space – the greatest ocean of all", TraitRequirement = SpeciesName.Monean, Weight = 10 },

        new Value { Name = "Living large, despite my size", TraitRequirement = SpeciesName.Nanokin, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "Not all life is on the same scale as you", TraitRequirement = SpeciesName.Nanokin, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "Sometimes good things come in small packages", TraitRequirement = SpeciesName.Nanokin, Weight = 10, Source = BookSource.SpeciesSourcebook},
        new Value { Name = "Small things survive big events", TraitRequirement = SpeciesName.Nanokin, Weight = 10, Source = BookSource.SpeciesSourcebook},

        new Value { Name = "All others are weak", TraitRequirement = SpeciesName.Nausicaan, Weight = 10 },
        new Value { Name = "Do not back down from any challenge", TraitRequirement = SpeciesName.Nausicaan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "It’s only cheating if you are foolish enough to be caught", TraitRequirement = SpeciesName.Nausicaan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My strength gives me the right to make the rules", TraitRequirement = SpeciesName.Nausicaan, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Only the weak have need to fear pain", TraitRequirement = SpeciesName.Nausicaan, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Do not be afraid to explore your full potential", TraitRequirement = SpeciesName.Ocampa, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Life is short, do not waste it", TraitRequirement = SpeciesName.Ocampa, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Optimism, not naiveté", TraitRequirement = SpeciesName.Ocampa, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "See all that life has to offer", TraitRequirement = SpeciesName.Ocampa, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Everything has a price", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "I am not who you expect me to be", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "I thrive because I do not ignore opportunities", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "Your expectations limit you", TraitRequirement = SpeciesName.Orion, Weight = 10 },

        new Value { Name = "Disrespect us at your peril", TraitRequirement = TraitName.BlueOrion, Weight = 20, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "House Azure together against the Galaxy", TraitRequirement = TraitName.BlueOrion, Weight = 20, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I will grasp any opportunity to elevate myself and my House ", TraitRequirement = TraitName.BlueOrion, Weight = 20, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Piracy is our tradition, and should be respected", TraitRequirement = TraitName.BlueOrion, Weight = 20, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I am as strong apart as I am with others", TraitRequirement = SpeciesName.Osnullus, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I choose my place in the Galaxy, and my place is in this crew", TraitRequirement = SpeciesName.Osnullus, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I do what I must for my community", TraitRequirement = SpeciesName.Osnullus, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "You can’t tell, but this is my happy face", TraitRequirement = SpeciesName.Osnullus, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I find what others have, and make myself strong", TraitRequirement = SpeciesName.Pakled, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I should have the biggest hat", TraitRequirement = SpeciesName.Pakled, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Pakleds are strong!", TraitRequirement = SpeciesName.Pakled, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "You think we are not smart. We are smart.", TraitRequirement = SpeciesName.Pakled, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "I am original and that gives me strength", TraitRequirement = SpeciesName.Paradan, Weight = 10 },

        new Value { Name = "Victory or death", TraitRequirement = SpeciesName.Pendari, Weight = 10 },
        
        new Value { Name = "I make the rules and you obey them", TraitRequirement = SpeciesName.Rakhari, Weight = 10 },

        new Value { Name = "Pain is no deterrent", TraitRequirement = SpeciesName.Reman, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We do not fear the dark, for it is our home", TraitRequirement = SpeciesName.Reman, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We have known hardship, and that gives us the", TraitRequirement = SpeciesName.Reman, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "We shall no longer bow before anyone strength to conquer", TraitRequirement = SpeciesName.Reman, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "My life for my charge", TraitRequirement = SpeciesName.Reman, Weight = 5 },

        new Value { Name = "Governance and trade for the prosperity of all", TraitRequirement = SpeciesName.RigellianJelna, Weight = 10 },
        new Value { Name = "I am the role I take in society", TraitRequirement = SpeciesName.RigellianChelon, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "I do not wish to fight, but I will not back down if threatened", TraitRequirement = SpeciesName.RigellianChelon, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Real power is in the service of others", TraitRequirement = SpeciesName.RigellianChelon, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Violence is a thing of our past", TraitRequirement = SpeciesName.RigellianChelon, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "For the prosperity of all", TraitRequirement = SpeciesName.RigellianJelna, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Our Galaxy is a better place when we make allies rather than enemies", TraitRequirement = SpeciesName.RigellianJelna, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The Galaxy gets a little more interesting with each new inhabitant we encounter", TraitRequirement = SpeciesName.RigellianJelna, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The stars are filled with opportunities", TraitRequirement = SpeciesName.RigellianJelna, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "All that is ours is yours", TraitRequirement = SpeciesName.Risian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Everyone deserves relief from their burdens", TraitRequirement = SpeciesName.Risian, Weight = 10 },
        new Value { Name = "I will help you feel better, if you’ll let me", TraitRequirement = SpeciesName.Risian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Joy is as noble a pursuit as truth, duty, or glory", TraitRequirement = SpeciesName.Risian, Weight = 10 },
        new Value { Name = "Life is too precious to experience without joy", TraitRequirement = SpeciesName.Risian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The pursuit of pleasure is worthy in and of itself", TraitRequirement = SpeciesName.Risian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Even my secrets have secrets!", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Every secret I discover is another weapon in my arsenal", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "For the triumph of the Romulan Empire", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "I give my life to the service of the empire", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Secrecy is a shield against betrayal", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "To survive, I must keep my secrets and discover yours", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Everything I do, I do for Romulus", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "I will not fail in my duty to the Empire", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "My people should be free", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "My portion is obedience", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "War is bought with blood", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "Outlanders are people, too", TraitRequirement = SpeciesName.Romulan, Weight = 5 },

        new Value { Name = "A hunt requires patience long before it requires action", TraitRequirement = SpeciesName.Saurian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Consider carefully, then act decisively", TraitRequirement = SpeciesName.Saurian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Needless aggression can blind you to the right decision", TraitRequirement = SpeciesName.Saurian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "No environment I will not brave", TraitRequirement = SpeciesName.Saurian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "Welcome all travelers", TraitRequirement = SpeciesName.Sikarian, Weight = 10 },
        
        new Value { Name = "The tide always breaks upon the shore and the shore endures", TraitRequirement = SpeciesName.Skreeaa, Weight = 10 },
        
        new Value { Name = "We do what we must", TraitRequirement = SpeciesName.Sona, Weight = 10 },

        new Value { Name = "Only fools take risks", TraitRequirement = SpeciesName.Talaxian, Weight = 10 },

        new Value { Name = "Kailash, when it rises (referencing the necessity of sacrifice for a greater cause)", TraitRequirement = SpeciesName.Tamarian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Kiazi’s Children, Their Faces Wet (downplaying injury or hardship)", TraitRequirement = SpeciesName.Tamarian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "Life in the Cave of Garanoga (describing a place where one feels a sense of belonging)", TraitRequirement = SpeciesName.Tamarian, Weight = 10, Source = BookSource.SpeciesSourcebook },
        new Value { Name = "The River Temarc, in Winter (resistance to being swayed from a decision)", TraitRequirement = SpeciesName.Tamarian, Weight = 10, Source = BookSource.SpeciesSourcebook },

        new Value { Name = "An idea left unchallenged can be dangerous", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "Even the best ideas need to be re-examined occasionally", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "No notion is above proper scrutiny", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "No voice silenced, no perspective unheard", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "The truth can be painful, but I take no joy in your pain", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "You’ll never get an answer if you don’t ask questions", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },

        new Value { Name = "Several lifetimes of adventure", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined", Weight = 20 },
        new Value { Name = "Even a 400-year-old explorer can find something new", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined", Weight = 5 },
        new Value { Name = "The Galaxy contains more than you can see in a lifetime", TraitRequirement = SpeciesName.Trill, Weight = 10 },
        new Value { Name = "What will this mean a century from now?", TraitRequirement = SpeciesName.Trill, Weight = 10 },
        new Value { Name = "What can I discover today?", TraitRequirement = SpeciesName.Trill, Weight = 10 },
        new Value { Name = "Who I was is only part of who I am", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined", Weight = 10 },
        new Value { Name = "Why argue when you can seek understanding", TraitRequirement = SpeciesName.Trill, Weight = 10 },

        new Value { Name = "I am tosk", TraitRequirement = SpeciesName.Tosk, Weight = 10 },
        
        new Value { Name = "No one shall be my master", TraitRequirement = SpeciesName.Turei, Weight = 10 },
        
        new Value { Name = "I am an expert on lies", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        new Value { Name = "I live to serve the founders", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        new Value { Name = "The Dominion philosophy is superior", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        new Value { Name = "The founders are the masters", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        new Value { Name = "There is nothing I will not do to succeed", TraitRequirement = SpeciesName.Vorta, Weight = 5 },
        
        new Value { Name = "In accepting the inevitable, one finds peace", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "Logic is the beginning of wisdom, not the end", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "Nothing that is, is unimportant", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "The needs of the many outweigh the needs of the few, or the one", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "Proud of the Vulcan way", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "Service to the betterment of all gives purpose", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },
        new Value { Name = "We may choose to be guided by logic, but the real world isn’t always reasonable", TraitRequirement = SpeciesName.Vulcan, Weight = 10 },

        new Value { Name = "Allamaraine!, shall we play again?", TraitRequirement = SpeciesName.Wadi, Weight = 10 },
        
        new Value { Name = "Balance between oneself and the world around you.", TraitRequirement = SpeciesName.Xahean, Weight = 10 },
        
        new Value { Name = "Calm focuses the mind", TraitRequirement = SpeciesName.XindiArboreal, Weight = 10 },
        new Value { Name = "Protect your off-spring at the expense of self", TraitRequirement = SpeciesName.XindiInsectoid, Weight = 10 },
        new Value { Name = "Honesty never makes a problem worse", TraitRequirement = SpeciesName.XindiPrimate, Weight = 10 },
        new Value { Name = "Patience is for the dead", TraitRequirement = SpeciesName.XindiReptilian, Weight = 10 },
        
        new Value { Name = "Kindness wins more battles than weapons", TraitRequirement = SpeciesName.Zahl, Weight = 10 },
        
        new Value { Name = "A coherent strategy is the first line of defense", TraitRequirement = SpeciesName.Zakdorn, Weight = 10 },
        
        new Value { Name = "The tougher the skin, the tougher the being", TraitRequirement = SpeciesName.Zaranite, Weight = 10 },
        
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
        new Value { Name = "The Hippocratic oath", TrackRequirement = TrackName.CivilianPhysician, Weight = 10 },
        
        new Value { Name = "I have devoted my career to this research", TrackRequirement = TrackName.CivilianScientist, Weight = 10 },
        new Value { Name = "Science allows us to seek truth and understanding", TrackRequirement = TrackName.CivilianScientist, Weight = 10 },
        new Value { Name = "With the right tools, we can solve any problem", TrackRequirement = TrackName.CivilianScientist, Weight = 10 },
        
        new Value { Name = "Keeping the wheels of civilization turning is vital", TrackRequirement = TrackName.CivilianOfficial, Weight = 10 },
        new Value { Name = "My decisions can affect a great many people; I must choose carefully", TrackRequirement = TrackName.CivilianOfficial, Weight = 10 },
        new Value { Name = "The law should serve the needs of the people", TrackRequirement = TrackName.CivilianOfficial, Weight = 10 },
        
        new Value { Name = "When all your needs are met, it’s the experience that matters", TrackRequirement = TrackName.CivilianTrader, Weight = 10 },
        new Value { Name = "Today’s strangers are tomorrow’s customers", TrackRequirement = TrackName.CivilianTrader, Weight = 10 },
        new Value { Name = "You wouldn’t begrudge me a little profit in this venture?", TrackRequirement = TrackName.CivilianTrader, Weight = 10 },

        new Value { Name = "The past informs our future", TrackRequirement = TrackName.IndependentArchaeologist, Weight = 10 },
        new Value { Name = "These artifacts belong in a museum!", TrackRequirement = TrackName.IndependentArchaeologist, Weight = 10 },
        new Value { Name = "You need to be quick to secure history’s treasures", TrackRequirement = TrackName.IndependentArchaeologist, Weight = 10 },

        new Value { Name = "I prefer research to dealing with people", TrackRequirement = TrackName.OutpostScientist, Weight = 10 },
        new Value { Name = "These creatures are fascinating", TrackRequirement = TrackName.OutpostScientist, Weight = 10 },
        new Value { Name = "My research will change the world!", TrackRequirement = TrackName.OutpostScientist, Weight = 10 },

        new Value { Name = "I can’t wait to see what’s out there", ExperienceRequirement = ExperienceName.Novice, Weight = 10 },
        new Value { Name = "I must prove myself", ExperienceRequirement = ExperienceName.Novice, Weight = 10 },
        new Value { Name = "The galaxy isn’t what I expected", ExperienceRequirement = ExperienceName.Novice, Weight = 10 },
        
        new Value { Name = "I’ve trusted my instincts long enough to doubt them now", ExperienceRequirement = ExperienceName.Veteran, Weight = 10 },
        new Value { Name = "There’s not much that can surprise me anymore", ExperienceRequirement = ExperienceName.Veteran, Weight = 10 },
        new Value { Name = "You don’t survive this long without facing loss", ExperienceRequirement = ExperienceName.Veteran, Weight = 10 },
        
        new Value { Name = "A failure to act can be as dangerous as acting rashly", Weight = 1 },
        new Value { Name = "A good mystery is irresistible", Weight = 1 },
        new Value { Name = "A questioning mind is essential for exploration", Weight = 1 },
        new Value { Name = "A prodigy of Starfleet intelligence", Weight = 1 },
        new Value { Name = "A responsibility to the truth", Weight = 1 },
        new Value { Name = "A ship is a home, it’s crew a family", Weight = 1 },
        new Value { Name = "A theory for every situation", Weight = 1 },
        new Value { Name = "A treaty is just a piece of paper", Weight = 1 },
        new Value { Name = "Act with confidence, even if you don’t feel confident", Weight = 1 },
        new Value { Name = "Adaptation is survival", Weight = 1 },
        new Value { Name = "Admirals don’t intimidate me", Weight = 1 },
        new Value { Name = "All’s fair in love and politics", Weight = 1 },
        new Value { Name = "Always find ways to be useful", Weight = 1 },
        new Value { Name = "Always prepared, always vigilant", Weight = 1 },
        new Value { Name = "Always up for an adventure", Weight = 1 },
        new Value { Name = "Are you sure these are the right coordinates?", Weight = 1 },
        new Value { Name = "Better to be too thorough than not thorough enough", Weight = 1 },
        new Value { Name = "Body and mind alike must be healthy", Weight = 1 },
        new Value { Name = "Breaking Federation principles in order to keep it safe", Weight = 1 },
        new Value { Name = "Build relationships", Weight = 1 },
        new Value { Name = "Can I cook, or can’t I?", Weight = 1 },
        new Value { Name = "Compelled to ease the plight of others", Weight = 1 },
        new Value { Name = "Concessions must be made to ensure our safety", Weight = 1 },
        new Value { Name = "Crew comes first", Weight = 1 },
        new Value { Name = "Crucial business demands immediate attention", Weight = 1 },
        new Value { Name = "Deny by demolition", Weight = 1 },
        new Value { Name = "Design moves technology to its preferred state", Weight = 1 },
        new Value { Name = "Diplomacy is the first and last solution to anything", Weight = 1 },
        new Value { Name = "Do better, be better", Weight = 1 },
        new Value { Name = "Do not be what others expect of you", Weight = 1 },
        new Value { Name = "Do not cross me", Weight = 1 },
        new Value { Name = "Don’t say it unless you mean it", Weight = 1 },
        new Value { Name = "Driven to ease suffering", Weight = 1 },
        new Value { Name = "Duty before all else", Weight = 1 },
        new Value { Name = "Engineer at heart", Weight = 1 },
        new Value { Name = "Every day is an adventure", Weight = 1 },
        new Value { Name = "Everyone deserves a second chance", Weight = 1 },
        new Value { Name = "Every puzzle has a solution", Weight = 1 },
        new Value { Name = "Everything I have lost, I will regain", Weight = 1 },
        new Value { Name = "Experience will earn me that promotion", Weight = 1 },
        new Value { Name = "Exploration is the blood that fills my veins", Weight = 1 },
        new Value { Name = "Exploring to test new theories", Weight = 1 },
        new Value { Name = "Fail to prepare and you prepare to fail", Weight = 1 },
        new Value { Name = "Family matters", Weight = 1 },
        new Value { Name = "Fast ships and strange new worlds", Weight = 1 },
        new Value { Name = "Fear is as effective as a warship", Weight = 1 },
        new Value { Name = "First, do no harm", Weight = 1 },
        new Value { Name = "First contact? Sign me up!", Weight = 1 },
        new Value { Name = "For every problem, there’s a solution", Weight = 1 },
        new Value { Name = "Friends are the family you choose", Weight = 1 },
        new Value { Name = "From this chair I am in control", Weight = 1 },
        new Value { Name = "Get it done right the first time", Weight = 1 },
        new Value { Name = "Get them before they get you", Weight = 1 },
        new Value { Name = "Go down swinging", Weight = 1 },
        new Value { Name = "Good leaders get their hands dirty", Weight = 1 },
        new Value { Name = "Great men make history", Weight = 1 },
        new Value { Name = "Haunted by the Borg", Weight = 1 },
        new Value { Name = "Holds everyone to the highest standards", Weight = 1 },
        new Value { Name = "Humility is the best path to honesty", Weight = 1 },
        new Value { Name = "Hungry for dangerous situations", Weight = 1 },
        new Value { Name = "I am a man of secrets", Weight = 1 },
        new Value { Name = "I am my own keeper", Weight = 1 },
        new Value { Name = "I am surrounded by a team I trust", Weight = 1 },
        new Value { Name = "I am the unseen hand of Starfleet", Weight = 1 },
        new Value { Name = "I ask of my crew only what I ask of myself", Weight = 1 },
        new Value { Name = "I can always do more for my people", Weight = 1 },
        new Value { Name = "I can make something from nothing", Weight = 1 },
        new Value { Name = "I care too much about what people think of me", Weight = 1 },
        new Value { Name = "I do not like hijinks", Weight = 1 },
        new Value { Name = "I don’t believe in a no-win scenario", Weight = 1 },
        new Value { Name = "I feel the need for speed", Weight = 1 },
        new Value { Name = "I finish what I start", Weight = 1 },
        new Value { Name = "I fix what is broken", Weight = 1 },
        new Value { Name = "I seize opportunity and take what I want", Weight = 1 },
        new Value { Name = "I study war to learn from the best", Weight = 1 },
        new Value { Name = "I will never be defeated", Weight = 1 },
        new Value { Name = "I will not fight for Starfleet, but I will defend its ideals", Weight = 1 },
        new Value { Name = "I’ll try my luck again", Weight = 1 },
        new Value { Name = "I'm a good bad influence", Weight = 1 },
        new Value { Name = "I’m beginning a new life", Weight = 1 },
        new Value { Name = "I’m not going to let anything stop me from getting what I want", Weight = 1 },
        new Value { Name = "If I can help, I will", Weight = 1 },
        new Value { Name = "If we go, we go together", Weight = 1 },
        new Value { Name = "Indefatigable confidence", Weight = 1 },
        new Value { Name = "Inexperienced and idealistic", Weight = 1 },
        new Value { Name = "Information is power", Weight = 1 },
        new Value { Name = "Insatiable curiosity", Weight = 1 },
        new Value { Name = "It’s not illegal if you don’t get caught", Weight = 1 },
        new Value { Name = "Keep a smile on your face no matter how you feel", Weight = 1 },
        new Value { Name = "Knowledge is power, and power is everything", Weight = 1 },
        new Value { Name = "Language is the key to exploring new civilizations", Weight = 1 },
        new Value { Name = "Law is the foundation upon which an orderly society is built", Weight = 1 },
        new Value { Name = "Layer yourself in subtleties", Weight = 1 },
        new Value { Name = "Learn all we can until the fighting begins", Weight = 1 },
        new Value { Name = "Leading in discovery", Weight = 1 },
        new Value { Name = "Life from lifelessness", Weight = 1 },
        new Value { Name = "Life is meant to be lived", Weight = 1 },
        new Value { Name = "Life’s true gift is the capacity to enjoy enjoyment", Weight = 1 },
        new Value { Name = "Listen to opposing viewpoints", Weight = 1 },
        new Value { Name = "Live life to the full", Weight = 1 },
        new Value { Name = "Living with the ghosts of war", Weight = 1 },
        new Value { Name = "Loyalty matters most", Weight = 1 },
        new Value { Name = "Making the galaxy a better place one world at a time", Weight = 1 },
        new Value { Name = "Man or machine? Man and machine", Weight = 1 },
        new Value { Name = "Meticulous scrutiny and pride in their work", Weight = 1 },
        new Value { Name = "More comfortable with engine schematics than people", Weight = 1 },
        new Value { Name = "Most comfortable in a crowd", Weight = 1 },
        new Value { Name = "Most comfortable in the center chair", Weight = 1 },
        new Value { Name = "My crew is my family", Weight = 1 },
        new Value { Name = "My faith will keep me warm", Weight = 1 },
        new Value { Name = "My knowledge is giving you a fighting chance", Weight = 1 },
        new Value { Name = "My lies are the truest of all stories", Weight = 1 },
        new Value { Name = "Never give less than what I’m capable of giving", Weight = 1 },
        new Value { Name = "Never hide who you are", Weight = 1 },
        new Value { Name = "Never leave a stone unturned", Weight = 1 },
        new Value { Name = "Never let others define who you are", Weight = 1 },
        new Value { Name = "No price is too high for security", Weight = 1 },
        new Value { Name = "No regrets for a life lived well", Weight = 1 },
        new Value { Name = "No stranger to violence", Weight = 1 },
        new Value { Name = "Nothing better than practical experience", Weight = 1 },
        new Value { Name = "Nothing is certain", Weight = 1 },
        new Value { Name = "Nothing’s more important than family", Weight = 1 },
        new Value { Name = "On the cutting edge of progress", Weight = 1 },
        new Value { Name = "Our best defense is knowledge", Weight = 1 },
        new Value { Name = "Our first priority is the lives of Federation citizens", Weight = 1 },
        new Value { Name = "Patience is a virtue", Weight = 1 },
        new Value { Name = "Peace can be attained through effort and compromise", Weight = 1 },
        new Value { Name = "People are more than flesh and blood", Weight = 1 },
        new Value { Name = "Precise to a fault", Weight = 1 },
        new Value { Name = "Protecting the Federation is paramount", Weight = 1 },
        new Value { Name = "Proud and honest", Weight = 1 },
        new Value { Name = "Push me too far and you’ll see my ugly side", Weight = 1 },
        new Value { Name = "Rarely refuses an interesting challenge", Weight = 1 },
        new Value { Name = "Resistance is never futile", Weight = 1 },
        new Value { Name = "Respect the chain of command, whether you agree with it or not", Weight = 1 },
        new Value { Name = "Risk is our business", Weight = 1 },
        new Value { Name = "Risk is part of the game if you want the captain’s chair", Weight = 1 },
        new Value { Name = "Sacrifice makes us strong", Weight = 1 },
        new Value { Name = "Safeguard the Federation from all threats", Weight = 1 },
        new Value { Name = "Safety of the family first", Weight = 1 },
        new Value { Name = "Seeking to find myself far from home", Weight = 1 },
        new Value { Name = "Sensors can’t tell you everything", Weight = 1 },
        new Value { Name = "Serving Starfleet is a family tradition", Weight = 1 },
        new Value { Name = "Silent vigilance", Weight = 1 },
        new Value { Name = "Some things don't deserve forgiveness", Weight = 1 },
        new Value { Name = "Sometimes family hurts family", Weight = 1 },
        new Value { Name = "Sometimes hope is a choice", Weight = 1 },
        new Value { Name = "Sometimes you have to take a leap of faith", Weight = 1 },
        new Value { Name = "Space really wants us dead", Weight = 1 },
        new Value { Name = "Spoiling for a fight", Weight = 1 },
        new Value { Name = "Spring into action", Weight = 1 },
        new Value { Name = "Starfleet to the core", Weight = 1 },
        new Value { Name = "Strange new life", Weight = 1 },
        new Value { Name = "Technology is simpler than people", Weight = 1 },
        new Value { Name = "Teamwork makes for success", Weight = 1 },
        new Value { Name = "The academy taught me 10 percent of what I know", Weight = 1 },
        new Value { Name = "The captain’s second opinion", Weight = 1 },
        new Value { Name = "The daily grind is worth it", Weight = 1 },
        new Value { Name = "The ends justify the means", Weight = 1 },
        new Value { Name = "The Federation must be protected at all costs", Weight = 1 },
        new Value { Name = "The first to see those stars up close", Weight = 1 },
        new Value { Name = "The Maquis are a bunch of irresponsible hotheads", Weight = 1 },
        new Value { Name = "The mission comes first", Weight = 1 },
        new Value { Name = "The only way to defeat fear is to tell it 'No'", Weight = 1 },
        new Value { Name = "The price of peace is vigilance", Weight = 1 },
        new Value { Name = "There is no greater enemy than one’s own fears", Weight = 1 },
        new Value { Name = "There is no higher calling than to serve", Weight = 1 },
        new Value { Name = "There’s nothing as important as shaping the next generation", Weight = 1 },
        new Value { Name = "There’s no such thing as the unknown", Weight = 1 },
        new Value { Name = "They will respect my authority", Weight = 1 },
        new Value { Name = "Things don’t always turn out quite the way you expect them to", Weight = 1 },
        new Value { Name = "This job requires a keen mind and an iron will", Weight = 1 },
        new Value { Name = "Threw out the handbook and wrote my own", Weight = 1 },
        new Value { Name = "To achieve high standards, you must expect high standards", Weight = 1 },
        new Value { Name = "To boldly go where no one has gone before", Weight = 1 },
        new Value { Name = "To explore strange new worlds...", Weight = 1 },
        new Value { Name = "Too many people underestimate the threats we face", Weight = 1 },
        new Value { Name = "Understands machines better than people", Weight = 1 },
        new Value { Name = "Understands technology better than people", Weight = 1 },
        new Value { Name = "Universal law is for lackeys", Weight = 1 },
        new Value { Name = "Voice of the crew", Weight = 1 },
        new Value { Name = "We are all connected despite being worlds apart", Weight = 1 },
        new Value { Name = "We are nothing without order and justice", Weight = 1 },
        new Value { Name = "We are stronger united than apart", Weight = 1 },
        new Value { Name = "We didn't come out here to play God", Weight = 1 },
        new Value { Name = "We endure hardship, so that others do not have to", Weight = 1 },
        new Value { Name = "We will take care of ourselves", Weight = 1 },
        new Value { Name = "Well-placed words are deadlier than a phaser", Weight = 1 },
        new Value { Name = "We’ll get it done...", Weight = 1 },
        new Value { Name = "We’re in a war and I intend to win it", Weight = 1 },
        new Value { Name = "What is necessary is never unwise", Weight = 1 },
        new Value { Name = "What matters the most is company", Weight = 1 },
        new Value { Name = "Weird is part of the job", Weight = 1 },
        new Value { Name = "Willing to sacrifice myself to save my crew", Weight = 1 },
        new Value { Name = "With proper discipline, anything is possible", Weight = 1 },
        new Value { Name = "Within the shadows, you are free to move", Weight = 1 },
        new Value { Name = "You can’t let them know what you value", Weight = 1 },
        new Value { Name = "You must not die!", Weight = 1 },
    };
}
