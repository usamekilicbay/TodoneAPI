using Microsoft.EntityFrameworkCore;
using TodoneAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));
builder.Services.token
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors",
        policy =>
        {
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowAnyOrigin();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCors");
app.UseHttpsRedirection();

app.MapGet("/api/todos", async (AppDbContext appDbContext) => await appDbContext.Todo.ToListAsync());

app.MapGet("/api/todos/{id}", async (AppDbContext appDbContext, string id) => await appDbContext.Todo.FindAsync(id));

app.MapPost("/api/todos", async (AppDbContext appDbContext, Todo todo) =>
{
    await appDbContext.Todo.AddAsync(todo);
    await appDbContext.SaveChangesAsync();
    Results.Accepted();
});

app.MapPut("/api/todos/{id}", async (AppDbContext appDbContext, string id, Todo todo) =>
{
    if (id != todo.Id) Results.BadRequest();

    appDbContext.Update(todo);
    await appDbContext.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/api/todos/{id}", async (AppDbContext appDbContext, string id) =>
{
    var todo = await appDbContext.Todo.FindAsync(id);

    if (todo == null)
        return Results.NotFound();

    appDbContext.Todo.Remove(todo);
    await appDbContext.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
