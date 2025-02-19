using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Electronic
    {
        [Key]
        public int ElectronicID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
