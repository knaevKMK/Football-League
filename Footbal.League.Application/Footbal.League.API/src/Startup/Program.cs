using static API.ApiConfiguration;
using static Application.ApplicationConfiguration;
using static Infrastructure.InfrastructureConfiguration;
using static Domain.DomainConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Services
                .AddDomain()
                .AddInfrastructure(builder.Configuration)
                .AddApplication(builder.Configuration)
                .AddWebComponents();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
