using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Map.Options
{
    public class OrderMap:BaseMap<Order>
    {
        public OrderMap()
        {
            ToTable("Sipariş");
            Property(x=>x.ShippedAddress).HasColumnName("Teslim Adresi");
        }
    }
}
