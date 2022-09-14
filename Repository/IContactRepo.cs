using System.Threading.Tasks;

namespace Repository
{
    public interface IContactRepo
    {
        Task<Contact?> Get(int id);
        IAsyncEnumerable<Contact> Get();
    }
}
