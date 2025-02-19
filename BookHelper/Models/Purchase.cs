using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("Book")]
        public int? BookID { get; set; }
        public Book? Book { get; set; }

        [ForeignKey("Electronic")]
        public int? ElectronicID { get; set; }
        public Electronic? Electronic { get; set; }
    }
}
