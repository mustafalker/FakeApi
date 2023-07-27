using FakeApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq;

//public class Startup
//{
//    public IConfiguration Configuration;

//    public Startup(IConfiguration configuration)
//    {
//        Configuration = configuration;
//    }
//}




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

builder.Services.AddDbContext<Repository>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("sqlConnection")));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
