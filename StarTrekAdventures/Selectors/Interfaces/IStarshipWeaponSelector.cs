using StarTrekAdventures.Models;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Selectors;

public interface IStarshipWeaponSelector
{
    StarshipWeapon GetWeapon(string name);

    WeaponQuality GetWeaponQuality(string name);

    List<StarshipWeapon> GetAllWeapons();

    StarshipWeapon GetRandomWeapon(Starship starship);

    StarshipWeapon GetRandomTypedWeapon(Starship starship, StarshipWeaponType weaponType);
}
