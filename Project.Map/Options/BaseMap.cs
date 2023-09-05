using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Map.Options
{
    //Map'ler veritabanı sınıflarının ayarlamalarını yapıldıgı sınıflardır. EntityTypeConfigration Sınıfı base sınıf olarak kullanılmalıdır.

    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity // Constraint uygulayarak BaseEntity ve BaseEntity'den türeyen sınıflar Generic olarak verilebilinmektedir.

    {
        public BaseMap()
        {
            Property(x => x.CreatedDate).HasColumnName("Oluşturulma Tarihi");
            Property(x => x.DeletedDate).HasColumnName("Pasif Edilme Tarihi");
            Property(x => x.ModifedDate).HasColumnName("Güncelle Tarihi");
            Property(x => x.Status).HasColumnName("Veri Durumu");
        }
    }
}
