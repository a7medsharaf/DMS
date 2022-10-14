using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Models
{
    public class Folder
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ParentType { get; set; }
        [Required]
        public int Parent { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
