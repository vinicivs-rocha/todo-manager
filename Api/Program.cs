using Application.Repositories;
using Application.UseCases.CreateToDo;
using Application.UseCases.DeleteToDo;
using Application.UseCases.GetAllToDos;
using Application.UseCases.GetToDoById;
using Application.UseCases.UpdateToDo;
using Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Inject Use Cases
builder.Services.AddScoped<CreateToDo>();
builder.Services.AddScoped<GetToDoById>();
builder.Services.AddScoped<GetAllToDos>();
builder.Services.AddScoped<UpdateToDo>();
builder.Services.AddScoped<DeleteToDo>();

// Inject Repositories
builder.Services.AddSingleton<IToDoRepository>(new InMemoryToDoRepository());

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