using Isoide.Domain.Services;
using Moq;

namespace CommonTestUtilities.Services;

public class BlobStorageServiceBuilder
{
	private readonly Mock<IBlobStorageService> _mock;

	public BlobStorageServiceBuilder()
	{
		_mock = new Mock<IBlobStorageService>();
	}

	public IBlobStorageService Build(Guid fileId)
	{
		_mock.Setup(x =>x .GetFileUrl(fileId)).ReturnsAsync(fileId.ToString);
		return _mock.Object;
	}
	
}