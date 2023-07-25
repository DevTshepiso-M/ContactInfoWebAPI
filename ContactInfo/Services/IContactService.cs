using ContactInfo.Model;
using MongoDB.Driver;

namespace ContactInfo.Services
{
	public interface IContactService
	{

		Task<IEnumerable<Contact>> GetAllAsync();
		Task<Contact> GetByIdAsync(string id);
		Task CreateAsync(Contact contact);
		Task UpdateAsync(string id, Contact contact);
		Task DeleteAsync(string id);
	}
}
