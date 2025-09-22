using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class ServiceRecordManager : IServiceRecordManager
{
    private readonly IServiceRecordSelector _serviceRecordSelector;

    public ServiceRecordManager(IServiceRecordSelector serviceRecordSelector)
    {
        _serviceRecordSelector = serviceRecordSelector;
    }

    public List<ServiceRecord> GetAll()
    {
        return _serviceRecordSelector.GetAllServiceRecords();
    }

    public List<string> GetAllNames()
    {
        return _serviceRecordSelector.GetAllServiceRecords().Select(x => x.Name).ToList();
    }

    public ServiceRecord Get(string name)
    {
        return _serviceRecordSelector.GetServiceRecord(name);
    }
}
