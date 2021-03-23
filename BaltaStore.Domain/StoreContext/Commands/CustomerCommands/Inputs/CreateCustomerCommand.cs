using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    //FailFastValidation
    // command nao podem obrigar o uso de construtores, para que seja possivel mapear as propriedades
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve possuir no mínimo 3 caracteres")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve possuir no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve possuir no mínimo 3 caracteres")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve possuir no máximo 40 caracteres")
                .IsEmail(Email, "Email", "E-mail inválido")
                .HasLen(Document, 11, "Document", "CPF inválido")
            );

            return base.IsValid;
        }


        // valida se o usuario existe no banco (EMAIL, CPF)
        

    }
}