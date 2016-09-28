using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace SeleniumWebDriver.Examples.Chapter09
{
    public class DbManager
    {
        private static DbManager _instance;
        private bool _databaseTesting;

        private DbManager()
        {
            _databaseTesting = ConfigurationManager.AppSettings["databaseTests"] == "true";
        }

        public static DbManager Instance
        {
            get { return _instance ?? (_instance = new DbManager()); }
        }

        public void CreateSnapshot()
        {
            var location = Path.GetTempPath();
            var createSql = string.Format(DatabaseQueries.CreateSnapshot, location);
            RunScript(createSql);
        }

        public void RestoreSnapshot()
        {
            RunScript(DatabaseQueries.RestoreSnapshot);
        }

        public void DropSnapshot()
        {
            RunScript(DatabaseQueries.DropSnapshot);
        }

        private void RunScript(string script)
        {
            if (_databaseTesting)
            {
                try
                {
                    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
                    {
                        conn.Open();
                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = script;
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }
    }
}