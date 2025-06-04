using Moq;
using MagazineStoreB.BL.Interfaces;
using MagazineStoreB.BL.Services;
using MagazineStoreB.DL.Interfaces;
using MagazineStoreB.Models.DTO;

namespace MagazineStoreB.Tests
{
    public class MagazineServiceTests
    {
        private readonly Mock<IMagazineRepository> _magazineRepositoryMock;
        private readonly Mock<IAuthorRepository> _AuthorRepositoryMock;

        private List<Magazine> _magazine = new List<Magazine>()
        {
            new Magazine()
            {
                Id = "c3bd1985-792e-4208-af81-4d154bff15c8",
                Title = "Magazine 1",
                Year = 2021,
                Authors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "baac2b19-bbd2-468d-bd3b-5bd18aba98d7"]
            },
            new Magazine()
            {
                Id = "4c304bec-f213-47b5-8ae0-9df4a4eb3b99",
                Title = Magazine 2",
                Year = 2022,
                Authors = [
                    "157af604-7a4b-4538-b6a9-fed41a41cf3a",
                    "5c93ba13-e803-49c1-b465-d471607e97b3"
                ]
            }
        };

        private List<Author> _authors = new List<Author>
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

        public MagazineServiceTests()
        {
            _authorRepositoryMock = new Mock<IAuthorRepository>();
            _magazineRepositoryMock = new Mock<IMagazineRepository>();
        }

        [Fact]
        async Task GetMagazinesById_ReturnsData()
        {
            // Arrange
            var magazineId = _magazines[0].Id;

            _magazineRepositoryMock.Setup(x => x.GetMagazinesById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _magazines.FirstOrDefault(x => x.Id == id));

            var magazineService = new MagazineService(_magazineRepositoryMock.Object, _AuthorRepositoryMock.Object);

            // Act
            var result = await magazineService.GetMagazinesById(magazineId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(magazineId, result.Id);
        }

        [Fact]
        void GetMagazinesById_MagazineNotExist()
        {
            // Arrange
            var magazineId = "c3bd1985-792e-4208-af81-4d154bff15c9";

            _magazineRepositoryMock.Setup(x => x.GetMagazinesById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _magazines.FirstOrDefault(x => x.Id == id));

            var magazineService = new MagazineService(_magazineRepositoryMock.Object, _AuthorRepositoryMock.Object);

            // Act
            var result = magazineService.GetMagazinesById(magazineId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        void GetMagazinesById_MagazineWithInvalidGuid()
        {
            // Arrange
            var magazineId = "c3bd1985-792e-4208-af81-4d154bff15c9-12";

            _magazineRepositoryMock.Setup(x => x.GetMagazinesById(It.IsAny<string>()))
                    .Returns((string id) =>
                        _magazines.First(x => x.Id == id));

            var magazineService = new MagazineService(_magazineRepositoryMock.Object, _AuthorRepositoryMock.Object);

            // Act
            var result = magazineService.GetMagazinesById(magazineId);

            // Assert
            Assert.Null(result);
        }
    }
}
