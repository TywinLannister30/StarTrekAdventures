using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Models.Version1;

namespace StarTrekAdventures.Managers.Version1
{
    public interface ISpeciesManager
    {
        ActionResult<List<Species>> GetAllSpecies(string name);
        ActionResult<List<string>> GetAllSpeciesNames();
    }
}
