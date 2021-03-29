using System.Collections.Generic;
using System.Linq;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Entities;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses;

        public Customer(Name name, Document document, Email email, string phone)
        {
            this.Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public Name Name { get; set; }
        public Document Document { get; set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();



        public void AddAddress(Address address)
        {
            // validar o endereco
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return "${this.FirstName} {this.LastName}";
        }
    }
}