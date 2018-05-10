using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class UserViewModel
    {
        //public int Id { get; set; }
        public string Description { get; set; }        
        public string Image { get; set; }
        public string FavBook { get; set; }
        public string Name { get; set; }
    }
}