using EtiqAssessment.Application;
using EtiqAssessment.Application.Interfaces;
using EtiqAssessment.Application.Services;
using EtiqAssessment.Domain.Interfaces;
using EtiqAssessment.Infrastructure.Data;
using EtiqAssessment.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EtiqAssessmentDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFreelancerService, FreelancerService>();
builder.Services.AddScoped<IFreelancerRepository, FreelancerRepository>();


builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EtiqAssessment.Api", Version = "v1" });
});

builder.Services.AddLogging();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action=Index}/{id?}");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EtiqAssessment.Api v1");
    c.RoutePrefix = string.Empty;
});

//app.MapFallbackToFile("index.html");

app.Run();
