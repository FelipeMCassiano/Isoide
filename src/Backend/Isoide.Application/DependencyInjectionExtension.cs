using Isoide.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Isoide.Application;

public static class DependencyInjectionExtension
{
	public static void AddApplication(this IServiceCollection services)
	{
		AddUseCases(services);
	}

	private static void AddUseCases(IServiceCollection services)
	{
		services.AddScoped<IGenerateQrCodeUseCase, GenerateQrCodeUseCase>();
		services.AddScoped<IGetQrCodeUseCase, GetQrCodeUseCase>();

	}
	
}