using backend_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using backend_dotnet.Repository;
using backend_dotnet.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(
            builder.Configuration.GetConnectionString("DefaultConnection")
        )
    ));

// Register Repository
builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();

// Register Service
builder.Services.AddScoped<ManufacturerService>();

// OpenAPI / Swagger
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();