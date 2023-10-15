using EasyDDD.Api.Configuration;
using EasyDDD.Infrastructure.Data.DbContexts.BoundedContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddMediatR(AppDomain.CurrentDomain.Load($"{nameof(EasyDDD)}.{nameof(Application)}"));

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer("Server=(local)\\SqlExpress;Database=EasyDDD;Trusted_Connection=True;TrustServerCertificate=True");
});

builder.Services.AddDependencyInjectionDefault();

var app = builder.Build();

//app.Services.

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<MyDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
