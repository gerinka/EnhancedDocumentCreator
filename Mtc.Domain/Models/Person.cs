namespace Mtc.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public int? ExperiencePoints { get; set; }
        public short? Level { get; set; }
    }
}