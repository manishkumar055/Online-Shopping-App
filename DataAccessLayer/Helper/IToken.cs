using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helper
{
    public interface IToken
    {
        string CreateToken( Users user);

        void CreateHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt);
        public bool VerifyPasswordHash(string password, byte[] passwordsalt, byte[] passwordHash);
    }
}
