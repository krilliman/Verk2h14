
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class CheckOutInputModel
    {
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public int CardHolder { get; set; }
        [MaxLength(3)]
        [MinLength(3)]

        [Required]
        public string Cvc { get; set; }
        public double CartTotal { get; set; }
        public int UserId { get; set; }
    }
}