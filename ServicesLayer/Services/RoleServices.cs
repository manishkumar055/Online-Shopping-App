using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using ServicesLayer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Services
{
    public class RoleServices:IRoleServices
    {
        private readonly IRoleMethods _roles;
        public RoleServices(IRoleMethods roles)
        {
            _roles = roles;
        }

        public Task<List<string>> AllRoles()
        {
            try
            {
                var res = _roles.AllRoles();
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> SetRole(string AdminEmail, string role)
        {
            try
            {
                var res = _roles.SetRole(AdminEmail,role);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
