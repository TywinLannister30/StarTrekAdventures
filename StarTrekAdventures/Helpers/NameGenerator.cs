using RandomNameGeneratorLibrary;
using StarTrekAdventures.Constants;
using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StarTrekAdventures.Helpers;

public static class NameGenerator
{
    public static string GenerateName(Character character, bool secondSpecies = false)
    {
        var species = character.Traits.First();

        if (secondSpecies)
            species = character.Traits.ElementAt(1);

        var gender = (Gender)Enum.Parse(typeof(Gender), character.Gender);

        if (species == SpeciesName.Andorian || species == SpeciesName.Aenar)
            return GenerateAndorianName(gender);
        if (species == SpeciesName.Ankari)
            return GenerateAnkariName(gender);
        if (species == SpeciesName.Arbazan)
            return GenerateArbazanName(gender);
        if (species == SpeciesName.Ardanan)
            return GenerateArdananName(gender);
        if (species == SpeciesName.Argrathi)
            return GenerateArgrathiName(gender);
        if (species == SpeciesName.Arkarian)
            return GenerateArkarianName(gender);
        if (species == SpeciesName.Aurelian)
            return GenerateAurelianName(gender);
        if (species == SpeciesName.AurelianNovolare)
            return GenerateAurelianName(gender);
        if (species == SpeciesName.Bajoran)
            return GenerateBajoranName(gender);
        if (species == SpeciesName.Barzan)
            return GenerateBarzanName();
        if (species == SpeciesName.Benzite)
            return GenerateBenziteName(gender);
        if (species == SpeciesName.Betazoid)
            return GenerateBetazoidName(gender);
        if (species == SpeciesName.Betelgeusian)
            return GenerateBetelgeusianName();
        if (species == SpeciesName.Bolian)
            return GenerateBolianName(gender);
        if (species == SpeciesName.Breen)
            return GenerateBreenName();
        if (species == SpeciesName.Brikar)
            return GenerateBrikarName(gender);
        if (species == SpeciesName.Bynar)
            return GenerateBynarName();
        if (species == SpeciesName.Caitian)
            return GenerateCaitianName(gender);
        if (species == SpeciesName.Cardassian)
            return GenerateCardassianName(gender);
        if (species == SpeciesName.Changeling)
            return GenerateChangelingName(gender);
        if (species == SpeciesName.CyberneticallyEnhanced)
            return GenerateCyberneticallyEnhancedName(character);
        if (species == SpeciesName.Cetacean)
            return GenerateCetaceanName();
        if (species == SpeciesName.Chameloid)
            return GenerateCommonName();
        if (species == SpeciesName.Changeling)
            return GenerateCommonName();
        if (species == SpeciesName.Deltan)
            return GenerateDeltanName(gender);
        if (species == SpeciesName.Denobulan)
            return GenerateDenobulanName(gender);
        if (species == SpeciesName.Dosi)
            return GenerateDosiName(gender);
        if (species == SpeciesName.Drai)
            return GenerateDraiName(gender);
        if (species == SpeciesName.Edosian)
            return GenerateEdosianName(gender);
        if (species == SpeciesName.Efrosian)
            return GenerateEfrosianName(gender);
        if (species == SpeciesName.ElAurian)
            return GenerateElAurianName(gender);
        if (species == SpeciesName.Exocomp)
            return GenerateCommonName();
        if (species == SpeciesName.Ferengi)
            return GenerateFerengiName(gender);
        if (species == SpeciesName.Grazerite)
            return GenerateGrazeriteName(gender);
        if (species == SpeciesName.Haliian)
            return GenerateHaliianName(gender);
        if (species == SpeciesName.Hologram)
            return GenerateHologramName(character);
        if (species == SpeciesName.Horta)
            return GenerateCommonName();
        if (species == SpeciesName.Human || species == SpeciesName.HumanAugment)
            return GenerateHumanName(gender);
        if (species == SpeciesName.Illyrian)
            return GenerateIllyrianName(gender);
        if (species == SpeciesName.JemHadar)
            return GenerateJemHadarName();
        if (species == SpeciesName.Jye)
            return GenerateJyeName(gender);
        if (species == SpeciesName.Karemma)
            return GenerateKaremmaName(gender);
        if (species == SpeciesName.Kellerun)
            return GenerateKellerunName();
        if (species == SpeciesName.Kelpien)
            return GenerateKelpianName();
        if (species == SpeciesName.Klingon)
            return GenerateKlingonName(gender);
        if (species == SpeciesName.Ktarian)
            return GenerateKtarianName(gender);
        if (species == SpeciesName.LiberatedBorg)
            return GenerateLiberatedBorgName(character);
        if (species == SpeciesName.Lokirrim)
            return GenerateLokirrimName(gender);
        if (species == SpeciesName.Lurian)
            return GenerateLurianName(gender);
        if (species == SpeciesName.Mari)
            return GenerateMariName(gender);
        if (species == SpeciesName.Monean)
            return GenerateMoneanName(gender);
        if (species == SpeciesName.Ocampa)
            return GenerateOcampaName(gender);
        if (species == SpeciesName.Orion)
            return GenerateOrionName(gender);
        if (species == SpeciesName.Osnullus)
            return GenerateOsnullusName();
        if (species == SpeciesName.Paradan)
            return GenerateParadanName(gender);
        if (species == SpeciesName.Pendari)
            return GeneratePendariName(gender);
        if (species == SpeciesName.Rakhari)
            return GenerateRakhariName(gender);
        if (species == SpeciesName.RigellianChelon)
            return GenerateRigellianChelonName(gender);
        if (species == SpeciesName.RigellianJelna)
            return GenerateRigellianJelnaName(gender);
        if (species == SpeciesName.Risian)
            return GenerateRisianName(gender);
        if (species == SpeciesName.Romulan || species == SpeciesName.Reman)
            return GenerateRomulanName(gender);
        if (species == SpeciesName.Saurian)
            return GenerateSaurianName(gender);
        if (species == SpeciesName.Sikarian)
            return GenerateSikarianName(gender);
        if (species == SpeciesName.Skreeaa)
            return GenerateSkreeaaName(gender);
        if (species == SpeciesName.Sona)
            return GenerateSonaName(gender);
        if (species == SpeciesName.SoongTypeAndroid || species == SpeciesName.Android || species == SpeciesName.CoppeliusAndroid)
            return GenerateSoongTypeAndroidName();
        if (species == SpeciesName.Talaxian)
            return GenerateTalaxianName(gender);
        if (species == SpeciesName.Tamarian)
            return GenerateTamarianName();
        if (species == SpeciesName.Tellarite)
            return GenerateTellariteName(gender);
        if (species == SpeciesName.Tosk)
            return GenerateToskName(gender);
        if (species == SpeciesName.Trill)
            return GenerateTrillName(gender, character.Traits);
        if (species == SpeciesName.Turei)
            return GenerateTureiName(gender);
        if (species == SpeciesName.Vorta)
            return GenerateVortaName(gender);
        if (species == SpeciesName.Vulcan)
            return GenerateVulcanName(gender);
        if (species == SpeciesName.Wadi)
            return GenerateWadiName(gender);
        if (species == SpeciesName.Xahean)
            return GenerateXaheanName();
        if (species == SpeciesName.XindiArboreal)
            return GenerateXindiArborealName(gender);
        if (species == SpeciesName.XindiInsectoid)
            return GenerateXindiInsectoidName(gender);
        if (species == SpeciesName.XindiPrimate)
            return GenerateXindiPrimateName(gender);
        if (species == SpeciesName.XindiReptilian)
            return GenerateXindiReptilianName(gender);
        if (species == SpeciesName.Zahl)
            return GenerateZahlName(gender);
        if (species == SpeciesName.Zakdorn)
            return GenerateZakdornName(gender);
        if (species == SpeciesName.Zaranite)
            return GenerateZaraniteName(gender);

        return "Not implemented.";
    }

    public static string GetSymbioteName()
    {
        return TrillSymbioteNames.OrderBy(n => Util.GetRandom()).First();
    }

    private static string GenerateHumanName(Gender gender)
    {
        var personGenerator = new PersonNameGenerator();

        if (gender == Gender.Male)
            return personGenerator.GenerateRandomMaleFirstAndLastName();
        else
            return personGenerator.GenerateRandomFemaleFirstAndLastName();
    }

    private static string GenerateAndorianName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? AndorianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : AndorianFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var clanSeperator = gender == Gender.Male
            ? "th'"
            : "zh'";

        var clanName = AndorianClanNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {clanSeperator}{clanName}";
    }
    private static readonly List<string> AndorianMaleNames = new List<string>
    {
        "Ishrath", "Thoss", "Shon", "Oshrev", "Atheth", "Tyvaass", "Thasiv", "Tyssab", "Tylihr", "Thy’lek", "Shras", "Thelev", "Keval", "Gareb", "Thyran"
    };
    private static readonly List<string> AndorianFemaleNames = new List<string>
    {
        "Athytti", "Vryvih", "Zyle", "Vyssia", "Thriras", "Shreri", "Vrossaan", "Itamaan", "Ishrelia", "Vreraat", "Talas", "Tarah", "Jhamel", "Talla"
    };
    private static readonly List<string> AndorianClanNames = new List<string>
    {
        "Tharhat", "Qiaqir", "Chiaqis", "Thenehr", "Zynes", "Shraviq", "Thilrerh", "Azonan", "Azollarh", "Shran"
    };

    private static string GenerateAnkariName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? AnkariMaleNames.OrderBy(n => Util.GetRandom()).First()
            : AnkariFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var ancestorName = AnkariAncestorNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {ancestorName}";
    }
    private static readonly List<string> AnkariMaleNames = new List<string>
    {
        "Rhal", "Jrek", "Mait", "Kast", "Hurn", "Tolk", "Byst", "Lurr", "Vurt", "Pulc", "Yrul", "Atla", "Fela", "Nahl", "Bole", "Whet", "Fila", "Koste", "Hirfa", "Valit", "Mal", "Nulna"
    };
    private static readonly List<string> AnkariFemaleNames = new List<string>
    {
        "Lalri", "Ghama", "Yruki", "Demre", "Whagi", "Sahme", "Clema", "Pulre", "Tili", "Ulua", "Atla", "Fela", "Nahl", "Bole", "Whet", "Fila", "Koste", "Hirfa", "Valit", "Mal", "Nulna"
    };
    private static readonly List<string> AnkariAncestorNames = new List<string>
    {
        "Onhyt", "Amkut", "Efna", "Ursuk", "Ahzur", "Etol", "Ofmat", "Skaa", "Ratka", "Vulin"
    };

    private static string GenerateArbazanName(Gender gender)
    {
        return gender == Gender.Male
            ? ArbazanMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ArbazanFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> ArbazanMaleNames = new List<string>
    {
        "Warik", "Rotes", "Apocec", "Berton", "Tuvmil", "Valbu"
    };
    private static readonly List<string> ArbazanFemaleNames = new List<string>
    {
        "Galez", "Krata", "Dortas", "Taxco", "Kezik", "Kimod"
    };

    private static string GenerateArdananName(Gender gender)
    {
        return gender == Gender.Male
            ? ArdananMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ArdananFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> ArdananMaleNames = new List<string>
    {
        "Anka", "Midro", "Plasus"
    };
    private static readonly List<string> ArdananFemaleNames = new List<string>
    {
        "Droxine", "Vanna"
    };

    private static string GenerateArgrathiName(Gender gender)
    {
        return gender == Gender.Male
            ? ArgrathiMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ArgrathiFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> ArgrathiMaleNames = new List<string>
    {
        "Ee’char", "V’gda Ruu", "N’Mi Char", "S’Geda Yuu"
    };
    private static readonly List<string> ArgrathiFemaleNames = new List<string>
    {
        "K’Par Rinn", "M’kethi Enu", "N’Mi Char", "S’Geda Yuu"
    };

    private static string GenerateArkarianName(Gender gender)
    {
        return gender == Gender.Male
            ? ArkarianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ArkarianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> ArkarianMaleNames = new List<string>
    {
        "Pemten", "Vivik", "Kopnon", "Raksab", "Navanat", "Natsan", "Imis", "Anat", "Hagan", "Vilim", "Sachan", "Feder"
    };
    private static readonly List<string> ArkarianFemaleNames = new List<string>
    {
        "Bracha", "Achan", "Teres", "Arat", "Sibinis", "Urus", "Latash", "Saksah", "Hannah", "Kamala"
    };

    private static string GenerateAurelianName(Gender gender)
    {
        return gender == Gender.Male
            ? AurelianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : AurelianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> AurelianMaleNames = new List<string>
    {
        "Jorenber-Le", "Aleek-Om", "Pealo-Dix", "Tarieel-Er", "Lovalga-Li", "Dueyyit-Ne",
    };
    private static readonly List<string> AurelianFemaleNames = new List<string>
    {
        "Manika-Esp", "Sutrial-Jon", "Loisma-Ne", "Pipadi-Par", "Inroha-Fe", "Evaasa-Al"
    };

    private static string GenerateBajoranName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? BajoranMaleNames.OrderBy(n => Util.GetRandom()).First()
            : BajoranFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = BajoranFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{familyName} {firstName}";
    }
    private static readonly List<string> BajoranMaleNames = new List<string>
    {
        "Anaphis", "Edon", "Essa", "Furel", "Gel", "Holem", "Hovath", "Kag", "Los", "Mabrin", "Nalas", "Reon", "Taban", "Tennan"
    };
    private static readonly List<string> BajoranFemaleNames = new List<string>
    {
        "Adami", "Chami", "Fala", "Jaxa", "Laren", "Lipras", "Leeta", "Lupaza", "Meru", "Neela", "Nerys", "Seriah", "Sul", "Yesa"
    };
    private static readonly List<string> BajoranFamilyNames = new List<string>
    {
        "Anbara", "Anjohl", "Faren", "Jaro", "Kalem", "Krim", "Kubus", "Latara", "Latha", "Lenaris", "Li", "Tahna", "Reil", "Ro", "Winn"
    };

    private static string GenerateBarzanName()
    {
        return BarzanNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> BarzanNames = new List<string>
    {
        "Amma", "Attis", "Bhavani", "Nhan", "Ryess", "Servu", "Tolpra"
    };

    private static string GenerateBenziteName(Gender gender)
    {
        return gender == Gender.Male
            ? BenziteMaleNames.OrderBy(n => Util.GetRandom()).First()
            : BenziteFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> BenziteMaleNames = new List<string>
    {
        "Cardok", "Kamis", "Laporin", "Mendon", "Monyodin", "Mordock", "Oorv", "Selidok"
    };
    private static readonly List<string> BenziteFemaleNames = new List<string>
    {
        "Dralia", "Hava", "Hoya", "Magark", "Mardral", "Marya", "N’Verix", "Salmak", "Shelzane", "Veldon"
    };

    private static string GenerateBetazoidName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? BetazoidMaleNames.OrderBy(n => Util.GetRandom()).First()
            : BetazoidFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = BetazoidFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> BetazoidMaleNames = new List<string>
    {
        "Konal", "Reban", "Xani", "Enon", "Dael", "Etas", "Andal", "Kolel", "Atani", "Devoni", "Algar", "Jensar", "Nikael", "Kalos", "Rennan"
    };
    private static readonly List<string> BetazoidFemaleNames = new List<string>
    {
        "Deanna", "Ania", "Kestra", "Lwaxanna", "Dalera", "Gloranna", "Abeana", "Pekera", "Nissila", "Lomestra", "Ioza", "Pegira", "Nemenna", "Nerira", "Lojeea"
    };
    private static readonly List<string> BetazoidFamilyNames = new List<string>
    {
        "Grax", "Hagen", "Morganth", "Stadi", "Dutrax", "Odutan", "Nelan", "Onovren", "Kader", "Nostrun", "Dulas", "Konin", "Ebesin"
    };

    private static string GenerateBetelgeusianName()
    {
        return BetelgeusianNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> BetelgeusianNames = new List<string>
    {
        "Cosmo Traitt", "Yor", "Jelfrit", "Badakar", "Shor", "Malkune"
    };

    private static string GenerateBolianName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? BolianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : BolianFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = BolianFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> BolianMaleNames = new List<string>
    {
         "Ardon", "Hars", "Boq’ta", "Brathaw", "Chell", "Rixx", "Zim"
    };
    private static readonly List<string> BolianFemaleNames = new List<string>
    {
        "Golwat", "Lysia", "Mitena"
    };
    private static readonly List<string> BolianFamilyNames = new List<string>
    {
        "Adislo", "Arlin", "Boq’ta", "Broht", "Haro", "Rixx", "V’Sal", "Vadosia", "Zier"
    };

    private static string GenerateBreenName()
    {
        return BreenNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> BreenNames = new List<string>
    {
        "Arisar", "Gor", "Gren", "L’ak", "Lok", "Pran", "Rong", "Ruhn", "Sar", "Tahal", "Trel", "Vart", "Vog", "Za’dag"
    };

    private static string GenerateBrikarName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? BrikarMaleNames.OrderBy(n => Util.GetRandom()).First()
            : BrikarFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = BrikarFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> BrikarMaleNames = new List<string>
    {
         "Cal", "Kelner", "Nyll", "Roakn", "Zak"
    };
    private static readonly List<string> BrikarFemaleNames = new List<string>
    {
        "Rok-Tahk", "Mirg"
    };
    private static readonly List<string> BrikarFamilyNames = new List<string>
    {
        "Kebron", "Saygur"
    };

    private static string GenerateBynarName()
    {
        var rng = new Random();
        char[] chars = new char[8];

        for (int i = 0; i < chars.Length; i++)
            chars[i] = (char)('0' + rng.Next(2)); // 0 or 1

        return new string(chars);
    }

    private static string GenerateCaitianName(Gender gender)
    {
        return gender == Gender.Male
            ? CaitianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : CaitianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> CaitianMaleNames = new List<string>
    {
        "R’Than", "C’horn", "Ur’Barr", "L’Enton,", "H’Sook", "K’Raka", "A’Outte", "V’Wilk", "A’Mathi", "Z’Thors"
    };
    private static readonly List<string> CaitianFemaleNames = new List<string>
    {
        "J’Aana", "M’ress", "S’isha", "K’irst", "N’Simi", "H’Lata", "A’Ahia", "P’Erone", "C’Nola", "Z’Thors"
    };

    private static string GenerateCardassianName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? CardassianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : CardassianFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = CardassianFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> CardassianMaleNames = new List<string>
    {
        "Trula", "Ganem", "Jolort", "Setem", "Dukat", "Meket", "Corak", "Seltan", "Revok", "Ekoor", "Hadar", "Telak", "Kovat", "Yaltar", "Evek", "Damar", "Parn", "Tremak"
    };
    private static readonly List<string> CardassianFemaleNames = new List<string>
    {
        "Mesha", "Eskei", "Asha", "Brocai", "Zarale", "Marata", "Itea", "Risha", "Gaska", "Kosha", "Alissa", "Marei", "Esha", "Seam", "Dearei"
    };
    private static readonly List<string> CardassianFamilyNames = new List<string>
    {
        "Priman", "Aanrad", "Drat", "Rin", "Liat", "Moset", "Tain", "Lang", "Pa’Dar", "Dal", "Ghemor", "Belor", "Prin", "Oddat", "Zenal"
    };

    private static string GenerateChangelingName(Gender gender)
    {
        return gender == Gender.Male
            ? ChangelingMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ChangelingFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> ChangelingMaleNames = new List<string>
    {
        "Odo", "Holak"
    };
    private static readonly List<string> ChangelingFemaleNames = new List<string>
    {
        "Lall", "Chiree"
    };

    private static string GenerateCyberneticallyEnhancedName(Character character)
    {
        return GenerateName(character, secondSpecies: true);
    }

    private static string GenerateCetaceanName()
    {
        return CetaceanNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> CetaceanNames = new List<string>
    {
        "Gillian", "Kimolu", "Matt", "Regis", "Jogani", "Nickie"
    };

    private static string GenerateDeltanName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? DeltanMaleNames.OrderBy(n => Util.GetRandom()).First()
            : DeltanFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = DeltanFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> DeltanMaleNames = new List<string>
    {
        "Jedda", "Clarze"
    };
    private static readonly List<string> DeltanFemaleNames = new List<string>
    {
        "Ilia", "Zinaida"
    };
    private static readonly List<string> DeltanFamilyNames = new List<string>
    {
        "Adzhin-Dall"
    };

    private static string GenerateDenobulanName(Gender gender)
    {
        return gender == Gender.Male
            ? DenobulanMaleNames.OrderBy(n => Util.GetRandom()).First()
            : DenobulanFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> DenobulanMaleNames = new List<string>
    {
        "Biras", "Bogga", "Delix", "Grolik", "Groznik", "Nettus", "Moga", "Morox", "Phlox", "Rinix", "Takis", "Tropp", "Tuglian", "Vinku", "Yolen", "Zepht", "Zinet"
    };
    private static readonly List<string> DenobulanFemaleNames = new List<string>
    {
        "Anari", "Andora", "Asha", "Daphina", "Feezal", "Forliza", "Kessil", "Liera", "Lusis", "Miral", "Natala", "Ninsen", "Henna", "Sabra", "Secka", "Symmé", "Trevis", "Vesena"
    };

    private static string GenerateDosiName(Gender gender)
    {
        return gender == Gender.Male
            ? DosiMaleNames.OrderBy(n => Util.GetRandom()).First()
            : DosiFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> DosiMaleNames = new List<string>
    {
        "Inglatu", "Mofala", "Ballu", "Vish"
    };
    private static readonly List<string> DosiFemaleNames = new List<string>
    {
        "Seketch", "Zyree", "Ballu", "Vish"
    };

    private static string GenerateDraiName(Gender gender)
    {
        return gender == Gender.Male
            ? DraiMaleNames.OrderBy(n => Util.GetRandom()).First()
            : DraiFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> DraiMaleNames = new List<string>
    {
        "Gilga", "Horu", "Netyr", "Coziss", "Kell"
    };
    private static readonly List<string> DraiFemaleNames = new List<string>
    {
        "Sekma", "Isett", "Netyr", "Coziss"
    };

    private static string GenerateEdosianName(Gender gender)
    {
        return gender == Gender.Male
            ? EdosianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : EdosianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> EdosianMaleNames = new List<string>
    {
        "Ainbelad", "Arex", "Ropetir", "Elwomo", "Cargarin", "Manoko", "Nusien", "Joelpo", "Darame", "Nileber"
    };
    private static readonly List<string> EdosianFemaleNames = new List<string>
    {
        "Nitemi", "Besheri", "Unora", "Kribara", "Zamare", "Cayamen", "Elanwa", "Matawa", "Bodanie", "Awiwa"
    };

    private static string GenerateEfrosianName(Gender gender)
    {
        return gender == Gender.Male
            ? EfrosianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : EfrosianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> EfrosianMaleNames = new List<string>
    {
        "Ra-ghoratreii", "Xin Ra-Havreii", "Ra-Yalix"
    };
    private static readonly List<string> EfrosianFemaleNames = new List<string>
    {
        "Hu’Ghrovlatrei", "Fellen Ni-Yaleii"
    };

    private static string GenerateElAurianName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? ElAurianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ElAurianFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = ElAurianFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> ElAurianMaleNames = new List<string>
    {
        "Doqtis", "Martus", "Tolian", "Yuriel"
    };
    private static readonly List<string> ElAurianFemaleNames = new List<string>
    {
        "Eylen", "Guinan", "Kassia", "Leandra"
    };
    private static readonly List<string> ElAurianFamilyNames = new List<string>
    {
        "Ilum", "Mazur", "Nox", "Soran", "Tyvan"
    };

    private static string GenerateFerengiName(Gender gender)
    {
        return gender == Gender.Male
            ? FerengiMaleNames.OrderBy(n => Util.GetRandom()).First()
            : FerengiFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> FerengiMaleNames = new List<string>
    {
        "Lexor", "Nurpax", "Nog", "Kakag", "Frector", "Quark", "Frink", "Torta", "Rom", "Zek", "Gigix", "Skel"
    };
    private static readonly List<string> FerengiFemaleNames = new List<string>
    {
        "Bosha", "Olene", "Ishka", "Helsel", "Gela", "Isall", "Norvira", "Vena", "Ganka", "Yaldis", "Pav"
    };

    private static string GenerateGrazeriteName(Gender gender)
    {
        return gender == Gender.Male
            ? GrazeriteMaleNames.OrderBy(n => Util.GetRandom()).First()
            : GrazeriteFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> GrazeriteMaleNames = new List<string>
    {
        "Anmer-Tasik", "Erasmo-Tes", "Saburo-Taff", "Jaresh-Inyo", "Zenko-Arwi", "Jacus-Kelle", "Luciro-Asi"
    };
    private static readonly List<string> GrazeriteFemaleNames = new List<string>
    {
        "Milina-Summ", "Photine-Mon", "Maevra-Rewe", "Tanti-Gome", "Mintu-Tian", "Natali-Leag"
    };

    private static string GenerateHaliianName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? HaliianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : HaliianFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = HaliianFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> HaliianMaleNames = new List<string>
    {
        "Franic", "Goker", "Rowlan", "Devar", "Atall", "Ordst", "Jayce", "Valtern", "Cale", "Nereus", "Norrish"
    };
    private static readonly List<string> HaliianFemaleNames = new List<string>
    {
        "Lympia", "Nathali", "Angeal", "Aquiel", "Camil", "Laura", "Sondra", "Jardine", "Anisa", "Sabia"
    };
    private static readonly List<string> HaliianFamilyNames = new List<string>
    {
        "Mahki", "Santosi", "Uhnari", "Kinge", "Rozenn", "Terzi", "Abeln", "Kedzi", "Albini", "Nani", "Apito"
    };

    private static string GenerateHologramName(Character character)
    {
        return GenerateName(character, secondSpecies: true);
    }

    private static string GenerateIllyrianName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? IllyrianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : IllyrianFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = IllyrianFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> IllyrianMaleNames = new List<string>
    {
        "Ivan", "Hudek", "Usarn"
    };
    private static readonly List<string> IllyrianFemaleNames = new List<string>
    {
        "Neera", "Una"
    };
    private static readonly List<string> IllyrianFamilyNames = new List<string>
    {
        "Chin", "Riley", "Ketoul"
    };

    private static string GenerateJemHadarName()
    {
        return $"{JemHadarFirstPartNames.OrderBy(n => Util.GetRandom()).First()}'{JemHadarSecondPartNames.OrderBy(n => Util.GetRandom()).First()}";
    }
    private static readonly List<string> JemHadarFirstPartNames = new List<string>
    {
        "Amat", "Arak", "Duran", "Goran", "Ikat", "Ixtana", "Kudak", "Lamar", "Limara", "Meso", "Omet", "Remata", "Talak", "Temo", "Toman", "Virak", "Yak"
    };
    private static readonly List<string> JemHadarSecondPartNames = new List<string>
    {
        "Adar", "Agar", "Clan", "Etan", "Igan", "Ika", "Iklan", "Kara", "Rax", "Son", "Talan", "Taral", "Torax", "Ukan", "Zuma"
    };

    private static string GenerateJyeName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? JyeMaleNames.OrderBy(n => Util.GetRandom()).First()
            : JyeFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = JyeFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> JyeMaleNames = new List<string>
    {
        "Bellah", "Carru", "Ettria", "Gunnara", "Jojjah", "Moddi", "Pallon", "Ruddis", "Urroin", "Wefft", "Chellick", "Kollarn", "Parett", "Mattack", "Wuttallet", "Donnarrek", "Sorretten", "Garrek", "Bennick", "Charelenn"
    };
    private static readonly List<string> JyeFemaleNames = new List<string>
    {
        "Bellah", "Carru", "Ettria", "Gunnara", "Jojjah", "Moddi", "Pallon", "Ruddis", "Urroin", "Wefft", "Jesal", "Farna", "Nalah", "Bejal", "Valona", "Meris", "Salah", "Harena", "Lalona", "Jalya"
    };
    private static readonly List<string> JyeFamilyNames = new List<string>
    {
        "Kales", "Hormal", "Terrek", "Questel", "Corele", "Volel", "Foralen", "Murcosta", "Nertal", "Ballek"
    };

    private static string GenerateKaremmaName(Gender gender)
    {
        return gender == Gender.Male
            ? KaremmaMaleNames.OrderBy(n => Util.GetRandom()).First()
            : KaremmaFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> KaremmaMaleNames = new List<string>
    {
        "Hanok", "Ornithar", "Bulko", "Yebesh"
    };
    private static readonly List<string> KaremmaFemaleNames = new List<string>
    {
        "Nethys", "Zarestra", "Bulko", "Yebesh"
    };

    private static string GenerateKellerunName()
    {
        return KellerunNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> KellerunNames = new List<string>
    {
        "Ayelle", "Carzot", "Defren", "Ferro", "Harreb", "Korlom", "Mennor", "Pherri", "Rayner", "Sharat", "Tivana", "Wennix"
    };

    private static string GenerateKelpianName()
    {
        return KelpianNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> KelpianNames = new List<string>
    {
        "Brinna", "Dor’na", "Kaladar", "Lin’lev", "Saru", "Su’Vyn", "Trialla", "Tuvu", "Vilara"
    };

    private static string GenerateKlingonName(Gender gender)
    {
        return gender == Gender.Male
            ? KlingonMaleNames.OrderBy(n => Util.GetRandom()).First()
            : KlingonFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> KlingonMaleNames = new List<string>
    {
        "Be’etor", "Cheng", "Mogh", "Qeng", "Torgh", "Moq'Var", "M'Keth", "Karuk", "Martok"
    };
    private static readonly List<string> KlingonFemaleNames = new List<string>
    {
        "‘a’Setbur", "HuS", "lurSa’", "Mara", "Loor", "Hereg"
    };

    private static string GenerateKtarianName(Gender gender)
    {
        return gender == Gender.Male
            ? KtarianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : KtarianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> KtarianMaleNames = new List<string>
    {
        "Rafen", "Tomishamin", "Lazos", "Mizan", "Dukannigarm", "Koolen", "Barhenk", "Greskrendtegk"
    };
    private static readonly List<string> KtarianFemaleNames = new List<string>
    {
        "Nives", "Etana", "Milosama", "Brunmohley", "Jezas", "Selit", "Meriana", "Reginalundula"
    };

    private static string GenerateLiberatedBorgName(Character character)
    {
        var chance = Util.GetRandom(100) + 1;

        if (chance <= 10)
            return GenerateName(character, secondSpecies: true);

        var count = Util.GetRandom(9) + 4;
        var designation = Util.GetRandom(count) + 1;

        return $"{NumberHelper.EnglishNumbers[designation]} of {NumberHelper.EnglishNumbers[count]}";
    }

    private static string GenerateLokirrimName(Gender gender)
    {
        return gender == Gender.Male
            ? LokirrimMaleNames.OrderBy(n => Util.GetRandom()).First()
            : LokirrimFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> LokirrimMaleNames = new List<string>
    {
        "Ramden", "Nadir", "Banlin", "Anitel", "Orlena", "Karin", "Cordel", "Artev", "Vanar", "Dennor", "Sanak", "Rusams", "Junark", "Gerhan", "Vacten", "Stesson", "Elderk"
    };
    private static readonly List<string> LokirrimFemaleNames = new List<string>
    {
        "Ramden", "Nadir", "Banlin", "Anitel", "Orlena", "Karin", "Cordel", "Zeryn", "Caran", "Tatin", "Talre", "Minal", "Sende", "Leanden", "Maydis", "Shanel", "Ellin"
    };

    private static string GenerateLurianName(Gender gender)
    {
        return gender == Gender.Male
            ? LurianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : LurianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> LurianMaleNames = new List<string>
    {
        "Morn", "Lork", "Gresh", "Slurr"
    };
    private static readonly List<string> LurianFemaleNames = new List<string>
    {
        "Eltessa", "Zyrionda", "Gresh", "Slurr"
    };

    private static string GenerateMariName(Gender gender)
    {
        return gender == Gender.Male
            ? MariMaleNames.OrderBy(n => Util.GetRandom()).First()
            : MariFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> MariMaleNames = new List<string>
    {
        "Tonane", "Norme", "Ande", "Sana", "Nalde", "Kline", "Osiall", "Tanel", "Santill", "Sharat", "Trupill", "Sebat", "Pritt", "Bennane", "Meron", "Maral"
    };
    private static readonly List<string> MariFemaleNames = new List<string>
    {
        "Tonane", "Norme", "Ande", "Sana", "Nalde", "Kline", "Nani", "Rina", "Edi", "Nimira", "Tirra", "Katina", "Minni", "Talli", "Ronzela", "Amali", "Elli"
    };

    private static string GenerateMoneanName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? MoneanMaleNames.OrderBy(n => Util.GetRandom()).First()
            : MoneanFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = MoneanFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> MoneanMaleNames = new List<string>
    {
        "Muloh", "Bahlo", "Zerha", "Kome", "Jelah", "Hurpa", "Gaehe", "Hurgo", "Korp", "Baguk", "Movok", "Waguc", "Berkus", "Pumop", "Jobol", "Burgo"
    };
    private static readonly List<string> MoneanFemaleNames = new List<string>
    {
        "Muloh", "Bahlo", "Zerha", "Kome", "Jelah", "Hurpa", "Gaehe", "Jula", "Poho", "Mamaw", "Baloa", "Wamah", "Halola", "Kugla", "Wola", "Layha"
    };
    private static readonly List<string> MoneanFamilyNames = new List<string>
    {
        "Zulohu", "Bahaho", "Mowel", "Ahlog", "Unajal", "Elgoha", "Omol", "Malom"
    };

    private static string GenerateOcampaName(Gender gender)
    {
        return gender == Gender.Male
            ? OcampaMaleNames.OrderBy(n => Util.GetRandom()).First()
            : OcampaFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> OcampaMaleNames = new List<string>
    {
        "Kelis", "Das", "Terel", "Kalen", "Talas", "Fergas", "Voralis", "Retis", "Nodas", "Jonarel", "Ferel", "Benil", "Lorlaren", "Dagis", "Nornan", "Foren", "Jerden", "Dulon", "Kelonal", "Keggis"
    };
    private static readonly List<string> OcampaFemaleNames = new List<string>
    {
        "Kelis", "Das", "Terel", "Kalen", "Talas", "Fergas", "Voralis", "Retis", "Nodas", "Jonarel", "Lesa", "Morana", "Ulona", "Pala", "Bella", "Terres", "Klaes", "Rayal", "Olona", "Nahal"
    };

    private static string GenerateOrionName(Gender gender)
    {
        return gender == Gender.Male
            ? OrionMaleNames.OrderBy(n => Util.GetRandom()).First()
            : OrionFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> OrionMaleNames = new List<string>
    {
        "Prasad", "Shretsh", "Jagadish", "Amaar"
    };
    private static readonly List<string> OrionFemaleNames = new List<string>
    {
        "Partha", "Seema"
    };

    private static string GenerateOsnullusName()
    {
        return OsnullusNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> OsnullusNames = new List<string>
    {
        "Aemmo", "Hivfa", "Rahma", "Srwell"
    };

    private static string GenerateParadanName(Gender gender)
    {
        return gender == Gender.Male
            ? ParadanMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ParadanFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> ParadanMaleNames = new List<string>
    {
        "Coutu", "Sebeksyr", "Zeill", "Shatu"
    };
    private static readonly List<string> ParadanFemaleNames = new List<string>
    {
        "Quetzla", "Maceda", "Zeill", "Shatu"
    };

    private static string GeneratePendariName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? PendariMaleNames.OrderBy(n => Util.GetRandom()).First()
            : PendariFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var clanName = PendariClanNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {clanName}";
    }
    private static readonly List<string> PendariMaleNames = new List<string>
    {
        "Rei", "Eli", "Dalvyo", "Makal", "Amsen", "Rox", "Vier", "Jax", "Den", "Pet", "Ris", "Nik", "Mar", "Teo", "Voy", "Ton", "Tek", "Dri", "Fen", "Sok", "Tum"
    };
    private static readonly List<string> PendariFemaleNames = new List<string>
    {
        "Rei", "Eli", "Dalvyo", "Makal", "Amsen", "Rox", "Vier", "Myral", "Ancole", "Elanme", "Listah", "Istana", "Qulin", "Reyge", "Jestepe"
    };
    private static readonly List<string> PendariClanNames = new List<string>
    {
        "Manu", "Driras", "Rettab", "Chanom", "Gridou", "Nefic", "Phinso", "Menbe", "Biusk"
    };

    private static string GenerateRakhariName(Gender gender)
    {
        return gender == Gender.Male
            ? RakhariMaleNames.OrderBy(n => Util.GetRandom()).First()
            : RakhariFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> RakhariMaleNames = new List<string>
    {
        "Croden", "Malar", "Nichil", "Heldix"
    };
    private static readonly List<string> RakhariFemaleNames = new List<string>
    {
        "Yareth", "Etheran", "Nichil", "Heldix"
    };

    private static string GenerateRigellianChelonName(Gender gender)
    {
        return gender == Gender.Male
            ? RigellianChelonMaleNames.OrderBy(n => Util.GetRandom()).First()
            : RigellianChelonFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> RigellianChelonMaleNames = new List<string>
    {
        "T’k-agha", "Genn", "Stek’ghen"
    };
    private static readonly List<string> RigellianChelonFemaleNames = new List<string>
    {
        "Salka", "Ash’lak", "Dakla’"
    };

    private static string GenerateRigellianJelnaName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? RigellianJelnaMaleNames.OrderBy(n => Util.GetRandom()).First()
            : RigellianJelnaFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = RigellianJelnaFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> RigellianJelnaMaleNames = new List<string>
    {
        "Jemer", "Shalma"
    };
    private static readonly List<string> RigellianJelnaFemaleNames = new List<string>
    {
        "Lahvon", "Velkal"
    };
    private static readonly List<string> RigellianJelnaFamilyNames = new List<string>
    {
        "Pahtel", "Zehron"
    };

    private static string GenerateRisianName(Gender gender)
    {
        return gender == Gender.Male
            ? RisianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : RisianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> RisianMaleNames = new List<string>
    {
        "Doranis", "Melek", "Oran"
    };
    private static readonly List<string> RisianFemaleNames = new List<string>
    {
        "Aradnis", "Elianjah", "Joval"
    };

    private static string GenerateRomulanName(Gender gender)
    {
        return gender == Gender.Male
            ? RomulanMaleNames.OrderBy(n => Util.GetRandom()).First()
            : RomulanFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> RomulanMaleNames = new List<string>
    {
        "Verohk"
    };
    private static readonly List<string> RomulanFemaleNames = new List<string>
    {
        "Malar"
    };

    private static string GenerateSaurianName(Gender gender)
    {
        return SaurianNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> SaurianNames = new List<string>
    {
        "Vk’chk’tk (Victoria)", "Sh’larlst (Shae)", "Gr’hsk-ha’sha (Gaius)", "Lss’t-kel’sar (Linus)"
    };

    private static string GenerateSikarianName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? SikarianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : SikarianFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = SikarianFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> SikarianMaleNames = new List<string>
    {
        "Posel", "Harge", "Marce", "Senel", "Alanel", "Sinom", "Rosar", "Baret", "Gathorel", "Japenel", "Seberal", "Naderen", "Kanel"
    };
    private static readonly List<string> SikarianFemaleNames = new List<string>
    {
        "Posel", "Harge", "Marce", "Senel", "Alanel", "Aldena", "Halle", "Kisteri", "Jalelli", "Corta", "Suleila", "Jodela", "Carela", "Diena"
    };
    private static readonly List<string> SikarianFamilyNames = new List<string>
    {
        "Otel", "Labin", "Solis", "Tann", "Almar", "Miton", "Moras", "Goull", "Mitlon", "Donal"
    };

    private static string GenerateSkreeaaName(Gender gender)
    {
        return gender == Gender.Male
            ? SkreeaaMaleNames.OrderBy(n => Util.GetRandom()).First()
            : SkreeaaFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> SkreeaaMaleNames = new List<string>
    {
        "Kelcho", "Tumak", "Kolden", "Hartik"
    };
    private static readonly List<string> SkreeaaFemaleNames = new List<string>
    {
        "Haneek", "Kachaya", "Kolden", "Hartik"
    };

    private static string GenerateSonaName(Gender gender)
    {
        return gender == Gender.Male
            ? SonaMaleNames.OrderBy(n => Util.GetRandom()).First()
            : SonaFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> SonaMaleNames = new List<string>
    {
        "Ru’afo", "Soboi", "Wy’nalido", "Vesh"
    };
    private static readonly List<string> SonaFemaleNames = new List<string>
    {
        "Var’esheshka", "Tu’la", "Wy’nalido", "Vesh"
    };

    private static string GenerateSoongTypeAndroidName()
    {
        return SoongTypeAndroidNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> SoongTypeAndroidNames = new List<string>
    {
        "B-4", "Data", "Lal", "Lore"
    };

    private static string GenerateTalaxianName(Gender gender)
    {
        return gender == Gender.Male
            ? TalaxianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : TalaxianFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> TalaxianMaleNames = new List<string>
    {
        "Xoma", "Karixa", "Palax", "Graxe", "Jonaxa", "Mitxi", "Adrinax", "Brax", "Jirex", "Titix", "Spirox", "Edix", "Adax", "Cantax", "Maxon", "Soxil", "Maldaxet"
    };
    private static readonly List<string> TalaxianFemaleNames = new List<string>
    {
        "Xoma", "Karixa", "Palax", "Graxe", "Jonaxa", "Mitxi", "Adrinax", "Dexa", "Palaxia", "Naxie", "Alaxa", "Terexi", "Millex", "Lanexi", "Axina", "Emaxa", "Jexa"
    };

    private static string GenerateTamarianName()
    {
        return TamarianNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> TamarianNames = new List<string>
    {
        "Varlok", "Trayshun", "Rinduk", "Shileez", "Grandor", "Norak"
    };

    private static string GenerateTellariteName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? TellariteMaleNames.OrderBy(n => Util.GetRandom()).First()
            : TellariteFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var prefix = TellaritePrefixes.OrderBy(n => Util.GetRandom()).First();

        var familyName = TellariteFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {prefix} {familyName}";
    }
    private static readonly List<string> TellariteMaleNames = new List<string>
    {
        "Prugm", "Brag", "Dash", "Gisich", "Gullerg", "Zankir", "Hellek", "Trar", "Jorsh", "Geshniv", "Tuk", "Rinkog", "Veth", "Cek", "Gullak"
    };
    private static readonly List<string> TellariteFemaleNames = new List<string>
    {
        "Pola", "Cherthish", "Zhuggaa", "Torthem", "Neshlel", "Verg", "Kholo", "Fratho", "Skig", "Vaolli", "Glavom", "Nihraogh", "Ghand", "Rensh"
    };
    private static readonly List<string> TellaritePrefixes= new List<string>
    {
        "bav", "glov", "blasch", "lorin", "jav", "bim", "glasch"
    };
    private static readonly List<string> TellariteFamilyNames = new List<string>
    {
        "Gronnahk", "Nonkursh", "Slaal", "Ker", "Zhiv", "Blav", "Zhuffand", "Khebloss", "Pend", "Brin", "Wenkurn", "Gerkow", "Khutohk", "Jagh", "Krer"
    };

    private static string GenerateToskName(Gender gender)
    {
        return "Tosk";
    }

    private static string GenerateTrillName(Gender gender, ICollection<string> traits)
    {
        var firstName = gender == Gender.Male
            ? TrillMaleNames.OrderBy(n => Util.GetRandom()).First()
            : TrillFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = string.Empty;

        familyName = traits.Any(x => x.Contains("Symbiote"))
            ? traits.First(x => x.Contains("Symbiote")).Split(' ').First()
            : TrillFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> TrillMaleNames = new List<string>
    {
        "Arjin", "Bejal", "Curzon", "Hanor", "Joran", "Malko", "Selin", "Timor", "Tobin", "Torias", "Verad", "Yedrin", "Keman", "Sabin", "Joal", "Dorin"
    };
    private static readonly List<string> TrillFemaleNames = new List<string>
    {
        "Audrid", "Azala", "Emony", "Kareel", "Lenara", "Nilani", "Reeza", "Zharaina", "Koria", "Lidra", "Diranne", "Kimoni", "Larista", "Vidria", "Kehdza"
    };
    private static readonly List<string> TrillFamilyNames = new List<string>
    {
        "Nedan", "Sozenn", "Rulon", "Les", "Tral", "Inazin", "Hama", "Kelen", "Imonim", "Razix", "Idiron", "Paron", "Tanan", "Sulil", "Kerev"
    };
    private static readonly List<string> TrillSymbioteNames = new List<string>
    {
        "Jexen", "Del", "Ogar", "Kyl", "Eku", "Nala", "Cela", "Pohr", "Ral", "Okir", "Etahn", "Lahl"
    };

    private static string GenerateTureiName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? TureiMaleNames.OrderBy(n => Util.GetRandom()).First()
            : TureiFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = TureiFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> TureiMaleNames = new List<string>
    {
        "Busal", "Derran", "Warrek", "Sarrvel", "Kiran", "Arrolen", "Kenuer", "Shilsen", "Bellas", "Torral", "Peral", "Norrick", "Relarr", "Mariek", "Berrel", "Varrolik", "Julear", "Desteck"
    };
    private static readonly List<string> TureiFemaleNames = new List<string>
    {
        "Busal", "Derran", "Warrek", "Sarrvel", "Kiran", "Arrolen", "Kenuer", "Shilsen", "Pesta", "Alerri", "Trelli", "Errika", "Rellen", "Harrila", "Jularri", "Waseun", "Donwani"
    };
    private static readonly List<string> TureiFamilyNames = new List<string>
    {
        "Turell", "Buhese", "Kiralur", "Wanoti", "Kotathi", "Hailova", "Jailance", "Madmika"
    };

    private static string GenerateVortaName(Gender gender)
    {
        return VortaNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> VortaNames = new List<string>
    {
        "Taris", "Wei'yeir", "Weyoun"
    };

    private static string GenerateVulcanName(Gender gender)
    {
        return gender == Gender.Male
            ? VulcanMaleNames.OrderBy(n => Util.GetRandom()).First()
            : VulcanFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> VulcanMaleNames = new List<string>
    {
        "Aravik", "Delvok", "Kovar", "Muroc", "Rekan", "Salok", "Savel", "Sevek", "Skon", "Soral", "Sutok", "Syrran", "Tekav", "Tolek", "Velik", "T'Mek"
    };
    private static readonly List<string> VulcanFemaleNames = new List<string>
    {
        "Falor", "Metana", "Perren", "T’Karra", "T’Laan", "T’Lar", "T’Les", "T’Mal", "T’Paal", "T’Pan", "T’Rel", "T’Vran", "Seleya", "Simora", "V’Lar"
    };

    private static string GenerateWadiName(Gender gender)
    {
        return gender == Gender.Male
            ? WadiMaleNames.OrderBy(n => Util.GetRandom()).First()
            : WadiFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> WadiMaleNames = new List<string>
    {
        "Falow", "Miranath", "Kalyn", "Peven"
    };
    private static readonly List<string> WadiFemaleNames = new List<string>
    {
        "Shou’lu", "Ecardra", "Kalyn", "Peven"
    };

    private static string GenerateXaheanName()
    {
        return XaheanNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> XaheanNames = new List<string>
    {
        "Caler No Fi Dafili", "Drex Dar Mala So Lesk", "Foto Mri Ka Se Wachi", "Me Hani Ika Hali Ka Po", "Vinters Saba Ra Ke Fa Nobi"
    };

    private static string GenerateXindiArborealName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? XindiArborealMaleNames.OrderBy(n => Util.GetRandom()).First()
            : XindiArborealFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = XindiArborealFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> XindiArborealMaleNames = new List<string>
    {
        "Janner", "Gralik"
    };
    private static readonly List<string> XindiArborealFemaleNames = new List<string>
    {
        "Adela", "Rolindis"
    };
    private static readonly List<string> XindiArborealFamilyNames = new List<string>
    {
        "Durr"
    };

    private static string GenerateXindiInsectoidName(Gender gender)
    {
        return "?????";
    }

    private static string GenerateXindiPrimateName(Gender gender)
    {
        return gender == Gender.Male
            ? XindiPrimateMaleNames.OrderBy(n => Util.GetRandom()).First()
            : XindiPrimateFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> XindiPrimateMaleNames = new List<string>
    {
        "Degra", "Ragnar", "Toki"
    };
    private static readonly List<string> XindiPrimateFemaleNames = new List<string>
    {
        "Bryn", "Guyda", "Hreidur"
    };

    private static string GenerateXindiReptilianName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? XindiReptilianMaleNames.OrderBy(n => Util.GetRandom()).First()
            : XindiReptilianFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = XindiReptilianFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> XindiReptilianMaleNames = new List<string>
    {
        "Dankra", "Guruk"
    };
    private static readonly List<string> XindiReptilianFemaleNames = new List<string>
    {
        "Igak", "Krell"
    };
    private static readonly List<string> XindiReptilianFamilyNames = new List<string>
    {
        "Dolim"
    };

    private static string GenerateZahlName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? ZahlMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ZahlFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = ZahlFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> ZahlMaleNames = new List<string>
    {
        "Luren", "Kley", "Jori", "Gabel", "Bhana", "Cirde", "Amaro", "Degna", "Ando", "Tromo", "Deon", "Vanil", "Darab", "Leom", "Gree", "Gesur", "Hanar", "Lelsh"
    };
    private static readonly List<string> ZahlFemaleNames = new List<string>
    {
        "Luren", "Kley", "Jori", "Gabel", "Bhana", "Cirde", "Amaro", "Persa", "Halya", "Dijah", "Morna", "Fani", "Balwa", "Fulna", "Essa", "Zare", "Nalise", "Pente"
    };
    private static readonly List<string> ZahlFamilyNames = new List<string>
    {
        "Wikan", "Tigh", "Temb", "Sami", "Mahid", "Remue", "Dregor", "Sedet", "Dalin", "Ketpor"
    };

    private static string GenerateZakdornName(Gender gender)
    {
        var firstName = gender == Gender.Male
            ? ZakdornMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ZakdornFemaleNames.OrderBy(n => Util.GetRandom()).First();

        var familyName = ZakdornFamilyNames.OrderBy(n => Util.GetRandom()).First();

        return $"{firstName} {familyName}";
    }
    private static readonly List<string> ZakdornMaleNames = new List<string>
    {
        "Gruhn", "Jir", "Koll", "Sirna"
    };
    private static readonly List<string> ZakdornFemaleNames = new List<string>
    {
        "Bel", "Myk", "Orym"
    };
    private static readonly List<string> ZakdornFamilyNames = new List<string>
    {
        "Azernal", "Bunkrep", "Kolrami", "Roplik"
    };

    private static string GenerateZaraniteName(Gender gender)
    {
        return gender == Gender.Male
            ? ZaraniteMaleNames.OrderBy(n => Util.GetRandom()).First()
            : ZaraniteFemaleNames.OrderBy(n => Util.GetRandom()).First();
    }
    private static readonly List<string> ZaraniteMaleNames = new List<string>
    {
        "Castel", "Makan", "Keshen", "Shrive", "Rayan", "Perraul", "Jossmah", "Kantasen", "Noorber", "Vosgi"
    };
    private static readonly List<string> ZaraniteFemaleNames = new List<string>
    {
        "Doraki", "Neelu", "Ayami", "Karis", "Elensa", "Irinu", "Kiran", "Tristi", "Lyudmi", "Natelani", "Adelyna"
    };

    private static string GenerateCommonName()
    {
        var personGenerator = new PersonNameGenerator();

        return personGenerator.GenerateRandomFirstName();
    }
}
