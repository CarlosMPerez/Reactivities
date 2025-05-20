using Application.Activities.Commands;
using Application.Activities.Models;
using Application.Activities.Queries;
using Application.Activities.Validators;
using Application.Core;
using Application.Core.CQRS;
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
        builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        builder.Services.AddScoped<ICommandHandler<CreateActivity.Command>, CreateActivity.Handler>();
        builder.Services.AddScoped<ICommandHandler<EditActivity.Command>, EditActivity.Handler>();
        builder.Services.AddScoped<ICommandHandler<DeleteActivity.Command>, DeleteActivity.Handler>();

        builder.Services.AddScoped<IQueryHandler<GetActivityDetails.Query, ActivityDto>, GetActivityDetails.Handler>();
        builder.Services.AddScoped<IQueryHandler<GetActivityList.Query, List<ActivityDto>>, GetActivityList.Handler>();
        
        builder.Services.AddValidatorsFromAssemblyContaining<CreateActivityValidator>();

        var app = builder.Build();

        app.UseRouting();

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
