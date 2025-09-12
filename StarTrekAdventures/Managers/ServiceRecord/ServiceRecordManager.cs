using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class ServiceRecordManager : IServiceRecordManager
{
    public List<ServiceRecord> GetAll()
    {
        return ServiceRecordSelector.GetAllServiceRecords();
    }

    public List<string> GetAllNames()
    {
        return ServiceRecordSelector.GetAllServiceRecords().Select(x => x.Name).ToList();
    }

    public ServiceRecord Get(string name)
    {
        return ServiceRecordSelector.GetServiceRecord(name);
    }
}
