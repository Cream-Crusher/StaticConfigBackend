using StaticConfig.Application.Common.Mappings;
using StaticConfig.Application.DI;
using StaticConfig.Persistence.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAutoMapper(profile =>
    {
        profile.AddProfile(new ConfigMappingProfile());
    })
    .AddApplication()
    .AddPersistence(builder.Configuration)
    .AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
    })
    .AddControllers();

builder.Services
    .AddSwaggerGen();

var app = builder.Build();

app
    .UseSwagger()
    .UseSwaggerUI()
    .UseRouting()
    .UseHttpsRedirection()
    .UseCors("AllowAll");

app
    .MapControllers();

app.Run();
