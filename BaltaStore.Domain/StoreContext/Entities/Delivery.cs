using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            this.CreateDate = DateTime.Now;
            this.EstimatedDeliveryDate = estimatedDeliveryDate;
            this.Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }


        public void Ship()
        {
            this.Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            this.Status = EDeliveryStatus.Canceled;
        }
    }
}