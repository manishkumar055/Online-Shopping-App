using DataAccessLayer.Context;
using DataAccessLayer.Helper;
using DataAccessLayer.IDbMethods;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using N_Tier_Architecture_FinalProject.ChangeTracking;

namespace DataAccessLayer.DbMehods
{
    public class UserMethods : IUserMethods
    {
        private readonly FlipkartContext _context;
        private readonly IToken _token;
        private readonly ITracking _track;
        public UserMethods(FlipkartContext context, IToken token, ITracking track)
        {
            _context = context;
            _token = token;
            _track = track;
        }

        public async Task<string> Add(string password, Users request)
        {
            try
            {
                var user = _context.Users
                    .Any(x => x.Email
                    .Equals(request.Email));
                if (user)
                {
                    throw new Exception("Already Resiterd Please Login");
                }
                byte[] passwordSalt;
                byte[] passworHash;
                var tempRoleId = _context.Roles
                    .Where(x => x.RoleName
                    .Equals("User"))
                    .FirstOrDefault().Id;

                request.RoleId = tempRoleId;

                _token.CreateHash(password, out passwordSalt, out passworHash);
                request.PasswordSalt = passwordSalt;
                request.PasswordHash = passworHash;

                await _context.Users.AddAsync(request);

                _track.AllChanges();
                await _context.SaveChangesAsync();
                return "User Registerd...!";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> Login(string email, string password)
        {
            var user = await _context.Users.Where(x => x.Email == email).Include(x => x.Role).FirstOrDefaultAsync();
            if (user != null)
            {
                if (_token.VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
                {
                    return _token.CreateToken(user);
                }
                return "Incorrect Password...!";
            }
            return "Please Register First...";
        }



        public async Task<string> AddByAdmin(string password, Users request, string role)
        {
            try
            {
                var tempRole = _context.Roles.Where(x => x.RoleName == role).FirstOrDefault();
                if (tempRole == null)
                {
                    var newrole = new Roles()
                    {
                        RoleName = role,
                    };
                    await _context.Roles.AddAsync(newrole);
                    await _context.SaveChangesAsync();
                }
                var user = await _context.Users
                    .Where(x => x.Email
                    .Equals(request.Email))
                    .FirstOrDefaultAsync();
                if (user != null)
                {

                    throw new Exception("Already Resiterd Please Login");
                }
                byte[] passwordSalt;
                byte[] passworHash;
                var tempRoleId = _context.Roles
                    .Where(x => x.RoleName
                    .Equals(role))
                    .FirstOrDefault().Id;

                request.RoleId = tempRoleId;

                _token.CreateHash(password, out passwordSalt, out passworHash);
                request.PasswordSalt = passwordSalt;
                request.PasswordHash = passworHash;

                await _context.Users.AddAsync(request);
                await _context.SaveChangesAsync();
                return $"{request.Name}  Registerd Role Is {role}...!";
            }
            catch (Exception ex)
            {

                throw;
            }
        }







        public async Task<string> Delete(string email)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
                if (user != null)
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return $"UserName {user.Name} Email :{user.Email} Deleted ";
                }
                return $"{email} Not Found";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<Users>> GetAll()
        {
            try
            {
                var result = await _context.Users.ToListAsync();
                return (result);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task<Users> GetByEmailId(string email)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Email.Equals(email)).FirstOrDefaultAsync();
                return user;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> Update(string password, Users user)
        {
            try
            {
                var tempUser = await _context.Users.Where(x => x.Email.Equals(user.Email)).FirstOrDefaultAsync();
                if (tempUser != null)
                {
                    if (!_token.VerifyPasswordHash(password, user.PasswordSalt, user.PasswordHash))
                        return "Incorrext Password ...";
                    tempUser.Name = user.Name;
                    tempUser.MobileNumber = user.MobileNumber;
                    tempUser.MobileNumber = user.MobileNumber;
                    await _context.SaveChangesAsync();
                    return $"Data changed for Email: {user.Email}";
                }
                return $"Email Not Found {user.Email}";

            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}
