using PartAssessment.Api;
using PartAssessment.Application;
using PartAssessment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    //TODO: add dependencies
    builder.Services.AddApiDependecies();
    builder.Services.AddApplicationDependencies();

    var secret = builder.Configuration.GetValue<string>("Jwt:Key") ?? "";
    var issuer = builder.Configuration.GetValue<string>("Jwt:Issuer") ?? "";
    var audience = builder.Configuration.GetValue<string>("Jwt:Audience") ?? "";
    builder.Services.AddInfrastructureDependencies(builder.Configuration, secret, issuer, audience);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
