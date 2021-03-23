using System;
using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.Enums;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly List<OrderItem> _items;
        private readonly List<Delivery> _deliveries;

        public Order(Customer customer)
        {
            this.Customer = customer;
            this.CreateDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            this._items = new List<OrderItem>();
            this._deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();



        public void AddItem(Product product, decimal quantity)
        {
            //valida o item
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        // public void AddDelivery(Delivery delivery)
        // {
        //     _deliveries.Add(delivery);
        // }

        // to place an order
        public void Place()
        {
            // gera o numero do pedido
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();

            if (_items.Count == 0)
                AddNotification("Order", "O pedido não possui itens");
        }

        public void Pay()
        {
            this.Status = EOrderStatus.Paid;
            // var delivery = new Delivery(DateTime.Now.AddDays(5));
            // delivery.Ship();
            // _deliveries.Add(delivery);
        }

        public void Ship()
        {
            // a cada 5 produtos gera uma entrega
            var count = 1;
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            deliveries.ForEach(x => x.Ship()); // passa o status da entrega para enviado
            deliveries.ForEach(x => _deliveries.Add(x)); // joga as entregas enviadas na propriedade da classe
        }

        public void Cancel()
        {
            this.Status = EOrderStatus.Canceled;
            _deliveries.ForEach(x => x.Cancel());
        }

    }
}