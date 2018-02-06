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
                    var customer = new Customer
                    {
                        FirstName = "Allan",
                        LastName = "Bomer"
                    };

                    session.Save(customer);
                    transaction.Commit();
                    Console.WriteLine("Customer Created: " + customer.FirstName + "\t" +
                       customer.LastName);
                                        
                    var c= session.Get<Customer>(1);                   

                    
                }

                Console.ReadKey();
            }
        }
    }
}