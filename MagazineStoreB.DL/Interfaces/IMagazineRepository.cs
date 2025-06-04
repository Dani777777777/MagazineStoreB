
using MagazineStoreB.Models.DTO;

namespace MagazineStoreB.DL.Interfaces
{
    public interface IMagazineRepository
    {
        Task<List<Magazine>> GetMagazines();

        Task AddMagazine(Magazine magazine);

        Task DeleteMagazine(string id);

        Task<Magazine?> GetMagazinesById(string id);
    }
}
