using EventsAPI.Data;
using EventsAPI.Services.Contracts;
using EventsAPI.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEventsService, EventsService>();

string eventsDbConnectionString = builder.Configuration.GetConnectionString("EventsDbContext");
builder.Services.AddDbContext<EventsDbContext>(options =>
{
    options.UseNpgsql(eventsDbConnectionString);
    options.UseSnakeCaseNamingConvention();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// TODO: revisit cors before deployment
app.UseCors(options => options.AllowAnyOrigin());
app.UseHttpsRedirection(); // TODO: do I need this?

app.UseAuthorization();

app.MapControllers();

app.Run();
