using Communication.Exceptions;
using Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Isoide.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
	public void OnException(ExceptionContext context)
	{
		if (context.Exception is IsoideException ex)
		{
			HandleProjectException(context, ex);
			return;
		}

		context.ExceptionHandled = true;
		context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
		context.Result = new ObjectResult(new ResponseError()
		{
			Error = context.Exception.Message,
		});
	}

	private void HandleProjectException(ExceptionContext context, IsoideException ex)
	{
		switch (ex)
		{
			case ErrorOnValidationException errorOnValidationException:
				context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				context.ExceptionHandled = true;
				context.Result = new BadRequestObjectResult(new ResponseError()
				{
					Error = errorOnValidationException.Message,
				});
				break;
			case NotFoundQrCodeException notFoundQrCodeException:
				context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				context.ExceptionHandled = true;
				context.Result = new NotFoundObjectResult(new ResponseError()
				{
					Error = notFoundQrCodeException.Message,
				});
				break;
		}
	}
}