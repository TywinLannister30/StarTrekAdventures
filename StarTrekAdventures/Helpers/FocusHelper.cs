using StarTrekAdventures.Constants;
using System.Reflection;

namespace StarTrekAdventures.Helpers;

public static class FocusHelper
{
    public static bool IsPsychologyFocus(string focus)
    {
        if (focus == Focus.Councelling ||
            focus == Focus.GuidedTherapy ||
            focus == Focus.NeuropsychologyOrPsychiatry ||
            focus == Focus.Parapsychology ||
            focus == Focus.Psychiatry ||
            focus == Focus.Psychoanalysis ||
            focus == Focus.Psychology ||
            focus == Focus.PsychosomaticDisorders ||
            focus == Focus.StressDisorders)
            return true;

        return false;
    }

    public static List<string> GetAllFocuses()
    {
        return typeof(Focus)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
            .Select(fi => (string)fi.GetRawConstantValue()!)
            .ToList();
    }
}
