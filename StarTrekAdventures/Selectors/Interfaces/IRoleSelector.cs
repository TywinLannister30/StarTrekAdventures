using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IRoleSelector
{
    Role ChooseRole(Character character);

    Role GetRole(string name);

    List<Role> GetAllRoles();
}
