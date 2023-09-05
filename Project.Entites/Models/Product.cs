using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entites.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int? CategoryID { get; set; } //ForeignKey

        //Relational - Navigation Properties

        public virtual Category Category { get; set; } // Bir product'da bir category olur

        public virtual List<OrderDetail> OrderDetails { get; set; } //ÇokaÇok İlişki
    }
}
