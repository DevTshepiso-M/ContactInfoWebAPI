using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ContactInfo.Model;

namespace ContactInfo.Services
{
	public class ContactService: IContactService
	{
		private readonly IMongoCollection<Contact> _ContactsCollectionName;
		private readonly IOptions<DatabaseSettings> _dbSettings;
		public ContactService(IOptions<DatabaseSettings> dbSettings)
		{
			_dbSettings = dbSettings;
			var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
			_ContactsCollectionName = mongoDatabase.GetCollection<Contact>
				(dbSettings.Value.ContactsCollectionName);
		}

		public async Task<IEnumerable<Contact>> GetAllAsync()
		{
			var contact = _ContactsCollectionName.Find(_=> true).ToListAsync();
		}
	}
}
