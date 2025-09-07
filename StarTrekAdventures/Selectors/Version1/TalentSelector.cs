using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models.Version1;
using System.Collections.Generic;
using System.Linq;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors.Version1
{
    public class TalentSelector
    {
        public static Talent ChooseTalent(Character character, LifepathStage lifepathStage, List<Species> species = null, Experience career = null)
        {
            var availableTalents = new List<Talent>();

            if (lifepathStage == LifepathStage.Species && species != null)
            {
                if (species.First().MustTakeRacialTalentInStepOne)
                {
                    foreach (var talent in Talents)
                    {
                        if (character.Traits.Any(x => x == talent.TraitRequirement) &&
                            !character.Talents.Any(x => x.Name == talent.Name))

                            availableTalents.Add(talent);
                    }

                    return availableTalents.OrderBy(n => Util.GetRandom()).First();
                }

                if (!string.IsNullOrWhiteSpace(species.First().MustTakeSpecificTalentInStepOne))
                    return GetTalent(species.First().MustTakeSpecificTalentInStepOne);
            }

            if (lifepathStage == LifepathStage.Upbringing && species != null && !string.IsNullOrWhiteSpace(species.First().MustTakeAnotherSpecificTalentInStepOne))
            {
                return GetTalent(species.First().MustTakeAnotherSpecificTalentInStepOne);
            }

            if (lifepathStage == LifepathStage.Career && !string.IsNullOrEmpty(career.Talent))
            {
                return GetTalent(career.Talent);
            }

            var weightedTalentsList = new WeightedList<Talent>();

            foreach (var talent in Talents)
            {
                if (CanTakeTalent(character, talent))
                    weightedTalentsList.AddEntry(talent, talent.Weight);
            }

            return weightedTalentsList.GetRandom();
        }

        private static bool CanTakeTalent(Character character, Talent talent)
        {
            var gmPermission = Util.GetRandom(100) == 1;

            if (character.Talents.Any(x => x.Name == talent.Name))
                return false;

            if (!talent.MayBeSelected)
                return false;

            if (!string.IsNullOrEmpty(talent.TraitRequirement))
            {
                if (!gmPermission && !character.Traits.Any(x => x == talent.TraitRequirement))
                    return false;
            }

            if (string.IsNullOrEmpty(talent.TraitRequirement) && talent.GMPermission && !gmPermission)
                return false;

            if (!string.IsNullOrEmpty(talent.FocusRequirement))
            {
                if (!character.Focuses.Any(x => x == talent.FocusRequirement))
                    return false;
            }

            if (!string.IsNullOrEmpty(talent.TalentRequirement))
            {
                if (!character.Talents.Any(x => x.Name == talent.TalentRequirement))
                    return false;
            }

            if (!string.IsNullOrEmpty(talent.MayNotTakeWithTalent))
            {
                if (character.Talents.Any(x => x.Name == talent.MayNotTakeWithTalent))
                    return false;
            }

            if (talent.DiscplineRequirements != null)
            {
                if (talent.DiscplineRequirements.Operator == Operator.None || talent.DiscplineRequirements.Operator == Operator.And)
                {
                    if (character.Disciplines.Command < talent.DiscplineRequirements.Command ||
                        character.Disciplines.Conn < talent.DiscplineRequirements.Conn ||
                        character.Disciplines.Engineering < talent.DiscplineRequirements.Engineering ||
                        character.Disciplines.Medicine < talent.DiscplineRequirements.Medicine ||
                        character.Disciplines.Science < talent.DiscplineRequirements.Science ||
                        character.Disciplines.Security < talent.DiscplineRequirements.Security)
                        return false;
                }

                if (talent.DiscplineRequirements.Operator == Operator.Or)
                {
                    var allowed = false;

                    if (talent.DiscplineRequirements.Command > 1 && (character.Disciplines.Command > talent.DiscplineRequirements.Command) ||
                        talent.DiscplineRequirements.Conn > 1 && (character.Disciplines.Conn > talent.DiscplineRequirements.Conn) ||
                        talent.DiscplineRequirements.Engineering > 1 && (character.Disciplines.Engineering > talent.DiscplineRequirements.Engineering) ||
                        talent.DiscplineRequirements.Medicine > 1 && (character.Disciplines.Medicine > talent.DiscplineRequirements.Medicine) ||
                        talent.DiscplineRequirements.Science > 1 && (character.Disciplines.Science > talent.DiscplineRequirements.Science) ||
                        talent.DiscplineRequirements.Security > 1 && (character.Disciplines.Security > talent.DiscplineRequirements.Security))
                        allowed = true;

                    if (!allowed)
                        return false;
                }

                if (talent.AttributeRequirements != null)
                {
                    if (character.Attributes.Control < talent.AttributeRequirements.Control ||
                        character.Attributes.Daring < talent.AttributeRequirements.Daring ||
                        character.Attributes.Fitness < talent.AttributeRequirements.Fitness ||
                        character.Attributes.Insight < talent.AttributeRequirements.Insight ||
                        character.Attributes.Presence < talent.AttributeRequirements.Presence ||
                        character.Attributes.Reason < talent.AttributeRequirements.Reason)
                        return false;
                }
            }

            return true;
        }

        public static Talent GetTalent(string name)
        {
            return Talents.First(x => x.Name == name);
        }

        private static readonly List<Talent> Talents = new List<Talent>
        {
            new Talent { Name = "Proud and Honorable", TraitRequirement = SpeciesName.Andorian, GMPermission = true, Weight = 10 },
            new Talent { Name = "The Ushaan", TraitRequirement = SpeciesName.Andorian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Favored by Fortune", TraitRequirement = SpeciesName.Ankari, GMPermission = true, Weight = 10 },
            new Talent { Name = "Vibration Senses", TraitRequirement = SpeciesName.Ankari, GMPermission = true, Weight = 10 },

            new Talent { Name = "Cold Shoulder", TraitRequirement = SpeciesName.Arbazan, GMPermission = true, Weight = 10 },
            new Talent { Name = "The Protocol of Politics", TraitRequirement = SpeciesName.Arbazan, GMPermission = true, Weight = 10 },

            new Talent { Name = "Above the Clouds", TraitRequirement = SpeciesName.Ardanan, GMPermission = true, Weight = 10 },
            new Talent { Name = "Zemite in the Soul", TraitRequirement = SpeciesName.Ardanan, GMPermission = true, Weight = 10 },

            new Talent { Name = "Absolute Conviction", TraitRequirement = SpeciesName.Argrathi, GMPermission = true, Weight = 10 },
            new Talent { Name = "Mind Games", TraitRequirement = SpeciesName.Argrathi, GMPermission = true, Weight = 10 },

            new Talent { Name = "Cool Under Pressure", TraitRequirement = SpeciesName.Arkarian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Quick Recovery", TraitRequirement = SpeciesName.Arkarian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Aerial Combat", TraitRequirement = SpeciesName.Aurelian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Keen Senses", TraitRequirement = SpeciesName.Aurelian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Orb Experience", TraitRequirement = SpeciesName.Bajoran, GMPermission = true, AdditionalValues = 1, Weight = 10 },
            new Talent { Name = "Strong Pagh", TraitRequirement = SpeciesName.Bajoran, GMPermission = true, Weight = 10 },

            new Talent { Name = "Expert Quartermaster", TraitRequirement = SpeciesName.Barzan, GMPermission = true, Weight = 10 },
            new Talent { Name = "Unyielding Resolve", TraitRequirement = SpeciesName.Barzan, GMPermission = true, Weight = 10 },

            new Talent { Name = "Meticulous Analysis", TraitRequirement = SpeciesName.Benzite, GMPermission = true, Weight = 10 },
            new Talent { Name = "All Fingers and Thumbs", TraitRequirement = SpeciesName.Benzite, GMPermission = true, Weight = 10 },

            new Talent { Name = "Empath", TraitRequirement = SpeciesName.Betazoid, GMPermission = true, Weight = 10 },
            new Talent { Name = "Telepath", TraitRequirement = SpeciesName.Betazoid, GMPermission = true, MixedHeritageAllowed = false, Weight = 10 },

            new Talent { Name = "Born Near a Warp Core", TraitRequirement = SpeciesName.Bolian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Warm Welcome", TraitRequirement = SpeciesName.Bolian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Disarming Nature", TraitRequirement = SpeciesName.Caitian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Prehensile Tail", TraitRequirement = SpeciesName.Caitian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Duty and Discipline", TraitRequirement = SpeciesName.Cardassian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Suspicious by Nature", TraitRequirement = SpeciesName.Cardassian, GMPermission = true, Weight = 10 },
            new Talent { Name = "The Ends Justify the Means", TraitRequirement = SpeciesName.Cardassian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Morphogenic Matrix", TraitRequirement = SpeciesName.Changeling, GMPermission = true, Weight = 10 },
            new Talent { Name = "Morphogenic Mastery", TraitRequirement = SpeciesName.Changeling, GMPermission = true, Weight = 10 },

            new Talent { Name = "Synthetic Physiology", TraitRequirement = SpeciesName.CyberneticallyEnhanced, GMPermission = true, Weight = 10 },
            new Talent { Name = "Analytical Recall", TraitRequirement = SpeciesName.CyberneticallyEnhanced, GMPermission = true, Weight = 10 },

            new Talent { Name = "Deltan Pheromones", TraitRequirement = SpeciesName.Deltan, GMPermission = true, Weight = 10 },
            new Talent { Name = "Empath", TraitRequirement = SpeciesName.Deltan, GMPermission = true, Weight = 10 },

            new Talent { Name = "Cultural Flexibility", TraitRequirement = SpeciesName.Denobulan, GMPermission = true, Weight = 10 },
            new Talent { Name = "Parent Figure", TraitRequirement = SpeciesName.Denobulan, GMPermission = true, Weight = 10 },

            new Talent { Name = "Strength and Cunning", TraitRequirement = SpeciesName.Dosi, GMPermission = true, Weight = 10 },
            new Talent { Name = "Glorious Notoriety", TraitRequirement = SpeciesName.Dosi, GMPermission = true, Weight = 10 },

            new Talent { Name = "Genetic Mastery", TraitRequirement = SpeciesName.Drai, GMPermission = true, Weight = 10 },
            new Talent { Name = "Born Stalker", TraitRequirement = SpeciesName.Drai, GMPermission = true, Weight = 10 },

            new Talent { Name = "Multi-Tasking", TraitRequirement = SpeciesName.Edosian, GMPermission = true, Weight = 10 },
            new Talent { Name = "The Long View", TraitRequirement = SpeciesName.Edosian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Oral Scholar", TraitRequirement = SpeciesName.Efrosian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Visual Spectrum", TraitRequirement = SpeciesName.Efrosian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Every Man Has His Price", TraitRequirement = SpeciesName.Ferengi, GMPermission = true, Weight = 10 },
            new Talent { Name = "Hear All, Trust Nothing", TraitRequirement = SpeciesName.Ferengi, GMPermission = true, Weight = 10 },
            new Talent { Name = "Knowledge Equals Profit", TraitRequirement = SpeciesName.Ferengi, GMPermission = true, Weight = 10 },

            new Talent { Name = "Communal", TraitRequirement = SpeciesName.Grazerite, GMPermission = true, Weight = 10 },
            new Talent { Name = "Horn-Sense", TraitRequirement = SpeciesName.Grazerite, GMPermission = true, Weight = 10 },

            new Talent { Name = "Contact Empathy", TraitRequirement = SpeciesName.Haliian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Faceted Attention", TraitRequirement = SpeciesName.Haliian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Resolute", TraitRequirement = SpeciesName.Human, GMPermission = true, StressModifier = 3, Weight = 10 },
            new Talent { Name = "Spirit of Discovery", TraitRequirement = SpeciesName.Human, GMPermission = true, Weight = 10 },

            new Talent { Name = "Maximized Efficiency", TraitRequirement = SpeciesName.Ankari, GMPermission = true, Weight = 10 },
            new Talent { Name = "Natural Coordinator", TraitRequirement = SpeciesName.Ankari, GMPermission = true, Weight = 10 },

            new Talent { Name = "My Honor is my Shield", TraitRequirement = SpeciesName.Karemma, GMPermission = true, Weight = 10 },
            new Talent { Name = "Instant Appraisal", TraitRequirement = SpeciesName.Karemma, GMPermission = true, Weight = 10 },

            new Talent { Name = "Threat Ganglia", TraitRequirement = SpeciesName.KelpianPostVaharai, Weight = 10 },
            new Talent { Name = "On all Fours", TraitRequirement = SpeciesName.KelpianPostVaharai, GMPermission = true, Weight = 10 },

            new Talent { Name = "Threat Ganglia", TraitRequirement = SpeciesName.KelpianPreVaharai, Weight = 10 },
            new Talent { Name = "On all Fours", TraitRequirement = SpeciesName.KelpianPreVaharai, GMPermission = true, Weight = 10 },

            new Talent { Name = "Brak'lul", TraitRequirement = SpeciesName.Klingon, GMPermission = true, Weight = 10 },
            new Talent { Name = "R'uustai", TraitRequirement = SpeciesName.Klingon, AdditionalValues = 1, GMPermission = true, Weight = 10 },
            new Talent { Name = "To Battle!", TraitRequirement = SpeciesName.Klingon, GMPermission = true, Weight = 10 },

            new Talent { Name = "Deep Determination", TraitRequirement = SpeciesName.Ktarian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Negotiate From Strength", TraitRequirement = SpeciesName.Ktarian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Borg Implants", TraitRequirement = SpeciesName.LiberatedBorg, GMPermission = true, BorgImplants = true, Weight = 10 },
            new Talent { Name = "Direct Neural Interface", TraitRequirement = SpeciesName.LiberatedBorg, GMPermission = true, Weight = 10 },

            new Talent { Name = "Hologram Master", TraitRequirement = SpeciesName.Lokirrim, GMPermission = true, Weight = 10 },
            new Talent { Name = "Photonic Prosecutor", TraitRequirement = SpeciesName.Lokirrim, GMPermission = true, Weight = 10 },

            new Talent { Name = "Into the Breach", TraitRequirement = SpeciesName.Lurian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Resistant Anatomy", TraitRequirement = SpeciesName.Lurian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Empath", TraitRequirement = SpeciesName.Mari, GMPermission = true, Weight = 10 },
            new Talent { Name = "Passive Persuader", TraitRequirement = SpeciesName.Mari, GMPermission = true, Weight = 10 },

            new Talent { Name = "Nomadic Heritage", TraitRequirement = SpeciesName.Monean, GMPermission = true, Weight = 10 },
            new Talent { Name = "Submariner", TraitRequirement = SpeciesName.Monean, GMPermission = true, Weight = 10 },

            new Talent { Name = "Quick Learner", TraitRequirement = SpeciesName.Ocampa, GMPermission = true, Weight = 10 },
            new Talent { Name = "Telepath", TraitRequirement = SpeciesName.Ocampa, GMPermission = true, Weight = 10 },

            new Talent { Name = "Born to a Task", TraitRequirement = SpeciesName.Osnullus, Weight = 10 },
            new Talent { Name = "Unreadable Face", TraitRequirement = SpeciesName.Osnullus, Weight = 10 },

            new Talent { Name = "Replicating Past Success", TraitRequirement = SpeciesName.Paradan, GMPermission = true, Weight = 10 },
            new Talent { Name = "Distracting Senses", TraitRequirement = SpeciesName.Paradan, GMPermission = true, Weight = 10 },

            new Talent { Name = "Born to Fight", TraitRequirement = SpeciesName.Pendari, GMPermission = true, Weight = 10 },
            new Talent { Name = "Robust Physiology", TraitRequirement = SpeciesName.Pendari, GMPermission = true, Weight = 10 },

            new Talent { Name = "The Truth of the Matter", TraitRequirement = SpeciesName.Rakhari, GMPermission = true, Weight = 10 },
            new Talent { Name = "Disciplined Mind", TraitRequirement = SpeciesName.Rakhari, GMPermission = true, Weight = 10 },

            new Talent { Name = "Chelon Shell", TraitRequirement = SpeciesName.RigellianChelon, GMPermission = true, Weight = 10 },
            new Talent { Name = "Toxic Claws", TraitRequirement = SpeciesName.RigellianChelon, GMPermission = true, Weight = 10 },
            new Talent { Name = "Exosex", TraitRequirement = SpeciesName.RigellianJelna, GMPermission = true, Weight = 10 },
            new Talent { Name = "Industrious Mind", TraitRequirement = SpeciesName.RigellianJelna, GMPermission = true, Weight = 10 },

            new Talent { Name = "Open and Insightful", TraitRequirement = SpeciesName.Risian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Peaceful Existence", TraitRequirement = SpeciesName.Risian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Enhanced Metabolism", TraitRequirement = SpeciesName.Saurian, Weight = 10 },
            new Talent { Name = "Hunter's Senses", TraitRequirement = SpeciesName.Saurian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Canonic Law", TraitRequirement = SpeciesName.Sikarian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Riveting Storyteller", TraitRequirement = SpeciesName.Sikarian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Well Regarded", TraitRequirement = SpeciesName.Sikarian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Agricultural Specialist", TraitRequirement = SpeciesName.Skreeaa, GMPermission = true, Weight = 10 },
            new Talent { Name = "Strength Through Struggle", TraitRequirement = SpeciesName.Skreeaa, GMPermission = true, Weight = 10 },

            new Talent { Name = "At all Costs", TraitRequirement = SpeciesName.Sona, GMPermission = true, Weight = 10 },
            new Talent { Name = "Particle Engineering", TraitRequirement = SpeciesName.Sona, GMPermission = true, Weight = 10 },

            new Talent { Name = "Polyalloy Construction", TraitRequirement = SpeciesName.SoongTypeAndroid, GMPermission = true, Weight = 10 },
            new Talent { Name = "Positronic Brain", TraitRequirement = SpeciesName.SoongTypeAndroid, GMPermission = true, Weight = 10 },

            new Talent { Name = "Being of Many Talents", TraitRequirement = SpeciesName.Talaxian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Infectous Nature", TraitRequirement = SpeciesName.Talaxian, GMPermission = true, Weight = 10 },
            new Talent { Name = "Widely Travelled", TraitRequirement = SpeciesName.Talaxian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Incisive Scrutiny", TraitRequirement = SpeciesName.Tellarite, GMPermission = true, Weight = 10 },
            new Talent { Name = "Sturdy", TraitRequirement = SpeciesName.Tellarite, GMPermission = true, Weight = 10 },

            new Talent { Name = "Survivor's Luck", TraitRequirement = SpeciesName.Tosk, GMPermission = true, Weight = 10 },
            new Talent { Name = "Last Breath", TraitRequirement = SpeciesName.Tosk, GMPermission = true, Weight = 10 },

            new Talent { Name = "Former Initiate", TraitRequirement = SpeciesName.Trill, GMPermission = true, MayNotTakeWithTalent = "Joined", Weight = 10 },
            new Talent { Name = "Joined", TraitRequirement = SpeciesName.Trill, GMPermission = true, Symbiote = true, MayNotTakeWithTalent = "Former Initiate", Weight = 10 },

            new Talent { Name = "Deep Determination", TraitRequirement = SpeciesName.Turei, GMPermission = true, Weight = 10 },
            new Talent { Name = "Underdweller", TraitRequirement = SpeciesName.Turei, GMPermission = true, Weight = 10 },

            new Talent { Name = "Discerning Scientific Mind", TraitRequirement = SpeciesName.Xahean, GMPermission = true, Weight = 10 },
            new Talent { Name = "Camouflage Field", TraitRequirement = SpeciesName.Xahean, Weight = 10 },

            new Talent { Name = "Calm Under Pressure", TraitRequirement = SpeciesName.XindiArboreal, GMPermission = true, Weight = 10 },
            new Talent { Name = "Protective Instinct", TraitRequirement = SpeciesName.XindiInsectoid, GMPermission = true, Weight = 10 },
            new Talent { Name = "A Mind for Design", TraitRequirement = SpeciesName.XindiPrimate, GMPermission = true, Weight = 10 },
            new Talent { Name = "Stun Resistance", TraitRequirement = SpeciesName.XindiReptilian, GMPermission = true, Weight = 10 },

            new Talent { Name = "Kolinahr", TraitRequirement = SpeciesName.Vulcan, GMPermission = true, Weight = 10 },
            new Talent { Name = "Mind-Meld", TraitRequirement = SpeciesName.Vulcan, GMPermission = true, Weight = 10 },
            new Talent { Name = "Nerve Pinch", TraitRequirement = SpeciesName.Vulcan, GMPermission = true, Weight = 10 },

            new Talent { Name = "Come with me", TraitRequirement = SpeciesName.Wadi, GMPermission = true, Weight = 10 },
            new Talent { Name = "Life is a Game", TraitRequirement = SpeciesName.Wadi, GMPermission = true, Weight = 10 },

            new Talent { Name = "Thermal Regulation", TraitRequirement = SpeciesName.Zahl, GMPermission = true, Weight = 10 },
            new Talent { Name = "Warm Welcome", TraitRequirement = SpeciesName.Zahl, GMPermission = true, Weight = 10 },

            new Talent { Name = "Master Strategist", TraitRequirement = SpeciesName.Zakdorn, GMPermission = true, Weight = 10 },
            new Talent { Name = "Tactical Voice", TraitRequirement = SpeciesName.Zakdorn, GMPermission = true, Weight = 10 },

            new Talent { Name = "Hardened Hide", TraitRequirement = SpeciesName.Zaranite, GMPermission = true, Weight = 10 },
            new Talent { Name = "Multispectrum Vision", TraitRequirement = SpeciesName.Zaranite, GMPermission = true, Weight = 10 },

            new Talent { Name = "Bold (Control)", MayNotTakeWithTalent = "Cautious (Control)", Weight = 1 },
            new Talent { Name = "Bold (Daring)", MayNotTakeWithTalent = "Cautious (Daring)", Weight = 1  },
            new Talent { Name = "Bold (Fitness)", MayNotTakeWithTalent = "Cautious (Fitness)", Weight = 1  },
            new Talent { Name = "Bold (Insight)", MayNotTakeWithTalent = "Cautious (Insight)", Weight = 1  },
            new Talent { Name = "Bold (Presence)", MayNotTakeWithTalent = "Cautious (Presence)", Weight = 1  },
            new Talent { Name = "Bold (Reason)", MayNotTakeWithTalent = "Cautious (Reason)", Weight = 1  },
            new Talent { Name = "Cautious (Control)", MayNotTakeWithTalent = "Bold (Control)", Weight = 1 },
            new Talent { Name = "Cautious (Daring)", MayNotTakeWithTalent = "Bold (Daring)", Weight = 1  },
            new Talent { Name = "Cautious (Fitness)", MayNotTakeWithTalent = "Bold (Fitness)", Weight = 1  },
            new Talent { Name = "Cautious (Insight)", MayNotTakeWithTalent = "Bold (Insight)", Weight = 1  },
            new Talent { Name = "Cautious (Presence)", MayNotTakeWithTalent = "Bold (Presence)", Weight = 1  },
            new Talent { Name = "Cautious (Reason)", MayNotTakeWithTalent = "Bold (Reason)", Weight = 1  },
            new Talent { Name = "Discipline (Command)", Weight = 1 },
            new Talent { Name = "Discipline (Conn)", Weight = 1 },
            new Talent { Name = "Discipline (Engineering)", Weight = 1 },
            new Talent { Name = "Discipline (Security)", Weight = 1 },
            new Talent { Name = "Discipline (Science)", Weight = 1 },
            new Talent { Name = "Discipline (Medicine)", Weight = 1 },
            new Talent { Name = "Collaboration (Command)", Weight = 1},
            new Talent { Name = "Collaboration (Conn)", Weight = 1 },
            new Talent { Name = "Collaboration (Engineering)", Weight = 1 },
            new Talent { Name = "Collaboration (Security)", Weight = 1 },
            new Talent { Name = "Collaboration (Science)", Weight = 1 },
            new Talent { Name = "Collaboration (Medicine)", Weight = 1 },
            new Talent { Name = "Constantly Watching", Weight = 1 },
            new Talent { Name = "Dauntless", Weight = 1 },
            new Talent { Name = "Field Medicine", Weight = 1 },
            new Talent { Name = "Flight Controller", Weight = 1 },
            new Talent { Name = "Mean Right Hook", Weight = 1 },
            new Talent { Name = "Pack Tactics", Weight = 1 },
            new Talent { Name = "Personal Effects", Weight = 1 },
            new Talent { Name = "Studious", Weight = 1 },
            new Talent { Name = "Supervisor", Weight = 1 },
            new Talent { Name = "Technical Expertise", Weight = 1 },
            new Talent { Name = "Tough", Weight = 1 },

            new Talent { Name = "Augmented Control", GMPermission = true, TraitGained = Trait.Augmented, Weight = 1 },
            new Talent { Name = "Augmented Daring", GMPermission = true, TraitGained = Trait.Augmented, Weight = 1 },
            new Talent { Name = "Augmented Fitness", GMPermission = true, TraitGained = Trait.Augmented, Weight = 1 },
            new Talent { Name = "Augmented Insight", GMPermission = true, TraitGained = Trait.Augmented, Weight = 1 },
            new Talent { Name = "Augmented Presence", GMPermission = true, TraitGained = Trait.Augmented, Weight = 1},
            new Talent { Name = "Augmented Reason", GMPermission = true, TraitGained = Trait.Augmented, Weight = 1  },
            new Talent { Name = "Neural Interface", Weight = 1  },
            new Talent { Name = "Physical Enhancement", Weight = 1  },
            new Talent { Name = "Sensory Replacement (Sight)", TraitGained = Trait.ArtificalSight, Weight = 1  },
            new Talent { Name = "Sensory Replacement (Hearing)", TraitGained = Trait.ArtificalHearing, Weight = 1  },
            new Talent { Name = "Sensory Replacement (Touch)", TraitGained = Trait.ArtificalTouch, Weight = 1  },
            new Talent { Name = "Sensory Replacement (Smell)", TraitGained = Trait.ArtificalSmell, Weight = 1  },
            new Talent { Name = "Sensory Replacement (Taste)", TraitGained = Trait.ArtificalTaste, Weight = 1  },

            new Talent { Name = "Untapped Potential", MayBeSelected = false, Weight = 1 },
            new Talent { Name = "Veteran", MayBeSelected = false, Weight = 1 },

            new Talent { Name = "Advisor", DiscplineRequirements = new DisciplineRequirements { Command = 2 }, Weight = 4 },
            new Talent { Name = "Bargain", DiscplineRequirements = new DisciplineRequirements { Command = 3 }, Weight = 6 },
            new Talent { Name = "Call to Action", DiscplineRequirements = new DisciplineRequirements { Command = 3 }, Weight = 6 },
            new Talent { Name = "Cold Reading", DiscplineRequirements = new DisciplineRequirements { Command = 4 }, Weight = 8 },
            new Talent { Name = "Coordinated Efforts", DiscplineRequirements = new DisciplineRequirements { Command = 4 }, Weight = 8 },
            new Talent { Name = "Decisive Leadership", DiscplineRequirements = new DisciplineRequirements { Command = 4 }, Weight = 8 },
            new Talent { Name = "Defuse the Tension", DiscplineRequirements = new DisciplineRequirements { Command = 3 }, Weight = 6 },
            new Talent { Name = "Fleet Commander", DiscplineRequirements = new DisciplineRequirements { Command = 4 }, Weight = 8 },
            new Talent { Name = "Follow My Lead", DiscplineRequirements = new DisciplineRequirements { Command = 3 }, Weight = 6 },
            new Talent { Name = "Multi-Discipline", DiscplineRequirements = new DisciplineRequirements { Command = 3 }, Weight = 6 },
            new Talent { Name = "Plan of Action", DiscplineRequirements = new DisciplineRequirements { Command = 4 }, Weight = 8 },
            new Talent { Name = "Time Management", DiscplineRequirements = new DisciplineRequirements { Command = 4 }, Weight = 8 },

            new Talent { Name = "Attack Run", DiscplineRequirements = new DisciplineRequirements { Conn = 4 }, Weight = 8 },
            new Talent { Name = "Covering Advance", DiscplineRequirements = new DisciplineRequirements { Conn = 2 }, Weight = 4 },
            new Talent { Name = "Efficient Evasion", DiscplineRequirements = new DisciplineRequirements { Conn = 2 }, Weight = 4 },
            new Talent { Name = "Fly-By", DiscplineRequirements = new DisciplineRequirements { Conn = 2 }, Weight = 4 },
            new Talent { Name = "Glancing Impact", DiscplineRequirements = new DisciplineRequirements { Conn = 4 }, Weight = 8 },
            new Talent { Name = "Inertia", DiscplineRequirements = new DisciplineRequirements { Conn = 3 }, Weight = 6 },
            new Talent { Name = "Multi-Tasking", DiscplineRequirements = new DisciplineRequirements { Conn = 2 }, Weight = 4 },
            new Talent { Name = "Pathfinder", DiscplineRequirements = new DisciplineRequirements { Conn = 4 }, Weight = 8 },
            new Talent { Name = "Precise Evaluation", DiscplineRequirements = new DisciplineRequirements { Conn = 4 }, Weight = 8 },
            new Talent { Name = "Precision Maneuvering", DiscplineRequirements = new DisciplineRequirements { Conn = 4 }, Weight = 8 },
            new Talent { Name = "Push the Limits", DiscplineRequirements = new DisciplineRequirements { Conn = 4 }, Weight = 8 },
            new Talent { Name = "Spacewalk", DiscplineRequirements = new DisciplineRequirements { Conn = 3 }, Weight = 6 },
            new Talent { Name = "Starship Expert", DiscplineRequirements = new DisciplineRequirements { Conn = 3 }, Weight = 6 },
            new Talent { Name = "Strafing Run", DiscplineRequirements = new DisciplineRequirements { Conn = 4 }, Weight = 8 },

            new Talent { Name = "Close Protection", DiscplineRequirements = new DisciplineRequirements { Security = 4 }, Weight = 8 },
            new Talent { Name = "Criminal Minds", DiscplineRequirements = new DisciplineRequirements { Security = 3 }, Weight = 6 },
            new Talent { Name = "Deadeye Marksman", DiscplineRequirements = new DisciplineRequirements { Security = 3 }, AttributeRequirements = new CharacterAttributes { Control = 10 }, Weight = 8 },
            new Talent { Name = "Fire at Will", DiscplineRequirements = new DisciplineRequirements { Security = 2 }, AttributeRequirements = new CharacterAttributes { Daring = 8 }, Weight = 6 },
            new Talent { Name = "Full Spread - Maximum Yield!", DiscplineRequirements = new DisciplineRequirements { Security = 3 }, Weight = 6 },
            new Talent { Name = "Hunker Down", DiscplineRequirements = new DisciplineRequirements { Security = 2 }, Weight = 4 },
            new Talent { Name = "Interrogation", DiscplineRequirements = new DisciplineRequirements { Security = 3 }, Weight = 6 },
            new Talent { Name = "Martial Artist", DiscplineRequirements = new DisciplineRequirements { Security = 4 }, Weight = 8 },
            new Talent { Name = "Quick to Action", DiscplineRequirements = new DisciplineRequirements { Security = 3 }, Weight = 6 },

            new Talent { Name = "A Little More Power", DiscplineRequirements = new DisciplineRequirements { Engineering = 3 }, Weight = 6 },
            new Talent { Name = "Experimental Device", DiscplineRequirements = new DisciplineRequirements { Engineering = 4 }, Weight = 8 },
            new Talent { Name = "I Know My Ship", DiscplineRequirements = new DisciplineRequirements { Engineering = 4 }, Weight = 8 },
            new Talent { Name = "Jury-Rig", DiscplineRequirements = new DisciplineRequirements { Engineering = 4 }, Weight = 8 },
            new Talent { Name = "Maintenance Specialist", DiscplineRequirements = new DisciplineRequirements { Engineering = 3 }, Weight = 6 },
            new Talent { Name = "Meticulous", DiscplineRequirements = new DisciplineRequirements { Engineering = 3 }, AttributeRequirements = new CharacterAttributes { Control = 10 }, Weight = 8 },
            new Talent { Name = "Miracle Worker", DiscplineRequirements = new DisciplineRequirements { Engineering = 5 }, Weight = 10 },
            new Talent { Name = "Past the Redline", DiscplineRequirements = new DisciplineRequirements { Engineering = 4 }, AttributeRequirements = new CharacterAttributes { Daring = 10 }, Weight = 10 },
            new Talent { Name = "Right Tool for the Right Job", DiscplineRequirements = new DisciplineRequirements { Engineering = 3 }, Weight = 6 },

            new Talent { Name = "Baffling Briefing", DiscplineRequirements = new DisciplineRequirements { Science = 3 }, AttributeRequirements = new CharacterAttributes { Presence = 9 }, Weight = 8 },
            new Talent { Name = "Computer Expertise", DiscplineRequirements = new DisciplineRequirements { Science = 2 }, Weight = 4 },
            new Talent { Name = "Dedicated Focus", DiscplineRequirements = new DisciplineRequirements { Science = 4 }, Weight = 8 },
            new Talent { Name = "Expedition Expert", DiscplineRequirements = new DisciplineRequirements { Science = 3 }, AttributeRequirements = new CharacterAttributes { Fitness = 9 }, Weight = 8 },
            new Talent { Name = "Mental Repository", DiscplineRequirements = new DisciplineRequirements { Science = 3 }, AttributeRequirements = new CharacterAttributes { Reason = 10 }, Weight = 8 },
            new Talent { Name = "Rapid Analysis", DiscplineRequirements = new DisciplineRequirements { Science = 3 }, AttributeRequirements = new CharacterAttributes { Daring = 9 }, Weight = 8 },
            new Talent { Name = "Temporal Mechanic", DiscplineRequirements = new DisciplineRequirements { Science = 3 }, FocusRequirement = Focus.TemporalMechanics, Weight = 10 },
            new Talent { Name = "Theory into Practice", DiscplineRequirements = new DisciplineRequirements { Science = 3 }, TalentRequirement = "Testing a Theory", Weight = 12 },
            new Talent { Name = "Unconventional Thinking", DiscplineRequirements = new DisciplineRequirements { Science = 3 }, AttributeRequirements = new CharacterAttributes { Insight = 9 }, Weight = 8 },
            new Talent { Name = "Walking Encyclopedia", DiscplineRequirements = new DisciplineRequirements { Science = 2 }, AttributeRequirements = new CharacterAttributes { Reason = 9 }, Weight = 6 },

            new Talent { Name = "Doctor's Orders", DiscplineRequirements = new DisciplineRequirements { Medicine = 4 }, Weight = 8 },
            new Talent { Name = "Fellowship Speciality", DiscplineRequirements = new DisciplineRequirements { Medicine = 4 }, Weight = 8 },
            new Talent { Name = "First Response", DiscplineRequirements = new DisciplineRequirements { Medicine = 3 }, Weight = 6 },
            new Talent { Name = "Healing Hands", DiscplineRequirements = new DisciplineRequirements { Medicine = 3 }, AttributeRequirements = new CharacterAttributes { Control = 9 }, Weight = 8 },
            new Talent { Name = "I'm a Doctor, Not a...", DiscplineRequirements = new DisciplineRequirements { Medicine = 3 }, Weight = 6 },
            new Talent { Name = "Positive Reinforcment", DiscplineRequirements = new DisciplineRequirements { Medicine = 3 }, AttributeRequirements = new CharacterAttributes { Presence = 9 }, Weight = 8 },
            new Talent { Name = "Practice Makes Perfect", DiscplineRequirements = new DisciplineRequirements { Medicine = 3 }, AttributeRequirements = new CharacterAttributes { Reason = 6 }, Weight = 8 },
            new Talent { Name = "Psychoanalyst", DiscplineRequirements = new DisciplineRequirements { Medicine = 3 }, Weight = 6 },
            new Talent { Name = "Quick Study", DiscplineRequirements = new DisciplineRequirements { Medicine = 3 }, Weight = 6 },
            new Talent { Name = "Surgery Savant", DiscplineRequirements = new DisciplineRequirements { Medicine = 4 }, Weight = 6 },
            new Talent { Name = "Triage", DiscplineRequirements = new DisciplineRequirements { Medicine = 3 }, Weight = 6 },

            new Talent { Name = "Crisis Management", DiscplineRequirements = new DisciplineRequirements { Security = 3, Command = 3, Operator = Operator.Or }, Weight = 6 },
            new Talent { Name = "In the Nick of Time", DiscplineRequirements = new DisciplineRequirements { Engineering = 3, Science = 3, Operator = Operator.Or }, Weight = 6 },
            new Talent { Name = "Intense Scrutiny", DiscplineRequirements = new DisciplineRequirements { Engineering = 3, Science = 3, Operator = Operator.Or }, Weight = 6 },
            new Talent { Name = "Testing a Theory", DiscplineRequirements = new DisciplineRequirements { Engineering = 2, Science = 2, Operator = Operator.Or }, Weight = 4 },

            new Talent { Name = "Bedside Manner", DiscplineRequirements = new DisciplineRequirements { Command = 3, Medicine = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Call Out Targets", DiscplineRequirements = new DisciplineRequirements { Command = 3, Security = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Chief of Staff", DiscplineRequirements = new DisciplineRequirements { Command = 3, Medicine = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Combat Medic", DiscplineRequirements = new DisciplineRequirements { Command = 2, Security = 2, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Cyberneticist", DiscplineRequirements = new DisciplineRequirements { Command = 2, Security = 2, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Exploit Engineering Flaw", DiscplineRequirements = new DisciplineRequirements { Engineering = 3, Medicine = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Field Medic", DiscplineRequirements = new DisciplineRequirements { Security = 2, Medicine = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Heart, Body and Mind", DiscplineRequirements = new DisciplineRequirements { Command = 2, Medicine = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Insightful Guidance", DiscplineRequirements = new DisciplineRequirements { Command = 2, Medicine = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Lab Rat", DiscplineRequirements = new DisciplineRequirements { Science = 3, Engineering = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Lead Investigator", DiscplineRequirements = new DisciplineRequirements { Security = 3, Conn = 2, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Precision Targeting", DiscplineRequirements = new DisciplineRequirements { Security = 4, Conn = 3, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Procedural Compliance", DiscplineRequirements = new DisciplineRequirements { Engineering = 3, Conn = 2, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Repair Team Leader", DiscplineRequirements = new DisciplineRequirements { Engineering = 3, Command = 2, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Rocks into Replicators", DiscplineRequirements = new DisciplineRequirements { Engineering = 4, Science = 2, Operator = Operator.And }, Weight = 10 },
            new Talent { Name = "Student of War", DiscplineRequirements = new DisciplineRequirements { Science = 4, Security = 4, Operator = Operator.And }, Weight = 10 },
        };
    }
}
