using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Selectors.Version1;
using System.Collections.Generic;

namespace StarTrekAdventures.Managers.Version1
{
    public class TechnobabbleManager : ITechnobabbleManager
    {
        public ActionResult<string> GenerateTechnobabble()
        {
            return TechnobabbleSelector.GenerateTechnobabble();
        }

        public ActionResult<List<string>> GenerateTechnobabble(int number)
        {
            var results = new List<string>();

            for (int i = 0; i < number; i++)
                results.Add(TechnobabbleSelector.GenerateTechnobabble().Value);

            return results;
        }

        public ActionResult<string> GetAction()
        {
            return TechnobabbleSelector.GetAction();
        }

        public ActionResult<string> GetDescriptor()
        {
            return TechnobabbleSelector.GetDescriptor();
        }

        public ActionResult<string> GetSource()
        {
            return TechnobabbleSelector.GetSource();
        }

        public ActionResult<string> GetEffect()
        {
            return TechnobabbleSelector.GetEffect();
        }

        public ActionResult<string> GetDevice()
        {
            return TechnobabbleSelector.GetDevice();
        }
    }
}
