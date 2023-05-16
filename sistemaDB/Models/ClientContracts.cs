using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDB.Models
{
    public class ClientContract
    {
        public int Id { get; set; }
        [Required, MaxLength(150)]
        public string? Name { get; set; }
        public DateTime DataStart { get; set;}
        public DateTime DataFinich { get; set;}
        public bool Active { get; set;}

        [ForeignKey("ClientSystem")]
        public int ClientSystemId { get; set;}
        public virtual ClientSystem ClientSystem { get; set;}
    }
}
    