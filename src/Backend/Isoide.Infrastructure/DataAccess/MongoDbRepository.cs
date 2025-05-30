using Isoide.Domain.Entities;
using Isoide.Domain.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Isoide.Infrastructure.DataAccess;

public class MongoDbRepository : IQrCodeRepository
{
	private readonly IMongoCollection<QrCode> _collection;

	public MongoDbRepository(IOptions<IsoideDatabaseSettings> settings )
	{
		var mongoClient = new MongoClient(settings.Value.ConnectionString);
		var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
		_collection = database.GetCollection<QrCode>(settings.Value.QrCodeCollectionName);
	}


	public async Task<QrCode?> GetByIdAsync(Guid id)
	{
		 return await _collection.Find(q => q.Id == id).FirstOrDefaultAsync();
	}

	public async Task AddAsync(QrCode qrCode)
	{
		await _collection.InsertOneAsync(qrCode);
	}
}