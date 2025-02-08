using JobPortal.Application.Mapping;
using JobPortal.Application.Services.Implementations.Authentication;
using JobPortal.Application.Services.Interfaces.Authentication;
using JobPortal.Application.Validation.Authentication;
using JobPortal.Application.Validation;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using FluentValidation;
using JobPortal.Application.Services.Interfaces;
using JobPortal.Application.Services.Implementations;

namespace JobPortal.Application.DependancyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingConfig));
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IJobServices, JobServices>();
            services.AddScoped<IJobApplicationService, JobApplicationService>();
            return services;
        }
    }
}
