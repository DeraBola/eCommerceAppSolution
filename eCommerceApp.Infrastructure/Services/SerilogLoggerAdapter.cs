using eCommerceApp.Application.Services.Interfaces.Logging;
using Microsoft.Extensions.Logging;

namespace eCommerceApp.Infrastructure.Services
{
	public class SerilogLoggerAdapter<T>(ILogger<T> logger) : IAppLogger<T>
	{
		public void LogException(Exception x, string message) => logger.LogError(x, message);

		public void LogInformation(string message) => logger.LogInformation(message);

		public void LogError(Exception x, string message) => logger.LogError(x, message);
	}
}
