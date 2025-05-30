using Communication.Responses;
using Isoide.Domain.Entities;

namespace Isoide.Application.UseCases;

public interface IGetQrCodeUseCase
{
	Task<QrCodeResponse> Execute(Guid id);
}