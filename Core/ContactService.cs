using Repository;

namespace Core
{
    public class ContactService : IContactService
    {

        private readonly IContactRepo contactRepo;

        public ContactService(IContactRepo contactRepo)
        {
            this.contactRepo = contactRepo;
        }
        public async Task<Contact> Get(int id)
        {
            var contact = await contactRepo.Get(id);
            //var result = Task.WhenAll(contactRepo.Get(id), salesRepo.Get(id));
            return new Contact { 
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                Company = contact.Company,
                Title = contact.Title
            };
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            var contacts = new List<Contact>();
            var contactAsyncEnumerable = contactRepo.Get();
            await foreach (var contact in contactAsyncEnumerable)
            {
                 contacts.Add(new Contact
                {
                    Id = contact.Id,
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Company = contact.Company,
                    Title = contact.Title
                });
            }

            return contacts;
        }
    }
}
