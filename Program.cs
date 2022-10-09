using MeufarmaceuticoApi.Repositories;
using FastEndpoints.Swagger;
using MeufarmaceuticoApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

builder.Services.AddControllers();

builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDapperRepository, DapperRepository>();
builder.Services.AddScoped<DataContext>();
builder.Services.AddSwaggerDoc();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(config.GetConnectionString("ServerConnection")));

var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.Run();
