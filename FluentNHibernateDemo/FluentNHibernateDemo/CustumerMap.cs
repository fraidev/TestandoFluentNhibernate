using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Mapa da classe Customer para o Banco de Dados
namespace FluentNHibernateDemo
{
    class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customer");

            Id(x => x.Id); 

            Map(x => x.Name);
          //Map(x => x.LastName);
            
            HasManyToMany(x => x.Products)
                .Table("CustomerProduct")
                .ParentKeyColumn("CustomerId")
                .ChildKeyColumn("ProductId")
                .Fetch.Join() // 
                .Not.LazyLoad(); // Pegar todos os itens ........ Not.LazyLoad = EagerLoad() 

            // Reference
            References(x => x.Category, "CategoryId")
                .Fetch.Join()
                .Not.LazyLoad();
        
            // HasMany
            HasMany(x => x.Contacts)
                .Table("ContactrProduct");

            // Fetch Eager, Fetch Lazy



            // Cliente ** --- ** Produto

        }
    }

    class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Category");

            Id(x => x.Id);

            Map(x => x.Name);           

        }
    }

    class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");

            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.Value, "[Value]"); // value eh palavra reservada

        }
    }

    class ContactMap : ClassMap<Contact>
    {
        public ContactMap()
        {
            Table("Contact");

            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.Number);

        }
    }
}