using System.ComponentModel.DataAnnotations;

namespace StartService.Dtos
{
    public class AccountCreateDto
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}