using AutoMapper;
using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using ServicesLayer.IServices;
using ServicesLayer.RequestDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;

namespace ServicesLayer.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMapper _mapper;
        private readonly IUserMethods _userMethods;

        public UserServices(IMapper mapper,IUserMethods userMethods)
        {
                _mapper= mapper;
            _userMethods= userMethods;
        }
        public async  Task<string> AddUser(UserRequestDTO request)
        {
            try
            {
                var user = _mapper.Map<UserRequestDTO, Users>(request);

                var result = await _userMethods.Add(request.Password, user);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<string> AddAdmin(string role, UserRequestDTO request)
        {
            //var role = _userMethods.

            //
            var user=_mapper.Map<UserRequestDTO, Users>(request);
            var res=await _userMethods.AddByAdmin(request.Password, user,role);
            return res;
        }

        public async Task<string> DeleteUser(string Email)
        {
            try
            {
                var result=await _userMethods.Delete(Email);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserRequestDTO>> GetAll()
        {
            try
            {
                var data = await _userMethods.GetAll();
                var result = _mapper.Map<List<Users>, List<UserRequestDTO>>(data);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async  Task<UserRequestDTO> GetById(string Email)
        {
            try
            {
                var user =await _userMethods.GetByEmailId(Email);
                if (user != null)
                {
                    var res=_mapper.Map<Users,UserRequestDTO>(user);
                    return res;
                }
                throw new Exception("User Not Found");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> Login(string email, string password)
        {
            try
            {
                var res = _userMethods.Login(email, password);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<string> UpdateUser(UserRequestDTO request)
        {
            try
            {
                var user = _mapper.Map<UserRequestDTO, Users> (request);
                var res = _userMethods.Update(request.Password, user);
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
