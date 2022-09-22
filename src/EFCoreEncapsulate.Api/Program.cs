using EFCoreEncapsulate.Infrastructure;
using EFCoreEncapsulate.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddInfrastructure(builder.Configuration["ConnectionString"], true);

builder.Services.AddTransient<StudentRepository>();
builder.Services.AddTransient<CourseRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapControllers();

app.Run();

