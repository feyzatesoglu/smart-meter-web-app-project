using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SmartWebAppAPI.Repositories;
using SmartWebAppAPI.Services;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;
using SmartWebAppAPI.Validators.AuthValidators;

var builder = WebApplication.CreateBuilder(args);
var jwtConfig = builder.Configuration.GetSection("JwtConfig");
// Add services to the container.
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowSpecificOrigin",
      builder => builder.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader());
});

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterValidation>());

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["Issuer"], // Yayımcı (Issuer) bilgisini buraya ekleyin
        ValidAudience = jwtConfig["Audience"], // İzleyici (Audience) bilgisini buraya ekleyin
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["SecretKey"])) // Gizli anahtarınızı buraya ekleyin
      };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Scoped services
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthTypeRepository, AuthTypeRepository>();
builder.Services.AddScoped<IQueryCountRepository, QueryCountRepository>();
builder.Services.AddScoped<IAuthRoleRepository, AuthRoleRepository>();
builder.Services.AddScoped<IUserResultRepository, UserResultsRepository>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRecommendationService, RecommendationManager>();
builder.Services.AddScoped<IAuthService, AuthManager>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
});

app.Run();
