using BasicFeatureToggle.Internal;
using System;
using System.Threading.Tasks;

namespace BasicFeatureToggle
{
    public class EnabledDuringDateRangeToggle : IBooleanFeatureToggle
    {
        private readonly DateTime? _disableDate;
        private readonly DateTime _enableDate;
        private readonly bool _useUtcTime;

        /// <summary>
        ///     A feature toggle that will enable during the specified date range
        /// </summary>
        /// <param name="enableDate">This toggle will return false until the current date is greater than this date</param>
        /// <param name="disableDate">The toggle will return true until the current date is greater than this date</param>
        /// <param name="useUtcTime">when this parameter is set to true, UTC time will be used for the dates, otherwise local time will be used</param>
        public EnabledDuringDateRangeToggle(DateTime enableDate, DateTime? disableDate = null, bool useUtcTime = false)
        {
            if (enableDate == DateTime.MinValue)
                throw new BasicFeatureToggleConfigurationException($"Toggle begin date may not be DateTime.MinValue. Check configuration for the {GetType().Name} toggle.");
            if (disableDate != null && disableDate < enableDate)
                throw new BasicFeatureToggleConfigurationException($"Toggle being date must be less than end date. Check configuration for the {GetType().Name} toggle.");

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

        public Task<bool> IsFeatureEnabledAsync()
        {
            return Task.FromResult(FeatureEnabled);
        }
    }
}