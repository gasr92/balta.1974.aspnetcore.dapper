// using System;

// namespace BaltaStore.Domain.StoreContext
// {
//     // sealed proibe que a classe seja herdada
//     // abstract nao permite que uma classe seja instanciada (utilizado em classes que sao herdadas)
//     public class Person : IPerson, IEmployee
//     {
//         public string Name { get; set; }
//         public DateTime BirthDate { get; set; }
//         public decimal Salary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

//         public void OnRegister()
//         {
//             throw new NotImplementedException();
//         }
//     }

//     public class Customer : Person
//     {
//         //metodos
//         public void Register()
//         {

//         }

//         // eventos
//         public void OnRegister()
//         {

//         }

//         public override string ToString()
//         {
//             return this.Name;
//         }
//     }


//     public class Salesman : Person
//     {
//     }

//     public interface IPerson
//     {
//         string Name { get; set; }
//         DateTime BirthDate { get; set; }
//         void OnRegister();
//     }

//     public interface IEmployee
//     {
//         decimal Salary { get; set; }
//     }
// }