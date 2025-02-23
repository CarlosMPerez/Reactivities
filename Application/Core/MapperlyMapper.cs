using Riok.Mapperly.Abstractions;
using Application.Activities.Models;

namespace Domain;

[Mapper]
public static partial class ReactivitiesMapper
{
    public static partial Activity Map(ActivityDto activity);

    public static partial ActivityDto Map(Activity activity);
}
