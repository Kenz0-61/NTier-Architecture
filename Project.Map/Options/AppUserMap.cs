using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Map.Options
{
    public class AppUserMap:BaseMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("Kulllanıcılar");
            Property(x=>x.UserName).HasColumnName("KullanıcıAdı");
            Property(x=>x.Password).HasColumnName("Şifre").HasMaxLength(10);
            HasOptional(x => x.AppUserProfile).WithRequired(x => x.AppUser);//userprofile bos gecilebilinir. Fakat AppUser boş geçilemez. BİREBİR İLİŞKİ YAPILMAKTADIR. App UserMap'da ilişki modelini oluşturlduğu için AppUserProfileMap'de tekrar ilişki oluşturmaya gerek yoktur.
        }
    }
}
