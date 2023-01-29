using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("InMemDB");
});
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PrepDB.PrepPopulation(app);

app.Run();
