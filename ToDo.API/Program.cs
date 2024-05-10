using ToDo.Infrastructure.Data; 
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Interfaces;
using ToDo.Core.ToDoItems;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//TODO: move DB specific to own DI class in Infrastructure project - keeping it clean
builder.Services.Configure<ToDoRepositorySettings>(builder.Configuration.GetSection("CustomerDatabase"));

//TODO: check if needs singleton instance of DI for MongoDB?

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoItemService>();

//TODO:add logging and exception handling

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

app.Run();
