using System.Diagnostics.Metrics;
using eCommerceApp.Application.DependencyInjection;
using eCommerceApp.Infrastructure.DependencyInjection;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
	.Enrich.FromLogContext()
	.WriteTo.Console()
	.WriteTo.File("log/log.txt", rollingInterval: RollingInterval.Day)
	.CreateLogger();

builder.Host.UseSerilog();
Log.Logger.Information("Application is building...");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationService();

builder.Services.AddCors(builder =>
{
	builder.AddDefaultPolicy(options =>
	{
		options.AllowAnyHeader()
		.WithOrigins("https://localhost:7025")
		.AllowAnyMethod()
		.AllowCredentials();
	});
});

try
{
	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseCors("OpenPolicy");

	app.UseInfrastuctureService();

	app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();
	Log.Logger.Information("Application is building...");

	app.Run();
}catch(Exception ex)
{
	Log.Logger.Error(ex, "Application failed to start...");
}
finally
{
	Log.CloseAndFlush();
}

