using DataAccessLayer.Context;
using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbMehods
{
    public class RoleMethods:IRoleMethods
    {
        private readonly FlipkartContext _context;
        public RoleMethods(FlipkartContext context)
        {
            _context = context;

        }

        public async Task<List<string>> AllRoles()
        {
            try
            {
                var datas = await _context.Roles.Select(x=>x.RoleName).ToListAsync();
                return datas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> SetRole(string adminEmail,string role)
        {
            try
            {
                int? id=_context.Users.Where(x=>x.Email== adminEmail).FirstOrDefault()?.Id;
                var roleObj = await _context.Roles.Where(x => x.RoleName == role).FirstOrDefaultAsync();
                if (roleObj != null)
                {
                    return $"{role} already Exist ...!";
                }
                var newrole = new Roles
                {
                    RoleName = role,
                    CreatedBy = id ?? 0,


                };
                await _context.Roles.AddAsync(newrole);
                await _context.SaveChangesAsync();
                return $"Added Role:{role} ";
            }
            catch (Exception)
            {

                throw;
            }
        }

       
    }
}
