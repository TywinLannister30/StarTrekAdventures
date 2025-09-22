using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IValueSelector
{
    string ChooseValue(Character character);

    List<Value> GetAllValues();

    Value GetSpecificValue(string name);
}
