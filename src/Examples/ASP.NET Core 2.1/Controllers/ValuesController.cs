using System;
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

        public ValuesController(AddExtraToResultFeatureToggle addExtraToggle, MultiplyByTwoFeatureToggle multiplyByTwoToggle)
        {
            _addExtraToggle = addExtraToggle;
            _multiplyByTwoToggle = multiplyByTwoToggle;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            if (_multiplyByTwoToggle.FeatureEnabled)
                id = id * 2;

            if (_addExtraToggle.FeatureValue == null)
                return Ok(id);

            id = id + Convert.ToInt32(_addExtraToggle.FeatureValue);
            return Ok(id);
        }
    }
}
