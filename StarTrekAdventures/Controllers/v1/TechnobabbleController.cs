using Microsoft.AspNetCore.Mvc;
using StarTrekAdventures.Managers.Version1;
using System.Collections.Generic;

namespace StarTrekAdventures.Controllers.Version1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TechnobabbleController
    {
        private readonly ITechnobabbleManager _technobabbleManager;

        public TechnobabbleController(ITechnobabbleManager technobabbleManager)
        {
            _technobabbleManager = technobabbleManager;
        }

        [HttpGet]
        public ActionResult<string> Technobabble()
        {
            return _technobabbleManager.GenerateTechnobabble();
        }

        [HttpGet("{number}")]
        public ActionResult<List<string>> Technobabble(int number)
        {
            return _technobabbleManager.GenerateTechnobabble(number);
        }

        [HttpGet("Action")]
        public ActionResult<string> GetAction()
        {
            return _technobabbleManager.GetAction();
        }

        [HttpGet("Descriptor")]
        public ActionResult<string> GetDescriptor()
        {
            return _technobabbleManager.GetDescriptor();
        }

        [HttpGet("Source")]
        public ActionResult<string> GetSource()
        {
            return _technobabbleManager.GetSource();
        }

        [HttpGet("Effect")]
        public ActionResult<string> GetEffect()
        {
            return _technobabbleManager.GetEffect();
        }

        [HttpGet("Device")]
        public ActionResult<string> GetDevice()
        {
            return _technobabbleManager.GetDevice();
        }
    }
}
