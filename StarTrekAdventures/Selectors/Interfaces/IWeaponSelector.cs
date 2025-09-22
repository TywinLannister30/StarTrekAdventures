using StarTrekAdventures.Models;

namespace StarTrekAdventures.Selectors;

public interface IWeaponSelector
{
    Weapon GetWeapon(string name);

    WeaponQuality GetWeaponQuality(string name);

    List<Weapon> GetAllWeapons();
}
