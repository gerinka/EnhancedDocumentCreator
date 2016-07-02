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
        public bool FirstTimeDocument { get; set; }
        public bool FirstTimeTasks { get; set; }
        public bool FirstTimeContent { get; set; }
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

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var p = obj as Person;
            if ((System.Object)p == null)
            {
                return false;
            }

            return (Id == p.Id) && (Email == p.Email);
        }

        public bool Equals(Person p)
        {
            // If parameter is null return false:
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Id == p.Id) && (Email == p.Email);
        }


        public override int GetHashCode()
        {
            if (Email == null) return 0;
            return Email.GetHashCode();
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
