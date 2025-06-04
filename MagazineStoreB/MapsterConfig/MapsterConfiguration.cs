using Mapster;
using MagazineStoreB.Models.DTO;
using MagazineStoreB.Models.Requests;

namespace MagazineStoreB.MapsterConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddMovieRequest, Movie>
                .NewConfig();
        }
    }
}
