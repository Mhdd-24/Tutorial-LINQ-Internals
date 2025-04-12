using System;
using System.Linq;

namespace LinqInternals
{
    class Program
    {

        public static void Main(string[] args)
        {
            var customers = new[] {
                new Customer{
                    Id = 1,
                    Name = "John",
                    Phones=new[]{
                        new Phone
                        { Number = "123", PhoneType = PhoneType.Cell },
                        new Phone
                        { Number = "345", PhoneType = PhoneType.Home }
                     }
                },
                new Customer
                {
                    Id = 2,
                    Name = "Jane",
                    Phones = new[]
                    {
                        new Phone
                        { Number = "213-123-1234", PhoneType = PhoneType.Cell},
                        new Phone
                        { Number = "564-324-2344", PhoneType = PhoneType.Home}
                    }
                }
            };

            var addresses = new[]
            {
                new Address{Id = 1, CustomerId = 2, Street = "123 Street", City = "City1"},
                 new Address{Id = 2, CustomerId = 2, Street = "456 Street", City = "City2"}
            };

            // var customerPhones = customers.NewSelectMany(c => c.Phones);
            // foreach (var item in customerPhones)
            // {   
            //     Console.WriteLine($"{item.Number} - {item.PhoneType}");
            // }

            var customerWithAddress = customers.NewJoin(
                addresses,
                c => c.Id,
                a => a.CustomerId,
                (c, a) => new { c.Name, a.Street, a.City }
            );

            foreach (var item in customerWithAddress)
            {
                Console.WriteLine($"{item.Name} - {item.Street} - {item.City}");
            }
        }

        private static void WhereDemo()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Using built-in Where
            var evenItem = items.NewSelect(x => x % 2 == 0);

            foreach (var item in evenItem)
            {
                Console.WriteLine(item);
            }
        }
    }
}
