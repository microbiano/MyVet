﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Manager
    {
        public int ManagerId { get; set; }

        public User User { get; set; }

    }
}
