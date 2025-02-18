using Riok.Mapperly.Abstractions;
using Application;

namespace Domain;

[Mapper]
public static partial class MapperlyMapper
{
    public static partial Activity Map(ActivityDto activity);

    public static partial ActivityDto Map(Activity activity);
}
