using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}