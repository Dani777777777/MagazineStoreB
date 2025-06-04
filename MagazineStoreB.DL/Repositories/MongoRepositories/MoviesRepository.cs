using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MagazineStoreB.DL.Interfaces;
using MagazineStoreB.Models.Configurations;
using MagazineStoreB.Models.DTO;

namespace MagazineStoreB.DL.Repositories.MongoRepositories
{
    internal class MagazineRepository : IMagazineRepository
    {
        private readonly IMongoCollection<Movie> _magazinesCollection;
        private readonly ILogger<MagazineRepository> _logger;

        public MagazineRepository(ILogger<MagazineRepository> logger, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _logger = logger;

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb configuration is missing");

                throw new ArgumentNullException("MongoDb configuration is missing");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _magazinesCollection = database.GetCollection<Magazine>($"{nameof(Magazine)}s");
        }

        public async Task AddMagazine(Magazine magazine)
        {
            try
            {
                magazine.Id = Guid.NewGuid().ToString();

                await _magazineCollection.InsertOneAsync(m,agazine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task DeleteMagazine(string id)
        {
            await _magazinesCollection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<List<Magazine>> GetMagazine()
        {
            var result =  await _magazinesCollection.FindAsync(m => true);

            return result.ToList();
        }

        public async Task<Magazine?> GetMagazineById(string id)
        {
           var result =  await _magazinesCollection.FindAsync(m => m.Id == id);

           return result.FirstOrDefault();
        }
    }
}
