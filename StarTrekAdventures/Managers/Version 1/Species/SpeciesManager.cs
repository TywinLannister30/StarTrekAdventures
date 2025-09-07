using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Models.Version1;
using StarTrekAdventures.Selectors.Version1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StarTrekAdventures.Managers.Version1
{
    public class SpeciesManager : ISpeciesManager
    {
        public SpeciesManager()
        {
        }

        public ActionResult<List<Species>> GetAllSpecies(string name)
        {
            var species = SpeciesSelector.GetAllSpecies();

            if (string.IsNullOrEmpty(name)) return species;

            return species.Where(x => x.Name.ToLower() == name.ToLower()).ToList();
        }

        public ActionResult<List<string>> GetAllSpeciesNames()
        {
            return SpeciesSelector.GetAllSpecies().Select(speciesModel => speciesModel.Name).ToList();
        }
    }
}
