using System.Security.Claims;
using JWT.Algorithms;
using JWT.Extensions.AspNetCore;
using LibraryManagementSystem.Domain.src.RepositoryInterfaces;
using LibraryManagementSystem.Infrastructure.src.Database;
using LibraryManagementSystem.Infrastructure.src.Implementations;
using LibraryManagementSystem.Service.src.Abstractions;
using LibraryManagementSystem.Service.src.Implementations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Get secret key from file.
var configuration = builder.Configuration;
var jwtSecretKey = configuration["JwtSecretKey"];

// Add Database Context.
builder.Services.AddDbContext<DatabaseContext>();

// Add AutoMapper.
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add services to the container.
builder.Services
    .AddScoped<IAuthorService, AuthorService>()
    .AddScoped<IAuthorRepository, AuthorRepository>()
    .AddScoped<IBookService, BookService>()
    .AddScoped<IBookRepository, BookRepository>()
    .AddScoped<IGenreService, GenreService>()
    .AddScoped<IGenreRepository, GenreRepository>()
    .AddScoped<ILoanService, LoanService>()
    .AddScoped<ILoanRepository, LoanRepository>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAuthorization(); 

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Bearer Token Authentication",
        Name = "Authentication",
        In = ParameterLocation.Header
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtAuthenticationDefaults.AuthenticationScheme).AddJwt(
    options =>
    {
        options.Keys = new [] { jwtSecretKey };
        options.VerifySignature = true;
    }
);

// Register JwT srvice.
builder.Services.AddSingleton<IAlgorithmFactory>(new HMACSHAAlgorithmFactory());

// Configure the routes.
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

// Register role based policy.
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
