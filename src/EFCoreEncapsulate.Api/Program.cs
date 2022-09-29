using EFCoreEncapsulate.Domain;
using EFCoreEncapsulate.Infrastructure;
using EFCoreEncapsulate.Infrastructure.Repositories;
using EFCoreEncapsulate.SharedKernel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddInfrastructure(builder.Configuration["ConnectionString"], true);

builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<CourseRepository>();
builder.Services.AddSingleton<Messages>();

// TODO: auto registration
builder.Services.AddTransient<ICommandHandler<EditStudentPersonalInfoCommand>, EditStudentPersonalInfoCommandHandler>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapControllers();

app.Run();

