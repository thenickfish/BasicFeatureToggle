using BasicFeatureToggle.Internal;
using System.IO;
using System.Threading.Tasks;

namespace BasicFeatureToggle
{
    public class FileExistsFeatureToggle : BooleanFeatureToggle
    {
        private readonly string _fileName;

        public override bool FeatureEnabled => File.Exists(_fileName);

        /// <summary>
        /// A toggle that will return true based on the existence of a file
        /// </summary>
        /// <param name="fileName">the path to the file that enables this toggle</param>
        public FileExistsFeatureToggle(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new BasicFeatureToggleConfigurationException($"Filename must be provided. Please check the configuration of the {GetType().Name} toggle.");
            _fileName = fileName;
        }

        public override Task<bool> IsFeatureEnabledAsync() => Task.FromResult(FeatureEnabled);
    }
}