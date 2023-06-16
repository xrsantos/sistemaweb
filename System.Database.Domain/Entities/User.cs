namespace System.Database.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public bool FlgEnable { get; set; }
        public string password { get; set; }
        public string Email { get; set; }

        public Costumer Costumer { get; set; }
    }
}