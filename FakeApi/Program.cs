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
builder.Services.AddSwaggerDocument(configure => configure.Title = "Fake API");
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
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseCors(options =>
options.WithOrigins("http://localhost:4200")
.AllowAnyMethod()
.AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();


