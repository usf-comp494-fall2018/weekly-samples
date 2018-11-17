using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindLibrary;

namespace NorthwindService.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customers> CreateAsync(Customers c);
        Task<IEnumerable<Customers>> RetrieveAllAsync();
        Task<Customers> RetrieveAsync(string id);
        Task<Customers> UpdateAsync(string id, Customers c);
        Task<bool> DeleteAsync(string id);
    }
}
