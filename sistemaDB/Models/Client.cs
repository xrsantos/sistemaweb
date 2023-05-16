using System.ComponentModel.DataAnnotations;


namespace SistemaDB.Models
{
    public class ClientSystem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [Required, MaxLength(150)]
        public virtual ICollection<ClientContract>? ClientContracts { get; set;}
    }
}
    