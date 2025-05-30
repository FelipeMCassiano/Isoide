using Bogus;
using Isoide.Domain.Entities;

namespace CommonTestUtilities.Entities;

public static class QrCodeBuilder
{
	public static QrCode Build()
	{
		return new Faker<QrCode>()
			.RuleFor(qc => qc.Id, (fake) => Guid.NewGuid())
			.RuleFor(qc => qc.Url, (fake) => fake.Internet.Url());
	}
	
}