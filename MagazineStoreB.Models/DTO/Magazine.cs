namespace MagazineStoreB.Models.DTO
{
    public class Magazine
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }
    }
}
