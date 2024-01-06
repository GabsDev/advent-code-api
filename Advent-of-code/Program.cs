using Advent_of_code;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AdventKeyDb>(opt => opt.UseInMemoryDatabase("AdventKeyList"));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/adventkeys", async (AdventKeyDb db) =>
    await db.AdventKeys.ToListAsync());

app.MapGet("/adventkeys/{id}", async (int id, AdventKeyDb db) =>
    await db.AdventKeys.FindAsync(id)
        is AdventKey adventKey
            ? Results.Ok(adventKey)
            : Results.NotFound());

app.MapPost("/adventkeys", async (AdventKey adventKey, AdventKeyDb db) =>
{
    db.AdventKeys.Add(adventKey);
    await db.SaveChangesAsync();

    return Results.Created($"/adventkeys/{adventKey.Id}", adventKey);
});

app.Run();