using System.ComponentModel.DataAnnotations;

namespace DMS.Models
{
    public class KnowledgePool
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
    }
}
