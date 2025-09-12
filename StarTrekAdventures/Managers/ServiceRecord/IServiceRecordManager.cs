using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IServiceRecordManager
{
    List<ServiceRecord> GetAll();

    List<string> GetAllNames();

    ServiceRecord Get(string name);
}
