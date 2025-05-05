using System.Reflection;
using SubApi;
using TravelApplication;
using TravelInfrastructure;

namespace TravelApi;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		{
			builder.Services.SetupBuilder(Assembly.GetExecutingAssembly());
			builder.AddApplication()
				.AddInfrastructure();
		}
		var app = builder.Build();
		{
			app.SetupApp();
			app.Run();
		}
	}
}
