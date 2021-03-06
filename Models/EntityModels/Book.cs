using System;

namespace  BookCave.Models.EntityModels
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Isbn { get; set; }
        public string Image { get; set; }
        public int AuthorId { get; set; }
        public double TotalPrice { get; set; }
        public double Rating { get; set; }
        public int Views { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
        public int MainCategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int PublisherId { get; set; }
        public int CopiesSold { get; set; }
    }
}