using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }

        public User  User { get; set; }

        #region Relaciones Virtuales

            public virtual ICollection<Pet> Pets { get; set; }
            
            public virtual ICollection<Agenda> Agendas { get; set; }
        #endregion
    }
}

