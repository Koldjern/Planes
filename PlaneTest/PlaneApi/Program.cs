using System.Reflection;
using Mapster;
using MapsterMapper;
using PlaneApplication;
using PlaneInfrastructureM;
using SubApi;

namespace PlaneApi;

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
