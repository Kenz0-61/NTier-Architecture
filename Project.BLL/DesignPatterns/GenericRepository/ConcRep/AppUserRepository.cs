using Project.BLL.DesignPatterns.GenericRepository.BaseRep;
using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.ConcRep
{
    //Burada AppUser veya diğer repositoryler özelinde özel iş parçacıkları method-fonksiyonlar oluşturabiliriz.
    public class AppUserRepository:BaseRepository<AppUser>
    {
    }
}
