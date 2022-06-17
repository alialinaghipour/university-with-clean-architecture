using System.Security.Cryptography;
using System.Text;

namespace Application.Security;

public static class PasswordHelper
{
    public static string Hash(this string pass)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        var originalBytes = Encoding.Default.GetBytes(pass);
        var encodedBytes = md5.ComputeHash(originalBytes);
        return BitConverter.ToString(encodedBytes);
    }
}