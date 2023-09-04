using Project.Entites.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entites.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now; /*Default değerleri verilmiştir.*/

        public DateTime? ModifedDate { get; set; }

        public DateTime? DeletedDate { get; set; }

        public DataStatus Status { get; set; }=DataStatus.Inserted; /*Default değerleri verilmiştir.*/

    }
}
