using Isoide.Domain.Entities;
using Isoide.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public class QrCodeRepositoryBuilder
{
	private readonly Mock<IQrCodeRepository> _mock;
	public QrCodeRepositoryBuilder()
	{
		_mock = new Mock<IQrCodeRepository>();
	}

	public QrCodeRepositoryBuilder GetByIdAsync(QrCode qrCode)
	{
		_mock.Setup(x => x.GetByIdAsync(qrCode.Id)).ReturnsAsync(qrCode);
		return this;
	}

	public IQrCodeRepository Build()
	{
		return _mock.Object;
	}

}