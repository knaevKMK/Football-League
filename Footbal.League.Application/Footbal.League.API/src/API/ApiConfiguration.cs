namespace API
{
    using Application.Common;
    using Application.Common.Contracts;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using API.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Application.BoundedContexts.FootballMatches.Commands;

    public static class ApiConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                }); 
            });
 
            services
                .AddScoped<ICurrentUser, CurrentUserService>()?
                 .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssemblyContaining<Result>()
                .AddValidatorsFromAssemblyContaining<CreateFootballMatchCommandValidator>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
