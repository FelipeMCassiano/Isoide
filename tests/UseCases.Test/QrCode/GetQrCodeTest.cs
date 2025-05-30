using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using Communication.Exceptions;
using Isoide.Application.UseCases;
using Shouldly;

namespace UseCases.Test.QrCode;

public class GetQrCodeTest
{
	[Fact]
	public async Task Success()
	{
		var qrCode = QrCodeBuilder.Build();
		var useCase = CreateUseCase(qrCode);
		
		var id = qrCode.Id;

		var act = async () =>
		{ 
			await useCase.Execute(id);
		};
		await act.ShouldNotThrowAsync();
	}

	[Fact]
	public async Task NotFoundQrCodeError()
	{
		var qrCode = QrCodeBuilder.Build();
		var useCase = CreateUseCase(qrCode);
		var act = async () =>
		{
			await useCase.Execute(Guid.NewGuid());
		};
		await act.ShouldThrowAsync<NotFoundQrCodeException>();
	}

	private static GetQrCodeUseCase CreateUseCase(Isoide.Domain.Entities.QrCode qrCode)
	{
		var repository = new QrCodeRepositoryBuilder().GetByIdAsync(qrCode).Build();
		return new GetQrCodeUseCase(repository);
	}
	
	
}