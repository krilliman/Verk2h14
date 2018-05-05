using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class WishListViewModel
    {
        public int Id { get; set; }
        public List<WishListItemViewModel> Items { get; set; }
    }
}