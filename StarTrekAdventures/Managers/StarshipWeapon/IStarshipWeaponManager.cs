using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface IStarshipWeaponManager
{
    List<StarshipWeapon> GetAll();

    List<string> GetAllNames();

    StarshipWeapon Get(string name);
}
