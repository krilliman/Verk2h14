using System;
using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Models.ViewModels
{
    public class MainCategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<SubCategoryViewModel> SubCategories { get; set; }
    }
}