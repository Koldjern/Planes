using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SubApplication;
using TravelApplication.Options;

namespace TravelApplication;

public static class DependencyInjection
{
	public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
	{
		builder.Services.AddSubApplication(Assembly.GetExecutingAssembly());

		builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection(ApiOptions.ApiOptionsKey));

		return builder;
	}
}
