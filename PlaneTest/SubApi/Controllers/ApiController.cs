using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SubApi.Common.Keys;

namespace SubApi.Controllers;

[ApiController]
public class ApiController : ControllerBase
{
	protected IActionResult Problem(List<Error> errors)
	{
		if (errors.Count == 0)
			return Problem();
		if (errors.All(x => x.Type == ErrorType.Validation))
			return ValidationProblem(errors);
		HttpContext.Items[HttpContextItemKeys.Errors] = errors;
		Error first = errors[0];
		return Problem(first);
	}

	private IActionResult ValidationProblem(List<Error> errors)
	{
		var modelStateDictionary = new ModelStateDictionary();
		errors.ForEach(x => modelStateDictionary.AddModelError(x.Code, x.Description));
		return ValidationProblem(modelStateDictionary);
	}

	private IActionResult Problem(Error firstError)
	{
		int statusCode = firstError.Type switch
		{
			ErrorType.Conflict => StatusCodes.Status409Conflict,
			ErrorType.Validation => StatusCodes.Status400BadRequest,
			ErrorType.NotFound => StatusCodes.Status404NotFound,
			_ => StatusCodes.Status500InternalServerError
		};
		return Problem(statusCode: statusCode, title: firstError.Description);
	}
}
