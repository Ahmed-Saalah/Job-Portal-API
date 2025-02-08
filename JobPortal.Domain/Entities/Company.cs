namespace JobPortal.Domain.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Location {  get; set; }
        public DateTime? CreateDate { get; set; }

        public ICollection<Job>? Jobs { get; set; }
    }
}
