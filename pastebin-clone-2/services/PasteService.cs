using Microsoft.Extensions.Options;
using MongoDB.Driver;
using pastebin_clone_2.models;

namespace pastebin_clone_2.Services;

public class PasteService
{
    private readonly IMongoCollection<Paste> _pastesCollection;

    public PasteService(IOptions<PastebinConnectionSettings> PasteStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            PasteStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            PasteStoreDatabaseSettings.Value.DatabaseName);

        _pastesCollection = mongoDatabase.GetCollection<Paste>(
            PasteStoreDatabaseSettings.Value.PastesCollectionName);

    }
    
    public async Task<List<Paste>> GetAsync() =>
        await _pastesCollection.Find(_ => true).ToListAsync();

    public async Task<Paste?> GetAsync(string id) =>
        await _pastesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Paste newPaste) =>
        await _pastesCollection.InsertOneAsync(newPaste);

    public async Task UpdateAsync(string id, Paste updatedPaste) =>
        await _pastesCollection.ReplaceOneAsync(x => x.Id == id, updatedPaste);

    public async Task RemoveAsync(string id) =>
        await _pastesCollection.DeleteOneAsync(x => x.Id == id);

}