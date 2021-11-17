using System.Data;
using System.Data.SqlClient;



namespace CoreDemoADO.NET.Data
{
    public class DbHelper
    {

        private static string _connectionstring = "";


        public DbHelper(string connectionstring)
        {
            _connectionstring = connectionstring;
        }


        public string GetConnectionString()
        {
            return _connectionstring;
        }

        public static IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionstring);
        }

        public static IDbCommand CreateCommand(string cmdText, IDbConnection con)
        {
            return new SqlCommand(cmdText, (SqlConnection)con);
        }


        public static void AddParameter(IDbCommand command, string name, object value)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }


    }
}
