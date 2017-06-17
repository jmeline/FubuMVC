using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MartenConnectorTester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "host=wjv-postgres01;port=9432;" +
                                      "database=dev-build02STOneExchangeProductManagement{Year};Integrated Security=true;Application Name='OEPM Storyteller - Test Execution';";
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
//                            if (year != 0)
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
