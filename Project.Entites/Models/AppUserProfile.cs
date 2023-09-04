using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entites.Models
{
    public class AppUserProfile
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone {get; set; }

        public string Address { get; set; }

        //Relatinaol - Navigation Property

        public virtual AppUser User { get; set; } /*Birebir ilişki*/
    }
}
}
