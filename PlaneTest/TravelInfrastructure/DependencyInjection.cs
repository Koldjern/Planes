using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SubInfrastructure;
using SubInfrastructure.Api.Access;
using TravelApplication.Options;
using TravelApplication.Travels;
using TravelInfrastructure.Api;
using TravelInfrastructure.TravelRepo;

namespace TravelInfrastructure;

public static class DependencyInjection
{
	public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
	{
		builder.Services.SubInfrastructure();

		builder.Services.AddHttpClient("PlaneClient", client =>
		{
			var apiOptions = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<ApiOptions>>().Value;
			client.BaseAddress = new Uri(apiOptions.PlaneUrl);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		});

		builder.Services.AddHttpClient("PeopleClient", client =>
		{
			var apiOptions = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<ApiOptions>>().Value;
			client.BaseAddress = new Uri(apiOptions.PeopleUrl);
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		});

		builder.Services.AddScoped<IApiAccess<ApiAccessPlanes>, ApiAccessPlanes>();
		builder.Services.AddScoped<IApiAccess<ApiAccessPeople>, ApiAccessPeople>();

		builder.Services.AddScoped<ITravelRepository, MemoryTravelRepository>();
		builder.Services.AddScoped<IPlanesApi, PlanesApi>();
		builder.Services.AddScoped<IPeopleApi, PeopleApi>();
		return builder;
	}
}