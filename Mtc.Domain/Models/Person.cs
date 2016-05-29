namespace Mtc.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? ExperiencePoints { get; set; }
        public short? Level { get; set; }

        public override string ToString()
        {
            return FirstName + " " + (MiddleName!=null ? MiddleName+" ":"") + LastName;
        }
    }
}