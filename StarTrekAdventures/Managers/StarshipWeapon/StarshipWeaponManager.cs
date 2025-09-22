using StarTrekAdventures.Models;
using StarTrekAdventures.Selectors;

namespace StarTrekAdventures.Managers;

public class StarshipWeaponManager : IStarshipWeaponManager
{
    private readonly IStarshipWeaponSelector _starshipWeaponSelector;

    public StarshipWeaponManager(IStarshipWeaponSelector starshipWeaponSelector)
    {
        _starshipWeaponSelector = starshipWeaponSelector;
    }

    public List<StarshipWeapon> GetAll()
    {
        var weapons = _starshipWeaponSelector.GetAllWeapons();

        foreach (var weapon in weapons)
        {
            weapon.SetEffect();
        }

        return weapons;
    }

    public List<string> GetAllNames()
    {
        return _starshipWeaponSelector.GetAllWeapons().Select(x => x.Name).ToList();
    }

    public StarshipWeapon Get(string name)
    {
        var weapon = _starshipWeaponSelector.GetWeapon(name);

        weapon.SetEffect();

        return weapon;
    }
}
