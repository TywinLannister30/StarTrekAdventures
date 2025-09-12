using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Models;

public class DepartmentRequirements : Departments
{
    public Operator Operator { get; set; }

    public string GetString()
    {
        var retVal = string.Empty;
        var requirementsCount = 0;
        var leadwithString = Operator == Operator.Or ? " or " : ", ";

        if (Command > 0)
        {
            retVal += AddValue($"Command {Command}+", requirementsCount > 0, leadwithString);
            requirementsCount++;
        }
        if (Conn > 0)
        {
            retVal += AddValue($"Conn {Conn}+", requirementsCount > 0, leadwithString);
            requirementsCount++;
        }
        if (Engineering > 0)
        {
            retVal += AddValue($"Engineering {Engineering}+", requirementsCount > 0, leadwithString);
            requirementsCount++;
        }
        if (Security > 0)
        {
            retVal += AddValue($"Security {Security}+", requirementsCount > 0, leadwithString);
            requirementsCount++;
        }
        if (Science > 0)
        {
            retVal += AddValue($"Science {Science}+", requirementsCount > 0, leadwithString);
            requirementsCount++;
        }
        if (Medicine > 0)
        {
            retVal += AddValue($"Medicine {Medicine}+", requirementsCount > 0, leadwithString);
        }

        return retVal;
    }

    private static string AddValue(string value, bool leadWith, string leadWithString)
    {
        var retVal = string.Empty;
        if (leadWith) retVal += leadWithString;
        retVal += value;
        return retVal;
    }
}
