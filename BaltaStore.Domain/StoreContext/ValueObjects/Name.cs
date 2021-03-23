using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve possuir no mínimo 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve possuir no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve possuir no mínimo 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve possuir no máximo 40 caracteres")
            );
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}