using MagazineStoreB.Models.DTO;

namespace MagazineStoreB.BL.Interfaces
{
    public interface IMagazineService
    {
        Task<List<Magazine>> GetMagazines();

        Task AddMagazine(Magazine magazine);

        Task DeleteMagazine(string id);

        Task<Magazine?> GetMagazineById(string id);

        Task AddAuthor(string magazineId, Author author);
    }
}
