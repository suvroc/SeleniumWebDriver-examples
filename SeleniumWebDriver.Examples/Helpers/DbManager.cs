using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Examples.Helpers
{
    public class DbManager
    {
        private static DbManager _instance;
        public static DbManager Instance
        {
            get
            {
                return _instance ?? (_instance = new DbManager());
            }
        }

        private DbManager() { }

        public void CreateSnapshot()
        {
            var location = Path.GetTempPath();
            var createSql = string.Format(DatabaseQueries.CreateSnapshot, location);
            this.RunScript(createSql);
        }

        public void RestoreSnapshot()
        {
            this.RunScript(DatabaseQueries.RestoreSnapshot);
        }

        public void DropSnapshot()
        {
            this.RunScript(DatabaseQueries.DropSnapshot);
        }

        private void RunScript(string script)
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
