using FixMeApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FixMeApi.Services;

public class MobileService
{
    private readonly IMongoCollection<Mobile> _mobileCollection;

    public MobileService(
        IOptions<MobileStoreDatabaseSettings> mobileStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            mobileStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mobileStoreDatabaseSettings.Value.DatabaseName);

        _mobileCollection = mongoDatabase.GetCollection<Mobile>(
            mobileStoreDatabaseSettings.Value.MobileCollectionName);
    }

    public async Task<List<Mobile>> GetAsync() =>
        await _mobileCollection.Find(_ => true).ToListAsync();

    public async Task<Mobile?> GetAsync(string id) =>
        await _mobileCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Mobile newMobile) =>
        await _mobileCollection.InsertOneAsync(newMobile);

    public async Task UpdateAsync(string id, Mobile updatedMobile) =>
        await _mobileCollection.ReplaceOneAsync(x => x.Id == id, updatedMobile);

    public async Task RemoveAsync(string id) =>
        await _mobileCollection.DeleteOneAsync(x => x.Id == id);
}