using Npgsql;
using StructureMap;

namespace MartenConnectorTester
{
    public class StructureMapRegistry : Registry
    {
        public StructureMapRegistry()
        {
            //IncludeRegistry(new OneExchangeProductMDatabaseProviderRegistry<IOEPMDatabase>(true));
            //IncludeRegistry(new DatabaseProviderRegistry<IQuotingDatabase>(true));
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
//            string connectionString = "host=wjv-postgres01;port=9432;" +
//                                      "database=dev-build02STOneExchangeProductManagement{Year};Integrated Security=true;Application Name='OEPM Storyteller - Test Execution';";
            string connectionString =
                "host=postgresqa.extendhealth.com;" +
                "port=5433;" +
                "database=QAOneExchangeProductManagement;" +
                "User ID=svc-quoting-qa@EXTENDHEALTH.COM;" +
                "Integrated Security=true;" +
                "Application Name='Quoting Consumers - QA';" +
                "Connection Idle Lifetime=120;" +
                "Keepalive=240;";
            
            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
//                    cmd.Connection = conn;
//                    cmd.CommandText =
//                        $"SELECT datname FROM pg_database where datistemplate = false and datname like '%{databaseName}%'";
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            var data = reader.GetString(0);
//                            int year;
//                            int.TryParse(data.Replace(databaseName, ""), out year);
//                            if (year != 0)k
//                            {
//                                _availableYears.Add(year);
//                            }
//                        }
//                    }
                }
            }
        }
    }
}
