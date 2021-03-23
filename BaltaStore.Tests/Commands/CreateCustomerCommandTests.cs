// pra cada command vai existir um fluxo (handler)

using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Command
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "12345678901";
            command.Email = "batman@hotmail.com";
            command.Phone = "5522224444";

            Assert.AreEqual(true, command.Valid());
        }
    }
}