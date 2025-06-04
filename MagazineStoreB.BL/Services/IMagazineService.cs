using MagazineStoreB.BL.Interfaces;
using MagazineStoreB.DL.Interfaces;
using MagazineStoreB.Models.DTO;

namespace MagazineStoreB.BL.Services
{
    internal class MagazineeService : IMagazineService
    {
        private readonly IMagazineRepository _magazineRepository;
        private readonly IAuthorRepository _authorRepository;

        public MagazineeService(IMagazineRepository magazineRepository, IAuthorRepository authorRepository)
        {
            _magazineRepository = magazineRepository;
            _authorRepository = authorRepository;
        }

        public async Task<List<Magazine>> GetMagazines()
        {
            return await _magazineRepository.GetMagazines();
        }

        public async Task AddMagazine(Magazine magazine)
        {
            if (magazineagazine == null || magazine.Authors == null) return;

            foreach (var author in magazine.Authors)
            {
                if (!Guid.TryParse(author, out _)) return;
            }

            await _magazineRepository.AddMagazine(magazine);
        }

        public async Task DeleteMagazine(string id)
        {
            if (!string.IsNullOrEmpty(id)) return;

            await _magazineRepository.DeleteMagazine(id);
        }

        public async Task<Magazine?> GetMagazinesById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var magazineId))
            {
                return null;
            }

            return await _magazineRepository.GetMagazinesById(magazineId.ToString());
        }

        public async Task AddAuthor(string magazineId, Author author)
        {
            if (string.IsNullOrEmpty(magazineId) || author == null) return;

            if (!Guid.TryParse(magazineId, out _)) return;

            var magazine = await _magazineRepository.GetMagazinesById(magazineId);

            if (magazine == null) return;

            if (magazine.Authors == null)
            {
                magazine.Authors = new List<string>();
            }

            if (author.Id == null || string.IsNullOrEmpty(author.Id) || Guid.TryParse(author.Id, out _) == false) return;

            var existingAuthor = await _authorRepository.GetById(author.Id);

            if (existingAuthor != null) return;

            magazine.Author.Add(author.Id);
        }
    }
}
