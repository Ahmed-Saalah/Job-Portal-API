using FluentValidation;
using JobPortal.Application.DTOs;

namespace JobPortal.Application.Validation
{
    public interface IValidationService
    {
        Task<ServiceResponse> ValidateAsync<T>(T model, IValidator<T> validator);
    }
}
