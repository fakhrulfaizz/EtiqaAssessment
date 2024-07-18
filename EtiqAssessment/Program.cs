
using EtiqAssessment.Application.Interfaces;
using EtiqAssessment.Application.Services;
using EtiqAssessment.Domain.Interfaces;
using EtiqAssessment.Infrastructure.Data;
using EtiqAssessment.Infrastructure.Repositories;
using EtiqAssessment.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EtiqAssessmentDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFreelancerService, FreelancerService>();
builder.Services.AddScoped<IFreelancerRepository, FreelancerRepository>();

builder.Services.AddControllers();
//Enable CORS
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowSpecificOrigin", options => options.WithOrigins("http://localhost:44401").AllowAnyMethod().AllowAnyHeader());
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Etiqa Assessment API",
        Description = "An ASP.NET Core Web API for managing Etiqa Assessment items",
      
    });
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

// Serve static files (Angular)
app.UseStaticFiles();

// Use Swagger for API documentation
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EtiqAssessment v1");
    c.RoutePrefix = "swagger";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

