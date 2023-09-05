using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entites.Models
{
    public class Shipper:BaseEntity
    {
        public string CompanyName { get; set; }

        //Relational - Navigation Properties

        public virtual List<Order> OrderList { get; set; }
      
    }
}
