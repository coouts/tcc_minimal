using System.Security.Cryptography;
using System.Text;

public class PasswordHasher
{
    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        string hashOfInput = HashPassword(password);
        return hashOfInput.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
    }
}