using System;
using System.Threading;
using System.Threading.Tasks;
using AspNetCore2.FeatureToggle;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IntFromConfigToggle intFromConfigToggle;
        private readonly BoolFromConfigToggle boolFromconfigToggle;
        private readonly TimeBasedLogicToggle _timeBasedLogicToggle;

        public ValuesController(IntFromConfigToggle intFromConfigToggle, BoolFromConfigToggle boolFromConfigToggle, TimeBasedLogicToggle timeBasedLogicToggle)
        {
            this.intFromConfigToggle = intFromConfigToggle;
            boolFromconfigToggle = boolFromConfigToggle;
            _timeBasedLogicToggle = timeBasedLogicToggle;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            if (boolFromconfigToggle.FeatureEnabled)
                id = id * 2;

            if (intFromConfigToggle.ToggleValue == 0)
                return Ok(id);

            id += intFromConfigToggle.ToggleValue;
            return Ok(id);
        }

        [HttpGet("")]
        public async Task<ActionResult<DateTime>> Getdtm()
        {
            return Ok(new
            {
                TimeBasedlogicToggle = await _timeBasedLogicToggle.IsFeatureEnabledAsync(CancellationToken.None),
                IntFromConfigToggle = await intFromConfigToggle.GetToggleValueAsync(CancellationToken.None),
                BoolFromConfigToggle = await boolFromconfigToggle.GetToggleValueAsync(CancellationToken.None)
        });
        }
    }
}
