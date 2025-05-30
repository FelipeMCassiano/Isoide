namespace Communication.Exceptions;

public class ErrorOnValidationException : IsoideException 
{
	public ErrorOnValidationException(string message) : base(message)
	{
	}
	
}