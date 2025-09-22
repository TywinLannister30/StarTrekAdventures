using StarTrekAdventures.Helpers;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IServiceRecordSelector
{
    ServiceRecord ChooseServiceRecord(IRandomGenerator randomGenerator = null);

    List<ServiceRecord> GetAllServiceRecords();

    ServiceRecord GetServiceRecord(string name);
}
