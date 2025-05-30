using Isoide.Domain.Entities;

namespace Isoide.Domain.Repositories;

public interface IQrCodeRepository 
{
	Task<QrCode?> GetByIdAsync(Guid id);
	Task AddAsync(QrCode qrCode);
}