using System.ComponentModel.DataAnnotations;
using BookCave.Models.ViewModels;

namespace BookCave.Models.InputModels
{
    public class AddressInputModel
    {
        public int? UserId { get; set; }
        [Required(ErrorMessage="StreetLine Is Required")]
        [RegularExpression("[a-zA-Z0-9]", ErrorMessage="Only Chars and Digits")]
        public string StreetLine { get; set; }
        [Required(ErrorMessage="PostalCode Is Required")]
        [RegularExpression("[0-9]" , ErrorMessage="Only Digits Allowed")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage="Country Is Required")]
        public string Country { get; set; }
        [RegularExpression("[a-zA-Z]", ErrorMessage="Only Chars Allowed")]
        public string Province { get; set; }
        [Required(ErrorMessage="City Is Required")]
        [RegularExpression("[a-zA-Z]",ErrorMessage="Only Chars Allowed")]
        public string City { get; set; }
    }
}