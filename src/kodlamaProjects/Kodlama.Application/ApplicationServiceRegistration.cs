using FluentValidation;
using MediatR;
using Core.Application.Pipelines.Validation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kodlama.Application.Features.Lessons.Rules;
using Kodlama.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.Application.Features.AppAuthorizations.Rules;
using Core.Application.Pipelines.Authorization;
using Kodlama.Application.Features.GitHubProfiles.Rules;
using Kodlama.Application.Services.AuthService;
using Kodlama.Application.Features.Auths.Rules;
using Kodlama.Application.Features.OperationClaims.Rules;
using Kodlama.Application.Features.UserOperationClaims.Rules;

namespace Kodlama.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<LessonBusinessRules>();
            services.AddScoped<ProgrammingTechnologyBusinessRules>();
            services.AddScoped<AppAuthorizationBusinessRules>();
            services.AddScoped<GitHubProfileBussinesRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<OperationClaimBusinessRules>();
            services.AddScoped<UserOperationClaimBusinessRules>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScoped<IAuthService, AuthManager>();
            return services;

        }
    }
}
