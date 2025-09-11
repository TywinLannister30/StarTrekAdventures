using StarTrekAdventures.Constants;

namespace StarTrekAdventures.Helpers;

public static class FocusHelper
{
    public static bool IsPsychologyFocus(string focus)
    {
        if (focus == Focus.Councelling ||
            focus == Focus.GuidedTherapy ||
            focus == Focus.NeuropsychologyOrPsychiatry ||
            focus == Focus.Psychiatry ||
            focus == Focus.Psychology ||
            focus == Focus.PsychosomaticDisorders ||
            focus == Focus.StressDisorders)
            return true;

        return false;
    }
}
