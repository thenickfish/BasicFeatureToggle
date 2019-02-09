namespace SqlFeatureToggle
{
    public class SqlServerFeatureToggleSettings
    {
        /// <summary>
        /// The connection string for the sql server database containing your feature flag configuration
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// a sql command to retrieve the value for this feature flag
        /// </summary>
        public string CommandText { get; set; }

        /// <summary>
        /// If the CommandText property contains this text, it will be replaced with a parameter containing the classname of your feature toggle.
        /// i.e. GetType().Name
        /// </summary>
        public string DefaultTypeParamName { get; set; } = "@toggleName";
    }
}
