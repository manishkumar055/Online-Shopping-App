using Online_Ordering__System.Model;

namespace Online_Ordering__System.Helper
{
    public interface IToken
    {
        string CreateToken(Customer customer);
        string CreateToken(Seller seller);

        bool VerifyPasswordHash(string password, byte[] passwordSalt,byte[] passwordHash);
        

    }
}
