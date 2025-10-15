﻿using StarTrekAdventures.Constants;
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
        new Value { Name = "Life is incomplete without purpose", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        new Value { Name = "Pacifism is not passive", TraitRequirement = SpeciesName.Aenar, Weight = 10 },
        
        new Value { Name = "I always repay my debts", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "No challenge unmet", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "Proud child of Andoria", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        new Value { Name = "Question my word, question my honor", TraitRequirement = SpeciesName.Andorian, Weight = 10 },
        
        new Value { Name = "Fortune favors the faithful", TraitRequirement = SpeciesName.Ankari, Weight = 10 },
        
        new Value { Name = "Propriety first and always", TraitRequirement = SpeciesName.Arbazan, Weight = 10 },
        
        new Value { Name = "Nothing is more beautiful than a city in the sky", TraitRequirement = SpeciesName.Ardanan, Weight = 10 },
        
        new Value { Name = "The law is blind but also fair", TraitRequirement = SpeciesName.Argrathi, Weight = 10 },
        
        new Value { Name = "Dedication and diligence", TraitRequirement = SpeciesName.Arkarian, Weight = 10 },
        
        new Value { Name = "Soar high and achieve greatness", TraitRequirement = SpeciesName.Aurelian, Weight = 10 },
        
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
        
        new Value { Name = "Report only what you know", TraitRequirement = SpeciesName.Benzite, Weight = 10 },
        
        new Value { Name = "A lie is a story told in bad faith", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "Compassion through understanding", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "Do not be what others expect you to be", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "I can feel your pain", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        new Value { Name = "I’m just saying what you’re thinking", TraitRequirement = SpeciesName.Betazoid, Weight = 10 },
        
        new Value { Name = "A broad smile and warm heart", TraitRequirement = SpeciesName.Bolian, Weight = 10 },
        
        new Value { Name = "All others are meant to serve us", TraitRequirement = SpeciesName.Breen, Weight = 5 },
        new Value { Name = "Brutally effective", TraitRequirement = SpeciesName.Breen, Weight = 5 },
        new Value { Name = "My soldiers are my tools", TraitRequirement = SpeciesName.Breen, Weight = 5 },
        
        new Value { Name = "War is instinct, conflict an art", TraitRequirement = SpeciesName.Caitian, Weight = 10 },
        
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
        
        new Value { Name = "The founders are the will of the Dominion", TraitRequirement = SpeciesName.Changeling, Weight = 10 },
        new Value { Name = "My terms are not open to negotiation", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "The Changelings are the Dominion", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "There’s very little that escapes our attention", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        new Value { Name = "What you control can’t hurt you", TraitRequirement = SpeciesName.Changeling, Weight = 5 },
        
        new Value { Name = "Artificial but still alive", TraitRequirement = SpeciesName.CyberneticallyEnhanced, Weight = 10 },
        
        new Value { Name = "Bodies and minds as one", TraitRequirement = SpeciesName.Deltan, Weight = 10 },
        
        new Value { Name = "Comfort in numbers", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "My patience exceeds your stubbornness", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "There's always someone new to meet", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        new Value { Name = "You cannot truly learn about people unless you talk to them", TraitRequirement = SpeciesName.Denobulan, Weight = 10 },
        
        new Value { Name = "I have already proven myself the victor", TraitRequirement = SpeciesName.Dosi, Weight = 10 },
        
        new Value { Name = "There are no challenges like the hunt", TraitRequirement = SpeciesName.Drai, Weight = 10 },
        new Value { Name = "Cold-blooded killer", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "The hunt is everything", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "They are insignificant in the eyes of the Dominion", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        new Value { Name = "We shall succeed at all costs", TraitRequirement = SpeciesName.Drai, Weight = 5 },
        
        new Value { Name = "Perspective brings understanding", TraitRequirement = SpeciesName.Edosian, Weight = 10 },
        
        new Value { Name = "Specialization furthers knowledge", TraitRequirement = SpeciesName.Efrosian, Weight = 10 },
        
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
        
        new Value { Name = "Patient study yields the best results", TraitRequirement = SpeciesName.Grazerite, Weight = 10 },
        
        new Value { Name = "Many sides to every tale", TraitRequirement = SpeciesName.Haliian, Weight = 10 },
        
        new Value { Name = "I believe in what the Federation stands for", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "Learn something new every day", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "Seek out new life and new civilizations", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "The drive for exploration", TraitRequirement = SpeciesName.Human, Weight = 10 },
        new Value { Name = "We are stronger together", TraitRequirement = SpeciesName.Human, Weight = 10 },
        
        new Value { Name = "All traitors must be accounted for", TraitRequirement = SpeciesName.JemHadar, Weight = 5 },
        new Value { Name = "Loyalty to the founders, now and always", TraitRequirement = SpeciesName.JemHadar, Weight = 5 },
        new Value { Name = "We are now dead; we go into battle to reclaim our lives", TraitRequirement = SpeciesName.JemHadar, Weight = 5 },
        
        new Value { Name = "Perfection by the numbers", TraitRequirement = SpeciesName.Jye, Weight = 10 },
        
        new Value { Name = "I see your true worth", TraitRequirement = SpeciesName.Karemma, Weight = 10 },
        
        new Value { Name = "The great balance must be achieved", TraitRequirement = SpeciesName.KelpianPostVaharai, Weight = 10 },
        
        new Value { Name = "The great balance must be achieved", TraitRequirement = SpeciesName.KelpianPreVaharai, Weight = 10 },
        
        new Value { Name = "Honor is more important than life", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "I am a Klingon warrior; if you doubt it, a demonstration can be arranged!", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Own the day!", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
        new Value { Name = "Revenge is a dish best served cold", TraitRequirement = SpeciesName.Klingon, Weight = 10 },
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
        
        new Value { Name = "Hold the course until the end", TraitRequirement = SpeciesName.Ktarian, Weight = 10 },
        
        new Value { Name = "What does it mean to be an individual?", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 10 },
        new Value { Name = "Borg are more than the collective, and I will show them", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 5 },
        new Value { Name = "I have known freedom and will have it again", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 5 },
        new Value { Name = "I must do as my programming instructs", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 5 },
        new Value { Name = "Resistance is not futile", TraitRequirement = SpeciesName.LiberatedBorg, Weight = 5 },
        
        new Value { Name = "Our creations will submit", TraitRequirement = SpeciesName.Lokirrim, Weight = 10 },
        
        new Value { Name = "Belly full of song and heart full of glory", TraitRequirement = SpeciesName.Lurian, Weight = 10 },
        
        new Value { Name = "Peace in mind and action", TraitRequirement = SpeciesName.Mari, Weight = 10 },
        
        new Value { Name = "Space – the greatest ocean of all", TraitRequirement = SpeciesName.Monean, Weight = 10 },
        
        new Value { Name = "All others are weak", TraitRequirement = SpeciesName.Nausicaan, Weight = 10 },
        
        new Value { Name = "See all that life has to offer", TraitRequirement = SpeciesName.Ocampa, Weight = 10 },
        
        new Value { Name = "Everything has a price", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "I am not who you expect me to be", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "I thrive because I do not ignore opportunities", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        new Value { Name = "Your expectations limit you", TraitRequirement = SpeciesName.Orion, Weight = 10 },
        
        new Value { Name = "I am as strong apart as I am with others", TraitRequirement = SpeciesName.Osnullus, Weight = 10 },
        
        new Value { Name = "I am original and that gives me strength", TraitRequirement = SpeciesName.Paradan, Weight = 10 },
        
        new Value { Name = "Victory or death", TraitRequirement = SpeciesName.Pendari, Weight = 10 },
        
        new Value { Name = "I make the rules and you obey them", TraitRequirement = SpeciesName.Rakhari, Weight = 10 },
        
        new Value { Name = "My life for my charge", TraitRequirement = SpeciesName.Reman, Weight = 5 },
        
        new Value { Name = "Real power is in the service of others", TraitRequirement = SpeciesName.RigellianChelon, Weight = 10 },
        new Value { Name = "Governance and trade for the prosperity of all", TraitRequirement = SpeciesName.RigellianJelna, Weight = 10 },
        
        new Value { Name = "All that is ours is yours", TraitRequirement = SpeciesName.Risian, Weight = 10 },
        
        new Value { Name = "Even my secrets have secrets!", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Every secret I discover is another weapon in my arsenal", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "I give my life to the service of the empire", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Secrecy is a shield against betrayal", TraitRequirement = SpeciesName.Romulan, Weight = 10 },
        new Value { Name = "Everything I do, I do for Romulus", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "I will not fail in my duty to the Empire", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "My people should be free", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "My portion is obedience", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "War is bought with blood", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        new Value { Name = "Outlanders are people, too", TraitRequirement = SpeciesName.Romulan, Weight = 5 },
        
        new Value { Name = "Consider carefully, then act decisively", TraitRequirement = SpeciesName.Saurian, Weight = 10 },
        
        new Value { Name = "Welcome all travelers", TraitRequirement = SpeciesName.Sikarian, Weight = 10 },
        
        new Value { Name = "The tide always breaks upon the shore and the shore endures", TraitRequirement = SpeciesName.Skreeaa, Weight = 10 },
        
        new Value { Name = "We do what we must", TraitRequirement = SpeciesName.Sona, Weight = 10 },

        new Value { Name = "A whole Galaxy to explore and experience", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },
        new Value { Name = "Ethical programming defines my thinking", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },
        new Value { Name = "Just because I am synthetic doesn’t mean I’m not a person", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },
        new Value { Name = "Know a man by his friends", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },
        new Value { Name = "Vast repository of information", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },
        new Value { Name = "•\tWhat does it mean to be alive?", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },
        new Value { Name = "What is it to be human?", AnyTraitRequirement = { SpeciesName.Android, SpeciesName.CoppeliusAndroid, SpeciesName.SoongTypeAndroid }, Weight = 10 },

        new Value { Name = "Only fools take risks", TraitRequirement = SpeciesName.Talaxian, Weight = 10 },
        
        new Value { Name = "An idea left unchallenged can be dangerous", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "No notion is above proper scrutiny", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "No voice silenced, no perspective unheard", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        new Value { Name = "You’ll never get an answer if you don’t ask questions", TraitRequirement = SpeciesName.Tellarite, Weight = 10 },
        
        new Value { Name = "Several lifetimes of adventure", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined", Weight = 20 },
        new Value { Name = "Even a 400-year-old explorer can find something new", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined", Weight = 5 },
        new Value { Name = "What will this mean a century from now?", TraitRequirement = SpeciesName.Trill, Weight = 10 },
        new Value { Name = "What can I discover today?", TraitRequirement = SpeciesName.Trill, Weight = 10 },
        new Value { Name = "Who I was is only part of who I am", TraitRequirement = SpeciesName.Trill, TalentRequirement = "Joined", Weight = 10 },
        
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
        new Value { Name = "Proud of the Vulcan way", TraitRequirement = SpeciesName.Vulcan, Weight = 5 },
        
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
