using FakeApi.Data;
using FakeApi.GenericRepositoryPattern.CommentByIdRemove.DAL;
using FakeApi.GenericRepositoryPattern.CommentPut.DAL;
using FakeApi.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IRemove<Comment>, RemoveComment<Comment>>();
builder.Services.AddScoped<IUpdate<Comment>, UpdateComment<Comment>>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();
try
{
    builder.Services.AddDbContext<FakeApi.Data.FakeApiDbContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("sqlConnection")));
}
catch (Exception ex)
{
    Console.WriteLine("Db Patladý" + ex);
}

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
app.Run();


