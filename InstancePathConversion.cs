using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nicologies.SqlServerUtils.Metadata
{
	static class InstancePathConversion
	{
		public static string GetInstsPath(string machineName, string instName)
		{
			if (string.Compare(instName, "MSSQLSERVER", StringComparison.InvariantCultureIgnoreCase) == 0)
			{
				instName = ".";
			}
			var path = machineName.Replace("LOCALHOST", ".") + "\\" + instName;
			return path.Replace(".\\.", ".");
		}
	}
}
