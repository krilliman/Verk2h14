using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Cart { get; set; }
        public double CartTotalPrice { get; set; }
        public int UserId { get; set; }
    }
}