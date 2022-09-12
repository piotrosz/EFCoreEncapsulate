using EFCoreEncapsulate.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddScoped(_ => new SchoolContext(builder.Configuration["ConnectionString"], true));

builder.Services.AddTransient<StudentRepository>();
builder.Services.AddTransient<CourseRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapControllers();

app.Run();

