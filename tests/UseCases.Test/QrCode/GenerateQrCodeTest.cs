using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Services;
using Communication.Exceptions;
using Communication.Requests;
using Isoide.Application.UseCases;
using Shouldly;

namespace UseCases.Test.QrCode;

public class GenerateQrCodeTest
{
	[Fact]
	public async Task Success()
	{
		var fileId = Guid.NewGuid();
		var useCase = CreateUseCase(fileId);
		var request = GenerateQrCodeRequestBuilder.Build();
		
		var act = async () => await useCase.Execute(request);

		await act.ShouldNotThrowAsync();
	}

	[Fact]
	public async Task EmptyQrCodeContentError()
	{
		var fileId = Guid.NewGuid();
		var useCase = CreateUseCase(fileId);
		var request = GenerateQrCodeRequestBuilder.Build();
		request.Content = string.Empty;
		var act = async () => await useCase.Execute(request);
		await act.ShouldThrowAsync<ErrorOnValidationException>();
	}

	private static GenerateQrCodeUseCase CreateUseCase(Guid fileId)
	{
		var repository = new QrCodeRepositoryBuilder().Build();
		var blobStorage = new BlobStorageServiceBuilder().Build(fileId);
		
		return new GenerateQrCodeUseCase(repository, blobStorage);
	}
	
}