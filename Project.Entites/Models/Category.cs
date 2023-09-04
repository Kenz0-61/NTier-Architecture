using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entites.Models
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        //Relational - Navigation Properties

        public virtual List<Product> Products { get; set; } // Çok ilişki bir CATEGORY birden cok PRODUCT'ta olabilir.
    }
}
