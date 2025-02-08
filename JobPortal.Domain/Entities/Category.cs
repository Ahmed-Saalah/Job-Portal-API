namespace JobPortal.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Job>? Jobs { get; set; }
    }
}
