using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class UserViewModel
    {
        //public int Id { get; set; }
        public string Name { get; set; }        
        public byte[] Image { get; set; }
        
        public string Address { get; set; }
        /*
        public string AddressLine { get; set; }
        public int PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
         */

    }
}