using Moq;
using MagazineStoreB.BL.Interfaces;
using MagazineStoreB.BL.Services;
using MagazineStoreB.DL.Interfaces;
using MagazineStoreB.Models.DTO;

namespace MagazineStoreB.Tests
{
    public class BlMagazineServiceUnitTest
    {
        private readonly Mock<IMagazineService> _magazineServiceMock;
        private readonly Mock<IAuthorRepository> _authorRepositoryMock;

        private List<Magazine> _magazine = new List<Magazine>()
        {
            new Magazine()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Magazine 1",
                Year = 2021,
                Authors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "baac2b19-bbd2-468d-bd3b-5bd18aba98d7"]
            },
            new Magazine()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Magazine 2",
                Year = 2022,
                Authors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        private List<Authors> _authorss = new List<Author>
        {
            new Author()
            {
                Id = "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                Name = "Author 1"
            },
            new Author()
            {
                Id = "baac2b19-bbd2-468d-bd3b-5bd18aba98d7",
                Name = "Author 2"
            },
            new Author()
            {
                Id = "5c93ba13-e803-49c1-b465-d471607e97b3",
                Name = "Author 3"
            },
        };

        public BlMagazineServiceUnitTest()
        {
            _magazineServiceMock = new Mock<IMagazineService>();
            _authorrRepositoryMock = new Mock<IAuthorRepository>();
        }

        [Fact]
        public async Task GetAllMagazineDetails_ReturnsData()
        {
            //setup
            var expectedCount = 2;

            _magazineServiceMock
                .Setup(x => x.GetMagazine())
                .ReturnsAsync(_magazine);

            _authorRepositoryMock
                .Setup(repo =>
                    repo.GetById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _authors.FirstOrDefault(x => x.Id == id));

            //inject
            var blMagazineService = new BlMagazineService(
                _magazineServiceMock.Object,
                _authorRepositoryMock.Object);

            //act
            var result =
                await blMagazineService.GetAllMagazineDetails();

            //assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result.Count);
        }
    }
}