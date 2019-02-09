using System;
using System.Threading.Tasks;
using AspNetCore2.FeatureToggle;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AddExtraToResultFeatureToggle _addExtraToggle;
        private readonly MultiplyByTwoFeatureToggle _multiplyByTwoToggle;
        private readonly DtmToggle dtmToggle;

        public ValuesController(AddExtraToResultFeatureToggle addExtraToggle, MultiplyByTwoFeatureToggle multiplyByTwoToggle, DtmToggle dtmToggle)
        {
            _addExtraToggle = addExtraToggle;
            _multiplyByTwoToggle = multiplyByTwoToggle;
            this.dtmToggle = dtmToggle;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            if (_multiplyByTwoToggle.FeatureEnabled)
                id = id * 2;

            if (_addExtraToggle.ToggleValue == 0)
                return Ok(id);

            id = id + _addExtraToggle.ToggleValue;
            return Ok(id);
        }

        [HttpGet("")]
        public async Task<ActionResult<DateTime>> Getdtm()
        {
            return Ok(dtmToggle.GetToggleValueAsync());
        }
    }
}
