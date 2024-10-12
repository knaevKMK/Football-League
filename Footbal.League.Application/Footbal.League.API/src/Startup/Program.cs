using static API.ApiConfiguration;
using static Application.ApplicationConfiguration;
using static Infrastructure.InfrastructureConfiguration;
using static Domain.DomainConfiguration;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
                .AddDomain()
                .AddInfrastructure(builder.Configuration)
                .AddApplication(builder.Configuration)
                .AddWebComponents();


var app = builder.Build();

app.UseValidationExceptionHandler();
 
 //todo hide swagger into Release
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Football League V1"));

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
