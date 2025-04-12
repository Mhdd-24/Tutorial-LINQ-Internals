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

            var customerPhones = customers.NewSelectMany(c => c.Phones);
            foreach (var item in customerPhones)
            {   
                Console.WriteLine($"{item.Number} - {item.PhoneType}");
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
