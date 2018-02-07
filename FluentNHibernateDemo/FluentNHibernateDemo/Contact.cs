
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateDemo
{
    public class Contact
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Value { get; set; }
        public virtual string Type { get; set; }
        // Name
        // Valor
        // Type
    }
}
