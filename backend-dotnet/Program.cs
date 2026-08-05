using backend_dotnet.Data;
using backend_dotnet.Helpers;
using backend_dotnet.Services;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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



// ===============================
// JWT Dependency Injection
// ===============================

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddScoped<PasswordHasher>();



// ===============================
// JWT Authentication
// ===============================

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme
)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters =
    new TokenValidationParameters
    {

        ValidateIssuer = true,

        ValidateAudience = true,

        ValidateLifetime = true,

        ValidateIssuerSigningKey = true,


        ValidIssuer =
        builder.Configuration["Jwt:Issuer"],


        ValidAudience =
        builder.Configuration["Jwt:Audience"],


        IssuerSigningKey =
        new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"]!
            ))

    };
});



// ===============================
// Authorization
// ===============================

builder.Services.AddAuthorization();



// OpenAPI / Swagger

builder.Services.AddOpenApi();



var app = builder.Build();



// Configure HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();


// JWT Middleware

app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();


app.Run();