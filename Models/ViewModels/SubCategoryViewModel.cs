using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class SubCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public List<BookViewModel> Top10Books { get; set; }
        public List<BookViewModel> BookList { get; set; }
    }
}