using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entites.Models
{
    public class AppUser:BaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        //Relatinaol - Navigation Property

        public virtual AppUserProfile Profile { get; set; } /*Birebir İlişki*/

        public virtual List<Order> Orders { get; set; } // Bir kullanıcının birde çok siparişi olabilir Çok ilişki
    }
}
