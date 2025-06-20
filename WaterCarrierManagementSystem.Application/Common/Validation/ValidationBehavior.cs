﻿using FluentValidation;
using MediatR;

namespace WaterCarrierManagementSystem.Application.Common.Validation;

public class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => 
        _validators = validators;

    public async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next(cancellationToken);
        
        var context = new ValidationContext<TRequest>(request);
        
        var errorsDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .GroupBy(
                x => x.PropertyName,
                x => x.ErrorMessage,
                (propertyName, errorMessages) => new
                {
                    Key = propertyName,
                    Values = errorMessages.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);
        
        if (errorsDictionary.Count != 0)
        {
            throw new ValidationException(
                (IEnumerable<FluentValidation.Results.ValidationFailure>)errorsDictionary);
        }
        return await next(cancellationToken);
    }
}
