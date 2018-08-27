using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BasicFeatureToggle.Interfaces;

namespace BasicFeatureToggle
{
    internal class SqlServerFeatureToggle : IFeatureToggle, IFeatureToggleAsync
    {
        private readonly string _connectionString;
        private readonly string _sqlStatement;
        private readonly Dictionary<string, object> _sqlStatementParameters;

        /// <inheritdoc />
        public SqlServerFeatureToggle(string connectionString, string sqlStatement) : this(connectionString, sqlStatement, null)
        {
        }

        /// <summary>
        ///     This feature toggle will connect to sql server to get the feature toggle value.
        /// </summary>
        /// <param name="connectionString">the connection string for the sql server where the flag is configured</param>
        /// <param name="sqlStatement">
        ///     the statement that will execute to retrieve the value, this should return a scalar boolean/(bit) value
        /// </param>
        /// <param name="parameters">optional parameters that can be used for a parameterized query, will be injected by name</param>
        public SqlServerFeatureToggle(string connectionString, string sqlStatement, Dictionary<string, object> parameters)
        {
            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrWhiteSpace(sqlStatement))
                throw new BasicFeatureToggleConfigurationException($"Connection string and sql statement must both be present. Please validate configuration for {GetType().Name}");
            _connectionString = connectionString;
            _sqlStatement = sqlStatement;
            _sqlStatementParameters = parameters;
        }

        public bool FeatureEnabled => EvaluateBooleanToggleValue();

        public async Task<bool> IsFeatureEnabledAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var cmd = GetSqlCommand(connection))
                {
                    return (bool) await cmd.ExecuteScalarAsync();
                }
            }
        }

        private bool EvaluateBooleanToggleValue()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var cmd = GetSqlCommand(connection))
                {
                    return (bool) cmd.ExecuteScalar();
                }
            }
        }

        private SqlCommand GetSqlCommand(SqlConnection connection)
        {
            var sqlCommand = new SqlCommand(_sqlStatement, connection);
            if (_sqlStatementParameters == null || _sqlStatementParameters.Count < 1)
                return sqlCommand;

            foreach (var parameter in _sqlStatementParameters)
                sqlCommand.Parameters.AddWithValue(parameter.Key, parameter.Value);

            return sqlCommand;
        }
    }
}