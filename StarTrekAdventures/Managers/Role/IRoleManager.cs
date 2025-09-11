using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IRoleManager
{
    List<Role> GetAll();

    List<string> GetAllNames();

    Role Get(string name);
}
