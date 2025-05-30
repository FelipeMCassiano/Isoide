using Communication.Requests;
using Communication.Responses;
using Isoide.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Isoide.API.Controllers;

[ApiController]
[Route("[controller]")]
public class QrCodeController: ControllerBase
{
	[HttpPost]
	[ProducesResponseType(typeof(QrCodeResponse),StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ResponseError),StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> GenerateQrCode([FromBody] GenerateQrCodeRequest request, [FromServices] IGenerateQrCodeUseCase useCase)
	{
		var response = await useCase.Execute(request);
		return Ok(response);
	}

	[HttpGet]
	[Route("{id:guid}")]
	[ProducesResponseType(typeof(QrCodeResponse), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(ResponseError),StatusCodes.Status404NotFound)]
	public async Task<IActionResult> GenerateQrCode([FromServices] IGetQrCodeUseCase useCase , [FromRoute] Guid id)
	{
		var response = await useCase.Execute(id);
		return Ok(response);
	}
	
}