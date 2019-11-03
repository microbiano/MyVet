using MyVet.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    
    public class ServiceType
    {
        [Key]
        public int ServiceTypeId { get; set; }

        [Display(Name = "Service Type")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        #region Relaciones Virtuales
            public ICollection<History> Histories { get; set; }
        #endregion

    }
}
