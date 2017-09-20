using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Nicologies.SqlServerUtils.Metadata
{
	public class SqlServerDatabases
	{
		private static readonly List<string> SystemDatabases = new List<string>
		{
			"master",
			"tempdb",
			"model",
			"msdb"
		};
		public List<string> GetDatabaseNames(string instanceName)
		{
			var connection = new SqlConnectionStringBuilder
			{
				DataSource = instanceName,
				IntegratedSecurity = true,
				ConnectTimeout = 50
			};

			using (var sqlConn = new SqlConnection(connection.ToString()))
			{
				sqlConn.Open();

				var databases = new List<string>();
				foreach (DataRow row in sqlConn.GetSchema("Databases").Rows)
				{
					string dbName = row["database_name"].ToString();
					if (!SystemDatabases.Contains(dbName))
					{
						databases.Add(dbName);
					}
				}

				return databases;
			}
		}
	}
}
