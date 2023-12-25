using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartWebAppAPI.Entity.Models;

using SmartWebAppAPI.Repositories;
using SmartWebAppAPI.Services;
using SmartWebAppAPI.Validators.AuthValidators;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
builder.Services.AddControllers()
  .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterValidation>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthTypeRepository, AuthTypeRepository>();
builder.Services.AddScoped<IAuthRoleRepository, AuthRoleRepository>();

builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRecommendationService, RecommendationManager>();
builder.Services.AddScoped<IAuthService,AuthManager>();


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
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();




app.Run();
