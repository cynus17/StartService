using System.ComponentModel.DataAnnotations;

namespace StartService.Models
{
    public class Account{
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Password { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

    }
}