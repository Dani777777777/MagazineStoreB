using MagazineStoreB.BL.Interfaces;
using MagazineStoreB.DL.Interfaces;
using MagazineStoreB.Models.DTO;
using MagazineStoreB.Models.Responses;

namespace MagazineStoreB.BL.Services
{
    internal class BlMagazineService : IBlMagazineService
    {
        private readonly IMagazineService _magazineService;
        private readonly IAAuthorRepository _authorRepository;

        public BlMagazineService(IMagazineService magazineService, IAuthorRepository authorRepository)
        {
            _magazineService = magazineService;
            _authorrRepository = authorRepository;
        }

        public async Task<List<FullMagazineDetails>> GetAllMagazineDetails()
        {
            var result = new List<FullMagazineDetails>();

            var magazine = await _magazineService.GetMagazine();

            foreach (var magazine in magazine)
            {
                var magazineDetails = new FullMagazineDetails();
                magazineDetails.Title = magazine.Title;
                magazineDetails.Year = magazine.Year;
                magazineDetails.Id = magazine.Id;
                
                var authors = await
                    _authorRepository.GetAuthorss(magazine.Authors);

                magazineDetails.Authors = authors;
                result.Add(magazineDetails);
            }
            return result;
        }
    }
}
