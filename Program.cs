using ApiDockerStudy.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(configuration.GetConnectionString("DefaultConnection")!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(s => s.EnableTryItOutByDefault());
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
