using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface ISpeciesManager
{
    List<Species> GetAllSpecies();

    List<string> GetAllSpeciesNames();

    Species GetSpecies(string name);
}
