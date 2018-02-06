using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Classe Customer
namespace FluentNHibernateDemo
{
    class Customer
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual IList<Product> Products { get; set; }
        
        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}