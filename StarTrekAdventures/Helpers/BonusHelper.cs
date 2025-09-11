namespace StarTrekAdventures.Helpers;

public static class BonusHelper
{
    public static int ToBonus (this int attribute)
    {
        if (attribute >= 13) return 4;
        if (attribute >= 11) return 3;
        if (attribute >= 9) return 2;
        if (attribute >= 7) return 1;

        return 0;
    }
}
