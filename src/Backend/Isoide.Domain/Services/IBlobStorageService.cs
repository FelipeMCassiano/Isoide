namespace Isoide.Domain.Services;

public interface IBlobStorageService
{
	Task UploadFile(MemoryStream memoryStream, Guid id);
	Task<string> GetFileUrl(Guid id);
	
	
}