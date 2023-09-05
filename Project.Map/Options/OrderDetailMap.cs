using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Map.Options
{
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("Sipariş Detayı");
            Ignore(x => x.Id);
            HasKey(x=> new { 
                x.OrderID,
                x.ProductID
            });
        }
    }
}
