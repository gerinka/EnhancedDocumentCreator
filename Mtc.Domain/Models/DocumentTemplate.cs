namespace Mtc.Domain.Models
{
    public class DocumentTemplate
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { set; get; }
        public bool IsActive { get; set; }
    }
}