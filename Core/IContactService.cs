using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IContactService
    {
        Task<Contact> Get(int id);
        Task<IEnumerable<Contact>> GetAll();
    }
}
