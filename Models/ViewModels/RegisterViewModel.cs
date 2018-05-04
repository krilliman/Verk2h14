using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        //public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string AddressLine { get; set; }
        public int PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}