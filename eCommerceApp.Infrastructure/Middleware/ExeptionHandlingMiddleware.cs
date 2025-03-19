using eCommerceApp.Application.Services.Interfaces.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Core;

namespace eCommerceApp.Infrastructure.Middleware
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (DbUpdateException ex) when (ex.InnerException is SqlException innerException)
			{
				var logger = context.RequestServices.GetRequiredService<IAppLogger<ExceptionHandlingMiddleware>>();
				context.Response.ContentType = "application/json";
				logger.LogError(innerException, "Sql exception");
				switch (innerException.Number)
				{
					case 2627:  // Unique constraint violation
						context.Response.StatusCode = StatusCodes.Status409Conflict;
						await context.Response.WriteAsync("{\"error\": \"This record already exists. Please try a different value.\"}");
						break;
					case 515:  // Cannot insert null
						context.Response.StatusCode = StatusCodes.Status400BadRequest;
						await context.Response.WriteAsync("{\"error\": \"A required field is missing. Please fill in all necessary information.\"}");
						break;
					case 547:  // Foreign key constraint violation
						context.Response.StatusCode = StatusCodes.Status409Conflict;
						await context.Response.WriteAsync("{\"error\": \"This action cannot be completed because it's linked to other data. Please check your inputs.\"}");
						break;
					default:
						context.Response.StatusCode = StatusCodes.Status500InternalServerError;
						await context.Response.WriteAsync("{\"error\": \"Something went wrong while processing your request. Please try again later.\"}");
						break;
				}
			}
			catch (Exception ex)
			{
				var logger = context.RequestServices.GetRequiredService<IAppLogger<ExceptionHandlingMiddleware>>();

				context.Response.ContentType = "application/json";
				logger.LogError(ex, "Unknown exception");
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await context.Response.WriteAsync("{\"error\": \"An unexpected error occurred. Please try again or contact support.\"}");
			}
		}
	}
}
