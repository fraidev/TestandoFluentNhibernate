using FluentNHibernateDemo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace FluentNhiberteDemoTest
{
    public class TestNHibernate
    {
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _fixture = new Fixture();
        }

        [Test]
        public void Tester()
        {
            using (var session = NHibernateHelper.OpenSession())
            {

                using (var transaction = session.BeginTransaction())
                {
                    //var customerAleatorio1 = _fixture.Create<Customer>();
                    //session.Save(customerAleatorio1);

                    var produtoAleatorio1 = _fixture.Create<Product>();
                    session.Save(produtoAleatorio1);

                    var produtoAleatorio2 = _fixture.Create<Product>();
                    session.Save(produtoAleatorio2);
                    
                    var vip = new Category
                    {
                        Name = "VIP"
                    };
                    session.Save(vip);

                    var customer = new Customer
                    {
                        Name = "Allan",
                        Category = vip,
                        Products = new[] {
                            produtoAleatorio1,
                            produtoAleatorio2
                        }
                    };


                    //// When
                    session.Save(customer);

                    transaction.Commit();

                    session.Clear();

                    // Then
                    var result = session.Get<Customer>(1);
                    Assert.AreEqual("Allan", result.Name);

                    Assert.AreEqual(2, result.Products.Count);

                    Assert.AreEqual(produtoAleatorio1.Name, result.Products[0].Name);
                    Assert.AreEqual(produtoAleatorio2.Name, result.Products[1].Name);


                    //Assert.AreEqual(customerAleatorio1.Name, Customer[1].Name);



                }
            }
        } 
    }
}
