using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateDemo
{
    class Program
    {

        static void Main(string[] args)
        {

            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    var tabuleiro = new Product
                    {
                        Name = "Tabuleiro",
                        Value = 300
                    };
                    session.Save(tabuleiro);

                    var fulano = new Contact
                    {
                        Name = "fulado",
                        Number = 900
                    };
                    session.Save(fulano);

                    var tapete = new Product
                    {
                        Name = "Tapete",
                        Value = 500
                    };
                    session.Save(tapete);


                    var vip = new Category
                    {
                        Name = "VIP"
                    };
                    session.Save(vip);

                    var NotVip = new Category
                    {
                        Name = "Not VIP"
                    };
                    session.Save(NotVip);

                    var customer = new Customer
                    {
                        Name = "Allan",
                        Category = vip,
                        Products = new[] {
                            tabuleiro,
                            tapete
                        },
                        Contacts = new[] {
                            fulano,
                    }
                    };

                                        
                    session.Save(customer);

                    transaction.Commit();
                    Console.WriteLine("Customer Created: " + customer.Name + "\t");

                    session.Clear();

                    var c= session.Get<Customer>(1);


                    Console.WriteLine("Category: " + c.Category.Name);


                    foreach(var p in c.Products)
                    {
                        Console.WriteLine("Product: " + p.Name + " - " + p.Value);
                    }

                }

                Console.ReadKey();
            }
        }
    }
}