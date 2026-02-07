using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Domain.RepositoryInterface;
using WorkoutTracker.Infrastructure.Data;
using WorkoutTracker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IWorkoutSessionRepository, WorkoutSessionRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkRepository>();

builder.Services.AddControllers();

var conncetionString = builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseMySql(conncetionString, ServerVersion.AutoDetect(conncetionString));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
