using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;
using BaltaStore.Domain.Repositories;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable
                                    , ICommandHandler<CreateCustomerCommand>
                                    , ICommandHandler<AddAddressCommand>
    {

        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // verifica se cpf ja existe ma base
            if(_repository.CheckDocument(command.Document))
                base.AddNotification("Document", "Este documento já está em uso");

            // verificar se  o email ja existe na base
            if (_repository.CheckEmail(command.Email))
                base.AddNotification("Email", "Este e-mail já existe na base da dados");

            // preparar e criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // criar entidades
            var customer = new Customer(name, document, email, command.Phone);

            // persistir o cliente
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);


            if(Invalid)
                return null;

            // persistir o cliente
            _repository.Save(customer);

            // enviar email de boas vindas
            _emailService.Send(email.Address, "hello@balta.io", "Bem vindo", "Seja bem vindo");
            // retorna o resultado para a tela

            return new CreateCustomerCommandResult(customer.Id, name.ToString(),email.Address );
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override IEnumerable<Notification> Validations()
        {
            return base.Validations();
        }
    }
}