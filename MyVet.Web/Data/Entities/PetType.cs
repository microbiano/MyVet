﻿using MyVet.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data
{
    public class PetType
    {
        public int PetTypeId { get; set; }

        [Display(Name="Pet Type")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory")]
        public string Name { get; set; }

        #region Relaciones Virtuales

            public ICollection<Pet> Pets { get; set; }          

        
        #endregion
    }
}
