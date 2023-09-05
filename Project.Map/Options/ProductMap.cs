using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Map.Options
{
    public class ProductMap : BaseMap<Product> 
    {
        public ProductMap()
        {
            ToTable("Ürünler");
            Property(x=>x.ProductName).HasColumnName("ÜrünAdı");
            Property(x=>x.UnitPrice).HasColumnName("Fiyat");
        }
    }
}
