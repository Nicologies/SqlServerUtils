using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Nicologies.SqlServerUtils.Metadata
{
	public class SqlServerInstanceNames
	{
		public List<string> GetSqlInstances()
		{
			var services = ServiceController.GetServices().Where(x => x.Status == ServiceControllerStatus.Running);
			return services.Where(r => IsMsSqlService(r)
				|| IsDefaultInstServiceName(r))
				.Select(NormalizeInstName)
				.Distinct()
				.ToList();
		}

		private static string NormalizeInstName(ServiceController r)
		{
			return InstancePathConversion.GetInstsPath(
				"LOCALHOST", r.ServiceName.ToUpperInvariant().Replace("MSSQL$", ""));
		}

		private static bool IsMsSqlService(ServiceController r)
		{
			return r.ServiceName.ToUpperInvariant().StartsWith("MSSQL$");
		}

		private static bool IsDefaultInstServiceName(ServiceController r)
		{
			return r.ServiceName.ToUpperInvariant() == "MSSQLSERVER";
		}
	}
}
