using AspNet472.FeatureToggle;
using System;
using System.Web.Http;

namespace AspNet472.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly MultiplyByTwoFeatureToggle _multiplyToggle;
        private readonly AddExtraToResultFeatureToggle _addExtraToggle;

        public ValuesController(MultiplyByTwoFeatureToggle multiplyToggle, AddExtraToResultFeatureToggle addExtraToggle)
        {
            _multiplyToggle = multiplyToggle;
            _addExtraToggle = addExtraToggle;
        }
        // GET api/values/5
        public int Get(int id)
        {
            if (_multiplyToggle.FeatureEnabled)
                id = id * 2;

            if (_addExtraToggle.FeatureValue != null)
                id = id + Convert.ToInt32(_addExtraToggle.FeatureValue);

            return id;
        }
    }
}
