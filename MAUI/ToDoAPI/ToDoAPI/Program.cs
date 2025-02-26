using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// string? check = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// to read
app.MapGet("api/todo", async (AppDbContext context) =>
{
    var items = await context.ToDos.ToListAsync();
    return Results.Ok(items);
});

//to create
app.MapPost("api/todo", async (AppDbContext context, ToDo toDo) =>
{
    await context.ToDos.AddAsync(toDo);
    await context.SaveChangesAsync();
    return Results.Created($"api/todo/{toDo.Id}", toDo);
});

//to update
app.MapPut("api/todo/{id}", async (AppDbContext context, int id, ToDo toDo) =>
{
    var toDoModel = await context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

    if(toDoModel == null)
    {
        return Results.NotFound();
    }

    toDoModel.ToDoName = toDo.ToDoName;

    await context.SaveChangesAsync();

    return Results.NoContent();
});

//to delete
app.MapDelete("api/todo/{id}", async (AppDbContext context, int id) =>
{
    var toDoModel = await context.ToDos.FirstOrDefaultAsync(t => t.Id == id);

    if (toDoModel == null)
    {
        return Results.NotFound();
    }

    context.ToDos.Remove(toDoModel);

    await context.SaveChangesAsync();

    return Results.NoContent();
});


app.Run();


  