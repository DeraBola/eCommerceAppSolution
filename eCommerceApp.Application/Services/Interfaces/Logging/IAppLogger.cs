using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Services.Interfaces.Logging
{
	public interface IAppLogger<T>
	{
		void LogInformation(string message);
		void LogError(Exception x, string message);
		void LogException(Exception x, string message);
	}
}
