using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers.Version1;
using StarTrekAdventures.Models.Version1;
using StarTrekAdventures.Selectors.Version1;
using System.Collections.Generic;

namespace StarTrekAdventures.Controllers.Version1
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly ISpeciesManager _speciesManager;

        public SpeciesController(ISpeciesManager speciesManager)
        {
            _speciesManager = speciesManager;
        }

        [HttpGet]
        public ActionResult<List<Species>> Species(string name)
        {
            if (!string.IsNullOrEmpty(name) && SpeciesSelector.GetSpecies(name) == null)
                return BadRequest($"{name} is not a valid species.");

            return _speciesManager.GetAllSpecies(name);
        }

        [HttpGet("name")]
        public ActionResult<List<string>> SpeciesNames()
        {
            return _speciesManager.GetAllSpeciesNames();
        }
    }
}
