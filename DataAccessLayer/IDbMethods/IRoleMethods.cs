using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IDbMethods
{
    public interface IRoleMethods
    {
        public Task<string> SetRole(string adminEmail,string role);

        public Task<List<string>> AllRoles();
    }
}
