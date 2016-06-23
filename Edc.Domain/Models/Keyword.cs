namespace Edc.Domain.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var k = obj as Keyword;
            if ((System.Object)k == null)
            {
                return false;
            }

            return (Id == k.Id) && (Name == k.Name);
        }

        public bool Equals(Keyword k)
        {
            // If parameter is null return false:
            if ((object)k == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Id == k.Id) && (Name == k.Name);
        }


        public override int GetHashCode()
        {
            if (Name == null) return 0;
            return Name.GetHashCode();
        }
    }
}