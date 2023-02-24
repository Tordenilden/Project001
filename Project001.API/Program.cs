using Project001.Repo.Interface;
using Project001.Repo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// 1 line for each Controller - Every model has a line
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Everytime I define a Model / DTO
// Then I need a Repo, Interface, Controller and 1 line in Program.cs
// Your Entity Framework, should follow your models...
// DbSet<ModelName>

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

app.Run();
