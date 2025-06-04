namespace MagazineStoreB.Models.Requests
{
    public class AddMagazineRequest
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> ActorIds { get; set; }
    }
}
