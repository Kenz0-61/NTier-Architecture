using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Map.Options
{
    public class ShipperMap:BaseMap<Shipper>
    {
        public ShipperMap()
        {
            ToTable("KargoFirma");
            Property(x => x.CompanyName).HasColumnName("Şirket İsmi");
        }
    }
}
