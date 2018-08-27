using System;
using BasicFeatureToggle.Interfaces;

namespace BasicFeatureToggle
{
    public class EnabledDuringDateRangeFeature : IFeatureToggle
    {
        private readonly DateTime? _disableDate;
        private readonly DateTime _enableDate;
        private readonly bool _useUtcTime;

        /// <summary>
        ///     This feature toggle will enable
        /// </summary>
        /// <param name="enableDate"></param>
        /// <param name="disableDate"></param>
        /// <param name="useUtcTime">when this parameter is set to true, UTC time will be used for the dates, otherwise local time will be used</param>
        public EnabledDuringDateRangeFeature(DateTime enableDate, DateTime? disableDate, bool useUtcTime = false)
        {
            _useUtcTime = useUtcTime;
            if (useUtcTime)
            {
                _enableDate = enableDate.ToUniversalTime();
                _disableDate = disableDate?.ToUniversalTime();
            }
            else
            {
                _enableDate = enableDate;
                _disableDate = disableDate;
            }
        }

        public bool FeatureEnabled
        {
            get
            {
                var now = _useUtcTime ? DateTime.UtcNow : DateTime.Now;
                return now > _enableDate && (now < _disableDate || _disableDate == null);
            }
        }
    }
}