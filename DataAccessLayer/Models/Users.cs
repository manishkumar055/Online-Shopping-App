using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Users:Audit
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }


        [Unique]
        [Required]
        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        [ForeignKey(nameof(RoleId))]
        public int RoleId { get; set; }

        public Roles Role { get; set; }
        public ICollection<Products> Products { get; set; }
        public ICollection<OrderTable> OrderTables { get; set; }


    }
}
