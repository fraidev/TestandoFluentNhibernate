
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Classe Customer
namespace FluentNHibernateDemo
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Product> Products { get; set; } //Tabela de Produtos

        public virtual IList<Contact> Contacts { get; set; } //Tabela de Contatos

        public virtual Category Category { get; set; } // Classe Categoria
    }

    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}