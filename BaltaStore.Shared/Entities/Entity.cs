using System;
using FluentValidator;

namespace BaltaStore.Shared.Entities
{
    // esta classe nunca podera ser instanciada, por isso deve ser abstract
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id{get;private set;}
    }
}