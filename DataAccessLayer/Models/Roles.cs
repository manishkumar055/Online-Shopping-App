﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Roles:Audit
    {
        [Key] public int Id { get; set; }

        public string RoleName { get; set; }

        public ICollection<Users> Users { get; set; }

    }
}
