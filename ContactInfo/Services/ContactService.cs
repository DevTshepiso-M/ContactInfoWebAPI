using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ContactInfo.Model;

namespace ContactInfo.Services
{
	public class ContactService: IContactService
	{
		private readonly IMongoCollection<Contact> _ContactsCollectionName;
		private readonly IOptions<DatabaseSettings> _databaseSettings;
		public ContactService(IOptions<DatabaseSettings> databaseSettings)
		{
			_databaseSettings = databaseSettings;
			var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
			_ContactsCollectionName = mongoDatabase.GetCollection<Contact>
				(databaseSettings.Value.ContactsCollectionName);
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
