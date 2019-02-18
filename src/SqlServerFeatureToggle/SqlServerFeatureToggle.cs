using BasicFeatureToggle;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace SqlFeatureToggle
{
    public abstract class SqlServerFeatureToggle<T> : IFeatureToggle<T>
    {
        private readonly SqlServerFeatureToggleSettings _settings;

        /// <summary>
        ///     This feature toggle will connect to sql server to get a feature toggle value.
        /// </summary>
        /// <param name="settings">configuration to be used while retrieving configuration for this feature toggle.</param>
        public SqlServerFeatureToggle(SqlServerFeatureToggleSettings settings)
        {
            if (string.IsNullOrWhiteSpace(settings?.ConnectionString) || string.IsNullOrWhiteSpace(settings?.CommandText))
                throw new BasicFeatureToggleConfigurationException($"Connection string and sql statement must both be present. Please validate configuration for {GetType().Name}");
            _settings = settings;
        }

        protected abstract T ConvertScalarToGenericType(object o);

        public T ToggleValue
        {
            get
            {
                using (var connection = new SqlConnection(_settings.ConnectionString))
                {
                    connection.Open();
                    using (var cmd = GetSqlCommand(connection))
                    {
                        return ConvertScalarToGenericType(cmd.ExecuteScalar());
                    }
                }
            }
        }

        /// <summary>
        /// Returns a scalar value from the command provided
        /// </summary>
        /// <returns></returns>
        public async Task<T> GetToggleValueAsync(CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_settings.ConnectionString))
            {
                await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                using (var cmd = GetSqlCommand(connection))
                {
                    return ConvertScalarToGenericType(await cmd.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false));
                }
            }
        }

        private SqlCommand GetSqlCommand(SqlConnection connection)
        {
            var sqlCommand = new SqlCommand(_settings.CommandText, connection);
            if (!string.IsNullOrWhiteSpace(_settings.DefaultTypeParamName) && _settings.CommandText.Contains(_settings.DefaultTypeParamName))
                sqlCommand.Parameters.AddWithValue(_settings.DefaultTypeParamName, GetType().Name);
            return sqlCommand;
        }
    }
}