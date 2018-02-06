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

            Map(x => x.FirstName);
            Map(x => x.LastName);
            
            HasManyToMany(x => x.Products)
                .LazyLoad()
                .Table("CustomerProduct")
                .ParentKeyColumn("CustomerId")
                .ChildKeyColumn("ProductId");
            
            References(x => x.Category, "CategoryId");

            // Reference


            // HasMany
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
            Map(x => x.Value, "[Value]");

        }
    }
}