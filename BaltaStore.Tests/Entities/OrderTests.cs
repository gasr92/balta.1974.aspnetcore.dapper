using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class OrderTests
    {
        private Customer _validCustomer;
        private Order _order;
        private Product _mouse, _keyboard, _monitor, _impressora;

        public OrderTests()
        {
            _validCustomer = new Customer(
                new Name("Bruce", "Wayne")
                , new Document("01234567890")
                , new Email("bruce@wayne.com")
                , "05588440055"
            );
            _order = new Order(_validCustomer);
            _mouse = new Product("Mouse gamer", "Mousa para jogadores", "", 100M, 10);
            _keyboard = new Product("Teclado gamer", "Teclado para jogadores", "", 100M, 10);
            _monitor = new Product("Monitor Full HD", "Monitor full hd", "", 100M, 5);
            _impressora = new Product("Impressora", "Impressora que imprime", "", 100M, 20);
        }


        // cria um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // ao criar o pedido, o status deve ser CREATED
        [TestMethod]
        public void StatusSHouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }


        // ao adicionar um item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedToValidItems()
        {
            _order.AddItem(this._impressora, 5);
            _order.AddItem(this._monitor, 5);

            Assert.AreEqual(2, _order.Items.Count);
        }


        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchaseFiveItems()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }


        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }


        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }


        [TestMethod]
        public void ShouldReturnTwoShippingsWhenPurchasedTenProducts()
        {
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }


        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }


        [TestMethod]
        public void ShouldCancelShippingWhenOrderCanceled()
        {
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.AddItem(this._keyboard, 1);
            _order.Ship();

            _order.Cancel();

            foreach (var x in _order.Deliveries)
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
        }


        public void CreateCustomer()
        {
            // verifica se cpf ja existe
            // verifica se emial existe
            // cria novo VO
            // criar entidade
            // validadar as entidades e VO
            // inserir o cliente no banco
            // envia convite do slack
            // envia email de voas vindas
        }
    }
}