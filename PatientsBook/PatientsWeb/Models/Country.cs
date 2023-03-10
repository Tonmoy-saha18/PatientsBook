using System.ComponentModel.DataAnnotations;

namespace PatientsWeb.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }
    }
}
