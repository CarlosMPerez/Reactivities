using Application.Activities.Queries;
using Application.Activities.Validators;
using Application.Core;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddCors();
        builder.Services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>();
            opt.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });
        builder.Services.AddValidatorsFromAssemblyContaining<CreateActivityValidator>();

        var app = builder.Build();

        app.UseCors(opt => opt
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:3000", "https://localhost:3000"));

        app.UseHttpsRedirection();

        app.MapControllers();

        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();
            await DbInitializer.SeedData(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error ocurred during migration");
        }

        app.Run();
    }
}
