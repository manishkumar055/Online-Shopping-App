using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.IDbMethods
{
    public interface IUserMethods
    {
        
        public Task<List<Users>> GetAll();

        public Task<Users> GetByEmailId(string email);
        public Task<string> Add(string password,Users user);

        public Task<string> Update(string password,Users user);

        public Task<string> Delete(string email);

        public Task<string> Login(string email, string password);

        public Task<string> AddByAdmin(string password, Users request,string role);
    }
}
