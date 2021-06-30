using System;
using System.Security.Cryptography;
using System.Text;

namespace ZbW.ITB1821H.OrderManager.Model.Service
{
  public class PasswordService
  {
    /// <summary>
    /// Generates a new random salt-value and hashes the specified password. 
    /// Sets the password properties for the specified customer.
    /// </summary>
    /// <param name="password">Non-hashed password string</param>
    /// <param name="customer">Customer which the password should be stored to</param>
    public void HashPassword(string password, Customer customer)
    {
      var r = new Random();
      customer.PasswordSalt = r.Next(10000000, 99999999).ToString();
      customer.PasswordHash = Hash(password, customer.PasswordSalt);
    }

    /// <summary>
    /// Compares two password hash-values. The Salt will be taken from the specified customer.
    /// </summary>
    /// <param name="password">Non-hashed password string to compare</param>
    /// <param name="customer">The customer with the password to compare</param>
    /// <returns>True if the hash-strings are equal</returns>
    public bool ComparePassword(string password, Customer customer)
    {
      return customer.PasswordHash == Hash(password, customer.PasswordSalt);
    }

    private string Hash(string password, string salt)
    {
      var md5 = MD5.Create();
      byte[] bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(salt + password));
      return BitConverter.ToString(bytes).Replace("-", "");
    }
  }
}
