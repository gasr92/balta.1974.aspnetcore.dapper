using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // dois metodos que testam o mesmo objeto mas retornam resultados diferenter se chama Red and green tests


        private Document _validDocument;
        private Document _invalidDocument;

        public DocumentTests()
        {
            _validDocument = new Document("12345678901");
            _invalidDocument =  new Document("012345678940");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, _invalidDocument.IsValid);
            Assert.AreEqual(1, _invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, _validDocument.IsValid);
            Assert.AreEqual(0, _validDocument.Notifications.Count);
        }
    }
}