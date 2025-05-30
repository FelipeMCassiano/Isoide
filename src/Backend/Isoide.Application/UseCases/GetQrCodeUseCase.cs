using Communication.Exceptions;
using Communication.Responses;
using Isoide.Domain.Entities;
using Isoide.Domain.Repositories;
using Isoide.Domain.Services;

namespace Isoide.Application.UseCases;

public class GetQrCodeUseCase:IGetQrCodeUseCase 
{
	private readonly IQrCodeRepository _repository;

	public GetQrCodeUseCase(IQrCodeRepository repository )
	{
		_repository = repository;
	}

	public async Task<QrCodeResponse> Execute(Guid id)
	{
		var qrCode = await _repository.GetByIdAsync(id);
		if (qrCode == null)
		{
			throw new NotFoundQrCodeException();
		}
		
		return new QrCodeResponse()
		{
			Id = qrCode.Id,
			Url =qrCode.Url 
		};
	}
}