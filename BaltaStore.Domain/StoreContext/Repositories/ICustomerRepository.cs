using BaltaStore.Domain.StoreContext.Entities;

namespace BaltaStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string email);

         void Save(Customer customer);
    }
}