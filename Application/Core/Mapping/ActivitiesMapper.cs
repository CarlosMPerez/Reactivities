using Domain.Entities;
using Application.Activities.Models;

namespace Application.Core;

public static class ActivityMappingExtensions
{
    public static ActivityDto ToDto(this Activity entity)
    {
        return new ActivityDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Date = entity.Date,
            Category = entity.Category,
            City = entity.City,
            Venue = entity.Venue,
            IsCancelled = entity.IsCancelled,
            Latitude = entity.Latitude,
            Longitude = entity.Longitude
        };
    }

    public static Activity ToEntity(this CreateActivityDto dto)
    {
        return new Activity
        {
            Title = dto.Title,
            Description = dto.Description,
            Date = dto.Date,
            Category = dto.Category,
            City = dto.City,
            Venue = dto.Venue,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude
        };
    }

    public static Activity ToEntity(this ActivityDto dto)
    {
        return new Activity
        {
            Id = dto.Id,
            Title = dto.Title,
            Description = dto.Description,
            Date = dto.Date,
            Category = dto.Category,
            City = dto.City,
            Venue = dto.Venue,
            IsCancelled = dto.IsCancelled,
            Latitude = dto.Latitude,
            Longitude = dto.Longitude
        };
    }
}
