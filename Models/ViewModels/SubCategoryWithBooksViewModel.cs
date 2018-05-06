using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class SubCategoryWithBooksViewModel
    {
         public int ID { get; set; }
         public string Name { get; set; }
         public List<BookViewModel> BookList { get; set; }
    }
}