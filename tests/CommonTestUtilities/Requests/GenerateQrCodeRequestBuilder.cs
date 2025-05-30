using Bogus;
using Communication.Requests;

namespace CommonTestUtilities.Requests;

public static class GenerateQrCodeRequestBuilder
{
	public static GenerateQrCodeRequest Build()
	{
		return new Faker<GenerateQrCodeRequest>()
			.RuleFor(r => r.Content, f => f.Lorem.Sentence());
	}
	
	
}