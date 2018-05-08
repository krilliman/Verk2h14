using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class UserViewModel
    {
        //public int Id { get; set; }
        public string Description { get; set; }        
        public byte[] Image { get; set; }
    }
}