using MagazineStoreB.Models.Responses;

namespace MagazineStoreB.BL.Interfaces
{
    public interface IBlMagazineService
    {
        Task<List<FullMagazineDetails>> GetAllMagazineDetails();
    }
}
