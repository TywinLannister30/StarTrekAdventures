using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class RoleManager : IRoleManager
{
    private readonly IRoleSelector _roleSelector;

    public RoleManager(IRoleSelector roleSelector)
    {
        _roleSelector = roleSelector;
    }

    public List<Role> GetAll()
    {
        return _roleSelector.GetAllRoles();
    }

    public List<string> GetAllNames()
    {
        return _roleSelector.GetAllRoles().Select(x => x.Name).ToList();
    }

    public Role Get(string name)
    {
        return _roleSelector.GetRole(name);
    }
}
