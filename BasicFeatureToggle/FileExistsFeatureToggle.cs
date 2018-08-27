using System.IO;
using BasicFeatureToggle.Interfaces;

namespace BasicFeatureToggle
{
    public class FileExistsFeatureToggle : IFeatureToggle
    {
        private readonly string _fileName;

        public FileExistsFeatureToggle(string fileName)
        {
            _fileName = fileName;
        }

        public bool FeatureEnabled => File.Exists(_fileName);
    }
}