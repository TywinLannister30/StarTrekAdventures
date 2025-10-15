namespace StarTrekAdventures.Constants;

public class Enums
{
    public enum CrewQuality
    {
        None = -1,
        Basic = 0,
        Proficient = 1,
        Talented = 2,
        Exceptional = 3
    }

    public enum Gender
    {
        None = 0,
        Male = 1,
        Female = 2
    }

    public enum InjuryType
    {
        Stun,
        StunOrDeadly,
        Deadly
    }

    public enum LifepathStage
    {
        Species = 1,
        Environemt = 2,
        Upbringing = 3,
        StarfleetAcademy = 4,
        Career = 5,
        CareerEvents = 6,
        FinishingTouches = 7
    }

    public enum NPCType
    {
        Minor,
        Notable,
        Major
    }

    public enum Operator
    {
        None = 0,
        And = 1,
        Or = 2
    }

    public enum StarshipWeaponType
    {
        None,
        Energy,
        Torpedo,
        Mine
    }

    public enum StarshipWeaponRange
    {
        None,
        Close,
        Medium,
        Long
    }

    public enum WeaponSize
    {
        OneHanded,
        TwoHanded
    }

    public enum WeaponType
    {
        Melee,
        Ranged
    }
}
