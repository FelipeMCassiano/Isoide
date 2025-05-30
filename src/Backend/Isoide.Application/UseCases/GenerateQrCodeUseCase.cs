using Communication.Exceptions;
using Communication.Requests;
using Communication.Responses;
using Isoide.Domain.Entities;
using Isoide.Domain.Repositories;
using Isoide.Domain.Services;
using QRCoder;

namespace Isoide.Application.UseCases;

public class GenerateQrCodeUseCase : IGenerateQrCodeUseCase
{
	private readonly IQrCodeRepository _repository;
	private readonly IBlobStorageService _blobStorageService;

	public GenerateQrCodeUseCase(IQrCodeRepository repository,  IBlobStorageService blobStorageService)
	{
		_repository = repository;
		_blobStorageService = blobStorageService;
	}

	public async Task<QrCodeResponse> Execute(GenerateQrCodeRequest request)
	{
		if (string.IsNullOrEmpty(request.Content) || string.IsNullOrWhiteSpace(request.Content))
		{
			throw new ErrorOnValidationException("Content is required");
		}

		var stream = GenerateQrCode(request);
		var fileId = Guid.NewGuid();
		await _blobStorageService.UploadFile(stream, fileId);
		var fileUrl = await _blobStorageService.GetFileUrl(fileId);

		var newQrCode = new QrCode()
		{
			Id = fileId,
			Url = fileUrl,
		};
		
		await _repository.AddAsync(newQrCode);

		return new QrCodeResponse()
		{
			Id = fileId,
			Url = fileUrl,
		};
	}

	private MemoryStream GenerateQrCode(GenerateQrCodeRequest request)
	{
		var qrGenerator = new QRCodeGenerator();
		var qrCodeData = qrGenerator.CreateQrCode(request.Content, QRCodeGenerator.ECCLevel.Q);
		var pngByteQrCode = new PngByteQRCode(qrCodeData);
		var qrCodeBytes = pngByteQrCode.GetGraphic(20);
		return new MemoryStream(qrCodeBytes);	
	}
	
}