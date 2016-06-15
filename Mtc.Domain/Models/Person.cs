using System;
using System.Text;

namespace Edc.Domain.Models
{
    public class Person
    {
        private string _password;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? ExperiencePoints { get; set; }
        public short? Level { get; set; }
        
        public string Password
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = Crypto.Hash(value);
            }
        }

        public override string ToString()
        {
            return FirstName + " " + (MiddleName != null ? MiddleName + " " : "") + LastName;
        }

        public bool CheckPassword(string password)
        {
            return string.Equals(Password, Crypto.Hash(password));
        }
    }

    public static class Crypto
    {
        public static string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}
