using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class RoleManager : IRoleManager
{
    public List<Role> GetAll()
    {
        return RoleSelector.GetAllRoles();
    }

    public List<string> GetAllNames()
    {
        return RoleSelector.GetAllRoles().Select(x => x.Name).ToList();
    }

    public Role Get(string name)
    {
        return RoleSelector.GetRole(name);
    }
}
