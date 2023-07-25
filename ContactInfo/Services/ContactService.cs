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

		//public async Task<IEnumerable<Contact>> GetAllAsync()
		//{
		//	var contact = _ContactsCollectionName.Find(_=> true).ToListAsync();

		//}
		public async Task<IEnumerable<Contact>> GetAllAsync()=>
		
			await _ContactsCollectionName.Find(_ => true).ToListAsync();

		public async Task<Contact> GetByIdAsync(string id) =>
			await _ContactsCollectionName.Find(a => a.Id == id).FirstOrDefaultAsync();
	
		public async Task CreateAsync(Contact contact)=>
			await _ContactsCollectionName.InsertOneAsync(contact);

		public async Task UpdateAsync(string id, Contact contact)=>
			await _ContactsCollectionName.ReplaceOneAsync(a => a.Id == contact.Id, contact);
	    
		public async Task DeleteAsync(string id)=>
			await _ContactsCollectionName.DeleteOneAsync(a =>a.Id == id);
	    
	}
}
