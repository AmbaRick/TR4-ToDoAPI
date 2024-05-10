using ToDo.Infrastructure.Data; 
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Interfaces;
using ToDo.Core.ToDoItems;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//TODO: move DB spefici to own DI class in Infrastructure project
builder.Services.Configure<ToDoRepositorySettings>(builder.Configuration.GetSection("CustomerDatabase"));

//TODO: check if needs singleton instance of DI?

//TODO: try and separrate the mothods for CRUD
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
