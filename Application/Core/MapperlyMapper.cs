using Domain.Entities;
using Riok.Mapperly.Abstractions;
using Application.Activities.Models;

namespace Application.Core;

[Mapper]
public static partial class ReactivitiesMapper
{
    public static partial Activity Map(ActivityDto activity);

    public static partial ActivityDto Map(Activity activity);
}
