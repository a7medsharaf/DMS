using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS.Models
{
    public class File
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Folder")]
        public int Parent  { get; set; }
        public Folder Folder { get; set; }
        [Required]
        public string Extension { get; set; }
    }
}
