using System.Collections.Generic;
using System.Linq;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class CategoryService
    {

        private CategoryRepo _categoryRepo;

        public CategoryService()
        {
            _categoryRepo = new CategoryRepo();
        }

        public List<MainCategoryViewModel> GetMainCategoryList(int? id)
        {
            var MainCategories = _categoryRepo.GetMainCategoryList(id);
            return MainCategories;
        }

        public List<SubCategoryViewModel> GetSubCategoryList(int? id)
        {
            var SubCategories = _categoryRepo.GetSubCategoryList(id);
            return SubCategories;
        }

        public List<BookViewModel> GetBookList(int? id)
        {
            var books = _categoryRepo.GetAllBooks(id);
            return books;
        }

        // Þessi föll sækja hina og þessa lista

        public CategoryIndexViewModel GetIndexViewModel()
        {
            var IndexViewModel = new CategoryIndexViewModel{
                                    BOTW = (from b in _categoryRepo.GetAllBooks(null)
                                            select b).OrderByDescending(x => x.Views).FirstOrDefault(),
                                    UserFav = (from b in _categoryRepo.GetAllBooks(null)
                                            select b).OrderByDescending(x => x.Rating).Take(1).FirstOrDefault(),
                                    NewestRelease = (from b in _categoryRepo.GetAllBooks(null)
                                            select b).OrderByDescending(b => b.PublishDate.ToUniversalTime()).FirstOrDefault(),
                                    CheapestBook = (from b in _categoryRepo.GetAllBooks(null)
                                            select b).OrderBy(x => x.TotalPrice).FirstOrDefault(),
                                    Top10AllCategories = GetMainCategoryTop10List(),
                                    Top10SubCategories = GetSubCategoryViewModel(null),
                                    
            };
            return IndexViewModel;
        }

        public List<MainCategoryTop10ListViewModel> GetMainCategoryTop10List()
        {
            var MainCategoriesWithTop10Books = (from m in GetMainCategoryList(null)
                                                select new MainCategoryTop10ListViewModel
                                                {
                                                    ID = m.ID,
                                                    Name = m.Name,
                                                    Top10Books = (from b in GetBookList(null)
                                                                where b.MainCategoryID == m.ID
                                                                select b).OrderByDescending(x => x.Rating).Take(4).ToList()
                                                }).ToList();
            return MainCategoriesWithTop10Books; 
        }


        public List<SubCategoryViewModel> GetSubCategoryViewModel(int? id)
        {
            if(id != null){
                var SubCategoryViewModelWithTop10 = (from s in GetSubCategoryList(id)
                                                where s.ID == id
                                                select new SubCategoryViewModel
                                                {
                                                    ID = s.ID,
                                                    Name = s.Name,
                                                    Top10Books = (from b in GetBookList(s.ID)
                                                                select b).OrderByDescending(x => x.Rating).Take(4).ToList(),
                                                    BookList = (from b in GetBookList(s.ID)
                                                                select b).OrderBy(x => x.Name).ToList()
                                                }).ToList();
            return SubCategoryViewModelWithTop10;
            }else{
                var SubCategoryViewModelWithTop10 = (from s in GetSubCategoryList(id)
                                                select new SubCategoryViewModel
                                                {
                                                    ID = s.ID,
                                                    Name = s.Name,
                                                    Top10Books = (from b in GetBookList(s.ID)
                                                                select b).OrderByDescending(x => x.Rating).Take(4).ToList(),
                                                    BookList = (from b in GetBookList(s.ID)
                                                                select b).OrderBy(x => x.Name).ToList()
                                                }).ToList();
            return SubCategoryViewModelWithTop10;
            } 
        }

        public List<MainCategoryViewModel> GetMainCategoryAndChildLists(int? id) //
        {
            var MainAndSubCategories = (from m in GetMainCategoryList(id)
                                        select new MainCategoryViewModel
                                        {
                                            ID = m.ID,
                                            Name = m.Name,
                                            SubCategories = GetSubCategoryAndChildList(m.ID),
                                        }).ToList();
            return MainAndSubCategories;
        }

        public  List<SubCategoryViewModel> GetSubCategoryAndChildList(int? id)
        {
            var SubCategoriesAndBooks = (from s in GetSubCategoryList(id)
                                                    select new SubCategoryViewModel
                                                    {
                                                        ID = s.ID,
                                                        Name = s.Name,
                                                        BookList = (GetBookList(s.ID)),
                                                    }).ToList();
            return SubCategoriesAndBooks;
        }
    }
}