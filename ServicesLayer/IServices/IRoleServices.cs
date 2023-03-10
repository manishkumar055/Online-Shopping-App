using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IServices
{
    public  interface IRoleServices
    {
        public Task<string> SetRole(string AdminEmail,string role);

        public Task<List<string>> AllRoles();
    }
}
