using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientsWeb.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(100)]
        public string FatherName { get; set; }
        [Required]
        [StringLength(100)]
        public string MotherName { get; set; }
        [Required]
        public int MaritialStatus { get; set; }
        [Required]
        public byte[] CustomerPhoto { get; set; }
        [Required]
        [StringLength(500)]
        public string CustomerAddress{ get; set; }

        [Required]
        [ForeignKey("Countries")]
        public int CountryId { get; set; }
        public virtual Country Countries { get; set; }

    }
}
