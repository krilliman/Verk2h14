using System;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public byte[] Image { get; set; }
        public string Author { get; set; }
        public double TotalPrice { get; set; }
        public double Rating { get; set; }
        //public int Views { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
        public int MainCategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int PublisherID { get; set; }

        // ma alveg kommenta eitthvad ef 
        public List<RateViewModel> Ratings {get; set; } // hvad gerir thetta?
        public bool WishListToggle { get; set; }
        public int BookId { get; set; }
        public string Comment { get; set; }
        public double Rate { get; set; }
        public int UserId {get; set; }
    }
}