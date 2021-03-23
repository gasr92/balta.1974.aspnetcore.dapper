using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            this.OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Identificador do cliente é inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Pedido não possui itens")
            );

            return base.IsValid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}