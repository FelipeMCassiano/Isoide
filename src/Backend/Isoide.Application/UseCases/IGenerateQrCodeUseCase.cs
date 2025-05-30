using Communication.Requests;
using Communication.Responses;

namespace Isoide.Application.UseCases;

public interface IGenerateQrCodeUseCase
{
	Task<QrCodeResponse> Execute(GenerateQrCodeRequest request);
	
}