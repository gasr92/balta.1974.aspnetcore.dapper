using BaltaStore.Domain.Repositories;
using BaltaStore.Domain.StoreContext.Entities;

namespace BaltaStore.Tests.Mocks
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}