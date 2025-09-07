using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace StarTrekAdventures.Managers.Version1
{
    public interface ITechnobabbleManager
    {
        ActionResult<string> GenerateTechnobabble();
        ActionResult<List<string>> GenerateTechnobabble(int number);
        ActionResult<string> GetAction();
        ActionResult<string> GetDescriptor();
        ActionResult<string> GetSource();
        ActionResult<string> GetEffect();
        ActionResult<string> GetDevice();
    }
}
