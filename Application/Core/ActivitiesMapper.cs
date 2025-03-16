using Domain.Entities;
using Riok.Mapperly.Abstractions;
using Application.Activities.Models;

namespace Application.Core;

[Mapper]
public static partial class ActivitiesMapper
{
    public static partial Activity Map(ActivityDto activity);

    public static partial ActivityDto Map(Activity activity);

    [MapperIgnoreTarget(nameof(Activity.Id))]
    [MapperIgnoreTarget(nameof(Activity.IsCancelled))]
    public static partial Activity Map(CreateActivityDto activity);
}
