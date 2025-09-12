using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class StarshipWeaponManager : IStarshipWeaponManager
{
    public List<StarshipWeapon> GetAll()
    {
        var weapons = StarshipWeaponSelector.GetAllWeapons();

        foreach (var weapon in weapons)
        {
            weapon.SetEffect();
        }

        return weapons;
    }

    public List<string> GetAllNames()
    {
        return StarshipWeaponSelector.GetAllWeapons().Select(x => x.Name).ToList();
    }

    public StarshipWeapon Get(string name)
    {
        var weapon = StarshipWeaponSelector.GetWeapon(name);

        weapon.SetEffect();

        return weapon;
    }
}
