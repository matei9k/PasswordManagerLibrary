using System.Security.Cryptography;
using System.Text;

namespace PasswordManager;

public class Hasher
{
    public static string Hash(string input)
    {
        using SHA512 sha = SHA512.Create();
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashBytes = sha.ComputeHash(inputBytes);
        StringBuilder builder = new StringBuilder();

        foreach (var hashByte in hashBytes)
            builder.Append(hashByte.ToString("x2"));
        return builder.ToString();
    }

    public static string GenerateSalt(int length = 8)
    {
        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        byte[] randomBytes = new byte[length];
        using RandomNumberGenerator rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        char[] chars = new char[length];

        for (int i = 0; i < length; i++)
            chars[i] = validChars[randomBytes[i] % validChars.Length];
        return new string(chars);
    }
}