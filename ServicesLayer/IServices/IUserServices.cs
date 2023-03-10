using ServicesLayer.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.IServices
{
    public  interface IUserServices
    {
        public Task<string> AddUser(UserRequestDTO request);

        public Task<string> AddAdmin(string role,UserRequestDTO request);

        public Task<string> UpdateUser(UserRequestDTO request);

        public Task<string> DeleteUser(string Email);

        public Task<List<UserRequestDTO>> GetAll();

        public Task<UserRequestDTO> GetById(string Email);

        public Task<string> Login(string email, string password);
        
    }
}
