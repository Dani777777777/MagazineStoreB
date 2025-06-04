using MagazineStoreB.Models.DTO;

namespace MagazineStoreB.Models.Responses
{
    public class FullMagazineDetails
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<Author> Authors { get; set; }
    }
}
