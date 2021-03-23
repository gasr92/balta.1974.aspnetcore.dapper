using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{
    public class Document : Notifiable
    {
        public Document(string number)
        {
            this.Number = number;

            AddNotifications(new ValidationContract()
                .IsTrue(Validate(), "Document", "CPF Inválido")
            );
        }

        public string Number { get; private set; }

        public override string ToString()
        {
            return this.Number;
        }

        public bool Validate()
        {
            return this.Number.Length == 11;
        }
    }
}