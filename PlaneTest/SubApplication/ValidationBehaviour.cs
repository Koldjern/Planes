using ErrorOr;
using FluentValidation;
using MediatR;

namespace SubApplication;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
	where TResponse : IErrorOr
{
	private readonly IValidator<TRequest>? _validator;
	public ValidationBehavior(IValidator<TRequest>? validator = null)
	{
		_validator = validator;
	}
	public async Task<TResponse> Handle(
		TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		if (_validator is null)
			return await next();

		var validationresult = await _validator.ValidateAsync(request);
		if (validationresult.IsValid)
			return await next();

		var errors = validationresult.Errors
			.ConvertAll(fail => Error.Validation(fail.PropertyName, fail.ErrorMessage));
		return (dynamic)errors;
	}
}
