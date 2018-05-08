using System;
using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        //public List<SubCategoryViewModel> SubCateGoryList { get; set; }
        public List<List<BookViewModel>> Books{ get; set;}
    }
}