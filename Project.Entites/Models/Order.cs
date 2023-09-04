using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entites.Models
{
    public class Order:BaseEntity
    {
        public string ShippedAddress { get; set; }

        public int? AppUserId { get; set; } //ForeignKey

        //Relational - Navigation Properties

        public virtual AppUser User { get; set; } //Bir siparişin bir sahibi olabilir. Tek İlişki

        public virtual List<OrderDetail> OrderDetails { get; set; } //ÇokaÇok İlişki
    }
}
