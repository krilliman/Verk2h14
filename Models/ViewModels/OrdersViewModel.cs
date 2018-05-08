using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class OrdersViewModel
    {
        public int OrderId { get; set; }
        public List<OrderItemViewModel> OrderItem { get; set; }
        public double OrderPrice { get; set; }
    }
}