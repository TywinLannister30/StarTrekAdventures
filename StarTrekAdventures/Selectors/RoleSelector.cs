using StarTrekAdventures.Constants;
using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public class RoleSelector: IRoleSelector
{
    public Role ChooseRole(Character character)
    {
        var weightedRoleList = new WeightedList<Role>();

        if (character.IsFlagOfficer() && Util.GetRandom(100) <= 50)
            return GetRole(RoleName.Admiral);
        
        if (character.IsCommandingOfficer())
            return GetRole(RoleName.CommandingOfficer);

        if (character.Rank == Rank.Commander)
            weightedRoleList.AddEntry(GetRole(RoleName.CommandingOfficer), 1);

        if (character.Rank == Rank.Commander)
            weightedRoleList.AddEntry(GetRole(RoleName.ExecutiveOfficer), 5);

        if (character.CareerPath.StartsWith(TrackName.StarfleetOfficerCommand))
        {
            if (character.Rank == Rank.Commander || character.Rank == Rank.LieutenantCommander)
            {
                weightedRoleList.AddEntry(GetRole(RoleName.ExecutiveOfficer), 5);
                weightedRoleList.AddEntry(GetRole(RoleName.Adjudant), 5);
            }

            if (character.Departments.Command >= 4) weightedRoleList.AddEntry(GetRole(RoleName.FleetLiaisonOfficer), 5);
            if (character.Departments.Command >= 4) weightedRoleList.AddEntry(GetRole(RoleName.StrategicOperationsOfficer), 5);
            if (character.Departments.Conn >= 4) weightedRoleList.AddEntry(GetRole(RoleName.FlightController), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.StarfleetOfficerOperations))
        {
            if (character.Experience == ExperienceName.Experienced || character.Experience == ExperienceName.Veteran)
            {
                if (character.Departments.Engineering >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefEngineer), 10);
                if (character.Departments.Engineering >= 4) weightedRoleList.AddEntry(GetRole(RoleName.OperationsManager), 10);
                if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefOfSecurity), 10);
                if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefTacticalOfficer), 10);
                if (character.Departments.Security >= 3) weightedRoleList.AddEntry(GetRole(RoleName.SquadLeader), 1);
            }

            if (character.Departments.Security >= 3 && character.Departments.Engineering >= 3) weightedRoleList.AddEntry(GetRole(RoleName.CombatEngineer), 1);
            if (character.Departments.Security >= 3 && character.Departments.Engineering >= 3) weightedRoleList.AddEntry(GetRole(RoleName.ExplosiveOrdnanceExpert), 1);
            if (character.Departments.Security >= 3 && character.Departments.Medicine >= 3) weightedRoleList.AddEntry(GetRole(RoleName.FieldMedic), 1);
            if (character.Departments.Security >= 3) weightedRoleList.AddEntry(GetRole(RoleName.HeavyWeaponSpecialist), 1);
            if (character.Departments.Security >= 3) weightedRoleList.AddEntry(GetRole(RoleName.Reconnaissance), 1);
        }

        if (character.CareerPath.StartsWith(TrackName.StarfleetOfficerSciences))
        {
            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Navigator), 5);
            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ScienceOfficer), 10);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ShipsDoctor), 10);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefSurgeon), 5);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Anesthesiologist), 1);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.PhysiciansAssistant), 1);

            if (character.Experience == ExperienceName.Experienced || character.Experience == ExperienceName.Veteran)
            {
                if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefMedicalOfficer), 10);
            }

            if (character.HasPsychologyFocus())
            {
                weightedRoleList.AddEntry(GetRole(RoleName.ShipsCounselor), 10);
            }
        }

        if (character.CareerPath.StartsWith(TrackName.StarfleetEnlisted))
        {
            if (character.Departments.Conn >= 4) weightedRoleList.AddEntry(GetRole(RoleName.FlightController), 10);

            if (character.Experience == ExperienceName.Experienced || character.Experience == ExperienceName.Veteran)
            {
                if (character.Departments.Engineering >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefEngineer), 10);
                if (character.Departments.Engineering >= 4) weightedRoleList.AddEntry(GetRole(RoleName.OperationsManager), 10);
                if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefOfSecurity), 10);
                if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefTacticalOfficer), 10);
                if (character.Departments.Security >= 3) weightedRoleList.AddEntry(GetRole(RoleName.SquadLeader), 1);
            }

            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Navigator), 5);
            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ScienceOfficer), 10);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ShipsDoctor), 10);
            if (character.Departments.Medicine >= 3) weightedRoleList.AddEntry(GetRole(RoleName.HeadNurse), 10);
            if (character.Departments.Medicine >= 3) weightedRoleList.AddEntry(GetRole(RoleName.PhysiciansAssistant), 5);

            if (character.Departments.Security >= 3 && character.Departments.Engineering >= 3) weightedRoleList.AddEntry(GetRole(RoleName.CombatEngineer), 1);
            if (character.Departments.Security >= 3 && character.Departments.Engineering >= 3) weightedRoleList.AddEntry(GetRole(RoleName.ExplosiveOrdnanceExpert), 1);
            if (character.Departments.Security >= 3 && character.Departments.Medicine >= 3) weightedRoleList.AddEntry(GetRole(RoleName.FieldMedic), 1);
            if (character.Departments.Security >= 3) weightedRoleList.AddEntry(GetRole(RoleName.HeavyWeaponSpecialist), 1);
            if (character.Departments.Security >= 3) weightedRoleList.AddEntry(GetRole(RoleName.Reconnaissance), 1);

            if (character.HasPsychologyFocus())
            {
                weightedRoleList.AddEntry(GetRole(RoleName.ShipsCounselor), 10);
            }
        }

        if (character.CareerPath.StartsWith(TrackName.StarfleetIntelligence))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.IntelligenceAgent), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.DiplomaticCorps))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.DiplomaticAttache), 10);
            weightedRoleList.AddEntry(GetRole(RoleName.PoliticalLiason), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.CivilianPhysician))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.Expert), 10);

            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ShipsDoctor), 10);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ChiefSurgeon), 10);
            if (character.Departments.Medicine >= 3) weightedRoleList.AddEntry(GetRole(RoleName.HeadNurse), 5);
            if (character.Departments.Medicine >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Anesthesiologist), 5);
            if (character.Departments.Medicine >= 3) weightedRoleList.AddEntry(GetRole(RoleName.PhysiciansAssistant), 10);

            if (character.HasPsychologyFocus())
            {
                weightedRoleList.AddEntry(GetRole(RoleName.ShipsCounselor), 10);
            }
        }

        if (character.CareerPath.StartsWith(TrackName.CivilianScientist))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.Expert), 10);

            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Navigator), 5);
            if (character.Departments.Science >= 4) weightedRoleList.AddEntry(GetRole(RoleName.ScienceOfficer), 10);
        }

        if (character.CareerPath.StartsWith(TrackName.CivilianOfficial))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.Expert), 10);
            weightedRoleList.AddEntry(GetRole(RoleName.ShipsCook), 1);
            weightedRoleList.AddEntry(GetRole(RoleName.ShipsChef), 1);

        }

        if (character.CareerPath.StartsWith(TrackName.CivilianTrader))
        {
            weightedRoleList.AddEntry(GetRole(RoleName.Merchant), 10);
            weightedRoleList.AddEntry(GetRole(RoleName.ShipsCook), 1);
            weightedRoleList.AddEntry(GetRole(RoleName.ShipsChef), 1);

            if (character.Departments.Security >= 4) weightedRoleList.AddEntry(GetRole(RoleName.Bodyguard), 10);

        }

        weightedRoleList.AddEntry(GetRole(RoleName.CommunicationsOfficer), 1);

        if (character.Roles.Count != 0)
            weightedRoleList.RemoveAll(character.Roles.First());

        return weightedRoleList.GetRandom();
    }

    public Role GetRole(string name)
    {
        return Roles.First(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
    }

    public List<Role> GetAllRoles()
    {
        return Roles;
    }

    private static readonly List<Role> Roles = new()
    {
        new Role
        {
            Name = RoleName.CommandingOfficer,
            Description = "Even if the commanding officer does not hold the rank of captain, they are usually referred to as captain by their subordinates aboard a starship. Aboard stations, commanding officers are referred to by their rank. Commanding officers are responsible for the ship or facility under their command as well as executing the orders and directives from their leadership.",
            Benefit = "You may spend Determination to grant any other character you can communicate with 1 Determination; this does not have to be linked to using or challenging a value."
        },
        new Role
        {
            Name = RoleName.ExecutiveOfficer,
            Description = "Second-in-command. The executive officer is the captain’s chief advisor and takes command in situations where the captain is unable to. If a ship does not have a dedicated executive officer, an officer in another role should be noted as second-in-command, but they will not gain the benefits of this role.",
            Benefit = "When an allied character in communication with you spends Determination, you may spend 3 Momentum (Immediate) to enable that character to regain the spent point of Determination."
        },
        new Role
        {
            Name = RoleName.OperationsManager,
            Description = "The operations manager manages and oversees all technical operations aboard or involving the ship, normally from the operations station on the bridge, or in conjunction with the chief engineer (on smaller ships, one officer may fill both roles). This often entails taking on the duties of a science officer if there is no dedicated science officer among the senior staff.",
            Benefit = "Whenever you create a trait representing a piece of equipment, or an alteration made to existing equipment, any character who benefits from that trait while you are present in the scene may re-roll a d20."
        },
        new Role
        {
            Name = RoleName.ChiefEngineer,
            Description = "The chief engineer is responsible for ensuring the ship remains operational and functional, and commands the engineering department aboard the ship.",
            Benefit = "You reduce the opportunity cost of engineering teams by 1, to a minimum of 0. Further, when you attempt a task to perform repairs to a starship or attempt to push the ship’s capabilities beyond its normal limits, you may spend 1 Momentum (Immediate) to re-roll a d20."
        },
        new Role
        {
            Name = RoleName.ChiefOfSecurity,
            Description = "The chief of security oversees the ship’s security department and is responsible for ensuring the safety of the ship and crew during missions, for the investigation of disciplinary and criminal matters, and for overseeing the protection of important persons aboard the ship.",
            Benefit = "You reduce the opportunity cost of weapons and security teams by 1, to a minimum of 0. Further, when you succeed at an Attack against an enemy during personal combat, you may spend 1 Momentum to increase the Difficulty of that enemy’s next Attack by 1."
        },
        new Role
        {
            Name = RoleName.ChiefTacticalOfficer,
            Description = "A presence on 22nd and 23rd century Starfleet ships, and common in other organizations, this role is also known as an armory officer or weapons officer. The officer is responsible for the upkeep and use of the ship’s armaments and is typically an expert in ship-to-ship combat.",
            Benefit = "When you succeed at an Attack with the ship’s weapons, you may increase the damage rating of that weapon system by spending 1 Momentum rather than 2."
        },
        new Role
        {
            Name = RoleName.FlightController,
            Description = "Also known as a helmsman on 22nd and 23rd century Starfleet vessels. Not a typical senior staff role, though some captains, particularly those operating in uncharted space, choose the most senior helmsman or flight control officer to serve on the senior staff.",
            Benefit = "When you attempt an engineering task related to flight or propulsion, you may use your Conn rating instead of Engineering. When you succeed at a Conn task to pilot a starship, you generate 1 bonus Momentum to be used on that task (bonus Momentum may not be saved)."
        },
        new Role
        {
            Name = RoleName.Navigator,
            Description = "On vessels exploring the uncharted frontiers of space, a skilled navigator, astrometrics officer, or stellar cartographer plots courses, studies and updates astrometrics charts and data, and supports the helmsman or flight controller. Navigators are rarely called to serve on the senior staff.",
            Benefit = "When you attempt a science task related to astrophysics or stellar navigation, you may use your Conn rating instead of Science. When you attempt or Assist a task to maneuver a starship through difficult or dangerous terrain, you may spend 1 Momentum to ignore a complication suffered (Repeatable)."
        },
        new Role
        {
            Name = RoleName.ScienceOfficer,
            Description = "The science officer (sometimes referred to as the chief science officer) is responsible for advising the commanding officer on all scientific matters, providing hypotheses concerning the unknown. The science officer is also responsible for all science personnel on the ship or station.",
            Benefit = "When you succeed at a task assisted by the ship’s Sensors or Computers, or a task using a tricorder or other sensing device, you may ask one additional question as if you had spent Momentum on Obtain Information."
        },
        new Role
        {
            Name = RoleName.ChiefMedicalOfficer,
            Description = "The chief medical officer is responsible for the health and well-being of the crew and other people aboard the ship and leads the ship’s medical department. A chief medical officer can order, and countermand the orders of, senior officers where matters of that officer’s health are concerned. In extreme situations, the chief medical officer can declare an officer unfit and remove them from active duty (including the commanding officer).",
            Benefit = "You reduce the opportunity cost of medical equipment and medical teams by 1, to a minimum of 0. Further, when you attempt a task using your Medicine rating, and you have assistance, you generate 1 bonus Momentum (bonus Momentum may not be saved)."
        },
        new Role
        {
            Name = RoleName.ShipsDoctor,
            Description = "You care for the crew of your ship, or the station you serve on (in which case, rename the role to Station’s Doctor), but unlike a chief medical officer, you do not have an extensive medical department to manage or to aid you. This is common in smaller crews which do not require a large sickbay or infirmary and tends to mean these smaller postings favor generalists who can adapt to a variety of circumstances.",
            Benefit = "You have two additional focuses, which must relate to medicine fields of study. However, your ship cannot use Crew Support to introduce supporting characters who are medical personnel.",
            AdditionalFocuses = 2,
            AdditionalFocusesChoices = new List<string>() { Focus.Cybernetics, Focus.EmergencyMedicine,  Focus.Genetics, Focus.InfectiousDiseases, Focus.Psychiatry, Focus.Surgery, Focus.TraumaSurgery, Focus.Virology, Focus.Xenobiology }
        },
        new Role
        {
            Name = RoleName.ShipsCounselor,
            Description = "On larger ships and starbases, it’s common (especially in the 24th century and beyond) to have personnel dedicated to the mental well-being of the crew. Some captains regard them as valuable advisors, as their training covers both culture and psychology, making them exceptionally good at reading the moods and intentions of others.",
            Benefit = "When you Assist a character suffering from a trait representing a negative emotional state, you may re-roll your assist die. Additionally, once per mission, you may spend a scene counseling a character who has challenged one of their values during the current mission. At the end of the scene, the character may rewrite their crossed-out value immediately, rather than waiting until the end of the mission. If they do this, they immediately gain 1 Determination as well."
        },
        new Role
        {
            Name = RoleName.CommunicationsOfficer,
            Description = "More common in the earlier days of Starfleet, dedicated communications officers are typically skilled in linguistics and cryptography, and aided with advanced translation and decryption technologies, and are valuable during encounters with new cultures, hostile or otherwise.",
            Benefit = "When you attempt a task assisted by the ship’s Computers or Communications systems, do not roll the ship’s assist die: instead, count the ship’s die as if it had rolled a 1."
        },
        new Role
        {
            Name = RoleName.Bodyguard,
            Description = "You specialize in personal security, protecting an individual, whether a paying client, or someone you were assigned to. Militaries tend not to employ specific bodyguards in this sense, but they may have specialists trained in protecting important personnel—ambassadors, admirals, political figures, and similar—as needed.",
            Benefit = "Choose a single character—another player character or an NPC—who you are assigned to protect. When you are in the same zone as that character, you may spend 1 Momentum (Immediate) when that character is attacked to have the Attack target you instead. If you do this, the attack’s Difficulty is increased by 1."
        },
        new Role
        {
            Name = RoleName.Expert,
            Description = "You are an expert in a particular field, working alongside the crew to consult upon a matter related to your expertise. You are highly specialized and extremely capable in your chosen field, but this may lead you to ignore or overlook things that fall outside your knowledge or result in an obsession that causes you to prioritize your work over other concerns.",
            Benefit = "You gain one additional value, which must reflect the importance of your work to you. In addition, select one of your focuses—this is the field you are an expert in. When you use this focus on a task and succeed, you generate 1 bonus Momentum (bonus Momentum may not be saved).",
            AdditionalValues = 1
        },
        new Role
        {
            Name = RoleName.IntelligenceAgent,
            Description = "You are not a traditional part of the fleet. Instead, you are an operative of the intelligence services of your civilization. You are charged with gathering information from places and people that don’t want their information gathered, and you achieve this through a combination of your own skills and the network of informants and contacts you have cultivated.",
            Benefit = "Once per adventure, you may create a trait without requiring a task or spending any Momentum, Threat, or Determination. This trait must reflect information, physical resources, or access to a location (such as access codes or identification data) provided to you by a contact or by your agency."
        },
        new Role
        {
            Name = RoleName.Merchant,
            Description = "You’re a merchant or trader, exchanging valuable goods for latinum or other goods. Even in the Federation, merchants are necessary for ensuring resources can easily move from place to place. The Federation and its members maintain reserves of latinum and other precious commodities to allow them to trade with other civilizations. In a practical sense, merchants are well-connected and often have access to unusual items or specialized resources not usually available.",
            Benefit = "Once per adventure, you can ignore the opportunity costs on up to three items of equipment being acquired by other player characters. You may even allow other player characters to obtain items not normally available to them (such as disruptors to a Starfleet crew, or items which are restricted or illegal), though you add 1 Threat for each such item provided."
        },
        new Role
        {
            Name = RoleName.PoliticalLiason,
            Description = "You serve as a representative of a government, representing their needs and interests during the operations of the crew, and providing the crew with a means of communicating with that government in turn. This is often the case where multiple groups are required to coexist, such as a Starfleet facility operating  close to an allied non-Federation world, or as part of a joint operation between Starfleet and Klingon Defense Force personnel.",
            Benefit = "You represent the official government your organization belongs to—i.e., if you are a member of the Bajoran Militia, you represent the current Bajoran government. You gain an additional Directive, which only applies to you, which reflects the political stance of the government you represent. Your gamemaster will work with you to determine the wording of this Directive. It serves to provide you with a source of complications and potential restrictions when acting against the interests of your government, and benefits when you are acting with the full support of your superiors."
        },
        new Role
        {
            Name = RoleName.Translator,
            Description = "You are an expert in language and communication. While the development of the universal translator has reduced the need for translators during daily life in the 23rd and 24th centuries, there are still situations which call for experts in linguistics. Encounters with new cultures often require support from xenolinguistics experts to smooth over any problems that the universal translator has, particularly if a culture has an unusual style or method of communication. Similarly, archaeological research often requires piecing together extinct languages from evidence in ways that can’t easily be automated.",
            Benefit = "When attempting to read, understand, or speak a language unfamiliar to you, you may spend 2 Momentum (Immediate) to piece together a basic understanding of that language immediately, enough to convey simple ideas. This allows social tasks to be attempted in this language, but the complication range of these tasks is increased to 18–20. Deeper study, at the gamemaster’s discretion, allows you to remove this penalty and discuss more complex ideas."
        },
        new Role
        {
            Name = RoleName.ShipsChef,
            Description = "In addition to owning restaurants, chefs are often found on starships and starbases, particularly those which do not purely rely upon replicators to feed the crew; a ship’s chef was a common fixture on older ships before the introduction of the replicator. Larger modern Starfleet vessels, especially ones serving diplomatic roles, often have a chef aboard to help prepare banquets for dignitaries, cooking with a mixture of stored foods, fruit and vegetables grown in hydroponics bays, and replicated ingredients to produce spectacular dishes. Chefs aboard starships are often called upon to be adaptable and a quick study, learning new cuisines from encountered cultures, and programming replicators to add special requests to the ship’s menus.",
            Benefit = "Once per adventure, you may prepare a meal for a non-combat scene set aboard the ship; this may be a dinner at the captain’s table, a banquet for dignitaries or other VIPs, part of a celebration, or some other meaningful occasion. The scene is also considered to be a Break rest, and characters will recover +1 Stress over what they normally would. Player characters may reroll 1d20 on all social conflict tasks they attempt during that scene.",
        },
        new Role
        {
            Name = RoleName.ShipsCook,
            Description = "Klingon vessels customarily have a ship’s cook, who is responsible for feeding the ship’s crew during a cruise. The entire crew customarily eats together, and, as Klingons dislike replicated food, regarding it as “artificial” and “lifeless,” a cook is necessary to prepare meals from live or recently slaughtered meat. Other ships and cultures may have reasons to have a cook aboard the ship, preparing meals from scratch.",
            Benefit = "Once per adventure, at the start of a new scene, you may declare the scene will feature the crew eating together. This is considered to be a Break rest, and characters will recover +1 Stress over and above what they’d normally regain. In addition, after the scene, you may roll 1d20: if you roll equal to or under your Control, add 1 Momentum to the group pool. At the commanding officer’s discretion, you may add drinks (for Klingons, bloodwine; on Starfleet vessels, this will be some variety of synthehol); if you do so, roll two d20s as above, but if either die rolls above your Control, add 1 Threat.",
        },

        // 1st Edition Roles
        new Role
        {
            Name = RoleName.Adjudant,
            Description = "Command department only. The adjutant must be at least a lieutenant commander. This is the admiral’s closest advisor and assistant, providing aid and support like an executive officer supports a commanding officer. A good adjutant is always prepared with mission proposals, alternative plans, and hypothetical scenarios to allow the admiral to react to problems.",
            Benefit = "At the start of any scene, the adjutant may spend one Momentum (Immediate) in order to change the Focus chosen by the admiral for the duration of that scene only. The new Focus must be one of the others selected by the admiral.",
            Source = BookSource.CommandDivision1stEdition
        },
        new Role
        {
            Name = RoleName.Admiral,
            Description = "Flag officer only. In an Admiralty game, the group must have an admiral (even if they’re a Non-Player Character).",
            Benefit = "Select three additional Focuses, reflecting areas of expertise or subjects that pertain to the admiral’s assignment. At the start of each mission, the admiral chooses one of their three Focuses, and every Main Character receives that as an additional Focus for the mission, due to additional briefings and instructional resources.",
            Source = BookSource.CommandDivision1stEdition
        },
        new Role
        {
            Name = RoleName.Anesthesiologist,
            Description = "These medical professionals are experts in treating pain and ensuring that patients do not suffer during the course of their treatments. This is of particular importance during major surgeries and other invasive treatments, as the anaesthesiologist is also responsible for monitoring the patient’s vital signs and adjusting medications during the proceedings. This allows the surgeons and physicians to focus on the task at hand.",
            Benefit = "When you Assist during a Medicine Task, you do not count against any limit on the number of characters that may assist, and do not have to pay Momentum or add Threat in order to assist.",
            Source = BookSource.ScienceDivision1stEdition
        },
        new Role
        {
            Name = RoleName.ChiefSurgeon,
            Description = "On larger ships and starbases, and on dedicated medical ships, the medical staff may be robust enough to support a dedicated surgery team. The head of this team is the Chief of Surgery or Chief Surgeon. While the duties of this role may often be filled by the Chief Medical Officer (often referred to as Ship’s Surgeon), when there is a dedicated surgeon, a character may choose to assume this role.",
            Benefit = "When you attempt a Control + Medicine task to remove an Injury (or as part of an extended task to treat multiple injuries), the first bonus d20 you purchase is free.",
            Source = BookSource.ScienceDivision1stEdition
        },
        new Role
        {
            Name = RoleName.DiplomaticAttache,
            Description = "A civilian from the Federation Diplomatic Corps and a valuable part of the staff who advises the admiral, and briefs them on culture, protocol, and other essential information during negotiations and other diplomatic activities.",
            Benefit = "At the start of any social conflict scene involving a foreign culture, you may spend 2 Momentum (Immediate) to create a trait for any other main character present, representing a briefing you provided them. You may do this even if your character is not personally present in the scene; it is prior counsel, not immediate assistance.",
            Source = BookSource.CommandDivision1stEdition
        },
        new Role
        {
            Name = RoleName.FleetLiaisonOfficer,
            Description = "A fleet liaison represents the interests of the fleet, and Starfleet as a whole, to one of the Federation’s allies. A Starfleet officer will represent the Federation, though the Gamemaster may allow other fleet liaison officers; for example, a joint Klingon- Federation task force may include a Klingon Empire liaison. These officers report to superiors and allow cooperation between allies.",
            Benefit = "The fleet liaison officer has an additional Trait: Contacts Amongst X, where X is the fleet or service the liaison works with/for. For example, a Klingon Defence Force has the trait Contacts Amongst the Klingon Defence Force.",
            Source = BookSource.CommandDivision1stEdition
        },
        new Role
        {
            Name = RoleName.HeadNurse,
            Description = "On almost any Federation starship, sickbay is staffed by a number of nurses, who assist the doctors on board with treating patients. There is, however, always a senior nurse—with the most experience, who works closely with the chief medical officer in managing the nursing staff.",
            Benefit = "You may substitute your Medicine Department in place of Command whenever attempting to coordinate or direct medical staff or patients under your care, and you may use the Direct major action on them. This may only be used with characters subordinate to you and thus would not apply to doctors or surgeons.",
            Source = BookSource.ScienceDivision1stEdition
        },
        new Role
        {
            Name = RoleName.PhysiciansAssistant,
            Description = "Filling a role between doctor and nurse—and commonly a role filled by those still finishing their training as doctors, nurse-practitioners, or medical researchers who lack their medical doctorate—physician’s assistants have attended medical school, but are not full medical doctors. They have sufficient training to diagnose and treat most minor to moderate conditions, and can make medical recommendations as well as prescribe medications. For more complex or life-threatening conditions, the physician’s assistant will call in a full doctor.",
            Benefit = "When you succeed at a Medicine task to diagnose or treat a patient, then if you later (during the same mission) assist another character making a Medicine task for that patient, you may roll two d20s to assist rather than one.",
            Source = BookSource.ScienceDivision1stEdition
        },
        new Role
        {
            Name = RoleName.StrategicOperationsOfficer,
            Description = "Command department only. This officer coordinates the movements and activities of vessels and forces in a given region or on a particular mission. Typically officers with a keen understanding of strategy, they advise the admiral and adjust plans independently when they cannot consult the admiral.",
            Benefit = "Regardless of rank, the strategic operations officer has authority over all vessels and forces linked to their region or mission. They may reduce the Difficulty of Persuade Tasks with the commanding officers of those vessels and forces by 1, to a minimum of 0.",
            Source = BookSource.CommandDivision1stEdition
        },

        // 1st Edition Roles - Tactical Roles
        new Role
        {
            Name = RoleName.CombatEngineer,
            Description = "From breaching security doors to erecting makeshift bunkers, combat engineers are responsible for dealing with all manners of fortifications (both enemy and friendly). They also make sure the squad’s equipment is in good working order.",
            Benefit = "When you succeed at an Engineering task roll during a combat encounter, you generate 1 bonus Momentum. Bonus Momentum may not be saved.",
            Source = BookSource.OperationsDivision1stEdition
        },
        new Role
        {
            Name = RoleName.ExplosiveOrdnanceExpert,
            Description = "Due to the prevalence of explosives in major conflict zones, someone capable of using and deactivating these weapons is critical.",
            Benefit = "You may reroll one d20 when attempting a task to use or disarm an explosive device, or to attack with a weapon which has the Area and/or Grenade qualities.",
            Source = BookSource.OperationsDivision1stEdition
        },
        new Role
        {
            Name = RoleName.FieldMedic,
            Description = "Every combatant’s best friend is their medic. These characters are responsible for patching up their squad mates and keeping them alive in the heat of battle.",
            Benefit = "You ignore any increase in Difficulty to the First Aid major action which are related to the chaos or distractions of battle.",
            Source = BookSource.OperationsDivision1stEdition
        },
        new Role
        {
            Name = RoleName.HeavyWeaponSpecialist,
            Description = "Starfleet attempts to avoid lethal engagements but sometimes there simply isn’t another way. In such situations, heavy weapon specialists ensure that their combat squad can match their opponent’s firepower.",
            Benefit = "Whenever you requisition weapons with an Escalation cost, reduce that Escalation cost by 1, to a minimum of 1.",
            Source = BookSource.OperationsDivision1stEdition
        },
        new Role
        {
            Name = RoleName.Reconnaissance,
            Description = "Throughout history, it is often the force with the most information that achieves its tactical objectives. Recon specialists are the eyes and ears of the team, venturing out ahead of the others to gather information.",
            Benefit = "When you succeed at an Insight + Security task roll to survey an environment or detect dangers, you generate 1 bonus Momentum which may only be spent to Obtain Information. Bonus Momentum may not be Saved.",
            Source = BookSource.OperationsDivision1stEdition
        },
        new Role
        {
            Name = RoleName.SquadLeader,
            Description = "Each combat squad must have one leader. This character serves as the commanding officer for the team.",
            Benefit = "When you use the Direct major action, you may assist with Control + Security instead of Control + Command. This task roll is still considered to be a Command task in all other regards.",
            Source = BookSource.OperationsDivision1stEdition
        },
    };
}
