using System.Reflection;
using PeopleApplication;
using PeopleInfrastructure;
using SubApi;

namespace PeopleApi;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		{
			builder.Services.SetupBuilder(Assembly.GetExecutingAssembly())
				.AddApplication()
				.AddInfrastructure();
		}
		var app = builder.Build();
		{
			app.SetupApp();
			app.Run();
		}
	}
}
