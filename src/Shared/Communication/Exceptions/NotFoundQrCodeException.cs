namespace Communication.Exceptions;

public class NotFoundQrCodeException : IsoideException
{
	public NotFoundQrCodeException() : base("QrCode not found")
	{
		
	}
	
}