using Amazon;
using Amazon.DynamoDBv2;
using MeufarmaceuticoApi.Contracts.Responses;
using MeufarmaceuticoApi.Repositories;
using FastEndpoints;
using FastEndpoints.Swagger;
using MeufarmaceuticoApi.Domain.Common;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Serveces.AddScoped<IDapperRepository, DapperRepository>();
builder.Services.AddScoped<DataContext>();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ServerConnection")));

var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();
app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(y => y.ErrorMessage).ToList()
        };
    };
});

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();
